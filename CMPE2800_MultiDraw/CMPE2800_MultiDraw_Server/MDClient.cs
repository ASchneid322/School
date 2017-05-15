using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using mdtypes;

namespace CMPE2800_MultiDraw_Server
{
    public partial class MDClient : Form
    {
        Queue<LineSegment> receivedSegs = new Queue<LineSegment>();
        List<mdConnection> allConnections = new List<mdConnection>();

        Thread sendSegs;
        Thread UIthread;

        Socket listener;

        private int allBytesRx = 0;
        private int allFramesRx = 0;

        #region Inits
        public MDClient()
        {
            InitializeComponent();
        }

        private void MDClient_Load(object sender, EventArgs e)
        {
            SetupListener();

            sendSegs = new Thread(ManageConnections);
            sendSegs.IsBackground = true;
            sendSegs.Start();

            UIthread = new Thread(UpdateUIThread);
            UIthread.IsBackground = true;
            UIthread.Start();
        }
        #endregion

        private void CreateConnection(IAsyncResult r)
        {
            Socket localListener = (Socket)r.AsyncState;

            Console.WriteLine("established connection");

            try
            {
                mdConnection conn = new mdConnection(localListener.EndAccept(r));
                conn.returnSeg += ls;
                conn.returnInfo += processData;

                lock(allConnections)
                    allConnections.Add(conn);
            }
            catch
            {
                Console.WriteLine("failed connection creation");
            }

            listener.Close();
            listener = null;
            SetupListener();              
        }

        private void ls(LineSegment lineseg)
        {            
            receivedSegs.Enqueue(lineseg);
        }

        private void processData(int data)
        {
            allBytesRx += data;
        }

        private void SetupListener()
        {
            if(listener != null)
            {
                // 1 listener only
                return;
            }

            try
            {
                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                listener.Bind(new IPEndPoint(IPAddress.Any, 1666));
            }
            catch
            {
                Console.WriteLine("Failed bind");
            }

            try
            {
                listener.Listen(5);
            }
            catch
            {
                Console.WriteLine("Listen fail");
            }

            try
            {
                listener.BeginAccept(CreateConnection, listener);
            }
            catch
            {

            }
        }

        private void ManageConnections()
        {
            while (true)
            {
                if (allConnections.Count > 0)
                {
                    lock(allConnections)
                        allConnections.RemoveAll(o => o!=null && !o._conState);

                    if(receivedSegs.Count > 0)
                    {
                        lock (receivedSegs)
                        {
                            foreach (mdConnection m in allConnections)
                            {
                                m.sendSeg(receivedSegs.First());
                            }
                        }
                       
                        receivedSegs.Dequeue();
                        allFramesRx++;
                    }
                }

                Thread.Sleep(0);
            }
        }

        private void UpdateUIThread()
        {
            while (true)
            {
                try
                {
                    Invoke(new Action(UpdateClear));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex);
                }

                if (allConnections.Count > 0)
                {
                    lock (allConnections)
                    {
                        foreach (mdConnection m in allConnections)
                        {
                            try
                            {
                                Invoke(new Action<string, string, string, int, int>(UpdateUI), new object[] {
                                IPAddress.Parse(((IPEndPoint)m._connection.RemoteEndPoint).Address.ToString()).ToString(),
                                m.destackAvg.ToString("F2"),
                                m.fragments.ToString(),
                                m.totalRx,
                                m.totalFrames
                            });
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(ex);
                            }
                        }
                    }
                }

                Thread.Sleep(100);
            }
        }

        private void UpdateUI(string IP, string destackAvg, string fragEvents, int bytesRx, int framesRx)
        {                                 
            LB_ClientInfo.Items.Add(string.Format("IP : {0} DestackAvg : {1} FragEvents : {2} BytesReceived : {3} FramesReceived : {4}", IP, destackAvg, fragEvents, bytesRx, framesRx));
        }

        private void UpdateClear()
        {
            LB_ClientInfo.Items.Clear();

            LB_ClientInfo.Items.Add(string.Format("Total Bytes : {0} Total Frames : {1}", allBytesRx, allFramesRx));
        }
    }
}

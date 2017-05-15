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
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using mdtypes;

namespace CMPE2800_MultiDraw_JKrueckl_ASchneider
{
    public partial class Form_Main : Form
    {
        //connection to the server
        private Socket _SockConnection = null;

        //recieving thread
        private Thread _Tr = null;
        //sending thread
        private Thread _Ts = null;
        //drawing thread
        private Thread _Td = null;

        //Queue for line seg recieve
        private Queue<LineSegment> _rxQ = new Queue<LineSegment>();

        //Queue for sending line segs
        private Queue<LineSegment> _sxQ = new Queue<LineSegment>();

        //point used for drawing linesegs
        private Point? _prevPt = null;

        private int _thickness = 1;
        private byte _alpha = 255;

        private bool _shifting = false;

        //Amount received
        private int receiveCount = 0;
        private int bytesCount = 0;

        private int defragC = 0;

        private delegate void DelVoidLineSeg(LineSegment ls);

        public Form_Main()
        {
            InitializeComponent();

            MouseWheel += Form_Main_MouseWheel;
        }

        private void Form_Main_MouseWheel(object sender, MouseEventArgs e)
        {
            if (!_shifting)
            {
                if (_thickness == 30 && e.Delta > 0)
                    _thickness = 30;
                else
                    _thickness += e.Delta / 120;

                if (_thickness < 1)
                    _thickness = 1;

                UI_S_Lb_Thickness.Text = "Thickness : " + _thickness;
            }
            else
            {
                if (_alpha == 255 && e.Delta > 0)
                    _alpha = 255;
                else
                    _alpha += (byte)(e.Delta / 120);

                if (_alpha < 1)
                    _alpha = 1;
               
                UI_S_Lb_Alpha.Text = "Alpha : " + _alpha;
            }

                         
        }

        private void rThread()
        {
            MemoryStream rxStream = new MemoryStream();
            byte[] rxBuff = new byte[2048];
            BinaryFormatter bf = new BinaryFormatter();
            int rxCount = 0;
            bool defragCheck = false;
            long lStartPos;
            int bytesR = 0;
            int fragments = 0;

            int totalFrames = 0;
            int totalRx = 0;

            //long lDefragEnd;

            while (true)
            {
                try
                {
                    //Wait for data
                    try
                    {
                        rxCount = _SockConnection.Receive(rxBuff);
                        totalRx++;
              
                        if (rxCount <= 0)
                        {
                            Invoke(new Action(ReceiverDisconnect));
                            break;
                        }
                    }
                    catch (Exception)
                    {
                        Invoke(new Action(ReceiverDisconnect));
                        break;
                    }
                    bytesR = rxBuff.Count();
                    //Add recieved data to the end of the stream
                    //Reset position to where it was
                    long lPos = rxStream.Position;
                    rxStream.Seek(0, SeekOrigin.End);
                    rxStream.Write(rxBuff, 0, rxCount);
                    rxStream.Position = lPos;

                    //Attempt to extract objects
                    do
                    {
                        //Get position
                        lStartPos = rxStream.Position;
                        try
                        {
                            //Pull object from stream
                            //rxStream.Length
                            object o = bf.Deserialize(rxStream);
                            //Add to the queue of frames
                            lock (_rxQ)
                                _rxQ.Enqueue((LineSegment)o);
                            totalFrames++;
                        }
                        catch(Exception)
                        {
                            //Error, so return to start
                            rxStream.Position = lStartPos;
                            if (defragCheck)
                            {
                                rxStream.Position = rxStream.Seek(0, SeekOrigin.End);
                                defragC++;
                                if (defragC > 100)
                                {
                                    try
                                    {
                                        Invoke(new Action(ReceiverDisconnect));
                                    }
                                    catch (Exception)
                                    {

                                        throw;
                                    }
                                }
                            }
                            else
                                defragC = 0;

                            fragments++;
                            defragCheck = true;
                            //Quit the loop until enough data is recieved.
                            break;
                        }
                    }
                    while (rxStream.Position < rxStream.Length);
                    try
                    {
                        Invoke(new Action<int, int, float, int>(receivedInfo), totalFrames, fragments, (float)totalFrames / totalRx, rxCount);
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                    defragCheck = false;
                    //Clear stream is all data is processed.
                    if (rxStream.Position == rxStream.Length)
                    {
                        rxStream.Position = 0;
                        rxStream.SetLength(0);
                    }
                }
                catch (Exception err)
                {
                    //Unexpected so exit.
                    Console.WriteLine(err.Message);
                    break;
                }
            }
        }

        private void sThread()
        {
            MemoryStream ms;
            BinaryFormatter bf;
            LineSegment seg;
            //Run forever
            while (_SockConnection != null)
            {
                if (_SockConnection != null)
                {
                    if (_sxQ.Count > 0)
                    {
                        lock (_sxQ)
                            seg = _sxQ.Dequeue();
                        ms = new MemoryStream();
                        bf = new BinaryFormatter();

                        bf.Serialize(ms, seg);
                        try
                        {
                            _SockConnection.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
                        }
                        catch (Exception)
                        {
                            Invoke(new Action(ReceiverDisconnect));
                            break;
                        }
                        
                    }
                }
                Thread.Sleep(10);
            }
        }

        private void dThread()
        {
            LineSegment seg;
            while (_SockConnection!=null)
            {
                if (_rxQ.Count > 0)
                {
                    lock (_rxQ)
                        seg = _rxQ.Dequeue();
                    try
                    {
                        //Invoke(new DelVoidLineSeg(DrawSeg), seg);
                        Graphics g = CreateGraphics();
                        seg.Render(g);
                    }
                    catch (Exception err)
                    {
                        Console.WriteLine("Error: " + err);
                    }
                }
                Thread.Sleep(1);
            }
        }

        private void DrawSeg(LineSegment seg)
        {
            Graphics g = CreateGraphics();
            seg.Render(g);
        }

        private void UI_S_Lb_ConnectionState_Click(object sender, EventArgs e)
        {
            //there is a connection, terminate the reciever
            if (_SockConnection != null)
            {
                try
                {
                    _SockConnection.Shutdown(SocketShutdown.Both);
                    ReceiverDisconnect();
                }
                catch (Exception exc)
                {
                    Console.WriteLine("Failed to disconnect");
                }
                return;
            }

            DLG_Connect connector = new DLG_Connect();
            if(connector.ShowDialog() == DialogResult.OK)
            {
                _SockConnection = connector.Connection;

                // Reset UI before connect?

                UI_S_Lb_ConnectionState.Text = "Disconnect";

                _Tr = new Thread(rThread);
                _Tr.IsBackground = true;
                _Tr.Start();

                _Td = new Thread(dThread);
                _Td.IsBackground = true;
                _Td.Start();

                _Ts = new Thread(sThread);
                _Ts.IsBackground = true;
                _Ts.Start();
            }
        }

        private void ReceiverDisconnect()
        {
            //socket needs shutdown
            if (_SockConnection != null)
            {
                _SockConnection.Close();
                _SockConnection = null;

                _Tr = null;
                _Ts = null;
                _Td = null;
                _rxQ = new Queue<LineSegment>();
                _sxQ = new Queue<LineSegment>();
                _prevPt = null;
                bytesCount = 0;

                UI_S_Lb_FramesRX.Text = "Frames RX'ed : 0";
                UI_S_Lb_Fragments.Text = "Fragments: 0";
                UI_S_Lb_DestackAVG.Text = "Destack Avg.: 0";
                UI_S_Lb_BytesRX.Text = "Bytes RX'ed : 0";

                Graphics g = CreateGraphics();
                g.Clear(Color.White);
            }

            //update connection button
            UI_S_Lb_ConnectionState.Text = "Connect";
        }

        private void receivedInfo(int totalReceived, int frags, float destack, int bytes)
        {
            string bytesFormat;
            UI_S_Lb_FramesRX.Text = "Frames RX'ed : " + totalReceived;
            UI_S_Lb_Fragments.Text = "Fragments: " + frags;
            UI_S_Lb_DestackAVG.Text = String.Format("Destack Avg.: {0:F2}", destack);
            bytesCount += bytes;

            if (bytesCount > 1000000000)
                bytesFormat = String.Format("{0:f2}G", bytesCount / 1000000000.0);
            else if (bytesCount > 1000000)
                bytesFormat = String.Format("{0:f2}M", bytesCount / 1000000.0);
            else
                bytesFormat = String.Format("{0:f2}K", bytesCount / 1000.0);

            UI_S_Lb_BytesRX.Text = "Bytes RX'ed : " + bytesFormat;
        }

        private void Form_Main_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                if(_prevPt == null)
                {
                    _prevPt = e.Location;
                }
                else
                {
                    LineSegment newSeg = new LineSegment()
                    {
                        Start = (Point)_prevPt,
                        End = e.Location,
                        Colour = UI_S_Lb_Color.ForeColor,
                        Alpha = _alpha,
                        Thickness = (ushort)_thickness                       
                    };

                    _sxQ.Enqueue(newSeg);

                    _prevPt = e.Location;
                }
            }
            else
            {
                _prevPt = null;
            }
        }

        private void UI_S_Lb_Color_Click(object sender, EventArgs e)
        {
            if(DLG_Color.ShowDialog() == DialogResult.OK)
            {
                UI_S_Lb_Color.ForeColor = DLG_Color.Color;

            }
        }

        private void Form_Main_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.ShiftKey)
                _shifting = true;

            if(e.KeyCode == Keys.S)
            {
                MemoryStream ms;
                BinaryFormatter bf;

                if (_SockConnection != null)
                {
                    string g = "asda";
                    ms = new MemoryStream();
                    bf = new BinaryFormatter();

                    bf.Serialize(ms, g);
                    try
                    {
                        _SockConnection.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
                    }
                    catch (Exception)
                    {
                    }
                }
            }
        }

        private void Form_Main_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.ShiftKey)
                _shifting = false;
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {

        }
    }
}

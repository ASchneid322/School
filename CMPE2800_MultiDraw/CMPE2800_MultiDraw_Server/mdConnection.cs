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

namespace CMPE2800_MultiDraw_Server
{
    class mdConnection
    {
        public delegate void delVoidLineSegment(LineSegment ls);
        public event delVoidLineSegment returnSeg;

        public delegate void delVoidInt(int info);
        public event delVoidInt returnInfo;

        public bool _conState { get; private set; } = true;
        private Queue<LineSegment> _txQ = new Queue<LineSegment>();
        //Recive thread
        private Thread _rT;
        private Thread _tT;

        public int totalFrames = 0;
        public int totalRx = 0;
        public int fragments = 0;

        public Socket _connection { get; private set; }

        public float destackAvg
        {
            get
            {
                if (totalRx > 0)
                    return (float)totalFrames / totalRx;
                else
                    return 1;
            }
        }

        public mdConnection(Socket connection)
        {
            _connection = connection;
            _conState = true;

            _rT = new Thread(rX);
            _rT.IsBackground = true;
            _rT.Start();

            _tT = new Thread(tX);
            _tT.IsBackground = true;
            _tT.Start();
        }

        public void Quit()
        {            
            _connection.Close();
            _connection = null;

            _conState = false;
        }

        private void rX()
        {
            MemoryStream rxStream = new MemoryStream();
            byte[] rxBuff = new byte[2048];
            BinaryFormatter bf = new BinaryFormatter();
            int rxCount = 0;
            bool defragCheck = false;
            long lStartPos;
            int bytesR = 0;
            
            int defragC = 0;

            //long lDefragEnd;

            while (true)
            {
                try
                {
                    //Wait for data
                    try
                    {
                        rxCount = _connection.Receive(rxBuff);
                        totalRx++;

                        if (rxCount <= 0)
                        {
                            Quit();
                            break;
                        }

                        returnInfo(rxCount);
                    }
                    catch (Exception)
                    {
                        Quit();
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

                            /*lock (_rxQ)
                                _rxQ.Enqueue((LineSegment)o);*/

                            returnSeg((LineSegment)o);
                            
                            totalFrames++;
                        }
                        catch (Exception ex)
                        {
                            if(ex is InvalidCastException)
                            {
                                Quit();
                            }

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
                            //Quit the loop until enough data is recieved.*/
                            break;
                        }
                    }
                    while (rxStream.Position < rxStream.Length);
                   /* try
                    {
                        Invoke(new Action<int, int, float, int>(receivedInfo), totalRx, fragments, (float)totalFrames / totalRx, rxCount);
                    }
                    catch (Exception)
                    {

                        throw;
                    }*/
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

        public void sendSeg(LineSegment seg)
        {
            lock (_txQ)
                _txQ.Enqueue(seg);
        }

        private void tX()
        {
            MemoryStream ms;
            BinaryFormatter bf;
            LineSegment seg;
            //Run forever
            while (_connection != null)
            {
                if (_connection != null)
                {
                    if (_txQ.Count > 0)
                    {
                        lock (_txQ)
                            seg = _txQ.Dequeue();
                        ms = new MemoryStream();
                        bf = new BinaryFormatter();

                        bf.Serialize(ms, seg);
                        try
                        {
                            _connection.Send(ms.GetBuffer(), (int)ms.Length, SocketFlags.None);
                        }
                        catch (Exception)
                        {
                            //Invoke(new Action(ReceiverDisconnect));
                            break;
                        }

                    }
                }
                Thread.Sleep(10);
            }
        }
    }
}

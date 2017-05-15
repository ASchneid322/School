using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CMPE2800_MultiDraw_JKrueckl_ASchneider
{
    public partial class DLG_Connect : Form
    {
        private delegate void delVoidBool(bool b);

        //the socket connection
        public Socket Connection { get; protected set; } = null;

        public DLG_Connect()
        {
            InitializeComponent();

            //hide status label
            UI_L_Status.Text = "";
        }

        /// <summary>
        /// Begins connection to the supplied server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UI_B_Connect_Click(object sender, EventArgs e)
        {
            //create connection
            try
            {
                Connection = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);

                //begin asynchronous connect
                Connection.BeginConnect(
                    UI_TB_Address.Text,             //address from textbox
                    int.Parse(UI_TB_Port.Text),     //port from textbox
                    cbConnectionComplete,
                    Connection);


                UI_L_Status.Text = "Establishing Connection... Please wait.";
                UI_Tim_Timout.Enabled = true;
                UI_B_Connect.Enabled = false;
            }

            catch (Exception)
            {
                UI_L_Status.Text = "Failed to begin connection, please try again.";

                Connection = null;
            }
        }

        /// <summary>
        /// User cancelled connection.
        /// </summary>
        private void UI_B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// In async thread, completes connection.
        /// </summary>
        private void cbConnectionComplete(IAsyncResult ar)
        {
            //pull socket out
            Socket tempSocket = (Socket)ar.AsyncState;

            //end connection
            try
            {
                tempSocket.EndConnect(ar);

                //assume success
                Invoke(new delVoidBool(ConnectionResult), true);
            }

            //connection failure
            catch (SocketException ex)
            {
                //potential the dialog closes and callback occurs afterwards
                try
                {
                    if (ex.NativeErrorCode == 10051)
                        Invoke(new Action(() => UpdateStatus("Failed to resolve host.")));

                    else if (ex.NativeErrorCode == 10060)
                        Invoke(new Action(() => UpdateStatus("Server refused connection.")));

                    else
                        Invoke(new Action(() => UpdateStatus("Failed to connect to server.")));

                    Invoke(new delVoidBool(ConnectionResult), false);
                }

                //can't do much reporting
                catch (Exception)
                { }
            }

            //other errors
            catch
            {
                try
                {
                    Invoke(new delVoidBool(ConnectionResult), false);
                    Invoke(new Action(() => UpdateStatus("Failed to connect.")));
                }
                catch (Exception)
                { }
            }
        }

        /// <summary>
        /// Connection process end. Close dialog for success, report error if failure.
        /// </summary>
        /// <param name="success"></param>
        private void ConnectionResult(bool success)
        {
            if (success)
            {
                DialogResult = DialogResult.OK;
            }

            else
            {
                UI_Tim_Timout.Enabled = false;
                UI_PB_Connecting.Value = 0;
                UI_B_Connect.Enabled = true;

                Connection = null;
            }
        }

        /// <summary>
        /// Updates status with a message.
        /// </summary>
        /// <param name="msg">Message to show.</param>
        private void UpdateStatus(string msg)
        {
            UI_L_Status.Text = msg;
        }

        /// <summary>
        /// Advance timeout progress bar.
        /// </summary>
        private void UI_Tim_Timout_Tick(object sender, EventArgs e)
        {
            UI_PB_Connecting.PerformStep();
        }

        private void DLG_Connect_Load(object sender, EventArgs e)
        {

        }
    }
}

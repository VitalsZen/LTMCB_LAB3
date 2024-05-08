using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03
{
    public partial class TCPServer3 : Form
    {
        public TCPServer3()
        {
            InitializeComponent();
        }

        private void btListen_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }

        void StartUnsafeThread()
        {
            try
            {
                int bytesReceived = 0;
                byte[] recv = new byte[1024];
                Socket clientSocket;
                Socket listenerSocket = new Socket(
                    AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Any, 8080);
                listenerSocket.Bind(ipepServer);
                listenerSocket.Listen(1);
                clientSocket = listenerSocket.Accept();
                IPEndPoint remoteEndPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
                IPAddress remoteIPAddress = remoteEndPoint.Address;
                lvConnection.Items.Add(remoteIPAddress.ToString() + " connected");
                while (clientSocket.Connected)
                {
                    string text = "";
                    bytesReceived = clientSocket.Receive(recv);
                    text += Encoding.ASCII.GetString(recv);

                    lvConnection.Items.Add(remoteIPAddress.ToString() + ": " + text);
                    if (text == "quit")
                    {

                        clientSocket.Close();
                        clientSocket.Disconnect(true);
                        break;
                    }
                }
                listenerSocket.Close();
                lvConnection.Items.Add(remoteIPAddress.ToString() + " disconnected");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
    }
}

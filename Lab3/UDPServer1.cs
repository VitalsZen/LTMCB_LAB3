using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace Lab3
{
    public partial class UDPServer1 : Form
    {
        delegate void InfoMessageDel(String info);
        public UDPServer1()
        {
            InitializeComponent();
        }

        public void serverThread()
        {
            UdpClient udpClient = new UdpClient(8080);
            while (true)
            {
                IPEndPoint RemoteIPEndPoint = new IPEndPoint(IPAddress.Any, 0);
                Byte[] receiveBytes = udpClient.Receive(ref RemoteIPEndPoint);
                string returnData = Encoding.ASCII.GetString(receiveBytes);
                string mess = RemoteIPEndPoint.Address.ToString() + "(" +
                    RemoteIPEndPoint.Port.ToString() + "):" + returnData.ToString();

                InfoMessage(mess);
            }
        }

        public void InfoMessage(string info)
        {
            if (lbMessages.InvokeRequired)
            {
                InfoMessageDel method = new InfoMessageDel(InfoMessage);
                lbMessages.Invoke(method, new object[] { info });
                return;
            }

            lbMessages.Items.Add(info);
        }

        private void UDP_Server_Load(object sender, EventArgs e)
        {
            Thread thdUDPServer = new Thread(new ThreadStart(serverThread));
            thdUDPServer.Start();
        }
    }
}

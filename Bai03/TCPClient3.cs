using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai03
{
    public partial class TCPClient3 : Form
    {
        TcpClient tcpClient;
        NetworkStream ns;

        public TCPClient3()
        {
            InitializeComponent();
        }

        private void btConnect_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient = new TcpClient();
                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse(tbIP.Text), 8080);
                tcpClient.Connect(ipEndPoint);
                ns = tcpClient.GetStream();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btSend_Click(object sender, EventArgs e)
        {

            Byte[] data = System.Text.Encoding.ASCII.GetBytes(tbMessage.Text);
            ns.Write(data, 0, data.Length);
            ns.Flush();
        }

        private void btDisconnect_Click(object sender, EventArgs e)
        {
            Byte[] data = System.Text.Encoding.ASCII.GetBytes("quit\n");
            ns.Write(data, 0, data.Length);
            ns.Close();
            tcpClient.Close();
        }
    }
}

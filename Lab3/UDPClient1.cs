using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab3
{
    public partial class UDPClient1 : Form
    {
        public UDPClient1()
        {
            InitializeComponent();
        }

        private void btSend_Click(object sender, EventArgs e)
        {
            if (tbIP.Text == "" || tbPort.Text == "")
            {
                MessageBox.Show("Dia chi IP: \nPort cua Server: 8080", "Canh bao!!");
            }
            UdpClient udpClient = new UdpClient();
            udpClient.Connect(tbIP.Text, Int32.Parse(tbPort.Text));
            Byte[] sendBytes = Encoding.ASCII.GetBytes(tbMessage.Text);
            udpClient.Send(sendBytes);
        }
    }
}

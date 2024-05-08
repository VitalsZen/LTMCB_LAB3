using System.Net.Sockets;
using System.Net;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace Bai02
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btStart_Click(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
            serverThread.Start();
        }

        void StartUnsafeThread()
        {
            int bytesReceived = 0;
            byte[] recv = new byte[1];
            Socket clientSocket;
            Socket listenerSocket = new Socket(
                              AddressFamily.InterNetwork,
                              SocketType.Stream,
                              ProtocolType.Tcp
                              );
            IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
            listenerSocket.Bind(ipepServer);
            listenerSocket.Listen(-1);
            clientSocket = listenerSocket.Accept();
            IPEndPoint remoteEndPoint = (IPEndPoint)clientSocket.RemoteEndPoint;
            lvCommand.Items.Add("New client connected: " + remoteEndPoint.Address + " " + remoteEndPoint.Port);
            while (clientSocket.Connected)
            {
                string text = "";
                do
                {
                    bytesReceived = clientSocket.Receive(recv);
                    text += Encoding.ASCII.GetString(recv);
                }
                while (text[text.Length - 1] != '\n');
                lvCommand.Items.Add(remoteEndPoint.Address + " (" + remoteEndPoint.Port + "): " + text);
            }
            listenerSocket.Close();
        }


    }
}

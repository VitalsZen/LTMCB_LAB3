using System;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Bai06
{
    public partial class Form2 : Form
    {
        const string SERVER_IP = "127.0.0.1";
        const int PORT = 8888;
        string user;
        TcpClient client;
        NetworkStream stream;
        public Form2()
        {
            InitializeComponent();
        }

        public Form2(string username)
        {
            InitializeComponent();
            string user = username;
            client = new TcpClient(SERVER_IP, PORT);
            stream = client.GetStream();
            Init(user);
        }

        public void StartUnsafeThread()
        {
            CheckForIllegalCrossThreadCalls = false;
            var receiveThread = new System.Threading.Thread(() => ReceiveMessages(client));
            receiveThread.Start();
        }
        void Init(string username)
        {
            
            MessageBox.Show("Connected to server");


            
            byte[] usernameBytes = Encoding.ASCII.GetBytes(username);
            stream.Write(usernameBytes, 0, usernameBytes.Length);
            stream.Flush();
            Console.WriteLine("Type '@username message' to send a private message");
            Console.WriteLine("Start typing your message:");

            // Start receiving messages in a separate thread
            StartUnsafeThread();

            // Send messages from the console
            

        }

        private void btSend_Click(object sender, EventArgs e)
        {
            byte[] messageBytes = Encoding.ASCII.GetBytes(tbMessage.Text);
            stream.Write(messageBytes, 0, messageBytes.Length);
            stream.Flush();
        }

    
        void ReceiveMessages(TcpClient client)
        {
            NetworkStream stream = client.GetStream();
            byte[] buffer = new byte[1024];
            int bytesRead;
            while (true)
            {
                try
                {
                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string received = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        lbMessage.Items.Add(received);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                    break;
                }
            }
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Net.Sockets;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;
//using System.Data.Common;
//using System.IO;

//namespace Bai06
//{
//    public partial class Form2 : Form
//    {

//        TcpClient tcpClient;
//        NetworkStream ns;
//        string user;
//        public Form2()
//        {
//            InitializeComponent();
//        }

//        public Form2(string username)
//        {
//            user = username;
//            InitializeComponent();
//            Init();
//        }
//        private void Init()
//        {
//            try
//            {
//                tcpClient = new TcpClient();
//                IPEndPoint ipEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
//                tcpClient.Connect(ipEndPoint);
//                ns = tcpClient.GetStream();

//                Thread receiveThread = new Thread(ReceiveMessages);
//                receiveThread.Start();
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }
//        private void ReceiveMessages()
//        {
//            try
//            {
//                byte[] buffer = new byte[1024];
//                int bytesRead;

//                while ((bytesRead = ns.Read(buffer, 0, buffer.Length)) > 0)
//                {
//                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
//                    lbMessage.Items.Add(message);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }
//        private void btSend_Click(object sender, EventArgs e)
//        {
//            Byte[] data = System.Text.Encoding.ASCII.GetBytes(tbMessage.Text);
//            ns.Write(data, 0, data.Length);
//            ns.Flush();
//        }


//static Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();

//static void Init()
//{
//    TcpListener server = new TcpListener(IPAddress.Parse("127.0.0.1"), 1234);
//    server.Start();
//    Console.WriteLine("Server started...");

//    while (true)
//    {
//        TcpClient client = server.AcceptTcpClient();
//        Thread clientThread = new Thread(() => HandleClient(client));
//        clientThread.Start();
//    }
//}

//static void HandleClient(TcpClient client)
//{
//    string clientId = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
//    clients.Add(clientId, client);
//    Console.WriteLine($"Client {clientId} connected.");

//    NetworkStream stream = client.GetStream();
//    byte[] buffer = new byte[1024];
//    int bytesRead;

//    try
//    {
//        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
//        {
//            string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
//            Console.WriteLine($"Received from {clientId}: {message}");

//            BroadcastMessage(clientId, message);
//        }
//    }
//    catch (Exception ex)
//    {
//        Console.WriteLine($"Client {clientId} disconnected: {ex.Message}");
//        clients.Remove(clientId);
//    }
//    finally
//    {
//        client.Close();
//    }
//}

//static void BroadcastMessage(string senderId, string message)
//{
//    foreach (var client in clients)
//    {
//        if (client.Key != senderId)
//        {
//            NetworkStream stream = client.Value.GetStream();
//            byte[] buffer = Encoding.ASCII.GetBytes($"Client {senderId}: {message}");
//            stream.Write(buffer, 0, buffer.Length);
//        }
//    }
//}
//    }
//}

using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.IO;

namespace Bai06
{
    public partial class Form3 : Form
    {
        

        static Dictionary<string, TcpClient> clients = new Dictionary<string, TcpClient>();
        static TcpListener listener;
        const int PORT = 8888;

        public Form3()
        {
            InitializeComponent();
            listener = new TcpListener(IPAddress.Any, PORT);
            listener.Start();
            Console.WriteLine($"Server started on port {PORT}");
            CheckForIllegalCrossThreadCalls = false;
            // Run AcceptClients method on a separate thread
            Task.Run(() => AcceptClients());
        }

        void AcceptClients()
        {
            while (true)
            {
                TcpClient client = listener.AcceptTcpClient();
                Thread clientThread = new Thread(() => HandleClient(client));
                clientThread.Start();
            }
        }

        void HandleClient(TcpClient client)
        {
            string username = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
            clients.Add(username, client);
            lvConnection.Items.Add($"Client {username} connected");

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
                        string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                        Console.WriteLine($"Received from {username}: {message}");

                        if (message.StartsWith("@"))
                        {
                            string[] parts = message.Split(' ');
                            string recipient = parts[0].Substring(1); // Remove '@' from recipient username
                            string privateMessage = String.Join(" ", parts, 1, parts.Length - 1);
                            SendPrivateMessage(username, recipient, privateMessage);
                        }
                        else
                        {
                            BroadcastMessage(username, message);
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    break;
                }
            }

            clients.Remove(username);
            client.Close();
            Console.WriteLine($"Client {username} disconnected");
        }

        static void BroadcastMessage(string sender, string message)
        {
            foreach (var pair in clients)
            {
                TcpClient client = pair.Value;
                NetworkStream stream = client.GetStream();
                byte[] buffer = Encoding.ASCII.GetBytes($"{sender}: {message}");
                stream.Write(buffer, 0, buffer.Length);
            }
        }

        static void SendPrivateMessage(string sender, string recipient, string message)
        {
            if (clients.ContainsKey(recipient))
            {
                TcpClient client = clients[recipient];
                NetworkStream stream = client.GetStream();
                byte[] buffer = Encoding.ASCII.GetBytes($"(Private) {sender}: {message}");
                stream.Write(buffer, 0, buffer.Length);
            }
            else
            {
                Console.WriteLine($"User '{recipient}' not found.");
            }
        }
    }
}


//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.Common;
//using System.Drawing;
//using System.Linq;
//using System.Net.Sockets;
//using System.Net;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace Bai06
//{
//    public partial class Form3 : Form
//    {
//        public Form3()
//        {
//            InitializeComponent();
//        }

//        private static Dictionary<string, Socket> clients = new Dictionary<string, Socket>();


//        private void StartUnsafeThread()
//        {
//            try
//            {
//                Socket listenerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//                IPEndPoint ipepServer = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
//                listenerSocket.Bind(ipepServer);
//                listenerSocket.Listen(10);
//                while (true)
//                {
//                    // Accept incoming connection
//                    Socket clientSocket = listenerSocket.Accept();

//                    // Start a new thread to handle the client
//                    Thread clientThread = new Thread(() => HandleClient(clientSocket));
//                    clientThread.Start();
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }



//            //    while (clientSocket.Connected)
//            //    {
//            //        string text = "";
//            //        bytesReceived = clientSocket.Receive(recv);
//            //        text += Encoding.ASCII.GetString(recv);

//            //        lvConnection.Items.Add(new ListViewItem(remoteIPAddress.ToString() + ": " + text));
//            //        if (text == "quit")
//            //        {

//            //            clientSocket.Close();
//            //            clientSocket.Disconnect(true);
//            //            break;
//            //        }
//            //    }
//            //    listenerSocket.Close();
//            //    lvConnection.Items.Add(new ListViewItem(remoteIPAddress.ToString() + " disconnected"));

//            //}


//        private void HandleClient(Socket clientSocket)
//        {
//            try
//            {
//                string clientId = ((IPEndPoint)clientSocket.RemoteEndPoint).Address.ToString();
//                clients.Add(clientId, clientSocket);
//                Console.WriteLine($"Client {clientId} connected.");

//                NetworkStream stream = new NetworkStream(clientSocket);
//                byte[] buffer = new byte[1024];
//                int bytesRead;

//                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
//                {
//                    string message = System.Text.Encoding.ASCII.GetString(buffer, 0, bytesRead);
//                    lvConnection.Items.Add($"{clientId}: {message}");

//                    BroadcastMessage(clientId, message);
//                }
//            }
//            catch (Exception ex)
//            {
//                Console.WriteLine($"Error handling client: {ex.Message}");
//            }
//            finally
//            {
//                clientSocket.Close();
//            }
//        }
//        private static void BroadcastMessage(string senderId, string message)
//        {
//            foreach (var client in clients)
//            {
//                if (client.Key != senderId)
//                {
//                    NetworkStream stream = new NetworkStream(client.Value);
//                    byte[] buffer = Encoding.ASCII.GetBytes($"Client {senderId}: {message}");
//                    stream.Write(buffer, 0, buffer.Length);
//                    stream.Flush();
//                }
//            }
//        }

//        private void btListen_Click_1(object sender, EventArgs e)
//        {
//            CheckForIllegalCrossThreadCalls = false;
//            Thread serverThread = new Thread(new ThreadStart(StartUnsafeThread));
//            serverThread.Start();
//        }
//    }
//}

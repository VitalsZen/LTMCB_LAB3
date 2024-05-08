﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using System.Net.Sockets;
using System.Net;

namespace Bai04
{
    public partial class Server4 : Form
    {

        public Server4()
        {
            InitializeComponent();
            DataClient dataclient = new DataClient(8888);
            dataclient.Start();
            rtb1_Show.Text = @"Nhập thông tin của từng loại phim cho rạp( nếu muốn nhập mới) thì ấn vào ""Write to a file"" " + '\n' + @"- Hoặc ấn ""Đặt vé"" để thực hiện đặt vé ngay và luôn vì file input5.txt đã có sẵn data về phim (không cần nhập lại data)";
        }
        static int n = 0;
        List<CPhim> Phims = new List<CPhim>();

        
        private void bt1_WtF_Click(object sender, EventArgs e)
        {
            if (tbTotal.Text == "")
            {
                MessageBox.Show("Nhap so luong phim vao Total");
                tbTotal.Enabled = true;
                return;
            }
        }

        private void EnableInput()
        {
            tbName.Enabled = true;
            cbRoom1.Enabled = true;
            cbRoom2.Enabled = true;
            cbRoom3.Enabled = true;
            tbCost.Enabled = true;
            btAdd.Enabled = true;
        }
        private void tbTotal_TextChanged(object sender, EventArgs e)
        {
            if (!Int32.TryParse(tbTotal.Text, out int temp))
            {
                MessageBox.Show(@"Nhap so nguyen vao thanh ""So luong phim"": ");
                return;
            }
            n = temp;
            tbCount.Text = n.ToString();
            MessageBox.Show("Nhap day du thong tin phim vao cac o phia duoi!! ");

            EnableInput();
        }
        private bool CheckLoiNhap()
        {
            // ghi thong bao loi o day
            return false;
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            try
            {
                CPhim Phim = new CPhim();
                int num = Int32.Parse(tbCount.Text);
                Phim.TenPhim = tbName.Text;
                if (cbRoom1.CheckState == CheckState.Checked)
                {
                    Phim.Phong.Add(new CPhim.CPhong { TenPhong = cbRoom1.Text.Trim() });
                }
                if (cbRoom2.CheckState == CheckState.Checked)
                {
                    Phim.Phong.Add(new CPhim.CPhong { TenPhong = cbRoom2.Text.Trim() });
                }
                if (cbRoom3.CheckState == CheckState.Checked)
                {
                    Phim.Phong.Add(new CPhim.CPhong { TenPhong = cbRoom3.Text.Trim() });
                }
                Phim.GiaVe = Int32.Parse(tbCost.Text);
                tbCount.Text = (num - 1).ToString();
                {
                    Phims.Add(Phim);
                    MessageBox.Show("Nhap thanh cong!!, con lai " + tbCount.Text + " lan nhap");
                    tbName.Text = "";
                    tbCost.Text = "";
                    cbRoom1.CheckState = CheckState.Unchecked;
                    cbRoom2.CheckState = CheckState.Unchecked;
                    cbRoom3.CheckState = CheckState.Unchecked;
                    tbTotal.Enabled = false;
                }
                if (tbCount.Text == "0")
                {
                    MessageBox.Show("Thuc hien day thong tin vao file ....", "Canh bao", MessageBoxButtons.OK);
                    SerializeJson(Phims, "input5.txt");
                    SerializeJson(Phims, "output5.txt");
                    //DisableInput();
                    //bt3_Read.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private List<CPhim> DeserializeJson(string Filepath)
        {
            string json = File.ReadAllText(Filepath);
            List<CPhim> Phims = JsonSerializer.Deserialize<List<CPhim>>(json);
            return Phims;
        }

        private void SerializeJson(object obj, string Filepath)
        {
            string json = JsonSerializer.Serialize(obj);
            File.WriteAllText(Filepath, json);
        }

        private void btDatVe_Click(object sender, EventArgs e)
        {
            var Form = new TicketDashboard4();
            Form.Show();
        }

        private static void RankPhim(List<CPhim> cphimList)
        {

            for (int i = 0; i < cphimList.Count - 1; i++)
            {
                for (int j = 0; j < cphimList.Count - 1 - i; j++)
                {
                    if (cphimList[j].TongTien < cphimList[j + 1].TongTien)
                    {
                        CPhim temp = cphimList[j];
                        cphimList[j] = cphimList[j + 1];
                        cphimList[j + 1] = temp;
                    }
                }
            }

            for (int i = 0; i < cphimList.Count; i++)
            {
                cphimList[i].Rank = i + 1;
            }
        }
        private void bt3_Read_Click(object sender, EventArgs e)
        {
            progressBar1.Value = 0;
            try
            {
                Phims = DeserializeJson("output5.txt");
                RankPhim(Phims);
                rtb1_Show.Clear();
                int progressStep = 100 / Phims.Count;
                foreach (var c in Phims)
                {
                    progressBar1.Value += progressStep;
                    progressBar1.Refresh();

                    rtb1_Show.Text += "Ten phim: " + c.TenPhim + '\n';
                    double vetong = 0;
                    double veban = 0;
                    foreach (CPhim.CPhong c2 in c.Phong)
                    {
                        vetong += 15;
                        veban += c2.suat.Length;
                    }
                    rtb1_Show.Text += "So ve ban duoc: " + (vetong - veban).ToString() + '\n' + "So ve ton: " + veban.ToString() + '\n';
                    rtb1_Show.Text += "Ti le ve ban duoc: " + (((vetong - veban) / vetong) * 100).ToString("0.00") + "%" + '\n' + "Doanh thu: " + c.TongTien.ToString() + '\n' + "Xep hang doanh thu: " + c.Rank + "\n\n";
                }

            }
            catch (JsonException)
            {
                MessageBox.Show("File thông kế (output5.txt) hiện không có dữ liệu để trích xuất hoặc lỗi về Json ");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public class DataClient
        {
            private TcpListener listener;
            private const int BufferSize = 4096;

            public DataClient(int port)
            {
                listener = new TcpListener(IPAddress.Any, port);
            }

            public void Start()
            {
                Task.Run(() => RunServer());
            }

            private void RunServer()
            {
                listener.Start();
                Console.WriteLine("Client-as-Server started. Waiting for connections...");

                while (true)
                {
                    TcpClient client = listener.AcceptTcpClient();
                    Task.Run(() => HandleClient(client));
                }
            }

            private void HandleClient(TcpClient client)
            {
                Console.WriteLine($"Client connected: {((IPEndPoint)client.Client.RemoteEndPoint).Address}");

                NetworkStream stream = client.GetStream();

                // Send info.txt (serialized CPhim data) to client
                SendFile("info.txt", stream);

                // Receive file from client and save as info.txt
                ReceiveFile("info.txt", stream);

                // Close connection
                stream.Close();
                client.Close();
            }

            private void SendFile(string filepath, NetworkStream stream)
            {

                byte[] fileBytes = File.ReadAllBytes(filepath);
                stream.Write(fileBytes, 0, fileBytes.Length);
            }

            private void ReceiveFile(string filepath, NetworkStream stream)
            {
               
                byte[] fileSizeBuffer = new byte[4];
                stream.Read(fileSizeBuffer, 0, 4);
                int fileSize = BitConverter.ToInt32(fileSizeBuffer, 0);
                if (fileSize == 0)
                {
                    return;
                }
                byte[] buffer = new byte[fileSize];
                int bytesRead = 0;
                while (bytesRead < fileSize)
                {
                    int bytesToRead = Math.Min(fileSize - bytesRead, BufferSize);
                    int received = stream.Read(buffer, bytesRead, bytesToRead);
                    bytesRead += received;
                }

                File.WriteAllBytes(filepath, buffer);
            }
        }
        


    }
}




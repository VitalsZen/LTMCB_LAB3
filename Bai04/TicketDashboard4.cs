using System.IO;
using System.Net.Sockets;
using System.Security.Claims;
using System.Text.Json;

namespace Bai04
{
    public partial class TicketDashboard4 : Form
    {
        List<CPhim> Phims = new List<CPhim>();
        static CPhim SelectedPhim = new CPhim();
        static CPhim.CPhong SelectedPhong = new CPhim.CPhong();
        TcpClient client;
        NetworkStream stream;

        
        public TicketDashboard4()
        {
            InitializeComponent();

            
            client = new TcpClient("localhost", 8888);
            stream = client.GetStream();

            // Start a thread for receiving files from the server

            StartUnsafeThread();
            
            
        }

        public void StartUnsafeThread()
        {
            CheckForIllegalCrossThreadCalls = false;
            Thread receiveThread = new Thread(ReceiveFile);
            receiveThread.Start();
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

        private void cb2_Movie_SelectionChangeCommitted(object sender, EventArgs e)
        {
            cb1_Theater.Items.Clear();
            if (cb2_Movie.SelectedItem != null)
            {
                foreach (CPhim Phim in Phims)
                {
                    if (Phim.TenPhim == cb2_Movie.SelectedItem.ToString())
                    {
                        //MessageBox.Show("1");
                        SelectedPhim = Phim;
                        break;
                    }
                }

                if (SelectedPhim != null && SelectedPhim.Phong != null)
                {
                    //MessageBox.Show("2"); 
                    foreach (CPhim.CPhong phong in SelectedPhim.Phong)
                    {
                        cb1_Theater.Items.Add(phong.TenPhong);
                    }
                }
                cb1_Theater.Enabled = true;
            }
        }

        private void cb1_Theater_SelectionChangeCommitted(object sender, EventArgs e)
        {
            clb1_Seats.Items.Clear();
            if (cb1_Theater.SelectedItem != null && SelectedPhim != null && SelectedPhim.Phong != null)
            {
                //MessageBox.Show("3"); ;
                foreach (CPhim.CPhong c in SelectedPhim.Phong)
                {
                    if (c.TenPhong == cb1_Theater.SelectedItem.ToString())
                    {
                        //MessageBox.Show("4"); ;
                        SelectedPhong = c;
                        break;
                    }
                }

                if (SelectedPhong.suat != null)
                {
                    clb1_Seats.Items.AddRange(SelectedPhong.suat);
                }
            }

        }

        private void clb1_Seats_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (clb1_Seats.CheckedItems.Count == 1)
            {
                if (e.NewValue == CheckState.Unchecked)
                    bt1_Confirm.Enabled = false;
            }
            else
                bt1_Confirm.Enabled = true;
        }

        private void bt1_Confirm_Click(object sender, EventArgs e)
        {
            long tong = 0; // tinh tổng tiền từ checked seats
            long cost = SelectedPhim.GiaVe;
            foreach (string c in clb1_Seats.CheckedItems)
            {
                if (new[] { "A1", "A5", "B1", "B5", "C1", "C5" }.Contains(c))
                {
                    tong += cost * 1 / 4;
                }
                else if (new[] { "A2", "A3", "A4", "C2", "C3", "C4" }.Contains(c))
                {
                    tong += cost * 1;
                }
                else
                {
                    tong += cost * 2;
                }
            }
            string s = "Ho va ten: " + tb1_Name.Text;
            s += System.Environment.NewLine + "Các vé đã chọn: ";
            foreach (string c in clb1_Seats.CheckedItems)
                s += c + " ";
            s += System.Environment.NewLine;
            s += "Phòng chiếu: " + cb1_Theater.Text;
            s += System.Environment.NewLine;
            s += "Số tiền phải trả: " + tong.ToString();


            if (MessageBox.Show(s, "Warning !!", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No) // thông báo lần cuối chắc chắn hay ko ? 
            {
                return;
            }
            else
            {
                MessageBox.Show("Bạn đã đặt vé thành công.", "Congratulations", MessageBoxButtons.OK, MessageBoxIcon.Information);
                SelectedPhim.TongTien += tong;
                HashSet<string> temp = SelectedPhong.suat.ToHashSet();
                foreach (string c in clb1_Seats.CheckedItems)
                {
                    temp.Remove(c);
                }
                SelectedPhong.suat = temp.ToArray();
                foreach (var c in SelectedPhim.Phong)
                {
                    if (c.TenPhong == SelectedPhong.TenPhong)
                    {
                        SelectedPhim.Phong.Remove(c);
                        SelectedPhim.Phong.Add(SelectedPhong);
                        break;
                    }
                }
                foreach (var c in Phims)
                {
                    if (SelectedPhim.TenPhim == c.TenPhim)
                    {
                        Phims.Remove(c);
                        Phims.Add(SelectedPhim);
                        break;
                    }
                }
                SerializeJson(Phims, "output5.txt");
                SendFile("output5.txt");
                // blank các ô -> đẹp
                tb1_Name.Text = "";
                cb2_Movie.Text = "";
                cb1_Theater.Text = "";
                cb1_Theater.Enabled = false;
                SelectedPhim = null;
                SelectedPhong = new CPhim.CPhong();
                cb1_Theater.Items.Clear();
                clb1_Seats.Items.Clear();
            }
        }

        private void bt2_Reset_Click(object sender, EventArgs e)
        {
            tb1_Name.Text = "";
            cb2_Movie.Text = "";
            cb1_Theater.Text = "";
            cb1_Theater.Enabled = false;

        }

        private void bt3_Exit_Click(object sender, EventArgs e)
        {
            stream.Close();
            client.Close();
            this.Close();
        }

        private void SendFile(string filepath)
        {
            byte[] fileBytes = File.ReadAllBytes(filepath);
            stream.Write(BitConverter.GetBytes(fileBytes.Length), 0, 4);
            stream.Write(fileBytes, 0, fileBytes.Length);
        }

        private void ReceiveFile()
        {
            try
            {
                while (true)
                {
                    byte[] buffer = new byte[4096];
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    if (bytesRead > 0)
                    {
                        string receivedFilepath = "received_tickets.txt"; 
                        using (FileStream fileStream = new FileStream(receivedFilepath, FileMode.Create, FileAccess.Write))
                        {
                            fileStream.Write(buffer, 0, bytesRead);
                        }
                        UpdateDashboard(receivedFilepath);
                    }
                }
            }
            catch (IOException ex) // thong bao loi/ tranh bi pause
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void UpdateDashboard(string filepath)
        {
            Phims = DeserializeJson(filepath);
            try
            {
                foreach (var phim in Phims)
                {
                    cb2_Movie.Items.Add(phim.TenPhim);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

    }
}

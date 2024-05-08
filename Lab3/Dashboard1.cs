using System.Net.Sockets;

namespace Lab3
{
    public partial class Dashboard1 : Form
    {
        public Dashboard1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            var Form = new UDPClient1();
            Form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Form = new UDPServer1();
            Form.Show();
        }

    }
}

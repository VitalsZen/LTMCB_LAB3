namespace Bai03
{
    public partial class Dashboard3 : Form
    {
        public Dashboard3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new TCPClient3();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new TCPServer3();
            form.Show();
        }
    }
}

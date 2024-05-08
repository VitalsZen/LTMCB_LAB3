using System.Net.Sockets;
using System.Net;

namespace Bai06
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tbConnect_Click(object sender, EventArgs e)
        {
            var form = new Form2(tbUsername.Text);
            form.Show();
        }
    }
}

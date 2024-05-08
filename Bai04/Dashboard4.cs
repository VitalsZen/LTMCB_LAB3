using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai04
{
    public partial class Dashboard4 : Form
    {
        public Dashboard4()
        {
            InitializeComponent();
        }

        private void btServer4_Click(object sender, EventArgs e)
        {
            var form = new Server4();
            form.Show();
        }

        private void btClient4_Click(object sender, EventArgs e)
        {
            var form = new TicketDashboard4();
            form.Show();
        }
    }
}

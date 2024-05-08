using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bai06
{
    public partial class Dashboard6 : Form
    {
        public Dashboard6()
        {
            InitializeComponent();
        }

        private void btUser_Click(object sender, EventArgs e)
        {
            var form = new Form1();
            form.Show();
        }

        private void btServer_Click(object sender, EventArgs e)
        {
            var form = new Form3();
            form.Show();
        }
    }
}

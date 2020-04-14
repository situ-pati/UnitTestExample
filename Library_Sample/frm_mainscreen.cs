using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Library_Sample
{
    public partial class frm_mainscreen : Form
    {
        public frm_mainscreen()
        {
            InitializeComponent();
        }

        private void addBooksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Add_Books a = new Add_Books();
            a.MdiParent = this;
            a.Show();
        }
    }
}

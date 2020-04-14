using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Library_Sample
{
    public partial class SearchBooks : Form
    {
        public SearchBooks()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            panel2.Enabled = true; panel3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Clear();
            string cmdstr ="select * from Books where ";
            if (textBox1.Text=="")
            {
                MessageBox.Show("Provide data in the search field");
                return;
            }
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    cmdstr += " bookID='" + textBox1.Text + "'";
                    break;
                case 1:
                    cmdstr += " bookname like'%" + textBox1.Text + "%'";
                    break;
                case 2:
                    cmdstr += " bookpubname like'%" + textBox1.Text + "%'";
                    break;
                case 3:
                    cmdstr += " bookautname like'%" + textBox1.Text + "%'";
                    break;
                case 4:
                    cmdstr += " bookcatname like'%" + textBox1.Text + "%'";
                    break;
                default:
                    break;
            }
            DbCon db = new DbCon();
            DataRowCollection dr= db.ExecuteSelectCommand(cmdstr);
            for (int i = 0; i < dr.Count; i++)
            {
                dataGridView1.Rows.Add(dr[i].ItemArray);
            }
            //dataGridView1.DataSource = dr;
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            panel4.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you really want to delete the item", "Admin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Books b = new Books();
                int x=   b.DeleteBook(dataGridView1.Rows[dataGridView1.SelectedRows[0].Index].Cells[0].Value.ToString());
                if (x>0)
                {
                    MessageBox.Show("Book is deleted");
                    dataGridView1.Rows.Clear();
                    textBox1.Text = "";
                    panel4.Enabled = false;
                    panel3.Enabled = false;
                    comboBox1.Text = "";
                }
            }
        }
    }
}

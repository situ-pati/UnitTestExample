using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Library_Sample
{
    public partial class Form1 : Form
    {
        OleDbConnection con;OleDbCommand cmd;OleDbDataAdapter adp;
        Login_CLass lc = new Login_CLass();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool log_s = lc.CheckLoginStatus(textBox1.Text, textBox2.Text);
            if (log_s==true)
            {
                frm_mainscreen x = new frm_mainscreen();
                x.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Login Unsucessful");
            }
        }

       

        private void Form1_Load(object sender, EventArgs e)
        {
            bool chk= lc.dbcheck("Provider = Microsoft.Jet.OLEDB.4.0; Data Source = " + Application.StartupPath + "\\lib_app.mdb");
            if (chk==false)
            {
                MessageBox.Show("Database conneection error. Please recheck the database connectivity");
            }
        }

       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.VisualBasic;

namespace Library_Sample
{
    public partial class Add_Books : Form
    {
       // OleDbConnection con;OleDbCommand cmd;OleDbDataAdapter adp;
        public Add_Books()
        {
            InitializeComponent();
        }
        DbCon con = new DbCon();
        private void Add_Books_Load(object sender, EventArgs e)
        {
           
            BookIDForAutocomplere();
           
        }

        private void BookIDForAutocomplere()
        {
            DataRowCollection ds = con.ExecuteSelectCommand("select * from Books");
            AutoCompleteStringCollection c = new AutoCompleteStringCollection();
            for (int i = 0; i < ds.Count; i++)
            {
                c.Add(ds[i].ItemArray[0].ToString());
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (BookIDExists(textBox1.Text))
            {
                MessageBox.Show("Book is already exists. You have to edit the stock value");
                groupBox2.Enabled = false;
            }
            else
            {
                groupBox2.Enabled = true;
            }
        }
        public bool BookIDExists(string ID)
        {
            bool res = true;
            try
            {
                //cmd=new OleDbCommand("Select * from books ")
                DbCon con = new DbCon();
                DataRowCollection ds;
                ds=con.ExecuteSelectCommand("select * from Books where BookID='" + ID + "'");
                if (ds.Count > 0)
                {
                    res = true;
                }
                else
                {
                    res = false;
                }
            }
            catch (Exception ex)
            {
                res = false;
                MessageBox.Show(ex.Message);
            }


            return res;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Information.IsNumeric(textBox7.Text))
            {
                MessageBox.Show("Please provide numeric value in Book Price.");
                textBox7.Focus();
                return;
            }
            if (!Information.IsNumeric(textBox8.Text))
            {
                MessageBox.Show("Please provide numeric value in Book Price.");
                textBox7.Focus();
                return;
            }
            if (!Information.IsNumeric(textBox10.Text))
            {
                MessageBox.Show("Please provide numeric value in Book Price.");
                textBox7.Focus();
                return;
            }
            foreach (var item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    TextBox t = (TextBox) item;
                    if (t.Text=="")
                    {
                        MessageBox.Show("You have to fill all the fields");
                        return;
                    }
                }
            }
            Books b = new Books();
            b.BookID = textBox1.Text;b.BookName = textBox2.Text;
            b.PublisherName = textBox3.Text; b.PublisherAdd = textBox4.Text; b.AuthorName = textBox5.Text;
            b.AuthorAdd = textBox6.Text;b.BookPrice = Convert.ToDouble( textBox7.Text);
            b.BookPafes = Convert.ToInt16(textBox8.Text); b.CatagoryName = textBox9.Text; b.Stock = Convert.ToInt16(textBox10.Text);
            DbCon d = new DbCon();
            int res= d.SaveBooks(b);
            if (res<=0)
            {
                MessageBox.Show("Sorry No Data is saved. Some error occurred");
            }
            else
            {
                MessageBox.Show("Record Saved Successfully");
            }
            Refresh_scr();
        }

        private void Refresh_scr()
        {
            foreach (var item in groupBox2.Controls)
            {
                if (item is TextBox)
                {
                    (item as TextBox).Text = ""; 
                }
            }

            textBox1.Text = "";
            groupBox2.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

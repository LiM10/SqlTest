using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notebook.cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView1.Visible = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string surname = textBox2.Text;
            string comment = textBox3.Text;

            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=P201\\SQLEXPRESS;Initial Catalog=example;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn.Open();
            string insert = "insert into dbo.person(name, surname, message) values('"+name+"', '"+surname+"','"+comment+"')";

            SqlCommand comm = new SqlCommand(insert, conn);
            comm.ExecuteNonQuery();
            conn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = "Data Source=P201\\SQLEXPRESS;Initial Catalog=example;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn.Open();
            string select = "select * from dbo.person";

            SqlCommand comm = new SqlCommand(select, conn);
            comm.ExecuteNonQuery();
            SqlDataAdapter adap = new SqlDataAdapter(comm);
            DataSet set = new DataSet();
            adap.Fill(set, "dbo.person");
            dataGridView1.DataSource = set.Tables["dbo.person"];
            conn.Close();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

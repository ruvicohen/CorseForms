using CorseForms.DAL;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorseForms.Forms
{
    internal partial class HomePageForm : Form
    {
        DBContext dbContext;
        public HomePageForm(DBContext DB)
        {
            InitializeComponent();
            dbContext = DB;
            string query = "select * from Intersted";
            DataTable interested = dbContext.MakeQuery(query, null);
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = interested;
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string query = "insert into Students(TZ, Name, Phone) values (@TZ, @Name,@Phone)";
            SqlParameter[] parameters = {
                        new SqlParameter("@TZ", int.Parse(textBox3.Text)),
                        new SqlParameter("@Name", textBox1.Text),
                        new SqlParameter("@Phone", int.Parse(textBox2.Text))
                    };
            bool isInsert = dbContext.ExecuteNonQuery(query, parameters);
            if (isInsert)
            {
                MessageBox.Show("הפרטים נשמרו בהצלחה");
            }
            else {
                MessageBox.Show("Error");

                    }

        }
    }
}

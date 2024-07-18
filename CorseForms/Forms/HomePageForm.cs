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
            else
            {
                MessageBox.Show("Error");

            }

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void buttonCreateCourse_Click(object sender, EventArgs e)
        {
            DateTime startCourse = dateTimePickerStart.Value;
            DateTime EndCourse = dateTimePickerEnd.Value;
            string NameCourse = textBoxPrice.Text;
            int Price = int.Parse(textBoxPrice.Text);
            int StartHour = int.Parse(textBoxStartHour.Text);
            int EndHour = int.Parse(textBoxEndHour.Text);
            int TotalHour = int.Parse(textBoxTotalHours.Text);
            int Cycle = int.Parse(textBoxCycle.Text);
            string query = "insert into Courses output inserted.ID values(@Name, @Cycle, @StsrtDate, @endDate, @totalHours, @Price)";
            SqlParameter[] parameters = {
                        new SqlParameter("@Name", NameCourse),
                        new SqlParameter("@Cycle", Cycle),
                        new SqlParameter("@StsrtDate", startCourse),
                        new SqlParameter("@endDate", EndCourse),
                        new SqlParameter("@totalHours", TotalHour),
                        new SqlParameter("@Price", Price)
            };
            DataTable CourseID = dbContext.MakeQuery(query, parameters);
            string queryForDays = "insert into Days values(@Day, @StartHour, @EndHour, @CoursID)";
            SqlParameter? parameter; 
            foreach (Control control in groupBox1.Controls)
            {
                if (control is RadioButton radioButton)
                {
                    if (radioButton.Checked)
                    {
                        parameter = radioButton.Text switch
                        {
                            "ראשון" => new("@Day", "Sunday"),
                            "שני" => new("@Day", "Monday"),
                            "שלישי" => new("@Day", "Tuesday"),
                            "רביעי" => new("@Day", "Wednesday"),
                            "חמישי" => new("@Day", "Thursday"),
                            "שישי" => new("@Day", "Friday"),
                            _ => null
                        };
                        SqlParameter[] parameters2 = {
                            parameter,
                            new SqlParameter("@StartHour", StartHour),
                            new SqlParameter("@EndHour", EndHour),
                            new SqlParameter("@CoursID", CourseID) };
                        bool isInsert = dbContext.ExecuteNonQuery(queryForDays, parameters2);
                        if (isInsert)
                        {
                            MessageBox.Show("Day is insert");
                        }
                        else
                        {
                            MessageBox.Show("Error in insert Day");
                        }
                    }
                }

            }
            

        }
    }
}

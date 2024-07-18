using CorseForms.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CorseForms.Forms
{
    internal partial class StudentsForm : Form
    {
        DBContext dbContext;
        public StudentsForm(DBContext DB)
        {
            InitializeComponent();
            dbContext = DB;
        }
    }
}

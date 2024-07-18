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
using CorseForms.DAL;

namespace CorseForms.Forms
{
    internal partial class CoursesForm : Form
    {
        DBContext dbContext;
        public CoursesForm(DBContext DB)
        {
            InitializeComponent();
            dbContext = DB;
        }
    }
}

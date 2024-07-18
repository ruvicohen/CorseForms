using CorseForms.DAL;
using CorseForms.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorseForms
{
    internal class Navigation
    {
        public static void CloseAllForms()
        {
            List<Form> openForms = new List<Form>(Application.OpenForms.Cast<Form>());
            foreach (Form item in openForms)
            {
                item.Close();
            }
        }
        public static void ShowForms<T>(string formName, DBContext DB, int ID = -1)
        {
            CloseAllForms();
            Form form = formName switch
            {
                "HomePageForm" => new HomePageForm(DB),
                "StudentsForm" => new StudentsForm(DB),
                "CoursesForm" => new CoursesForm(DB),
                _ => throw new ArgumentException("invalid form name.", nameof(formName)),
            };
            form.Show();
        }
    }
}

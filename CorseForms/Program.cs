using CorseForms.DAL;
using CorseForms.Forms;
using Microsoft.Extensions.Configuration;
using CorseForms.DAL;
namespace CorseForms
{
    internal class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var config = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            string conn = config["Connection"];
            if (string.IsNullOrEmpty(conn))
            {
                throw new ArgumentNullException("Connection string is missing");
            }
            DBContext dbContext = new DBContext(conn);
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new HomePageForm(dbContext));
        }
    }
}
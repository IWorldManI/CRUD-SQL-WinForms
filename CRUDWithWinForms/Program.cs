using System;
using System.Windows.Forms;
using System.Configuration;
using CRUDWithWinForms.Presenters;
using CRUDWithWinForms.Views;

namespace CRUDWithWinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread] //Entry point of any application that uses Windows Forms
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            string sqlConnectionString = ConfigurationManager.ConnectionStrings["SqlConnection"].ConnectionString;
            IMainView view = new MainView();           
            new MainPresenter(view,sqlConnectionString);
            Application.Run((Form)view);
        }
    }
}

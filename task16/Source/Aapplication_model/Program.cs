using System;
using System.Windows.Forms;

namespace Aapplication_model
{
    internal static class Program
    {
        /// <summary>
        ///     Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                new ApplicationModelTable().RunTable();
            }
            catch
            {
                // ignored
            }
        }
    }
}
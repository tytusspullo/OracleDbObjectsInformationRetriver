using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test2019
{
    static class Program
    {
        /// <summary>
        /// Główny punkt wejścia dla aplikacji.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                ConnectionData cnData = new ConnectionData();
                DbColumns model = new DbColumns(cnData);
                FrmMain view = new FrmMain();
                Controller controler = new Controller(view, model, true);

                Application.Run(view);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message , "Warning" , MessageBoxButtons.OK , MessageBoxIcon.Error);
            }
        }
    }
}

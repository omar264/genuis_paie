using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GENIUSPAIE
{
    static class Program
    {
        /// <summary>
        /// Point d'entrée principal de l'application.
        /// </summary>
        public static void ErrorMessage(string msg)
            {
                MessageBox.Show(msg, "GENIUS Paie", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
    [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmParent());
        }
    }
}

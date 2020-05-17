using GENIUSPAIE.Salaries;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GENIUSPAIE
{
    public partial class frmParent : Form
    {
        public frmParent()
        {
            InitializeComponent();
        }

        private void fichesDePersonnelToolStripMenuItem_Click(object sender, EventArgs e)
        {

            frmListeSalarie frm = new frmListeSalarie();
            frm.ShowDialog();
        }

        private void frmParent_Load(object sender, EventArgs e)
        {

        }

        private void listesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsmDepartement_Click(object sender, EventArgs e)
        {
            try
            {
                frmListeDepartement frm = new frmListeDepartement();
                frm.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void tsmService_Click(object sender, EventArgs e)
        {
            try
            {
                frmListeService frm = new frmListeService();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {

                Program.ErrorMessage(ex.Message); ;
            }

        }

        private void tsmUnite_Click(object sender, EventArgs e)
        {
            try
            {
                frmListeUnité frm = new frmListeUnité();
                frm.ShowDialog();
            }
            catch (Exception ex)
            {

                Program.ErrorMessage(ex.Message);
            }
        }
    }
}

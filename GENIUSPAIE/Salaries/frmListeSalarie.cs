using Core.Classe;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GENIUSPAIE.Salaries
{
    public partial class frmListeSalarie : Form
    {
        #region Fields
        DbSage _db = new DbSage();
        #endregion Fields

        public frmListeSalarie()
        {

            InitializeComponent();

        }

        private void frmListeSalarie_Load(object sender, EventArgs e)
        {
            BindListe();
        }

        public void BindListe()
        {
            olvSalarie.DataSource = _db.F_Salarie.ToArray();
        }

        private void btNouveau_Click(object sender, EventArgs e)
        {
            try
            {
                frmFicheSalarie frm = new frmFicheSalarie();
                frm.ShowDialog();
                BindListe();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void olvSalarie_Click(object sender, EventArgs e)
        {
            if (gridView1.SelectedRowsCount != 1) return;
            F_Salarie salaire = ((F_Salarie)(gridView1.GetRow(gridView1.FocusedRowHandle)));
            frmFicheSalarie frm = new frmFicheSalarie(salaire);
            frm.ShowDialog();
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}

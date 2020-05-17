using Core;
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
    public partial class frmListeService : Form
    {
        #region Fields 

        private F_Service _service = null;
        private Mode _mode = Mode.Ajouter;
        #endregion Fields
        #region Constructeurs
        public frmListeService()
        {
            InitializeComponent();
        }
        #endregion Constructeurs
        #region Methods 

        private void frmListeService_Load(object sender, EventArgs e)
        {
            try
            {
                BindListe();

                this.ActiveControl = txtCode;
                txtCode.Focus();
            }
            catch (Exception ex)
            {
                Program.ErrorMessage(ex.Message);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void olvSalarie_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.SelectedRowsCount != 1) return;
                F_Service row = (F_Service)(gridView1.GetRow(gridView1.FocusedRowHandle));
                txtCode.Text = row.SE_Code;
                txtIntitule.Text = row.SE_intitule;
                txtCode.Enabled = false;
                btSupprimer.Enabled = true;
                _mode = Mode.Modifier;

                this.ActiveControl = txtIntitule;
                txtIntitule.Focus();

            }
            catch (Exception ex)
            {

                Program.ErrorMessage(ex.Message);
            }
        }

        private void btEnregistrer_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCode.Text == "")
                {
                    this.ActiveControl = txtCode;
                    throw new ArgumentException("La saisie du code est obligatoire!");
                }
                if (txtIntitule.Text == "")
                {
                    this.ActiveControl = txtIntitule;
                    txtIntitule.Focus();
                    throw new ArgumentException("la saisie du l'intitule est obligatoire");
                }
                using (DbSage db = new DbSage())
                {
                    string code = txtCode.Text;
                    if (_mode == Mode.Ajouter && db.F_Service.Count(item => item.SE_Code == code) > 0)
                    {
                        this.ActiveControl = txtCode;
                        txtCode.Focus();
                        throw new ArgumentException("Ce code existe déja!");
                    }
                }
                    F_Service service = new F_Service()
                    {
                        SE_Code = txtCode.Text,
                        SE_intitule = txtIntitule.Text,
                        SE_No = _mode == Mode.Modifier ? _service.SE_No : 0,
                    };
            
            using (DbSage db = new DbSage())
            {
                if (_mode == Mode.Ajouter)
                {
                    db.F_Service.Add(service);
                }
                else if (_mode == Mode.Modifier)
                {
                    db.F_Service.Add(service);
                    db.Entry(_service).State = System.Data.Entity.EntityState.Modified;

                }
                db.SaveChanges();
            };
                BindListe();
                btNouveau_Click(null, null);
            }

             catch (Exception ex)
            {
                Program.ErrorMessage(ex.Message);
            }

}
        private void BindListe()
        {
            try
            {
                using (DbSage db = new DbSage())
                {
                    olvSalarie.DataSource = db.F_Service.ToList();
                }
            }
            catch (Exception ex)
            {
                Program.ErrorMessage(ex.Message);
            }
        }

        private void btNouveau_Click(object sender, EventArgs e)
        {
            try
            {
                txtCode.Text = "";
                txtIntitule.Text = "";
                txtCode.Enabled = true;
                _mode = Mode.Ajouter;
                btSupprimer.Enabled = false;
                txtCode.Focus();


            }
            catch (Exception ex)
            {

                Program.ErrorMessage(ex.Message);

            }



        
    }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.SelectedRowsCount != 1) return;
                 int idSE = ((F_Service)(gridView1.GetRow(gridView1.FocusedRowHandle))).SE_No;

                using (DbSage db = new DbSage())
                {
                    db.F_Service.Remove(db.F_Service.Find(idSE));

                    db.SaveChanges();
                }

                BindListe();
                btNouveau_Click(null, null);

                this.ActiveControl = txtIntitule;
                txtIntitule.Focus();
            }
            catch (Exception ex)
            {
                Program.ErrorMessage(ex.Message);
            }
        }

        private void frmListeService_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode != Keys.Escape) return;
                Close();
            }
            catch (Exception ex)
            {
                Program.ErrorMessage(ex.Message);
            }
        }
        #endregion Constructeurs

        private void btOK_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

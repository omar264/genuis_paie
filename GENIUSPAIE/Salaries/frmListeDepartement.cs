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
    public partial class frmListeDepartement : Form
    {
        #region Fields 

        private F_Departement _departement = null;
        private Mode _mode = Mode.Ajouter;

        #endregion Fields

        #region Constructeurs
        public frmListeDepartement()
        {
            InitializeComponent();
        }

        #endregion Constructeurs

        #region Methods 
        private void frmListeDepartement_Load(object sender, EventArgs e)
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
        private void btEnregistrer_Click(object sender, EventArgs e)
        {

            try
            {
                if (txtCode.Text == "")
                {
                    this.ActiveControl = txtCode;
                    txtCode.Focus();
                    throw new ArgumentException("La saisie du code est obligatoire!");
                }

                if (txtIntitule.Text == "")
                {
                    this.ActiveControl = txtIntitule;
                    txtIntitule.Focus();
                    throw new ArgumentException("La saisie de l'intitulé est obligatoire!");
                }
                using (DbSage db = new DbSage())
                {
                    string code = txtCode.Text;
                    if (_mode == Mode.Ajouter && db.F_Departement.Count(item => item.DP_Code == code) > 0)
                    {
                        this.ActiveControl = txtCode;
                        txtCode.Focus();
                        throw new ArgumentException("Ce code existe déja!");
                    }
                    F_Departement departement = new F_Departement()
                    {
                        DP_Code = txtCode.Text,
                        DP_intitule = txtIntitule.Text,
                        DP_No = _mode == Mode.Modifier ? _departement.DP_No : 0,
                    };

                    if (_mode == Mode.Ajouter)
                    {
                        db.F_Departement.Add(departement);
                    }
                    else if (_mode == Mode.Modifier)
                    {
                        db.F_Departement.Add(departement);
                        db.Entry(departement).State = System.Data.Entity.EntityState.Modified;

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
                    olvSalarie.DataSource = db.F_Departement.ToList();
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

        private void olvSalarie_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.SelectedRowsCount != 1) return;
                F_Departement row = (F_Departement)(gridView1.GetRow(gridView1.FocusedRowHandle));

                txtCode.Text = row.DP_Code;
                txtIntitule.Text = row.DP_intitule;

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
        private void btSupprimer_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.SelectedRowsCount != 1) return;
                int idDep = ((F_Departement)(gridView1.GetRow(gridView1.FocusedRowHandle))).DP_No;

                using (DbSage db = new DbSage())
                {
                    db.F_Departement.Remove(db.F_Departement.Find(idDep));
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

        private void frmListeDepartement_KeyDown(object sender, KeyEventArgs e)
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

        #endregion Methods 

        private void btOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbImprimer_Click(object sender, EventArgs e)
        {

        }
    }
}

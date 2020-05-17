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
    public partial class frmListeEnfant : Form
    {
        #region Fields 

        private F_Enfant _enfant = null;
        private Mode _mode = Mode.Ajouter;
        private F_Salarie _salarie = null;


        #endregion Fields
        #region Constructeurs
        public frmListeEnfant()
        {
            InitializeComponent();
        }
        public frmListeEnfant(F_Salarie salarie)
            :this()
        {
            _salarie = salarie;
        }

        #endregion Constructeurs
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
          
        }

        private void btnNouveau_Click(object sender, EventArgs e)
        {
            try
            {
                txtNom.Text = "";
                txtPrenom.Text = "";
                txtNom.Enabled = true;
                _mode = Mode.Ajouter;
                btSupprimer.Enabled = false;
                txtNom.Focus();


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
                    olvSalarie.DataSource = db.F_Enfant.ToList();
                }
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
                int idEn = ((F_Enfant)(gridView1.GetRow(gridView1.FocusedRowHandle))).EN_NO;

                using (DbSage db = new DbSage())
                {
                    db.F_Enfant.Remove(db.F_Enfant.Find(idEn));
                    db.SaveChanges();
                }

                BindListe();
                btnNouveau_Click(null, null);

                this.ActiveControl = txtNom;
                txtNom.Focus();
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
                if (txtNom.Text == "")
                {
                    this.ActiveControl = txtNom;
                    throw new ArgumentException("La saisie du nom est obligatoire!");
                }
                if (txtPrenom.Text == "")
                {
                    this.ActiveControl = txtPrenom;
                    txtNom.Focus();
                    throw new ArgumentException("la saisie du prénom est obligatoire");
                }
                using (DbSage db = new DbSage())
                {
                    string nom = txtNom.Text;
                    if (_mode == Mode.Ajouter && db.F_Enfant.Count(item => item.EN_Nom == nom) > 0)
                    {
                        this.ActiveControl = txtNom;
                        txtNom.Focus();
                        throw new ArgumentException("Ce nom existe déja!");
                    }
                    F_Enfant enfant = new F_Enfant()
                    {   EN_DateNaissance = dateTimePicker1.Value ,
                        EN_Nom = txtNom.Text,
                        EN_Prenom = txtPrenom.Text,
                        EN_NO = _mode == Mode.Modifier ? _enfant.EN_NO : 0,
                    };
                    if (_mode == Mode.Ajouter)
                    {
                        db.F_Enfant.Add(enfant);
                    }
                    else if (_mode == Mode.Modifier)
                    {
                        db.F_Enfant.Add(enfant);
                        db.Entry(enfant).State = System.Data.Entity.EntityState.Modified;

                    }
                    db.SaveChanges();
                };
                BindListe();
                btnNouveau_Click(null, null);
            }

            catch (Exception ex)
            {
                Program.ErrorMessage(ex.Message);
            }
        }

        private void frmListeEnfant_Load(object sender, EventArgs e)
        {
            try
            {
                BindListe();

                this.ActiveControl = txtNom;
                txtNom.Focus();
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
                F_Enfant row = (F_Enfant)(gridView1.GetRow(gridView1.FocusedRowHandle));

                txtNom.Text = row.EN_Nom;
                txtPrenom.Text = row.EN_Prenom;

                txtNom.Enabled = false;
                btSupprimer.Enabled = true;
                _mode = Mode.Modifier;

                this.ActiveControl = txtPrenom;
                txtPrenom.Focus();
            }
            catch (Exception ex)
            {
                Program.ErrorMessage(ex.Message);
            }
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            Close();

        }
    }
}

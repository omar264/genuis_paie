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
    public partial class frmListeUnité : Form
    {
        #region Fields 

        private F_Unite _unite = null;
        private Mode _mode = Mode.Ajouter;


        #endregion Fields
        #region Constructeurs

        public frmListeUnité()
        {
            InitializeComponent();
        }
        #endregion Constructeurs
        #region Methods 

        private void olvSalarie_Click(object sender, EventArgs e)
        {
            try
            {
                if (gridView1.SelectedRowsCount != 1) return;
                F_Unite row = (F_Unite)(gridView1.GetRow(gridView1.FocusedRowHandle));
                txtCode.Text = row.UN_Code;
                txtIntitule.Text = row.UN_intitule;
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

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
                    if (_mode == Mode.Ajouter && db.F_Unite.Count(item => item.UN_Code == code) > 0)
                    {
                        this.ActiveControl = txtCode;
                        txtCode.Focus();
                        throw new ArgumentException("Ce code existe déja!");
                    }
                    F_Unite unite = new F_Unite()
                    {
                        UN_Code = txtCode.Text,
                        UN_intitule = txtIntitule.Text,
                        UN_No = _mode == Mode.Modifier ? _unite.UN_No : 0,
                    };
                    if (_mode == Mode.Ajouter)
                    {
                        db.F_Unite.Add(unite);
                    }
                    else if (_mode == Mode.Modifier)
                    {
                        db.F_Unite.Add(unite);
                        db.Entry(unite).State = System.Data.Entity.EntityState.Modified;

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
                    olvSalarie.DataSource = db.F_Unite.ToList();
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
        #endregion Constructeurs

        private void frmListeUnité_Load(object sender, EventArgs e)
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

        private void btSupprimer_Click(object sender, EventArgs e)
        {
            try
            { 
                if (gridView1.SelectedRowsCount != 1) return;
                int idUn  = ((F_Unite)(gridView1.GetRow(gridView1.FocusedRowHandle))).UN_No;

                using (DbSage db = new DbSage())
                {
                    db.F_Unite.Remove(db.F_Unite.Find(idUn));
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

        private void frmListeUnité_KeyDown(object sender, KeyEventArgs e)
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

        private void btOK_Click(object sender, EventArgs e)
        {
            Close();
        }
        

    }
}
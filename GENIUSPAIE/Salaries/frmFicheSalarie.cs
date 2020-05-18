using Core;
using Core.Classe;
using DevExpress.XtraEditors.Filtering;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace GENIUSPAIE.Salaries
{
    public partial class frmFicheSalarie : Form
    {
        #region Fields 
        DbSage db = new DbSage();
        private F_Salarie _salarie = null;
        private Mode _mode = Mode.Ajouter;
        private Control _currentPanel = new Panel();

        #endregion Fields
        #region Constructeurs

        public frmFicheSalarie(F_Salarie salarie = null)
        {
            InitializeComponent();
            if (salarie != null)
            {
                _salarie = salarie;
                _mode = Mode.Modifier;

            }
        }

        #endregion Constructeurs

        private void SetItem()
        {
            try
            {
                txtMatricule.Text = _salarie.SA_Matricule;
                cbCivilité.SelectedValue = _salarie.SA_Civilté;
                txtNom.Text = _salarie.SA_Nom;
                txtPrénom.Text = _salarie.SA_Prénom;
                txtCin.Text = _salarie.SA_CIN;
                cbSituationF.SelectedValue = _salarie.SA_SituationFamilliale;
                txtNumSecS.Text = _salarie.SA_NumSécuritéSocial;
                txtCléSs.Text = _salarie.SA_Clé;
                txtAdresse.Text = _salarie.SA_Adresse;
                txtComplement.Text = _salarie.SA_ComplementAdresse;
                txtCodePostale.Text = _salarie.SA_CodePostal;
                txtTelephone.Text = _salarie.SA_Telephone;
                txtPortable.Text = _salarie.SA_Portable;
                txtBanque.Text = _salarie.SA_Banque;
                txtGuichet.Text = _salarie.SA_Guichet;
                txtCompte.Text = _salarie.SA_Compte;
                txtClé.Text = _salarie.SA_CléCompte;
                txtLibCompte.Text = _salarie.SA_LibelléCompte;
                cbDépartement.SelectedValue = _salarie.DP_Code ?? "";
                cbService.SelectedValue = _salarie.SE_Code ?? "";
                cbUnité.SelectedValue = _salarie.UN_Code ?? "";
                salaireBase.Text = _salarie.SalaireDeBase.ToString();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void btAnnuler_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int departement = 0;

                F_Salarie salarie = new F_Salarie()
                {
                    SA_Matricule = txtMatricule.Text,
                    SA_Nom = txtNom.Text,
                    SA_Civilté = Convert.ToInt16(cbCivilité.SelectedValue),
                    SA_Prénom = txtPrénom.Text,
                    SA_SituationFamilliale = Convert.ToInt16(cbSituationF.SelectedValue),
                    SA_NombreEnfants = Convert.ToInt32(TxtNumEnfant.Value),
                    SA_DateNaissance = Convert.ToDateTime(dtpDateNaiss.EditValue),
                    SA_NumSécuritéSocial = txtNumSecS.Text,
                    SA_Clé = txtCléSs.Text,
                    SA_CIN = txtCin.Text,
                    SA_DateLivraisonCin = Convert.ToDateTime(dtpDateLv.EditValue),
                    SA_Adresse = txtAdresse.Text,
                    SA_ComplementAdresse = txtComplement.Text,
                    SA_CodePostal = txtCodePostale.Text ,
                    SA_Telephone = txtTelephone.Text,
                    SA_Banque = txtBanque.Text,
                    SA_Guichet = txtGuichet.Text,
                    SA_LibelléCompte = txtLibCompte.Text,
                    SA_Compte = txtCompte.Text,
                    SA_CléCompte = txtClé.Text,
                    SA_Portable = txtPortable.Text,
                    DP_Code = cbDépartement.SelectedIndex == -1 ? "" : Convert.ToString(cbDépartement.SelectedValue),
                    SE_Code = cbService.SelectedIndex == -1 ? "" : Convert.ToString(cbService.SelectedValue),
                    UN_Code = cbUnité.SelectedIndex == -1 ? "" : Convert.ToString(cbUnité.SelectedValue),
                    cbMarq = _mode == Mode.Modifier ? _salarie.cbMarq : 0,


                };
                using (DbSage db = new DbSage())
                {
                    if (_mode == Mode.Ajouter)
                    {
                        db.F_Salarie.Add(salarie);
                    }
                    else if (_mode == Mode.Modifier)
                    {
                       //db.F_Salarie.Add(salarie);
                        db.Entry(_salarie).State = System.Data.Entity.EntityState.Modified;
                    }

                    db.SaveChanges();
                    Close();
                };
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        private void SwitchPanel(Control nextPanel)
        {
            try
            {
                _currentPanel.Hide();
                _currentPanel.Dock = DockStyle.None;
                _currentPanel = nextPanel;
                _currentPanel.Dock = DockStyle.Fill;
                _currentPanel.Visible = true;
            }
            catch (Exception ex)
            {
                Program.ErrorMessage(ex.Message);
            }
        }

        private void frmFicheSalarie_Load(object sender, EventArgs e)
        {
            try
            {
                SwitchPanel(plEtatCivile);
                RemplirListe();
                if (_mode == Mode.Modifier)
                {
                    SetItem();
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void trvSalarie_Click(object sender, EventArgs e)
        {
            try
            {
                TreeList node = (TreeList)sender;
                if (Convert.ToInt32(node.FocusedNode.Tag) == 0)
                    SwitchPanel(plEtatCivile);
                else if (Convert.ToInt32(node.FocusedNode.Tag) == 1)
                    SwitchPanel(plCoordonnee);
                else if (Convert.ToInt32(node.FocusedNode.Tag) == 2)
                    SwitchPanel(plContrat);
                else if (Convert.ToInt32(node.FocusedNode.Tag) == 3)
                    SwitchPanel(plPoste);
                else if (Convert.ToInt32(node.FocusedNode.Tag) == 4)
                    SwitchPanel(plPaie);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void trvSalarie_AfterCheckNode(object sender, DevExpress.XtraTreeList.NodeEventArgs e)
        {
            try
            {
                TreeListNode node = (TreeListNode)sender;
                if (Convert.ToInt32(node.Tag) == 0)
                    SwitchPanel(plEtatCivile);
                else if (Convert.ToInt32(node.Tag) == 1)
                    SwitchPanel(plCoordonnee);
                else if (Convert.ToInt32(node.Tag) == 2)
                    SwitchPanel(plContrat);
                else if (Convert.ToInt32(node.Tag) == 3)
                    SwitchPanel(plPoste);
                else if (Convert.ToInt32(node.Tag) == 4)
                    SwitchPanel(plPaie);

            }
            catch (Exception)
            {

                throw;
            }
        }

        private void label34_Click(object sender, EventArgs e)
        {

        }
        public void RemplirListe()
        {

            List<CbItem> listeItem01 = new List<CbItem>();
            List<CbItem> listeItem02 = new List<CbItem>();
            List<CbItem> listeItem03 = new List<CbItem>();

            List<F_Departement> listeDP = db.F_Departement.ToList();
            List<F_Service> listSE = db.F_Service.ToList();
            List<F_Unite> listeUN = db.F_Unite.ToList(); ;


            for (int i = 0; i < listeDP.Count; i++)
                listeItem01.Add(new CbItem(listeDP[i].DP_intitule,
listeDP[i].DP_Code));

            cbDépartement.DisplayMember = "Display";
            cbDépartement.ValueMember = "ValueST";
            cbDépartement.DataSource = listeItem01;
            cbDépartement.SelectedIndex = -1;

            for (int i = 0; i < listSE.Count; i++)
                listeItem02.Add(new CbItem(listSE[i].SE_intitule,
listSE[i].SE_Code));

            cbService.DisplayMember = "Display";
            cbService.ValueMember = "ValueST";
            cbService.DataSource = listeItem02;
            cbService.SelectedIndex = -1;

            for (int i = 0; i < listeUN.Count; i++)
                listeItem03.Add(new CbItem(listeUN[i].UN_intitule,
listeUN[i].UN_Code));

            cbUnité.DisplayMember = "Display";
            cbUnité.ValueMember = "ValueST";
            cbUnité.DataSource = listeItem03;
            cbUnité.SelectedIndex = -1;
        }

        private void plPoste_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                frmListeEnfant frm = new frmListeEnfant(_salarie);
                frm.ShowDialog();
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void trvSalarie_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {

        }

        private void plPaie_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbxUnite_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void plEtatCivile_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog() { Filter = "PDF file|*.pdf", ValidateNames = true })
            {
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
                    try
                    {
                        PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                        doc.Open();
                        doc.Add(new iTextSharp.text.Paragraph(txtMatricule.Text + " " + txtNom.Text + " " + txtPrénom.Text));
                        doc.Add(new iTextSharp.text.Paragraph("Salaire mensuel : " + calculerSalaireMensuel(salaireHoraireValue.Text)));
                        doc.Add(new iTextSharp.text.Paragraph("MAticule : " + txtMatricule.Text));
                        doc.Add(new iTextSharp.text.Paragraph("cnss : " + txtNumSecS.Text));
                        doc.Add(new iTextSharp.text.Paragraph("cnss : " + salaireBase.Text));


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Trace.TraceError(ex.Message);
                    }
                    finally
                    {
                        doc.Close();
                    }
                }
            }
        }

        private String calculerSalaireMensuel(String salaireHoraire)
        {
            try
            {
                decimal salaireHoraireDecimal = decimal.Parse(salaireHoraire);
                decimal salaireMensuleDecimal = salaireHoraireDecimal * 8 * 20;
                Trace.TraceInformation(salaireMensuleDecimal.ToString("0.00"));
                return salaireMensuleDecimal.ToString("0.00");
            }
            catch(Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
            throw new Exception("Impossible de calculer le salaire mensuel");
            //return "";
        }
    }
}

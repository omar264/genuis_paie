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
        private F_BullteinPaie _BullteinPaie = null;
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
                txtsalaireBase.Text = _salarie.SalaireDeBase.ToString();
                txtPrimes.Text = _salarie.primes.ToString();
                txtCnss.Text = _salarie.retenueCnss.ToString();
                txtIrpp.Text = _salarie.retenueIrpp.ToString();
                txtCss.Text = _salarie.Css.ToString();
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
                    SA_CodePostal = txtCodePostale.Text,
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
                    SalaireDeBase = Convert.ToDecimal(txtsalaireBase.Text),
                    primes = Convert.ToDecimal(txtPrimes.Text),
                    /*SA_DateSortie =Convert.ToDateTime(dateSortie.EditValue),*/
                    retenueCnss = Convert.ToDecimal(txtPrimes.Text),
                    retenueIrpp = Convert.ToDecimal(txtIrpp.Text),
                    Css = Convert.ToDecimal(txtCss.Text),



                    
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
                    SwitchPanel(v);

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
                    SwitchPanel(v);

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
                        doc.Add(new iTextSharp.text.Paragraph( "                           Bulltein de paie" ));
                        doc.Add(new iTextSharp.text.Paragraph("Date d'impression"+dateSortie.EditValue));

                        doc.Add(new iTextSharp.text.Paragraph("Période de paie"+dateDeb.EditValue+dateFin.EditValue));

                        doc.Add(new iTextSharp.text.Paragraph("STE:"+txtSoc.Text));
                        doc.Add(new iTextSharp.text.Paragraph("CNSS:"+txtCnssSoc.Text));
                        doc.Add(new iTextSharp.text.Paragraph("Matricule"+txtMatricule.Text ));
                          doc.Add(new iTextSharp.text.Paragraph( txtNom.Text + " " + txtPrénom.Text));
                        doc.Add(new iTextSharp.text.Paragraph("cnss : " + txtNumSecS.Text ));
                        doc.Add(new iTextSharp.text.Paragraph("Situation familiale : "+cbSituationF.Text));
                        doc.Add(new iTextSharp.text.Paragraph("salaire de base : " + txtsalaireBase.Text));
                        doc.Add(new iTextSharp.text.Paragraph("Primes : " + txtPrimes.Text));
                       doc.Add(new iTextSharp.text.Paragraph("total brute : " + txtTotalBrute.Text));
                        doc.Add(new iTextSharp.text.Paragraph("retnue cnss : " +txtCnss.Text));
                        doc.Add(new iTextSharp.text.Paragraph("total imposable: " + txtTotalImposable.Text));
                        doc.Add(new iTextSharp.text.Paragraph("retnue irrp : " + txtIrpp.Text));
                        doc.Add(new iTextSharp.text.Paragraph("css : " + txtCss.Text));

                        doc.Add(new iTextSharp.text.Paragraph("net à payer :" + txtNetPayer.Text));
                        //doc.Add(new iTextSharp.text.Paragraph("net à payer : " + calculerSalaireMensuel(salaireHoraireValue.Text)));
                        PdfPTable table = new PdfPTable(6);
                        PdfPCell cell = new PdfPCell(new Phrase("bulltein de paie"));
                         cell.Colspan = 10;

                         cell.HorizontalAlignment = 3;

                         table.AddCell(cell);

                         table.AddCell("salaire de base : " + txtsalaireBase.Text);

                         table.AddCell("Primes : " + txtPrimes.Text);

                         table.AddCell("total brute : " + txtTotalBrute.Text);

                         table.AddCell("retnue cnss : " + txtCnss.Text);

                         table.AddCell("total imposable: " + txtTotalImposable.Text);

                         table.AddCell("retenue irrp : " + txtIrpp.Text);
                         table.AddCell(new PdfPCell(new Phrase("css : " + txtCss.Text)));
                        
                            table.AddCell(new PdfPCell(new Phrase("Cell 2")));
                         table.AddCell(new PdfPCell(new Phrase("Cell 3")));
                         table.AddCell(new PdfPCell(new Phrase("Cell 4")));

                        
                        table.AddCell(new PdfPCell(new Phrase("RepGroup Logo")) { Rowspan = 9 });
                        table.AddCell(new PdfPCell(new Phrase("CID")));
                        table.AddCell(new PdfPCell(new Phrase("CID-Val")));
                        table.AddCell(new PdfPCell(new Phrase("Ven Logo")) { Rowspan = 9, Colspan = 2 });
                        table.AddCell(new PdfPCell(new Phrase("CPO")));
                        table.AddCell(new PdfPCell(new Phrase("CPO-Val")));
                        table.AddCell(new PdfPCell(new Phrase("Order Status")));
                        table.AddCell(new PdfPCell(new Phrase("Confirmed")));
                        table.AddCell(new PdfPCell(new Phrase("Order Date")));
                        table.AddCell(new PdfPCell(new Phrase("10/02/2013")));
                        table.AddCell(new PdfPCell(new Phrase("Ship Date")));
                        table.AddCell(new PdfPCell(new Phrase("12/01/2013")));
                        table.AddCell(new PdfPCell(new Phrase("Back Orders")));
                        table.AddCell(new PdfPCell(new Phrase("Accepted")));
                        table.AddCell(new PdfPCell(new Phrase("Ship Via")));
                        table.AddCell(new PdfPCell(new Phrase("Best Way")));
                        table.AddCell(new PdfPCell(new Phrase("Terms")));
                        table.AddCell(new PdfPCell(new Phrase("CC")));
                        table.CompleteRow();


                        doc.Add(table);

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
        private void calculer()
        {
            try
            {
                double a, b, c, d, e, f, h, i, E36, E37='0',k, l,taux,E38='0',impot,j;
                a = double.Parse(txtsalaireBase.Text);
                b = double.Parse(txtPrimes.Text);
                k = double.Parse(txtNombreJ.Text);
                c = ((a + b) * k) / 26;
                txtTotalBrute.Text = c.ToString("0.000");
                // d= double.Parse(txtCnss.Text);
                txtCnss.Text = (c * 0.0918).ToString("0.000");
                e = double.Parse(txtTotalBrute.Text);
                d = double.Parse(txtCnss.Text);
                f = e - d;
                txtTotalImposable.Text = f.ToString("0.000");
                h = double.Parse(txtTotalImposable.Text);
                taux = h * 12*0.1;

                   
                if (taux > 2000)
                {
                    E36 = h * 12 - 2000;

                }
                else
                {

                    E36 = h * 12 - taux;
                }
                if (cbSituationF.SelectedItem.ToString() == "C")
                {
                    E37 = E36;
                }
                if (cbSituationF.SelectedItem.ToString() == "M")
                {
                    E37 = E36-150;
                  
                }
                if (cbSituationF.SelectedItem.ToString() == "M+1")
                {
                    E37 = E36 - 240;
                    
                }
                if (cbSituationF.SelectedItem.ToString() == "M+2")
                {
                    E37 = E36 - 315;
                    
                }
                if (cbSituationF.SelectedItem.ToString() == "M+3")
                {
                    E37 = E36 - 375;
                    ;
                }
                if (cbSituationF.SelectedItem.ToString() == "M+4")
                {
                    E37 = E36 - 420;
                    
                }
                E38 = E37;
                if (E37<5000)
                {
                    txtIrpp.Text = "0";
                }
                if (5000<E37 && E37<20000)
                {
                    txtIrpp.Text = (((E37 - 5000) * 0.26) / 12).ToString();
                }
                if (20000 < E37 && E37 < 30000)
                {
                    txtIrpp.Text = ((((E37 - 20000) * 0.28)+3900) / 12).ToString();
                }
                if (30000 < E37 && E37 < 50000)
                {
                    txtIrpp.Text = ((((E37 - 30000) * 0.32) + 6700) / 12).ToString();
                }
                if (E37 > 50000)
                {
                    txtIrpp.Text = ((((E37 - 30000) * 0.32) + 6700) / 12).ToString();
                }

 
                txtCss.Text = ((E38 * 0.01) / 12).ToString();
                i = double.Parse(txtIrpp.Text);
                j = double.Parse(txtCss.Text);
                impot =i + j;
                txtNetPayer.Text = (h - impot).ToString();
                    //txtIrpp.Text = i.ToString("0.00");

                // j = h - i;
                // txtNetPayer.Text = j.ToString();


                /*decimal c = Convert.ToDecimal(txtTotalBrute.Text);
                decimal c2 = Convert.ToDecimal(txtCnss.Text);
                decimal c3 = Convert.ToDecimal(txtIrpp.Text);

                // txtTotalBrute.Text = txtsalaireBase.Text + txtCnss.Text;

                decimal TotalImposable = decimal.Parse(txtTotalImposable.Text);
                TotalImposable = c + c2;
                // txtNetPayer.Text = txtTotalImposable.Text-c3;*/

            }
            catch (Exception ex)
            {
                Trace.TraceError(ex.Message);
            }
        }
        private String calculerSalaireMensuel(String salaireHoraire)
        {
            try
            {

                txtTotalBrute.Text = txtsalaireBase.Text + txtPrimes.Text;

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

        private void txtPrimes_TextChanged(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void txtsalaireBase_TextChanged(object sender, EventArgs e)
        {

        }

        private void btncalculer_Click(object sender, EventArgs e)
        {
            calculer();
        }
    }
}

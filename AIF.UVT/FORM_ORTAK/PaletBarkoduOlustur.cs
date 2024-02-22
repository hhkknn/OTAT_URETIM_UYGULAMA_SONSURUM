using AIF.UVT.DatabaseLayer;
using AIF.UVT.Models;
using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT.FORM_ORTAK
{
    public partial class PaletBarkoduOlustur : Form
    {
        //font start
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //font end.
        public PaletBarkoduOlustur(string _partiNo, string _uretimFisNo, string _istasyon, string _kullaniciid, int _row, string _tarih1, int _width, int _height, string _type)
        {
            partiNo = _partiNo;
            uretimFisNo = _uretimFisNo;
            istasyon = _istasyon;
            kullaniciid = _kullaniciid;
            row = _row;
            tarih1 = _tarih1;
            type = _type;

            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = _width;
            initialHeight = _height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = txtMiktar.Font.Size;
            txtMiktar.Resize += Form_Resize;

            initialFontSize = txtPartiNo.Font.Size;
            txtPartiNo.Resize += Form_Resize;

            initialFontSize = btnPaletOlustur.Font.Size;
            btnPaletOlustur.Resize += Form_Resize;

            initialFontSize = btnOzetEkranaDon.Font.Size;
            btnOzetEkranaDon.Resize += Form_Resize;

            initialFontSize = btnBarkodYazdir.Font.Size;
            btnBarkodYazdir.Resize += Form_Resize;
            //font end
            txtMiktar.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Regular);
            cmbPrinter.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Regular);
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            // Yeniden boyutlandırma oranını alır
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            btnBarkodYazdir.Font = new Font(btnBarkodYazdir.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnBarkodYazdir.Font.Style);

            txtMiktar.Font = new Font(txtMiktar.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtMiktar.Font.Style);

            txtPartiNo.Font = new Font(txtPartiNo.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPartiNo.Font.Style);

            btnPaletOlustur.Font = new Font(btnPaletOlustur.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnPaletOlustur.Font.Style);

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnOzetEkranaDon.Font.Style);

            btnBarkodYazdir.Font = new Font(btnBarkodYazdir.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnBarkodYazdir.Font.Style);

            dtgPaletBarkoduOlustur.Font = new Font(dtgPaletBarkoduOlustur.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                FontStyle.Bold);

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                FontStyle.Bold);

            cmbPrinter.Font = new Font(cmbPrinter.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                FontStyle.Bold);

            ResumeLayout();
            //font end
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;

                cp.ClassStyle |= 0x20000;

                cp.ExStyle |= 0x02000000;

                return cp;
            }
        }

        private string partiNo = "";
        private string uretimFisNo = "";
        private string istasyon = "";
        private string kullaniciid = "";
        private string tarih1 = "";
        private string istasyonadi = "";
        private int row = 0;
        private string type = "";
        private SqlCommand cmd = null;
        DataTable dtDetay = new DataTable();
        private void PaletBarkoduOlustur_Load(object sender, EventArgs e)
        {
            listAllPrinters();
            txtUretimFisNo.Text = uretimFisNo;
            #region MKOD İle Background Değişimi 
            var lastOpenedForm = Application.OpenForms.Cast<Form>().Last();

            if (Giris.mKodValue == "010OTATURVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.OTAT_UVT_ArkaPlanV3;
            }
            else if (Giris.mKodValue == "20URVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.YORUK_UVT_ArkaPlanv2;
            }
            #endregion MKOD İle Background Değişimi

            txtPartiNo.Text = partiNo;

            #region dataGridView1 



            UVTService.UVTServiceSoapClient uVTServiceSoapClient = new UVTService.UVTServiceSoapClient();
            UVTService.Response resp = uVTServiceSoapClient.getUretimPaletDetay(Giris.dbName, txtUretimFisNo.Text, Giris.mKodValue);
            if (resp.Value != 0)
            {
                CustomMsgBox.Show(resp.Description, "Uyarı", "TAMAM", "");
                return;
            }

            dtDetay = resp.List;
            //dtDetay.Columns.Add("PaletNo", typeof(string));
            //dtDetay.Columns.Add("Miktar", typeof(double));

            dtgPaletBarkoduOlustur.DataSource = dtDetay;

            if (dtgPaletBarkoduOlustur.Rows.Count > 0)
            {
                dtgPaletBarkoduOlustur.Rows[0].Selected = false;
            }

            dtgPaletBarkoduOlustur.AllowUserToAddRows = false;
            dtgPaletBarkoduOlustur.AllowUserToDeleteRows = false;
            dtgPaletBarkoduOlustur.AllowUserToResizeColumns = false;
            dtgPaletBarkoduOlustur.AllowUserToResizeRows = false;
            dtgPaletBarkoduOlustur.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgPaletBarkoduOlustur.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dtgPaletBarkoduOlustur.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 191, 143);
            dtgPaletBarkoduOlustur.DefaultCellStyle.BackColor = Color.FromArgb(220, 230, 241);

            dtgPaletBarkoduOlustur.EnableHeadersVisualStyles = false;
            dtgPaletBarkoduOlustur.RowHeadersVisible = false;

            dtgPaletBarkoduOlustur.ColumnHeadersHeight = 50;
            dtgPaletBarkoduOlustur.RowTemplate.Height = 40;

            foreach (DataGridViewColumn column in dtgPaletBarkoduOlustur.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
            #endregion
        }

        private void txtMiktar_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew n = new SayiKlavyesiNew(txtMiktar, null);
            n.ShowDialog();
        }

        private void dtgPaletBarkoduOlustur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var paletno = dtgPaletBarkoduOlustur.Rows[e.RowIndex].Cells["PaletNo"].Value.ToString();
                txtPaletNo.Text = paletno;
            }
            catch (Exception)
            {
            }
        }

        private void dtgPaletBarkoduOlustur_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar2.Value = e.NewValue;

        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgPaletBarkoduOlustur.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception ex)
            {
            }
        }

        private void btnBarkodYazdir_Click(object sender, EventArgs e)
        {
            if (txtPaletNo.Text == "")
            {
                CustomMsgBtn.Show("LÜTFEN PALET SEÇİNİZ.", "Uyarı", "TAMAM");
                return;
            }
            #region Crystal reports işlemlerinin yapıldığı yer

            try
            {
                string path = "";

                if (Giris.dbName == "OTAT_EskiDb_2")
                {
                    path = System.AppDomain.CurrentDomain.BaseDirectory + "SVK_A4_1_OTAT_OTAT_EskiDb_2.rpt";
                }

                //path = System.AppDomain.CurrentDomain.BaseDirectory + "SVK_A4_1.rpt";

                ReportDocument cryRpt = new ReportDocument();

                cryRpt.Load(path);

                string server = "";
                server = "172.55.10.16";

                cryRpt.SetDatabaseLogon("sa", "Qaz1Wsx2", server, Giris.dbName);
                cryRpt.VerifyDatabase();

                cryRpt.SetParameterValue(0, txtPaletNo.Text);
                //cryRpt.SetParameterValue(1, "");

                cryRpt.PrintOptions.PrinterName = cmbPrinter.Text;

                //cryRpt.PrintToPrinter(txtPrintMik.Text == "" ? 1 : Convert.ToInt32(txtPrintMik.Text), false, 0, 1);
                cryRpt.PrintToPrinter(1, false, 0, 0);

                cryRpt.Close();
                 
                CustomMsgBtn.Show("YAZDIRMA İŞLEMİ BAŞARILI.", "Uyarı", "TAMAM");

            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
            finally
            {
                txtPaletNo.Text = "";
            }

            #endregion Crystal reports işlemlerinin yapıldığı yer
        }

        private void listAllPrinters()
        {
            cmbPrinter.Items.Clear();
            cmbPrinter.Items.Add("");

            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                cmbPrinter.Items.Add(item);
            }
            //default
            PrintDocument printDocument = new PrintDocument();
            string defaultPrinter = printDocument.PrinterSettings.PrinterName;
            cmbPrinter.SelectedItem = defaultPrinter;
        }
        private void btnPaletOlustur_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtMiktar.Text == "")
                {
                    CustomMsgBtn.Show("LÜTFEN MİKTAR GİRİNİZ.", "Uyarı", "TAMAM"); 
                    return;
                }


                UVTService.UVTServiceSoapClient uVTServiceSoapClient = new UVTService.UVTServiceSoapClient();
                UVTService.Response resp = uVTServiceSoapClient.GetPaletNumarasiGetir(Giris.dbName, Giris.mKodValue);

                if (resp.Value == 0)
                {
                    int siradakiNo = Convert.ToInt32(resp.List.Rows[0]["U_SiradakiNo"]);
                    int docEntry = Convert.ToInt32(resp.List.Rows[0]["DocEntry"]);
                    string paletno = resp.List.Rows[0]["U_SiradakiNo"].ToString();
                    txtPaletNo.Text = paletno;

                    resp = uVTServiceSoapClient.UpdatePaletNumarasi(Giris.dbName, docEntry, siradakiNo, Giris.mKodValue);

                    if (resp.Value != 0)
                    {
                        CustomMsgBox.Show(resp.Description, "Uyarı", "TAMAM", "");
                        return;
                    }

                    string sql = "";
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter sda = new SqlDataAdapter();
                    DataTable dt = new DataTable();

                    sql = "Select T0.\"WareHouse\" as \"DepoKodu\",T1.\"WhsName\" as \"DepoAdi\", T2.\"CodeBars\" as \"Barkod\",T2.\"ItemCode\" as \"KalemKodu\",T2.\"ItemName\" as \"KalemAdi\",T2.\"ManBtchNum\" as \"Partili\" FROM OWOR as T0 LEFT JOIN OWHS AS T1 ON T0.\"WareHouse\" = T1.\"WhsCode\" LEFT JOIN OITM AS T2 ON T0.\"ItemCode\" = T2.\"ItemCode\" where T0.\"DocEntry\" = '" + txtUretimFisNo.Text + "'";
                    cmd = new SqlCommand(sql, Connection.sql);
                    sda = new SqlDataAdapter();
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt);


                    UVTService.PaletYapma paletYapma = new UVTService.PaletYapma();
                    UVTService.PaletYapmaDetay paletYapmaDetay = new UVTService.PaletYapmaDetay();
                    List<UVTService.PaletYapmaDetay> paletYapmaDetays = new List<UVTService.PaletYapmaDetay>();
                    UVTService.PaletYapmaPartiler paletYapmaPartiler = new UVTService.PaletYapmaPartiler();
                    List<UVTService.PaletYapmaPartiler> paletYapmaPartilers = new List<UVTService.PaletYapmaPartiler>();
                    paletYapma.PaletNumarasi = paletno;
                    paletYapma.Durum = "A";
                    paletYapma.MevcutDepoKodu = dt.Rows[0]["DepoKodu"].ToString();
                    paletYapma.MevcutDepoAdi = dt.Rows[0]["DepoAdi"].ToString();
                    paletYapma.UretimFisNo = txtUretimFisNo.Text;

                    paletYapmaDetay.Barkod = dt.Rows[0]["Barkod"].ToString();
                    paletYapmaDetay.KalemKodu = dt.Rows[0]["KalemKodu"].ToString();
                    paletYapmaDetay.KalemTanimi = dt.Rows[0]["KalemAdi"].ToString();
                    paletYapmaDetay.Quantity = Convert.ToDouble(txtMiktar.Text);
                    paletYapmaDetay.DepoKodu = dt.Rows[0]["DepoKodu"].ToString();
                    paletYapmaDetay.DepoAdi = dt.Rows[0]["DepoAdi"].ToString();

                    string guid = Guid.NewGuid().ToString().ToUpper();
                    paletYapmaDetay.guid = guid;
                    paletYapmaDetay.partili = dt.Rows[0]["Partili"].ToString();

                    paletYapmaPartiler.Barkod = dt.Rows[0]["Barkod"].ToString();
                    paletYapmaPartiler.DepoKodu = dt.Rows[0]["DepoKodu"].ToString();
                    paletYapmaPartiler.DepoAdi = dt.Rows[0]["DepoAdi"].ToString();
                    paletYapmaPartiler.KalemKodu = dt.Rows[0]["KalemKodu"].ToString();
                    paletYapmaPartiler.KalemTanimi = dt.Rows[0]["KalemAdi"].ToString();
                    paletYapmaPartiler.Miktar = Convert.ToDouble(txtMiktar.Text);
                    paletYapmaPartiler.PartiNumarasi = txtPartiNo.Text;
                    paletYapmaPartiler.guid = guid;

                    paletYapmaPartilers.Add(paletYapmaPartiler);

                    paletYapmaDetay.PaletYapmaPartilers = paletYapmaPartilers.ToArray();

                    paletYapmaDetays.Add(paletYapmaDetay);

                    paletYapma.paletYapmaDetays = paletYapmaDetays.ToArray();

                    resp = uVTServiceSoapClient.AddOrUpdatePaletYapma(Giris.dbName, paletYapma, Giris.mKodValue);

                    if (resp.Value != 0)
                    {
                        CustomMsgBox.Show(resp.Description, "Uyarı", "TAMAM", "");
                        return;
                    }
                    else
                    {
                        DataRow dr = dtDetay.NewRow();
                        dr["PaletNo"] = txtPaletNo.Text;
                        dr["Miktar"] = Convert.ToDouble(txtMiktar.Text);

                        dtDetay.Rows.Add(dr);
                    }

                    btnBarkodYazdir.PerformClick();
                }
                else
                { 
                    CustomMsgBtn.Show(resp.Description, "Uyarı", "TAMAM");
                }
            }
            catch (Exception)
            {
            }
            finally
            {
                txtPaletNo.Text = "";
            }
        }

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(istasyon, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }
    }
}

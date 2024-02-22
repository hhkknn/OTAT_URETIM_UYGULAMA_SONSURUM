using AIF.UVT.DatabaseLayer;
using AIF.UVT.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT.FORM_ORTAK
{
    public partial class SayiKlavyesiPartiSecim : Form
    {
        //font start
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //font end

        private DataGridView dtgridParams = null;
        private string basevalue = "";
        private bool timeField = false;
        private bool integerField = false;
        private TextBox tparam = new TextBox();
        public static string GirisOk = "";
        private DataTable dtParti = new DataTable();
        private int currentRow = -1;
        private DataTable dtParams = new DataTable();
        private DataTable dtParams_FifoOlmayan = new DataTable();
        System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");
        private string uretimFisNo = "";
        public SayiKlavyesiPartiSecim(TextBox text, DataGridView _dtgridParams, DataTable _dtParams, DataTable _dtParams_FifoOlmayan, string _uretimFisNo, bool _timeField = false, bool _integerfield = false)
        {
            tparam = text;
            dtgridParams = _dtgridParams;
            integerField = _integerfield;
            //urunKodu = _urunKodu;
            //partiNo = _partiNo;
            //uretimSarf = _uretimSarf;
            dtParams = _dtParams;
            dtParams_FifoOlmayan = _dtParams_FifoOlmayan;
            uretimFisNo = _uretimFisNo;

            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            #region font
            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            initialFontSize = label3.Font.Size;
            label3.Resize += Form_Resize;

            initialFontSize = txtUrunKodu.Font.Size;
            txtUrunKodu.Resize += Form_Resize;

            initialFontSize = txtParti.Font.Size;
            txtParti.Resize += Form_Resize;

            initialFontSize = txtMiktar.Font.Size;
            txtMiktar.Resize += Form_Resize;

            initialFontSize = txtPlanlananSarf.Font.Size;
            txtPlanlananSarf.Resize += Form_Resize;

            initialFontSize = txtGerceklesenSarf.Font.Size;
            txtGerceklesenSarf.Resize += Form_Resize;

            initialFontSize = txtBeklenenSarf.Font.Size;
            txtBeklenenSarf.Resize += Form_Resize;

            initialFontSize = btnBir.Font.Size;
            btnBir.Resize += Form_Resize;

            initialFontSize = btnIki.Font.Size;
            btnIki.Resize += Form_Resize;

            initialFontSize = btnUc.Font.Size;
            btnUc.Resize += Form_Resize;

            initialFontSize = btnDort.Font.Size;
            btnDort.Resize += Form_Resize;

            initialFontSize = btnBes.Font.Size;
            btnBes.Resize += Form_Resize;

            initialFontSize = btnAlti.Font.Size;
            btnAlti.Resize += Form_Resize;

            initialFontSize = btnYedi.Font.Size;
            btnYedi.Resize += Form_Resize;

            initialFontSize = btnSekiz.Font.Size;
            btnSekiz.Resize += Form_Resize;

            initialFontSize = btnDokuz.Font.Size;
            btnDokuz.Resize += Form_Resize;

            initialFontSize = btnVirgul.Font.Size;
            btnVirgul.Resize += Form_Resize;

            initialFontSize = btnSifir.Font.Size;
            btnSifir.Resize += Form_Resize;

            initialFontSize = btnSil.Font.Size;
            btnSil.Resize += Form_Resize;

            initialFontSize = btnListeyeEkle.Font.Size;
            btnListeyeEkle.Resize += Form_Resize;

            initialFontSize = btnEksi.Font.Size;
            btnEksi.Resize += Form_Resize;

            initialFontSize = btnIptal.Font.Size;
            btnIptal.Resize += Form_Resize;

            initialFontSize = btnSarfTamamla.Font.Size;
            btnSarfTamamla.Resize += Form_Resize;
            #endregion
            //font end


            if (text != null)
            {
                try
                {
                    txtMiktar.Text = Convert.ToDouble(text.Text).ToString("N" + Giris.OndalikMiktar, cultureTR);
                    txtMiktar.Text = parseNumber.parservalues<double>(text.Text.ToString()).ToString();
                }
                catch (Exception)
                {
                }
            }
            else
            {
                try
                {
                    if (dtgridParams.Name == "dtgSarfMalzeme")
                    {
                        //textBox1.Text = Convert.ToDouble(dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value).ToString("N" + Giris.OndalikMiktar, cultureTR);//old milyara çevirdiğinden kapattım
                        txtMiktar.Text = parseNumber.parservalues<double>(dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value.ToString()).ToString("N" + Giris.OndalikMiktar);

                        txtPlanlananSarf.Text = parseNumber.parservalues<double>(dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Planlanan Miktar"].Value.ToString()).ToString("N" + Giris.OndalikMiktar);
                        txtGerceklesenSarf.Text = parseNumber.parservalues<double>(dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Gerçekleşen Miktar"].Value.ToString()).ToString("N" + Giris.OndalikMiktar);
                        double gercek = parseNumber.parservalues<double>(dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Gerçekleşen Miktar"].Value.ToString());
                        double plan = parseNumber.parservalues<double>(dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Planlanan Miktar"].Value.ToString());
                        txtBeklenenSarf.Text = (plan - gercek).ToString("N" + Giris.OndalikMiktar);
                    }
                    else
                    {
                        if (_timeField == false)
                        {
                            //textBox1.Text = Convert.ToDouble(dtgridParams.CurrentCell.Value).ToString("N" + Giris.OndalikMiktar, cultureTR); //
                            txtMiktar.Text = parseNumber.parservalues<double>(dtgridParams.CurrentCell.Value.ToString()).ToString("N" + Giris.OndalikMiktar);
                        }
                        else
                        {
                            var saat = dtgridParams.CurrentCell.Value.ToString();
                            txtMiktar.Text = saat;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            basevalue = txtMiktar.Text;
            //TableLayoutRowStyleCollection styles = this.tableLayoutPanel2.RowStyles;
            //double rowh = styles[1].Height;

            //txtUrunKodu.Font = new Font("Microsoft Sans Serif", Convert.ToInt32(rowh), FontStyle.Bold);
            //txtParti.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtMiktar.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtPlanlananSarf.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtGerceklesenSarf.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
            //txtBeklenenSarf.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //font start
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label2.Font.Style);

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
             (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
             label3.Font.Style);

            txtUrunKodu.Font = new Font(txtUrunKodu.Font.FontFamily, initialFontSize *
   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
   txtUrunKodu.Font.Style);

            txtParti.Font = new Font(txtParti.Font.FontFamily, initialFontSize *
   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
   txtParti.Font.Style);

            txtMiktar.Font = new Font(txtMiktar.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtMiktar.Font.Style);

            txtPlanlananSarf.Font = new Font(txtPlanlananSarf.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtPlanlananSarf.Font.Style);

            txtGerceklesenSarf.Font = new Font(txtGerceklesenSarf.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtGerceklesenSarf.Font.Style);

            txtBeklenenSarf.Font = new Font(txtBeklenenSarf.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtBeklenenSarf.Font.Style);

            btnBir.Font = new Font(btnBir.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnBir.Font.Style);

            btnIki.Font = new Font(btnIki.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnIki.Font.Style);

            btnUc.Font = new Font(btnUc.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnUc.Font.Style);

            btnDort.Font = new Font(btnDort.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnDort.Font.Style);

            btnBes.Font = new Font(btnBes.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnBes.Font.Style);

            btnAlti.Font = new Font(btnAlti.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnAlti.Font.Style);

            btnYedi.Font = new Font(btnYedi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnYedi.Font.Style);

            btnSekiz.Font = new Font(btnSekiz.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSekiz.Font.Style);

            btnDokuz.Font = new Font(btnDokuz.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnDokuz.Font.Style);

            btnVirgul.Font = new Font(btnVirgul.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnVirgul.Font.Style);

            btnSifir.Font = new Font(btnSifir.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSifir.Font.Style);

            btnSil.Font = new Font(btnSil.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSil.Font.Style);

            btnListeyeEkle.Font = new Font(btnListeyeEkle.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnListeyeEkle.Font.Style);

            btnEksi.Font = new Font(btnEksi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnEksi.Font.Style);

            btnIptal.Font = new Font(btnIptal.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnIptal.Font.Style);

            btnSarfTamamla.Font = new Font(btnSarfTamamla.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSarfTamamla.Font.Style);

            dtgParti.Font = new Font(dtgParti.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              dtgParti.Font.Style);

            ResumeLayout();
            //font end
            //watch.Stop();
            //MessageBox.Show(string.Format("Süre: {0}", watch.Elapsed.TotalMilliseconds));
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

        private void SayiKlavyesiPartiSecim_Load(object sender, EventArgs e)
        {
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

            txtUrunKodu.Focus();

            if (dtParams_FifoOlmayan.Rows.Count > 0 && dtParams_FifoOlmayan.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString()).Count() > 0)
            {
                //dtParti = dtParams_FifoOlmayan;

                //var parti = dtParams_FifoOlmayan.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == dtParams.AsEnumerable().Where(x => x.Field<string>("UrunKodu") && x.Field<string>("PartiNo") == dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Parti"].Value.ToString()).ToList();

                //var partilercc = dtParams.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == dr["UrunKodu"].ToString() && x.Field<string>("PartiNo") == dr["PartiNo"].ToString()).ToList();


                foreach (DataRow dr in dtParams_FifoOlmayan.Rows)
                {
                    //dtParams.AsEnumerable().Where(x => x.Field<string>("PartiNo") == dr["PartiNo"].ToString()).ToList().ForEach(y => y.Field<double>("Miktar") = parseNumber.parservalues<double>(dr["Miktar"].ToString()));

                    var partiler = dtParams.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == dr["UrunKodu"].ToString() && x.Field<string>("PartiNo") == dr["PartiNo"].ToString()).ToList();
                    foreach (DataRow drParams in partiler)
                    {
                        drParams["Miktar"] = parseNumber.parservalues<double>(dr["Miktar"].ToString());
                        #region burayı ekledim çünkü 1.satırda 2 tane pari girdim.2 satırda başka ürün için 1 adet parti girdim.sonra tekrar 1.satıra tıkladığımda 3 satır veri getiriyordu
                        if (dtParti.Rows.Count == 0)
                        {
                            dtParti.Columns.Add("UrunKodu", typeof(string));
                            dtParti.Columns.Add("PartiNo", typeof(string));
                            dtParti.Columns.Add("Miktar", typeof(double));
                        }
                        DataRow drnew = dtParti.NewRow();
                        drnew["UrunKodu"] = dr["UrunKodu"].ToString();
                        drnew["PartiNo"] = dr["PartiNo"].ToString();
                        drnew["Miktar"] = parseNumber.parservalues<double>(dr["Miktar"].ToString()).ToString("N" + Giris.OndalikMiktar);
                        dtParti.Rows.Add(drnew);
                        #endregion
                    }

                    dtParams.AcceptChanges();
                }

                var miktartoplami = dtParams_FifoOlmayan.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString().ToString()).Sum(y => y.Field<double>("Miktar"));

                txtBeklenenSarf.Text = (parseNumber.parservalues<double>(txtBeklenenSarf.Text.ToString()) - parseNumber.parservalues<double>(miktartoplami.ToString())).ToString("N" + Giris.OndalikMiktar);

            }

            GridDuzenle();
        }
        private void GridDuzenle()
        {
            try
            {
                if (dtParti.Rows.Count == 0)
                {
                    dtParti.Columns.Add("UrunKodu", typeof(string));
                    dtParti.Columns.Add("PartiNo", typeof(string));
                    dtParti.Columns.Add("Miktar", typeof(double));
                }

                dtgParti.DataSource = dtParti;

                dtgParti.AutoResizeColumns();

                dtgParti.EnableHeadersVisualStyles = false;
                dtgParti.RowTemplate.Height = 30;
                dtgParti.ColumnHeadersHeight = 40;
                dtgParti.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;

                DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

                btn = new DataGridViewButtonColumn();
                dtgParti.Columns.Add(btn);
                //dtgDetails.Columns[dtgDetails.ColumnCount - 1].DisplayIndex = dtgDetails.Columnscount-1;
                btn.HeaderText = "";
                btn.Text = "Sil";
                btn.Name = "btnSil";
                btn.UseColumnTextForButtonValue = true;

                //dtgParti.Columns["SatirNo"].Visible = false;

                //dtgParti.DefaultCellStyle.WrapMode = DataGridViewTriState.True; 

                foreach (DataGridViewColumn column in dtgParti.Columns) //columns tıklayınca girişe atıyor
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                if (dtgParti.Rows.Count > 0)
                {
                    dtgParti.Rows[0].Selected = false;
                    dtgParti.Columns["Miktar"].DisplayIndex = 2;
                    if (dtgParti.Columns.Contains("KulMiktar"))
                    {
                        dtgParti.Columns["KulMiktar"].Visible = false;
                    }
                }

            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM");
            }
        }
        private void dtgParti_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > 0)
                {
                    //barcode = dtParti.Rows[e.RowIndex]["Barkod"].ToString();

                    currentRow = e.RowIndex + 1;
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM");
            }
        }
        
        private void dtgParti_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    if (senderGrid.Columns[e.ColumnIndex].Name == "btnSil")
                    {
                        //var partiler = dtParti.AsEnumerable().Where(x => x.Field<string>("PartiNo") == txtUrunKodu.Text && x.Field<string>("UrunKodu") == txtUrunKodu.Text).ToList();
                        var partiler = dtParti.AsEnumerable().Where(x => x.Field<string>("PartiNo") == dtgParti.Rows[e.RowIndex].Cells["PartiNo"].Value.ToString() && x.Field<string>("UrunKodu") == dtgParti.Rows[e.RowIndex].Cells["UrunKodu"].Value.ToString()).ToList();

                        foreach (DataRow dr in partiler)
                        {
                            txtBeklenenSarf.Text = (parseNumber.parservalues<double>(txtBeklenenSarf.Text.ToString()) + parseNumber.parservalues<double>(dr["Miktar"].ToString())).ToString("N" + Giris.OndalikMiktar);

                            var onEkrandakiParti = dtParams.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == dr["UrunKodu"].ToString() && x.Field<string>("PartiNo") == dr["PartiNo"].ToString()).ToList();
                            foreach (DataRow drParams in onEkrandakiParti)
                            {
                                drParams["Miktar"] = parseNumber.parservalues<double>(drParams["Miktar"].ToString()) - parseNumber.parservalues<double>(dr["Miktar"].ToString()); 
                            }

                            //BURASI SARF TAMAMLA BASINCA ÇALIŞMALI M?
                            #region satir silmeme rağmen fifoolmayan dt de satır hala silinmiyor.satıra tıkladığımda tekrar parti tabosu doluyordu bu yüzden fifoolmayandan sildim
                            var fifoolmayanlist = dtParams_FifoOlmayan.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == dr["UrunKodu"].ToString() && x.Field<string>("PartiNo") == dr["PartiNo"].ToString()).ToList();
                            foreach (DataRow fifolmayanRow in fifoolmayanlist)
                            {

                                fifolmayanRow.Delete();
                            }
                            dtParams_FifoOlmayan.AcceptChanges();

                            #endregion

                            dr.Delete(); //fifodan önce siliyorduk hata aldıgım için buraya koydum
                            dtParams.AcceptChanges();//fifodan önce siliyorduk hata aldıgım için buraya koydum
                        }

                        dtParti.AcceptChanges();
                        //dtgParti.Rows.RemoveAt(e.RowIndex);
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM");
            }
        }
        private void btnListeyeEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUrunKodu.Text == "")
                {
                    CustomMsgBtn.Show("URUN KODU GİRİLMELİDİR.", "UYARI", "TAMAM");
                    txtUrunKodu.Focus();
                    return;
                }
                if (txtParti.Text == "")
                {
                    CustomMsgBtn.Show("PARTİ GİRİLMELİDİR.", "UYARI", "TAMAM");
                    txtParti.Focus();
                    return;
                }
                if (txtMiktar.Text == "" || parseNumber.parservalues<double>(txtMiktar.Text) == 0)
                {
                    CustomMsgBtn.Show("MİKTAR GİRİLMELİDİR.", "UYARI", "TAMAM");
                    txtMiktar.Focus();
                    return;
                }
                if (txtUrunKodu.Text != dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString())
                {
                    CustomMsgBtn.Show("ÜRÜN KODU UYUŞMAMAKTADIR.", "UYARI", "TAMAM");
                    txtUrunKodu.Focus();
                    return;
                }
                int count = dtParams.AsEnumerable().Where(x => x.Field<string>("PartiNo") == txtParti.Text).Count();

                if (count == 0)
                {
                    CustomMsgBtn.Show("PARTİ NUMARASI BULUNAMADI.", "UYARI", "TAMAM");
                    txtParti.Focus();
                    return;
                }
                var mik = dtParams.AsEnumerable().Where(x => x.Field<string>("PartiNo") == txtParti.Text).Select(y => y.Field<double>("KulMiktar")).FirstOrDefault().ToString();

                double oncedengirilen = 0;

                if (dtParti.Rows.Count > 0)
                {
                    oncedengirilen = dtParti.AsEnumerable().Where(x => x.Field<string>("PartiNo") == txtParti.Text).Sum(y => y.Field<double>("Miktar"));

                }
                if (parseNumber.parservalues<double>(txtMiktar.Text) > parseNumber.parservalues<double>(txtBeklenenSarf.Text))
                {
                    CustomMsgBtn.Show("BEKLENEN SARFTAN FAZLA MİKTAR GİRİLEMEZ.", "UYARI", "TAMAM");
                    txtMiktar.Text = "";
                    txtMiktar.Focus();
                    return;
                }
                if (parseNumber.parservalues<double>(txtMiktar.Text) + oncedengirilen > parseNumber.parservalues<double>(mik))
                {
                    CustomMsgBtn.Show("PARTİ MİKTARINDAN FAZLA MİKTAR GİRİLEMEZ.", "UYARI", "TAMAM");
                    txtMiktar.Text = "";
                    txtMiktar.Focus();
                    return;
                }
                if (dtParti.Rows.Count > 0 && dtParti.AsEnumerable().Where(x => x.Field<string>("UrunKodu") == txtUrunKodu.Text && x.Field<string>("PartiNo") == txtParti.Text).Count() > 0)
                {
                    //foreach (DataGridViewRow dr in dtgParti.Rows)
                    //{
                    //    if (dr.Cells["UrunKodu"].Value.ToString() == txtUrunKodu.Text && dr.Cells["PartiNo"].Value.ToString() == txtParti.Text)
                    //    {
                    //        dr.Cells["Miktar"].Value = parseNumber.parservalues<double>(txtMiktar.Text) + parseNumber.parservalues<double>(dr.Cells["Miktar"].Value.ToString());
                    //    } 
                    //} deneyelim kanka

                    var partiler = dtParti.AsEnumerable().Where(x => x.Field<string>("PartiNo") == txtParti.Text && x.Field<string>("UrunKodu") == txtUrunKodu.Text).ToList();

                    foreach (DataRow dr in partiler)
                    {
                        dr["Miktar"] = parseNumber.parservalues<double>(txtMiktar.Text) + parseNumber.parservalues<double>(dr["Miktar"].ToString());
                    }
                    txtBeklenenSarf.Text = (parseNumber.parservalues<double>(txtBeklenenSarf.Text) - parseNumber.parservalues<double>(txtMiktar.Text)).ToString("N" + Giris.OndalikMiktar);
                }
                else
                {
                    DataRow dr = dtParti.NewRow();
                    dr["UrunKodu"] = txtUrunKodu.Text;
                    dr["PartiNo"] = txtParti.Text;
                    dr["Miktar"] = parseNumber.parservalues<double>(txtMiktar.Text).ToString("N" + Giris.OndalikMiktar);
                    txtBeklenenSarf.Text = (parseNumber.parservalues<double>(txtBeklenenSarf.Text) - parseNumber.parservalues<double>(txtMiktar.Text)).ToString("N" + Giris.OndalikMiktar);
                    dtParti.Rows.Add(dr);
                }

                txtMiktar.Text = "";
                txtMiktar.Focus();
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void txtUrunKodu_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtUrunKodu.Text != dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString())
                    {
                        CustomMsgBtn.Show("ÜRÜN KODU UYUŞMAMAKTADIR.", "UYARI", "TAMAM");
                        txtUrunKodu.Text = "";
                        return;
                    }
                    else
                    {
                        txtParti.ReadOnly = false;
                        txtParti.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM");

            }
        }

        private void txtParti_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    int count = dtParams.AsEnumerable().Where(x => x.Field<string>("PartiNo") == txtParti.Text).Count();

                    if (count == 0)
                    {
                        CustomMsgBtn.Show("PARTİ NUMARASI UYUŞMAMAKTADIR.", "UYARI", "TAMAM");
                        txtParti.Text = "";
                        txtMiktar.ReadOnly = true;

                        return;
                    }
                    else
                    {
                        //var kulmik = dtParams.AsEnumerable().Where(x => x.Field<string>("PartiNo") == txtParti.Text).Select(y => y.Field<double>("Miktar")).FirstOrDefault();
                        txtMiktar.ReadOnly = false;
                        //txtMiktar.Text = kulmik.ToString("N" + Giris.OndalikMiktar);
                        txtMiktar.Focus();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM");

            }
        }

        private void txtMiktar_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btnListeyeEkle.PerformClick();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM");
            }
        }
        SqlCommand cmd = new SqlCommand();
        private void btnSarfTamamla_Click(object sender, EventArgs e)
        {
            #region Eski pardon old :D:)
            //if (timeField)
            //{
            //    if (txtMiktar.Text.Length != 5 && txtMiktar.Text != "")
            //    {
            //        CustomMsgBtn.Show(string.Format("{0} saat girişi saat formatına uygun değildir.", txtMiktar.Text), "UYARI", "TAMAM");
            //        return;
            //    }
            //}
            //if (tparam != null)
            //{
            //    tparam.Text = txtMiktar.Text;
            //}
            //else if (dtgridParams != null)
            //{
            //    try
            //    {
            //        if (integerField)
            //        {
            //            int val = 0;

            //            try
            //            {
            //                //val = (int)Convert.ToDouble(textBox1.Text);//old 20220722
            //                val = (int)parseNumber.parservalues<double>(txtMiktar.Text.ToString());
            //                dtgridParams.NotifyCurrentCellDirty(true);
            //                dtgridParams.CurrentCell.Value = Convert.ToString(val);
            //            }
            //            catch (Exception)
            //            {
            //            }

            //        }
            //        else if (timeField == false)
            //        {
            //            System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

            //            //double val = Convert.ToDouble(textBox1.Text.Replace(",", "."));
            //            double val = double.Parse(txtMiktar.Text, cultureTR);
            //            dtgridParams.NotifyCurrentCellDirty(true);

            //            GirisOk = "DEG";
            //            if (dtgridParams.Name == "dtgSarfMalzeme")
            //            {
            //                dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = Convert.ToString(val);
            //            }
            //            else
            //            {
            //                dtgridParams.CurrentCell.Value = Convert.ToString(val);
            //            }
            //        }
            //        else if (timeField == true)
            //        {
            //            //System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");
            //            //double val = double.Parse(textBox1.Text, cultureTR);
            //            //string saat = val.ToString().PadRight(4, '0');

            //            //saat = saat.Insert(2, ":");

            //            //dtgridParams.NotifyCurrentCellDirty(true);
            //            //dtgridParams.CurrentCell.Value = "";
            //            dtgridParams.CurrentCell.Value = Convert.ToString(txtMiktar.Text);
            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        CustomMsgBtn.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM");
            //    }
            //} 
            #endregion

            try
            { 
                if (dtgridParams != null)
                {
                    #region parti tablosundan satır silindiğinde ön ekrandaki miktar sıfırlansın diye - fifoolmayan tablosundan silmek için???
                    if (dtgParti.Rows.Count == 0)
                    {
                        double val2 = parseNumber.parservalues<double>(dtParti.AsEnumerable().Sum(x => x.Field<double>("Miktar")).ToString());
                        dtgridParams.NotifyCurrentCellDirty(true);

                        if (dtgridParams.Name == "dtgSarfMalzeme")
                        {
                            dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = Convert.ToString(val2);
                        }
                        else
                        {
                            dtgridParams.CurrentCell.Value = Convert.ToString(val2);
                        }

                        #region fifo olmayandna sil??

                        #endregion
                        GirisOk = "DEG";
                        Close();
                        return;
                    }
                    #endregion

                    #region sarf
                    string sarfOranHesaplamaSekli = "";

                    #region Sarf Oran Hesaplama Şekli Alınır.

                    string urunkodu = dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                    var GirilenMiktar = dtParti.AsEnumerable().Sum(y => y.Field<double>("Miktar"));
                    var miktar = Convert.ToDouble(dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Planlanan Miktar"].Value);
                    var Gerceklesenmiktar = Convert.ToDouble(dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Gerçekleşen Miktar"].Value);

                    string sql = "Select \"U_SrfOrnHspSkl\" from \"@AIF_UVT_PARAM\" WITH (NOLOCK)";
                    cmd = new SqlCommand(sql, Connection.sql);

                    if (Connection.sql.State != ConnectionState.Open)
                        Connection.sql.Open();

                    SqlDataAdapter sda3 = new SqlDataAdapter(cmd);
                    DataTable dt_Sorgu3 = new DataTable();
                    sda3.Fill(dt_Sorgu3);

                    #region sql connection chn

                    Connection.sql.Close();
                    Connection.sql.Dispose();
                    if (Connection.sql.State == ConnectionState.Open)
                    {
                        cmd.ExecuteNonQuery();
                    }

                    #endregion sql connection chn

                    sarfOranHesaplamaSekli = dt_Sorgu3.Rows[0][0].ToString();

                    #endregion Sarf Oran Hesaplama Şekli Alınır.

                    if (sarfOranHesaplamaSekli == "1")
                    {
                        #region SARF ORANI HEASAPLAMA (OITM ÜZERİNDEN HESAPLAMA)

                        double sarfOran = 0;

                        sql = "Select \"U_SarfOran\" FROM OITM WITH (NOLOCK) where \"ItemCode\" = '" + urunkodu + "'";
                        cmd = new SqlCommand(sql, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        SqlDataAdapter sda2 = new SqlDataAdapter(cmd);
                        DataTable dt_Sorgu2 = new DataTable();
                        sda2.Fill(dt_Sorgu2);

                        #region sql connection chn

                        Connection.sql.Close();
                        Connection.sql.Dispose();
                        if (Connection.sql.State == ConnectionState.Open)
                        {
                            cmd.ExecuteNonQuery();
                        }

                        #endregion sql connection chn

                        if (dt_Sorgu2.Rows.Count > 0)
                        {
                            if (dt_Sorgu2.Rows[0][0] != null)
                            {
                                sarfOran = dt_Sorgu2.Rows[0][0].ToString() == "" ? 0 : Convert.ToDouble(dt_Sorgu2.Rows[0][0]);

                                //if (sarfOran == 0)//SARF ORAN HESAPLAMASI 0'DAN BÜYÜK BİR DEĞER GİRİLMİŞ İSE YAPILACAKTIR. BOŞ DEĞER 0 OLARAK KABUL EDİLİR. FATİH ABİYLE EN SON BU ŞEKİLDE KONUŞTUK. 19.07.2022
                                //{
                                //    if (miktar != GirilenMiktar)
                                //    {
                                //        dtgSarfMalzeme.Rows[e.RowIndex].Cells["Miktar"].Value = Convert.ToString(0.ToString("N" + Giris.OndalikMiktar), cultureTR);

                                //        var fark3 = miktar - (Gerceklesenmiktar);

                                //        dtgSarfMalzeme.Rows[e.RowIndex].Cells["Fark"].Value = Convert.ToString(fark3.ToString(), cultureTR);

                                //        CustomMsgBtn.Show("Miktar girişi sarf için uyumsuzdur. Lütfen kontrol ediniz.", "UYARI", "TAMAM");

                                //        dtgSarfMalzeme.Rows[e.RowIndex].Cells["Miktar"].Value = DBNull.Value;

                                //        return;
                                //    }
                                //}
                                //else
                                //{
                                //if (sarfOran > 0 && sarfOran.ToString() != "")
                                //{
                                if (parseNumber.parservalues<double>(txtGerceklesenSarf.Text) == 0)
                                {
                                    double miktarinYuzdesi = (miktar * sarfOran) / 100;
                                    double toplamGirebilecekFazlaMiktar = miktar + miktarinYuzdesi;
                                    double toplamGirebilecekEksikMiktar = miktar - miktarinYuzdesi;

                                    if (GirilenMiktar > toplamGirebilecekFazlaMiktar)
                                    {
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = Convert.ToString(0.ToString("N" + Giris.OndalikMiktar), cultureTR);
                                        CustomMsgBtn.Show("Miktar girişi sarf için uyumsuzdur. Lütfen kontrol ediniz.", "UYARI", "TAMAM");
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = DBNull.Value;

                                        return;
                                    }

                                    if (GirilenMiktar < toplamGirebilecekEksikMiktar)
                                    {
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = Convert.ToString(0.ToString("N" + Giris.OndalikMiktar), cultureTR);
                                        CustomMsgBtn.Show("Miktar girişi sarf için uyumsuzdur. Lütfen kontrol ediniz.", "UYARI", "TAMAM");
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = DBNull.Value;

                                        return;
                                    }
                                }
                                else
                                {
                                    //Gerceklesenmiktar = Convert.ToDouble(dtgSarfMalzeme.Rows[e.RowIndex].Cells["Gerçekleşen Miktar"].Value);
                                    double miktarinYuzdesi = (miktar * sarfOran) / 100;
                                    double eklenenToplamMiktar = GirilenMiktar + Gerceklesenmiktar;

                                    double toplamGirebilecekFazlaMiktar = miktar + miktarinYuzdesi;
                                    double toplamGirebilecekEksikMiktar = miktar - miktarinYuzdesi;

                                    if (eklenenToplamMiktar > toplamGirebilecekFazlaMiktar)
                                    {
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = Convert.ToString(0.ToString("N" + Giris.OndalikMiktar), cultureTR);

                                        if (eklenenToplamMiktar > 0)
                                        {
                                            var fark3 = miktar - (Gerceklesenmiktar);

                                            dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Fark"].Value = Convert.ToString(fark3.ToString(), cultureTR);
                                        }
                                        CustomMsgBtn.Show("Miktar girişi sarf için uyumsuzdur. Lütfen kontrol ediniz.", "UYARI", "TAMAM");
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = DBNull.Value;

                                        return;
                                    }

                                    if (eklenenToplamMiktar < toplamGirebilecekEksikMiktar)
                                    {
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = Convert.ToString(0.ToString("N" + Giris.OndalikMiktar), cultureTR);

                                        if (eklenenToplamMiktar > 0)
                                        {
                                            var fark3 = miktar - (Gerceklesenmiktar);

                                            dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Fark"].Value = Convert.ToString(fark3.ToString(), cultureTR);
                                        }
                                        CustomMsgBtn.Show("Miktar girişi sarf için uyumsuzdur. Lütfen kontrol ediniz.", "UYARI", "TAMAM");
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = DBNull.Value;

                                        return;
                                    }

                                    if (eklenenToplamMiktar > 0)
                                    {
                                        var fark3 = miktar - (eklenenToplamMiktar);

                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Fark"].Value = Convert.ToString(fark3.ToString(), cultureTR);
                                    }
                                }
                            }
                            //}
                        }
                        //}

                        #endregion SARF ORANI HEASAPLAMA (OITM ÜZERİNDEN HESAPLAMA)
                    }
                    else if (sarfOranHesaplamaSekli == "2")
                    {
                        #region SARF ORANI HEASAPLAMA (OWOR (Üretim Siparişi) ÜZERİNDEN HESAPLAMA)

                        double sarfOran = 0;

                        sql = "Select T1.\"U_SarfOran\" FROM OWOR AS T0 WITH (NOLOCK) INNER JOIN WOR1 AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"DocNum\" = '" + uretimFisNo + "'  and T1.\"ItemCode\" = '" + urunkodu + "'";
                        cmd = new SqlCommand(sql, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        SqlDataAdapter sda2 = new SqlDataAdapter(cmd);
                        DataTable dt_Sorgu2 = new DataTable();
                        sda2.Fill(dt_Sorgu2);

                        #region sql connection chn

                        Connection.sql.Close();
                        Connection.sql.Dispose();
                        if (Connection.sql.State == ConnectionState.Open)
                        {
                            cmd.ExecuteNonQuery();
                        }

                        #endregion sql connection chn

                        if (dt_Sorgu2.Rows.Count > 0)
                        {
                            if (dt_Sorgu2.Rows[0][0] != null)
                            {
                                sarfOran = dt_Sorgu2.Rows[0][0].ToString() == "" ? 0 : Convert.ToDouble(dt_Sorgu2.Rows[0][0]);

                                //if (sarfOran == 0) //SARF ORAN HESAPLAMASI 0'DAN BÜYÜK BİR DEĞER GİRİLMİŞ İSE YAPILACAKTIR. BOŞ DEĞER 0 OLARAK KABUL EDİLİR. FATİH ABİYLE EN SON BU ŞEKİLDE KONUŞTUK. 19.07.2022
                                //{
                                //    if (miktar != GirilenMiktar)
                                //    {
                                //        dtgSarfMalzeme.Rows[e.RowIndex].Cells["Miktar"].Value = Convert.ToString(0.ToString("N" + Giris.OndalikMiktar), cultureTR);

                                //        var fark3 = miktar - (Gerceklesenmiktar);

                                //        dtgSarfMalzeme.Rows[e.RowIndex].Cells["Fark"].Value = Convert.ToString(fark3.ToString(), cultureTR);

                                //        CustomMsgBtn.Show("Miktar girişi sarf için uyumsuzdur. Lütfen kontrol ediniz.", "UYARI", "TAMAM");

                                //        dtgSarfMalzeme.Rows[e.RowIndex].Cells["Miktar"].Value = DBNull.Value;

                                //        return;
                                //    }
                                //}
                                //else
                                //{
                                //if (sarfOran > 0 && sarfOran.ToString() != "")
                                //{
                                if (Gerceklesenmiktar == 0)
                                {
                                    double miktarinYuzdesi = (miktar * sarfOran) / 100;
                                    double toplamGirebilecekFazlaMiktar = miktar + miktarinYuzdesi;
                                    double toplamGirebilecekEksikMiktar = miktar - miktarinYuzdesi;

                                    if (GirilenMiktar > toplamGirebilecekFazlaMiktar)
                                    {
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = Convert.ToString(0.ToString("N" + Giris.OndalikMiktar), cultureTR);
                                        CustomMsgBtn.Show("Miktar girişi sarf için uyumsuzdur. Lütfen kontrol ediniz.", "UYARI", "TAMAM");
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = DBNull.Value;

                                        return;
                                    }

                                    if (GirilenMiktar < toplamGirebilecekEksikMiktar)
                                    {
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = Convert.ToString(0.ToString("N" + Giris.OndalikMiktar), cultureTR);
                                        CustomMsgBtn.Show("Miktar girişi sarf için uyumsuzdur. Lütfen kontrol ediniz.", "UYARI", "TAMAM");
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = DBNull.Value;

                                        return;
                                    }
                                }
                                else
                                {
                                    //Gerceklesenmiktar = Convert.ToDouble(dtgridParams.Rows[e.RowIndex].Cells["Gerçekleşen Miktar"].Value);
                                    double miktarinYuzdesi = (miktar * sarfOran) / 100;
                                    double eklenenToplamMiktar = GirilenMiktar + Gerceklesenmiktar;

                                    double toplamGirebilecekFazlaMiktar = miktar + miktarinYuzdesi;
                                    double toplamGirebilecekEksikMiktar = miktar - miktarinYuzdesi;

                                    if (eklenenToplamMiktar > toplamGirebilecekFazlaMiktar)
                                    {
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = Convert.ToString(0.ToString("N" + Giris.OndalikMiktar), cultureTR);

                                        if (eklenenToplamMiktar > 0)
                                        {
                                            var fark3 = miktar - (Gerceklesenmiktar);

                                            dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Fark"].Value = Convert.ToString(fark3.ToString(), cultureTR);
                                        }
                                        CustomMsgBtn.Show("Miktar girişi sarf için uyumsuzdur. Lütfen kontrol ediniz.", "UYARI", "TAMAM");
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = DBNull.Value;

                                        return;
                                    }

                                    if (eklenenToplamMiktar < toplamGirebilecekEksikMiktar)
                                    {
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = Convert.ToString(0.ToString("N" + Giris.OndalikMiktar), cultureTR);

                                        if (eklenenToplamMiktar > 0)
                                        {
                                            var fark3 = miktar - (Gerceklesenmiktar);

                                            dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Fark"].Value = Convert.ToString(fark3.ToString(), cultureTR);
                                        }
                                        CustomMsgBtn.Show("Miktar girişi sarf için uyumsuzdur. Lütfen kontrol ediniz.", "UYARI", "TAMAM");
                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = DBNull.Value;

                                        return;
                                    }

                                    if (eklenenToplamMiktar > 0)
                                    {
                                        var fark3 = miktar - (eklenenToplamMiktar);

                                        dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Fark"].Value = Convert.ToString(fark3.ToString(), cultureTR);
                                    }
                                }
                            }
                            //}
                        }
                        //}

                        #endregion SARF ORANI HEASAPLAMA (OWOR (Üretim Siparişi) ÜZERİNDEN HESAPLAMA)
                    }
                    #endregion

                    #region miktar giriş-hesaplama
                    foreach (DataRow dr in dtParti.Rows)
                    {
                        //dtParams.AsEnumerable().Where(x => x.Field<string>("PartiNo") == dr["PartiNo"].ToString()).ToList().ForEach(y => y.Field<double>("Miktar") = parseNumber.parservalues<double>(dr["Miktar"].ToString()));

                        var partiler = dtParams.AsEnumerable().Where(x => x.Field<string>("PartiNo") == dr["PartiNo"].ToString()).ToList();
                        foreach (DataRow drParams in partiler)
                        {
                            drParams["Miktar"] = parseNumber.parservalues<double>(dr["Miktar"].ToString());
                        }

                        dtParams.AcceptChanges();



                        var fifoOlmayandaVarmi = dtParams_FifoOlmayan.AsEnumerable().Where(x => x.Field<string>("PartiNo") == dr["PartiNo"].ToString()).ToList();

                        if (fifoOlmayandaVarmi.Count > 0)
                        {
                            var partiler2 = dtParams_FifoOlmayan.AsEnumerable().Where(x => x.Field<string>("PartiNo") == dr["PartiNo"].ToString() && x.Field<string>("UrunKodu") == dr["UrunKodu"].ToString()).ToList();

                            foreach (DataRow dr2 in partiler2)
                            {
                                dr2["Miktar"] = parseNumber.parservalues<double>(dr["Miktar"].ToString());
                            }
                        }
                        else
                        {
                            DataRow dr2 = dtParams_FifoOlmayan.NewRow();
                            dr2["UrunKodu"] = dr["UrunKodu"].ToString();
                            dr2["PartiNo"] = dr["PartiNo"].ToString();
                            dr2["Miktar"] = parseNumber.parservalues<double>(dr["Miktar"].ToString());
                            dtParams_FifoOlmayan.Rows.Add(dr2);
                        }

                    }

                    try
                    {
                        //double val2 = double.Parse(txtMiktar.Text, cultureTR); //burada parti tablosuunun sum hali ekleneceğiniz düşündüşümden bunu kapattım
                        double val2 = parseNumber.parservalues<double>(dtParti.AsEnumerable().Sum(x => x.Field<double>("Miktar")).ToString());
                        dtgridParams.NotifyCurrentCellDirty(true);

                        if (dtgridParams.Name == "dtgSarfMalzeme")
                        {
                            dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = Convert.ToString(val2);
                        }
                        else
                        {
                            dtgridParams.CurrentCell.Value = Convert.ToString(val2);
                        }
                    }
                    catch (Exception)
                    {
                    }

                    #endregion

                    GirisOk = "DEG";

                    Close();
                } 
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("HATA OLUŞTU." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtMiktar_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region sadece sayı girişi

            if (e.KeyChar.ToString() != ",")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }

            #endregion sadece sayı girişi

            #region sadece harf girişi

            //e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);

            #endregion sadece harf girişi
        }

        #region klavye
        private void textboxTemizle()
        {
            if (txtMiktar.Text == basevalue)
            {
                txtMiktar.Text = "";
            }
        }
        private void btnBir_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtMiktar.Text = txtMiktar.Text + "1";
        }

        private void btnIki_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtMiktar.Text = txtMiktar.Text + "2";
        }
        private void btnUc_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtMiktar.Text = txtMiktar.Text + "3";
        }

        private void btnDort_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtMiktar.Text = txtMiktar.Text + "4";
        }

        private void btnBes_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtMiktar.Text = txtMiktar.Text + "5";
        }

        private void btnAlti_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtMiktar.Text = txtMiktar.Text + "6";
        }

        private void btnYedi_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtMiktar.Text = txtMiktar.Text + "7";
        }

        private void btnSekiz_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtMiktar.Text = txtMiktar.Text + "8";
        }

        private void btnDokuz_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtMiktar.Text = txtMiktar.Text + "9";
        }

        private void btnVirgul_Click(object sender, EventArgs e)
        {
            if (!txtMiktar.Text.Contains(","))
            {
                txtMiktar.Text = txtMiktar.Text + ",";
            }
        }

        private void btnSifir_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            txtMiktar.Text = txtMiktar.Text + "0";
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                txtMiktar.Text = txtMiktar.Text.Remove(txtMiktar.Text.Length - 1, 1);
            }
            catch (Exception ex)
            {
            }
        }

        private void btnEksi_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            if (txtMiktar.Text == "")
            {
                txtMiktar.Text = "-";
            }
        }

        #endregion


    }
}

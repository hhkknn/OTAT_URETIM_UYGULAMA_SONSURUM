using AIF.UVT.DatabaseLayer;
using AIF.UVT.Library;
using AIF.UVT.UVTService;
using SAPbobsCOM;
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

namespace AIF.UVT
{
    public partial class TereyagProsesTakip_1 : Form
    {
        //font start.tsarım
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //font end
        public TereyagProsesTakip_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, int _width, int _height, string _tarih1, string _urunKodu)
        {
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            initialFontSize = label3.Font.Size;
            label3.Resize += Form_Resize;

            initialFontSize = txtUretimSiparisNo.Font.Size;
            txtUretimSiparisNo.Resize += Form_Resize;

            initialFontSize = txtPartyNo.Font.Size;
            txtPartyNo.Resize += Form_Resize;

            initialFontSize = txtUrunTanimi.Font.Size;
            txtUrunTanimi.Resize += Form_Resize;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;

            initialFontSize = button3.Font.Size;
            button3.Resize += Form_Resize;

            initialFontSize = button4.Font.Size;
            button4.Resize += Form_Resize;

            initialFontSize = button5.Font.Size;
            button5.Resize += Form_Resize;

            initialFontSize = button6.Font.Size;
            button6.Resize += Form_Resize;

            initialFontSize = button7.Font.Size;
            button7.Resize += Form_Resize;

            initialFontSize = btnOzetEkraniDon.Font.Size;
            btnOzetEkraniDon.Resize += Form_Resize;
            //font end

            UretimFisNo = _UretimFisNo;
            partiNo = _PartiNo;
            UrunTanimi = _UrunTanimi;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;
            urunKodu = _urunKodu;

            txtUretimSiparisNo.Text = UretimFisNo;
            txtUrunTanimi.Text = UrunTanimi;
            txtPartyNo.Text = partiNo;
            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
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

            txtUretimSiparisNo.Font = new Font(txtUretimSiparisNo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimSiparisNo.Font.Style);

            txtPartyNo.Font = new Font(txtPartyNo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtPartyNo.Font.Style);

            txtUrunTanimi.Font = new Font(txtUrunTanimi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUrunTanimi.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              button1.Font.Style);

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button2.Font.Style);

            button3.Font = new Font(button3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button3.Font.Style);

            button4.Font = new Font(button4.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              button4.Font.Style);

            button5.Font = new Font(button5.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button5.Font.Style);

            button6.Font = new Font(button6.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button6.Font.Style);

            button7.Font = new Font(button7.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button7.Font.Style);

            btnOzetEkraniDon.Font = new Font(btnOzetEkraniDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkraniDon.Font.Style);

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
          (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
          label4.Font.Style);

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimTarihi.Font.Style);
            ResumeLayout();
            //font end
        }

        private string UretimFisNo = "";
        private string partiNo = "";
        private string istasyon = "";
        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private string urunKodu = "";
        private int row = 0;
        private SqlCommand cmd = null;
        private string tarih1 = "";

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

        public List<kontrolListesi> kontrolListesis = new List<kontrolListesi>();
        public class kontrolListesi
        {
            public string aktifKolon { get; set; }
            public string kontroledilmesigerekenKolon { get; set; }
        }

        public bool Kontrol(string _kontroledilmesigerekenKolon, DataGridView dtg, DataGridView dtg2)
        {

            string temelkolon = kontrolListesis.Where(x => x.aktifKolon == _kontroledilmesigerekenKolon).Select(y => y.kontroledilmesigerekenKolon).FirstOrDefault();


            if (temelkolon != null)
            {
                string val = "";

                if (dtg2 != null)
                {
                    val = dtg2.Rows[dtg2.Rows.Count - 1].Cells[temelkolon].Value.ToString();
                }
                else
                {
                    val = dtg.Rows[dtg.CurrentCell.RowIndex].Cells[temelkolon].Value.ToString();
                }

                if (val == "")
                {
                    CustomMsgBtn.Show(temelkolon + " doldurulmadan " + _kontroledilmesigerekenKolon + " kolon doldurulamaz.", "UYARI", "TAMAM");
                    return false;
                }
                else
                {
                    try
                    {
                        double val2 = 0;

                        if (dtg2 != null)
                        {
                            val2 = Convert.ToDouble(dtg2.Rows[dtg2.Rows.Count - 1].Cells[temelkolon].Value);
                        }
                        else
                        {
                            val2 = Convert.ToDouble(dtg.Rows[dtg.CurrentCell.RowIndex].Cells[temelkolon].Value);
                        }
                        if (val2 == 0)
                        {
                            CustomMsgBtn.Show(temelkolon + " doldurulmadan " + _kontroledilmesigerekenKolon + " kolon doldurulamaz.", "UYARI", "TAMAM");
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }



            return true;
        }
        private void TereyagProsesTakip_1_Load(object sender, EventArgs e)
        {
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_TRYGPRSS_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtAciklama.Text = dt.Rows[0].ItemArray[0].ToString();
            }

            dtgProsesOzellikleri1Load();
            dtgProsesOzellikleri2Load();
            dtgHammamaddeMiktarVeOzellik();
            dtgSarfMalzemeKullanim();
            dtgMamulOzellikleri();

            DataGridViewColumn dataGridViewColumn = dtgHammaddeMiktar.Columns["Kuru Madde (%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgHammaddeMiktar.Columns["Kuru Madde (%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgHammaddeMiktar.Columns["Yağ Oranı (%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgHammaddeMiktar.Columns["PH Değeri"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgHammaddeMiktar.Columns["SH Değeri"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["Hammmade ve Sarf Malzeme Toplamı"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtgMamulOz.Columns["Kuru Madde(%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["Yağ Oranı(%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["Yayık Altı Suyu Oranı (%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["Yağın PH Değeri"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["Üretilen Hamur"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;
        }

        private DataTable dtSarfMalzemeKullanim = new DataTable();
        private DataTable dtHammaddeMiktarveOzellik = new DataTable();
        private DataTable dtMamulOz = new DataTable();

        private void dtgProsesOzellikleri1Load()
        {
            string sql = "SELECT T1.\"U_PartiNo\" as \"Parti No\", T1.\"U_YagTuru\" as \"Yağ Türü\", T1.\"U_YagTuruKod\" as \"Yağ Türü Kod\", T1.\"U_GorevliOperator\" as \"Görevli Operatör\", T1.\"U_GorevliOperatorAdi\" as \"Görevli Operatör Adı\", T1.\"U_KremaPastorizasyonSicak\" as \"Krema Pastörizasyon Sıcaklığı (KKN1)\", T1.\"U_YayigaKremaYukBasSaat\" as \"Yayığa Krema Yük.Baş.\", T1.\"U_YayigaKremaYukBitSaat\" as \"Yayığa Krema Yük.Bit.\", T1.\"U_YagOlusmaSaati\" as \"Yağ Oluşma Saati\", T1.\"U_YikamaSayisi\" as \"Yıkama Sayısı (Adet)\", T1.\"U_YikamaBitisSaati\" as \"Yıkama Bitiş Saati\", T1.\"U_YaginYayiktanIndSaat\" as \"Yağın Yayıktan ind.Saat\", T1.\"U_YaginGramajlamaBasSaat\" as \"Yağın Gramajlama Bas.\", T1.\"U_YaginGramajlamaBitSaat\" as \"Yağın Gramajlama Bit.\" FROM \"@AIF_TRYGPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TRYGPRSS_ANLZ1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dt2 = new DataTable();
            sda.Fill(dt);
            string KremaPastorizasyonSicakligi = "0";

            string uretimdenCikissql = "Select T0.\"DocEntry\" from \"OIGE\" as T0 WITH (NOLOCK) INNER JOIN \"IGE1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "'";

            cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                var uretimicinCikisNo = dt2.Rows[0][0].ToString();
                dt2 = new DataTable();

                string kremasicakliksql = "SELECT T0.[BatchNum] FROM IBT1 T0 WITH (NOLOCK)  INNER JOIN OITM T1 WITH (NOLOCK) ON T0.[ItemCode] = T1.[ItemCode] WHERE T0.[BaseType]  = '60' AND  T1.[U_ItemGroup2] ='121' AND  T0.[BaseEntry] = '" + uretimicinCikisNo + "'";

                cmd = new SqlCommand(kremasicakliksql, Connection.sql);
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt2);

                if (dt2.Rows.Count > 0)
                {
                    var uretimicinCikisPartiNo = dt2.Rows[0][0].ToString();

                    dt2 = new DataTable();
                    string pastorizasyonAnalizSql = "SELECT ISNULL(\"U_KremaPastSicakligi\",0)  FROM [dbo].[@AIF_PASPRSS_ANLZ2] T0 WITH (NOLOCK) INNER JOIN [dbo].[@AIF_PASPRSS_ANLZ]  T1 WITH (NOLOCK) ON T0.DocEntry = T1.DocEntry where T1.U_PartiNo = '" + uretimicinCikisPartiNo + "'";

                    cmd = new SqlCommand(pastorizasyonAnalizSql, Connection.sql);
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt2);

                    if (dt2.Rows.Count > 0)
                    {
                        KremaPastorizasyonSicakligi = dt2.Rows[0][0].ToString();
                    }
                }
            }

            //Commit
            dtgProsesOzellikleri1.DataSource = dt;

            dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgProsesOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgProsesOzellikleri1.EnableHeadersVisualStyles = false;
            dtgProsesOzellikleri1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr["Parti No"] = partiNo;
                dr["Yağ Türü"] = txtUrunTanimi.Text;
                dr["Krema Pastörizasyon Sıcaklığı (KKN1)"] = Convert.ToString(KremaPastorizasyonSicakligi, cultureTR);

                dt.Rows.Add(dr);
            }
            else
            {
                var sicaklik = dtgProsesOzellikleri1.Rows[0].Cells["Krema Pastörizasyon Sıcaklığı (KKN1)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Krema Pastörizasyon Sıcaklığı (KKN1)"].Value);
                if (sicaklik == 0)
                {
                    dtgProsesOzellikleri1.Rows[0].Cells["Krema Pastörizasyon Sıcaklığı (KKN1)"].Value = Convert.ToString(KremaPastorizasyonSicakligi, cultureTR);
                }
            }

            dtgProsesOzellikleri1.Columns["Krema Pastörizasyon Sıcaklığı (KKN1)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri1.Columns["Krema Pastörizasyon Sıcaklığı (KKN1)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgProsesOzellikleri1.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgProsesOzellikleri1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgProsesOzellikleri1.Columns["Yağ Türü Kod"].Visible = false;
            dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            dtgProsesOzellikleri1.Columns["Görevli Operatör Adı"].HeaderText = "Operatör Adı";
            dtgProsesOzellikleri1.Columns["Krema Pastörizasyon Sıcaklığı (KKN1)"].HeaderText = "Krema Past. Sıc.(C)";
            //dtgProsesOzellikleri1.Columns["Krema Pastörizasyon Sıcaklığı (KKN1)"].HeaderText = "Krema Past. Sıc.(C)";
            dtgProsesOzellikleri1.Columns["Yıkama Sayısı (Adet)"].HeaderText = "Yıkama Sayısı";

            dtgProsesOzellikleri1.Rows[0].Height = dtgProsesOzellikleri1.Height - dtgProsesOzellikleri1.ColumnHeadersHeight;
            dtgProsesOzellikleri1.AutoResizeColumns();

            #region Kontrol listesi oluşturma 

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Görevli Operatör Adı",
                kontroledilmesigerekenKolon = "Yağ Türü"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Krema Pastörizasyon Sıcaklığı (KKN1)",
                kontroledilmesigerekenKolon = "Görevli Operatör Adı"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Yayığa Krema Yük.Baş.",
                kontroledilmesigerekenKolon = "Krema Pastörizasyon Sıcaklığı (KKN1)"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Yayığa Krema Yük.Bit.",
                kontroledilmesigerekenKolon = "Yayığa Krema Yük.Baş."
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Yağ Oluşma Saati",
                kontroledilmesigerekenKolon = "Yayığa Krema Yük.Bit."
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Yıkama Sayısı (Adet)",
                kontroledilmesigerekenKolon = "Yağ Oluşma Saati"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Yıkama Bitiş Saati",
                kontroledilmesigerekenKolon = "Yıkama Sayısı (Adet)"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Yağın Yayıktan ind.Saat",
                kontroledilmesigerekenKolon = "Yıkama Bitiş Saati"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Yağın Gramajlama Bas.",
                kontroledilmesigerekenKolon = "Yağın Yayıktan ind.Saat"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Yağın Gramajlama Bit.",
                kontroledilmesigerekenKolon = "Yağın Gramajlama Bas."
            });
            #endregion Kontrol listesi oluşturma 
        }
        



        private void dtgProsesOzellikleri2Load()
        {
            string sql = "SELECT T1.\"U_KremaYuklemeSuresiDk\" as \"Krema Yükleme Süresi (DK)\", T1.\"U_YayiklamaSuresiDk\" as \"Yayıklama Süresi (DK)\", T1.\"U_YikamaSuresiDk\" as \"Yıkama Süresi (DK)\", T1.\"U_YaginGramajlamaSuresiDk\" as \"Yağın Gramajlama Süresi (DK)\", T1.\"U_ToplamGecenSureDk\" as \"Toplam Geçen Süre (DK)\" FROM \"@AIF_TRYGPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TRYGPRSS_ANLZ2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgProsesOzellikleri2.DataSource = dt;

            dtgProsesOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgProsesOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dtgProsesOzellikleri2.EnableHeadersVisualStyles = false;
            dtgProsesOzellikleri2.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            if (dt.Rows.Count == 0)
            {
                //System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                //DataRow dr = dt.NewRow();
                //dr["Krema Yükleme Süresi (DK)"] = Convert.ToString("0", cultureTR);
                //dr["Yayıklama Süresi (DK)"] = Convert.ToString("0", cultureTR);
                //dr["Yıkama Süresi (DK)"] = Convert.ToString("0", cultureTR);
                //dr["Yağın Gramajlama Süresi (DK)"] = Convert.ToString("0", cultureTR);
                //dr["Toplam Geçen Süre (DK)"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add();
            }

            dtgProsesOzellikleri2.Columns["Krema Yükleme Süresi (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Krema Yükleme Süresi (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Yayıklama Süresi (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Yayıklama Süresi (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Yıkama Süresi (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Yıkama Süresi (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Yağın Gramajlama Süresi (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Yağın Gramajlama Süresi (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Toplam Geçen Süre (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Toplam Geçen Süre (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgProsesOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgProsesOzellikleri2.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgProsesOzellikleri2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgProsesOzellikleri2.Rows[0].Height = dtgProsesOzellikleri2.Height - dtgProsesOzellikleri2.ColumnHeadersHeight;
            dtgProsesOzellikleri2.AutoResizeColumns();
        }

        private void dtgHammamaddeMiktarVeOzellik()
        {
            string sql = "SELECT T1.\"U_MalzemeAdi\" as \"Malzeme Adı\", T1.\"U_KuruMadde\" as \"Kuru Madde (%)\", T1.\"U_YagOrani\" as \"Yağ Oranı (%)\", T1.\"U_PH\" as \"PH Değeri\", T1.\"U_SH\" as \"SH Değeri\",T1.\"U_HammaddePartiNo\" as \"Hammade Parti No\", T1.\"U_Miktar\" as \"Miktar\", T1.\"U_Birim\" as \"Birim\" FROM \"@AIF_TRYGPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TRYGPRSS_ANLZ3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgHammaddeMiktar.DataSource = dt;

            dtgHammaddeMiktar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgHammaddeMiktar.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgHammaddeMiktar.EnableHeadersVisualStyles = false;
            dtgHammaddeMiktar.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            if (dt.Rows.Count == 0)
            {
                sql = "select T0.ItemName as \"Malzeme Adı\",CardName as \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1 T0 WITH (NOLOCK) inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo + "')  and ISNULL(T1.\"QryGroup1\",'')<>'Y' AND T1.\"ItmsGrpCod\" IN('105','106','107') ";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                sda = new SqlDataAdapter(cmd);
                dttemp = new DataTable();
                sda.Fill(dttemp);

                foreach (DataRow dr1 in dttemp.Rows)
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dt.NewRow();
                    dr["Kuru Madde (%)"] = Convert.ToString("0", cultureTR);
                    dr["Yağ Oranı (%)"] = Convert.ToString("0", cultureTR);
                    dr["PH Değeri"] = Convert.ToString("0", cultureTR);
                    dr["SH Değeri"] = Convert.ToString("0", cultureTR);
                    dr["Miktar"] = Convert.ToString("0", cultureTR);
                    dr["Malzeme Adı"] = dr1["Malzeme Adı"].ToString();
                    dr["Hammade Parti No"] = dr1["Sarf Malzemesi Parti No"].ToString();
                    dr["Miktar"] = dr1["Miktar"].ToString();
                    dr["Birim"] = dr1["Birim"].ToString();

                    dt.Rows.Add(dr);
                }
            }

            dtHammaddeMiktarveOzellik = dt;

            dtgHammaddeMiktar.Columns["Kuru Madde (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgHammaddeMiktar.Columns["Kuru Madde (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgHammaddeMiktar.Columns["Yağ Oranı (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgHammaddeMiktar.Columns["Yağ Oranı (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgHammaddeMiktar.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgHammaddeMiktar.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgHammaddeMiktar.Columns["SH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgHammaddeMiktar.Columns["SH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgHammaddeMiktar.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgHammaddeMiktar.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgHammaddeMiktar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgHammaddeMiktar.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgHammaddeMiktar.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dtgSarfMalzemeKullanim()
        {
            string sql = "SELECT T1.\"U_MalzemeAdi\" as \"Malzeme Adı\",T1.\"U_MalMarkaTedarikci\" as \"Malzemenin Markası ve Tedarikçisi\",T1.\"U_PartiNo\" as \"Sarf Malzemesi Parti No\",Convert(float,T1.\"U_Miktar\") as \"Miktar\",T1.\"U_Birim\" as \"Birim\" FROM \"@AIF_TLMPRSS_ANALIZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TLMPRSS_ANALIZ5\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgSarfMalzeme.DataSource = dt;

            dtgSarfMalzeme.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgSarfMalzeme.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgSarfMalzeme.EnableHeadersVisualStyles = false;
            dtgSarfMalzeme.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            if (dt.Rows.Count == 0)
            {
                sql = "select T0.ItemName as \"Malzeme Adı\",CardName as \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1 T0 WITH (NOLOCK) inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo + "')  and T1.\"ItmsGrpCod\" NOT IN('105','106','107') "; //OLD and ISNULL(T1.\"QryGroup1\",'')='Y'";

                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                sda = new SqlDataAdapter(cmd);
                dttemp = new DataTable();
                sda.Fill(dttemp);

                foreach (DataRow dr1 in dttemp.Rows)
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dt.NewRow();
                    dr["Malzeme Adı"] = dr1["Malzeme Adı"].ToString();
                    dr["Malzemenin Markası ve Tedarikçisi"] = dr1["Malzemenin Markası ve Tedarikçisi"].ToString();
                    dr["Sarf Malzemesi Parti No"] = dr1["Sarf Malzemesi Parti No"].ToString();
                    dr["Miktar"] = Convert.ToDouble(dr1["Miktar"].ToString());
                    dr["Birim"] = dr1["Birim"].ToString();

                    dt.Rows.Add(dr);
                }

                //DataRow dr = dt.NewRow();
                //dr["Miktar"] = Convert.ToString("0", cultureTR);

                //dt.Rows.Add(dr);
            }

            dtSarfMalzemeKullanim = dt;

            dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dtgSarfMalzeme.Columns["Yağ Oranı (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgSarfMalzeme.Columns["Yağ Oranı (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dtgSarfMalzeme.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgSarfMalzeme.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dtgSarfMalzeme.Columns["SH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgSarfMalzeme.Columns["SH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgSarfMalzeme.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgSarfMalzeme.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgSarfMalzeme.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dtgMamulOzellikleri()
        {
            string sql = "SELECT \"U_HammaddeSarfMalzTop\" as \"Hammmade ve Sarf Malzeme Toplamı\", T1.\"U_UretilenHamur\" as \"Üretilen Hamur\",T1.\"U_UretilenUrunMik\" as \"Üretilen Ürün Miktarı (Adet)\", T1.\"U_UretilenUrunAdi\" as \"Üretilen Ürün Adı\", T1.\"U_KuruMadde\" as \"Kuru Madde(%)\", T1.\"U_YagOrani\" as \"Yağ Oranı(%)\", T1.\"U_YayikAltiSuyuOran\" as \"Yayık Altı Suyu Oranı (%)\", T1.\"U_YaginPH\" as \"Yağın PH Değeri\" FROM \"@AIF_TRYGPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TRYGPRSS_ANLZ5\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dtMamulOz = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtMamulOz);

            //Commit
            dtgMamulOz.DataSource = dtMamulOz;

            dtgMamulOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgMamulOz.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgMamulOz.EnableHeadersVisualStyles = false;
            dtgMamulOz.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            if (dtMamulOz.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtMamulOz.NewRow();
                dr["Hammmade ve Sarf Malzeme Toplamı"] = Convert.ToString("0", cultureTR);
                dr["Üretilen Ürün Miktarı (Adet)"] = Convert.ToString("0", cultureTR);
                dr["Üretilen Ürün Adı"] = "";
                dr["Kuru Madde(%)"] = Convert.ToString("0", cultureTR);
                dr["Yağ Oranı(%)"] = Convert.ToString("0", cultureTR);
                dr["Yayık Altı Suyu Oranı (%)"] = Convert.ToString("0", cultureTR);
                dr["Yağın PH Değeri"] = Convert.ToString("0", cultureTR);
                dr["Üretilen Hamur"] = Convert.ToString("0", cultureTR);

                dtMamulOz.Rows.Add(dr);
            }

            dtgMamulOz.Columns["Hammmade ve Sarf Malzeme Toplamı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Hammmade ve Sarf Malzeme Toplamı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOz.Columns["Üretilen Ürün Miktarı (Adet)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Üretilen Ürün Miktarı (Adet)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOz.Columns["Kuru Madde(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Kuru Madde(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOz.Columns["Yağ Oranı(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Yağ Oranı(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOz.Columns["Yayık Altı Suyu Oranı (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Yayık Altı Suyu Oranı (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOz.Columns["Yağın PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Yağın PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgMamulOz.Columns["Üretilen Hamur"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Üretilen Hamur"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgMamulOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgMamulOz.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgMamulOz.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            try
            {
                dtgMamulOz.Rows[0].Height = dtgMamulOz.Height - dtgMamulOz.ColumnHeadersHeight;
                dtgMamulOz.AutoResizeColumns();

                double dtHammaddeMiktar = Math.Round(Convert.ToDouble(dtHammaddeMiktarveOzellik.AsEnumerable().Sum(x => x.Field<decimal>("Miktar"))), Giris.OndalikMiktar);
                double dtSarfMalzemeKullanimMiktar = Math.Round(Convert.ToDouble(dtSarfMalzemeKullanim.AsEnumerable().Sum(x => x.Field<double>("Miktar"))), Giris.OndalikMiktar);
                var sonuc = dtHammaddeMiktar + dtSarfMalzemeKullanimMiktar;

                dtgMamulOz.Rows[0].Cells["Hammmade ve Sarf Malzeme Toplamı"].Value = sonuc.ToString();
            }
            catch (Exception)
            {
            } 
            dtgMamulOz.Columns["Üretilen Ürün Adı"].ReadOnly = true;
            dtgMamulOz.Columns["Hammmade ve Sarf Malzeme Toplamı"].ReadOnly = true;
            dtgMamulOz.Columns["Üretilen Ürün Miktarı (Adet)"].ReadOnly = true;
            dtgMamulOz.Columns["Kuru Madde(%)"].ReadOnly = true;
            dtgMamulOz.Columns["Yağ Oranı(%)"].ReadOnly = true;
            dtgMamulOz.Columns["Yayık Altı Suyu Oranı (%)"].ReadOnly = true;
            dtgMamulOz.Columns["Yağın PH Değeri"].ReadOnly = true;

            dtgMamulOz.Columns["Üretilen Hamur"].ReadOnly = true;


        }

        private void dtgProsesOzellikleri2ToplamGecenSure()
        {
            var KremaYukSureDk = dtgProsesOzellikleri2.Rows[0].Cells["Krema Yükleme Süresi (DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2.Rows[0].Cells["Krema Yükleme Süresi (DK)"].Value);
            var YayiklamaSuresiDk = dtgProsesOzellikleri2.Rows[0].Cells["Yayıklama Süresi (DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2.Rows[0].Cells["Yayıklama Süresi (DK)"].Value);
            var YikamaSuresiDk = dtgProsesOzellikleri2.Rows[0].Cells["Yıkama Süresi (DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2.Rows[0].Cells["Yıkama Süresi (DK)"].Value);
            var YaginGramajlamaSuresiDk = dtgProsesOzellikleri2.Rows[0].Cells["Yağın Gramajlama Süresi (DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2.Rows[0].Cells["Yağın Gramajlama Süresi (DK)"].Value);

            var sonuc = KremaYukSureDk + YayiklamaSuresiDk + YikamaSuresiDk + YaginGramajlamaSuresiDk;
            dtgProsesOzellikleri2.Rows[0].Cells["Toplam Geçen Süre (DK)"].Value = sonuc.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }

        private void dtgProsesOzellikleri1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                bool cvp = true;

                cvp = Kontrol(dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name, dtgProsesOzellikleri1, null);

                if (!cvp)
                {
                    return;
                }

                Tuple<DateTime, DateTime> resp = null;
                Helper help = new Helper();
                if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Krema Pastörizasyon Sıcaklığı (KKN1)" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yıkama Sayısı (Adet)")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1);
                    n.ShowDialog();

                    #region Süt Gönderim Saat Kontrolleri

                    //var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Süt Gönderim Başlangıç Saati"].Value.ToString();
                    //var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Süt Gönderim Bitiş Saati"].Value.ToString();

                    //if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                    //{
                    //    TimeSpan girisCikisFarki = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(baslangicSaati));
                    //    dtgProsesOzellikleri2_1.Rows[0].Cells["Süt Gönderim Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                    //}
                    //else
                    //{
                    //    dtgProsesOzellikleri2_1.Rows[0].Cells["Süt Gönderim Süresi (DK)"].Value = "0";
                    //}

                    //ProsesOzellikleri1Topla();

                    #endregion Süt Gönderim Saat Kontrolleri
                }
                else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yayığa Krema Yük.Baş." || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yayığa Krema Yük.Bit." || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yağ Oluşma Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yıkama Bitiş Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yağın Yayıktan ind.Saat" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yağın Gramajlama Bit." || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yağın Gramajlama Bas.")
                {
                    SaatTarihGirisi n = new SaatTarihGirisi(dtgProsesOzellikleri1);
                    n.ShowDialog();

                    #region Krema Yükleme başlangıç bitiş

                    if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yayığa Krema Yük.Baş." || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yayığa Krema Yük.Bit.")
                    {
                        var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Yayığa Krema Yük.Baş."].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Yayığa Krema Yük.Bit."].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            //TimeSpan Fark = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(baslangicSaati));
                            dtgProsesOzellikleri2.Rows[0].Cells["Krema Yükleme Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();

                            baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Yayığa Krema Yük.Bit."].Value.ToString();
                            bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Yağın Yayıktan ind.Saat"].Value.ToString();

                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2.Rows[0].Cells["Yayıklama Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2.Rows[0].Cells["Krema Yükleme Süresi (DK)"].Value = "0";
                        }
                    }

                    if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yıkama Bitiş Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yağ Oluşma Saati")
                    {
                        var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Yağ Oluşma Saati"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Yıkama Bitiş Saati"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            //TimeSpan Fark = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(baslangicSaati));
                            dtgProsesOzellikleri2.Rows[0].Cells["Yıkama Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2.Rows[0].Cells["Yıkama Süresi (DK)"].Value = "0";
                        }
                    }

                    if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yağın Yayıktan ind.Saat")
                    {
                        var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Yayığa Krema Yük.Bit."].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Yağın Yayıktan ind.Saat"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2.Rows[0].Cells["Yayıklama Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2.Rows[0].Cells["Yayıklama Süresi (DK)"].Value = "0";
                        }
                    }

                    if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yağın Gramajlama Bas." || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yağın Gramajlama Bit.")
                    {
                        var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Yağın Gramajlama Bas."].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Yağın Gramajlama Bit."].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            //TimeSpan Fark = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(baslangicSaati));
                            dtgProsesOzellikleri2.Rows[0].Cells["Yağın Gramajlama Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2.Rows[0].Cells["Yağın Gramajlama Süresi (DK)"].Value = "0";
                        }
                    }

                    dtgProsesOzellikleri2ToplamGecenSure();

                    #endregion Krema Yükleme başlangıç bitiş
                }
                else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Görevli Operatör Adı")
                {
                    if (istasyon.StartsWith("IST"))
                    {
                        //string sql = "Select \"empID\" as \"Kullanıcı Kodu\", (\"firstName\" + ' ' + \"lastName\") as 'Ad Soyad' from OHEM where \"Active\" = 'Y'";

                        string field = "U_" + istasyon;

                        DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                        string gunfield = "U_Gun" + dtTarih.Day;

                        string sql = "";

                        #region Günlük Personel Planlama 2 ekranı

                        //sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

                        //if (AtanmisIsler.Joker)
                        //{
                        //    sql += " UNION ALL ";

                        //    sql += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                        //}

                        #endregion Günlük Personel Planlama 2 ekranı

                        #region Günlük Personel Planlama 1 ekranı

                        //string sql = "Select \"U_PersonelNo\" as \"Personel No\",\"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"" + field + "\" = 'Y'";

                        #endregion Günlük Personel Planlama 1 ekranı

                        #region Günlük Personel Planlama 3 ekranı

                        //sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                        //sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and \"U_Durum\" = 'X'";

                        //if (AtanmisIsler.Joker)
                        //{
                        //    sql += " UNION ALL ";

                        //    sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                        //    sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') and \"U_Durum\" = 'X'";
                        //}

                        #endregion Günlük Personel Planlama 3 ekranı

                        #region Günlük Personel Planlama 4 ekranı
                        sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

                        if (AtanmisIsler.Joker)
                        {
                            sql += " UNION ALL ";

                            sql += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0  WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                        }
                        #endregion Günlük Personel Planlama 4 ekranı

                        SelectList selectList = new SelectList(sql, dtgProsesOzellikleri1, 3, 4, _autoresizerow: false);
                        selectList.ShowDialog();

                        //dtgProsesOzellikleri1.AutoResizeRows();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtgHammaddeMiktar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgHammaddeMiktar.Columns[e.ColumnIndex].Name == "Krema Pastörizasyon Sıcaklığı (KKN1)" || dtgHammaddeMiktar.Columns[e.ColumnIndex].Name == "Kuru Madde (%)" || dtgHammaddeMiktar.Columns[e.ColumnIndex].Name == "Yağ Oranı (%)" || dtgHammaddeMiktar.Columns[e.ColumnIndex].Name == "Yıkama Sayısı (Adet)" || dtgHammaddeMiktar.Columns[e.ColumnIndex].Name == "SH Değeri" || dtgHammaddeMiktar.Columns[e.ColumnIndex].Name == "PH Değeri")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgHammaddeMiktar);
                n.ShowDialog();

                //if (dtgHammaddeMiktar.Columns[e.ColumnIndex].DisplayIndex < dtgHammaddeMiktar.Columns.Count)
                //{
                //    dtgHammaddeMiktar.CurrentCell = dtgHammaddeMiktar.Rows[e.RowIndex].Cells[e.ColumnIndex + 1];
                //    //dtgHammaddeMiktar.BeginEdit(true);

                //    dtgHammaddeMiktar.Rows[e.RowIndex].Cells[e.ColumnIndex].Selected = false;
                //    dtgHammaddeMiktar.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Selected = true;
                //    var arg = new DataGridViewCellEventArgs(dtgHammaddeMiktar.Rows.Count, dtgHammaddeMiktar.CurrentCell.ColumnIndex);
                //    dtgHammaddeMiktar_CellClick(dtgHammaddeMiktar, arg);
                //}
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                TereyagProsesTakipAnaliz nesne = new TereyagProsesTakipAnaliz();
                TereyagProssesOzellikleri1 tereyagProssesOzellikleri1 = new TereyagProssesOzellikleri1();
                List<TereyagProssesOzellikleri1> tereyagProssesOzellikleri1s = new List<TereyagProssesOzellikleri1>();
                TereyagProssesOzellikleri2 tereyagProssesOzellikleri2 = new TereyagProssesOzellikleri2();
                List<TereyagProssesOzellikleri2> tereyagProssesOzellikleri2s = new List<TereyagProssesOzellikleri2>();
                TereyagHammaddeMiktarVeOzellik tereyagHammaddeMiktarVeOzellik = new TereyagHammaddeMiktarVeOzellik();
                List<TereyagHammaddeMiktarVeOzellik> tereyagHammaddeMiktarVeOzelliks = new List<TereyagHammaddeMiktarVeOzellik>();
                TereyagSarfMalzemeKullanim tereyagSarfMalzemeKullanim = new TereyagSarfMalzemeKullanim();
                List<TereyagSarfMalzemeKullanim> tereyagSarfMalzemeKullanims = new List<TereyagSarfMalzemeKullanim>();
                TereyagMamulOzellikleri tereyagMamulOzellikleri = new TereyagMamulOzellikleri();
                List<TereyagMamulOzellikleri> tereyagMamulOzellikleris = new List<TereyagMamulOzellikleri>();

                nesne.PartiNo = txtPartyNo.Text;
                nesne.Aciklama = txtAciklama.Text;
                nesne.KalemKodu = "";
                nesne.KalemTanimi = txtUrunTanimi.Text;
                nesne.UretimTarihi = tarih1;

                foreach (DataGridViewRow dr in dtgProsesOzellikleri1.Rows)
                {
                    tereyagProssesOzellikleri1 = new TereyagProssesOzellikleri1();
                    tereyagProssesOzellikleri1.PartiNo = dr.Cells["Parti No"].Value == DBNull.Value ? "" : dr.Cells["Parti No"].Value.ToString();
                    tereyagProssesOzellikleri1.YagTuru = dr.Cells["Yağ türü"].Value == DBNull.Value ? "" : dr.Cells["Yağ türü"].Value.ToString();
                    tereyagProssesOzellikleri1.GorevliOperator = dr.Cells["Görevli Operatör"].Value == DBNull.Value ? "" : dr.Cells["Görevli Operatör"].Value.ToString();
                    tereyagProssesOzellikleri1.GorevliOperatorAdi = dr.Cells["Görevli Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Görevli Operatör Adı"].Value.ToString();
                    tereyagProssesOzellikleri1.KremaPastorizasyonSicakligi = dr.Cells["Krema Pastörizasyon Sıcaklığı (KKN1)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Krema Pastörizasyon Sıcaklığı (KKN1)"].Value);

                    tereyagProssesOzellikleri1.YayigaKremaYuklemeBaslamaSaati = dr.Cells["Yayığa Krema Yük.Baş."].Value == DBNull.Value ? "" : dr.Cells["Yayığa Krema Yük.Baş."].Value.ToString();
                    tereyagProssesOzellikleri1.YayigaKremaYuklemeBitisSaati = dr.Cells["Yayığa Krema Yük.Bit."].Value == DBNull.Value ? "" : dr.Cells["Yayığa Krema Yük.Bit."].Value.ToString();

                    tereyagProssesOzellikleri1.YagOlusmaSaati = dr.Cells["Yağ Oluşma Saati"].Value == DBNull.Value ? "" : dr.Cells["Yağ Oluşma Saati"].Value.ToString();
                    tereyagProssesOzellikleri1.YikamaSayisi = dr.Cells["Yıkama Sayısı (Adet)"].Value == DBNull.Value ? 0 : Convert.ToInt32(dr.Cells["Yıkama Sayısı (Adet)"].Value);

                    tereyagProssesOzellikleri1.YikamaBitisSaati = dr.Cells["Yıkama Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Yıkama Bitiş Saati"].Value.ToString();
                    tereyagProssesOzellikleri1.YaginYayiktanIndirilmeSaati = dr.Cells["Yağın Yayıktan ind.Saat"].Value == DBNull.Value ? "" : dr.Cells["Yağın Yayıktan ind.Saat"].Value.ToString();
                    tereyagProssesOzellikleri1.YaginGramajBaslamaSaati = dr.Cells["Yağın Gramajlama Bas."].Value == DBNull.Value ? "" : dr.Cells["Yağın Gramajlama Bas."].Value.ToString();
                    tereyagProssesOzellikleri1.YaginGramajlamaBitSaati = dr.Cells["Yağın Gramajlama Bit."].Value == DBNull.Value ? "" : dr.Cells["Yağın Gramajlama Bit."].Value.ToString();

                    tereyagProssesOzellikleri1s.Add(tereyagProssesOzellikleri1);
                }

                nesne.tereyagProssesOzellikleri1_Detay = tereyagProssesOzellikleri1s.ToArray();

                foreach (DataGridViewRow dr in dtgProsesOzellikleri2.Rows)
                {
                    tereyagProssesOzellikleri2 = new TereyagProssesOzellikleri2();

                    tereyagProssesOzellikleri2.KremaYuklemeSuresiDk = dr.Cells["Krema Yükleme Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Krema Yükleme Süresi (DK)"].Value);

                    tereyagProssesOzellikleri2.YayiklamaSuresiDk = dr.Cells["Yayıklama Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yayıklama Süresi (DK)"].Value);

                    tereyagProssesOzellikleri2.YikamaSuresiDk = dr.Cells["Yıkama Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yıkama Süresi (DK)"].Value);

                    tereyagProssesOzellikleri2.YaginGramajlamaSuresiDk = dr.Cells["Yağın Gramajlama Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağın Gramajlama Süresi (DK)"].Value);

                    tereyagProssesOzellikleri2.ToplamGecenSureDk = dr.Cells["Toplam Geçen Süre (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Geçen Süre (DK)"].Value);

                    tereyagProssesOzellikleri2s.Add(tereyagProssesOzellikleri2);
                }

                nesne.tereyagProssesOzellikleri2_Detay = tereyagProssesOzellikleri2s.ToArray();

                foreach (DataGridViewRow dr in dtgHammaddeMiktar.Rows)
                {
                    tereyagHammaddeMiktarVeOzellik = new TereyagHammaddeMiktarVeOzellik();
                    tereyagHammaddeMiktarVeOzellik.MalzemeAdi = dr.Cells["Malzeme Adı"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Adı"].Value.ToString();
                    tereyagHammaddeMiktarVeOzellik.KuruMadde = dr.Cells["Kuru Madde (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde (%)"].Value);
                    tereyagHammaddeMiktarVeOzellik.YagOrani = dr.Cells["Yağ Oranı (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ Oranı (%)"].Value);
                    tereyagHammaddeMiktarVeOzellik.PH = dr.Cells["PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH Değeri"].Value);
                    tereyagHammaddeMiktarVeOzellik.SH = dr.Cells["SH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH Değeri"].Value);
                    tereyagHammaddeMiktarVeOzellik.HammaddePartiNo = dr.Cells["Hammade Parti No"].Value == DBNull.Value ? "" : dr.Cells["Hammade Parti No"].Value.ToString();
                    tereyagHammaddeMiktarVeOzellik.Miktar = dr.Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Miktar"].Value);
                    tereyagHammaddeMiktarVeOzellik.Birim = dr.Cells["Birim"].Value == DBNull.Value ? "" : dr.Cells["Birim"].Value.ToString();

                    tereyagHammaddeMiktarVeOzelliks.Add(tereyagHammaddeMiktarVeOzellik);
                }

                nesne.tereyagHammaddeMiktarVeOzellik_Detay = tereyagHammaddeMiktarVeOzelliks.ToArray();

                foreach (DataGridViewRow dr in dtgSarfMalzeme.Rows)
                {
                    tereyagSarfMalzemeKullanim = new TereyagSarfMalzemeKullanim();
                    tereyagSarfMalzemeKullanim.MalzemeAdi = dr.Cells["Malzeme Adı"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Adı"].Value.ToString();
                    tereyagSarfMalzemeKullanim.SarfMalzemePartiNo = dr.Cells["Sarf Malzemesi Parti No"].Value == DBNull.Value ? "" : dr.Cells["Sarf Malzemesi Parti No"].Value.ToString();
                    tereyagSarfMalzemeKullanim.MalzemeMarkaTedarikcisi = dr.Cells["Malzemenin Markası ve Tedarikçisi"].Value == DBNull.Value ? "" : dr.Cells["Malzemenin Markası ve Tedarikçisi"].Value.ToString();
                    tereyagSarfMalzemeKullanim.Miktar = dr.Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Miktar"].Value);
                    tereyagSarfMalzemeKullanim.Birim = dr.Cells["Birim"].Value == DBNull.Value ? "" : dr.Cells["Birim"].Value.ToString();

                    tereyagSarfMalzemeKullanims.Add(tereyagSarfMalzemeKullanim);
                }

                nesne.tereyagSarfMalzemeKullanim_Detay = tereyagSarfMalzemeKullanims.ToArray();

                foreach (DataGridViewRow dr in dtgMamulOz.Rows)
                {
                    tereyagMamulOzellikleri = new TereyagMamulOzellikleri();
                    tereyagMamulOzellikleri.HammaddeVeSarfMalzemeToplami = dr.Cells["Hammmade ve Sarf Malzeme Toplamı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Hammmade ve Sarf Malzeme Toplamı"].Value);
                    tereyagMamulOzellikleri.UretilenUrunMiktariKg = dr.Cells["Üretilen Ürün Miktarı (Adet)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretilen Ürün Miktarı (Adet)"].Value);
                    tereyagMamulOzellikleri.UretilenUrunAdi = dr.Cells["Üretilen Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Üretilen Ürün Adı"].Value.ToString();
                    tereyagMamulOzellikleri.KuruMadde = dr.Cells["Kuru Madde(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde(%)"].Value);
                    tereyagMamulOzellikleri.YagOrani = dr.Cells["Yağ Oranı(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ Oranı(%)"].Value);
                    tereyagMamulOzellikleri.YayikAltiSuyuYagOrani = dr.Cells["Yayık Altı Suyu Oranı (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yayık Altı Suyu Oranı (%)"].Value);
                    tereyagMamulOzellikleri.YaginPHDegeri = dr.Cells["Yağın PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağın PH Değeri"].Value);
                    tereyagMamulOzellikleri.UretilenHamur = dr.Cells["Üretilen Hamur"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretilen hamur"].Value);

                    tereyagMamulOzellikleris.Add(tereyagMamulOzellikleri);
                }

                nesne.tereyagMamulOzellikleri_Detay = tereyagMamulOzellikleris.ToArray();

                var resp = client.AddOrUpdateTereyagProsesAnalizTakip(nesne, Giris.dbName, Giris.mKodValue);

                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                if (resp.Value == 0)
                {
                    btnOzetEkraniDon.PerformClick();
                }
            }
            catch (Exception)
            {
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();
        }

        private void dtgProsesOzellikleri2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                string sql = "SELECT T1.\"U_KremaYuklemeSuresiDk\" as \"Krema Yükleme Süresi (DK)\", T1.\"U_YayiklamaSuresiDk\" as \"Yayıklama Süresi (DK)\", T1.\"U_YikamaSuresiDk\" as \"Yıkama Süresi (DK)\", T1.\"U_YaginGramajlamaSuresiDk\" as \"Yağın Gramajlama Süresi (DK)\", T1.\"U_ToplamGecenSureDk\" as \"Toplam Geçen Süre (DK)\" FROM \"@AIF_TRYGPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TRYGPRSS_ANLZ2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

                if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Krema Yükleme Süresi (DK)" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Yayıklama Süresi (DK)" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Yıkama Süresi (DK)" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Yağın Gramajlama Süresi (DK)")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri2);
                    n.ShowDialog();
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtgMamulOz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgMamulOz.Columns[e.ColumnIndex].Name == "Üretilen Ürün Miktarı (Adet)" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Kuru Madde(%)" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Yağ Oranı(%)" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Yağın PH Değeri" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Yayık Altı Suyu Oranı (%)")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOz);
                    n.ShowDialog();

                    #region üretilen hamur
                    if (dtgMamulOz.Columns[e.ColumnIndex].Name == "Üretilen Ürün Miktarı (Adet)")
                    {
                        string sqlBrut = "Select \"U_BrutAgirlik\" from \"OITM\" WITH (NOLOCK) where \"ItemCode\" = '" + SelectList.kalemKodu + "' ";
                        cmd = new SqlCommand(sqlBrut, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt_Brut = new DataTable();
                        sda.Fill(dt_Brut);

                        Connection.sql.Close();
                        if (dt_Brut.Rows[0][0] == DBNull.Value)
                        {
                            dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Hamur"].Value = 0.ToString("N" + Giris.OndalikMiktar);

                        }
                        if (dt_Brut.Rows.Count > 0)
                        {
                            double brut = Math.Round(Convert.ToDouble(dt_Brut.AsEnumerable().Sum(x => x.Field<decimal>("U_BrutAgirlik"))), Giris.OndalikMiktar);
                            double miktar = Math.Round(Convert.ToDouble(dtMamulOz.AsEnumerable().Sum(x => x.Field<decimal>("Üretilen Ürün Miktarı (Adet)"))), Giris.OndalikMiktar);


                            //double brut = parseNumber.parservalues<double>(dt_Brut.Rows[0][0].ToString());
                            //double miktar = parseNumber.parservalues<double>(dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Ürün Miktarı (Adet)"].Value.ToString());

                            double sonuc2 = brut * miktar;

                            dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Hamur"].Value = sonuc2;
                        }
                        else
                        {
                            dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Hamur"].Value = 0.ToString("N" + Giris.OndalikMiktar);

                        }
                    }
                    #endregion
                }
                else if (dtgMamulOz.Columns[e.ColumnIndex].Name == "Üretilen Ürün Adı")
                {
                    string sql_AnalizParam = "Select \"U_Deger1\",\"U_Deger2\" from \"@AIF_GNLKANLZPRM\" WITH (NOLOCK) where \"U_Kod\" ='9'";
                    cmd = new SqlCommand(sql_AnalizParam, Connection.sql);

                    if (Connection.sql.State != ConnectionState.Open)
                        Connection.sql.Open();

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt_Sorgu = new DataTable();
                    sda.Fill(dt_Sorgu);

                    //dtgSecim.DataSource = dt;
                    //dtSecim = dt;

                    Connection.sql.Close();

                    if (dt_Sorgu.Rows.Count > 0)
                    {
                        string sql1 = "Select TOP 1 '' as \"Kalem Kodu\",'' as \"Kalem Adı\" FROM OITM WITH (NOLOCK) where \"U_ItemGroup2\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][1].ToString() + "' ";
                        sql1 += " UNION ALL ";
                        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM WITH (NOLOCK) where \"U_ItemGroup2\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][1].ToString() + "'";

                        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, e.ColumnIndex, _autoresizerow: false);
                        selectList.ShowDialog();

                        #region üretilen hamur 
                        string sqlBrut = "Select \"U_BrutAgirlik\" from \"OITM\" WITH (NOLOCK) where \"ItemCode\" = '" + SelectList.kalemKodu + "' ";
                        cmd = new SqlCommand(sqlBrut, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        sda = new SqlDataAdapter(cmd);
                        DataTable dt_Brut = new DataTable();
                        sda.Fill(dt_Brut);

                        Connection.sql.Close();

                        if (dt_Brut.Rows[0][0] == DBNull.Value)
                        {
                            dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Hamur"].Value = 0.ToString("N" + Giris.OndalikMiktar);

                        }

                        if (dt_Brut.Rows.Count > 0)
                        {
                            double brut = Math.Round(Convert.ToDouble(dt_Brut.AsEnumerable().Sum(x => x.Field<decimal>("U_BrutAgirlik"))), Giris.OndalikMiktar);
                            double miktar = Math.Round(Convert.ToDouble(dtMamulOz.AsEnumerable().Sum(x => x.Field<decimal>("Üretilen Ürün Miktarı (Adet)"))), Giris.OndalikMiktar);


                            //double brut = parseNumber.parservalues<double>(dt_Brut.Rows[0][0].ToString());
                            //double miktar = parseNumber.parservalues<double>(dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Ürün Miktarı (Adet)"].Value.ToString());

                            double sonuc2 = brut * miktar;

                            dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Hamur"].Value = sonuc2;
                        }
                        else
                        {
                            dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Hamur"].Value = 0.ToString("N" + Giris.OndalikMiktar);
                        }
                        #endregion
                    }
                    else
                    {
                        CustomMsgBtn.Show("Üretilen Ürünler için parametre tablosu doldurulmamıştır.", "UYARI", "TAMAM");
                    }

                    #region eski listeleme sorguları 01.06.2022 tarihinde değiştirildi
                    //    string sql1 = "Select TOP 1 '' as \"Kalem Kodu\",'' as \"Kalem Adı\" FROM OITM ";
                    //    sql1 += " UNION ALL ";
                    //    if (urunKodu == "YRM-60001")
                    //    {
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-16000'";
                    //        sql1 += " UNION ALL ";
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-16001'";
                    //        sql1 += " UNION ALL ";
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-16002'";
                    //        sql1 += " UNION ALL ";
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-16003'";
                    //        sql1 += " UNION ALL ";
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-16005'";
                    //        sql1 += " UNION ALL ";
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-16006'";
                    //        sql1 += " UNION ALL ";
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-26000'";

                    //        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, e.ColumnIndex, _autoresizerow: false);
                    //        selectList.ShowDialog();
                    //    }
                    //    else if (urunKodu == "YRM-60002")
                    //    {
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-16004'";
                    //        sql1 += " UNION ALL ";
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-16007'";
                    //        sql1 += " UNION ALL ";
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-16008'";
                    //        sql1 += " UNION ALL ";
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-16009'";

                    //        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, e.ColumnIndex, _autoresizerow: false);
                    //        selectList.ShowDialog();
                    //    }
                    //    else if (urunKodu == "YRM-60003")
                    //    {
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-26001'";
                    //        sql1 += " UNION ALL ";
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-26002'";
                    //        sql1 += " UNION ALL ";
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-26003'";
                    //        sql1 += " UNION ALL ";
                    //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-26004'";

                    //        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, e.ColumnIndex, _autoresizerow: false);
                    //        selectList.ShowDialog();
                    //    } 
                    #endregion
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
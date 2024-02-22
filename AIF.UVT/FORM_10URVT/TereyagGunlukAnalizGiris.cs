using AIF.UVT.DatabaseLayer;
using AIF.UVT.UVTService;
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

namespace AIF.UVT.FORM_10URVT
{
    public partial class TereyagGunlukAnalizGiris : Form
    {
        //font start.tasarım
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //font end
        private string tarih1 = "";

        private string UretimFisNo = "";
        private string partiNo = "";
        private string istasyon = "";
        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private int row = 0;
        private SqlCommand cmd = null; 
        private DataTable dtMamulOzellikleri = new DataTable();
       
        public TereyagGunlukAnalizGiris(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, int _width, int _height, string _tarih1)
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

            initialFontSize = txtUretimTarihi.Font.Size;
            txtUretimTarihi.Resize += Form_Resize;

            initialFontSize = txtPaketlemeTarihi.Font.Size;
            txtPaketlemeTarihi.Resize += Form_Resize;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = button3.Font.Size;
            button3.Resize += Form_Resize;

            initialFontSize = btnAciklama.Font.Size;
            btnAciklama.Resize += Form_Resize;

            initialFontSize = btnOnayla.Font.Size;
            btnOnayla.Resize += Form_Resize;

            initialFontSize = btnOzetEkranaDon.Font.Size;
            btnOzetEkranaDon.Resize += Form_Resize;
            //font end

            UretimFisNo = _UretimFisNo;
            partiNo = _PartiNo;
            UrunTanimi = _UrunTanimi;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;

            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
            txtPaketlemeTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
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

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimTarihi.Font.Style);

            txtPaketlemeTarihi.Font = new Font(txtPaketlemeTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtPaketlemeTarihi.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              button1.Font.Style);

            button3.Font = new Font(button3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button3.Font.Style);

            btnAciklama.Font = new Font(btnAciklama.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnAciklama.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOnayla.Font.Style);

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);
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
                    if (_kontroledilmesigerekenKolon == "Üretilen Ürünler" && dtg.CurrentCell.RowIndex > 0)
                    {
                        val = dtg.Rows[dtg.CurrentCell.RowIndex - 1].Cells[temelkolon].Value.ToString();
                    }
                    else if (_kontroledilmesigerekenKolon == "Üretilen Ürünler" && dtg.CurrentCell.RowIndex == 0)
                    {
                        val = "KontrolYok";
                    }
                    else if (_kontroledilmesigerekenKolon == "Ürün Çeşidi" && dtg.CurrentCell.RowIndex > 0)
                    {
                        val = dtg.Rows[dtg.CurrentCell.RowIndex - 1].Cells[temelkolon].Value.ToString();
                    }
                    else if (_kontroledilmesigerekenKolon == "Ürün Çeşidi" && dtg.CurrentCell.RowIndex == 0)
                    {
                        val = "KontrolYok";
                    }
                    else
                    {
                        val = dtg.Rows[dtg.CurrentCell.RowIndex].Cells[temelkolon].Value.ToString();
                    }
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
                            if (_kontroledilmesigerekenKolon == "Üretilen Ürünler" && dtg.CurrentCell.RowIndex > 0)
                            {
                                val2 = Convert.ToDouble(dtg.Rows[dtg.CurrentCell.RowIndex - 1].Cells[temelkolon].Value);
                            }
                            else if (_kontroledilmesigerekenKolon == "Üretilen Ürünler" && dtg.CurrentCell.RowIndex == 0)
                            {
                                val2 = -1;
                            }
                            else if (_kontroledilmesigerekenKolon == "Ürün Çeşidi" && dtg.CurrentCell.RowIndex > 0)
                            {
                                val2 = Convert.ToDouble(dtg.Rows[dtg.CurrentCell.RowIndex - 1].Cells[temelkolon].Value);
                            }
                            else if (_kontroledilmesigerekenKolon == "Ürün Çeşidi" && dtg.CurrentCell.RowIndex == 0)
                            {
                                val2 = -1;
                            }
                            else
                            {
                                val2 = Convert.ToDouble(dtg.Rows[dtg.CurrentCell.RowIndex].Cells[temelkolon].Value);
                            }
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

        private void TereyagGunlukAnalizGiris_Load(object sender, EventArgs e)
        {
            //DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));

            //txtUretimTarihi.Text = dtTarih.ToString("dd/MM/yyyy");
            //textBox2.Text = dtTarih.ToString("dd/MM/yyyy");

            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_TRYGPRSS2_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
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

            dtgMamulOzellikleri();
            dtgDinlenmeVePaketleme(); 

            DataGridViewColumn dataGridViewColumn = dtgMamulOz.Columns["Kuru Madde(%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["Yağ Oranı (%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["PH Değeri"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["SH Değeri"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["Tuz Oranı(%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;
        }

        private void dtgMamulOzellikleri()
        {
            try
            {
                #region old
                //string sql = "SELECT T1.\"U_UretilenUrunler\" as \"Üretilen Ürünler\",T1.\"U_PaketlemeOncesiSicakik\" as \"Paketleme Öncesi Ürün Sıcaklığı\", T1.\"U_UretimMiktari\" as \"Paketlenen Ürün Miktarı (Adet)\", T1.\"U_FireUrunMiktari\" as \"Fire Ürün Miktarı (Adet)\", T1.\"U_NumuneUrunMiktari\" as \"Numune Ürün Miktarı (Adet)\", T1.\"U_DepoyaGirenUrunMik\" as \"Depoya Giren Ürün Miktarı\", T1.\"U_KuruMadde\" as \"Kuru Madde(%)\", T1.\"U_YagOrani\" as \"Yağ Oranı (%)\", T1.\"U_PH\" as \"PH Değeri\", T1.\"U_SH\" as \"SH Değeri\", T1.\"U_TuzOrani\" as \"Tuz Oranı(%)\" FROM \"@AIF_TRYGPRSS2_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TRYGPRSS2_ANLZ1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

                string sql = "SELECT T1.\"U_UretilenUrunler\" as \"Üretilen Ürünler\",T1.\"U_PaketlemeOncesiSicakik\" as \"Paketleme Öncesi Ürün Sıcaklığı\", T1.\"U_UretimMiktari\" as \"Paketlenen Ürün Miktarı (Adet)\", T1.\"U_FireUrunMiktari\" as \"Fire Ürün Miktarı (Adet)\", T1.\"U_NumuneUrunMiktari\" as \"Numune Ürün Miktarı (Adet)\", T1.\"U_DepoyaGirenUrunMik\" as \"Depoya Giren Ürün Miktarı\", T1.\"U_KuruMadde\" as \"Kuru Madde(%)\", T1.\"U_YagOrani\" as \"Yağ Oranı (%)\", T1.\"U_PH\" as \"PH Değeri\", T1.\"U_SH\" as \"SH Değeri\", T1.\"U_TuzOrani\" as \"Tuz Oranı(%)\" FROM \"@AIF_TRYGGUN_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TRYGGUN_ANLZ1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_UretimTarihi\" = '" + tarih1 + "'";
                #endregion
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);
                dtMamulOzellikleri = dt;

                if (dt.Rows.Count == 0)
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");
                    DataRow dr = dtMamulOzellikleri.NewRow();
                    dr["Üretilen Ürünler"] = "";
                    dr["Paketleme Öncesi Ürün Sıcaklığı"] = 0;
                    dr["Paketlenen Ürün Miktarı (Adet)"] = 0;
                    dr["Fire Ürün Miktarı (Adet)"] = 0;
                    dr["Numune Ürün Miktarı (Adet)"] = 0;
                    dr["Depoya Giren Ürün Miktarı"] = 0;
                    dr["Kuru Madde(%)"] = 0;
                    dr["Yağ Oranı (%)"] = 0;
                    dr["PH Değeri"] = 0;
                    dr["SH Değeri"] = 0;
                    dr["Tuz Oranı(%)"] = 0;

                    dtMamulOzellikleri.Rows.Add(dr);
                }

                //Commit
                dtgMamulOz.DataSource = dt;

                dtgMamulOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtgMamulOz.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                dtgMamulOz.EnableHeadersVisualStyles = false;
                dtgMamulOz.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

                //if (dt.Rows.Count == 0)
                //{
                //    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                //    DataRow dr = dt.NewRow();
                //    dr["Parti No"] = partiNo;
                //    dr["Hamur Türü"] = txtUrunTanimi.Text;
                //    dr["Karışım Past. Sıcakligi"] = Convert.ToString("0", cultureTR);
                //    //dr["Hammadde Yükleme Baş. Saat"] = Convert.ToString("0", cultureTR);
                //    //dr["Hammadde Yükleme Bit. Saat"] = Convert.ToString("0", cultureTR);
                //    //dr["Pişirme Mak. Indirilme Saati"] = Convert.ToString("0", cultureTR);
                //    //dr["Hamurun Gramajlama Bitiş Saati"] = Convert.ToString("0", cultureTR);

                //    dt.Rows.Add(dr);
                //}

                dtgMamulOz.Columns["Paketleme Öncesi Ürün Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgMamulOz.Columns["Paketleme Öncesi Ürün Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgMamulOz.Columns["Paketlenen Ürün Miktarı (Adet)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgMamulOz.Columns["Paketlenen Ürün Miktarı (Adet)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgMamulOz.Columns["Numune Ürün Miktarı (Adet)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgMamulOz.Columns["Numune Ürün Miktarı (Adet)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgMamulOz.Columns["Fire Ürün Miktarı (Adet)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgMamulOz.Columns["Fire Ürün Miktarı (Adet)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgMamulOz.Columns["Depoya Giren Ürün Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgMamulOz.Columns["Depoya Giren Ürün Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgMamulOz.Columns["Kuru Madde(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgMamulOz.Columns["Kuru Madde(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgMamulOz.Columns["Yağ Oranı (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgMamulOz.Columns["Yağ Oranı (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgMamulOz.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgMamulOz.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgMamulOz.Columns["SH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgMamulOz.Columns["SH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgMamulOz.Columns["Tuz Oranı(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgMamulOz.Columns["Tuz Oranı(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgMamulOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtMamulOz.AutoResizeRows();
                //dtgProsesOzellikleri1.AutoResizeColumns();

                //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

                foreach (DataGridViewColumn column in dtgMamulOz.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }


                #region Kontrol listesi oluşturma 

                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Üretilen Ürünler",
                    kontroledilmesigerekenKolon = "Depoya Giren Ürün Miktarı"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Paketleme Öncesi Ürün Sıcaklığı",
                    kontroledilmesigerekenKolon = "Üretilen Ürünler"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Paketlenen Ürün Miktarı (Adet)",
                    kontroledilmesigerekenKolon = "Paketleme Öncesi Ürün Sıcaklığı"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Fire Ürün Miktarı (Adet)",
                    kontroledilmesigerekenKolon = "Paketlenen Ürün Miktarı (Adet)"
                });

                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Numune Ürün Miktarı (Adet)",
                    kontroledilmesigerekenKolon = "Fire Ürün Miktarı (Adet)"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Depoya Giren Ürün Miktarı",
                    kontroledilmesigerekenKolon = "Numune Ürün Miktarı (Adet)"
                });

                #endregion
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");

            }
        }

        private void dtgDinlenmeVePaketleme()
        {
            try
            {
                DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));

                string sql = "SELECT T1.\"U_AlanAdi\" as \"Alan Adı\",T1.\"U_SifirSekizSicaklik\" as \"08:00 Sıcaklık\", T1.\"U_SifirSekizNem\" as \"08:00 Nem\", T1.\"U_OnikiSicaklik\" as \"12:00 Sıcaklık\", T1.\"U_OnikiNem\" as \"12:00 Nem\", T1.\"U_OnBesSicaklik\" as \"15:00 Sıcaklık\", T1.\"U_OnBesNem\" as \"15:00 Nem\",T1.\"U_OnSekizSicaklik\" as \"18:00 Sıcaklık\", T1.\"U_OnSekizNem\" as \"18:00 Nem\" FROM \"@AIF_TRYGGUN_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TRYGGUN_ANLZ2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_UretimTarihi\" = '" + tarih1 + "'"; //dtTarih.ToString("yyyyMMdd") 
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                //Commit
                dtgDinlendirmeVePaket.DataSource = dt;

                dtgDinlendirmeVePaket.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtgDinlendirmeVePaket.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                dtgDinlendirmeVePaket.EnableHeadersVisualStyles = false;
                dtgDinlendirmeVePaket.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

                if (dt.Rows.Count == 0)
                {
                    //System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dt.NewRow();
                    dr["Alan Adı"] = "Dinlendirme Odası 1";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["Alan Adı"] = "Dinlendirme Odası 2";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["Alan Adı"] = "Paketleme Odası";
                    dt.Rows.Add(dr);

                    dr = dt.NewRow();
                    dr["Alan Adı"] = "Üretim Alanı";
                    dt.Rows.Add(dr);
                }

                dtgDinlendirmeVePaket.Columns["08:00 Sıcaklık"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgDinlendirmeVePaket.Columns["08:00 Sıcaklık"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                dtgDinlendirmeVePaket.Columns["08:00 Nem"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgDinlendirmeVePaket.Columns["08:00 Nem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                dtgDinlendirmeVePaket.Columns["12:00 Sıcaklık"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgDinlendirmeVePaket.Columns["12:00 Sıcaklık"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                dtgDinlendirmeVePaket.Columns["12:00 Nem"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgDinlendirmeVePaket.Columns["12:00 Nem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                dtgDinlendirmeVePaket.Columns["15:00 Sıcaklık"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgDinlendirmeVePaket.Columns["15:00 Sıcaklık"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                dtgDinlendirmeVePaket.Columns["15:00 Nem"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgDinlendirmeVePaket.Columns["15:00 Nem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                dtgDinlendirmeVePaket.Columns["18:00 Sıcaklık"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgDinlendirmeVePaket.Columns["18:00 Sıcaklık"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                dtgDinlendirmeVePaket.Columns["18:00 Nem"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgDinlendirmeVePaket.Columns["18:00 Nem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                dtgDinlendirmeVePaket.Columns["Alan Adı"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                dtgDinlendirmeVePaket.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgDinlendirmeVePaket.AutoResizeRows();
                //dtgDinlendirmeVePaket.AutoResizeColumns();

                //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

                foreach (DataGridViewColumn column in dtgDinlendirmeVePaket.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }


                #region Kontrol listesi oluşturma 

                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "08:00 Nem",
                    kontroledilmesigerekenKolon = "08:00 Sıcaklık"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "12:00 Sıcaklık",
                    kontroledilmesigerekenKolon = "08:00 Nem"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "12:00 Nem",
                    kontroledilmesigerekenKolon = "12:00 Sıcaklık"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "15:00 Sıcaklık",
                    kontroledilmesigerekenKolon = "12:00 Nem"
                });

                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "15:00 Nem",
                    kontroledilmesigerekenKolon = "15:00 Sıcaklık"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "18:00 Sıcaklık",
                    kontroledilmesigerekenKolon = "15:00 Nem"
                });


                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "18:00 Nem",
                    kontroledilmesigerekenKolon = "18:00 Sıcaklık"
                });

                #endregion
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }

        }

        private void dtgMamulOz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool cvp = true;

                cvp = Kontrol(dtgMamulOz.Columns[e.ColumnIndex].Name, dtgMamulOz, null);

                if (!cvp)
                {
                    return;
                }

                if (dtgMamulOz.Columns[e.ColumnIndex].Name == "Kuru Madde(%)" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Yağ Oranı (%)" || dtgMamulOz.Columns[e.ColumnIndex].Name == "PH Değeri" || dtgMamulOz.Columns[e.ColumnIndex].Name == "SH Değeri" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Paketleme Öncesi Ürün Sıcaklığı" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Paketlenen Ürün Miktarı (Adet)" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Fire Ürün Miktarı (Adet)" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Numune Ürün Miktarı (Adet)" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Depoya Giren Ürün Miktarı" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Tuz Oranı(%)")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOz);
                    n.ShowDialog();
                }
                else if (dtgMamulOz.Columns[e.ColumnIndex].Name == "Üretilen Ürünler")
                {
                    string sql_AnalizParam = "Select \"U_Deger1\",\"U_Deger2\" from \"@AIF_GNLKANLZPRM\" WITH (NOLOCK) where \"U_Kod\" ='5'";
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

                        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, 0, _autoresizerow: false);
                        selectList.ShowDialog();

                        var sonSatir = dtgMamulOz.Rows[dtgMamulOz.RowCount - 1].Cells[e.ColumnIndex].Value.ToString();

                        if (sonSatir != "")
                        {
                            System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                            DataRow dr = dtMamulOzellikleri.NewRow();
                            dr["Üretilen Ürünler"] = "";
                            dr["Paketleme Öncesi Ürün Sıcaklığı"] = 0;
                            dr["Paketlenen Ürün Miktarı (Adet)"] = 0;
                            dr["Fire Ürün Miktarı (Adet)"] = 0;
                            dr["Numune Ürün Miktarı (Adet)"] = 0;
                            dr["Depoya Giren Ürün Miktarı"] = 0;
                            dr["Kuru Madde(%)"] = 0;
                            dr["Yağ Oranı (%)"] = 0;
                            dr["PH Değeri"] = 0;
                            dr["SH Değeri"] = 0;
                            dr["Tuz Oranı(%)"] = 0;

                            dtMamulOzellikleri.Rows.Add(dr);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtgDinlendirmeVePaket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                bool cvp = true;

                cvp = Kontrol(dtgDinlendirmeVePaket.Columns[e.ColumnIndex].Name, dtgDinlendirmeVePaket, null);

                if (!cvp)
                {
                    return;
                }

                if (dtgDinlendirmeVePaket.Columns[e.ColumnIndex].Name == "08:00 Sıcaklık" || dtgDinlendirmeVePaket.Columns[e.ColumnIndex].Name == "08:00 Nem" || dtgDinlendirmeVePaket.Columns[e.ColumnIndex].Name == "12:00 Sıcaklık" || dtgDinlendirmeVePaket.Columns[e.ColumnIndex].Name == "12:00 Nem" || dtgDinlendirmeVePaket.Columns[e.ColumnIndex].Name == "15:00 Sıcaklık" || dtgDinlendirmeVePaket.Columns[e.ColumnIndex].Name == "15:00 Nem" || dtgDinlendirmeVePaket.Columns[e.ColumnIndex].Name == "18:00 Sıcaklık" || dtgDinlendirmeVePaket.Columns[e.ColumnIndex].Name == "18:00 Nem")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgDinlendirmeVePaket);
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
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                TereyagGunlukAnaliz nesne = new TereyagGunlukAnaliz();

                TereyagGunlukMamulOzellik tereyagGunlukMamulOzellik = new TereyagGunlukMamulOzellik();
                List<TereyagGunlukMamulOzellik> tereyagGunlukMamulOzelliks = new List<TereyagGunlukMamulOzellik>();  

                TereyagGunlukDinlendirmeVePaketleme tereyagGunlukDinlendirmeVePaketleme = new TereyagGunlukDinlendirmeVePaketleme();
                List<TereyagGunlukDinlendirmeVePaketleme> tereyagGunlukDinlendirmeVePaketlemes = new List<TereyagGunlukDinlendirmeVePaketleme>();
                 
                nesne.Aciklama = txtAciklama.Text; 

                nesne.UretimTarihi = txtUretimTarihi.Text.Substring(6, 4) + txtUretimTarihi.Text.Substring(3, 2) + txtUretimTarihi.Text.Substring(0, 2);
                nesne.PaketlemeTarihi = txtUretimTarihi.Text.Substring(6, 4) + txtUretimTarihi.Text.Substring(3, 2) + txtUretimTarihi.Text.Substring(0, 2);

                foreach (DataGridViewRow dr in dtgMamulOz.Rows)
                { 
                    tereyagGunlukMamulOzellik = new TereyagGunlukMamulOzellik();
                    
                    tereyagGunlukMamulOzellik.UretilenUrun = dr.Cells["Üretilen Ürünler"].Value == DBNull.Value ? "" : dr.Cells["Üretilen Ürünler"].Value.ToString();
                    tereyagGunlukMamulOzellik.PaketlemeOncesiSicaklik = dr.Cells["Paketleme Öncesi Ürün Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Paketleme Öncesi Ürün Sıcaklığı"].Value);
                    tereyagGunlukMamulOzellik.PaketlenenUrunMiktari = dr.Cells["Paketlenen Ürün Miktarı (Adet)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Paketlenen Ürün Miktarı (Adet)"].Value);
                    tereyagGunlukMamulOzellik.FireUrunMiktari = dr.Cells["Fire Ürün Miktarı (Adet)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Fire Ürün Miktarı (Adet)"].Value);
                    tereyagGunlukMamulOzellik.NumuneUrunMiktari = dr.Cells["Numune Ürün Miktarı (Adet)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Numune Ürün Miktarı (Adet)"].Value);
                    tereyagGunlukMamulOzellik.DepoyaGirenUrunMiktari = dr.Cells["Depoya Giren Ürün Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Depoya Giren Ürün Miktarı"].Value);
                    tereyagGunlukMamulOzellik.KuruMadde = dr.Cells["Kuru Madde(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde(%)"].Value);
                    tereyagGunlukMamulOzellik.YagOrani = dr.Cells["Yağ Oranı (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ Oranı (%)"].Value);
                    tereyagGunlukMamulOzellik.PH = dr.Cells["PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH Değeri"].Value);
                    tereyagGunlukMamulOzellik.SH = dr.Cells["SH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH Değeri"].Value);
                    tereyagGunlukMamulOzellik.TuzOrani = dr.Cells["Tuz Oranı(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tuz Oranı(%)"].Value);

                    tereyagGunlukMamulOzelliks.Add(tereyagGunlukMamulOzellik);
                }

                nesne.tereyagGunlukMamulOzelliks = tereyagGunlukMamulOzelliks.ToArray();

                foreach (DataGridViewRow dr in dtgDinlendirmeVePaket.Rows)
                {
                    tereyagGunlukDinlendirmeVePaketleme = new TereyagGunlukDinlendirmeVePaketleme();

                    //tereyagGunlukDinlendirmeVePaketleme.UretimTarihi = DateTime.Now.ToString("yyyyMMdd");
                    tereyagGunlukDinlendirmeVePaketleme.AlanAdi = dr.Cells["Alan Adı"].Value == DBNull.Value ? "" : dr.Cells["Alan Adı"].Value.ToString();
                    tereyagGunlukDinlendirmeVePaketleme.SifirSekizSicaklik = dr.Cells["08:00 Sıcaklık"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["08:00 Sıcaklık"].Value);
                    tereyagGunlukDinlendirmeVePaketleme.SifirSekizNem = dr.Cells["08:00 Nem"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["08:00 Nem"].Value);
                    tereyagGunlukDinlendirmeVePaketleme.OnikiSicaklik = dr.Cells["12:00 Sıcaklık"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["12:00 Sıcaklık"].Value);
                    tereyagGunlukDinlendirmeVePaketleme.OnikiNem = dr.Cells["12:00 Nem"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["12:00 Nem"].Value);
                    tereyagGunlukDinlendirmeVePaketleme.OnBesSicaklik = dr.Cells["15:00 Sıcaklık"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["15:00 Sıcaklık"].Value);
                    tereyagGunlukDinlendirmeVePaketleme.OnBesNem = dr.Cells["15:00 Nem"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["15:00 Nem"].Value);
                    tereyagGunlukDinlendirmeVePaketleme.OnSekizSicaklik = dr.Cells["18:00 Sıcaklık"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["18:00 Sıcaklık"].Value);
                    tereyagGunlukDinlendirmeVePaketleme.OnSekizNem = dr.Cells["18:00 Nem"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["18:00 Nem"].Value);

                    tereyagGunlukDinlendirmeVePaketlemes.Add(tereyagGunlukDinlendirmeVePaketleme);
                }

                nesne.tereyagGunlukDinlendirmeVePaketlemes = tereyagGunlukDinlendirmeVePaketlemes.ToArray();

                var resp = client.AddOrUpdateTereyagGunlukAnaliz(nesne, Giris.dbName, Giris.mKodValue); 
                 
                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                if (resp.Value == 0)
                {
                    btnOzetEkranaDon.PerformClick();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }

        private void btnAciklama_Click(object sender, EventArgs e)
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();
        }
    }
}

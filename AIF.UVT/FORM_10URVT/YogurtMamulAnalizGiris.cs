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
    public partial class YogurtMamulAnalizGiris : Form
    {
        //font start
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //font end

        private string UretimFisNo = "";
        private string partiNo = "";
        private string istasyon = "";
        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private int row = 0;
        private string tarih1 = "";
        private string UrunKodu = "";
        private SqlCommand cmd = null;

        public List<kontrolListesi> kontrolListesis = new List<kontrolListesi>();
        public class kontrolListesi
        {
            public string aktifKolon { get; set; }
            public string kontroledilmesigerekenKolon { get; set; }
        }
        public YogurtMamulAnalizGiris(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, int _width, int _height, string _tarih1, string _urunKodu)
        {
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;
            //initialFontSize = txtUretimTarihi.Font.Size;
            //txtUretimTarihi.Resize += Form_Resize;
            //font end

            UretimFisNo = _UretimFisNo;
            partiNo = _PartiNo;
            UrunTanimi = _UrunTanimi;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;
            UrunKodu = _urunKodu;

            txtUretimFisNo.Text = UretimFisNo;
            txtPartiNo.Text = partiNo;
            txtUrunTanimi.Text = UrunTanimi;

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

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              label4.Font.Style);

            txtUretimFisNo.Font = new Font(txtUretimFisNo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimFisNo.Font.Style);

            txtPartiNo.Font = new Font(txtPartiNo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtPartiNo.Font.Style);

            txtUrunTanimi.Font = new Font(txtUrunTanimi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUrunTanimi.Font.Style);

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button2.Font.Style);

            button3.Font = new Font(button3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button3.Font.Style);

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOnayla.Font.Style);

            btnAciklama.Font = new Font(btnAciklama.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnAciklama.Font.Style);

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtUretimTarihi.Font.Style);
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
        private void YogurtMamulAnalizGiris_Load(object sender, EventArgs e)
        {
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_YGRMML_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
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

            dtgInkubasyonTakipLoad();
            dtgGramajKontrolLoad();

            dtgInkubasyonTakip.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgGramajKontrolTablosu.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
        }

        private void dtgInkubasyonTakipLoad()
        {
            try
            {  
                string sql = "select T1.\"U_KontrolNo\" AS \"Kontrol No\",T1.\"U_Saat\" AS \"Saat\",T1.\"U_UrunSicaklik\" AS \"Ürün Sıcaklığı\",T1.\"U_PH\" AS \"PH\",T1.\"U_OdaSicaklik\" AS \"Oda Sıcaklığı\" ,T1.\"U_KontrolEdenPers\" AS \"Kontrol Eden Personel\" from \"@AIF_YGRMML_ANLZ\" T0 WITH (NOLOCK) INNER JOIN \"@AIF_YGRMML_ANLZ1\" T1 WITH (NOLOCK) ON T0.DocEntry = T1.DocEntry WHERE T0.\"U_PartiNo\" = '" + partiNo + "' ";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                //Commit
                dtgInkubasyonTakip.DataSource = dt;

                //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold); 
                //SilButonuEkle(dtgMamulOzellikleri1);


                if (dt.Rows.Count == 0)
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    for (int i = 1; i <= 5; i++)
                    {
                        DataRow dr = dt.NewRow();
                        dr["Kontrol No"] = i;
                        dr["Ürün Sıcaklığı"] = Convert.ToString("0", cultureTR);
                        dr["PH"] = Convert.ToString("0", cultureTR);
                        dr["Oda Sıcaklığı"] = Convert.ToString("0", cultureTR);

                        dt.Rows.Add(dr);
                    }
                }
                //dt.Rows.Add();

                dtgInkubasyonTakip.Columns["Ürün Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgInkubasyonTakip.Columns["Ürün Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgInkubasyonTakip.Columns["PH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgInkubasyonTakip.Columns["PH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgInkubasyonTakip.Columns["Oda Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgInkubasyonTakip.Columns["Oda Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dtgInkubasyonTakip.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgMamulOzellikleri1.AutoResizeRows();
                //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;
                //dtgProsesOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                dtgInkubasyonTakip.EnableHeadersVisualStyles = false;
                dtgInkubasyonTakip.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

                foreach (DataGridViewColumn column in dtgInkubasyonTakip.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                //dtgProsesOzellikleri1.Columns["Parti No"].Width = dtgProsesOzellikleri1.Columns["Parti No"].Width + 20;
                //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;

                #region Kontrol listesi oluşturma 

                //kontrolListesis.Add(new kontrolListesi
                //{
                //    aktifKolon = "Saat",
                //    kontroledilmesigerekenKolon = "Kontrol No"
                //});
                //kontrolListesis.Add(new kontrolListesi
                //{
                //    aktifKolon = "Ürün Sıcaklığı",
                //    kontroledilmesigerekenKolon = "Saat"
                //});
                //kontrolListesis.Add(new kontrolListesi
                //{
                //    aktifKolon = "PH",
                //    kontroledilmesigerekenKolon = "Ürün Sıcaklığı"
                //});
                //kontrolListesis.Add(new kontrolListesi
                //{
                //    aktifKolon = "Oda Sıcaklığı",
                //    kontroledilmesigerekenKolon = "PH"
                //});
                //kontrolListesis.Add(new kontrolListesi
                //{
                //    aktifKolon = "Kontrol Eden Personel",
                //    kontroledilmesigerekenKolon = "Oda Sıcaklığı"
                //});
                #endregion
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
        }
        private void dtgGramajKontrolLoad()
        {
            try
            {
                string sql = "Select T1.\"U_Ornek1\" as \"1.Örnek\",T1.\"U_Ornek2\" as \"2.Örnek\",T1.\"U_Ornek3\" as \"3.Örnek\",T1.\"U_Ornek4\" as \"4.Örnek\",T1.\"U_Ornek5\" as \"5.Örnek\",T1.\"U_Ornek6\" as \"6.Örnek\",T1.\"U_Ornek7\" as \"7.Örnek\",T1.\"U_Ornek8\" as \"8.Örnek\",T1.\"U_Ornek9\" as \"9.Örnek\",T1.\"U_Ornek10\" as \"10.Örnek\",T1.\"U_Ornek11\" as \"11.Örnek\",T1.\"U_Ornek12\" as \"12.Örnek\",T1.\"U_Ornek13\" as \"13.Örnek\",T1.\"U_Ornek14\" as \"14.Örnek\",T1.\"U_Ornek15\" as \"15.Örnek\" from \"@AIF_YGRMML_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_YGRMML_ANLZ2\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                //Commit
                dtgGramajKontrolTablosu.DataSource = dt;

                //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold); 

                //SilButonuEkle(dtgMamulOzellikleri1);

                if (dt.Rows.Count == 0)
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dt.NewRow();
                    dr["1.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["2.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["3.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["4.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["5.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["6.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["7.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["8.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["9.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["10.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["11.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["12.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["13.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["14.Örnek"] = Convert.ToString("0", cultureTR);
                    dr["15.Örnek"] = Convert.ToString("0", cultureTR);

                    dt.Rows.Add(dr);
                }
                //dt.Rows.Add();

                dtgGramajKontrolTablosu.Columns["1.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["1.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["2.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["2.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["3.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["3.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["4.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["4.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["5.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["5.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["6.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["6.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["7.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["7.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["8.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["8.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["9.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["9.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["10.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["10.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["11.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["11.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["12.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["12.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["13.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["13.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["14.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["14.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgGramajKontrolTablosu.Columns["15.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgGramajKontrolTablosu.Columns["15.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dtgGramajKontrolTablosu.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgMamulOzellikleri1.AutoResizeRows(); 
                //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

                //dtgGramajKontrolTablosu.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
                dtgGramajKontrolTablosu.EnableHeadersVisualStyles = false;
                dtgGramajKontrolTablosu.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                foreach (DataGridViewColumn column in dtgGramajKontrolTablosu.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtgInkubasyonTakip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex != -1)
                {
                    //bool cvp = true;

                    //cvp = Kontrol(dtgInkubasyonTakip.Columns[e.ColumnIndex].Name, dtgInkubasyonTakip, null);

                    //if (!cvp)
                    //{
                    //    return;
                    //}

                    if (dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "Kontrol Eden Personel")
                    {
                        if (istasyon.StartsWith("IST"))
                        {
                            //string sql = "Select \"empID\" as \"Kullanıcı Kodu\", (\"firstName\" + ' ' + \"lastName\") as 'Ad Soyad' from OHEM where \"Active\" = 'Y'";

                            string field = "U_" + istasyon;

                            DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                            string gunfield = "U_Gun" + dtTarih.Day;

                            string sql1 = "";

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
                            sql1 = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

                            if (AtanmisIsler.Joker)
                            {
                                sql1 += " UNION ALL ";

                                sql1 += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                            }
                            #endregion Günlük Personel Planlama 4 ekranı

                            SelectList selectList = new SelectList(sql1, dtgInkubasyonTakip, -1, e.ColumnIndex, _autoresizerow: false);
                            selectList.ShowDialog();

                            //dtgProsesOzellikleri1.AutoResizeRows();
                        }
                    }
                    else if (dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "Saat")
                    {
                        SaatTarihGirisi n = new SaatTarihGirisi(dtgInkubasyonTakip);
                        n.ShowDialog();
                    }
                    else if (dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "Ürün Sıcaklığı" || dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "PH" || dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "Oda Sıcaklığı")
                    {
                        SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgInkubasyonTakip);
                        n.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtgGramajKontrolTablosu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            { 
                if (e.RowIndex != -1)
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgGramajKontrolTablosu);
                    n.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
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

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();

                YogurtMamulAnaliz nesne = new YogurtMamulAnaliz();

                YogurtMamulInkubasyon yogurtMamulInkubasyon = new YogurtMamulInkubasyon();
                List<YogurtMamulInkubasyon> yogurtMamulInkubasyons = new List<YogurtMamulInkubasyon>();

                YogurtMamulGramajKontrol yogurtMamulGramajKontrol = new YogurtMamulGramajKontrol();
                List<YogurtMamulGramajKontrol> yogurtMamulGramajKontrols = new List<YogurtMamulGramajKontrol>(); 

                nesne.PartiNo = txtPartiNo.Text;
                nesne.Aciklama = txtAciklama.Text;
                nesne.UretimTarihi = tarih1;
                nesne.UrunKodu = UrunKodu;
                nesne.UrunTanimi = txtUrunTanimi.Text;

                foreach (DataGridViewRow dr in dtgInkubasyonTakip.Rows)
                {
                    yogurtMamulInkubasyon = new YogurtMamulInkubasyon();
                    yogurtMamulInkubasyon.KontrolNo = dr.Cells["Kontrol No"].Value == DBNull.Value ? "" : dr.Cells["Kontrol No"].Value.ToString();
                    yogurtMamulInkubasyon.Saat = dr.Cells["Saat"].Value == DBNull.Value ? "" : dr.Cells["Saat"].Value.ToString();
                    yogurtMamulInkubasyon.UrunSicakligi= dr.Cells["Ürün Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Ürün Sıcaklığı"].Value);  
                    yogurtMamulInkubasyon.PH= dr.Cells["PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH"].Value);  
                    yogurtMamulInkubasyon.OdaSicakligi= dr.Cells["Oda Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Oda Sıcaklığı"].Value);
                    yogurtMamulInkubasyon.KontrolEdenPersonel = dr.Cells["Kontrol Eden Personel"].Value == DBNull.Value ? "" : dr.Cells["Kontrol Eden Personel"].Value.ToString(); 

                    yogurtMamulInkubasyons.Add(yogurtMamulInkubasyon);
                }

                nesne.YogurtMamulInkubasyons = yogurtMamulInkubasyons.ToArray();

                foreach (DataGridViewRow dr in dtgGramajKontrolTablosu.Rows)
                {
                    yogurtMamulGramajKontrol = new YogurtMamulGramajKontrol();

                    yogurtMamulGramajKontrol.Ornek1 = dr.Cells["1.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["1.Örnek"].Value); 
                    yogurtMamulGramajKontrol.Ornek2 = dr.Cells["2.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["2.Örnek"].Value); 
                    yogurtMamulGramajKontrol.Ornek3 = dr.Cells["3.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["3.Örnek"].Value); 
                    yogurtMamulGramajKontrol.Ornek4 = dr.Cells["4.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["4.Örnek"].Value); 
                    yogurtMamulGramajKontrol.Ornek5 = dr.Cells["5.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["5.Örnek"].Value); 
                    yogurtMamulGramajKontrol.Ornek6 = dr.Cells["6.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["6.Örnek"].Value); 
                    yogurtMamulGramajKontrol.Ornek7 = dr.Cells["7.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["7.Örnek"].Value); 
                    yogurtMamulGramajKontrol.Ornek8 = dr.Cells["8.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["8.Örnek"].Value); 
                    yogurtMamulGramajKontrol.Ornek9 = dr.Cells["9.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["9.Örnek"].Value); 
                    yogurtMamulGramajKontrol.Ornek10 = dr.Cells["10.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["10.Örnek"].Value); 
                    yogurtMamulGramajKontrol.Ornek11 = dr.Cells["11.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["11.Örnek"].Value);
                    yogurtMamulGramajKontrol.Ornek12 = dr.Cells["12.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["12.Örnek"].Value);
                    yogurtMamulGramajKontrol.Ornek13 = dr.Cells["13.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["13.Örnek"].Value);
                    yogurtMamulGramajKontrol.Ornek14 = dr.Cells["14.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["14.Örnek"].Value);
                    yogurtMamulGramajKontrol.Ornek15 = dr.Cells["15.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["15.Örnek"].Value);

                    yogurtMamulGramajKontrols.Add(yogurtMamulGramajKontrol);
                }

                nesne.YogurtMamulGramajKontrols = yogurtMamulGramajKontrols.ToArray(); 

                var resp = client.AddOrUpdateYogurtMamulAnaliz(nesne, Giris.dbName, Giris.mKodValue);

                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                if (resp.Value == 0)
                {
                    btnOzetEkranaDon.PerformClick();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
        } 
    }
}

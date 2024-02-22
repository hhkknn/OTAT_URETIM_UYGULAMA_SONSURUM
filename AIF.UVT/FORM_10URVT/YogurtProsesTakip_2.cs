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

namespace AIF.UVT
{
    public partial class YogurtProsesTakip_2 : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end

        public YogurtProsesTakip_2(string _type, string _kullaniciid, int _row, string _tarih1)
        {
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = txtTarih.Font.Size;
            txtTarih.Resize += Form_Resize;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            //initialFontSize = button2.Font.Size;
            //button2.Resize += Form_Resize;

            initialFontSize = button3.Font.Size;
            button3.Resize += Form_Resize;

            initialFontSize = btnOzetEkranaDon.Font.Size;
            btnOzetEkranaDon.Resize += Form_Resize;

            initialFontSize = btnOnayla.Font.Size;
            btnOnayla.Resize += Form_Resize;

            initialFontSize = btnAciklama.Font.Size;
            btnAciklama.Resize += Form_Resize;

            //font end

            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            tarih1 = _tarih1;

            txtTarih.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
        }

        private string type = "";
        private string kullaniciid = "";
        private int row = 0;
        private string tarih1 = "";
        private SqlCommand cmd = null;

        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label1.Font.Style);

            txtTarih.Font = new Font(txtTarih.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtTarih.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button1.Font.Style);

            //button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   button2.Font.Style);

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

        private void YogurtProsesTakip_2_Load(object sender, EventArgs e)
        {
            sabitDegerler.Add("200G Yoğurt");
            sabitDegerler.Add("500G Yoğurt");
            sabitDegerler.Add("1000G Yoğurt");
            sabitDegerler.Add("1500G Yoğurt");
            sabitDegerler.Add("2000G Yoğurt");
            sabitDegerler.Add("3750G Yoğurt");
            sabitDegerler.Add("5000G Yoğurt");
            sabitDegerler.Add("10KG Yoğurt");

            sabitDegerlerGorevliPersonel.Add("Operatör-Operatör Yardımcısı");
            sabitDegerlerGorevliPersonel.Add("Makineye Kova Veya Bidon Verme");
            sabitDegerlerGorevliPersonel.Add("Makineye Kapak Verme");
            sabitDegerlerGorevliPersonel.Add("Makineden Ürün Alma(Palete Ürün Dizme)");
            sabitDegerlerGorevliPersonel.Add("Viyol Besleme");
            sabitDegerlerGorevliPersonel.Add("Shrin Sonu Yoğurt Dizme");

            //sabitDegerlerGramajKontrol.Add("1.Örnek");
            //sabitDegerlerGramajKontrol.Add("2.Örnek");
            //sabitDegerlerGramajKontrol.Add("3.Örnek");
            //sabitDegerlerGramajKontrol.Add("4.Örnek");
            //sabitDegerlerGramajKontrol.Add("5.Örnek");
            //sabitDegerlerGramajKontrol.Add("6.Örnek");
            //sabitDegerlerGramajKontrol.Add("7.Örnek");

            dtgYardimciMalzemelerLoad();
            dtgGorevliPersonelLoad();
            //dtgGramajKontrolLoad();
        }

        private List<string> sabitDegerler = new List<string>();
        private List<string> sabitDegerlerGorevliPersonel = new List<string>();
        //private List<string> sabitDegerlerGramajKontrol = new List<string>();

        private void dtgYardimciMalzemelerLoad()
        {
            string sql = "Select T1.\"U_UrunAdi\" as \"Ürün Adı\",\"U_KovaKaseTedAdi\" as \"Kova/Kase Tedarikçi Adı\",T1.\"U_KovaKasePartiNo\" as \"Kova/Kase Parti No\",T1.\"U_KapakFolyoTedAdi\" as \"Kapak/Folyo Tedarikçi Adı\",T1.\"U_KapakFolyoPartiNo\" as \"Kapak/Folyo Parti No\",T1.\"U_ViyolTedAdi\" as \"Viyol Tedarikçi Adı\",T1.\"U_ViyolPartiNo\" as \"Viyol Parti No\" from \"@AIF_YGRTYRDMLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_YGRTYRDMLZ1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_UretimTarihi\" = '" + tarih1 + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            dtgYardimciMalzemeler.DataSource = dt;

            dtgYardimciMalzemeler.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgYardimciMalzemeler.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgYardimciMalzemeler.EnableHeadersVisualStyles = false;
            dtgYardimciMalzemeler.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgYardimciMalzemeler.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            if (dt.Rows.Count == 0)
            {
                //foreach (var item in sabitDegerler)
                //{
                //    DataRow dr = dt.NewRow();
                //    dr["Ürün Adı"] = item;

                //    dt.Rows.Add(dr);
                //}

                string sqlParametre = "Select DISTINCT T2.\"ProdName\" from (Select \"ItemCode\" from OITM as T0 INNER JOIN \"@AIF_GNLKANLZPRM\" as T1 WITH (NOLOCK) ON T0.\"U_ItemGroup2\" = T1.\"U_Deger1\" and T0.\"ItmsGrpCod\" = T1.\"U_Deger2\" where T1.\"U_Kod\" = '2') as tbl INNER JOIN OWOR as T2 WITH (NOLOCK) ON tbl.\"ItemCode\" = T2.\"ItemCode\" and T2.\"PostDate\" = '" + tarih1 + "' ";

                cmd = new SqlCommand(sqlParametre, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                sda = new SqlDataAdapter(cmd);
                sda.Fill(dttemp);

                foreach (DataRow item in dttemp.Rows)
                {
                    DataRow dr = dt.NewRow();
                    dr["Ürün Adı"] = item[0].ToString();

                    dt.Rows.Add(dr);
                }

                dtgYardimciMalzemeler.DataSource = dt;
            }
            //dt.Rows.Add();
            Connection.sql.Close();

            foreach (DataGridViewColumn column in dtgYardimciMalzemeler.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dtgGorevliPersonelLoad()
        {
            string sql = "Select T1.\"U_Aciklama\" as \"Açıklama\",T1.\"U_Deger\" as \"Değer\" from \"@AIF_YGRTYRDMLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_YGRTYRDMLZ2\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_UretimTarihi\" = '" + tarih1 + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            dtgGorevliPersonel.DataSource = dt;

            dtgGorevliPersonel.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgGorevliPersonel.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgGorevliPersonel.EnableHeadersVisualStyles = false;
            dtgGorevliPersonel.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgGorevliPersonel.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            if (dt.Rows.Count == 0)
            {
                foreach (var item in sabitDegerlerGorevliPersonel)
                {
                    DataRow dr = dt.NewRow();
                    dr["Açıklama"] = item;

                    dt.Rows.Add(dr);
                }
            }
            //dt.Rows.Add();

            foreach (DataGridViewColumn column in dtgGorevliPersonel.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dtgGramajKontrolLoad()
        {
            //string sql = "Select T1.\"U_Aciklama\" as \"Açıklama\",T1.\"U_Deger\" as \"Değer\" from \"@AIF_YGRTYRDMLZ\" as T0 INNER JOIN \"@AIF_YGRTYRDMLZ3\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_UretimTarihi\" = '" + tarih1 + "'";
            //cmd = new SqlCommand(sql, Connection.sql);

            //if (Connection.sql.State != ConnectionState.Open)
            //    Connection.sql.Open();

            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //DataTable dttemp = new DataTable();
            //sda.Fill(dt);

            //dtgGramajKontrol.DataSource = dt;

            //dtgGramajKontrol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //dtgGramajKontrol.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            //dtgGramajKontrol.EnableHeadersVisualStyles = false;
            //dtgGramajKontrol.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            //foreach (DataGridViewColumn col in dtgGramajKontrol.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            //}

            //if (dt.Rows.Count == 0)
            //{
            //    foreach (var item in sabitDegerlerGramajKontrol)
            //    {
            //        DataRow dr = dt.NewRow();
            //        dr["Açıklama"] = item;

            //        dt.Rows.Add(dr);
            //    }
            //}
            ////dt.Rows.Add();

            //dtgGramajKontrol.Columns["Değer"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgGramajKontrol.Columns["Değer"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //foreach (DataGridViewColumn column in dtgGramajKontrol.Columns)
            //{
            //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
            //    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //}
        }

        private void dtgYardimciMalzemeler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgYardimciMalzemeler.Columns[e.ColumnIndex].Name == "Kova/Kase Tedarikçi Adı" || dtgYardimciMalzemeler.Columns[e.ColumnIndex].Name == "Kapak/Folyo Tedarikçi Adı" || dtgYardimciMalzemeler.Columns[e.ColumnIndex].Name == "Viyol Tedarikçi Adı")
            {
                string sql1 = "Select TOP 1 '' as \"Müşteri Kodu\",'' as \"Müşteri Adı\" FROM OCRD WITH (NOLOCK) where \"CardType\" = 'S'";
                sql1 += " UNION ALL ";
                sql1 += "Select CardCode as \"Müşteri Kodu\",CardName as \"Müşteri Adı\" FROM OCRD WITH (NOLOCK) where \"CardType\" = 'S' and \"QryGroup2\"='Y'";

                SelectList selectList = new SelectList(sql1, dtgYardimciMalzemeler, -1, e.ColumnIndex, _autoresizerow: false);
                selectList.ShowDialog();
            }
        }

        //private void dtgGramajKontrol_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (dtgGramajKontrol.Columns[e.ColumnIndex].Name == "Değer")
        //    {
        //        SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgGramajKontrol);
        //        n.ShowDialog();
        //    }
        //}

        private void dtgGorevliPersonel_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgGorevliPersonel.Columns[e.ColumnIndex].Name == "Değer")
            {
                DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                string gunfield = "U_Gun" + dtTarih.Day;

                string sql = "";

                #region Günlük Personel Planlama 2 ekranı
                //sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'IST002' or T1.\"U_Bolum2\" = 'IST002' or T1.\"U_Bolum3\" = 'IST002') and " + gunfield + " = 'X' ";


                //if (AtanmisIsler.Joker)
                //{
                //    sql += " UNION ALL ";

                //    sql += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                //}
                #endregion
                //string sql = "Select \"U_PersonelNo\" as \"Personel No\",\"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"" + field + "\" = 'Y'";

                #region Günlük Personel Planlama 3 ekranı
                //sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                //sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'IST002' or T1.\"U_Bolum2\" = 'IST002' or T1.\"U_Bolum3\" = 'IST002') and \"U_Durum\" = 'X'";

                //if (AtanmisIsler.Joker)
                //{
                //    sql += " UNION ALL ";

                //    sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                //    sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') and \"U_Durum\" = 'X'";
                //} 
                #endregion

                #region Günlük Personel Planlama 4 ekranı
                sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

                if (AtanmisIsler.Joker)
                {
                    sql += " UNION ALL ";

                    sql += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                }
                #endregion Günlük Personel Planlama 4 ekranı

                SelectList selectList = new SelectList(sql, dtgGorevliPersonel, -1, e.ColumnIndex, _autoresizerow: false);
                selectList.ShowDialog();
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            UVTServiceSoapClient client = new UVTServiceSoapClient();
            YogurtYardimciMalzeme nesne = new YogurtYardimciMalzeme();
            YogurtYardimciMalzemeKontrolu yogurtYardimciMalzemeKontrolu = new YogurtYardimciMalzemeKontrolu();
            List<YogurtYardimciMalzemeKontrolu> yogurtYardimciMalzemeKontrolus = new List<YogurtYardimciMalzemeKontrolu>();
            YogurtYardimciMalzemeGorevliPersonel yogurtYardimciMalzemeGorevliPersonel = new YogurtYardimciMalzemeGorevliPersonel();
            List<YogurtYardimciMalzemeGorevliPersonel> yogurtYardimciMalzemeGorevliPersonels = new List<YogurtYardimciMalzemeGorevliPersonel>();
            YogurtYardimciMalzemeGramajKontrol yogurtYardimciMalzemeGramajKontrol = new YogurtYardimciMalzemeGramajKontrol();
            List<YogurtYardimciMalzemeGramajKontrol> yogurtYardimciMalzemeGramajKontrols = new List<YogurtYardimciMalzemeGramajKontrol>();

            nesne.UretimTarihi = txtTarih.Text.Substring(6, 4) + txtTarih.Text.Substring(3, 2) + txtTarih.Text.Substring(0, 2);
            nesne.Aciklama = txtAciklama.Text;

            foreach (DataGridViewRow dr in dtgYardimciMalzemeler.Rows)
            {
                yogurtYardimciMalzemeKontrolu = new YogurtYardimciMalzemeKontrolu();
                yogurtYardimciMalzemeKontrolu.UrunKodu = "";
                yogurtYardimciMalzemeKontrolu.UrunAdi = dr.Cells["Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Ürün Adı"].Value.ToString();
                yogurtYardimciMalzemeKontrolu.KovaKaseTedarikciAdi = dr.Cells["Kova/Kase Tedarikçi Adı"].Value == DBNull.Value ? "" : dr.Cells["Kova/Kase Tedarikçi Adı"].Value.ToString();
                yogurtYardimciMalzemeKontrolu.KovaKasePartiNo = dr.Cells["Kova/Kase Parti No"].Value == DBNull.Value ? "" : dr.Cells["Kova/Kase Parti No"].Value.ToString();
                yogurtYardimciMalzemeKontrolu.KapakFolyoTedarikciAdi = dr.Cells["Kapak/Folyo Tedarikçi Adı"].Value == DBNull.Value ? "" : dr.Cells["Kapak/Folyo Tedarikçi Adı"].Value.ToString();
                yogurtYardimciMalzemeKontrolu.KapakFolyoPartiNo = dr.Cells["Kapak/Folyo Parti No"].Value == DBNull.Value ? "" : dr.Cells["Kapak/Folyo Parti No"].Value.ToString();
                yogurtYardimciMalzemeKontrolu.ViyolTedarikciAdi = dr.Cells["Viyol Tedarikçi Adı"].Value == DBNull.Value ? "" : dr.Cells["Viyol Tedarikçi Adı"].Value.ToString();
                yogurtYardimciMalzemeKontrolu.ViyolPartiNo = dr.Cells["Viyol Parti No"].Value == DBNull.Value ? "" : dr.Cells["Viyol Parti No"].Value.ToString();

                yogurtYardimciMalzemeKontrolus.Add(yogurtYardimciMalzemeKontrolu);
            }

            nesne.yogurtYardimciMalzemeKontrolus = yogurtYardimciMalzemeKontrolus.ToArray();

            foreach (DataGridViewRow dr in dtgGorevliPersonel.Rows)
            {
                yogurtYardimciMalzemeGorevliPersonel = new YogurtYardimciMalzemeGorevliPersonel();
                yogurtYardimciMalzemeGorevliPersonel.Aciklama = dr.Cells["Açıklama"].Value == DBNull.Value ? "" : dr.Cells["Açıklama"].Value.ToString();
                yogurtYardimciMalzemeGorevliPersonel.Deger = dr.Cells["Değer"].Value == DBNull.Value ? "" : dr.Cells["Değer"].Value.ToString();

                yogurtYardimciMalzemeGorevliPersonels.Add(yogurtYardimciMalzemeGorevliPersonel);
            }

            nesne.yogurtYardimciMalzemeGorevliPersonels = yogurtYardimciMalzemeGorevliPersonels.ToArray();

            //foreach (DataGridViewRow dr in dtgGramajKontrol.Rows)
            //{
            //    yogurtYardimciMalzemeGramajKontrol = new YogurtYardimciMalzemeGramajKontrol();
            //    yogurtYardimciMalzemeGramajKontrol.Aciklama = dr.Cells["Açıklama"].Value == DBNull.Value ? "" : dr.Cells["Açıklama"].Value.ToString();
            //    yogurtYardimciMalzemeGramajKontrol.Deger = dr.Cells["Değer"].Value == DBNull.Value ? "" : dr.Cells["Değer"].Value.ToString();

            //    yogurtYardimciMalzemeGramajKontrols.Add(yogurtYardimciMalzemeGramajKontrol);
            //}

            //nesne.yogurtYardimciMalzemeGramajKontrols = yogurtYardimciMalzemeGramajKontrols.ToArray();

            var resp = client.AddOrUpdateYogurtYardimciMalzeme(nesne, Giris.dbName, Giris.mKodValue);

            MessageBox.Show(resp.Description);

            if (resp.Value == 0)
            {
                btnOzetEkranaDon.PerformClick();
            }
        }

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }
    }
}
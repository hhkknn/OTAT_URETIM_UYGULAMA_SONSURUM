using AIF.UVT.DatabaseLayer;
using AIF.UVT.Library;
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
    public partial class YogurtProsesTakip_1 : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end

        public YogurtProsesTakip_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunGrubu)
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

            initialFontSize = txtUretimFisNo.Font.Size;
            txtUretimFisNo.Resize += Form_Resize;

            initialFontSize = txtPartiNo.Font.Size;
            txtPartiNo.Resize += Form_Resize;

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

            initialFontSize = btnOzetEkranaDon.Font.Size;
            btnOzetEkranaDon.Resize += Form_Resize;

            initialFontSize = btnOnayla.Font.Size;
            btnOnayla.Resize += Form_Resize;

            initialFontSize = button10.Font.Size;
            button10.Resize += Form_Resize;

            initialFontSize = button11.Font.Size;
            button11.Resize += Form_Resize;
            //font end

            UretimFisNo = _UretimFisNo;
            partiNo = _PartiNo;
            UrunTanimi = _UrunTanimi;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;
            UrunGrubu = _urunGrubu;

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

            txtUretimFisNo.Font = new Font(txtUretimFisNo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimFisNo.Font.Style);

            txtPartiNo.Font = new Font(txtPartiNo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtPartiNo.Font.Style);

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

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOnayla.Font.Style);

            button10.Font = new Font(button10.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button10.Font.Style);

            button11.Font = new Font(button11.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button11.Font.Style);

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              label4.Font.Style);

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

        DataTable dataTable1 = new DataTable();
        private string UretimFisNo = "";
        private string partiNo = "";
        private string istasyon = "";
        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private int row = 0;
        private static string tarih1 = "";
        private string UrunGrubu = "";
        private SqlCommand cmd = null;

        #region eski tablo kaydetme
        //private static OtatServiceSoapClient client = new OtatServiceSoapClient();
        //public static YogurtProsesTakipAnaliz nesne = new YogurtProsesTakipAnaliz();
        //public static YogurtProsesOzellikleri1 YogurtProsesOzellikleri1 = new YogurtProsesOzellikleri1();
        //public static List<YogurtProsesOzellikleri1> YogurtProsesOzellikleri1s = new List<YogurtProsesOzellikleri1>();
        //public static YogurtProsesOzellikleri2 YogurtProsesOzellikleri2 = new YogurtProsesOzellikleri2();
        //public static List<YogurtProsesOzellikleri2> YogurtProsesOzellikleri2s = new List<YogurtProsesOzellikleri2>();
        //public static YogurtProsesOzellikleri3 YogurtProsesOzellikleri3 = new YogurtProsesOzellikleri3();
        //public static List<YogurtProsesOzellikleri3> yogurtProsesOzellikleri3s = new List<YogurtProsesOzellikleri3>();
        //public static YogurtBirinciKultur YogurtBirinciKultur = new YogurtBirinciKultur();
        //public static List<YogurtBirinciKultur> YogurtBirinciKulturs = new List<YogurtBirinciKultur>();
        //public static YogurtIkinciKultur YogurtIkinciKultur = new YogurtIkinciKultur();
        //public static List<YogurtIkinciKultur> YogurtIkinciKulturs = new List<YogurtIkinciKultur>();
        //public static YogurtTuzOzellikleri YogurtTuzOzellikleri = new YogurtTuzOzellikleri();
        //public static List<YogurtTuzOzellikleri> YogurtTuzOzellikleris = new List<YogurtTuzOzellikleri>();
        //public static YogurtSutOzellikleri YogurtSutOzellikleri = new YogurtSutOzellikleri();
        //public static List<YogurtSutOzellikleri> YogurtSutOzellikleris = new List<YogurtSutOzellikleri>();
        //public static YogurtYariMamulKaliteOzellikleri YogurtYariMamulKaliteOzellikleri = new YogurtYariMamulKaliteOzellikleri();
        //public static List<YogurtYariMamulKaliteOzellikleri> YogurtYariMamulKaliteOzellikleris = new List<YogurtYariMamulKaliteOzellikleri>();
        //public static YogurtInkubasyonOzellikleri YogurtInkubasyonOzellikleri = new YogurtInkubasyonOzellikleri();
        //public static List<YogurtInkubasyonOzellikleri> YogurtInkubasyonOzellikleris = new List<YogurtInkubasyonOzellikleri>();
        #endregion

        private static UVTServiceSoapClient client = new UVTServiceSoapClient();
        public DataTable dtgProsesOzellikleri1_DataTable = new DataTable();
        public DataTable dtgProsesOzellikleri2_DataTable = new DataTable();
        public DataTable dtgBirinciKultur_DataTable = new DataTable();
        public DataTable dtgProsesOzellikleri3_DataTable = new DataTable();
        public DataTable dtgIkinciKultur_DataTable = new DataTable();
        public DataTable dtgSutunOzellikleri_DataTable = new DataTable();
        public DataTable dtgYariMamulKaliteOzellikleri_DataTable = new DataTable();
        public DataTable dtgInkubasyonTakip_DataTable = new DataTable();

        public static string PartyNo = "";
        public static string UretimSiparisNo = "";
        public static string UretilenUrunTanimi = "";
        public static string UretimAciklamasi = "";

        #region eski tablo kaydetme
        //public static DataGridView dtgProsesOzellikleri1Static = new DataGridView();
        //public static DataGridView dtgProsesOzellikleri2Static = new DataGridView();
        //public static DataGridView dtgProsesOzellikleri3Static = new DataGridView();
        //public static DataGridView dtgBirinciKulturBilgileriStatic = new DataGridView();
        //public static DataGridView dtgIkinciKulturBilgileriStatic = new DataGridView();
        //public static DataGridView dtgSutunOzellikleriStatic = new DataGridView();
        //public static DataGridView dtgYariMamulKaliteOzellikleriStatic = new DataGridView();
        //public static DataGridView dtgInkubasyonTakipStatic = new DataGridView(); 
        #endregion

        public static Button btnOzet = null;

        private void YogurtProsesTakip_1_Load(object sender, EventArgs e)
        {
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_YGRPRSS_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            sda.Fill(dataTable1);

            if (dataTable1.Rows.Count > 0)
            {
                txtAciklama.Text = dataTable1.Rows[0].ItemArray[0].ToString();
            }

            dtgProsesOzellikleri1Load();
            dtgProsesOzellikleri2Load();
            dtgProsesOzellikleri3Load();
            dtgBirinciKulturBilgileriLoad();
            dtgIkinciKulturBilgileriLoad();

            #region ikinci ekrn 1,2,3 grid yüklemeleri
            dtgSutunOzellikleriLoad_IkinciEkran();
            dtgYariMamulKaliteOzellikleriLoad_IkinciEkran();
            dtgInkubasyonTakipOzellikleriLoad_IkinciEkran();
            #endregion

            //dtgProsesOzellikleri1Static = dtgProsesOzellikleri1;
            //dtgProsesOzellikleri2Static = dtgProsesOzellikleri2;
            //dtgProsesOzellikleri3Static = dtgProsesOzellikleri3;
            //dtgBirinciKulturBilgileriStatic = dtgBirinciKultur;
            //dtgIkinciKulturBilgileriStatic = dtgIkinciKultur;

            btnOzet = btnOzetEkranaDon;
        }

        private void dtgProsesOzellikleri1Load()
        {
            //string sql = "Select T1.\"ItemCode\" as \"Malzeme Kodu\",T1.\"Dscription\" as \"Malzeme Tanımı\", SUM(T1.\"Quantity\") as \"Miktar\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' group by T1.\"ItemCode\",T1.\"Dscription\"";

            string sql = "Select T1.\"U_UrunGrubu\" as \"Ürün Grubu\",T1.\"U_InkubasyonOdaNo\" as \"Inkübasyon Oda No\",\"U_ProsesBasSaat\" as \"Proses Başlangıç Saati\",T1.\"U_YagliSutMik\" as \"Yağlı Süt Miktarı\",T1.\"U_YagsizSutMik\" as \"Yağsız Süt Miktarı\",T1.\"U_KremaMik\" as \"Kullanılan Krema Miktarı\" from \"@AIF_YGRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_YGRPRSS_ANLZ1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtgProsesOzellikleri1_DataTable);

            //Commit
            dtgProsesOzellikleri1.DataSource = dtgProsesOzellikleri1_DataTable;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgProsesOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgProsesOzellikleri1.EnableHeadersVisualStyles = false;
            dtgProsesOzellikleri1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgProsesOzellikleri1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);

            if (dtgProsesOzellikleri1_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgProsesOzellikleri1_DataTable.NewRow();
                dr["Ürün Grubu"] = UrunGrubu;
                dr["Yağlı Süt Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Yağsız Süt Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Kullanılan Krema Miktarı"] = Convert.ToString("0", cultureTR);

                dtgProsesOzellikleri1_DataTable.Rows.Add(dr);
            }
            //dt.Rows.Add();

            dtgProsesOzellikleri1.Columns["Yağlı Süt Miktarı"].ReadOnly = true;
            dtgProsesOzellikleri1.Columns["Yağlı Süt Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri1.Columns["Yağlı Süt Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri1.Columns["Yağsız Süt Miktarı"].ReadOnly = true;
            dtgProsesOzellikleri1.Columns["Yağsız Süt Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri1.Columns["Yağsız Süt Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri1.Columns["Kullanılan Krema Miktarı"].ReadOnly = true;
            dtgProsesOzellikleri1.Columns["Kullanılan Krema Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri1.Columns["Kullanılan Krema Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgProsesOzellikleri1.Columns["Proses Başlangıç Saati"].ReadOnly = true;
            dtgProsesOzellikleri1.Columns["Ürün Grubu"].ReadOnly = true;

            dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgProsesOzellikleri1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;

            sda = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();

            #region Proses başlangıç saati getirme

            sql = "SELECT \"BeginTime\" from OCLG WITH (NOLOCK) where \"U_PartiNo\" = '" + partiNo + "' order by \"ClgCode\" asc";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            sda = new SqlDataAdapter(cmd);
            dt2 = new DataTable();
            sda.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                var girilenSaat = dtgProsesOzellikleri1.Rows[0].Cells["Proses Başlangıç Saati"].Value.ToString() == "" ? "0" : dtgProsesOzellikleri1.Rows[0].Cells["Proses Başlangıç Saati"].Value.ToString();
                if (girilenSaat == "0")
                {
                    string saat = dt2.Rows[0][0].ToString().PadLeft(4, '0');
                    saat = saat.Substring(0, 2) + ":" + saat.Substring(2, 2);
                    dtgProsesOzellikleri1.Rows[0].Cells["Proses Başlangıç Saati"].Value = saat;
                }
            }

            #endregion Proses başlangıç saati getirme

            dt2.Rows.Clear();
            string uretimdenCikissql = "Select T0.\"DocEntry\",SUM(ISNULL(T1.\"Quantity\",0)) from \"OIGE\" as T0 WITH (NOLOCK) INNER JOIN \"IGE1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' and T1.\"ItemCode\" = 'YRM-10003' group by T0.\"DocEntry\"";

            cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                var uretilenmiktar = dtgProsesOzellikleri1.Rows[0].Cells["Yağlı Süt Miktarı"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Yağlı Süt Miktarı"].Value);
                if (uretilenmiktar == 0)
                {
                    var miktar = Convert.ToDouble(dt2.Rows[0][1]);
                    dtgProsesOzellikleri1.Rows[0].Cells["Yağlı Süt Miktarı"].Value = miktar.ToString();
                }
            }

            dt2 = new DataTable();

            uretimdenCikissql = "Select T0.\"DocEntry\",SUM(ISNULL(T1.\"Quantity\",0)) from \"OIGE\" as T0 WITH (NOLOCK) INNER JOIN \"IGE1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' and T1.\"ItemCode\" = 'YRM-10002' group by T0.\"DocEntry\"";

            cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt2);

            if (dt2.Rows.Count > 0)
            {
                var uretilenmiktar = dtgProsesOzellikleri1.Rows[0].Cells["Yağsız Süt Miktarı"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Yağsız Süt Miktarı"].Value);
                if (uretilenmiktar == 0)
                {
                    var miktar = Convert.ToDouble(dt2.Rows[0][1]);
                    dtgProsesOzellikleri1.Rows[0].Cells["Yağsız Süt Miktarı"].Value = miktar.ToString();
                }
            }
        }

        private void dtgProsesOzellikleri2Load()
        {
            //string sql = "Select T1.\"ItemCode\" as \"Malzeme Kodu\",T1.\"Dscription\" as \"Malzeme Tanımı\", SUM(T1.\"Quantity\") as \"Miktar\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' group by T1.\"ItemCode\",T1.\"Dscription\"";

            string sql = "Select T1.\"U_VakumBasSaat\" as \"Vakum Başlangıç Saati\",T1.\"U_VakumBitSaat\" as \"Vakum Bitiş Saati\",\"U_Brix\" as \"Vakum Sonu Brix Değeri\",T1.\"U_PastorizasyonSicak\" as \"Pastörizasyon Sıcaklığı\",T1.\"U_PastorizasyonSure\" as \"Pastörizasyon Süresi\",T1.\"U_MayalamaSaati\" as \"Mayalama Saati\",T1.\"U_MayalamaPH\" as \"Mayalama PH Değeri\",T1.\"U_MayalamaSicakligi\" as \"Mayalama Sıcaklığı\" from \"@AIF_YGRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_YGRPRSS_ANLZ2\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtgProsesOzellikleri2_DataTable);

            //Commit
            dtgProsesOzellikleri2.DataSource = dtgProsesOzellikleri2_DataTable;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgProsesOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgProsesOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgProsesOzellikleri2.EnableHeadersVisualStyles = false;
            dtgProsesOzellikleri2.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgProsesOzellikleri2.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);

            if (dtgProsesOzellikleri2_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgProsesOzellikleri2_DataTable.NewRow();
                dr["Pastörizasyon Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Mayalama Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Mayalama PH Değeri"] = Convert.ToString("0", cultureTR);
                dr["Vakum Sonu Brix Değeri"] = Convert.ToString("0", cultureTR);
                dr["Pastörizasyon Süresi"] = Convert.ToString("0", cultureTR);

                dtgProsesOzellikleri2_DataTable.Rows.Add(dr);
            }
            //dt.Rows.Add();

            dtgProsesOzellikleri2.Columns["Pastörizasyon Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Pastörizasyon Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Mayalama Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Mayalama Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Mayalama PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Mayalama PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Vakum Sonu Brix Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Vakum Sonu Brix Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Pastörizasyon Süresi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Pastörizasyon Süresi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgProsesOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;


            //dtgProsesOzellikleri2.Columns["Vakum Başlangıç Saati"].ReadOnly = true;

            foreach (DataGridViewColumn column in dtgProsesOzellikleri2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;

            #region Kontrol listesi oluşturma
            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Vakum Bitiş Saati",
                kontroledilmesigerekenKolon = "Vakum Başlangıç Saati"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Vakum Sonu Brix Değeri",
                kontroledilmesigerekenKolon = "Vakum Bitiş Saati"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pastörizasyon Sıcaklığı",
                kontroledilmesigerekenKolon = "Vakum Sonu Brix Değeri"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pastörizasyon Süresi",
                kontroledilmesigerekenKolon = "Pastörizasyon Sıcaklığı"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Mayalama Saati",
                kontroledilmesigerekenKolon = "Pastörizasyon Süresi"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Mayalama PH Değeri",
                kontroledilmesigerekenKolon = "Mayalama Saati"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Mayalama Sıcaklığı",
                kontroledilmesigerekenKolon = "Mayalama PH Değeri"
            });
            #endregion
        }

        private void dtgProsesOzellikleri3Load()
        {
            //string sql = "Select T1.\"ItemCode\" as \"Malzeme Kodu\",T1.\"Dscription\" as \"Malzeme Tanımı\", SUM(T1.\"Quantity\") as \"Miktar\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' group by T1.\"ItemCode\",T1.\"Dscription\"";

            string sql = "Select T1.\"U_DolumBasSaat\" as \"Dolum Başlangıç Saati\",T1.\"U_DolumBasPH\" as \"Dolum Başlangıcındaki PH Değeri\",T1.\"U_DolumBasSicak\" as \"Dolum Başlangıcındaki Süt Sıcaklığı\",T1.\"U_DolumBitSaat\" as \"Dolum Bitiş Saati\",T1.\"U_DolumBitPH\" as \"Dolum Bittiğindeki PH Değeri\",T1.\"U_DolumBitSicak\" as \"Dolum Bittiğindeki Süt Sıcaklığı\",T1.\"U_SorumluPersonel\" as \"Sorumlu Personel\",T1.\"U_ToplamGecenSure\" as \"Toplam Geçen Süre\" from \"@AIF_YGRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_YGRPRSS_ANLZ3\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtgProsesOzellikleri3_DataTable);

            //Commit
            dtgProsesOzellikleri3.DataSource = dtgProsesOzellikleri3_DataTable;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgProsesOzellikleri3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgProsesOzellikleri3.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgProsesOzellikleri3.EnableHeadersVisualStyles = false;
            dtgProsesOzellikleri3.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgProsesOzellikleri3.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);

            if (dtgProsesOzellikleri3_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgProsesOzellikleri3_DataTable.NewRow();
                dr["Dolum Başlangıcındaki PH Değeri"] = Convert.ToString("0", cultureTR);
                dr["Dolum Başlangıcındaki Süt Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Dolum Bittiğindeki PH Değeri"] = Convert.ToString("0", cultureTR);
                dr["Dolum Bittiğindeki Süt Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Toplam Geçen Süre"] = Convert.ToString("0", cultureTR);

                dtgProsesOzellikleri3_DataTable.Rows.Add(dr);
            }
            //dt.Rows.Add();

            dtgProsesOzellikleri3.Columns["Dolum Başlangıcındaki PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri3.Columns["Dolum Başlangıcındaki PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri3.Columns["Dolum Başlangıcındaki Süt Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri3.Columns["Dolum Başlangıcındaki Süt Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri3.Columns["Dolum Bittiğindeki PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri3.Columns["Dolum Bittiğindeki PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri3.Columns["Dolum Bittiğindeki Süt Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri3.Columns["Dolum Bittiğindeki Süt Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri3.Columns["Toplam Geçen Süre"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri3.Columns["Toplam Geçen Süre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgProsesOzellikleri3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgProsesOzellikleri3.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.ReadOnly = true;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;
            DataGridViewColumn dataGridViewColumn = dtgProsesOzellikleri3.Columns["Toplam Geçen Süre"];

            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;


            #region Kontrol listesi oluşturma
            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Dolum Başlangıç Saati",
                kontroledilmesigerekenKolon = "Mayalama Sıcaklığı"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Dolum Başlangıcındaki PH Değeri",
                kontroledilmesigerekenKolon = "Dolum Başlangıç Saati"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Dolum Başlangıcındaki Süt Sıcaklığı",
                kontroledilmesigerekenKolon = "Dolum Başlangıcındaki PH Değeri"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Dolum Bitiş Saati",
                kontroledilmesigerekenKolon = "Dolum Başlangıcındaki Süt Sıcaklığı"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Dolum Bittiğindeki PH Değeri",
                kontroledilmesigerekenKolon = "Dolum Bitiş Saati"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Dolum Bittiğindeki Süt Sıcaklığı",
                kontroledilmesigerekenKolon = "Dolum Bittiğindeki PH Değeri"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Sorumlu Personel",
                kontroledilmesigerekenKolon = "Dolum Bittiğindeki Süt Sıcaklığı"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Toplam Geçen Süre",
                kontroledilmesigerekenKolon = "Sorumlu Personel"
            });
            #endregion
        }

        private void dtgBirinciKulturBilgileriLoad()
        {
            string sql = "Select ISNULL(T1.\"U_KullanilanMik\",0) as \"Kullanılan Miktar\",T1.\"U_TedAdiVeKultKod\" as \"Tedarikçi Adı ve Kültür Kodu\", T1.\"U_LotNo\" as \"Lot No\" from \"@AIF_YGRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_YGRPRSS_ANLZ4\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "' ";
            sql += " and ISNULL(T1.\"U_KullanilanMik\",0)<>0 and ISNULL(T1.\"U_TedAdiVeKultKod\",'')<>'' and ISNULL(T1.\"U_LotNo\",'')<>'' ";

            dtgBirinciKultur_DataTable = new DataTable();
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //DataTable dt_Result = new DataTable();
            sda.Fill(dtgBirinciKultur_DataTable);
            //sda.Fill(dt_Result);

            #region satırda 0 ve null yanii boş kayıt geldiinden alttaki aha önce girilmiş analiz var mı sorgusuna girmiyordu satırlar bu durumda kaldırıldı
            //if (dtgBirinciKultur_DataTable.Rows.Count > 0)
            //{
            //    //double kullanilanmik = Convert.ToDouble(dtgBirinciKultur_DataTable.Rows[0][0]);
            //    //string tedarikci = dtgBirinciKultur_DataTable.Rows[0][0].ToString();
            //    //string lotno = dtgBirinciKultur_DataTable.Rows[0][0].ToString();

            //    //if (kullanilanmik != null && kullanilanmik == 0)
            //    //{
            //    //    dtgBirinciKultur_DataTable.
            //    //}
            //    int i = 1;
            //    foreach (DataRow dr in dtgBirinciKultur_DataTable.Rows)
            //    {
            //        if ((Convert.ToDouble(dr["Kullanılan Miktar"]) != null && Convert.ToDouble(dr["Kullanılan Miktar"]) == 0) && (dr["Tedarikçi Adı ve Kültür Kodu"] != null && dr["Tedarikçi Adı ve Kültür Kodu"].ToString() == "") && (dr["Lot No"] != null && dr["Lot No"] == ""))
            //        {
            //            dr.Delete();
            //        }

            //        i++;
            //    }

            //    dtgBirinciKultur_DataTable.AcceptChanges();
            //}
            #endregion satırda 0 ve null yanii boş kayıt geldiinden alttaki aha önce girilmiş analiz var mı sorgusuna girmiyordu satırlar bu durumda kaldırıldı

            if (dtgBirinciKultur_DataTable.Rows.Count == 0)
            {
                string baseref = txtUretimFisNo.Text;

                sql = "select I1.ItemCode + ' | ' + (Select TOP 1 ttt.CardName from IBT1 as ttt WITH (NOLOCK) where ttt.BatchNum = T2.BatchNum ) as \"Tedarikçi Adı ve Kültür Kodu\" ,SUM(I1.Quantity) as 'Kullanılan Miktar', t2.BatchNum as \"Lot No\"  from IGE1 I1 WITH (NOLOCK) inner join OITM O1 WITH (NOLOCK) ON O1.ItemCode = I1.ItemCode INNER JOIN IBT1 T2 WITH (NOLOCK) ON T2.\"BaseEntry\" = I1.\"DocEntry\" and T2.ItemCode = I1.ItemCode where I1.BaseType = '202' and I1.BaseRef = '" + baseref + "' AND U_AnalizGrubu = '02' group by t2.BatchNum, I1.ItemCode,T2.CardCode";

                cmd = new SqlCommand(sql, Connection.sql);
                sda = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable(); 
                sda.Fill(dtgBirinciKultur_DataTable);

                if (dtgBirinciKultur_DataTable.Rows.Count > 1)
                {
                    int i = 1;
                    foreach (DataRow dr in dtgBirinciKultur_DataTable.Rows)
                    {
                        if (i > 1)
                        {
                            dr.Delete();
                        }

                        i++;
                    }

                    dtgBirinciKultur_DataTable.AcceptChanges();
                }

                #region ESKİ KÜLTÜR GETİRME 20220803
                //sql = "Select \"U_Deger3\" from \"@AIF_GNLKANLZPRM\" where \"U_Kod\" ='6'";
                //cmd = new SqlCommand(sql, Connection.sql);

                //if (Connection.sql.State != ConnectionState.Open)
                //    Connection.sql.Open();

                //sda = new SqlDataAdapter(cmd);
                //DataTable dt_Sorgu = new DataTable();
                //DataTable dt_Line = new DataTable();
                //sda.Fill(dt_Sorgu);

                ////dtgSecim.DataSource = dt;
                ////dtSecim = dt;

                //Connection.sql.Close();

                //if (dt_Sorgu.Rows.Count > 0)
                //{
                //    string uretimdenCikissql = "";

                //    uretimdenCikissql = "Select T1.LineNum ";
                //    uretimdenCikissql += " from ";
                //    uretimdenCikissql += "OIGE T0 ";
                //    uretimdenCikissql += "inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
                //    uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry ";
                //    uretimdenCikissql += "and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry ";
                //    uretimdenCikissql += "inner join OITM T5 ON T5.ItemCode = T2.ItemCode where T0.U_BatchNumber = '" + partiNo + "' and T5.U_ItemGroup3 = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"U_UVTUrunTipi\"='1' order by Case when ISNULL(T1.\"LineNum\",'') = '' then 0 else cast(T1.\"LineNum\" as int) end";

                //    cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
                //    sda = new SqlDataAdapter(cmd);
                //    sda.Fill(dt_Line);

                //    if (dt_Line.Rows.Count > 0)
                //    {
                //        string itemgrp = dt_Sorgu.Rows[0][0].ToString();

                //        uretimdenCikissql = "Select T2.Quantity as \"Kullanılan Miktar\",T1.Dscription as \"Tedarikçi Adı ve Kültür Kodu\",T2.BatchNum as \"Lot No\" ";

                //        //uretimdenCikissql = " (Select T10.CardName from IBT1 T9 ";
                //        //uretimdenCikissql += "inner join OCRD T10 ON T9.CardCode = T10.CardCode where T9.BatchNum = T2.BatchNum) as 'CardName', ";
                //        uretimdenCikissql += " from OIGE T0 ";
                //        uretimdenCikissql += "inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
                //        uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry ";
                //        uretimdenCikissql += "and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry inner join OITM T5 ON T5.ItemCode = T2.ItemCode where T0.U_BatchNumber = '" + partiNo + "' and T5.U_ItemGroup3 = '" + itemgrp + "' and \"U_UVTUrunTipi\"='1' and T1.\"LineNum\" = '" + dt_Line.Rows[0][0].ToString() + "' order by Case when ISNULL(T1.\"LineNum\",'') = '' then 0 else cast(T1.\"LineNum\" as int) end";

                //        cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
                //        sda = new SqlDataAdapter(cmd);

                //        dtgBirinciKultur_DataTable.Rows.Clear();
                //        //dt.Columns.Clear();

                //        //dt_Result.Rows.Clear();
                //        sda.Fill(dtgBirinciKultur_DataTable);
                //    }
                //}
                #endregion
            }

            if (dtgBirinciKultur_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgBirinciKultur_DataTable.NewRow();
                dr["Kullanılan Miktar"] = Convert.ToString("0", cultureTR);

                dtgBirinciKultur_DataTable.Rows.Add(dr);
            }

            Connection.sql.Close();
            //Commit
            dtgBirinciKultur.DataSource = dtgBirinciKultur_DataTable;

            dtgBirinciKultur.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgBirinciKultur.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgBirinciKultur.EnableHeadersVisualStyles = false;
            dtgBirinciKultur.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgBirinciKultur.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1); 
            //dt.Rows.Add();

            dtgBirinciKultur.Columns["Kullanılan Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgBirinciKultur.Columns["Kullanılan Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgBirinciKultur.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgBirinciKultur.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;
        }

        private void dtgIkinciKulturBilgileriLoad()
        {
            string sql = "Select ISNULL(T1.\"U_KullanilanMik\",0) as \"Kullanılan Miktar\",ISNULL(T1.\"U_TedAdiVeKultKod\",'') as \"Tedarikçi Adı ve Kültür Kodu\", ISNULL(T1.\"U_LotNo\",'') as \"Lot No\" from \"@AIF_YGRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_YGRPRSS_ANLZ5\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "' ";
            sql += "and ISNULL(T1.\"U_KullanilanMik\",0)<>0 and ISNULL(T1.\"U_TedAdiVeKultKod\",'')<>'' and ISNULL(T1.\"U_LotNo\",'')<>'' ";
            dtgIkinciKultur_DataTable = new DataTable();
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //DataTable dt_Result = new DataTable();
            sda.Fill(dtgIkinciKultur_DataTable);
            //sda.Fill(dt_Result);

            #region satırda 0 ve null yanii boş kayıt geldiinden alttaki aha önce girilmiş analiz var mı sorgusuna girmiyordu satırlar bu durumda kaldırıldı
            //if (dtgIkinciKultur_DataTable.Rows.Count > 0)
            //{
            //    //double kullanilanmik = Convert.ToDouble(dtgBirinciKultur_DataTable.Rows[0][0]);
            //    //string tedarikci = dtgBirinciKultur_DataTable.Rows[0][0].ToString();
            //    //string lotno = dtgBirinciKultur_DataTable.Rows[0][0].ToString();

            //    //if (kullanilanmik != null && kullanilanmik == 0)
            //    //{
            //    //    dtgBirinciKultur_DataTable.
            //    //}
            //    int i = 1;
            //    foreach (DataRow dr in dtgIkinciKultur_DataTable.Rows)
            //    {
            //        if ((Convert.ToDouble(dr["Kullanılan Miktar"]) != null && Convert.ToDouble(dr["Kullanılan Miktar"]) == 0) && (dr["Tedarikçi Adı ve Kültür Kodu"] != null && dr["Tedarikçi Adı ve Kültür Kodu"].ToString() == "") && (dr["Lot No"] != null && dr["Lot No"] == ""))
            //        {
            //            dr.Delete();
            //        }

            //        i++;
            //    }

            //    dtgIkinciKultur_DataTable.AcceptChanges();
            //}
            #endregion satırda 0 ve null yanii boş kayıt geldiinden alttaki aha önce girilmiş analiz var mı sorgusuna girmiyordu satırlar bu durumda kaldırıldı

            if (dtgIkinciKultur_DataTable.Rows.Count == 0)
            {
                #region daha önce girilmiş analiz var mı sorgu chn 20220803
                string baseref = txtUretimFisNo.Text;
 
                sql = "select I1.ItemCode + ' | ' + (Select TOP 1 ttt.CardName from IBT1 as ttt WITH (NOLOCK) where ttt.BatchNum = T2.BatchNum ) as \"Tedarikçi Adı ve Kültür Kodu\" ,SUM(I1.Quantity) as 'Kullanılan Miktar', t2.BatchNum as \"Lot No\"  from IGE1 I1 WITH (NOLOCK) inner join OITM O1 WITH (NOLOCK) ON O1.ItemCode = I1.ItemCode INNER JOIN IBT1 T2 WITH (NOLOCK) ON T2.\"BaseEntry\" = I1.\"DocEntry\" and T2.ItemCode = I1.ItemCode where I1.BaseType = '202' and I1.BaseRef = '" + baseref + "' AND U_AnalizGrubu = '02' group by t2.BatchNum, I1.ItemCode,T2.CardCode";

                cmd = new SqlCommand(sql, Connection.sql);
                sda = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable(); 
                sda.Fill(dtgIkinciKultur_DataTable);



                if (dtgIkinciKultur_DataTable.Rows.Count >= 1)
                {
                    int i = 1;
                    foreach (DataRow dr in dtgIkinciKultur_DataTable.Rows)
                    {
                        if (i != 2)
                        {
                            dr.Delete();
                        }

                        i++;
                    }

                    dtgIkinciKultur_DataTable.AcceptChanges();
                }

                #endregion
                #region eski kültür getirme 
                //sql = "Select \"U_Deger3\" from \"@AIF_GNLKANLZPRM\" where \"U_Kod\" ='6'";
                //cmd = new SqlCommand(sql, Connection.sql);

                //if (Connection.sql.State != ConnectionState.Open)
                //    Connection.sql.Open();

                //sda = new SqlDataAdapter(cmd);
                //DataTable dt_Sorgu = new DataTable();
                //DataTable dt_Line = new DataTable();
                //sda.Fill(dt_Sorgu);

                ////dtgSecim.DataSource = dt;
                ////dtSecim = dt;

                //Connection.sql.Close();

                //if (dt_Sorgu.Rows.Count > 0)
                //{
                //    string uretimdenCikissql = "";

                //    uretimdenCikissql = "Select T1.LineNum ";
                //    uretimdenCikissql += " from ";
                //    uretimdenCikissql += "OIGE T0 ";
                //    uretimdenCikissql += "inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
                //    uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry ";
                //    uretimdenCikissql += "and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry ";
                //    uretimdenCikissql += "inner join OITM T5 ON T5.ItemCode = T2.ItemCode where T0.U_BatchNumber = '" + partiNo + "' and T5.U_ItemGroup3 = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"U_UVTUrunTipi\"='1' order by Case when ISNULL(T1.\"LineNum\",'') = '' then 0 else cast(T1.\"LineNum\" as int) end";

                //    cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
                //    sda = new SqlDataAdapter(cmd);
                //    sda.Fill(dt_Line);

                //    if (dt_Line.Rows.Count > 1)
                //    {
                //        string itemgrp = dt_Sorgu.Rows[0][0].ToString();

                //        uretimdenCikissql = "Select T2.Quantity as \"Kullanılan Miktar\",T1.Dscription as \"Tedarikçi Adı ve Kültür Kodu\",T2.BatchNum as \"Lot No\" ";

                //        //uretimdenCikissql = " (Select T10.CardName from IBT1 T9 ";
                //        //uretimdenCikissql += "inner join OCRD T10 ON T9.CardCode = T10.CardCode where T9.BatchNum = T2.BatchNum) as 'CardName', ";
                //        uretimdenCikissql += " from OIGE T0 ";
                //        uretimdenCikissql += "inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
                //        uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry ";
                //        uretimdenCikissql += "and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry inner join OITM T5 ON T5.ItemCode = T2.ItemCode where T0.U_BatchNumber = '" + partiNo + "' and T5.U_ItemGroup3 = '" + itemgrp + "' and \"U_UVTUrunTipi\"='1' and T1.\"LineNum\" > '" + dt_Line.Rows[0][0].ToString() + "'";

                //        cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
                //        sda = new SqlDataAdapter(cmd);

                //        dtgIkinciKultur_DataTable.Rows.Clear();
                //        //dt.Columns.Clear();

                //        //dt_Result.Rows.Clear();
                //        sda.Fill(dtgIkinciKultur_DataTable);
                //    }
                //} 
                #endregion
            }


            if (dtgIkinciKultur_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgIkinciKultur_DataTable.NewRow();
                dr["Kullanılan Miktar"] = Convert.ToString("0", cultureTR);

                dtgIkinciKultur_DataTable.Rows.Add(dr);
            }

            Connection.sql.Close();

            //Commit
            dtgIkinciKultur.DataSource = dtgIkinciKultur_DataTable;

            dtgIkinciKultur.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgIkinciKultur.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgIkinciKultur.EnableHeadersVisualStyles = false;
            dtgIkinciKultur.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgIkinciKultur.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);

            //dt.Rows.Add();

            dtgIkinciKultur.Columns["Kullanılan Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgIkinciKultur.Columns["Kullanılan Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgIkinciKultur.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgIkinciKultur.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;
        }

        private void dtgSutunOzellikleriLoad_IkinciEkran()
        {
            //string sql = "Select T1.\"ItemCode\" as \"Malzeme Kodu\",T1.\"Dscription\" as \"Malzeme Tanımı\", SUM(T1.\"Quantity\") as \"Miktar\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' group by T1.\"ItemCode\",T1.\"Dscription\"";

            string sql = "Select T1.\"U_SutTuru\" as \"Süt Türü\",T1.\"U_SutunKaynagi\" as \"Sütün Kaynağı\", T1.\"U_Brix\" as \"Brix\", T1.\"U_PH\" as \"PH\", T1.\"U_SH\" as \"SH\", T1.\"U_Yag\" as \"Yağ\" from \"@AIF_YGRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_YGRPRSS_ANLZ6\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtgSutunOzellikleri_DataTable);

            if (dtgSutunOzellikleri_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgSutunOzellikleri_DataTable.NewRow();
                dr["Süt Türü"] = Convert.ToString("Yağlı", cultureTR);
                dr["Brix"] = Convert.ToString("0", cultureTR);
                dr["PH"] = Convert.ToString("0", cultureTR);
                dr["SH"] = Convert.ToString("0", cultureTR);
                dr["Yağ"] = Convert.ToString("0", cultureTR);

                dtgSutunOzellikleri_DataTable.Rows.Add(dr);

                dr = dtgSutunOzellikleri_DataTable.NewRow();
                dr["Süt Türü"] = Convert.ToString("Yağsız", cultureTR);
                dr["Brix"] = Convert.ToString("0", cultureTR);
                dr["PH"] = Convert.ToString("0", cultureTR);
                dr["SH"] = Convert.ToString("0", cultureTR);
                dr["Yağ"] = Convert.ToString("0", cultureTR);

                dtgSutunOzellikleri_DataTable.Rows.Add(dr);
            }
            //dt.Rows.Add();

        }

        private void dtgYariMamulKaliteOzellikleriLoad_IkinciEkran()
        {
            //string sql = "Select T1.\"ItemCode\" as \"Malzeme Kodu\",T1.\"Dscription\" as \"Malzeme Tanımı\", SUM(T1.\"Quantity\") as \"Miktar\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' group by T1.\"ItemCode\",T1.\"Dscription\"";

            string sql = "Select T1.\"U_PartiNo\" as \"Parti No\",T1.\"U_TKM\" as \"TKM\", T1.\"U_Protein\" as \"Protein\", T1.\"U_Tuz\" as \"Tuz\", T1.\"U_Brix\" as \"Brix\", T1.\"U_PH\" as \"PH\", T1.\"U_SH\" as \"SH\", T1.\"U_Yag\" as \"Yağ\", T1.\"U_TatKokuKivam\" as \"Tat Koku ve Kıvamı\" from \"@AIF_YGRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_YGRPRSS_ANLZ7\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtgYariMamulKaliteOzellikleri_DataTable);

            if (dtgYariMamulKaliteOzellikleri_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgYariMamulKaliteOzellikleri_DataTable.NewRow();
                dr["TKM"] = Convert.ToString("0", cultureTR);
                dr["Protein"] = Convert.ToString("0", cultureTR);
                dr["Tuz"] = Convert.ToString("0", cultureTR);
                dr["Brix"] = Convert.ToString("0", cultureTR);
                dr["PH"] = Convert.ToString("0", cultureTR);
                dr["SH"] = Convert.ToString("0", cultureTR);
                dr["Yağ"] = Convert.ToString("0", cultureTR);

                dtgYariMamulKaliteOzellikleri_DataTable.Rows.Add(dr);
            }
            //dt.Rows.Add(); 
        }

        private void dtgInkubasyonTakipOzellikleriLoad_IkinciEkran()
        {
            //string sql = "Select T1.\"ItemCode\" as \"Malzeme Kodu\",T1.\"Dscription\" as \"Malzeme Tanımı\", SUM(T1.\"Quantity\") as \"Miktar\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' group by T1.\"ItemCode\",T1.\"Dscription\"";

            string sql = "Select T1.\"U_KontrolNo\" as \"Kontrol No\",T1.\"U_Saat\" as \"Saat\", T1.\"U_Sicaklik\" as \"Sıcaklık\", T1.\"U_PH\" as \"PH\", T1.\"U_KontrolEdenPers\" as \"Kontrol Eden Personel\" from \"@AIF_YGRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_YGRPRSS_ANLZ8\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtgInkubasyonTakip_DataTable);

            if (dtgInkubasyonTakip_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgInkubasyonTakip_DataTable.NewRow();
                dr["Kontrol No"] = Convert.ToString("1", cultureTR);
                dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                dr["PH"] = Convert.ToString("0", cultureTR);

                dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("2", cultureTR);
                //dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("3", cultureTR);
                //dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("4", cultureTR);
                //dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("5", cultureTR);
                //dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);
            }
            //dt.Rows.Add(); 


            #region Kontrol listesi oluşturma 

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Saat",
                kontroledilmesigerekenKolon = "Toplam Geçen Süre"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Sıcaklık",
                kontroledilmesigerekenKolon = "Saat"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "PH",
                kontroledilmesigerekenKolon = "Sıcaklık"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Kontrol Eden Personel",
                kontroledilmesigerekenKolon = "PH"
            });

            #endregion

        }

        private void button10_Click(object sender, EventArgs e) //açıklama
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();
        }

        private void button11_Click(object sender, EventArgs e) //sağa git
        {
            PartyNo = txtPartiNo.Text;
            UretimSiparisNo = txtUretimFisNo.Text;
            UretilenUrunTanimi = txtUrunTanimi.Text;
            UretimAciklamasi = txtAciklama.Text;
            YogurtProsesTakip_1_1 nesne = new YogurtProsesTakip_1_1(type, kullaniciid, UretimFisNo, partiNo, UrunTanimi, istasyon, row, tarih1, UrunGrubu, dtgProsesOzellikleri1_DataTable, dtgProsesOzellikleri2_DataTable, dtgBirinciKultur_DataTable, dtgProsesOzellikleri3_DataTable, dtgIkinciKultur_DataTable, dtgSutunOzellikleri_DataTable, dtgYariMamulKaliteOzellikleri_DataTable, dtgInkubasyonTakip_DataTable, txtAciklama);
            nesne.ShowDialog();
            //txtAciklama.Text = UretimAciklamasi;

            if (YogurtProsesTakip_1_1.geriDonme == "OzeteDon")
            {
                btnOzetEkranaDon.PerformClick();
            }
        }

        public static List<kontrolListesi> kontrolListesis = new List<kontrolListesi>();
        public class kontrolListesi
        {
            public string aktifKolon { get; set; }
            public string kontroledilmesigerekenKolon { get; set; }
        }

        public static bool Kontrol(string _kontroledilmesigerekenKolon, DataGridView dtg, DataGridView dtg2, DataTable dt = null)
        {

            string temelkolon = kontrolListesis.Where(x => x.aktifKolon == _kontroledilmesigerekenKolon).Select(y => y.kontroledilmesigerekenKolon).FirstOrDefault();


            if (temelkolon != null)
            {
                string val = "";

                if (dt != null)
                {
                    val = dt.Rows[0][dt.Columns.Count - 1].ToString();
                }
                else if (dtg2 != null)
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

                        if (dt != null)
                        {
                            val2 = Convert.ToDouble(dt.Rows[0][dt.Columns.Count - 1]);
                        }
                        else if (dtg2 != null)
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

        //public static bool tarihKontrol(string value1 )
        //{

        //}

        private void dtgProsesOzellikleri1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Proses Başlangıç Saati")
            {
                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, true);
                //n.ShowDialog();

                SaatTarihGirisi n = new SaatTarihGirisi(dtgProsesOzellikleri1);
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
            else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yağlı Süt Miktarı" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yağsız Süt Miktarı" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Kullanılan Krema Miktarı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                n.ShowDialog();

                //if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Net Süt Miktarı LT")
                //{
                //var netSutMiktari = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value);
                //var birgunSonraTartilan = dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                //if (netSutMiktari > 0 && birgunSonraTartilan > 0)
                //{
                //    var sonuc = netSutMiktari / birgunSonraTartilan;
                //    dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc.ToString();

                //}
                //}
            }
            //else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Görevli Operatör Adı")
            //{
            //    if (istasyon.StartsWith("IST"))
            //    {
            //        //string sql = "Select \"empID\" as \"Kullanıcı Kodu\", (\"firstName\" + ' ' + \"lastName\") as 'Ad Soyad' from OHEM where \"Active\" = 'Y'";

            //        string field = "U_" + istasyon;

            //        DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
            //        string gunfield = "U_Gun" + dtTarih.Day;

            //        string sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

            //        //string sql = "Select \"U_PersonelNo\" as \"Personel No\",\"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"" + field + "\" = 'Y'";

            //        SelectList selectList = new SelectList(sql, dtgProsesOzellikleri1, 2, 3, _autoresizerow: false);
            //        selectList.ShowDialog();

            //        //dtgProsesOzellikleri1.AutoResizeRows();
            //    }
            //}
            //else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Esanjör ve Tank Filtre Kont.")
            //{
            //    string sql = "Select '0' as \"Kod\",'Uygun Değil' as \"Aciklama\" ";
            //    sql += " UNION ALL ";
            //    sql += "Select '1' as \"Kod\",'Uygun' as \"Aciklama\" ";

            //    SelectList selectList = new SelectList(sql, dtgProsesOzellikleri1, -1, 8, _autoresizerow: false);
            //    selectList.ShowDialog();

            //    //dtgProsesOzellikleri1.AutoResizeRows();
            //}
        }

        private void dtgProsesOzellikleri2_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            bool cvp = Kontrol(dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name, dtgProsesOzellikleri2, null);


            if (!cvp)
            {
                return;
            }


            if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Vakum Başlangıç Saati" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Vakum Bitiş Saati" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Mayalama Saati")
            {
                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, true);
                //n.ShowDialog();

                SaatTarihGirisi n = new SaatTarihGirisi(dtgProsesOzellikleri2);
                n.ShowDialog();


                if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Vakum Bitiş Saati")
                {
                    Tuple<DateTime, DateTime> resp = null;
                    Helper help = new Helper();
                    var baslangicSaati = dtgProsesOzellikleri2.Rows[e.RowIndex].Cells["Vakum Bitiş Saati"].Value.ToString();
                    var bitisSaati = dtgProsesOzellikleri3.Rows[0].Cells["Dolum Bitiş Saati"].Value.ToString();

                    if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                    {
                        resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                        TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                        dtgProsesOzellikleri3.Rows[0].Cells["Toplam Geçen Süre"].Value = girisCikisFarki.TotalMinutes.ToString();
                    }
                    else
                    {
                        dtgProsesOzellikleri3.Rows[0].Cells["Toplam Geçen Süre"].Value = "0";
                    }

                }

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
            else if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Vakum Sonu Brix Değeri" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Pastörizasyon Sıcaklığı" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Mayalama PH Değeri" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Mayalama Sıcaklığı" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Pastörizasyon Süresi")
            {

                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri2, false);
                n.ShowDialog();

                //if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Net Süt Miktarı LT")
                //{
                //var netSutMiktari = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value);
                //var birgunSonraTartilan = dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                //if (netSutMiktari > 0 && birgunSonraTartilan > 0)
                //{
                //    var sonuc = netSutMiktari / birgunSonraTartilan;
                //    dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc.ToString();

                //}
                //}
            }
        }

        private void dtgProsesOzellikleri3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool cvp = true;
            if (dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name == "Dolum Başlangıç Saati")
            {
                cvp = Kontrol(dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name, dtgProsesOzellikleri3, dtgProsesOzellikleri2);
            }
            else
            {
                cvp = Kontrol(dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name, dtgProsesOzellikleri3, null);
            }

            if (!cvp)
            {
                return;
            }
            if (dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name == "Dolum Başlangıç Saati" || dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name == "Dolum Bitiş Saati" || dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name == "Mayalama Saati")
            {
                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, true);
                //n.ShowDialog();

                SaatTarihGirisi n = new SaatTarihGirisi(dtgProsesOzellikleri3);
                n.ShowDialog();


                if (dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name == "Dolum Başlangıç Saati" || dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name == "Dolum Bitiş Saati" && e.RowIndex != -1)
                {
                    Tuple<DateTime, DateTime> resp = null;
                    Helper help = new Helper();
                    var baslangicSaati = dtgProsesOzellikleri2.Rows[e.RowIndex].Cells["Vakum Bitiş Saati"].Value.ToString();
                    var bitisSaati = dtgProsesOzellikleri3.Rows[e.RowIndex].Cells["Dolum Bitiş Saati"].Value.ToString();

                    if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                    {
                        resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                        TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                        dtgProsesOzellikleri3.Rows[0].Cells["Toplam Geçen Süre"].Value = girisCikisFarki.TotalMinutes.ToString();
                    }
                    else
                    {
                        dtgProsesOzellikleri3.Rows[0].Cells["Toplam Geçen Süre"].Value = "0";
                    }

                }
            }
            else if (dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name == "Dolum Başlangıcındaki PH Değeri" || dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name == "Dolum Başlangıcındaki Süt Sıcaklığı" || dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name == "Dolum Bittiğindeki PH Değeri" || dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name == "Dolum Bittiğindeki Süt Sıcaklığı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri3, false);
                n.ShowDialog();

                //if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Net Süt Miktarı LT")
                //{
                //var netSutMiktari = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value);
                //var birgunSonraTartilan = dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                //if (netSutMiktari > 0 && birgunSonraTartilan > 0)
                //{
                //    var sonuc = netSutMiktari / birgunSonraTartilan;
                //    dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc.ToString();

                //}
                //}
            }
            else if (dtgProsesOzellikleri3.Columns[e.ColumnIndex].Name == "Sorumlu Personel")
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

                    SelectList selectList = new SelectList(sql1, dtgProsesOzellikleri3, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();

                    //dtgProsesOzellikleri1.AutoResizeRows();
                }
            }
        }

        private void dtgBirinciKultur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgBirinciKultur.Columns[e.ColumnIndex].Name == "Kullanılan Miktar")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgBirinciKultur, false);
                n.ShowDialog();

                //if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Net Süt Miktarı LT")
                //{
                //var netSutMiktari = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value);
                //var birgunSonraTartilan = dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                //if (netSutMiktari > 0 && birgunSonraTartilan > 0)
                //{
                //    var sonuc = netSutMiktari / birgunSonraTartilan;
                //    dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc.ToString();

                //}
                //}
            }
        }

        private void dtgIkinciKultur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgIkinciKultur.Columns[e.ColumnIndex].Name == "Kullanılan Miktar")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgIkinciKultur, false);
                n.ShowDialog();

                //if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Net Süt Miktarı LT")
                //{
                //var netSutMiktari = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value);
                //var birgunSonraTartilan = dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                //if (netSutMiktari > 0 && birgunSonraTartilan > 0)
                //{
                //    var sonuc = netSutMiktari / birgunSonraTartilan;
                //    dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc.ToString();

                //}
                //}
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            PartyNo = txtPartiNo.Text;
            UretimSiparisNo = txtUretimFisNo.Text;
            UretilenUrunTanimi = txtUrunTanimi.Text;
            UretimAciklamasi = txtAciklama.Text;
            //TabloyaKaydet();
            tabloyaKaydetmeIslemleri();
        }

        #region eski tabloya kaydetme işlemi
        public static void TabloyaKaydet()
        {
            //YogurtProsesOzellikleri1s = new List<YogurtProsesOzellikleri1>();
            //YogurtProsesOzellikleri2s = new List<YogurtProsesOzellikleri2>();
            //yogurtProsesOzellikleri3s = new List<YogurtProsesOzellikleri3>();
            //YogurtBirinciKulturs = new List<YogurtBirinciKultur>();
            //YogurtIkinciKulturs = new List<YogurtIkinciKultur>();
            //YogurtTuzOzellikleris = new List<YogurtTuzOzellikleri>();
            //YogurtSutOzellikleris = new List<YogurtSutOzellikleri>();
            //YogurtYariMamulKaliteOzellikleris = new List<YogurtYariMamulKaliteOzellikleri>();
            //YogurtInkubasyonOzellikleris = new List<YogurtInkubasyonOzellikleri>();

            //nesne.PartiNo = PartyNo;
            //nesne.Aciklama = UretimAciklamasi;
            //nesne.UrunKodu = "";
            //nesne.UrunTanimi = UretilenUrunTanimi;
            //nesne.UretimTarihi = tarih1;

            //foreach (DataGridViewRow dr in dtgProsesOzellikleri1Static.Rows)
            //{
            //    YogurtProsesOzellikleri1 = new YogurtProsesOzellikleri1();
            //    YogurtProsesOzellikleri1.UrunGrubu = dr.Cells["Ürün Grubu"].Value == DBNull.Value ? "" : dr.Cells["Ürün Grubu"].Value.ToString();
            //    YogurtProsesOzellikleri1.InkubasyonNo = dr.Cells["Inkübasyon Oda No"].Value == DBNull.Value ? "" : dr.Cells["Inkübasyon Oda No"].Value.ToString();
            //    YogurtProsesOzellikleri1.ProsesBaslangicSaati = dr.Cells["Proses Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Proses Başlangıç Saati"].Value.ToString();
            //    YogurtProsesOzellikleri1.YagliSutMiktari = dr.Cells["Yağlı Süt Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağlı Süt Miktarı"].Value);
            //    YogurtProsesOzellikleri1.YagsizSutMiktari = dr.Cells["Yağsız Süt Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağsız Süt Miktarı"].Value);
            //    YogurtProsesOzellikleri1.KullanilanKremaMiktari = dr.Cells["Kullanılan Krema Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kullanılan Krema Miktarı"].Value);

            //    YogurtProsesOzellikleri1s.Add(YogurtProsesOzellikleri1);
            //}

            //nesne.YogurtProsesOzellikleri1s = YogurtProsesOzellikleri1s.ToArray();

            //foreach (DataGridViewRow dr in dtgProsesOzellikleri2Static.Rows)
            //{
            //    YogurtProsesOzellikleri2 = new YogurtProsesOzellikleri2();
            //    YogurtProsesOzellikleri2.VakumBaslangicSaati = dr.Cells["Vakum Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Vakum Başlangıç Saati"].Value.ToString();
            //    YogurtProsesOzellikleri2.VakumBitisSaati = dr.Cells["Vakum Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Vakum Bitiş Saati"].Value.ToString();
            //    YogurtProsesOzellikleri2.VakumSonuSutBrixDegeri = dr.Cells["Vakum Sonu Brix Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Vakum Sonu Brix Değeri"].Value);
            //    YogurtProsesOzellikleri2.PastorizasyonSicakligi = dr.Cells["Pastörizasyon Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastörizasyon Sıcaklığı"].Value);
            //    YogurtProsesOzellikleri2.PastorizasyonSuresi = dr.Cells["Pastörizasyon Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastörizasyon Süresi"].Value);
            //    YogurtProsesOzellikleri2.MayalamaSaati = dr.Cells["Mayalama Saati"].Value == DBNull.Value ? "" : dr.Cells["Mayalama Saati"].Value.ToString();
            //    YogurtProsesOzellikleri2.MayalamaPHDegeri = dr.Cells["Mayalama PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Mayalama PH Değeri"].Value);
            //    YogurtProsesOzellikleri2.MayalamaSicakligi = dr.Cells["Mayalama Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Mayalama Sıcaklığı"].Value);

            //    YogurtProsesOzellikleri2s.Add(YogurtProsesOzellikleri2);
            //}

            //nesne.YogurtProsesOzellikleri2s = YogurtProsesOzellikleri2s.ToArray();

            //foreach (DataGridViewRow dr in dtgProsesOzellikleri3Static.Rows)
            //{
            //    YogurtProsesOzellikleri3 = new YogurtProsesOzellikleri3();
            //    YogurtProsesOzellikleri3.DolumBaslangicSaati = dr.Cells["Dolum Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Dolum Başlangıç Saati"].Value.ToString();
            //    YogurtProsesOzellikleri3.DolumBaslangicindakiPHDegeri = dr.Cells["Dolum Başlangıcındaki PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Dolum Başlangıcındaki PH Değeri"].Value);
            //    YogurtProsesOzellikleri3.DolumBaslangicindakiSutSicakligi = dr.Cells["Dolum Başlangıcındaki Süt Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Dolum Başlangıcındaki Süt Sıcaklığı"].Value);
            //    YogurtProsesOzellikleri3.DolumBitisSaati = dr.Cells["Dolum Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Dolum Bitiş Saati"].Value.ToString();
            //    YogurtProsesOzellikleri3.DolumBittigindekiPHDegeri = dr.Cells["Dolum Bittiğindeki PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Dolum Bittiğindeki PH Değeri"].Value);
            //    YogurtProsesOzellikleri3.DolumBittigindekiSutSicakligi = dr.Cells["Dolum Bittiğindeki Süt Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Dolum Bittiğindeki Süt Sıcaklığı"].Value);
            //    YogurtProsesOzellikleri3.SorumluPersonel = dr.Cells["Sorumlu Personel"].Value == DBNull.Value ? "" : dr.Cells["Sorumlu Personel"].Value.ToString();
            //    YogurtProsesOzellikleri3.DolumBittigindekiSutSicakligi = dr.Cells["Toplam Geçen Süre"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Geçen Süre"].Value);

            //    yogurtProsesOzellikleri3s.Add(YogurtProsesOzellikleri3);
            //}

            //nesne.YogurtProsesOzellikleri3s = yogurtProsesOzellikleri3s.ToArray();

            //foreach (DataGridViewRow dr in dtgBirinciKulturBilgileriStatic.Rows)
            //{
            //    YogurtBirinciKultur = new YogurtBirinciKultur();

            //    YogurtBirinciKultur.KullanilanMiktar = dr.Cells["Kullanılan Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kullanılan Miktar"].Value);
            //    YogurtBirinciKultur.TedarikciAdiveKulturKodu = dr.Cells["Tedarikçi Adı ve Kültür Kodu"].Value == DBNull.Value ? "" : dr.Cells["Tedarikçi Adı ve Kültür Kodu"].Value.ToString();
            //    YogurtBirinciKultur.LotNo = dr.Cells["Lot No"].Value == DBNull.Value ? "" : dr.Cells["Lot No"].Value.ToString();

            //    YogurtBirinciKulturs.Add(YogurtBirinciKultur);
            //}

            //nesne.YogurtBirinciKulturs = YogurtBirinciKulturs.ToArray();

            //foreach (DataGridViewRow dr in dtgIkinciKulturBilgileriStatic.Rows)
            //{
            //    YogurtIkinciKultur = new YogurtIkinciKultur();

            //    YogurtIkinciKultur.KullanilanMiktar = dr.Cells["Kullanılan Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kullanılan Miktar"].Value);
            //    YogurtIkinciKultur.TedarikciAdiveKulturKodu = dr.Cells["Tedarikçi Adı ve Kültür Kodu"].Value == DBNull.Value ? "" : dr.Cells["Tedarikçi Adı ve Kültür Kodu"].Value.ToString();
            //    YogurtIkinciKultur.LotNo = dr.Cells["Lot No"].Value == DBNull.Value ? "" : dr.Cells["Lot No"].Value.ToString();

            //    YogurtIkinciKulturs.Add(YogurtIkinciKultur);
            //}

            //nesne.YogurtIkinciKulturs = YogurtIkinciKulturs.ToArray();

            //foreach (DataGridViewRow dr in dtgSutunOzellikleriStatic.Rows)
            //{
            //    YogurtSutOzellikleri = new YogurtSutOzellikleri();

            //    YogurtSutOzellikleri.SutTuru = dr.Cells["Süt Türü"].Value == DBNull.Value ? "" : dr.Cells["Süt Türü"].Value.ToString();
            //    YogurtSutOzellikleri.SutunKaynagi = dr.Cells["Sütün Kaynağı"].Value == DBNull.Value ? "" : dr.Cells["Sütün Kaynağı"].Value.ToString();
            //    YogurtSutOzellikleri.Brix = dr.Cells["Brix"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Brix"].Value);
            //    YogurtSutOzellikleri.PH = dr.Cells["PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH"].Value);
            //    YogurtSutOzellikleri.SH = dr.Cells["SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH"].Value);
            //    YogurtSutOzellikleri.Yag = dr.Cells["Yağ"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ"].Value);

            //    YogurtSutOzellikleris.Add(YogurtSutOzellikleri);
            //}

            //nesne.YogurtSutOzellikleris = YogurtSutOzellikleris.ToArray();

            //foreach (DataGridViewRow dr in dtgYariMamulKaliteOzellikleriStatic.Rows)
            //{
            //    YogurtYariMamulKaliteOzellikleri = new YogurtYariMamulKaliteOzellikleri();
            //    YogurtYariMamulKaliteOzellikleri.PartiNo = dr.Cells["Parti No"].Value == DBNull.Value ? "" : dr.Cells["Parti No"].Value.ToString();
            //    YogurtYariMamulKaliteOzellikleri.TKM = dr.Cells["TKM"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["TKM"].Value);
            //    YogurtYariMamulKaliteOzellikleri.Protein = dr.Cells["Protein"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Protein"].Value);
            //    YogurtYariMamulKaliteOzellikleri.Tuz = dr.Cells["Tuz"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tuz"].Value);
            //    YogurtYariMamulKaliteOzellikleri.Brix = dr.Cells["Brix"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Brix"].Value);
            //    YogurtYariMamulKaliteOzellikleri.PH = dr.Cells["PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH"].Value);
            //    YogurtYariMamulKaliteOzellikleri.SH = dr.Cells["SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH"].Value);
            //    YogurtYariMamulKaliteOzellikleri.Yag = dr.Cells["Yağ"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ"].Value);
            //    YogurtYariMamulKaliteOzellikleri.TatKokuKivam = dr.Cells["Tat Koku ve Kıvamı"].Value == DBNull.Value ? "" : dr.Cells["Tat Koku ve Kıvamı"].Value.ToString();

            //    YogurtYariMamulKaliteOzellikleris.Add(YogurtYariMamulKaliteOzellikleri);
            //}

            //nesne.YogurtYariMamulKaliteOzellikleris = YogurtYariMamulKaliteOzellikleris.ToArray();

            //foreach (DataGridViewRow dr in dtgInkubasyonTakipStatic.Rows)
            //{
            //    YogurtInkubasyonOzellikleri = new YogurtInkubasyonOzellikleri();
            //    YogurtInkubasyonOzellikleri.KontrolNo = dr.Cells["Kontrol No"].Value == DBNull.Value ? "" : dr.Cells["Kontrol No"].Value.ToString();
            //    YogurtInkubasyonOzellikleri.Saat = dr.Cells["Saat"].Value == DBNull.Value ? "" : dr.Cells["Saat"].Value.ToString();
            //    YogurtInkubasyonOzellikleri.Sicaklik = dr.Cells["Sıcaklık"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Sıcaklık"].Value);
            //    YogurtInkubasyonOzellikleri.PH = dr.Cells["PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH"].Value);
            //    YogurtInkubasyonOzellikleri.KontrolEdenPersonel = dr.Cells["Kontrol Eden Personel"].Value == DBNull.Value ? "" : dr.Cells["Kontrol Eden Personel"].Value.ToString();

            //    YogurtInkubasyonOzellikleris.Add(YogurtInkubasyonOzellikleri);
            //}

            //nesne.YogurtInkubasyonOzellikleris = YogurtInkubasyonOzellikleris.ToArray();

            //var resp = client.AddOrUpdateYogurtProsesTakipAnaliz(nesne, Giris.dbName);

            //MessageBox.Show(resp.Description);

            //if (resp.Value == 0)
            //{
            //    btnOzet.PerformClick();
            //}
        }
        #endregion

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }

        public void tabloyaKaydetmeIslemleri()
        {
            try
            {
                YogurtProsesTakipAnaliz nesne = new YogurtProsesTakipAnaliz();
                YogurtProsesOzellikleri1 YogurtProsesOzellikleri1 = new YogurtProsesOzellikleri1();
                List<YogurtProsesOzellikleri1> YogurtProsesOzellikleri1s = new List<YogurtProsesOzellikleri1>();
                YogurtProsesOzellikleri2 YogurtProsesOzellikleri2 = new YogurtProsesOzellikleri2();
                List<YogurtProsesOzellikleri2> YogurtProsesOzellikleri2s = new List<YogurtProsesOzellikleri2>();
                YogurtProsesOzellikleri3 YogurtProsesOzellikleri3 = new YogurtProsesOzellikleri3();
                List<YogurtProsesOzellikleri3> yogurtProsesOzellikleri3s = new List<YogurtProsesOzellikleri3>();
                YogurtBirinciKultur YogurtBirinciKultur = new YogurtBirinciKultur();
                List<YogurtBirinciKultur> YogurtBirinciKulturs = new List<YogurtBirinciKultur>();
                YogurtIkinciKultur YogurtIkinciKultur = new YogurtIkinciKultur();
                List<YogurtIkinciKultur> YogurtIkinciKulturs = new List<YogurtIkinciKultur>();
                YogurtTuzOzellikleri YogurtTuzOzellikleri = new YogurtTuzOzellikleri();
                List<YogurtTuzOzellikleri> YogurtTuzOzellikleris = new List<YogurtTuzOzellikleri>();
                YogurtSutOzellikleri YogurtSutOzellikleri = new YogurtSutOzellikleri();
                List<YogurtSutOzellikleri> YogurtSutOzellikleris = new List<YogurtSutOzellikleri>();
                YogurtYariMamulKaliteOzellikleri YogurtYariMamulKaliteOzellikleri = new YogurtYariMamulKaliteOzellikleri();
                List<YogurtYariMamulKaliteOzellikleri> YogurtYariMamulKaliteOzellikleris = new List<YogurtYariMamulKaliteOzellikleri>();
                YogurtInkubasyonOzellikleri YogurtInkubasyonOzellikleri = new YogurtInkubasyonOzellikleri();
                List<YogurtInkubasyonOzellikleri> YogurtInkubasyonOzellikleris = new List<YogurtInkubasyonOzellikleri>();

                nesne.PartiNo = PartyNo;
                nesne.Aciklama = UretimAciklamasi;
                nesne.UrunKodu = "";
                nesne.UrunTanimi = UretilenUrunTanimi;
                nesne.UretimTarihi = tarih1;

                foreach (DataRow dr in dtgProsesOzellikleri1_DataTable.Rows)
                {
                    YogurtProsesOzellikleri1 = new YogurtProsesOzellikleri1();
                    YogurtProsesOzellikleri1.UrunGrubu = dr["Ürün Grubu"] == DBNull.Value ? "" : dr["Ürün Grubu"].ToString();
                    YogurtProsesOzellikleri1.InkubasyonNo = dr["Inkübasyon Oda No"] == DBNull.Value ? "" : dr["Inkübasyon Oda No"].ToString();
                    YogurtProsesOzellikleri1.ProsesBaslangicSaati = dr["Proses Başlangıç Saati"] == DBNull.Value ? "" : dr["Proses Başlangıç Saati"].ToString();
                    YogurtProsesOzellikleri1.YagliSutMiktari = dr["Yağlı Süt Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağlı Süt Miktarı"]);
                    YogurtProsesOzellikleri1.YagsizSutMiktari = dr["Yağsız Süt Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağsız Süt Miktarı"]);
                    YogurtProsesOzellikleri1.KullanilanKremaMiktari = dr["Kullanılan Krema Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kullanılan Krema Miktarı"]);

                    YogurtProsesOzellikleri1s.Add(YogurtProsesOzellikleri1);
                }

                nesne.YogurtProsesOzellikleri1s = YogurtProsesOzellikleri1s.ToArray();

                foreach (DataRow dr in dtgProsesOzellikleri2_DataTable.Rows)
                {
                    YogurtProsesOzellikleri2 = new YogurtProsesOzellikleri2();
                    YogurtProsesOzellikleri2.VakumBaslangicSaati = dr["Vakum Başlangıç Saati"] == DBNull.Value ? "" : dr["Vakum Başlangıç Saati"].ToString();
                    YogurtProsesOzellikleri2.VakumBitisSaati = dr["Vakum Bitiş Saati"] == DBNull.Value ? "" : dr["Vakum Bitiş Saati"].ToString();
                    YogurtProsesOzellikleri2.VakumSonuSutBrixDegeri = dr["Vakum Sonu Brix Değeri"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Vakum Sonu Brix Değeri"]);
                    YogurtProsesOzellikleri2.PastorizasyonSicakligi = dr["Pastörizasyon Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastörizasyon Sıcaklığı"]);
                    YogurtProsesOzellikleri2.PastorizasyonSuresi = dr["Pastörizasyon Süresi"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastörizasyon Süresi"]);
                    YogurtProsesOzellikleri2.MayalamaSaati = dr["Mayalama Saati"] == DBNull.Value ? "" : dr["Mayalama Saati"].ToString();
                    YogurtProsesOzellikleri2.MayalamaPHDegeri = dr["Mayalama PH Değeri"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Mayalama PH Değeri"]);
                    YogurtProsesOzellikleri2.MayalamaSicakligi = dr["Mayalama Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Mayalama Sıcaklığı"]);

                    YogurtProsesOzellikleri2s.Add(YogurtProsesOzellikleri2);
                }

                nesne.YogurtProsesOzellikleri2s = YogurtProsesOzellikleri2s.ToArray();

                foreach (DataRow dr in dtgProsesOzellikleri3_DataTable.Rows)
                {
                    YogurtProsesOzellikleri3 = new YogurtProsesOzellikleri3();
                    YogurtProsesOzellikleri3.DolumBaslangicSaati = dr["Dolum Başlangıç Saati"] == DBNull.Value ? "" : dr["Dolum Başlangıç Saati"].ToString();
                    YogurtProsesOzellikleri3.DolumBaslangicindakiPHDegeri = dr["Dolum Başlangıcındaki PH Değeri"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Başlangıcındaki PH Değeri"]);
                    YogurtProsesOzellikleri3.DolumBaslangicindakiSutSicakligi = dr["Dolum Başlangıcındaki Süt Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Başlangıcındaki Süt Sıcaklığı"]);
                    YogurtProsesOzellikleri3.DolumBitisSaati = dr["Dolum Bitiş Saati"] == DBNull.Value ? "" : dr["Dolum Bitiş Saati"].ToString();
                    YogurtProsesOzellikleri3.DolumBittigindekiPHDegeri = dr["Dolum Bittiğindeki PH Değeri"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Bittiğindeki PH Değeri"]);
                    YogurtProsesOzellikleri3.DolumBittigindekiSutSicakligi = dr["Dolum Bittiğindeki Süt Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Bittiğindeki Süt Sıcaklığı"]);
                    YogurtProsesOzellikleri3.SorumluPersonel = dr["Sorumlu Personel"] == DBNull.Value ? "" : dr["Sorumlu Personel"].ToString();
                    YogurtProsesOzellikleri3.DolumBittigindekiSutSicakligi = dr["Toplam Geçen Süre"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Toplam Geçen Süre"]);

                    yogurtProsesOzellikleri3s.Add(YogurtProsesOzellikleri3);
                }

                nesne.YogurtProsesOzellikleri3s = yogurtProsesOzellikleri3s.ToArray();

                foreach (DataRow dr in dtgBirinciKultur_DataTable.Rows)
                {
                    YogurtBirinciKultur = new YogurtBirinciKultur();

                    YogurtBirinciKultur.KullanilanMiktar = dr["Kullanılan Miktar"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kullanılan Miktar"]);
                    YogurtBirinciKultur.TedarikciAdiveKulturKodu = dr["Tedarikçi Adı ve Kültür Kodu"] == DBNull.Value ? "" : dr["Tedarikçi Adı ve Kültür Kodu"].ToString();
                    YogurtBirinciKultur.LotNo = dr["Lot No"] == DBNull.Value ? "" : dr["Lot No"].ToString();

                    YogurtBirinciKulturs.Add(YogurtBirinciKultur);
                }

                nesne.YogurtBirinciKulturs = YogurtBirinciKulturs.ToArray();

                foreach (DataRow dr in dtgIkinciKultur_DataTable.Rows)
                {
                    YogurtIkinciKultur = new YogurtIkinciKultur();

                    YogurtIkinciKultur.KullanilanMiktar = dr["Kullanılan Miktar"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kullanılan Miktar"]);
                    YogurtIkinciKultur.TedarikciAdiveKulturKodu = dr["Tedarikçi Adı ve Kültür Kodu"] == DBNull.Value ? "" : dr["Tedarikçi Adı ve Kültür Kodu"].ToString();
                    YogurtIkinciKultur.LotNo = dr["Lot No"] == DBNull.Value ? "" : dr["Lot No"].ToString();

                    YogurtIkinciKulturs.Add(YogurtIkinciKultur);
                }

                nesne.YogurtIkinciKulturs = YogurtIkinciKulturs.ToArray();

                foreach (DataRow dr in dtgSutunOzellikleri_DataTable.Rows)
                {
                    YogurtSutOzellikleri = new YogurtSutOzellikleri();

                    YogurtSutOzellikleri.SutTuru = dr["Süt Türü"] == DBNull.Value ? "" : dr["Süt Türü"].ToString();
                    YogurtSutOzellikleri.SutunKaynagi = dr["Sütün Kaynağı"] == DBNull.Value ? "" : dr["Sütün Kaynağı"].ToString();
                    YogurtSutOzellikleri.Brix = dr["Brix"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Brix"]);
                    YogurtSutOzellikleri.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    YogurtSutOzellikleri.SH = dr["SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SH"]);
                    YogurtSutOzellikleri.Yag = dr["Yağ"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağ"]);

                    YogurtSutOzellikleris.Add(YogurtSutOzellikleri);
                }

                nesne.YogurtSutOzellikleris = YogurtSutOzellikleris.ToArray();

                foreach (DataRow dr in dtgYariMamulKaliteOzellikleri_DataTable.Rows)
                {
                    YogurtYariMamulKaliteOzellikleri = new YogurtYariMamulKaliteOzellikleri();
                    YogurtYariMamulKaliteOzellikleri.PartiNo = dr["Parti No"] == DBNull.Value ? "" : dr["Parti No"].ToString();
                    YogurtYariMamulKaliteOzellikleri.TKM = dr["TKM"] == DBNull.Value ? 0 : Convert.ToDouble(dr["TKM"]);
                    YogurtYariMamulKaliteOzellikleri.Protein = dr["Protein"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Protein"]);
                    YogurtYariMamulKaliteOzellikleri.Tuz = dr["Tuz"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Tuz"]);
                    YogurtYariMamulKaliteOzellikleri.Brix = dr["Brix"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Brix"]);
                    YogurtYariMamulKaliteOzellikleri.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    YogurtYariMamulKaliteOzellikleri.SH = dr["SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SH"]);
                    YogurtYariMamulKaliteOzellikleri.Yag = dr["Yağ"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağ"]);
                    YogurtYariMamulKaliteOzellikleri.TatKokuKivam = dr["Tat Koku ve Kıvamı"] == DBNull.Value ? "" : dr["Tat Koku ve Kıvamı"].ToString();

                    YogurtYariMamulKaliteOzellikleris.Add(YogurtYariMamulKaliteOzellikleri);
                }

                nesne.YogurtYariMamulKaliteOzellikleris = YogurtYariMamulKaliteOzellikleris.ToArray();

                foreach (DataRow dr in dtgInkubasyonTakip_DataTable.Rows)
                {
                    YogurtInkubasyonOzellikleri = new YogurtInkubasyonOzellikleri();
                    YogurtInkubasyonOzellikleri.KontrolNo = dr["Kontrol No"] == DBNull.Value ? "" : dr["Kontrol No"].ToString();
                    YogurtInkubasyonOzellikleri.Saat = dr["Saat"] == DBNull.Value ? "" : dr["Saat"].ToString();
                    YogurtInkubasyonOzellikleri.Sicaklik = dr["Sıcaklık"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Sıcaklık"]);
                    YogurtInkubasyonOzellikleri.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    YogurtInkubasyonOzellikleri.KontrolEdenPersonel = dr["Kontrol Eden Personel"] == DBNull.Value ? "" : dr["Kontrol Eden Personel"].ToString();

                    if (YogurtInkubasyonOzellikleri.KontrolEdenPersonel != "")
                    {
                        YogurtInkubasyonOzellikleris.Add(YogurtInkubasyonOzellikleri);
                    }
                }

                nesne.YogurtInkubasyonOzellikleris = YogurtInkubasyonOzellikleris.ToArray();

                var resp = client.AddOrUpdateYogurtProsesTakipAnaliz(nesne, Giris.dbName, Giris.mKodValue);

                MessageBox.Show(resp.Description);

                if (resp.Value == 0)
                {
                    btnOzet.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu." + ex.Message);
            }
        }
    }
}
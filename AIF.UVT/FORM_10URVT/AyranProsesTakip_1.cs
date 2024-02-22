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
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class AyranProsesTakip_1 : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end.

        public AyranProsesTakip_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunGrubu)
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

            initialFontSize = button6.Font.Size;
            button6.Resize += Form_Resize;

            initialFontSize = btnOzetEkanaDon.Font.Size;
            btnOzetEkanaDon.Resize += Form_Resize;

            initialFontSize = btnOnayla.Font.Size;
            btnOnayla.Resize += Form_Resize;

            initialFontSize = button9.Font.Size;
            button9.Resize += Form_Resize;

            initialFontSize = button10.Font.Size;
            button10.Resize += Form_Resize;

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

            PartyNo = partiNo;
            UretimSiparisNo = UretimFisNo;
            UretilenUrunTanimi = UrunTanimi;

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

            button6.Font = new Font(button6.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button6.Font.Style);

            btnOzetEkanaDon.Font = new Font(btnOzetEkanaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkanaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOnayla.Font.Style);

            button9.Font = new Font(button9.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button9.Font.Style);

            button10.Font = new Font(button10.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button10.Font.Style);

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              label4.Font.Style);

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimTarihi.Font.Style);

            button7.Font = new Font(button7.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button7.Font.Style);

            ResumeLayout();
            //font end
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

        private static UVTServiceSoapClient client = new UVTServiceSoapClient();
        public DataTable dtgMamulOzellikleri1_DataTable = new DataTable();
        public DataTable dtgMamulOzellikleri2_DataTable = new DataTable();
        public DataTable dtgPihtiKirim_DataTable = new DataTable();
        public DataTable dtgBirinciKultur_DataTable = new DataTable();
        public DataTable dtgIkinciKultur_DataTable = new DataTable();
        public DataTable dtgTuzOzellikleri_DataTable = new DataTable();
        public DataTable dtgSutunOzellikleri_DataTable = new DataTable();
        public DataTable dtgYariMamulKaliteOzellikleri_DataTable = new DataTable();
        public DataTable dtgInkubasyonTakip_DataTable = new DataTable();

        #region eski tablo kaydetme
        //private static OtatServiceSoapClient client = new OtatServiceSoapClient();
        //public static AyranProsesTakipAnaliz nesne = new AyranProsesTakipAnaliz();
        //public static AyranProsesOzellikleri1 AyranProsesOzellikleri1 = new AyranProsesOzellikleri1();
        //public static List<AyranProsesOzellikleri1> ayranProsesOzellikleri1s = new List<AyranProsesOzellikleri1>();
        //public static AyranProsesOzellikleri2 AyranProsesOzellikleri2 = new AyranProsesOzellikleri2();
        //public static List<AyranProsesOzellikleri2> ayranProsesOzellikleri2s = new List<AyranProsesOzellikleri2>();
        //public static AyranPihtiKirim AyranPihtiKirim = new AyranPihtiKirim();
        //public static List<AyranPihtiKirim> ayranPihtiKirims = new List<AyranPihtiKirim>();
        //public static AyranBirinciKultur AyranBirinciKultur = new AyranBirinciKultur();
        //public static List<AyranBirinciKultur> ayranBirinciKulturs = new List<AyranBirinciKultur>();
        //public static AyranIkinciKultur AyranIkinciKultur = new AyranIkinciKultur();
        //public static List<AyranIkinciKultur> ayranIkinciKulturs = new List<AyranIkinciKultur>();
        //public static AyranTuzOzellikleri AyranTuzOzellikleri = new AyranTuzOzellikleri();
        //public static List<AyranTuzOzellikleri> ayranTuzOzellikleris = new List<AyranTuzOzellikleri>();
        //public static AyranSutOzellikleri AyranSutOzellikleri = new AyranSutOzellikleri();
        //public static List<AyranSutOzellikleri> ayranSutOzellikleris = new List<AyranSutOzellikleri>();
        //public static AyranYariMamulKaliteOzellikleri AyranYariMamulKaliteOzellikleri = new AyranYariMamulKaliteOzellikleri();
        //public static List<AyranYariMamulKaliteOzellikleri> ayranYariMamulKaliteOzellikleris = new List<AyranYariMamulKaliteOzellikleri>();
        //public static AyranInkubasyonOzellikleri AyranInkubasyonOzellikleri = new AyranInkubasyonOzellikleri();
        //public static List<AyranInkubasyonOzellikleri> ayranInkubasyonOzellikleris = new List<AyranInkubasyonOzellikleri>(); 
        #endregion

        public static string PartyNo = "";
        public static string UretimSiparisNo = "";
        public static string UretilenUrunTanimi = "";
        public static string UretimAciklamasi = "";
        #region eski tablo kaydetme
        //public static DataGridView dtgMamulOzellikleri1Static = new DataGridView();
        //public static DataGridView dtgMamulOzellikleri2Static = new DataGridView();
        //public static DataGridView dtgPihtiKirimOzellikleriStatic = new DataGridView();
        //public static DataGridView dtgBirinciKulturBilgileriStatic = new DataGridView();
        //public static DataGridView dtgIkinciKulturBilgileriStatic = new DataGridView();
        //public static DataGridView dtgTuzOzellikleriStatic = new DataGridView();
        //public static DataGridView dtgSutunOzellikleriStatic = new DataGridView();
        //public static DataGridView dtgYariMamulKaliteOzellikleriStatic = new DataGridView();
        //public static DataGridView dtgInkubasyonTakipStatic = new DataGridView(); 
        #endregion
        public static Button btnOzet = null;

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

        string pastorizasyonpartino = "";
        private void AyranProsesTakip_1_Load(object sender, EventArgs e)
        {
            if (type == "IST001")
            {
                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                string ss = "";
                ss = "SELECT TOP 1 T2.\"BatchNum\" FROM OIGE T0 WITH (NOLOCK) INNER JOIN IGE1 T1 WITH (NOLOCK) ON T0.\"DocEntry\"=T1.\"DocEntry\" INNER JOIN IBT1 T2 WITH (NOLOCK) ON T2.\"BaseEntry\"=T0.\"DocEntry\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ\" as T3 WITH (NOLOCK) ON T2.\"BatchNum\" = T3.\"U_PartiNo\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ1\" as T4 WITH (NOLOCK) ON T3.\"DocEntry\" = T4.\"DocEntry\" WHERE T1.\"BaseRef\" = '" + txtUretimFisNo.Text + "' AND ISNULL(T0.\"U_BatchNumber\",'') <>'' AND T2.\"BaseType\" = '60' ORDER by T2.\"BatchNum\" ";

                DataTable dt1 = new DataTable();
                cmd = new SqlCommand(ss, Connection.sql);
                sda1 = new SqlDataAdapter(cmd);
                sda1.Fill(dt1);

                if (dt1.Rows.Count > 0)
                {
                    pastorizasyonpartino = dt1.Rows[0][0].ToString();
                }

            }
            else
            {

                button7.Visible = false;
            }

            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_AYRPRSS_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            sda.Fill(dataTable1);

            Connection.sql.Close();

            if (dataTable1.Rows.Count > 0)
            {
                txtAciklama.Text = dataTable1.Rows[0].ItemArray[0].ToString();
            }

            dtgMamulOzellikleri1Load();
            dtgMamulOzellikleri2Load();
            dtPihtiKirimOzellikleriLoad();
            dtgBirinciKulturBilgileriLoad();
            dtgIkinciKulturBilgileriLoad();
            dtgTuzOzellikleriLoad();

            #region Ikinci ekran 1,2 ve 3.gridlerin yüklenmesi

            dtgSutunOzellikleriLoad_IkinciEkran();
            dtgYariMamulKaliteOzellikleriLoad_IkinciEkran();
            dtgInkubasyonTakipOzellikleriLoad_IkinciEkran();

            #endregion

            #region eski tablo kaydetme
            //dtgMamulOzellikleri1Static = dtgMamulOzellikleri1;
            //dtgMamulOzellikleri2Static = dtgMamulOzellikleri2;
            //dtgPihtiKirimOzellikleriStatic = dtgPihtiKirim;
            //dtgBirinciKulturBilgileriStatic = dtgBirinciKultur;
            //dtgIkinciKulturBilgileriStatic = dtgIkinciKultur;
            //dtgTuzOzellikleriStatic = dtgTuzOzellikleri; 
            #endregion

            DataGridViewColumn dataGridViewColumn = dtgPihtiKirim.Columns["Toplam Geçen Süre"];

            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            btnOzet = btnOzetEkanaDon;

            #region Termize Süt Yağlı Hesaplaması
            //sql = "SELECT ISNULL(SUM(T1.\"Quantity\"),0) from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' and T1.\"ItemCode\" = 'YRM-10003'";
            //cmd = new SqlCommand(sql, Connection.sql);

            //if (Connection.sql.State != ConnectionState.Open)
            //    Connection.sql.Open();

            //sda = new SqlDataAdapter(cmd);
            //dt = new DataTable();
            //sda.Fill(dt);

            //if (dt.Rows.Count > 0)
            //{
            //    dtgMamulOzellikleri1.Rows[0].Cells["Yağlı Süt Miktarı"].Value = dt.Rows[0][0].ToString();
            //}
            //#endregion

            //#region Termize Süt Yağsız Hesaplaması
            //sql = "SELECT ISNULL(SUM(T1.\"Quantity\"),0) from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' and T1.\"ItemCode\" = 'YRM-10002'";
            //cmd = new SqlCommand(sql, Connection.sql);

            //if (Connection.sql.State != ConnectionState.Open)
            //    Connection.sql.Open();

            //sda = new SqlDataAdapter(cmd);
            //dt = new DataTable();
            //sda.Fill(dt);

            //if (dt.Rows.Count > 0)
            //{
            //    dtgMamulOzellikleri1.Rows[0].Cells["Yağsız Süt Miktarı"].Value = dt.Rows[0][0].ToString();
            //}
            //#endregion

            //#region Su Miktarı Hesaplaması
            //sql = "SELECT ISNULL(SUM(T1.\"Quantity\"),0) from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' and T1.\"ItemCode\" = 'YRM-00001'";
            //cmd = new SqlCommand(sql, Connection.sql);

            //if (Connection.sql.State != ConnectionState.Open)
            //    Connection.sql.Open();

            //sda = new SqlDataAdapter(cmd);
            //dt = new DataTable();
            //sda.Fill(dt);

            //if (dt.Rows.Count > 0)
            //{
            //    dtgMamulOzellikleri1.Rows[0].Cells["Toplam Su Miktarı"].Value = dt.Rows[0][0].ToString();
            //}
            #endregion
        }


        public static List<kontrolListesi> kontrolListesis = new List<kontrolListesi>();
        public class kontrolListesi
        {
            public string aktifKolon { get; set; }
            public string kontroledilmesigerekenKolon { get; set; }
        }
        private void dtgMamulOzellikleri1Load()
        {
            //string sql = "Select T1.\"ItemCode\" as \"Malzeme Kodu\",T1.\"Dscription\" as \"Malzeme Tanımı\", SUM(T1.\"Quantity\") as \"Miktar\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' group by T1.\"ItemCode\",T1.\"Dscription\"";

            string sql = "Select T1.\"U_UrunGrubu\" as \"Ürün Grubu\",T1.\"U_ProsesBasSaat\" as \"Proses Başlangıç Saati\", T1.\"U_YagliSutMik\" as \"Yağlı Süt Miktarı\", T1.\"U_YagsizSutMik\" as \"Yağsız Süt Miktarı\", T1.\"U_ToplamSuMik\" as \"Toplam Su Miktarı\", T1.\"U_TuzMiktari\" as \"Tuz Miktarı\", T1.\"U_AyranTuzOrani\" as \"Ayran Tuz Oranı\", T1.\"U_TopAyranYarMamulMik\" as \"Toplam Ayran Yarı Mamül Miktarı\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtgMamulOzellikleri1_DataTable);

            if (dtgMamulOzellikleri1_DataTable.Rows.Count == 0)
            {
                #region daha önce girilmiş analiz var mı sorgu chn 20220802
                string baseref = txtUretimFisNo.Text;
                if (type == "IST001") //Ayran istasyonundan geliyorsa
                {
                    //sql = "SELECT TOP 1 T4.\"U_UrunGrubu\" as \"Ürün Grubu\",T4.\"U_ProsesBasSaat\" as \"Proses Başlangıç Saati\", T4.\"U_YagliSutMik\" as \"Yağlı Süt Miktarı\",T4.\"U_YagsizSutMik\" as \"Yağsız Süt Miktarı\", T4.\"U_ToplamSuMik\" as \"Toplam Su Miktarı\", T4.\"U_TuzMiktari\" as \"Tuz Miktarı\",T4.\"U_AyranTuzOrani\" as \"Ayran Tuz Oranı\", T4.\"U_TopAyranYarMamulMik\" as \"Toplam Ayran Yarı Mamül Miktarı\" FROM OIGE T0 INNER JOIN IGE1 T1 ON T0.\"DocEntry\"=T1.\"DocEntry\" INNER JOIN IBT1 T2 ON T2.\"BaseEntry\"=T0.\"DocEntry\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ\" as T3 ON T2.\"BatchNum\" = T3.\"U_PartiNo\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ1\" as T4 ON T3.\"DocEntry\" = T4.\"DocEntry\" WHERE T1.\"BaseRef\" = '" + baseref + "' AND ISNULL(T0.\"U_BatchNumber\",'') <>'' AND T2.\"BaseType\" = '60' ORDER by T2.\"BatchNum\" ";

                    sql = "Select T1.\"U_UrunGrubu\" as \"Ürün Grubu\",T1.\"U_ProsesBasSaat\" as \"Proses Başlangıç Saati\", T1.\"U_YagliSutMik\" as \"Yağlı Süt Miktarı\", T1.\"U_YagsizSutMik\" as \"Yağsız Süt Miktarı\", T1.\"U_ToplamSuMik\" as \"Toplam Su Miktarı\", T1.\"U_TuzMiktari\" as \"Tuz Miktarı\", T1.\"U_AyranTuzOrani\" as \"Ayran Tuz Oranı\", T1.\"U_TopAyranYarMamulMik\" as \"Toplam Ayran Yarı Mamül Miktarı\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + pastorizasyonpartino + "'";

                    cmd = new SqlCommand(sql, Connection.sql);
                    sda = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable(); 
                    sda.Fill(dtgMamulOzellikleri1_DataTable);
                }
                else if (type == "IST009") //Pastörizasyondan geliyorsa
                {
                    sql = "select 'YagliSut' as Tip,ISNULL(SUM(cast(I1.Quantity as decimal (15,2))),0) as Miktar from IGE1 I1 WITH (NOLOCK) inner join OITM O1 WITH (NOLOCK) ON O1.ItemCode = I1.ItemCode where I1.BaseType = '202' and I1.BaseRef = " + baseref + " AND U_AnalizGrubu = '06' ";

                    sql += " UNION ALL ";

                    sql += "select 'YagsizSut' as Tip,ISNULL(SUM(cast(I1.Quantity as decimal (15,2))),0)  as Miktar from IGE1 I1 WITH (NOLOCK) inner join OITM O1 WITH (NOLOCK) ON O1.ItemCode = I1.ItemCode where I1.BaseType = '202' and I1.BaseRef = " + baseref + " AND U_AnalizGrubu = '07' ";

                    sql += " UNION ALL ";

                    sql += "select 'Su' as Tip,ISNULL(SUM(cast(I1.Quantity as decimal (15,2))),0)  as Miktar from IGE1 I1 WITH (NOLOCK) inner join OITM O1 WITH (NOLOCK) ON O1.ItemCode = I1.ItemCode where I1.BaseType = '202' and I1.BaseRef = " + baseref + " AND U_AnalizGrubu = '08' ";

                    sql += " UNION ALL ";

                    sql += "select 'Tuz' as Tip,ISNULL(SUM(cast(I1.Quantity as decimal (15,2))),0)  as Miktar from IGE1 I1 WITH (NOLOCK) inner join OITM O1 WITH (NOLOCK) ON O1.ItemCode = I1.ItemCode where I1.BaseType = '202' and I1.BaseRef = " + baseref + " AND U_AnalizGrubu = '01' ";



                    cmd = new SqlCommand(sql, Connection.sql);
                    sda = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable(); 
                    sda.Fill(dttemp);

                    if (dtgMamulOzellikleri1_DataTable.Rows.Count == 0)
                    {
                        System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                        DataRow dr = dtgMamulOzellikleri1_DataTable.NewRow();
                        dr["Ürün Grubu"] = UrunGrubu;
                        dr["Yağlı Süt Miktarı"] = Convert.ToString(dttemp.AsEnumerable().Where(z => z.Field<string>("Tip") == "YagliSut").Select(y => y.Field<decimal>("Miktar")).FirstOrDefault(), cultureTR);
                        dr["Yağsız Süt Miktarı"] = Convert.ToString(dttemp.AsEnumerable().Where(z => z.Field<string>("Tip") == "YagsizSut").Select(y => y.Field<decimal>("Miktar")).FirstOrDefault(), cultureTR);
                        dr["Toplam Su Miktarı"] = Convert.ToString(dttemp.AsEnumerable().Where(z => z.Field<string>("Tip") == "Su").Select(y => y.Field<decimal>("Miktar")).FirstOrDefault(), cultureTR);
                        dr["Tuz Miktarı"] = Convert.ToString(dttemp.AsEnumerable().Where(z => z.Field<string>("Tip") == "Tuz").Select(y => y.Field<decimal>("Miktar")).FirstOrDefault(), cultureTR);
                        dr["Ayran Tuz Oranı"] = Convert.ToString("0", cultureTR);
                        dr["Toplam Ayran Yarı Mamül Miktarı"] = Convert.ToString("0", cultureTR);

                        dtgMamulOzellikleri1_DataTable.Rows.Add(dr);
                    }

                }
                #endregion
            }

            if (dtgMamulOzellikleri1_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgMamulOzellikleri1_DataTable.NewRow();
                dr["Ürün Grubu"] = UrunGrubu;
                dr["Yağlı Süt Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Yağsız Süt Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Toplam Su Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Tuz Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Ayran Tuz Oranı"] = Convert.ToString("0", cultureTR);
                dr["Toplam Ayran Yarı Mamül Miktarı"] = Convert.ToString("0", cultureTR);

                dtgMamulOzellikleri1_DataTable.Rows.Add(dr);
            }


            Connection.sql.Close();

            //Commit
            dtgMamulOzellikleri1.DataSource = dtgMamulOzellikleri1_DataTable;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgMamulOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgMamulOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dtgMamulOzellikleri1.EnableHeadersVisualStyles = false;
            dtgMamulOzellikleri1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgMamulOzellikleri1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);

            //dt.Rows.Add();

            dtgMamulOzellikleri1.Columns["Yağlı Süt Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri1.Columns["Yağlı Süt Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri1.Columns["Yağsız Süt Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri1.Columns["Yağsız Süt Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri1.Columns["Toplam Su Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri1.Columns["Toplam Su Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri1.Columns["Ayran Tuz Oranı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri1.Columns["Ayran Tuz Oranı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri1.Columns["Toplam Ayran Yarı Mamül Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri1.Columns["Toplam Ayran Yarı Mamül Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri1.Columns["Tuz Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri1.Columns["Tuz Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgMamulOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgMamulOzellikleri1.Columns)
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
                var girilenSaat = dtgMamulOzellikleri1.Rows[0].Cells["Proses Başlangıç Saati"].Value.ToString() == "" ? "0" : dtgMamulOzellikleri1.Rows[0].Cells["Proses Başlangıç Saati"].Value.ToString();
                if (girilenSaat == "0")
                {
                    string saat = dt2.Rows[0][0].ToString().PadLeft(4, '0');
                    saat = saat.Substring(0, 2) + ":" + saat.Substring(2, 2);
                    dtgMamulOzellikleri1.Rows[0].Cells["Proses Başlangıç Saati"].Value = saat;
                }
            }

            #endregion Proses başlangıç saati getirme

            #region 20220802 Analiz bilgileri sorgudan yukarıdaki getilriliyor
            //string uretimdenCikissql = "Select T0.\"DocEntry\",SUM(ISNULL(T1.\"Quantity\",0)) from \"OIGE\" as T0 INNER JOIN \"IGE1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' and T1.\"ItemCode\" = 'YRM-10003' group by T0.\"DocEntry\"";

            //cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //dt2 = new DataTable();
            //sda = new SqlDataAdapter(cmd);
            //sda.Fill(dt2);

            //if (dt2.Rows.Count > 0)
            //{
            //    var uretilenmiktar = dtgMamulOzellikleri1.Rows[0].Cells["Yağlı Süt Miktarı"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["Yağlı Süt Miktarı"].Value);
            //    if (uretilenmiktar == 0)
            //    {
            //        var miktar = Convert.ToDouble(dt2.Rows[0][1]);
            //        dtgMamulOzellikleri1.Rows[0].Cells["Yağlı Süt Miktarı"].Value = miktar.ToString();
            //    }
            //}

            //dt2 = new DataTable();

            //uretimdenCikissql = "Select T0.\"DocEntry\",SUM(ISNULL(T1.\"Quantity\",0)) from \"OIGE\" as T0 INNER JOIN \"IGE1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' and T1.\"ItemCode\" = 'YRM-10002' group by T0.\"DocEntry\"";

            //cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //sda = new SqlDataAdapter(cmd);
            //sda.Fill(dt2);

            //if (dt2.Rows.Count > 0)
            //{
            //    var uretilenmiktar = dtgMamulOzellikleri1.Rows[0].Cells["Yağsız Süt Miktarı"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["Yağsız Süt Miktarı"].Value);
            //    if (uretilenmiktar == 0)
            //    {
            //        var miktar = Convert.ToDouble(dt2.Rows[0][1]);
            //        dtgMamulOzellikleri1.Rows[0].Cells["Yağsız Süt Miktarı"].Value = miktar.ToString();
            //    }
            //}

            //dt2 = new DataTable();

            //uretimdenCikissql = "Select T0.\"DocEntry\",SUM(ISNULL(T1.\"Quantity\",0)) from \"OIGE\" as T0 INNER JOIN \"IGE1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' and T1.\"ItemCode\" = 'YRM-00001' group by T0.\"DocEntry\"";

            //cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //sda = new SqlDataAdapter(cmd);
            //sda.Fill(dt2);

            //if (dt2.Rows.Count > 0)
            //{
            //    var uretilenmiktar = dtgMamulOzellikleri1.Rows[0].Cells["Toplam Su Miktarı"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["Toplam Su Miktarı"].Value);
            //    if (uretilenmiktar == 0)
            //    {
            //        var miktar = Convert.ToDouble(dt2.Rows[0][1]);
            //        dtgMamulOzellikleri1.Rows[0].Cells["Toplam Su Miktarı"].Value = miktar.ToString();
            //    }
            //}

            //dt2 = new DataTable();

            //uretimdenCikissql = "Select T0.\"DocEntry\",SUM(ISNULL(T1.\"Quantity\",0)) from \"OIGE\" as T0 INNER JOIN \"IGE1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' and (T1.\"ItemCode\" = 'ISM-10186' or T1.\"ItemCode\" = 'ISM-10188') group by T0.\"DocEntry\"";

            //cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //sda = new SqlDataAdapter(cmd);
            //sda.Fill(dt2);

            //if (dt2.Rows.Count > 0)
            //{
            //    var uretilenmiktar = dtgMamulOzellikleri1.Rows[0].Cells["Tuz Miktarı"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["Tuz Miktarı"].Value);
            //    if (uretilenmiktar == 0)
            //    {
            //        var miktar = Convert.ToDouble(dt2.Rows[0][1]);
            //        dtgMamulOzellikleri1.Rows[0].Cells["Tuz Miktarı"].Value = miktar.ToString();
            //    }
            //} 
            #endregion

            ayranTuzOraniYariMamulToplamiHesapla();
        }

        private void dtgMamulOzellikleri2Load()
        {
            //string sql = "Select T1.\"ItemCode\" as \"Malzeme Kodu\",T1.\"Dscription\" as \"Malzeme Tanımı\", SUM(T1.\"Quantity\") as \"Miktar\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' group by T1.\"ItemCode\",T1.\"Dscription\"";

            string sql = "Select T1.\"U_PastorizasyonSicak\" as \"Pastörizasyon Sıcaklığı\",T1.\"U_PastorizasyonSuresi\" as \"Pastörizasyon Süresi\", T1.\"U_SutVakum\" as \"Süt Vakum\", T1.\"U_MayalamaSaati\" as \"Mayalama Saati\", T1.\"U_MayalamaSicakligi\" as \"Mayalama Sıcaklığı\", T1.\"U_SorumluPersonel\" as \"Sorumlu Personel\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ2\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            sda.Fill(dtgMamulOzellikleri2_DataTable);

            if (type == "IST001") //Ayran İstasyonu 
            {
                if (dtgMamulOzellikleri2_DataTable.Rows.Count == 0)
                {
                    #region daha önce girilmiş analiz var mı sorgu chn 20220802
                    //string baseref = txtUretimFisNo.Text;
                    //sql = "SELECT TOP 1  T4.\"U_PastorizasyonSicak\" as \"Pastörizasyon Sıcaklığı\",T4.\"U_PastorizasyonSuresi\" as \"Pastörizasyon Süresi\", T4.\"U_SutVakum\" as \"Süt Vakum\",T4.\"U_MayalamaSaati\" as \"Mayalama Saati\", T4.\"U_MayalamaSicakligi\" as \"Mayalama Sıcaklığı\", T4.\"U_SorumluPersonel\" as \"Sorumlu Personel\" FROM OIGE T0 INNER JOIN IGE1 T1 ON T0.\"DocEntry\"=T1.\"DocEntry\" INNER JOIN IBT1 T2 ON T2.\"BaseEntry\"=T0.\"DocEntry\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ\" as T3 ON T2.\"BatchNum\" = T3.\"U_PartiNo\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ2\" as T4 ON T3.\"DocEntry\" = T4.\"DocEntry\" WHERE T1.\"BaseRef\" = '" + baseref + "' AND ISNULL(T0.\"U_BatchNumber\",'') <>'' AND T2.\"BaseType\" = '60'  ORDER by T2.\"BatchNum\" ";

                    sql = "Select T1.\"U_PastorizasyonSicak\" as \"Pastörizasyon Sıcaklığı\",T1.\"U_PastorizasyonSuresi\" as \"Pastörizasyon Süresi\", T1.\"U_SutVakum\" as \"Süt Vakum\", T1.\"U_MayalamaSaati\" as \"Mayalama Saati\", T1.\"U_MayalamaSicakligi\" as \"Mayalama Sıcaklığı\", T1.\"U_SorumluPersonel\" as \"Sorumlu Personel\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ2\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + pastorizasyonpartino + "'";

                    cmd = new SqlCommand(sql, Connection.sql);
                    sda = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable(); 
                    sda.Fill(dtgMamulOzellikleri2_DataTable);
                    #endregion
                }
            }

            if (dtgMamulOzellikleri2_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgMamulOzellikleri2_DataTable.NewRow();
                dr["Pastörizasyon Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Pastörizasyon Süresi"] = Convert.ToString("0", cultureTR);
                dr["Mayalama Sıcaklığı"] = Convert.ToString("0", cultureTR);

                dtgMamulOzellikleri2_DataTable.Rows.Add(dr);
            }

            Connection.sql.Close();
            //Commit
            dtgMamulOzellikleri2.DataSource = dtgMamulOzellikleri2_DataTable;

            dtgMamulOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgMamulOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgMamulOzellikleri2.EnableHeadersVisualStyles = false;
            dtgMamulOzellikleri2.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgMamulOzellikleri2.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);


            //dt.Rows.Add();

            dtgMamulOzellikleri2.Columns["Pastörizasyon Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["Pastörizasyon Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri2.Columns["Pastörizasyon Süresi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["Pastörizasyon Süresi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri2.Columns["Mayalama Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["Mayalama Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgMamulOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgMamulOzellikleri2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;



            #region Kontrol listesi oluşturma 

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pastörizasyon Süresi",
                kontroledilmesigerekenKolon = "Pastörizasyon Sıcaklığı"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Süt Vakum",
                kontroledilmesigerekenKolon = "Pastörizasyon Süresi"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Mayalama Saati",
                kontroledilmesigerekenKolon = "Süt Vakum"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Mayalama Sıcaklığı",
                kontroledilmesigerekenKolon = "Mayalama Saati"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Sorumlu Personel",
                kontroledilmesigerekenKolon = "Mayalama Sıcaklığı"
            });

            #endregion
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

        private void dtPihtiKirimOzellikleriLoad()
        {
            string sql = "Select T1.\"U_PompaBasinci\" as \"Pompa Basıncı\",T1.\"U_BaslamaSaati\" as \"Başlama Saati\", T1.\"U_BitisSaati\" as \"Bitiş Saati\", T1.\"U_ToplamGecenSure\" as \"Toplam Geçen Süre\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ3\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            sda.Fill(dtgPihtiKirim_DataTable);

            if (type == "IST001") //Ayran istasyonu
            {
                if (dtgPihtiKirim_DataTable.Rows.Count == 0)
                {
                    #region daha önce girilmiş analiz var mı sorgu chn 20220802
                    //string baseref = txtUretimFisNo.Text;
                    //sql = "SELECT TOP 1  T4.\"U_PompaBasinci\" as \"Pompa Basıncı\",T4.\"U_BaslamaSaati\" as \"Başlama Saati\", T4.\"U_BitisSaati\" as \"Bitiş Saati\",T4.\"U_ToplamGecenSure\" as \"Toplam Geçen Süre\" FROM OIGE T0 INNER JOIN IGE1 T1 ON T0.\"DocEntry\"=T1.\"DocEntry\" INNER JOIN IBT1 T2 ON T2.\"BaseEntry\"=T0.\"DocEntry\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ\" as T3 ON T2.\"BatchNum\" = T3.\"U_PartiNo\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ3\" as T4 ON T3.\"DocEntry\" = T4.\"DocEntry\" WHERE T1.\"BaseRef\" = '" + baseref + "' AND ISNULL(T0.\"U_BatchNumber\",'') <>'' AND T2.\"BaseType\" = '60' ORDER by T2.\"BatchNum\" ";
                    sql = "Select T1.\"U_PompaBasinci\" as \"Pompa Basıncı\",T1.\"U_BaslamaSaati\" as \"Başlama Saati\", T1.\"U_BitisSaati\" as \"Bitiş Saati\", T1.\"U_ToplamGecenSure\" as \"Toplam Geçen Süre\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ3\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + pastorizasyonpartino + "'";

                    cmd = new SqlCommand(sql, Connection.sql);
                    sda = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable(); 
                    sda.Fill(dtgPihtiKirim_DataTable);
                    #endregion
                }
            }

            if (dtgPihtiKirim_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgPihtiKirim_DataTable.NewRow();
                dr["Pompa Basıncı"] = Convert.ToString("0", cultureTR);
                dr["Toplam Geçen Süre"] = Convert.ToString("0", cultureTR);

                dtgPihtiKirim_DataTable.Rows.Add(dr);
            }

            Connection.sql.Close();
            //Commit
            dtgPihtiKirim.DataSource = dtgPihtiKirim_DataTable;

            dtgPihtiKirim.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgPihtiKirim.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgPihtiKirim.EnableHeadersVisualStyles = false;
            dtgPihtiKirim.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgPihtiKirim.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);

            //dt.Rows.Add();

            dtgPihtiKirim.Columns["Pompa Basıncı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgPihtiKirim.Columns["Pompa Basıncı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgPihtiKirim.Columns["Toplam Geçen Süre"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgPihtiKirim.Columns["Toplam Geçen Süre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgPihtiKirim.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgPihtiKirim.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;


            #region Kontrol listesi oluşturma 

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pompa Basıncı",
                kontroledilmesigerekenKolon = "Sorumlu Personel"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Başlama Saati",
                kontroledilmesigerekenKolon = "Pompa Basıncı"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Bitiş Saati",
                kontroledilmesigerekenKolon = "Başlama Saati"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Toplam Geçen Süre",
                kontroledilmesigerekenKolon = "Bitiş Saati"
            });
            #endregion
        }

        private void dtgBirinciKulturBilgileriLoad()
        {
            string sql = "Select ISNULL(T1.\"U_KullanilanMik\",0) as \"Kullanılan Miktar\",ISNULL(T1.\"U_TedAdiVeKultKod\",'') as \"Tedarikçi Adı ve Kültür Kodu\", ISNULL(T1.\"U_LotNo\",'') as \"Lot No\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ4\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "' ";

            sql += " and ISNULL(T1.\"U_KullanilanMik\",0)<>0 and ISNULL(T1.\"U_TedAdiVeKultKod\",'')<>'' and ISNULL(T1.\"U_LotNo\",'')<>'' ";

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            sda.Fill(dtgBirinciKultur_DataTable);

            //if (dt.Rows.Count == 0)
            //{
            //    string uretimdenCikissql = "Select T2.Quantity as \"Kullanılan Miktar\",(isnull(T4.CardName, '') + T1.Dscription) as \"Tedarikçi Adı ve Kültür Kodu\",T2.BatchNum as \"Lot No\" from ";
            //    uretimdenCikissql += "OIGE T0 inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
            //    uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry ";
            //    uretimdenCikissql += "left join OCRD T4 ON T2.CardCode = T4.CardCode ";
            //    uretimdenCikissql += "inner join OITM T5 ON T5.ItemCode = T2.ItemCode ";
            //    uretimdenCikissql += "where T0.U_BatchNumber = '" + partiNo + "' and T5.\"ItemCode\" = 'ISM-10219'";

            //    cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //    sda = new SqlDataAdapter(cmd);
            //    sda.Fill(dt);
            //} 
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
                #region daha önce girilmiş analiz var mı sorgu chn 20220802
                string baseref = txtUretimFisNo.Text;

                if (type == "IST001")
                {
                    sql = "SELECT T4.\"U_KullanilanMik\" as \"Kullanılan Miktar\",T4.\"U_TedAdiVeKultKod\" as \"Tedarikçi Adı ve Kültür Kodu\",T4.\"U_LotNo\" as \"Lot No\" FROM OIGE T0 WITH (NOLOCK) INNER JOIN IGE1 T1 WITH (NOLOCK) ON T0.\"DocEntry\"=T1.\"DocEntry\" INNER JOIN IBT1 T2 WITH (NOLOCK) ON T2.\"BaseEntry\"=T0.\"DocEntry\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ\" as T3 WITH (NOLOCK) ON T2.\"BatchNum\" = T3.\"U_PartiNo\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ4\" as T4 WITH (NOLOCK) ON T3.\"DocEntry\" = T4.\"DocEntry\" WHERE T1.\"BaseRef\" = '" + baseref + "' AND ISNULL(T0.\"U_BatchNumber\",'') <>'' AND T2.\"BaseType\" = '60' ORDER by T2.\"BatchNum\" ";

                }
                else if (type == "IST009")
                {

                    sql = "select I1.ItemCode + ' | ' + (Select TOP 1 ttt.CardName from IBT1 as ttt WITH (NOLOCK) where ttt.BatchNum = T2.BatchNum ) as \"Tedarikçi Adı ve Kültür Kodu\" ,SUM(I1.Quantity) as 'Kullanılan Miktar', t2.BatchNum as \"Lot No\"  from IGE1 I1 WITH (NOLOCK) inner join OITM O1 WITH (NOLOCK) ON O1.ItemCode = I1.ItemCode INNER JOIN IBT1 T2 WITH (NOLOCK) ON T2.\"BaseEntry\" = I1.\"DocEntry\" and T2.ItemCode = I1.ItemCode where I1.BaseType = '202' and I1.BaseRef = '" + baseref + "' AND U_AnalizGrubu = '02' group by t2.BatchNum, I1.ItemCode,T2.CardCode";

                }



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

            #region eski analiz getirme sorgusu 20220802
            //if (dtgBirinciKultur_DataTable.Rows.Count == 0)
            //{
            //    sql = "Select \"U_Deger3\" from \"@AIF_GNLKANLZPRM\" where \"U_Kod\" ='6'";
            //    cmd = new SqlCommand(sql, Connection.sql);

            //    if (Connection.sql.State != ConnectionState.Open)
            //        Connection.sql.Open();

            //    sda = new SqlDataAdapter(cmd);
            //    DataTable dt_Sorgu = new DataTable();
            //    DataTable dt_Line = new DataTable();
            //    sda.Fill(dt_Sorgu);

            //    //dtgSecim.DataSource = dt;
            //    //dtSecim = dt;

            //    Connection.sql.Close(); 
            //    if (dt_Sorgu.Rows.Count > 0)
            //    {
            //        string uretimdenCikissql = "";

            //        uretimdenCikissql = "Select T1.LineNum ";
            //        uretimdenCikissql += " from ";
            //        uretimdenCikissql += "OIGE T0 ";
            //        uretimdenCikissql += "inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
            //        uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry ";
            //        uretimdenCikissql += "and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry ";
            //        uretimdenCikissql += "inner join OITM T5 ON T5.ItemCode = T2.ItemCode where T0.U_BatchNumber = '" + partiNo + "' and T5.U_ItemGroup3 = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"U_UVTUrunTipi\"='1' order by Case when ISNULL(T1.\"LineNum\",'') = '' then 0 else cast(T1.\"LineNum\" as int) end";

            //        cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //        sda = new SqlDataAdapter(cmd);
            //        sda.Fill(dt_Line);

            //        if (dt_Line.Rows.Count > 1)
            //        {
            //            string itemgrp = dt_Sorgu.Rows[0][0].ToString();

            //            uretimdenCikissql = "Select T2.Quantity as \"Kullanılan Miktar\",T1.Dscription as \"Tedarikçi Adı ve Kültür Kodu\",T2.BatchNum as \"Lot No\" ";

            //            //uretimdenCikissql = " (Select T10.CardName from IBT1 T9 ";
            //            //uretimdenCikissql += "inner join OCRD T10 ON T9.CardCode = T10.CardCode where T9.BatchNum = T2.BatchNum) as 'CardName', ";
            //            uretimdenCikissql += " from OIGE T0 ";
            //            uretimdenCikissql += "inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
            //            uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry ";
            //            uretimdenCikissql += "and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry inner join OITM T5 ON T5.ItemCode = T2.ItemCode where T0.U_BatchNumber = '" + partiNo + "' and T5.U_ItemGroup3 = '" + itemgrp + "' and \"U_UVTUrunTipi\"='1' and T1.\"LineNum\" > '" + dt_Line.Rows[0][0].ToString() + "'";

            //            cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //            sda = new SqlDataAdapter(cmd);

            //            dtgBirinciKultur_DataTable.Rows.Clear();
            //            //dt.Columns.Clear();

            //            //dt_Result.Rows.Clear();
            //            sda.Fill(dtgBirinciKultur_DataTable);
            //        }
            //    }
            //} 
            #endregion

            //Commit
            dtgBirinciKultur.DataSource = dtgBirinciKultur_DataTable;

            dtgBirinciKultur.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgBirinciKultur.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
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
            string sql = "Select ISNULL(T1.\"U_KullanilanMik\",0) as \"Kullanılan Miktar\",ISNULL(T1.\"U_TedAdiVeKultKod\",'') as \"Tedarikçi Adı ve Kültür Kodu\", ISNULL(T1.\"U_LotNo\",'') as \"Lot No\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ5\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "' ";

            sql += "and ISNULL(T1.\"U_KullanilanMik\",0)<>0 and ISNULL(T1.\"U_TedAdiVeKultKod\",'')<>'' and ISNULL(T1.\"U_LotNo\",'')<>'' ";

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            sda.Fill(dtgIkinciKultur_DataTable);

            //if (dt.Rows.Count == 0)
            //{
            //    string uretimdenCikissql = "Select T2.Quantity as \"Kullanılan Miktar\",(isnull(T4.CardName, '') + T1.Dscription) as \"Tedarikçi Adı ve Kültür Kodu\",T2.BatchNum as \"Lot No\" from ";
            //    uretimdenCikissql += "OIGE T0 inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
            //    uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry ";
            //    uretimdenCikissql += "left join OCRD T4 ON T2.CardCode = T4.CardCode ";
            //    uretimdenCikissql += "inner join OITM T5 ON T5.ItemCode = T2.ItemCode ";
            //    uretimdenCikissql += "where T0.U_BatchNumber = '" + partiNo + "' and T5.\"ItemCode\" = 'ISM-10220'";

            //    cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //    sda = new SqlDataAdapter(cmd);
            //    sda.Fill(dt);
            //}

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
                #region daha önce girilmiş analiz var mı sorgu chn 20220802
                string baseref = txtUretimFisNo.Text;

                if (type == "IST001")
                {
                    sql = "SELECT T4.\"U_KullanilanMik\" as \"Kullanılan Miktar\",T4.\"U_TedAdiVeKultKod\" as \"Tedarikçi Adı ve Kültür Kodu\",T4.\"U_LotNo\" as \"Lot No\" FROM OIGE T0 WITH (NOLOCK) INNER JOIN IGE1 T1 WITH (NOLOCK) ON T0.\"DocEntry\"=T1.\"DocEntry\" INNER JOIN IBT1 T2 WITH (NOLOCK) ON T2.\"BaseEntry\"=T0.\"DocEntry\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ\" as T3 WITH (NOLOCK) ON T2.\"BatchNum\" = T3.\"U_PartiNo\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ5\" as T4 WITH (NOLOCK) ON T3.\"DocEntry\" = T4.\"DocEntry\" WHERE T1.\"BaseRef\" = '" + baseref + "' AND ISNULL(T0.\"U_BatchNumber\",'') <>''AND T2.\"BaseType\" = '60' ORDER by T2.\"BatchNum\" ";

                }
                else if (type == "IST009")
                {
                    sql = "select I1.ItemCode + ' | ' + (Select TOP 1 ttt.CardName from IBT1 as ttt WITH (NOLOCK) where ttt.BatchNum = T2.BatchNum ) as \"Tedarikçi Adı ve Kültür Kodu\" ,SUM(I1.Quantity) as 'Kullanılan Miktar', t2.BatchNum as \"Lot No\"  from IGE1 I1 WITH (NOLOCK) inner join OITM O1 WITH (NOLOCK) ON O1.ItemCode = I1.ItemCode INNER JOIN IBT1 T2 WITH (NOLOCK) ON T2.\"BaseEntry\" = I1.\"DocEntry\" and T2.ItemCode = I1.ItemCode where I1.BaseType = '202' and I1.BaseRef = '" + baseref + "' AND U_AnalizGrubu = '02' group by t2.BatchNum, I1.ItemCode,T2.CardCode";

                }

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
            }

            if (dtgIkinciKultur_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgIkinciKultur_DataTable.NewRow();
                dr["Kullanılan Miktar"] = Convert.ToString("0", cultureTR);

                dtgIkinciKultur_DataTable.Rows.Add(dr);
            }

            Connection.sql.Close();

            #region eski analiz getirme sorgusu 20220802
            //if (dtgIkinciKultur_DataTable.Rows.Count == 0)
            //{
            //    sql = "Select \"U_Deger3\" from \"@AIF_GNLKANLZPRM\" where \"U_Kod\" ='6'";
            //    cmd = new SqlCommand(sql, Connection.sql);

            //    if (Connection.sql.State != ConnectionState.Open)
            //        Connection.sql.Open();

            //    sda = new SqlDataAdapter(cmd);
            //    DataTable dt_Sorgu = new DataTable();
            //    DataTable dt_Line = new DataTable();
            //    sda.Fill(dt_Sorgu);

            //    //dtgSecim.DataSource = dt;
            //    //dtSecim = dt;

            //    Connection.sql.Close();

            //    if (dt_Sorgu.Rows.Count > 0)
            //    {
            //        string uretimdenCikissql = "";

            //        uretimdenCikissql = "Select T1.LineNum ";
            //        uretimdenCikissql += " from ";
            //        uretimdenCikissql += "OIGE T0 ";
            //        uretimdenCikissql += "inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
            //        uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry ";
            //        uretimdenCikissql += "and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry ";
            //        uretimdenCikissql += "inner join OITM T5 ON T5.ItemCode = T2.ItemCode where T0.U_BatchNumber = '" + partiNo + "' and T5.U_ItemGroup3 = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"U_UVTUrunTipi\"='1' order by Case when ISNULL(T1.\"LineNum\",'') = '' then 0 else cast(T1.\"LineNum\" as int) end";

            //        cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //        sda = new SqlDataAdapter(cmd);
            //        sda.Fill(dt_Line);

            //        if (dt_Line.Rows.Count > 1)
            //        {
            //            string itemgrp = dt_Sorgu.Rows[0][0].ToString();

            //            uretimdenCikissql = "Select T2.Quantity as \"Kullanılan Miktar\",T1.Dscription as \"Tedarikçi Adı ve Kültür Kodu\",T2.BatchNum as \"Lot No\" ";

            //            //uretimdenCikissql = " (Select T10.CardName from IBT1 T9 ";
            //            //uretimdenCikissql += "inner join OCRD T10 ON T9.CardCode = T10.CardCode where T9.BatchNum = T2.BatchNum) as 'CardName', ";
            //            uretimdenCikissql += " from OIGE T0 ";
            //            uretimdenCikissql += "inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
            //            uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry ";
            //            uretimdenCikissql += "and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry inner join OITM T5 ON T5.ItemCode = T2.ItemCode where T0.U_BatchNumber = '" + partiNo + "' and T5.U_ItemGroup3 = '" + itemgrp + "' and \"U_UVTUrunTipi\"='1' and T1.\"LineNum\" > '" + dt_Line.Rows[0][0].ToString() + "'";

            //            cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //            sda = new SqlDataAdapter(cmd);

            //            dtgIkinciKultur_DataTable.Rows.Clear();
            //            //dt.Columns.Clear();

            //            //dt_Result.Rows.Clear();
            //            sda.Fill(dtgIkinciKultur_DataTable);
            //        }
            //    }
            //} 
            #endregion

            //Commit
            dtgIkinciKultur.DataSource = dtgIkinciKultur_DataTable;

            dtgIkinciKultur.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgIkinciKultur.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
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

        private void dtgTuzOzellikleriLoad()
        {
            string sql = "Select T1.\"U_TedarikciAdi\" as \"Tedarikçi Adı\",T1.\"U_PartiNo\" as \"Parti No\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ6\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            sda.Fill(dtgTuzOzellikleri_DataTable);

            //if (dt.Rows.Count == 0)
            //{
            //    string uretimdenCikissql = "Select (isnull(T4.CardName, '') + T1.ItemCode) as \"Tedarikçi Adı\",T2.BatchNum as \"Parti No\" from ";
            //    uretimdenCikissql += "OIGE T0 inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
            //    uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry ";
            //    uretimdenCikissql += "left join OCRD T4 ON T2.CardCode = T4.CardCode ";
            //    uretimdenCikissql += "inner join OITM T5 ON T5.ItemCode = T2.ItemCode ";
            //    uretimdenCikissql += "where T0.U_BatchNumber = '" + partiNo + "' and T5.\"ItemCode\" = 'ISM-10188'";

            //    cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //    sda = new SqlDataAdapter(cmd);
            //    sda.Fill(dt);
            //}
            if (dtgTuzOzellikleri_DataTable.Rows.Count == 0)
            {
                #region daha önce girilmiş analiz var mı sorgu chn 20220802
                string baseref = txtUretimFisNo.Text;

                if (type == "IST001")
                {
                    sql = "Select T1.\"U_TedarikciAdi\" as \"Tedarikçi Adı\",T1.\"U_PartiNo\" as \"Parti No\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ6\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + pastorizasyonpartino + "'";

                    //sql = "Select T1.\"U_TedarikciAdi\" as \"Tedarikçi Adı\",T1.\"U_PartiNo\" as \"Parti No\" from \"@AIF_AYRPRSS_ANLZ\" as T0 INNER JOIN \"@AIF_AYRPRSS_ANLZ6\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

                    //sql = "SELECT DISTINCT T4.\"U_TedarikciAdi\" as \"Tedarikçi Adı\",T2.\"BatchNum\" AS \"Parti No\" FROM OIGE T0  INNER JOIN IGE1 T1 ON T0.\"DocEntry\"=T1.\"DocEntry\"  INNER JOIN IBT1 T2 ON T2.\"BaseEntry\"=T0.\"DocEntry\"  LEFT JOIN \"@AIF_AYRPRSS_ANLZ\" as T3 ON T2.\"BatchNum\" = T3.\"U_PartiNo\"  LEFT JOIN \"@AIF_AYRPRSS_ANLZ6\" as T4 ON T3.\"DocEntry\" = T4.\"DocEntry\" inner join OITM O1 ON O1.ItemCode = T1.ItemCode  WHERE T1.\"BaseRef\" = '" + baseref + "' AND ISNULL(T0.\"U_BatchNumber\",'') <>'' AND T2.\"BaseType\" = '60' AND U_AnalizGrubu = '01'  order by T2.\"BatchNum\" ";

                }
                else if (type == "IST009")
                {
                    sql = "select (SELECT TOP 1 ttt.CardName FROM IBT1 AS ttt WITH (NOLOCK) WHERE ttt.BatchNum = T2.BatchNum ) AS \"Tedarikçi Adı\",T2.\"BatchNum\" as 'Parti No' from IGE1 I1 WITH (NOLOCK) inner join OITM O1 WITH (NOLOCK) ON O1.ItemCode = I1.ItemCode INNER JOIN IBT1 T2 WITH (NOLOCK) ON T2.\"BaseEntry\" = I1.\"DocEntry\" and T2.ItemCode = I1.ItemCode where I1.BaseType = '202' and I1.BaseRef = '" + baseref + "' AND U_AnalizGrubu = '01' ";
                }






                cmd = new SqlCommand(sql, Connection.sql);
                sda = new SqlDataAdapter(cmd);
                //DataTable dt = new DataTable(); 
                sda.Fill(dtgTuzOzellikleri_DataTable);
                #endregion
            }

            if (dtgTuzOzellikleri_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgTuzOzellikleri_DataTable.NewRow();
                dr["Tedarikçi Adı"] = "";

                dtgTuzOzellikleri_DataTable.Rows.Add(dr);
            }

            Connection.sql.Close();

            #region eski analiz getirme sorgusu 20220802
            //if (dtgIkinciKultur_DataTable.Rows.Count == 0)
            //{
            //    sql = "Select \"U_Deger3\" from \"@AIF_GNLKANLZPRM\" where \"U_Kod\" ='6'";
            //    cmd = new SqlCommand(sql, Connection.sql);

            //    if (Connection.sql.State != ConnectionState.Open)
            //        Connection.sql.Open();

            //    sda = new SqlDataAdapter(cmd);
            //    DataTable dt_Sorgu = new DataTable();
            //    DataTable dt_Line = new DataTable();
            //    sda.Fill(dt_Sorgu);

            //    //dtgSecim.DataSource = dt;
            //    //dtSecim = dt;

            //    Connection.sql.Close();

            //    if (dt_Sorgu.Rows.Count > 0)
            //    {
            //        string uretimdenCikissql = "";

            //        uretimdenCikissql = "Select T1.LineNum ";
            //        uretimdenCikissql += " from ";
            //        uretimdenCikissql += "OIGE T0 ";
            //        uretimdenCikissql += "inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
            //        uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry ";
            //        uretimdenCikissql += "and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry ";
            //        uretimdenCikissql += "inner join OITM T5 ON T5.ItemCode = T2.ItemCode where T0.U_BatchNumber = '" + partiNo + "' and T5.U_ItemGroup3 = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"U_UVTUrunTipi\"='1' order by Case when ISNULL(T1.\"LineNum\",'') = '' then 0 else cast(T1.\"LineNum\" as int) end";

            //        cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //        sda = new SqlDataAdapter(cmd);
            //        sda.Fill(dt_Line);

            //        if (dt_Line.Rows.Count > 1)
            //        {
            //            string itemgrp = dt_Sorgu.Rows[0][0].ToString();

            //            uretimdenCikissql = "Select (Select T10.CardName from IBT1 T9 ";
            //            uretimdenCikissql += "inner join OCRD T10 ON T9.CardCode = T10.CardCode where T9.BatchNum = T2.BatchNum) + T1.\"ItemCode\" as 'Tedarikçi Adı',T2.BatchNum as \"Parti No\"  ";
            //            uretimdenCikissql += " from OIGE T0 ";
            //            uretimdenCikissql += "inner join IGE1 T1 ON T0.DocEntry = T1.DocEntry ";
            //            uretimdenCikissql += "inner join IBT1 T2 ON T2.BaseEntry = T1.DocEntry ";
            //            uretimdenCikissql += "and T2.BaseType = 60 and T2.ItemCode = T1.ItemCode and T2.BaseLinNum = T1.LineNum and T2.BsDocEntry = T1.BaseEntry inner join OITM T5 ON T5.ItemCode = T2.ItemCode where T0.U_BatchNumber = '" + partiNo + "' and T5.U_ItemGroup3 = '" + itemgrp + "' and \"U_UVTUrunTipi\"='1' and T1.\"LineNum\" > '" + dt_Line.Rows[0][0].ToString() + "'";

            //            cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
            //            sda = new SqlDataAdapter(cmd);

            //            dtgIkinciKultur_DataTable.Rows.Clear();
            //            //dt.Columns.Clear();

            //            //dt_Result.Rows.Clear();
            //            sda.Fill(dtgIkinciKultur_DataTable);
            //        }
            //    }
            //} 
            #endregion

            //Commit
            dtgTuzOzellikleri.DataSource = dtgTuzOzellikleri_DataTable;

            dtgTuzOzellikleri.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgTuzOzellikleri.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dtgTuzOzellikleri.EnableHeadersVisualStyles = false;
            dtgTuzOzellikleri.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgTuzOzellikleri.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);


            dtgTuzOzellikleri.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            foreach (DataGridViewColumn column in dtgTuzOzellikleri.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;
        }

        #region İkinci ekran datagrid 1,2,3 sorguları
        private void dtgSutunOzellikleriLoad_IkinciEkran()
        {
            //string sql = "Select T1.\"ItemCode\" as \"Malzeme Kodu\",T1.\"Dscription\" as \"Malzeme Tanımı\", SUM(T1.\"Quantity\") as \"Miktar\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' group by T1.\"ItemCode\",T1.\"Dscription\"";

            string sql = "Select T1.\"U_SutTuru\" as \"Süt Türü\",T1.\"U_SutunKaynagi\" as \"Sütün Kaynağı\", T1.\"U_Brix\" as \"Brix\", T1.\"U_PH\" as \"PH\", T1.\"U_SH\" as \"SH\", T1.\"U_Yag\" as \"Yağ\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ7\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtgSutunOzellikleri_DataTable);

            if (type == "IST001")
            {
                if (dtgSutunOzellikleri_DataTable.Rows.Count == 0)
                {
                    #region daha önce girilmiş analiz var mı sorgu chn 20220802
                    //string baseref = txtUretimFisNo.Text;

                    //sql = "SELECT T4.\"U_SutTuru\" as \"Süt Türü\",T4.\"U_SutunKaynagi\" as \"Sütün Kaynağı\", T4.\"U_Brix\" as \"Brix\", T4.\"U_PH\" as \"PH\", T4.\"U_SH\" as \"SH\",T4.\"U_Yag\" as \"Yağ\" FROM OIGE T0  INNER JOIN IGE1 T1 ON T0.\"DocEntry\"=T1.\"DocEntry\"  INNER JOIN IBT1 T2 ON T2.\"BaseEntry\"=T0.\"DocEntry\"  LEFT JOIN \"@AIF_AYRPRSS_ANLZ\" as T3 ON T2.\"BatchNum\" = T3.\"U_PartiNo\"  LEFT JOIN \"@AIF_AYRPRSS_ANLZ7\" as T4 ON T3.\"DocEntry\" = T4.\"DocEntry\"  WHERE T1.\"BaseRef\" = '" + baseref + "' AND ISNULL(T0.\"U_BatchNumber\",'') <>'' AND T2.\"BaseType\" = '60' ORDER by T2.\"BatchNum\"   ";

                    sql = "Select T1.\"U_SutTuru\" as \"Süt Türü\",T1.\"U_SutunKaynagi\" as \"Sütün Kaynağı\", T1.\"U_Brix\" as \"Brix\", T1.\"U_PH\" as \"PH\", T1.\"U_SH\" as \"SH\", T1.\"U_Yag\" as \"Yağ\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ7\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + pastorizasyonpartino + "'";

                    cmd = new SqlCommand(sql, Connection.sql);
                    sda = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    dttemp = new DataTable();
                    sda.Fill(dtgSutunOzellikleri_DataTable);
                    #endregion

                }
            }

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

            Connection.sql.Close();

        }

        private void dtgYariMamulKaliteOzellikleriLoad_IkinciEkran()
        {

            string sql = "Select T1.\"U_PartiNo\" as \"Parti No\",T1.\"U_TKM\" as \"TKM\", T1.\"U_Brix\" as \"Brix\", T1.\"U_PH\" as \"PH\", T1.\"U_SH\" as \"SH\", T1.\"U_Yag\" as \"Yağ\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ8\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtgYariMamulKaliteOzellikleri_DataTable);

            if (type == "IST001")
            {
                if (dtgYariMamulKaliteOzellikleri_DataTable.Rows.Count == 0)
                {
                    #region daha önce girilmiş analiz var mı sorgu chn 20220802
                    //string baseref = txtUretimFisNo.Text;

                    //sql = "SELECT T4.\"U_PartiNo\" as \"Parti No\",T4.\"U_TKM\" as \"TKM\", T4.\"U_Brix\" as \"Brix\", T4.\"U_PH\" as \"PH\", T4.\"U_SH\" as \"SH\",T4.\"U_Yag\" as \"Yağ\" FROM OIGE T0  INNER JOIN IGE1 T1 ON T0.\"DocEntry\"=T1.\"DocEntry\"  INNER JOIN IBT1 T2 ON T2.\"BaseEntry\"=T0.\"DocEntry\" LEFT JOIN \"@AIF_AYRPRSS_ANLZ\" as T3 ON T2.\"BatchNum\" = T3.\"U_PartiNo\"  LEFT JOIN \"@AIF_AYRPRSS_ANLZ8\" as T4 ON T3.\"DocEntry\" = T4.\"DocEntry\"  WHERE T1.\"BaseRef\" = '" + baseref + "' AND ISNULL(T0.\"U_BatchNumber\",'') <>'' AND T2.\"BaseType\" = '60' ORDER by T2.\"BatchNum\"  ";

                    sql = "Select T1.\"U_PartiNo\" as \"Parti No\",T1.\"U_TKM\" as \"TKM\", T1.\"U_Brix\" as \"Brix\", T1.\"U_PH\" as \"PH\", T1.\"U_SH\" as \"SH\", T1.\"U_Yag\" as \"Yağ\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ8\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + pastorizasyonpartino + "'";
                    cmd = new SqlCommand(sql, Connection.sql);
                    sda = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    dttemp = new DataTable();
                    sda.Fill(dtgYariMamulKaliteOzellikleri_DataTable);
                    #endregion

                }
            }

            if (dtgYariMamulKaliteOzellikleri_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgYariMamulKaliteOzellikleri_DataTable.NewRow();
                //dr["Parti No"] = partiNo;
                dr["TKM"] = Convert.ToString("0", cultureTR);
                //dr["Protein"] = Convert.ToString("0", cultureTR);
                //dr["Tuz"] = Convert.ToString("0", cultureTR);
                dr["Brix"] = Convert.ToString("0", cultureTR);
                dr["PH"] = Convert.ToString("0", cultureTR);
                dr["SH"] = Convert.ToString("0", cultureTR);
                dr["Yağ"] = Convert.ToString("0", cultureTR);

                dtgYariMamulKaliteOzellikleri_DataTable.Rows.Add(dr);
            }

            Connection.sql.Close();
        }

        private void dtgInkubasyonTakipOzellikleriLoad_IkinciEkran()
        {
            string sql = "";

            sql = "Select T1.\"U_KontrolNo\" as \"Kontrol No\",T1.\"U_Saat\" as \"Saat\", T1.\"U_UrunSicakligi\" as \"Ürün Sıcaklığı\",T1.\"U_OdaSicakligi\" as \"Oda Sıcaklığı\", T1.\"U_PH\" as \"PH\", T1.\"U_KontrolEdenPers\" as \"Kontrol Eden Personel\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ9\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtgInkubasyonTakip_DataTable);

            if (type == "IST001")
            {
                if (dtgInkubasyonTakip_DataTable.Rows.Count == 0)
                {
                    #region daha önce girilmiş analiz var mı sorgu chn 20220802
                    //string baseref = txtUretimFisNo.Text;

                    //sql = " SELECT T4.\"U_KontrolNo\" as \"Kontrol No\",T4.\"U_Saat\" as \"Saat\", T4.\"U_UrunSicakligi\" as \"Ürün Sıcaklığı\",T4.\"U_OdaSicakligi\" as \"Oda Sıcaklığı\", T4.\"U_PH\" as \"PH\", T4.\"U_KontrolEdenPers\" as \"Kontrol Eden Personel\" FROM OIGE T0  INNER JOIN IGE1 T1 ON T0.\"DocEntry\"=T1.\"DocEntry\"  INNER JOIN IBT1 T2 ON T2.\"BaseEntry\"=T0.\"DocEntry\"  LEFT JOIN \"@AIF_AYRPRSS_ANLZ\" as T3 ON T2.\"BatchNum\" = T3.\"U_PartiNo\"  LEFT JOIN \"@AIF_AYRPRSS_ANLZ9\" as T4 ON T3.\"DocEntry\" = T4.\"DocEntry\"  WHERE T1.\"BaseRef\" = '" + baseref + "' AND ISNULL(T0.\"U_BatchNumber\",'') <>''  AND T2.\"BaseType\" = '60' ORDER by T2.\"BatchNum\"";

                    sql = "Select T1.\"U_KontrolNo\" as \"Kontrol No\",T1.\"U_Saat\" as \"Saat\", T1.\"U_UrunSicakligi\" as \"Ürün Sıcaklığı\",T1.\"U_OdaSicakligi\" as \"Oda Sıcaklığı\", T1.\"U_PH\" as \"PH\", T1.\"U_KontrolEdenPers\" as \"Kontrol Eden Personel\" from \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ9\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + pastorizasyonpartino + "'";
                    cmd = new SqlCommand(sql, Connection.sql);
                    sda = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    dttemp = new DataTable();
                    sda.Fill(dtgInkubasyonTakip_DataTable);
                    #endregion


                }
            }

            if (dtgInkubasyonTakip_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgInkubasyonTakip_DataTable.NewRow();
                dr["Kontrol No"] = Convert.ToString("1", cultureTR);
                //dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                dr["Ürün Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Oda Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["PH"] = Convert.ToString("0", cultureTR);

                dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("2", cultureTR);
                ////dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["Ürün Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["Oda Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("3", cultureTR);
                ////dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["Ürün Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["Oda Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("4", cultureTR);
                ////dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["Ürün Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["Oda Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("5", cultureTR);
                ////dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["Ürün Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["Oda Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);
            }

            Connection.sql.Close();

            #region Kontrol listesi oluşturma 

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Saat",
                kontroledilmesigerekenKolon = "Sorumlu Personel"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Ürün Sıcaklığı",
                kontroledilmesigerekenKolon = "Saat"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "PH",
                kontroledilmesigerekenKolon = "Ürün Sıcaklığı"
            });

            //kontrolListesis.Add(new kontrolListesi
            //{
            //    aktifKolon = "PH",
            //    kontroledilmesigerekenKolon = "Oda Sıcaklığı"
            //});

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Kontrol Eden Personel",
                kontroledilmesigerekenKolon = "PH"
            });

            #endregion
        }
        #endregion İkinci ekran datagrid 1,2,3 sorguları

        private void button9_Click(object sender, EventArgs e) //açıklama butonu
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();
        }

        private void button10_Click(object sender, EventArgs e) //sağa git butonu
        {
            PartyNo = txtPartiNo.Text;
            UretimSiparisNo = txtUretimFisNo.Text;
            UretilenUrunTanimi = txtUrunTanimi.Text;
            UretimAciklamasi = txtAciklama.Text;
            AyranProsesTakip_1_1 nesne = new AyranProsesTakip_1_1(type, kullaniciid, UretimFisNo, partiNo, UrunTanimi, istasyon, row, tarih1, UrunGrubu, dtgMamulOzellikleri1_DataTable, dtgMamulOzellikleri2_DataTable, dtgPihtiKirim_DataTable, dtgBirinciKultur_DataTable, dtgIkinciKultur_DataTable, dtgTuzOzellikleri_DataTable, dtgSutunOzellikleri_DataTable, dtgYariMamulKaliteOzellikleri_DataTable, dtgInkubasyonTakip_DataTable, txtAciklama);
            nesne.ShowDialog();
            //txtAciklama.Text = UretimAciklamasi;

            if (AyranProsesTakip_1_1.geriDonme == "OzeteDon")
            {
                btnOzetEkanaDon.PerformClick();
            }
        }

        private void dtgMamulOzellikleri1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (type == "IST001") //Bu ekrana veri yalnızca pastorizasyon istasyonunda girilir. Ayran istasyonunda değil.
            {
                return;
            }

            CustomMsgBtn.Show("Veri girişi sadece sarf etme ekranında yapılmalıdır.", "UYARI", "TAMAM");
            return;
            #region Elle girilmeyecek artık sarf etten otomatik geliyor.
            //if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Yağlı Süt Miktarı" || dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Yağsız Süt Miktarı" || dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Toplam Su Miktarı" || dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Tuz Miktarı")
            //{
            //    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOzellikleri1, false);
            //    n.ShowDialog();

            //    ayranTuzOraniYariMamulToplamiHesapla();
            //}
            //else if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Proses Başlangıç Saati")
            //{
            //    SaatTarihGirisi n = new SaatTarihGirisi(dtgMamulOzellikleri1);
            //    n.ShowDialog();
            //} 
            #endregion
        }

        private void dtgMamulOzellikleri2_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (type == "IST001") //Bu ekrana veri yalnızca pastorizasyon istasyonunda girilir. Ayran istasyonunda değil.
            {
                return;
            }

            bool cvp = true;

            cvp = Kontrol(dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name, dtgMamulOzellikleri2, null);

            if (!cvp)
            {
                return;
            }

            if (dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "Pastörizasyon Sıcaklığı" || dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "Pastörizasyon Süresi" || dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "Mayalama Sıcaklığı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOzellikleri2, false);
                n.ShowDialog();
            }
            else if (dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "Mayalama Saati")
            {
                SaatTarihGirisi n = new SaatTarihGirisi(dtgMamulOzellikleri2);
                n.ShowDialog();
            }
            else if (dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "Sorumlu Personel")
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

                    SelectList selectList = new SelectList(sql1, dtgMamulOzellikleri2, -1, 5, _autoresizerow: false);
                    selectList.ShowDialog();

                    //dtgProsesOzellikleri1.AutoResizeRows();
                }
            }
            else if (dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "Süt Vakum")
            {
                string sql1 = "Select '0' as \"Kod\",'Var' as \"Aciklama\" ";
                sql1 += " UNION ALL ";
                sql1 += "Select '1' as \"Kod\",'Yok' as \"Aciklama\" ";

                SelectList selectList = new SelectList(sql1, dtgMamulOzellikleri2, -1, 2, _autoresizerow: false);
                selectList.ShowDialog();
            }
        }

        private void dtgPihtiKirim_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (type == "IST001") //Bu ekrana veri yalnızca pastorizasyon istasyonunda girilir. Ayran istasyonunda değil.
            {
                return;
            }

            bool cvp = true;

            if (dtgPihtiKirim.Columns[e.ColumnIndex].Name == "Pompa Basıncı")
            {
                cvp = Kontrol(dtgPihtiKirim.Columns[e.ColumnIndex].Name, dtgPihtiKirim, dtgMamulOzellikleri2);
            }
            else
            {
                cvp = Kontrol(dtgPihtiKirim.Columns[e.ColumnIndex].Name, dtgPihtiKirim, null);
            }

            if (!cvp)
            {
                return;
            }



            if (dtgPihtiKirim.Columns[e.ColumnIndex].Name == "Pompa Basıncı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgPihtiKirim, false);
                n.ShowDialog();
            }
            else if (dtgPihtiKirim.Columns[e.ColumnIndex].Name == "Başlama Saati" || dtgPihtiKirim.Columns[e.ColumnIndex].Name == "Bitiş Saati")
            {
                SaatTarihGirisi n = new SaatTarihGirisi(dtgPihtiKirim);
                n.ShowDialog();

                Tuple<DateTime, DateTime> resp = null;
                Helper help = new Helper();
                var baslangicSaati = dtgPihtiKirim.Rows[e.RowIndex].Cells["Başlama Saati"].Value.ToString();
                var bitisSaati = dtgPihtiKirim.Rows[e.RowIndex].Cells["Bitiş Saati"].Value.ToString();

                if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                {
                    resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                    TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                    dtgPihtiKirim.Rows[0].Cells["Toplam Geçen Süre"].Value = girisCikisFarki.TotalMinutes.ToString();
                }
                else
                {
                    dtgPihtiKirim.Rows[0].Cells["Toplam Geçen Süre"].Value = "0";
                }
            }
        }

        private void ayranTuzOraniYariMamulToplamiHesapla()
        {
            //Yağlı Süt Miktarı"] = Convert.To
            //Yağsız Süt Miktarı"] = Convert.T
            //Toplam Su Miktarı"] = Convert.To
            //Tuz Miktarı"] = Convert.ToString
            //Ayran Tuz Oranı"] = Convert.ToSt
            //Toplam Ayran Yarı Mamül Miktarı"

            var yagliSutMiktari = dtgMamulOzellikleri1.Rows[0].Cells["Yağlı Süt Miktarı"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["Yağlı Süt Miktarı"].Value);
            var yagsizSutMiktari = dtgMamulOzellikleri1.Rows[0].Cells["Yağsız Süt Miktarı"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["Yağsız Süt Miktarı"].Value);
            var toplamSuMiktari = dtgMamulOzellikleri1.Rows[0].Cells["Toplam Su Miktarı"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["Toplam Su Miktarı"].Value);
            var tuzMiktari = dtgMamulOzellikleri1.Rows[0].Cells["Tuz Miktarı"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["Tuz Miktarı"].Value);

            if (tuzMiktari > 0)
            {
                var sonuc = tuzMiktari / (yagliSutMiktari + yagsizSutMiktari + toplamSuMiktari);
                dtgMamulOzellikleri1.Rows[0].Cells["Ayran Tuz Oranı"].Value = sonuc;
            }

            dtgMamulOzellikleri1.Rows[0].Cells["Toplam Ayran Yarı Mamül Miktarı"].Value = yagliSutMiktari + yagsizSutMiktari + toplamSuMiktari + tuzMiktari;

            //var tuzMiktari = dtgMamulOzellikleri1.Rows[0].Cells["Tuz Miktarı"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["Tuz Miktarı"].Value);

            //var sonuc = pihtiKirimBitis + pihtiKirimBaslangic;
            //if (sonuc > 0)
            //{
            //    dtgMamulOzellikleri1.Rows[0].Cells["Toplam Geçen Süre"].Value = sonuc.ToString();
            //}
        }

        public Tuple<DateTime, DateTime> SaatDuzenle(string baslangicSaati, string bitisSaati)
        {
            DateTime dtBaslangic = DateTime.Now;
            DateTime dtBitis = DateTime.Now;

            if (Convert.ToInt32(baslangicSaati.Replace(":", "")) > Convert.ToInt32(bitisSaati.Replace(":", "")))
            {
                TimeSpan time = new TimeSpan(1, Convert.ToInt32(bitisSaati.Substring(0, 2)), Convert.ToInt32(bitisSaati.Substring(3, 2)), 0);

                dtBitis = dtBitis.Date + time;

                time = new TimeSpan(0, Convert.ToInt32(baslangicSaati.Substring(0, 2)), Convert.ToInt32(baslangicSaati.Substring(3, 2)), 0);

                dtBaslangic = dtBaslangic.Date + time;
            }
            else
            {
                TimeSpan time = new TimeSpan(0, Convert.ToInt32(bitisSaati.Substring(0, 2)), Convert.ToInt32(bitisSaati.Substring(3, 2)), 0);

                dtBitis = dtBitis.Date + time;

                time = new TimeSpan(0, Convert.ToInt32(baslangicSaati.Substring(0, 2)), Convert.ToInt32(baslangicSaati.Substring(3, 2)), 0);

                dtBaslangic = dtBaslangic.Date + time;
            }

            return Tuple.Create(dtBaslangic, dtBitis);
        }

        private void dtgBirinciKultur_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (type == "IST001") //Bu ekrana veri yalnızca pastorizasyon istasyonunda girilir. Ayran istasyonunda değil.
            {
                return;
            }

            CustomMsgBtn.Show("Veri girişi sadece sarf etme ekranında yapılmalıdır.", "UYARI", "TAMAM");
            #region Elle girilmeyecek sarf etme ekranında girilecek.
            //if (dtgBirinciKultur.Columns[e.ColumnIndex].Name == "Kullanılan Miktar")
            //{
            //    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgBirinciKultur, false);
            //    n.ShowDialog();
            //} 
            #endregion
            //else if (dtgPihtiKirim.Columns[e.ColumnIndex].Name == "Başlama Saati" || dtgPihtiKirim.Columns[e.ColumnIndex].Name == "Bitiş Saati")
            //{
            //    SaatTarihGirisi n = new SaatTarihGirisi(dtgPihtiKirim);
            //    n.ShowDialog();
            //}
        }

        private void dtgIkinciKultur_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (type == "IST001") //Bu ekrana veri yalnızca pastorizasyon istasyonunda girilir. Ayran istasyonunda değil.
            {
                return;
            }

            CustomMsgBtn.Show("Veri girişi sadece sarf etme ekranında yapılmalıdır.", "UYARI", "TAMAM");
            #region Elle girilmeyecek sarf etme ekranında girilecek.
            //if (dtgIkinciKultur.Columns[e.ColumnIndex].Name == "Kullanılan Miktar")
            //{
            //    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgIkinciKultur, false);
            //    n.ShowDialog();
            //} 
            #endregion
            //else if (dtgPihtiKirim.Columns[e.ColumnIndex].Name == "Başlama Saati" || dtgPihtiKirim.Columns[e.ColumnIndex].Name == "Bitiş Saati")
            //{
            //    SaatTarihGirisi n = new SaatTarihGirisi(dtgPihtiKirim);
            //    n.ShowDialog();
            //}
        }

        private void dtgTuzOzellikleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (type == "IST001") //Bu ekrana veri yalnızca pastorizasyon istasyonunda girilir. Ayran istasyonunda değil.
            {
                return;
            }

            CustomMsgBtn.Show("Veri girişi sadece sarf etme ekranında yapılmalıdır.", "UYARI", "TAMAM");

            #region Elle girilmeyecek sarf etme ekranında girilecek.
            //if (dtgTuzOzellikleri.Columns[e.ColumnIndex].Name == "Tedarikçi Adı")
            //{
            //    string sql1 = "Select ' ' as \"Satıcı Kodu\",' ' as \"Satıcı Adı\" ";
            //    sql1 += " UNION ALL ";
            //    sql1 += "Select \"CardCode\" as \"Satıcı Kodu\", \"CardName\" as \"Satıcı Adı\" from OCRD where \"CardType\" = 'S' ";

            //    SelectList selectList = new SelectList(sql1, dtgTuzOzellikleri, -1, 0, _autoresizerow: false);
            //    selectList.ShowDialog();
            //} 
            #endregion
        }

        #region eski tablo kaydetme
        public static void TabloyaKaydet()
        {
            //ayranProsesOzellikleri1s = new List<AyranProsesOzellikleri1>();
            //ayranProsesOzellikleri2s = new List<AyranProsesOzellikleri2>();
            //ayranPihtiKirims = new List<AyranPihtiKirim>();
            //ayranBirinciKulturs = new List<AyranBirinciKultur>();
            //ayranIkinciKulturs = new List<AyranIkinciKultur>();
            //ayranTuzOzellikleris = new List<AyranTuzOzellikleri>();
            //ayranSutOzellikleris = new List<AyranSutOzellikleri>();
            //ayranYariMamulKaliteOzellikleris = new List<AyranYariMamulKaliteOzellikleri>();
            //ayranInkubasyonOzellikleris = new List<AyranInkubasyonOzellikleri>();

            //nesne.PartiNo = PartyNo;
            //nesne.Aciklama = UretimAciklamasi;
            //nesne.UrunKodu = "";
            //nesne.UrunTanimi = UretilenUrunTanimi;
            //nesne.UretimTarihi = tarih1;

            //foreach (DataGridViewRow dr in dtgMamulOzellikleri1Static.Rows)
            //{
            //    AyranProsesOzellikleri1 = new AyranProsesOzellikleri1();
            //    AyranProsesOzellikleri1.UrunGrubu = dr.Cells["Ürün Grubu"].Value == DBNull.Value ? "" : dr.Cells["Ürün Grubu"].Value.ToString();
            //    AyranProsesOzellikleri1.ProsesBaslangicSaati = dr.Cells["Proses Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Proses Başlangıç Saati"].Value.ToString();
            //    AyranProsesOzellikleri1.YagliSutMiktari = dr.Cells["Yağlı Süt Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağlı Süt Miktarı"].Value);
            //    AyranProsesOzellikleri1.YagsizSutMiktari = dr.Cells["Yağsız Süt Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağsız Süt Miktarı"].Value);
            //    AyranProsesOzellikleri1.ToplamSuMiktari = dr.Cells["Toplam Su Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Su Miktarı"].Value);
            //    AyranProsesOzellikleri1.TuzMiktari = dr.Cells["Tuz Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tuz Miktarı"].Value);
            //    AyranProsesOzellikleri1.AyranTuzOrani = dr.Cells["Ayran Tuz Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Ayran Tuz Oranı"].Value);
            //    AyranProsesOzellikleri1.ToplamAyranYariMamulMiktari = dr.Cells["Toplam Ayran Yarı Mamül Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Ayran Yarı Mamül Miktarı"].Value);

            //    ayranProsesOzellikleri1s.Add(AyranProsesOzellikleri1);
            //}

            //nesne.ayranProsesOzellikleri1s = ayranProsesOzellikleri1s.ToArray();

            //foreach (DataGridViewRow dr in dtgMamulOzellikleri2Static.Rows)
            //{
            //    AyranProsesOzellikleri2 = new AyranProsesOzellikleri2();
            //    AyranProsesOzellikleri2.PastorizasyonSicakligi = dr.Cells["Pastörizasyon Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastörizasyon Sıcaklığı"].Value);
            //    AyranProsesOzellikleri2.PastorizasyonSuresi = dr.Cells["Pastörizasyon Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastörizasyon Süresi"].Value);
            //    AyranProsesOzellikleri2.SutVakum = dr.Cells["Süt Vakum"].Value == DBNull.Value ? "" : dr.Cells["Süt Vakum"].Value.ToString();
            //    AyranProsesOzellikleri2.MayalamaSaati = dr.Cells["Mayalama Saati"].Value == DBNull.Value ? "" : dr.Cells["Mayalama Saati"].Value.ToString();
            //    AyranProsesOzellikleri2.MayalamaSicakligi = dr.Cells["Mayalama Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Mayalama Sıcaklığı"].Value);
            //    AyranProsesOzellikleri2.SorumluPersonel = dr.Cells["Sorumlu Personel"].Value == DBNull.Value ? "" : dr.Cells["Sorumlu Personel"].Value.ToString();

            //    ayranProsesOzellikleri2s.Add(AyranProsesOzellikleri2);
            //}

            //nesne.ayranProsesOzellikleri2s = ayranProsesOzellikleri2s.ToArray();

            //foreach (DataGridViewRow dr in dtgPihtiKirimOzellikleriStatic.Rows)
            //{
            //    AyranPihtiKirim = new AyranPihtiKirim();
            //    AyranPihtiKirim.PompaBasinci = dr.Cells["Pompa Basıncı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pompa Basıncı"].Value);
            //    AyranPihtiKirim.BaslamaSaati = dr.Cells["Başlama Saati"].Value == DBNull.Value ? "" : dr.Cells["Başlama Saati"].Value.ToString();
            //    AyranPihtiKirim.BitisSaati = dr.Cells["Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Bitiş Saati"].Value.ToString();
            //    AyranPihtiKirim.ToplamGecenSure = dr.Cells["Toplam Geçen Süre"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Geçen Süre"].Value);

            //    ayranPihtiKirims.Add(AyranPihtiKirim);
            //}

            //nesne.ayranPihtiKirims = ayranPihtiKirims.ToArray();

            //foreach (DataGridViewRow dr in dtgBirinciKulturBilgileriStatic.Rows)
            //{
            //    AyranBirinciKultur = new AyranBirinciKultur();

            //    AyranBirinciKultur.KullanilanMiktar = dr.Cells["Kullanılan Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kullanılan Miktar"].Value);
            //    AyranBirinciKultur.TedarikciAdiveKulturKodu = dr.Cells["Tedarikçi Adı ve Kültür Kodu"].Value == DBNull.Value ? "" : dr.Cells["Tedarikçi Adı ve Kültür Kodu"].Value.ToString();
            //    AyranBirinciKultur.LotNo = dr.Cells["Lot No"].Value == DBNull.Value ? "" : dr.Cells["Lot No"].Value.ToString();

            //    ayranBirinciKulturs.Add(AyranBirinciKultur);
            //}

            //nesne.ayranBirinciKulturs = ayranBirinciKulturs.ToArray();

            //foreach (DataGridViewRow dr in dtgIkinciKulturBilgileriStatic.Rows)
            //{
            //    AyranIkinciKultur = new AyranIkinciKultur();

            //    AyranIkinciKultur.KullanilanMiktar = dr.Cells["Kullanılan Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kullanılan Miktar"].Value);
            //    AyranIkinciKultur.TedarikciAdiveKulturKodu = dr.Cells["Tedarikçi Adı ve Kültür Kodu"].Value == DBNull.Value ? "" : dr.Cells["Tedarikçi Adı ve Kültür Kodu"].Value.ToString();
            //    AyranIkinciKultur.LotNo = dr.Cells["Lot No"].Value == DBNull.Value ? "" : dr.Cells["Lot No"].Value.ToString();

            //    ayranIkinciKulturs.Add(AyranIkinciKultur);
            //}

            //nesne.ayranIkinciKulturs = ayranIkinciKulturs.ToArray();

            //foreach (DataGridViewRow dr in dtgTuzOzellikleriStatic.Rows)
            //{
            //    AyranTuzOzellikleri = new AyranTuzOzellikleri();

            //    AyranTuzOzellikleri.PartiNo = dr.Cells["Parti No"].Value == DBNull.Value ? "" : dr.Cells["Parti No"].Value.ToString();
            //    AyranTuzOzellikleri.TedarikciAdi = dr.Cells["Tedarikçi Adı"].Value == DBNull.Value ? "" : dr.Cells["Tedarikçi Adı"].Value.ToString();

            //    ayranTuzOzellikleris.Add(AyranTuzOzellikleri);
            //}

            //nesne.ayranTuzOzellikleris = ayranTuzOzellikleris.ToArray();

            //foreach (DataGridViewRow dr in dtgSutunOzellikleriStatic.Rows)
            //{
            //    AyranSutOzellikleri = new AyranSutOzellikleri();

            //    AyranSutOzellikleri.SutTuru = dr.Cells["Süt Türü"].Value == DBNull.Value ? "" : dr.Cells["Süt Türü"].Value.ToString();
            //    AyranSutOzellikleri.SutunKaynagi = dr.Cells["Sütün Kaynağı"].Value == DBNull.Value ? "" : dr.Cells["Sütün Kaynağı"].Value.ToString();
            //    AyranSutOzellikleri.Brix = dr.Cells["Brix"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Brix"].Value);
            //    AyranSutOzellikleri.PH = dr.Cells["PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH"].Value);
            //    AyranSutOzellikleri.SH = dr.Cells["SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH"].Value);
            //    AyranSutOzellikleri.Yag = dr.Cells["Yağ"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ"].Value);

            //    ayranSutOzellikleris.Add(AyranSutOzellikleri);
            //}

            //nesne.ayranSutOzellikleris = ayranSutOzellikleris.ToArray();

            //foreach (DataGridViewRow dr in dtgYariMamulKaliteOzellikleriStatic.Rows)
            //{
            //    AyranYariMamulKaliteOzellikleri = new AyranYariMamulKaliteOzellikleri();
            //    AyranYariMamulKaliteOzellikleri.PartiNo = dr.Cells["Parti No"].Value == DBNull.Value ? "" : dr.Cells["Parti No"].Value.ToString();
            //    AyranYariMamulKaliteOzellikleri.TKM = dr.Cells["TKM"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["TKM"].Value);
            //    //AyranYariMamulKaliteOzellikleri.Protein = dr.Cells["Protein"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Protein"].Value);
            //    //AyranYariMamulKaliteOzellikleri.Tuz = dr.Cells["Tuz"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tuz"].Value);
            //    AyranYariMamulKaliteOzellikleri.Brix = dr.Cells["Brix"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Brix"].Value);
            //    AyranYariMamulKaliteOzellikleri.PH = dr.Cells["PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH"].Value);
            //    AyranYariMamulKaliteOzellikleri.SH = dr.Cells["SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH"].Value);
            //    AyranYariMamulKaliteOzellikleri.Yag = dr.Cells["Yağ"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ"].Value);
            //    //AyranYariMamulKaliteOzellikleri.TatKokuKivam = dr.Cells["Tat Koku ve Kıvamı"].Value == DBNull.Value ? "" : dr.Cells["Tat Koku ve Kıvamı"].Value.ToString();

            //    ayranYariMamulKaliteOzellikleris.Add(AyranYariMamulKaliteOzellikleri);
            //}

            //nesne.ayranYariMamulKaliteOzellikleris = ayranYariMamulKaliteOzellikleris.ToArray();

            //foreach (DataGridViewRow dr in dtgInkubasyonTakipStatic.Rows)
            //{
            //    AyranInkubasyonOzellikleri = new AyranInkubasyonOzellikleri();
            //    AyranInkubasyonOzellikleri.KontrolNo = dr.Cells["Kontrol No"].Value == DBNull.Value ? "" : dr.Cells["Kontrol No"].Value.ToString();
            //    AyranInkubasyonOzellikleri.Saat = dr.Cells["Saat"].Value == DBNull.Value ? "" : dr.Cells["Saat"].Value.ToString();
            //    //AyranInkubasyonOzellikleri.Sicaklik = dr.Cells["Sıcaklık"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Sıcaklık"].Value);
            //    AyranInkubasyonOzellikleri.UrunSicakligi = dr.Cells["Ürün Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Ürün Sıcaklığı"].Value);
            //    AyranInkubasyonOzellikleri.OdaSicakligi = dr.Cells["Oda Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Oda Sıcaklığı"].Value);
            //    AyranInkubasyonOzellikleri.PH = dr.Cells["PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH"].Value);
            //    AyranInkubasyonOzellikleri.KontrolEdenPersonel = dr.Cells["Kontrol Eden Personel"].Value == DBNull.Value ? "" : dr.Cells["Kontrol Eden Personel"].Value.ToString();

            //    ayranInkubasyonOzellikleris.Add(AyranInkubasyonOzellikleri);
            //}

            //nesne.ayranInkubasyonOzellikleris = ayranInkubasyonOzellikleris.ToArray();

            //var resp = client.AddOrUpdateAyranProsesTakipAnaliz(nesne, Giris.dbName);

            //MessageBox.Show(resp.Description);

            //if (resp.Value == 0)
            //{
            //    btnOzet.PerformClick();
            //}
        }
        #endregion
        private void btnOnayla_Click(object sender, EventArgs e)
        {
            PartyNo = txtPartiNo.Text;
            UretimSiparisNo = txtUretimFisNo.Text;
            UretilenUrunTanimi = txtUrunTanimi.Text;
            UretimAciklamasi = txtAciklama.Text;
            //TabloyaKaydet();
            tabloyaKaydetmeIslemleri();
        }

        private void btnOzetEkanaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }

        public void tabloyaKaydetmeIslemleri()
        {
            try
            {
                AyranProsesTakipAnaliz nesne = new AyranProsesTakipAnaliz();

                AyranProsesOzellikleri1 AyranProsesOzellikleri1 = new AyranProsesOzellikleri1();
                List<AyranProsesOzellikleri1> ayranProsesOzellikleri1s = new List<AyranProsesOzellikleri1>();

                AyranProsesOzellikleri2 AyranProsesOzellikleri2 = new AyranProsesOzellikleri2();
                List<AyranProsesOzellikleri2> ayranProsesOzellikleri2s = new List<AyranProsesOzellikleri2>();

                AyranPihtiKirim AyranPihtiKirim = new AyranPihtiKirim();
                List<AyranPihtiKirim> ayranPihtiKirims = new List<AyranPihtiKirim>();

                AyranBirinciKultur AyranBirinciKultur = new AyranBirinciKultur();
                List<AyranBirinciKultur> ayranBirinciKulturs = new List<AyranBirinciKultur>();

                AyranIkinciKultur AyranIkinciKultur = new AyranIkinciKultur();
                List<AyranIkinciKultur> ayranIkinciKulturs = new List<AyranIkinciKultur>();

                AyranTuzOzellikleri AyranTuzOzellikleri = new AyranTuzOzellikleri();
                List<AyranTuzOzellikleri> ayranTuzOzellikleris = new List<AyranTuzOzellikleri>();

                AyranSutOzellikleri AyranSutOzellikleri = new AyranSutOzellikleri();
                List<AyranSutOzellikleri> ayranSutOzellikleris = new List<AyranSutOzellikleri>();

                AyranYariMamulKaliteOzellikleri AyranYariMamulKaliteOzellikleri = new AyranYariMamulKaliteOzellikleri();
                List<AyranYariMamulKaliteOzellikleri> ayranYariMamulKaliteOzellikleris = new List<AyranYariMamulKaliteOzellikleri>();

                AyranInkubasyonOzellikleri AyranInkubasyonOzellikleri = new AyranInkubasyonOzellikleri();
                List<AyranInkubasyonOzellikleri> ayranInkubasyonOzellikleris = new List<AyranInkubasyonOzellikleri>();


                //ayranProsesOzellikleri1s = new List<AyranProsesOzellikleri1>();
                //ayranProsesOzellikleri2s = new List<AyranProsesOzellikleri2>();
                //ayranPihtiKirims = new List<AyranPihtiKirim>();
                //ayranBirinciKulturs = new List<AyranBirinciKultur>();
                //ayranIkinciKulturs = new List<AyranIkinciKultur>();
                //ayranTuzOzellikleris = new List<AyranTuzOzellikleri>();
                //ayranSutOzellikleris = new List<AyranSutOzellikleri>();
                //ayranYariMamulKaliteOzellikleris = new List<AyranYariMamulKaliteOzellikleri>();
                //ayranInkubasyonOzellikleris = new List<AyranInkubasyonOzellikleri>();

                nesne.PartiNo = PartyNo;
                nesne.Aciklama = UretimAciklamasi;
                nesne.UrunKodu = "";
                nesne.UrunTanimi = UretilenUrunTanimi;
                nesne.UretimTarihi = tarih1;

                foreach (DataRow dr in dtgMamulOzellikleri1_DataTable.Rows)
                {
                    AyranProsesOzellikleri1 = new AyranProsesOzellikleri1();
                    AyranProsesOzellikleri1.UrunGrubu = dr["Ürün Grubu"] == DBNull.Value ? "" : dr["Ürün Grubu"].ToString();
                    AyranProsesOzellikleri1.ProsesBaslangicSaati = dr["Proses Başlangıç Saati"] == DBNull.Value ? "" : dr["Proses Başlangıç Saati"].ToString();
                    AyranProsesOzellikleri1.YagliSutMiktari = dr["Yağlı Süt Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağlı Süt Miktarı"]);
                    AyranProsesOzellikleri1.YagsizSutMiktari = dr["Yağsız Süt Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağsız Süt Miktarı"]);
                    AyranProsesOzellikleri1.ToplamSuMiktari = dr["Toplam Su Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Toplam Su Miktarı"]);
                    AyranProsesOzellikleri1.TuzMiktari = dr["Tuz Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Tuz Miktarı"]);
                    AyranProsesOzellikleri1.AyranTuzOrani = dr["Ayran Tuz Oranı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Ayran Tuz Oranı"]);
                    AyranProsesOzellikleri1.ToplamAyranYariMamulMiktari = dr["Toplam Ayran Yarı Mamül Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Toplam Ayran Yarı Mamül Miktarı"]);

                    ayranProsesOzellikleri1s.Add(AyranProsesOzellikleri1);
                }

                nesne.ayranProsesOzellikleri1s = ayranProsesOzellikleri1s.ToArray();

                foreach (DataRow dr in dtgMamulOzellikleri2_DataTable.Rows)
                {
                    AyranProsesOzellikleri2 = new AyranProsesOzellikleri2();
                    AyranProsesOzellikleri2.PastorizasyonSicakligi = dr["Pastörizasyon Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastörizasyon Sıcaklığı"]);
                    AyranProsesOzellikleri2.PastorizasyonSuresi = dr["Pastörizasyon Süresi"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastörizasyon Süresi"]);
                    AyranProsesOzellikleri2.SutVakum = dr["Süt Vakum"] == DBNull.Value ? "" : dr["Süt Vakum"].ToString();
                    AyranProsesOzellikleri2.MayalamaSaati = dr["Mayalama Saati"] == DBNull.Value ? "" : dr["Mayalama Saati"].ToString();
                    AyranProsesOzellikleri2.MayalamaSicakligi = dr["Mayalama Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Mayalama Sıcaklığı"]);
                    AyranProsesOzellikleri2.SorumluPersonel = dr["Sorumlu Personel"] == DBNull.Value ? "" : dr["Sorumlu Personel"].ToString();

                    ayranProsesOzellikleri2s.Add(AyranProsesOzellikleri2);
                }

                nesne.ayranProsesOzellikleri2s = ayranProsesOzellikleri2s.ToArray();

                foreach (DataRow dr in dtgPihtiKirim_DataTable.Rows)
                {
                    AyranPihtiKirim = new AyranPihtiKirim();
                    AyranPihtiKirim.PompaBasinci = dr["Pompa Basıncı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pompa Basıncı"]);
                    AyranPihtiKirim.BaslamaSaati = dr["Başlama Saati"] == DBNull.Value ? "" : dr["Başlama Saati"].ToString();
                    AyranPihtiKirim.BitisSaati = dr["Bitiş Saati"] == DBNull.Value ? "" : dr["Bitiş Saati"].ToString();
                    AyranPihtiKirim.ToplamGecenSure = dr["Toplam Geçen Süre"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Toplam Geçen Süre"]);

                    ayranPihtiKirims.Add(AyranPihtiKirim);
                }

                nesne.ayranPihtiKirims = ayranPihtiKirims.ToArray();

                foreach (DataRow dr in dtgBirinciKultur_DataTable.Rows)
                {
                    AyranBirinciKultur = new AyranBirinciKultur();

                    AyranBirinciKultur.KullanilanMiktar = dr["Kullanılan Miktar"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kullanılan Miktar"]);
                    AyranBirinciKultur.TedarikciAdiveKulturKodu = dr["Tedarikçi Adı ve Kültür Kodu"] == DBNull.Value ? "" : dr["Tedarikçi Adı ve Kültür Kodu"].ToString();
                    AyranBirinciKultur.LotNo = dr["Lot No"] == DBNull.Value ? "" : dr["Lot No"].ToString();

                    ayranBirinciKulturs.Add(AyranBirinciKultur);
                }

                nesne.ayranBirinciKulturs = ayranBirinciKulturs.ToArray();

                foreach (DataRow dr in dtgIkinciKultur_DataTable.Rows)
                {
                    AyranIkinciKultur = new AyranIkinciKultur();

                    AyranIkinciKultur.KullanilanMiktar = dr["Kullanılan Miktar"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kullanılan Miktar"]);
                    AyranIkinciKultur.TedarikciAdiveKulturKodu = dr["Tedarikçi Adı ve Kültür Kodu"] == DBNull.Value ? "" : dr["Tedarikçi Adı ve Kültür Kodu"].ToString();
                    AyranIkinciKultur.LotNo = dr["Lot No"] == DBNull.Value ? "" : dr["Lot No"].ToString();

                    ayranIkinciKulturs.Add(AyranIkinciKultur);
                }

                nesne.ayranIkinciKulturs = ayranIkinciKulturs.ToArray();

                foreach (DataRow dr in dtgTuzOzellikleri_DataTable.Rows)
                {
                    AyranTuzOzellikleri = new AyranTuzOzellikleri();

                    AyranTuzOzellikleri.PartiNo = dr["Parti No"] == DBNull.Value ? "" : dr["Parti No"].ToString();
                    AyranTuzOzellikleri.TedarikciAdi = dr["Tedarikçi Adı"] == DBNull.Value ? "" : dr["Tedarikçi Adı"].ToString();

                    ayranTuzOzellikleris.Add(AyranTuzOzellikleri);
                }

                nesne.ayranTuzOzellikleris = ayranTuzOzellikleris.ToArray();

                foreach (DataRow dr in dtgSutunOzellikleri_DataTable.Rows)
                {
                    AyranSutOzellikleri = new AyranSutOzellikleri();

                    AyranSutOzellikleri.SutTuru = dr["Süt Türü"] == DBNull.Value ? "" : dr["Süt Türü"].ToString();
                    AyranSutOzellikleri.SutunKaynagi = dr["Sütün Kaynağı"] == DBNull.Value ? "" : dr["Sütün Kaynağı"].ToString();
                    AyranSutOzellikleri.Brix = dr["Brix"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Brix"]);
                    AyranSutOzellikleri.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    AyranSutOzellikleri.SH = dr["SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SH"]);
                    AyranSutOzellikleri.Yag = dr["Yağ"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağ"]);

                    ayranSutOzellikleris.Add(AyranSutOzellikleri);
                }

                nesne.ayranSutOzellikleris = ayranSutOzellikleris.ToArray();

                foreach (DataRow dr in dtgYariMamulKaliteOzellikleri_DataTable.Rows)
                {
                    AyranYariMamulKaliteOzellikleri = new AyranYariMamulKaliteOzellikleri();
                    AyranYariMamulKaliteOzellikleri.PartiNo = dr["Parti No"] == DBNull.Value ? "" : dr["Parti No"].ToString();
                    AyranYariMamulKaliteOzellikleri.TKM = dr["TKM"] == DBNull.Value ? 0 : Convert.ToDouble(dr["TKM"]);
                    //AyranYariMamulKaliteOzellikleri.Protein = dr["Protein"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Protein"]);
                    //AyranYariMamulKaliteOzellikleri.Tuz = dr["Tuz"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Tuz"]);
                    AyranYariMamulKaliteOzellikleri.Brix = dr["Brix"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Brix"]);
                    AyranYariMamulKaliteOzellikleri.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    AyranYariMamulKaliteOzellikleri.SH = dr["SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SH"]);
                    AyranYariMamulKaliteOzellikleri.Yag = dr["Yağ"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağ"]);
                    //AyranYariMamulKaliteOzellikleri.TatKokuKivam = dr["Tat Koku ve Kıvamı"] == DBNull.Value ? "" : dr["Tat Koku ve Kıvamı"].ToString();

                    ayranYariMamulKaliteOzellikleris.Add(AyranYariMamulKaliteOzellikleri);
                }

                nesne.ayranYariMamulKaliteOzellikleris = ayranYariMamulKaliteOzellikleris.ToArray();

                foreach (DataRow dr in dtgInkubasyonTakip_DataTable.Rows)
                {
                    AyranInkubasyonOzellikleri = new AyranInkubasyonOzellikleri();
                    AyranInkubasyonOzellikleri.KontrolNo = dr["Kontrol No"] == DBNull.Value ? "" : dr["Kontrol No"].ToString();
                    AyranInkubasyonOzellikleri.Saat = dr["Saat"] == DBNull.Value ? "" : dr["Saat"].ToString();
                    //AyranInkubasyonOzellikleri.Sicaklik = dr["Sıcaklık"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Sıcaklık"]);
                    AyranInkubasyonOzellikleri.UrunSicakligi = dr["Ürün Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Ürün Sıcaklığı"]);
                    AyranInkubasyonOzellikleri.OdaSicakligi = dr["Oda Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Oda Sıcaklığı"]);
                    AyranInkubasyonOzellikleri.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    AyranInkubasyonOzellikleri.KontrolEdenPersonel = dr["Kontrol Eden Personel"] == DBNull.Value ? "" : dr["Kontrol Eden Personel"].ToString();

                    if (AyranInkubasyonOzellikleri.KontrolEdenPersonel != "")
                    {
                        ayranInkubasyonOzellikleris.Add(AyranInkubasyonOzellikleri);
                    }

                }

                nesne.ayranInkubasyonOzellikleris = ayranInkubasyonOzellikleris.ToArray();

                var resp = client.AddOrUpdateAyranProsesTakipAnaliz(nesne, Giris.dbName, Giris.mKodValue);

                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                if (resp.Value == 0)
                {
                    btnOzet.PerformClick();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");

            }
        }
    }
}
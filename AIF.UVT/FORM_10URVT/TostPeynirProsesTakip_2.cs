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
    public partial class TostPeynirProsesTakip_2 : Form
    {
        //font start.tasrım
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end

        public TostPeynirProsesTakip_2(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, int _width, int _height, string _tarih1)
        {
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;
            //font end

            UretimFisNo = _UretimFisNo;
            partiNo = _PartiNo;
            UrunTanimi = _UrunTanimi;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;

            txtUretimSiparisNo.Text = UretimFisNo;
            txtUrunTanimi.Text = UrunTanimi;
            txtPartyNo.Text = partiNo;

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

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label3.Font.Style);

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label4.Font.Style);

            label5.Font = new Font(label5.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label5.Font.Style);

            label6.Font = new Font(label6.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label6.Font.Style);

            label7.Font = new Font(label7.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label7.Font.Style);

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimTarihi.Font.Style);

            txtPaketlemeTarihi.Font = new Font(txtPaketlemeTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtPaketlemeTarihi.Font.Style);

            txtUrunSislemesiYapan.Font = new Font(txtUrunSislemesiYapan.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUrunSislemesiYapan.Font.Style);

            txtUrunSislemesiKontrolEden.Font = new Font(txtUrunSislemesiKontrolEden.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUrunSislemesiKontrolEden.Font.Style);

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

            button3.Font = new Font(button3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button3.Font.Style);

            button6.Font = new Font(button6.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button6.Font.Style);

            button7.Font = new Font(button7.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              button7.Font.Style);

            btnOzetEkraniDon.Font = new Font(btnOzetEkraniDon.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnOzetEkraniDon.Font.Style);
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

        private void button5_Click(object sender, EventArgs e)
        {
        }

        private string UretimFisNo = "";
        private string partiNo = "";
        private string istasyon = "";
        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private int row = 0;
        private string tarih1 = "";
        private SqlCommand cmd = null;

        private void TostPeynirProsesTakip_2_Load(object sender, EventArgs e)
        {
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_TSTPRSS2_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
            //dtgSarfMalzemeKullanim();
            dtgDedektordenGecirme();
            //dtgGramajKontrol();


            //dataGridViewColumn = dtMamulOz.Columns["SH Değeri"];
            //dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            //dataGridViewColumn = dtMamulOz.Columns["Tuz Oranı(%)"];
            //dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            DataGridViewColumn dataGridViewColumn = dtMamulOz.Columns["Üretilen Ürünler"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtMamulOz.Columns["Paketleme Öncesi Ürün Miktarı (Adet)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtMamulOz.Columns["Paketlenen Ürün Miktarı (Adet)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtMamulOz.Columns["Fire Ürün Miktarı (Adet)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtMamulOz.Columns["Numune Ürün Miktarı (Adet)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtMamulOz.Columns["Depoya Giren Ürün Miktarı"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtMamulOz.Columns["Kuru Madde (%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;
            dataGridViewColumn = dtMamulOz.Columns["Yağ Oranı (%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;
            dataGridViewColumn = dtMamulOz.Columns["PH Değeri"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtMamulOz.Columns["Kuru Madde Yağ Oranı (%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtMamulOz.Columns["Üretilen Hamur"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dtMamulOz.Columns["Üretilen Ürünler"].ReadOnly = true;
            dtMamulOz.Columns["Paketleme Öncesi Ürün Miktarı (Adet)"].ReadOnly = true;
            dtMamulOz.Columns["Paketlenen Ürün Miktarı (Adet)"].ReadOnly = true;
            dtMamulOz.Columns["Fire Ürün Miktarı (Adet)"].ReadOnly = true;
            dtMamulOz.Columns["Numune Ürün Miktarı (Adet)"].ReadOnly = true;
            dtMamulOz.Columns["Depoya Giren Ürün Miktarı"].ReadOnly = true;
            dtMamulOz.Columns["Kuru Madde (%)"].ReadOnly = true;
            dtMamulOz.Columns["Yağ Oranı (%)"].ReadOnly = true;
            dtMamulOz.Columns["PH Değeri"].ReadOnly = true;
            dtMamulOz.Columns["Kuru Madde Yağ Oranı (%)"].ReadOnly = true;
            dtMamulOz.Columns["Üretilen Hamur"].ReadOnly = true;
        }

        private DataTable dtMamulOzellikleri = new DataTable();
        private DataTable dtGramaj = new DataTable();

        private void dtgMamulOzellikleri()
        {
            #region old
            //string sql = "SELECT ISNULL(T1.\"U_UretilenUrunler\",'') as \"Üretilen Ürünler\",ISNULL(T1.\"U_PaketlemeOncesiSicakik\",0) as \"Paketleme Öncesi Ürün Sıcaklığı\",ISNULL(T1.\"U_PaketOnceUretimMik\",0) as \"Paketleme Öncesi Ürün Miktarı (Adet)\", ISNULL(T1.\"U_UretimMiktari\",0) as \"Paketlenen Ürün Miktarı (Adet)\", ISNULL(T1.\"U_FireUrunMiktari\",0) as \"Fire Ürün Miktarı (Adet)\", ISNULL(T1.\"U_NumuneUrunMiktari\",0) as \"Numune Ürün Miktarı (Adet)\", ISNULL(T1.\"U_DepoyaGirenUrunMik\",0) as \"Depoya Giren Ürün Miktarı\", ISNULL(T1.\"U_KuruMadde\",0) as \"Kuru Madde(%)\", ISNULL(T1.\"U_YagOrani\",0) as \"Yağ Oranı (%)\", ISNULL(T1.\"U_PH\",0) as \"PH Değeri\", ISNULL(T1.\"U_SH\",0) as \"SH Değeri\",ISNULL(T1.\"U_TuzOrani\",0) as \"Tuz Oranı(%)\" FROM \"@AIF_TSTPRSS2_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TSTPRSS2_ANLZ1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "' ";

            //sql += "and ISNULL(cast(T1.\"U_UretilenUrunler\" as varchar(254)),'')<>''and ISNULL(T1.\"U_PaketlemeOncesiSicakik\",0)<>0 and ISNULL(\"U_PaketOnceUretimMik\",0)<>0 and ISNULL(T1.\"U_UretimMiktari\",0)<>0 and ISNULL(T1.\"U_FireUrunMiktari\",0)<>0 and ISNULL(T1.\"U_NumuneUrunMiktari\",0)<>0 and ISNULL(T1.\"U_DepoyaGirenUrunMik\",0)<>0 and ISNULL(T1.\"U_KuruMadde\",0)<>0 and ISNULL(T1.\"U_YagOrani\",0)<>0 and ISNULL(T1.\"U_PH\",0)<>0 and ISNULL(T1.\"U_SH\",0)<>0 and ISNULL(T1.\"U_TuzOrani\",0)<>0 "; 
            #endregion

            string sql = "SELECT ISNULL(T1.\"U_UretilenUrunler\",'') as \"Üretilen Ürünler\",ISNULL(T1.\"U_PaketlemeOncesiSicakik\",0) as \"Paketleme Öncesi Ürün Sıcaklığı\",ISNULL(T1.\"U_PaketOnceUretimMik\",0) as \"Paketleme Öncesi Ürün Miktarı (Adet)\", ISNULL(T1.\"U_UretimMiktari\",0) as \"Paketlenen Ürün Miktarı (Adet)\", ISNULL(T1.\"U_FireUrunMiktari\",0) as \"Fire Ürün Miktarı (Adet)\", ISNULL(T1.\"U_NumuneUrunMiktari\",0) as \"Numune Ürün Miktarı (Adet)\", ISNULL(T1.\"U_DepoyaGirenUrunMik\",0) as \"Depoya Giren Ürün Miktarı\", ISNULL(T1.\"U_KuruMadde\",0) as \"Kuru Madde (%)\", ISNULL(T1.\"U_YagOrani\",0) as \"Yağ Oranı (%)\", ISNULL(T1.\"U_PH\",0) as \"PH Değeri\", ISNULL(T1.\"U_KuruMadYagOrn\",0) as \"Kuru Madde Yağ Oranı (%)\", ISNULL(T1.\"U_UretilenHamur\",0) as \"Üretilen Hamur\"  FROM \"@AIF_TSTPRSS2_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TSTPRSS2_ANLZ1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Uretimtarihi\" = '" + tarih1 + "' ";

            //sql += "and ISNULL(cast(T1.\"U_UretilenUrunler\" as varchar(254)),'')<>''and ISNULL(T1.\"U_PaketlemeOncesiSicakik\",0)<>0 and ISNULL(\"U_PaketOnceUretimMik\",0)<>0 and ISNULL(T1.\"U_UretimMiktari\",0)<>0 and ISNULL(T1.\"U_FireUrunMiktari\",0)<>0 and ISNULL(T1.\"U_NumuneUrunMiktari\",0)<>0 and ISNULL(T1.\"U_DepoyaGirenUrunMik\",0)<>0 and ISNULL(T1.\"U_KuruMadde\",0)<>0 and ISNULL(T1.\"U_YagOrani\",0)<>0 and ISNULL(T1.\"U_PH\",0)<>0 and ISNULL(T1.\"U_KuruMadYagOrn\",0)<>0 and ISNULL(T1.\"U_UretilenHamur\",0)<>0 ";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);
            dtMamulOzellikleri = dt;

            #region satırda 0 ve null yanii boş kayıt geldiinden alttaki aha önce girilmiş analiz var mı sorgusuna girmiyordu satırlar bu durumda kaldırıldı
            //if (dtMamulOzellikleri.Rows.Count > 0)
            //{
            //    //double kullanilanmik = Convert.ToDouble(dtgBirinciKultur_DataTable.Rows[0][0]);
            //    //string tedarikci = dtgBirinciKultur_DataTable.Rows[0][0].ToString();
            //    //string lotno = dtgBirinciKultur_DataTable.Rows[0][0].ToString();

            //    //if (kullanilanmik != null && kullanilanmik == 0)
            //    //{
            //    //    dtgBirinciKultur_DataTable.
            //    //}
            //    int i = 1;
            //    foreach (DataRow dr in dtMamulOzellikleri.Rows)
            //    {
            //        if (
            //            (dr["Üretilen Ürünler"] == null || dr["Üretilen Ürünler"] == "") &&
            //            (Convert.ToDouble(dr["Paketleme Öncesi Ürün Sıcaklığı"]) == 0) && 
            //            (Convert.ToDouble(dr["Paketleme Öncesi Ürün Miktarı (Adet)"]) == 0) &&
            //            (Convert.ToDouble(dr["Paketlenen Ürün Miktarı (Adet)"]) == null || Convert.ToDouble(dr["Paketlenen Ürün Miktarı (Adet)"]) == 0) &&
            //            (Convert.ToDouble(dr["Fire Ürün Miktarı (Adet)"]) == null || Convert.ToDouble(dr["Fire Ürün Miktarı (Adet)"]) == 0) &&
            //            (Convert.ToDouble(dr["Numune Ürün Miktarı (Adet)"]) == null || Convert.ToDouble(dr["Numune Ürün Miktarı (Adet)"]) == 0) &&
            //            (Convert.ToDouble(dr["Depoya Giren Ürün Miktarı"]) == null || Convert.ToDouble(dr["Depoya Giren Ürün Miktarı"]) == 0) &&
            //            (Convert.ToDouble(dr["Kuru Madde(%)"]) == null || Convert.ToDouble(dr["Kuru Madde(%)"]) == 0) &&
            //            (Convert.ToDouble(dr["Yağ Oranı (%)"]) == null || Convert.ToDouble(dr["Yağ Oranı (%)"]) == 0) &&
            //            (Convert.ToDouble(dr["PH Değeri"]) == null || Convert.ToDouble(dr["PH Değeri"]) == 0) &&
            //            (Convert.ToDouble(dr["SH Değeri"]) == null || Convert.ToDouble(dr["SH Değeri"]) == 0) &&
            //            (Convert.ToDouble(dr["Tuz Oranı(%)"]) == null || Convert.ToDouble(dr["Tuz Oranı(%)"]) == 0) 
            //            )
            //        {
            //            dr.Delete();
            //        }

            //        i++;
            //    }

            //    dtMamulOzellikleri.AcceptChanges();
            //}
            #endregion satırda 0 ve null yanii boş kayıt geldiinden alttaki aha önce girilmiş analiz var mı sorgusuna girmiyordu satırlar bu durumda kaldırıldı

            if (dtMamulOzellikleri.Rows.Count == 0)
            {
                #region old
                //sql = "SELECT  T1.\"U_UretilenUrunAdi\" as \"Üretilen Ürünler\",cast(0 as decimal (15,2)) as \"Paketleme Öncesi Ürün Sıcaklığı\",  cast(0 as decimal (15,2))  as \"Paketleme Öncesi Ürün Miktarı (Adet)\",T1.\"U_UretilenUrunMik\" as \"Paketlenen Ürün Miktarı (Adet)\", cast(0 as decimal (15,2)) as \"Fire Ürün Miktarı (Adet)\",cast(0 as decimal (15,2)) as \"Numune Ürün Miktarı (Adet)\",cast(0 as decimal (15,2)) as \"Depoya Giren Ürün Miktarı\", T1.\"U_KuruMadde\" as \"Kuru Madde(%)\", T1.\"U_HamurYagOrani\" as \"Yağ Oranı (%)\",T1.\"U_HamurPH\" as \"PH Değeri\", cast(0 as decimal (15,2)) as \"SH Değeri\", cast(0 as decimal (15,2)) as \"Tuz Oranı(%)\" FROM OWOR O1 INNER JOIN OITM O2 ON O1.\"ItemCode\" = O2.\"ItemCode\" INNER JOIN \"@AIF_TSTPRSS_ANLZ\" AS T0 WITH (NOLOCK) ON T0.\"U_PartiNo\" = O1.\"U_GrupPartiNo\" INNER JOIN \"@AIF_TSTPRSS_ANLZ5\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" WHERE O1.\"U_ISTASYON\" = '" + type + "' AND O2.\"ItmsGrpCod\" = '105' AND O1.\"StartDate\" = '" + tarih1 + "' ORDER BY O1.\"ItemCode\" "; 
                #endregion

                //sql = "select tbl1.\"Üretilen Ürünler\",tbl1.\"Paketleme Öncesi Ürün Sıcaklığı\",sum(tbl1.\"Paketleme Öncesi Ürün Miktarı (Adet)\") as \"Paketleme Öncesi Ürün Miktarı (Adet)\",tbl1.\"Paketlenen Ürün Miktarı (Adet)\",tbl1.\"Fire Ürün Miktarı (Adet)\",tbl1.\"Numune Ürün Miktarı (Adet)\",tbl1.\"Depoya Giren Ürün Miktarı\",sum(cast(tbl1.\"Kuru Madde (%)\" as decimal(16, 2))) as \"Kuru Madde (%)\",sum(cast(tbl1.\"Yağ Oranı (%)\" as decimal(16, 2))) as \"Yağ Oranı (%)\",sum(cast(tbl1.\"PH Değeri\" as decimal(16, 2))) as \"PH Değeri\",sum(cast(tbl1.\"Kuru Madde Yağ Oranı (%)\" as decimal(16, 2))) as \"Kuru Madde Yağ Oranı (%)\",sum(cast(tbl1.\"Üretilen Hamur\" as decimal(16, 2))) as \"Üretilen Hamur\" from (SELECT T1.\"U_UretilenUrunAdi\" AS \"Üretilen Ürünler\",cast(0 AS decimal(15, 2)) AS \"Paketleme Öncesi Ürün Sıcaklığı\",T1.\"U_UretilenUrunMik\" AS \"Paketleme Öncesi Ürün Miktarı (Adet)\",cast(0 AS decimal(15, 2)) AS \"Paketlenen Ürün Miktarı (Adet)\",cast(0 AS decimal(15, 2)) AS \"Fire Ürün Miktarı (Adet)\",cast(0 AS decimal(15, 2)) AS \"Numune Ürün Miktarı (Adet)\",cast(0 AS decimal(15, 2)) AS \"Depoya Giren Ürün Miktarı\",t1.\"U_KuruMadYagOrn\",(T1.\"U_UretilenUrunMik\" * T1.\"U_KuruMadde\") / (select sum(\"U_UretilenUrunMik\") from \"@AIF_TSTPRSS_ANLZ5\" where T1.\"U_UretilenUrunAdi\" =\"U_UretilenUrunAdi\" ) as \"Kuru Madde (%)\",(T1.\"U_UretilenUrunMik\" * T1.\"U_HamurYagOrani\" ) / (select sum(\"U_UretilenUrunMik\") from \"@AIF_TSTPRSS_ANLZ5\" where T1.\"U_UretilenUrunAdi\" =\"U_UretilenUrunAdi\" ) as \"Yağ Oranı (%)\",(T1.\"U_UretilenUrunMik\" * T1.\"U_HamurPH\" ) / (select sum(\"U_UretilenUrunMik\") from \"@AIF_TSTPRSS_ANLZ5\" where T1.\"U_UretilenUrunAdi\" =\"U_UretilenUrunAdi\" ) as \"PH Değeri\",(T1.\"U_UretilenUrunMik\" * T1.\"U_KuruMadYagOrn\" ) / (select sum(\"U_UretilenUrunMik\") from \"@AIF_TSTPRSS_ANLZ5\" where T1.\"U_UretilenUrunAdi\" = \"U_UretilenUrunAdi\" ) as \"Kuru Madde Yağ Oranı (%)\",(T1.\"U_UretilenUrunMik\" *   T1.\"U_UretilenHamur\" ) /(select sum(\"U_UretilenUrunMik\") from \"@AIF_TSTPRSS_ANLZ5\" where T1.\"U_UretilenUrunAdi\"=\"U_UretilenUrunAdi\" ) as \"Üretilen Hamur\" FROM OWOR O1 INNER JOIN OITM O2 ON O1.\"ItemCode\" = O2.\"ItemCode\" INNER JOIN \"@AIF_TSTPRSS_ANLZ\" AS T0 WITH(NOLOCK) ON T0.\"U_PartiNo\" = O1.\"U_GrupPartiNo\" INNER JOIN \"@AIF_TSTPRSS_ANLZ5\" AS T1 WITH(NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" WHERE O1.\"U_ISTASYON\" = '" + istasyon + "' AND O2.\"ItmsGrpCod\" = '105' AND O1.\"StartDate\" = '" + tarih1 + "') as tbl1 group by tbl1.\"Üretilen Ürünler\",tbl1.\"Paketleme Öncesi Ürün Sıcaklığı\",tbl1.\"Paketlenen Ürün Miktarı (Adet)\",tbl1.\"Fire Ürün Miktarı (Adet)\",tbl1.\"Numune Ürün Miktarı (Adet)\",tbl1.\"Depoya Giren Ürün Miktarı\" ";

                sql = "select tbl1.\"Üretilen Ürünler\",tbl1.\"Paketleme Öncesi Ürün Sıcaklığı\",sum(tbl1.\"Paketleme Öncesi Ürün Miktarı (Adet)\") as \"Paketleme Öncesi Ürün Miktarı (Adet)\",tbl1.\"Paketlenen Ürün Miktarı (Adet)\",tbl1.\"Fire Ürün Miktarı (Adet)\",tbl1.\"Numune Ürün Miktarı (Adet)\",tbl1.\"Depoya Giren Ürün Miktarı\",sum(cast(tbl1.\"Kuru Madde (%)\" as decimal(16, 2))) / cnt as \"Kuru Madde (%)\", sum(cast(tbl1.\"Yağ Oranı (%)\" as decimal(16, 2))) / CNT as \"Yağ Oranı (%)\", sum(cast(tbl1.\"PH Değeri\" as decimal(16, 2))) / CNT as \"PH Değeri\", sum(cast(tbl1.\"Kuru Madde Yağ Oranı (%)\" as decimal(16, 2))) / CNT as \"Kuru Madde Yağ Oranı (%)\", sum(cast(tbl1.\"Üretilen Hamur\" as decimal(16, 2))) / CNT as \"Üretilen Hamur\" from (SELECT(select count(*) from \"@AIF_TSTPRSS_ANLZ\" AS z0 INNER JOIN \"@AIF_TSTPRSS_ANLZ5\" AS Z1 WITH(NOLOCK) ON Z0.\"DocEntry\" = Z1.\"DocEntry\" where Z1.\"U_UretilenUrunAdi\" = T1.\"U_UretilenUrunAdi\" AND Z0.U_UretimTarihi =T0.U_UretimTarihi) as cnt, T1.\"U_UretilenUrunAdi\" AS \"Üretilen Ürünler\", cast(0 AS decimal(15, 2)) AS \"Paketleme Öncesi Ürün Sıcaklığı\", T1.\"U_UretilenUrunMik\" AS \"Paketleme Öncesi Ürün Miktarı (Adet)\", cast(0 AS decimal(15, 2)) AS \"Paketlenen Ürün Miktarı (Adet)\", cast(0 AS decimal(15, 2)) AS \"Fire Ürün Miktarı (Adet)\", cast(0 AS decimal(15, 2)) AS \"Numune Ürün Miktarı (Adet)\", cast(0 AS decimal(15, 2)) AS \"Depoya Giren Ürün Miktarı\", t1.U_KuruMadYagOrn, (T1.\"U_KuruMadde\") as \"Kuru Madde (%)\",(T1.\"U_HamurYagOrani\" )  as \"Yağ Oranı (%)\", (T1.\"U_HamurPH\" )  as \"PH Değeri\",(T1.\"U_KuruMadYagOrn\") as \"Kuru Madde Yağ Oranı (%)\",(T1.U_UretilenHamur) as \"Üretilen Hamur\" FROM OWOR O1 INNER JOIN OITM O2 ON O1.\"ItemCode\" = O2.\"ItemCode\" INNER JOIN \"@AIF_TSTPRSS_ANLZ\" AS T0 WITH(NOLOCK) ON T0.\"U_PartiNo\" = O1.\"U_GrupPartiNo\" INNER JOIN \"@AIF_TSTPRSS_ANLZ5\" AS T1 WITH(NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\"  WHERE O1.\"U_ISTASYON\" = '" + istasyon + "' AND O2.\"ItmsGrpCod\" = '105' AND O1.\"StartDate\" = '" + tarih1 + "') as tbl1 group by cnt,tbl1.\"Üretilen Ürünler\",tbl1.\"Paketleme Öncesi Ürün Sıcaklığı\",tbl1.\"Paketlenen Ürün Miktarı (Adet)\",tbl1.\"Fire Ürün Miktarı (Adet)\",tbl1.\"Numune Ürün Miktarı (Adet)\",tbl1.\"Depoya Giren Ürün Miktarı\" ";

                cmd = new SqlCommand(sql, Connection.sql);

                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dttemp = new DataTable();
                sda.Fill(dt);
                dtMamulOzellikleri = dt;
            }

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");
                DataRow dr = dtMamulOzellikleri.NewRow();
                dr["Üretilen Ürünler"] = "";
                dr["Paketleme Öncesi Ürün Sıcaklığı"] = 0;
                dr["Paketlenen Ürün Miktarı (Adet)"] = 0;
                dr["Paketleme Öncesi Ürün Miktarı (Adet)"] = 0;
                dr["Fire Ürün Miktarı (Adet)"] = 0;
                dr["Numune Ürün Miktarı (Adet)"] = 0;
                dr["Depoya Giren Ürün Miktarı"] = 0;
                dr["Kuru Madde (%)"] = 0;
                dr["Yağ Oranı (%)"] = 0;
                dr["PH Değeri"] = 0;
                dr["Kuru Madde Yağ Oranı (%)"] = 0;
                dr["Üretilen Hamur"] = 0;
                //dr["SH Değeri"] = 0;
                //dr["Tuz Oranı(%)"] = 0;

                dtMamulOzellikleri.Rows.Add(dr);
            }
            Connection.sql.Close();
            //Commit
            dtMamulOz.DataSource = dt;

            dtMamulOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtMamulOz.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtMamulOz.EnableHeadersVisualStyles = false;
            dtMamulOz.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

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

            //dtMamulOz.Columns["SH Değeri"].Visible = false;
            //dtMamulOz.Columns["Tuz Oranı(%)"].Visible = false;
            dtMamulOz.Columns["Paketleme Öncesi Ürün Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtMamulOz.Columns["Paketleme Öncesi Ürün Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtMamulOz.Columns["Paketlenen Ürün Miktarı (Adet)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtMamulOz.Columns["Paketlenen Ürün Miktarı (Adet)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtMamulOz.Columns["Paketleme Öncesi Ürün Miktarı (Adet)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtMamulOz.Columns["Paketleme Öncesi Ürün Miktarı (Adet)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtMamulOz.Columns["Numune Ürün Miktarı (Adet)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtMamulOz.Columns["Numune Ürün Miktarı (Adet)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtMamulOz.Columns["Fire Ürün Miktarı (Adet)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtMamulOz.Columns["Fire Ürün Miktarı (Adet)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtMamulOz.Columns["Depoya Giren Ürün Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtMamulOz.Columns["Depoya Giren Ürün Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtMamulOz.Columns["Kuru Madde (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtMamulOz.Columns["Kuru Madde (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtMamulOz.Columns["Yağ Oranı (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtMamulOz.Columns["Yağ Oranı (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtMamulOz.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtMamulOz.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            //dtMamulOz.Columns["SH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtMamulOz.Columns["SH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            //dtMamulOz.Columns["Tuz Oranı(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtMamulOz.Columns["Tuz Oranı(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtMamulOz.Columns["Kuru Madde Yağ Oranı (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtMamulOz.Columns["Kuru Madde Yağ Oranı (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtMamulOz.Columns["Üretilen Hamur"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtMamulOz.Columns["Üretilen Hamur"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;


            dtMamulOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtMamulOz.AutoResizeRows();
            //dtMamulOz.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtMamulOz.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dtgDinlenmeVePaketleme()
        {
            DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));

            string sql = "SELECT T1.\"U_AlanAdi\" as \"Alan Adı\",T1.\"U_SifirSekizSicaklik\" as \"08:00 Sıcaklık\", T1.\"U_SifirSekizNem\" as \"08:00 Nem\", T1.\"U_OnikiSicaklik\" as \"12:00 Sıcaklık\", T1.\"U_OnikiNem\" as \"12:00 Nem\", T1.\"U_OnBesSicaklik\" as \"15:00 Sıcaklık\", T1.\"U_OnBesNem\" as \"15:00 Nem\",T1.\"U_OnSekizSicaklik\" as \"18:00 Sıcaklık\", T1.\"U_OnSekizNem\" as \"18:00 Nem\" FROM \"@AIF_TSTDNPKT\" AS T1 WITH (NOLOCK) where T1.\"U_UretimTarihi\" = '" + tarih1 + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgKurutmaVePaket.DataSource = dt;

            dtgKurutmaVePaket.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgKurutmaVePaket.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgKurutmaVePaket.EnableHeadersVisualStyles = false;
            dtgKurutmaVePaket.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            if (dt.Rows.Count == 0)
            {
                //System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Alan Adı"] = "Kurutma Odası-1";

                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Alan Adı"] = "Kurutma Odası-2";

                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Alan Adı"] = "Paketleme Odası";

                dt.Rows.Add(dr);

                dr = dt.NewRow();
                dr["Alan Adı"] = "Üretim Alanı";

                dt.Rows.Add(dr);
            }

            dtgKurutmaVePaket.Columns["08:00 Sıcaklık"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgKurutmaVePaket.Columns["08:00 Sıcaklık"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgKurutmaVePaket.Columns["08:00 Nem"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgKurutmaVePaket.Columns["08:00 Nem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgKurutmaVePaket.Columns["12:00 Sıcaklık"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgKurutmaVePaket.Columns["12:00 Sıcaklık"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgKurutmaVePaket.Columns["12:00 Nem"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgKurutmaVePaket.Columns["12:00 Nem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgKurutmaVePaket.Columns["15:00 Sıcaklık"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgKurutmaVePaket.Columns["15:00 Sıcaklık"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgKurutmaVePaket.Columns["15:00 Nem"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgKurutmaVePaket.Columns["15:00 Nem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgKurutmaVePaket.Columns["18:00 Sıcaklık"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgKurutmaVePaket.Columns["18:00 Sıcaklık"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            dtgKurutmaVePaket.Columns["18:00 Nem"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgKurutmaVePaket.Columns["18:00 Nem"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgKurutmaVePaket.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgKurutmaVePaket.AutoResizeRows();
            //dtgDinlendirmeVePaket.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgKurutmaVePaket.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dtgDedektordenGecirme()
        {
            string sql = "SELECT T1.\"U_DedektorGecirilmeKontrol\" as \"Dedektörden Geçirilme Kontrolü\" FROM \"@AIF_TSTPRSS2_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TSTPRSS2_ANLZ3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add();
            }

            //Commit
            dtgDedektordenKontrol.DataSource = dt;

            dtgDedektordenKontrol.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgDedektordenKontrol.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgDedektordenKontrol.EnableHeadersVisualStyles = false;
            dtgDedektordenKontrol.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                //DataRow dr = dt.NewRow();
                //dr["Parti No"] = partiNo;
                //dr["Hamur Türü"] = txtUrunTanimi.Text;
                //dr["Karışım Past. Sıcakligi"] = Convert.ToString("0", cultureTR);
                //dr["Hammadde Yükleme Baş. Saat"] = Convert.ToString("0", cultureTR);
                //dr["Hammadde Yükleme Bit. Saat"] = Convert.ToString("0", cultureTR);
                //dr["Pişirme Mak. Indirilme Saati"] = Convert.ToString("0", cultureTR);
                //dr["Hamurun Gramajlama Bitiş Saati"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add();
            }

            //dtgProsesOzellikleri1.Columns["Karışım Past. Sıcakligi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgProsesOzellikleri1.Columns["Karışım Past. Sıcakligi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            ////dtgProsesOzellikleri1.Columns["Hammadde Yükleme Bit. Saat"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            ////dtgProsesOzellikleri1.Columns["Hammadde Yükleme Bit. Saat"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            ////dtgProsesOzellikleri1.Columns["Karışım Past. Sıcakligi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            ////dtgProsesOzellikleri1.Columns["Karışım Past. Sıcakligi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            ////dtgProsesOzellikleri1.Columns["Pişirme Mak. Indirilme Saati"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            ////dtgProsesOzellikleri1.Columns["Pişirme Mak. Indirilme Saati"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            ////dtgProsesOzellikleri1.Columns["Hamurun Gramajlama Bitiş Saati"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            ////dtgProsesOzellikleri1.Columns["Hamurun Gramajlama Bitiş Saati"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            //dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgProsesOzellikleri1.AutoResizeRows();
            ////dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgDedektordenKontrol.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();
        }

        private void dtMamulOz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtMamulOz.Columns[e.ColumnIndex].Name == "Paketleme Öncesi Ürün Sıcaklığı")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtMamulOz);
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
                //else if (dtMamulOz.Columns[e.ColumnIndex].Name == "Üretilen Ürünler")
                //{
                //    #region veri getirildiği için tekrar getirmeye kapatıldı
                //    //string sql_AnalizParam = "Select \"U_Deger1\",\"U_Deger2\" from \"@AIF_GNLKANLZPRM\" where \"U_Kod\" ='3'";
                //    //cmd = new SqlCommand(sql_AnalizParam, Connection.sql);

                //    //if (Connection.sql.State != ConnectionState.Open)
                //    //    Connection.sql.Open();

                //    //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //    //DataTable dt_Sorgu = new DataTable();
                //    //sda.Fill(dt_Sorgu);

                //    ////dtgSecim.DataSource = dt;
                //    ////dtSecim = dt;

                //    //Connection.sql.Close();

                //    //if (dt_Sorgu.Rows.Count > 0)
                //    //{
                //    //    string sql1 = "Select TOP 1 '' as \"Kalem Kodu\",'' as \"Kalem Adı\" FROM OITM where \"U_ItemGroup2\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][1].ToString() + "' ";
                //    //    sql1 += " UNION ALL ";
                //    //    sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"U_ItemGroup2\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][1].ToString() + "'";

                //    //    SelectList selectList = new SelectList(sql1, dtMamulOz, -1, 0, _autoresizerow: false);
                //    //    selectList.ShowDialog();

                //    //    var sonSatir = dtMamulOz.Rows[dtMamulOz.RowCount - 1].Cells[e.ColumnIndex].Value.ToString();

                //    //    if (sonSatir != "")
                //    //    {
                //    //        System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                //    //        DataRow dr = dtMamulOzellikleri.NewRow();
                //    //        dr["Üretilen Ürünler"] = "";
                //    //        dr["Paketleme Öncesi Ürün Sıcaklığı"] = 0;
                //    //        dr["Paketlenen Ürün Miktarı (Adet)"] = 0;
                //    //        dr["Fire Ürün Miktarı (Adet)"] = 0;
                //    //        dr["Numune Ürün Miktarı (Adet)"] = 0;
                //    //        dr["Depoya Giren Ürün Miktarı"] = 0;
                //    //        dr["Kuru Madde(%)"] = 0;
                //    //        dr["Yağ Oranı (%)"] = 0;
                //    //        dr["PH Değeri"] = 0;
                //    //        dr["SH Değeri"] = 0;
                //    //        dr["Tuz Oranı(%)"] = 0;

                //    //        dtMamulOzellikleri.Rows.Add(dr);
                //    //    }
                //    //}
                //    //else
                //    //{
                //    //    CustomMsgBtn.Show("Üretilen Ürünler için parametre tablosu doldurulmamıştır.", "UYARI", "TAMAM");
                //    //} 
                //    #endregion
                //}
            }
            catch (Exception)
            {
            }
        }

        private void dtgKurutmaVePaket_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgKurutmaVePaket.Columns[e.ColumnIndex].Name == "08:00 Sıcaklık" || dtgKurutmaVePaket.Columns[e.ColumnIndex].Name == "08:00 Nem" || dtgKurutmaVePaket.Columns[e.ColumnIndex].Name == "12:00 Sıcaklık" || dtgKurutmaVePaket.Columns[e.ColumnIndex].Name == "12:00 Nem" || dtgKurutmaVePaket.Columns[e.ColumnIndex].Name == "15:00 Sıcaklık" || dtgKurutmaVePaket.Columns[e.ColumnIndex].Name == "15:00 Nem" || dtgKurutmaVePaket.Columns[e.ColumnIndex].Name == "18:00 Sıcaklık" || dtgKurutmaVePaket.Columns[e.ColumnIndex].Name == "18:00 Nem")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgKurutmaVePaket);
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
            catch (Exception)
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                TostPeynirTakipAnaliz2 nesne = new TostPeynirTakipAnaliz2();

                TostPeynirMamulOzellikleri1 tostPeynirMamulOzellikleri1 = new TostPeynirMamulOzellikleri1();
                List<TostPeynirMamulOzellikleri1> tostPeynirMamulOzellikleri1s = new List<TostPeynirMamulOzellikleri1>();

                //TostPeynir2SarfMalzemeKullanim tostPeynir2SarfMalzemeKullanim = new TostPeynir2SarfMalzemeKullanim();
                //List<TostPeynir2SarfMalzemeKullanim> tostPeynir2SarfMalzemeKullanims = new List<TostPeynir2SarfMalzemeKullanim>();

                TostPeynir2DedektorGecirilmeKontrol tostPeynir2DedektorGecirilmeKontrol = new TostPeynir2DedektorGecirilmeKontrol();
                List<TostPeynir2DedektorGecirilmeKontrol> tostPeynir2DedektorGecirilmeKontrols = new List<TostPeynir2DedektorGecirilmeKontrol>();

                //TostPeynir2GramajKontrol tostPeynir2GramajKontrol = new TostPeynir2GramajKontrol();
                //List<TostPeynir2GramajKontrol> tostPeynir2GramajKontrols = new List<TostPeynir2GramajKontrol>();

                TostPeynir2KurutmaVePaketleme tostPeynir2KurutmaVePaketleme = new TostPeynir2KurutmaVePaketleme();
                List<TostPeynir2KurutmaVePaketleme> tostPeynir2KurutmaVePaketlemes = new List<TostPeynir2KurutmaVePaketleme>();

                nesne.PartiNo = txtPartyNo.Text;
                nesne.Aciklama = txtAciklama.Text;
                nesne.KalemKodu = "";
                nesne.KalemTanimi = txtUrunTanimi.Text;

                nesne.UretimTarihi = txtUretimTarihi.Text.Substring(6, 4) + txtUretimTarihi.Text.Substring(3, 2) + txtUretimTarihi.Text.Substring(0, 2);
                nesne.PaketlemeTarihi = txtPaketlemeTarihi.Text.Substring(6, 4) + txtPaketlemeTarihi.Text.Substring(3, 2) + txtPaketlemeTarihi.Text.Substring(0, 2);
                nesne.UrunSislemesiKontroEdenPersonel = txtUrunSislemesiKontrolEden.Text;
                nesne.UrunSislemesiYapanPersonel = txtUrunSislemesiYapan.Text;
                nesne.EkranTipi = "G";

                foreach (DataGridViewRow dr in dtMamulOz.Rows)
                {
                    tostPeynirMamulOzellikleri1 = new TostPeynirMamulOzellikleri1();

                    tostPeynirMamulOzellikleri1.UretilenUrun = dr.Cells["Üretilen Ürünler"].Value == DBNull.Value ? "" : dr.Cells["Üretilen Ürünler"].Value.ToString();
                    tostPeynirMamulOzellikleri1.PaketlemeOncesiSicaklik = dr.Cells["Paketleme Öncesi Ürün Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Paketleme Öncesi Ürün Sıcaklığı"].Value);
                    tostPeynirMamulOzellikleri1.PaketlenenUrunMiktari = dr.Cells["Paketlenen Ürün Miktarı (Adet)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Paketlenen Ürün Miktarı (Adet)"].Value);
                    tostPeynirMamulOzellikleri1.FireUrunMiktari = dr.Cells["Fire Ürün Miktarı (Adet)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Fire Ürün Miktarı (Adet)"].Value);
                    tostPeynirMamulOzellikleri1.NumuneUrunMiktari = dr.Cells["Numune Ürün Miktarı (Adet)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Numune Ürün Miktarı (Adet)"].Value);
                    tostPeynirMamulOzellikleri1.DepoyaGirenUrunMiktari = dr.Cells["Depoya Giren Ürün Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Depoya Giren Ürün Miktarı"].Value);
                    tostPeynirMamulOzellikleri1.KuruMadde = dr.Cells["Kuru Madde (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde (%)"].Value);
                    tostPeynirMamulOzellikleri1.YagOrani = dr.Cells["Yağ Oranı (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ Oranı (%)"].Value);
                    tostPeynirMamulOzellikleri1.PH = dr.Cells["PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH Değeri"].Value);
                    //tostPeynirMamulOzellikleri1.SH = dr.Cells["SH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH Değeri"].Value);
                    //tostPeynirMamulOzellikleri1.TuzOrani = dr.Cells["Tuz Oranı(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tuz Oranı(%)"].Value);
                    tostPeynirMamulOzellikleri1.KuruMaddeYagOrani = dr.Cells["Kuru Madde Yağ Oranı (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde Yağ Oranı (%)"].Value);
                    tostPeynirMamulOzellikleri1.UretilenHamur = dr.Cells["Üretilen Hamur"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretilen Hamur"].Value);

                    tostPeynirMamulOzellikleri1s.Add(tostPeynirMamulOzellikleri1);
                }

                nesne.tostPeynirMamulOzellikleri1s_Detay = tostPeynirMamulOzellikleri1s.ToArray();

                //foreach (DataGridViewRow dr in dtgSarfMalzeme.Rows)
                //{
                //    tostPeynir2SarfMalzemeKullanim = new TostPeynir2SarfMalzemeKullanim();

                //    tostPeynir2SarfMalzemeKullanim.MalzemeAdi = dr.Cells["Malzeme Adı"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Adı"].Value.ToString();
                //    tostPeynir2SarfMalzemeKullanim.MalzemeMarkaTedarikcisi = dr.Cells["Malzeme Marka ve Tedarikçi"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Marka ve Tedarikçi"].Value.ToString();
                //    tostPeynir2SarfMalzemeKullanim.SarfMalzemePartiNo = dr.Cells["Sarf Malzemesi Parti No"].Value == DBNull.Value ? "" : dr.Cells["Sarf Malzemesi Parti No"].Value.ToString();
                //    tostPeynir2SarfMalzemeKullanim.Miktar = dr.Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Miktar"].Value);
                //    tostPeynir2SarfMalzemeKullanim.Birim = dr.Cells["Birim"].Value == DBNull.Value ? "" : dr.Cells["Birim"].Value.ToString();

                //    tostPeynir2SarfMalzemeKullanims.Add(tostPeynir2SarfMalzemeKullanim);
                //}

                //nesne.tostPeynir2SarfMalzemeKullanims = tostPeynir2SarfMalzemeKullanims.ToArray();

                foreach (DataGridViewRow dr in dtgDedektordenKontrol.Rows)
                {
                    tostPeynir2DedektorGecirilmeKontrol = new TostPeynir2DedektorGecirilmeKontrol();
                    tostPeynir2DedektorGecirilmeKontrol.UretilenMetalDedektördenGecirilmeKontrolu = dr.Cells["Dedektörden Geçirilme Kontrolü"].Value == DBNull.Value ? "" : dr.Cells["Dedektörden Geçirilme Kontrolü"].Value.ToString();

                    tostPeynir2DedektorGecirilmeKontrols.Add(tostPeynir2DedektorGecirilmeKontrol);
                }

                nesne.tostPeynir2DedektorGecirilmeKontrols = tostPeynir2DedektorGecirilmeKontrols.ToArray();

                //foreach (DataGridViewRow dr in dtgGramaj.Rows)
                //{
                //    tostPeynir2GramajKontrol = new TostPeynir2GramajKontrol();

                //    tostPeynir2GramajKontrol.UrunCesidi = dr.Cells["Ürün Çeşidi"].Value == DBNull.Value ? "" : dr.Cells["Ürün Çeşidi"].Value.ToString();
                //    tostPeynir2GramajKontrol.PartiNo = dr.Cells["Parti No"].Value == DBNull.Value ? "" : dr.Cells["Parti No"].Value.ToString();
                //    tostPeynir2GramajKontrol.BirinciOrnek = dr.Cells["1.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["1.Örnek"].Value);
                //    tostPeynir2GramajKontrol.IkinciOrnek = dr.Cells["2.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["2.Örnek"].Value);
                //    tostPeynir2GramajKontrol.UcuncuOrnek = dr.Cells["3.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["3.Örnek"].Value);
                //    tostPeynir2GramajKontrol.DorduncuOrnek = dr.Cells["4.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["4.Örnek"].Value);
                //    tostPeynir2GramajKontrol.BesinciOrnek = dr.Cells["5.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["5.Örnek"].Value);
                //    tostPeynir2GramajKontrol.AltinciOrnek = dr.Cells["6.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["6.Örnek"].Value);
                //    tostPeynir2GramajKontrol.YedinciOrnek = dr.Cells["7.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["7.Örnek"].Value);

                //    tostPeynir2GramajKontrols.Add(tostPeynir2GramajKontrol);
                //}

                //nesne.tostPeynir2GramajKontrols = tostPeynir2GramajKontrols.ToArray();

                var resp = client.AddOrUpdateTostPeynirProsesAnalizTakip2(nesne, Giris.dbName, Giris.mKodValue);

                string mesaj = resp.Description;

                nesne = new TostPeynirTakipAnaliz2();

                foreach (DataGridViewRow dr in dtgKurutmaVePaket.Rows)
                {
                    tostPeynir2KurutmaVePaketleme = new TostPeynir2KurutmaVePaketleme();

                    tostPeynir2KurutmaVePaketleme.UretimTarihi = tarih1;
                    tostPeynir2KurutmaVePaketleme.AlanAdi = dr.Cells["Alan Adı"].Value == DBNull.Value ? "" : dr.Cells["Alan Adı"].Value.ToString();
                    tostPeynir2KurutmaVePaketleme.SifirSekizSicaklik = dr.Cells["08:00 Sıcaklık"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["08:00 Sıcaklık"].Value);
                    tostPeynir2KurutmaVePaketleme.SifirSekizNem = dr.Cells["08:00 Nem"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["08:00 Nem"].Value);
                    tostPeynir2KurutmaVePaketleme.OnikiSicaklik = dr.Cells["12:00 Sıcaklık"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["12:00 Sıcaklık"].Value);
                    tostPeynir2KurutmaVePaketleme.OnikiNem = dr.Cells["12:00 Nem"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["12:00 Nem"].Value);
                    tostPeynir2KurutmaVePaketleme.OnBesSicaklik = dr.Cells["15:00 Sıcaklık"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["15:00 Sıcaklık"].Value);
                    tostPeynir2KurutmaVePaketleme.OnBesNem = dr.Cells["15:00 Nem"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["15:00 Nem"].Value);
                    tostPeynir2KurutmaVePaketleme.OnSekizSicaklik = dr.Cells["18:00 Sıcaklık"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["18:00 Sıcaklık"].Value);
                    tostPeynir2KurutmaVePaketleme.OnSekizNem = dr.Cells["18:00 Nem"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["18:00 Nem"].Value);

                    tostPeynir2KurutmaVePaketlemes.Add(tostPeynir2KurutmaVePaketleme);
                }

                resp = client.AddOrUpdateTostPeynirKurutmaVePaketlemeOdasi(tostPeynir2KurutmaVePaketlemes.ToArray(), Giris.dbName, Giris.mKodValue);

                mesaj += Environment.NewLine;
                mesaj += "Kurutma ve Paketleme Odası Sıcaklık ve Nem Takip" + resp.Description;

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

        private void btnOzetEkraniDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }
    }
}
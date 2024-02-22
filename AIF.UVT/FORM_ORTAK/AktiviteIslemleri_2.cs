using AIF.UVT.DatabaseLayer;
using AIF.UVT.UVTService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class AktiviteIslemleri_2 : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end.

        public AktiviteIslemleri_2(string _type, string _kullaniciid, string _rota, string _stageid, string _uretimFisNo, string _btnType, string _partiNo, string _urunKodu, string _uretimdengirisYap, int _row, double _planlananMiktar, int _width, int _height, string _tarih, string _varsayilanDepo, DateTime _siparisTarihi, TextBox _txtParam = null)
        {
            type = _type;
            kullaniciid = _kullaniciid;
            rota = _rota;
            stageid = _stageid;
            uretimfisNo = _uretimFisNo;
            btnType = _btnType;
            partiNo = _partiNo;
            urunKodu = _urunKodu;
            tarih1 = _tarih;
            varsayilanDepo = _varsayilanDepo;
            siparisTarihi = _siparisTarihi;
            //width = _width;
            //height = _height;
            row = _row;
            uretimdengirisYap = _uretimdengirisYap;
            planlananMiktar = _planlananMiktar;
            txtParam = _txtParam;
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = _width;
            initialHeight = _height;

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

            initialFontSize = dataGridView1.Font.Size;
            dataGridView1.Resize += Form_Resize;
            //font end
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            btnDuraklamaSebebi.Font = new Font(btnDuraklamaSebebi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnDuraklamaSebebi.Font.Style);


            rchDuraklama.Font = new Font(rchDuraklama.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                rchDuraklama.Font.Style);

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

            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dataGridView1.Font.Style);
            ResumeLayout();
            //font end 

            //txtDuraklama1.Font = new Font("Microsoft Sans Serif", 22, FontStyle.Bold);
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

        private string type;
        private string kullaniciid;
        private string rota;
        private string stageid;
        private string uretimfisNo;
        private string partiNo;
        private string uretimdengirisYap;
        private string urunKodu;
        private string tarih1;
        private string varsayilanDepo;
        private int width = 0;
        private int height = 0;
        private int row = 0;
        private double planlananMiktar = 0;
        private DataTable dt = new DataTable();
        private DataTable dt2 = new DataTable();
        private DataTable dt99 = new DataTable();
        private DataTable dt88 = new DataTable();
        private DataTable dtAktiviteCalisanlari = new DataTable();
        private DataTable dtDevamEdenAktiviteCalisanlari = new DataTable();
        private string personelid = "";
        private string queryaktivite = "";
        private string sql = "";
        private SqlCommand cmd = null;
        private SqlDataAdapter sda = null;
        private DataGridViewCheckBoxColumn checkColumn = null;
        private DataGridViewCheckBoxColumn checkColumn2 = null;
        private TextBox txtParam = null;
        private DateTime siparisTarihi;
        private void BekleyenleriGetir()
        {
            dt = new DataTable();
            dt99 = new DataTable();
            string field = "U_" + type;

            DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
            string gunfield = "U_Gun" + dtTarih.Day;

            #region Günlük Personel Planlama 2 ekranı

            //sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\",'  ' as Saat,'  ' as Dakika,'    ' as AktiviteNo," + gunfield + " as \"Değer\", case when " + gunfield + " = 'X' then 'Çalışıyor' when " + gunfield + " = 'R' then 'Raporlu' when " + gunfield + " = 'HT' then 'Hafta Tatili' when " + gunfield + " = 'UC' then 'Ücretsiz İzin' when " + gunfield + " = 'RT' then 'Resmi Tatil' when " + gunfield + " = 'YI' then 'Yıllık İzin' end as \"Durum\"  from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2,*/ '0') +"' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "') ";

            #endregion Günlük Personel Planlama 2 ekranı

            #region Günlük Personel Planlama 1 ekranı

            //sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\",'  ' as Saat,'  ' as Dakika,'    ' as AktiviteNo from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and T1.\"" + field + "\" = 'Y'";

            #endregion Günlük Personel Planlama 1 ekranı

            #region Günlük Personel Planlama 3 ekranı

            sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\",'  ' AS \"Saat\",'  ' AS \"Dakika\",'    ' AS \"AktiviteNo\",\"U_Durum\" as \"Değer\", ";
            sql += "CASE ";
            sql += "WHEN U_Durum = 'X' THEN 'Çalışıyor' ";
            sql += "WHEN U_Durum = 'R' THEN 'Raporlu' ";
            sql += "WHEN U_Durum = 'HT' THEN 'Hafta Tatili' ";
            sql += "WHEN U_Durum = 'UC' THEN 'Ücretsiz İzin' ";
            sql += "WHEN U_Durum = 'RT' THEN 'Resmi Tatil' ";
            sql += "WHEN U_Durum = 'YI' THEN 'Yıllık İzin' ";
            sql += "END AS \"Durum\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" ";

            if (Giris.mKodValue == "010OTATURVT")
            {
                sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + tarih1 + "' AND (T1.\"U_Bolum1\" = '" + type + "')";
            }

            if (Giris.mKodValue == "20URVT")
            {
                sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + tarih1 + "' AND (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum1\" = 'JOKER')";
            }

            sql += "  AND U_PersonelNo not in (SELECT \"AttendEmpl\" FROM \"OCLG\" WITH(NOLOCK) WHERE \"ReContact\" = '" + tarih1 + "' AND(\"Status\" = '2') AND \"AttendEmpl\" = \"U_PersonelNo\" AND \"U_RotaCode\" = '" + rota + "' AND \"U_PartiNo\" = '" + partiNo + "') ";
            #endregion Günlük Personel Planlama 3 ekranı

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            #region sql connection chn 
            Connection.sql.Close();
            Connection.sql.Dispose();
            if (Connection.sql.State == ConnectionState.Open)
            {
                cmd.ExecuteNonQuery();
            }
            #endregion

            #region Bekleyenlerde çalışan kişi var ise silinir.

            DataTable tempdt = dt.Copy();
            //tempdt.Rows.Clear();
            #region Yukarıdaki genel sorguya aşağıdaki işlem eklendi.
            //foreach (DataRow dataRow in dt.Rows)
            //{
            //    personelid = dataRow["Personel No"].ToString();

            //    queryaktivite = "Select * from \"OCLG\" WITH (NOLOCK) where \"ReContact\" = '" + tarih1 + "' and (\"Status\" = '2') and \"AttendEmpl\" = '" + personelid + "' and \"U_RotaCode\" = '" + rota + "' and \"U_PartiNo\" = '" + partiNo + "'";

            //    cmd = new SqlCommand(queryaktivite, Connection.sql);

            //    sda = new SqlDataAdapter(cmd);
            //    sda.Fill(dt99);

            //    #region sql connection chn 
            //    Connection.sql.Close();
            //    Connection.sql.Dispose();
            //    if (Connection.sql.State == ConnectionState.Open)
            //    {
            //        cmd.ExecuteNonQuery();
            //    }
            //    #endregion

            //    if (dt99.Rows.Count == 0)
            //    {
            //        tempdt.Rows.Add(dataRow.ItemArray);
            //    }
            //    dt99 = new DataTable();
            //} 
            #endregion

            #region Personel Ekleme işlemi yapıldıktan sonra aktivite yapmış olan varsa getirilir.

            #region Günlük personel planlama 1 ekranı

            //queryaktivite = "Select DISTINCT \"AttendEmpl\" as \"Personel No\",T1.\"firstName\" + ' ' + T1.\"lastName\" as \"Personel Adı\", ' ' as Saat,' ' as Dakika, ' ' as AktiviteNo from OCLG as T0 INNER JOIN OHEM as T1 ON T0.\"AttendEmpl\" = T1.\"empID\" where AttendEmpl NOT IN(Select \"U_PersonelNo\" from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and T1.\"" + field + "\" = 'Y') and \"ReContact\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and T0.\"Status\" <> '2' and \"U_RotaCode\" = '" + rota + "' and \"U_PartiNo\" = '" + partiNo + "' and ISNULL(Closed,'')<>'Y' ";

            #endregion Günlük personel planlama 1 ekranı

            #region Günlük personel planlama 2 ekranı

            //queryaktivite = "SELECT DISTINCT \"AttendEmpl\" AS \"Personel No\", T2.\"firstName\" + ' ' + T2.\"lastName\" as \"Personel Adı\" " + Environment.NewLine;
            //queryaktivite += "FROM OCLG AS T0 " + Environment.NewLine;
            //queryaktivite += " INNER JOIN OHEM as T2 ON T0.\"AttendEmpl\" = T2.\"empID\" " + Environment.NewLine;
            //queryaktivite += "WHERE AttendEmpl NOT IN (SELECT \"U_PersonelNo\" FROM \"@AIF_GUNLUKPERSPLAN\" AS T0 " + Environment.NewLine;
            //queryaktivite += "INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and " + gunfield + " = 'X') " + Environment.NewLine;
            //queryaktivite += " and \"ReContact\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"U_RotaCode\" = '" + rota + "' and \"U_PartiNo\" = '" + partiNo + "'";

            #endregion Günlük personel planlama 2 ekranı

            #region Günlük Personel Planlama 3 ekranı

            //queryaktivite = "SELECT DISTINCT \"AttendEmpl\" AS \"Personel No\", T2.\"firstName\" + ' ' + T2.\"lastName\" as \"Personel Adı\" " + Environment.NewLine;
            //queryaktivite += "FROM OCLG AS T0 WITH (NOLOCK) " + Environment.NewLine;
            //queryaktivite += " INNER JOIN OHEM as T2 WITH (NOLOCK) ON T0.\"AttendEmpl\" = T2.\"empID\" " + Environment.NewLine;
            //queryaktivite += "WHERE AttendEmpl NOT IN (SELECT \"U_PersonelNo\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) " + Environment.NewLine;
            //queryaktivite += "INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' and U_Durum ='X') " + Environment.NewLine;
            //queryaktivite += " and \"ReContact\" = '" + tarih1 + "' and \"U_RotaCode\" = '" + rota + "' and \"U_PartiNo\" = '" + partiNo + "'";


            //cmd = new SqlCommand(queryaktivite, Connection.sql);

            //sda = new SqlDataAdapter(cmd);
            //sda.Fill(dt99);

            //#region sql connection chn 
            //Connection.sql.Close();
            //Connection.sql.Dispose();
            //if (Connection.sql.State == ConnectionState.Open)
            //{
            //    cmd.ExecuteNonQuery();
            //}
            //#endregion

            //foreach (DataRow dr in dt99.Rows)
            //{
            //    queryaktivite = "Select * from \"OCLG\" WITH (NOLOCK) where \"ReContact\" = '" + tarih1 + "' and (\"Status\" = '2') and \"AttendEmpl\" = '" + dr["Personel No"].ToString() + "' and \"U_RotaCode\" = '" + rota + "' and \"U_PartiNo\" = '" + partiNo + "'";

            //    cmd = new SqlCommand(queryaktivite, Connection.sql);

            //    sda = new SqlDataAdapter(cmd);
            //    sda.Fill(dt88);

            //    #region sql connection chn 
            //    Connection.sql.Close();
            //    Connection.sql.Dispose();
            //    if (Connection.sql.State == ConnectionState.Open)
            //    {
            //        cmd.ExecuteNonQuery();
            //    }
            //    #endregion

            //    if (dt88.Rows.Count == 0)
            //    {
            //        tempdt.Rows.Add(dr.ItemArray);
            //    }

            //    //if (tempdt.AsEnumerable().Where(x => x.Field<string>("Personel No") == dr["Personel No"].ToString()).Count() == 0)
            //    //{
            //    //Burada eğer çalışanlar aktiviteden gelirse ve bir kere listeye eklendiyse bir daha eklenmiyor.
            //    //tempdt.Rows.Add(dr.ItemArray);
            //    //}
            //    dt88 = new DataTable();
            //}

            #endregion Günlük Personel Planlama 3 ekranı

            #endregion Personel Ekleme işlemi yapıldıktan sonra aktivite yapmış olan varsa getirilir.

            if (tempdt.Rows.Count > 0)
            {
                tempdt = tempdt.AsEnumerable()
                           .OrderBy(r => r.Field<string>("Personel Adı"))
                           .CopyToDataTable();
            }

            dt = tempdt;

            #endregion Bekleyenlerde çalışan kişi var ise silinir.

            dataGridView1.DataSource = dt;

            dataGridView1.Columns["Değer"].Visible = false;
        }

        private void DuraklatilmisCalisanlariGetir()
        {
            DataTable tempdt = dt.Copy();
            tempdt.Rows.Clear();
            string status = "2";

            //foreach (DataRow dataRow in data.Rows)
            //{
            //    personelid = dataRow["Personel No"].ToString();

            queryaktivite = "exec [DuraklatilmisPersonelleriGetir] '" + tarih1 + "','" + status + "', '" + rota + "','" + partiNo + "'";

            //queryaktivite = "Select * from \"OCLG\" as T0 WITH (NOLOCK) INNER JOIN OHEM T1 WITH (NOLOCK) ON T0.\"AttendEmpl\" = T1.\"empID\" where T0.\"ReContact\" = '" + tarih1 + "' and T0.\"Status\" = '" + status + "' and T0.\"U_RotaCode\" = '" + rota + "' and T0.\"U_PartiNo\" = '" + partiNo + "' order by \"ClgCode\" desc";

            cmd = new SqlCommand(queryaktivite, Connection.sql);

            sda = new SqlDataAdapter(cmd);
            sda.Fill(tempdt);


            #region Duraklatılmış personeller prosedüründe çözümlendi.
            //queryaktivite = "Select * from \"OCLG\" as T0 WITH (NOLOCK) INNER JOIN OHEM T1 WITH (NOLOCK) ON T0.\"AttendEmpl\" = T1.\"empID\" where T0.\"ReContact\" = '" + tarih1 + "' and T0.\"Status\" = '" + status + "' and T0.\"U_RotaCode\" = '" + rota + "' and T0.\"U_PartiNo\" = '" + partiNo + "' order by \"ClgCode\" desc";

            //cmd = new SqlCommand(queryaktivite, Connection.sql);

            //sda = new SqlDataAdapter(cmd);
            //sda.Fill(dt99);

            //#region sql connection chn 
            //Connection.sql.Close();
            //Connection.sql.Dispose();
            //if (Connection.sql.State == ConnectionState.Open)
            //{
            //    cmd.ExecuteNonQuery();
            //}
            //#endregion

            //foreach (DataRow item in dt99.Rows)
            //{
            //    var clgCode = item["ClgCode"].ToString();
            //    queryaktivite = "Select * from \"OCLG\" as T0 WITH (NOLOCK) INNER JOIN OHEM T1 WITH (NOLOCK) ON T0.\"AttendEmpl\" = T1.\"empID\" where T0.\"AttendEmpl\" = '" + item["AttendEmpl"].ToString() + "' and \"ClgCode\" > '" + clgCode + "' and T0.\"U_RotaCode\" = '" + rota + "' and T0.\"U_PartiNo\" = '" + partiNo + "'";
            //    cmd = new SqlCommand(queryaktivite, Connection.sql);

            //    sda = new SqlDataAdapter(cmd);
            //    sda.Fill(dt88);

            //    #region sql connection chn 
            //    Connection.sql.Close();
            //    Connection.sql.Dispose();
            //    if (Connection.sql.State == ConnectionState.Open)
            //    {
            //        cmd.ExecuteNonQuery();
            //    }
            //    #endregion

            //    if (dt88.Rows.Count == 0)
            //    {
            //        var saat = item["BeginTime"].ToString().PadLeft(4, '0');
            //        var AktiviteNo = item["ClgCode"].ToString();
            //        var PersonelNo = item["empID"].ToString();
            //        var PersonelAdi = item["firstName"].ToString() + " " + item["lastName"].ToString();

            //        DataRow dr = tempdt.NewRow();
            //        dr["AktiviteNo"] = AktiviteNo;
            //        dr["Saat"] = saat.Substring(0, 2);
            //        dr["Dakika"] = saat.Substring(2, 2);
            //        dr["Personel No"] = PersonelNo;
            //        dr["Personel Adı"] = PersonelAdi;

            //        tempdt.Rows.Add(dr);
            //    }
            //} 
            #endregion

            if (tempdt.Rows.Count > 0)
            {
                tempdt = tempdt.AsEnumerable()
                           .OrderBy(r => r.Field<string>("Personel Adı"))
                           .CopyToDataTable();
            }

            dt = tempdt;
            dataGridView1.DataSource = dt;

            #region DURAKLATILMIŞ ÜRETİMİ GETİR
            sql = "SELECT T88.\"U_DuraklamaSebep\" FROM OWOR T88 WITH (NOLOCK) WHERE T88.\"DocEntry\" = '" + uretimfisNo + "'";

            SqlDataAdapter sqlData = new SqlDataAdapter();
            DataTable dtDurum = new DataTable();
            cmd = new SqlCommand(sql, Connection.sql);
            sqlData = new SqlDataAdapter(cmd);

            sqlData.Fill(dtDurum);

            #region sql connection chn 
            Connection.sql.Close();
            Connection.sql.Dispose();
            if (Connection.sql.State == ConnectionState.Open)
            {
                cmd.ExecuteNonQuery();
            }
            #endregion

            if (dtDurum != null)
            {
                if (dtDurum.Rows.Count > 0)
                {
                    string durum = dtDurum.Rows[0]["U_DuraklamaSebep"].ToString();
                    rchDuraklama.Text = durum;

                }
            }
            #endregion
        }
        private void TamamlananlariGetir()
        {
            DataTable tempdt = dt.Copy();
            tempdt.Rows.Clear();
            //foreach (DataRow dataRow in data.Rows)
            //{
            //    personelid = dataRow["Personel No"].ToString();

            queryaktivite = "Select * from \"OCLG\" as T0 WITH (NOLOCK) INNER JOIN OHEM T1 WITH (NOLOCK) ON T0.\"AttendEmpl\" = T1.\"empID\" where T0.\"ReContact\" = '" + tarih1 + "' and T0.\"Status\" = '2' and T0.\"U_RotaCode\" = '" + rota + "' and T0.\"U_PartiNo\" = '" + partiNo + "'";

            cmd = new SqlCommand(queryaktivite, Connection.sql);

            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt99);

            #region sql connection chn 
            Connection.sql.Close();
            Connection.sql.Dispose();
            if (Connection.sql.State == ConnectionState.Open)
            {
                cmd.ExecuteNonQuery();
            }
            #endregion

            foreach (DataRow dataRow in dt99.Rows)
            {
                var saat = dataRow["EndTime"].ToString().PadLeft(4, '0');
                var AktiviteNo = dataRow["ClgCode"].ToString();
                var PersonelNo = dataRow["empID"].ToString();
                var PersonelAdi = dataRow["firstName"].ToString() + " " + dataRow["lastName"].ToString();

                DataRow dr = tempdt.NewRow();
                dr["AktiviteNo"] = AktiviteNo;
                dr["Saat"] = saat.Substring(0, 2);
                dr["Dakika"] = saat.Substring(2, 2);
                dr["Personel No"] = PersonelNo;
                dr["Personel Adı"] = PersonelAdi;

                tempdt.Rows.Add(dr);
            }

            dt = tempdt;
            dataGridView1.DataSource = dt;
            //}
        }

        private string btnType; //1-Başlat 2-Duraklat

        private void AktiviteIslemleri_2_Load(object sender, EventArgs e)
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


            UretimdenGirisMiktari.dialogResult = "";
            if (btnType == "1")
            {
                btnDuraklamaSebebi.Visible = false;
                rchDuraklama.Visible = false;
                txtDuraklamaKod.Visible = false;
                BekleyenleriGetir();

                dt.Columns.Add("Secim", typeof(string));

                Checkboxolustur();

                butonOlustur();
                int i = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];
                    if (chk.Value == chk.FalseValue || chk.Value == null)
                    {
                        var calisiyorMu = row.Cells["Değer"].Value.ToString();

                        if (calisiyorMu == "X")
                        {
                            chk.Value = chk.TrueValue;
                            dt.Rows[i]["Secim"] = "Y";
                        }
                        else
                        {
                            dataGridView1.Rows[i].Cells["Durum"].Style.BackColor = Color.Red;
                        }
                    }
                    i++;
                }
                dataGridView1.EndEdit();

                //if (dt.Rows.Count > 0)
                //{
                dataGridView1.Columns["btnSeç"].DisplayIndex = 0;
                dataGridView1.Columns["ScmCheck"].DisplayIndex = 1;
                dataGridView1.Columns["Personel No"].DisplayIndex = 2;
                dataGridView1.Columns["Personel Adı"].DisplayIndex = 3;
                dataGridView1.Columns["Saat"].DisplayIndex = 4;
                dataGridView1.Columns["Dakika"].DisplayIndex = 5;
                dataGridView1.Columns["AktiviteNo"].DisplayIndex = 6;

                dataGridView1.Columns["Saat"].Visible = false;
                dataGridView1.Columns["Dakika"].Visible = false;
                dataGridView1.Columns["AktiviteNo"].Visible = false;
                dataGridView1.Columns["Secim"].Visible = false;
                dataGridView1.Columns["ScmCheck"].Width = 60;
                dataGridView1.Columns["ScmCheck"].ReadOnly = true;
                button7.Visible = true;
            }
            else if (btnType == "2")
            {
                string field = "U_" + type;

                DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                string gunfield = "U_Gun" + dtTarih.Day;

                #region Günlük personel planlama 2 ekranı

                //sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\",'  ' as Saat,'  ' as Dakika,'    ' as AktiviteNo from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

                #endregion Günlük personel planlama 2 ekranı

                #region Günlük personel planlama 1 ekranı

                //sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\",'  ' as Saat,'  ' as Dakika,'    ' as AktiviteNo from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and T1.\"" + field + "\" = 'Y'";

                #endregion Günlük personel planlama 1 ekranı

                #region Günlük Personel Planlama 3 ekranı

                sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\",'  ' AS \"Saat\",'  ' AS \"Dakika\",'    ' AS \"AktiviteNo\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and \"U_Durum\" = 'X'";

                #endregion Günlük Personel Planlama 3 ekranı

                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                #region sql connection chn 
                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
                #endregion

                DuraklatilmisCalisanlariGetir();

                Checkboxolustur();

                butonOlustur();
                dt.Columns.Add("Secim", typeof(string));

                int i = 0;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];
                    if (chk.Value == chk.FalseValue || chk.Value == null)
                    {
                        chk.Value = chk.TrueValue;
                        dt.Rows[i]["Secim"] = "Y";
                    }
                    i++;
                }
                dataGridView1.EndEdit();

                dataGridView1.Columns["btnSeç"].DisplayIndex = 0;
                dataGridView1.Columns["ScmCheck"].DisplayIndex = 1;
                dataGridView1.Columns["Personel No"].DisplayIndex = 2;
                dataGridView1.Columns["Personel Adı"].DisplayIndex = 3;
                dataGridView1.Columns["Saat"].DisplayIndex = 4;
                dataGridView1.Columns["Dakika"].DisplayIndex = 5;
                dataGridView1.Columns["AktiviteNo"].DisplayIndex = 6;
                dataGridView1.Columns["Saat"].Visible = false;
                dataGridView1.Columns["Dakika"].Visible = false;
                dataGridView1.Columns["AktiviteNo"].Visible = false;
                dataGridView1.Columns["Secim"].Visible = false;
                dataGridView1.Columns["ScmCheck"].Width = 60;
                dataGridView1.Columns["ScmCheck"].ReadOnly = true;
            }
            else if (btnType == "4")
            {
                string field = "U_" + type;

                DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                string gunfield = "U_Gun" + dtTarih.Day;

                #region Günlük personel planlama 2 ekranı

                //sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\",'  ' as Saat,'  ' as Dakika,'    ' as AktiviteNo from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

                #endregion Günlük personel planlama 2 ekranı

                #region Günlük personel planlama 1 ekranı

                //sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\",'  ' as Saat,'  ' as Dakika,'    ' as AktiviteNo from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and T1.\"" + field + "\" = 'Y'";

                #endregion Günlük personel planlama 1 ekranı

                #region Günlük personel planlama 3 ekranı

                sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\",'  ' AS \"Saat\",'  ' AS \"Dakika\",'    ' AS \"AktiviteNo\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and \"U_Durum\" = 'X'";

                #endregion Günlük personel planlama 3 ekranı

                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                #region sql connection chn 
                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
                #endregion

                TamamlananlariGetir();
            }

            richTextBox1.Text = DateTime.Now.Hour.ToString().PadLeft(2, '0');
            richTextBox2.Text = DateTime.Now.Minute.ToString().PadLeft(2, '0');

            richTextBox1.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

            richTextBox2.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
            richTextBox2.SelectionAlignment = HorizontalAlignment.Center;

            aktiveParams = getTolerans();

            setFormatGrid(dataGridView1, 15);

            dataGridView1.Columns["Personel No"].Width = 130;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dataGridView1.Columns["Personel No"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView1.Columns["Personel Adı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void butonOlustur()
        {
            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

            btn = new DataGridViewButtonColumn();
            dataGridView1.Columns.Add(btn);
            btn.HeaderText = "Seç";
            btn.Text = "Seç";
            btn.Name = "btnSeç";
            btn.UseColumnTextForButtonValue = true;
            btn.Width = 40;
        }

        private void Checkboxolustur()
        {
            checkColumn = new DataGridViewCheckBoxColumn();

            checkColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkColumn.CellTemplate = new DataGridViewCheckBoxCell();
            checkColumn.FalseValue = true;
            checkColumn.HeaderText = "Seçim";
            checkColumn.Name = "ScmCheck";
            checkColumn.TrueValue = true;
            checkColumn.FalseValue = false;
            dataGridView1.Columns.Add(checkColumn);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["ScmCheck"].DisplayIndex = 0;
            dataGridView1.Columns["Personel No"].DisplayIndex = 1;
            dataGridView1.Columns["Personel Adı"].DisplayIndex = 2;
            dataGridView1.Columns["Saat"].DisplayIndex = 3;
            dataGridView1.Columns["Dakika"].DisplayIndex = 4;
            dataGridView1.Columns["AktiviteNo"].DisplayIndex = 5;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].Name == "btnSeç")
                {
                    string durum = "";

                    if (btnType == "1")
                    {
                        durum = dataGridView1.Rows[e.RowIndex].Cells["Değer"].Value.ToString();

                        if (durum == "X")
                        {
                            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                            DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];
                            if (chk.Value == chk.FalseValue || chk.Value == null)
                            {
                                chk.Value = chk.TrueValue;
                                dt.Rows[e.RowIndex]["Secim"] = "Y";
                            }
                            else
                            {
                                chk.Value = chk.FalseValue;
                                dt.Rows[e.RowIndex]["Secim"] = "N";
                            }
                            dataGridView1.EndEdit();
                        }
                        else
                        {
                            var durumAciklamasi = dataGridView1.Rows[e.RowIndex].Cells["Durum"].Value.ToString();
                            CustomMsgBtn.Show(durumAciklamasi + " durumunda olan çalışan için seçim yapılamaz.", "UYARI", "TAMAM");
                        }
                    }
                    else
                    {
                        DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                        DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];
                        if (chk.Value == chk.FalseValue || chk.Value == null)
                        {
                            chk.Value = chk.TrueValue;
                            dt.Rows[e.RowIndex]["Secim"] = "Y";
                        }
                        else
                        {
                            chk.Value = chk.FalseValue;
                            dt.Rows[e.RowIndex]["Secim"] = "N";
                        }
                        dataGridView1.EndEdit();
                    }
                }
            }
        }

        private DataTable dtAktiviteParam = new DataTable();

        public List<Tuple<string, int>> getTolerans()
        {
            try
            {
                string sql = "Select ISNULL(\"U_Hour\",0),ISNULL(\"U_Minute\",0) from \"@AIF_UVT_ACTPARAM\" WITH (NOLOCK)";
                SqlCommand cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtAktiviteParam);

                #region sql connection chn 
                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
                #endregion

                var akt = dtAktiviteParam.Select().ToList();

                //int hou

                List<Tuple<string, int>> ret = new List<Tuple<string, int>>();
                if (akt.Count > 0)
                {
                    ret.Add(Tuple.Create("Saat", Convert.ToInt32(akt[0].ItemArray[0])));
                    ret.Add(Tuple.Create("Dakika", Convert.ToInt32(akt[0].ItemArray[1])));
                }
                else
                {
                    ret.Add(Tuple.Create("Saat", Convert.ToInt32("0")));
                    ret.Add(Tuple.Create("Dakika", Convert.ToInt32("0")));
                }
                return ret;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: STTA06 " + ex.Message, "UYARI", "TAMAM");
            }

            return null;
        }

        private DateTime sistemSaati = DateTime.Now;
        private List<Tuple<string, int>> aktiveParams = new List<Tuple<string, int>>();

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int saat = Convert.ToInt32(richTextBox1.Text);
                saat = saat - 1;
                int sistemsaati = sistemSaati.Hour;
                int result = Math.Abs(saat - sistemsaati);
                int tolerans = aktiveParams.Where(x => x.Item1 == "Saat").Count() > 0 ? aktiveParams.Where(x => x.Item1 == "Saat").Select(y => y.Item2).FirstOrDefault() : 0;

                if (tolerans < result)
                {
                    CustomMsgBtn.Show("Tolerans süreniz " + tolerans + " saat kadardır. Daha fazla düşürülemez.", "UYARI", "TAMAM");
                    return;
                }

                //if (saat == 0)
                //{
                //    saat = 00;
                //}
                if (saat == -1)
                {
                    saat = 23;
                }

                richTextBox1.Text = saat.ToString().PadLeft(2, '0');

                richTextBox1.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: STTA03 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int saat = Convert.ToInt32(richTextBox1.Text);
                saat = saat + 1;
                int sistemsaati = sistemSaati.Hour;
                int result = saat - sistemsaati;
                int tolerans = aktiveParams.Where(x => x.Item1 == "Saat").Count() > 0 ? aktiveParams.Where(x => x.Item1 == "Saat").Select(y => y.Item2).FirstOrDefault() : 0;

                if (result > tolerans)
                {
                    CustomMsgBtn.Show("Tolerans süreniz " + tolerans + " saat kadardır. Daha fazla yükseltilemez.", "UYARI", "TAMAM");
                    return;
                }
                //else if (tolerans < result)
                //{
                //    MessageBox.Show("Tolerans süreniz " + tolerans + " saat kadardır. Daha fazla düşürülemez.");
                //    return;
                //}

                if (saat == 24)
                {
                    saat = 00;
                }

                richTextBox1.Text = saat.ToString().PadLeft(2, '0');

                richTextBox1.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: STTA002 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int dakika = Convert.ToInt32(richTextBox2.Text);
                dakika = dakika - 1;
                int sistemdakikasi = sistemSaati.Minute;
                int result = Math.Abs(dakika - sistemdakikasi);
                int tolerans = aktiveParams.Where(x => x.Item1 == "Dakika").Count() > 0 ? aktiveParams.Where(x => x.Item1 == "Dakika").Select(y => y.Item2).FirstOrDefault() : 0;

                if (tolerans < result)
                {
                    CustomMsgBtn.Show("Tolerans süreniz " + tolerans + " dakika kadardır. Daha fazla düşürülemez.", "UYARI", "TAMAM");
                    return;
                }

                if (dakika == -1)
                {
                    dakika = 59;
                }

                richTextBox2.Text = dakika.ToString().PadLeft(2, '0');
                richTextBox2.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: STTA05 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int dakika = Convert.ToInt32(richTextBox2.Text);
                dakika = dakika + 1;
                int sistemdakikasi = sistemSaati.Minute;
                int result = Math.Abs(dakika - sistemdakikasi);
                int tolerans = aktiveParams.Where(x => x.Item1 == "Dakika").Count() > 0 ? aktiveParams.Where(x => x.Item1 == "Dakika").Select(y => y.Item2).FirstOrDefault() : 0;

                if (result > tolerans)
                {
                    CustomMsgBtn.Show("Tolerans süreniz " + tolerans + " dakika kadardır. Daha fazla yükseltilemez.", "UYARI", "TAMAM");
                    return;
                }

                if (dakika == 60)
                {
                    dakika = 00;
                }

                richTextBox2.Text = dakika.ToString().PadLeft(2, '0');
                richTextBox2.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: STTA04 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void setFormatGrid(DataGridView dtg, int value)
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dtg.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //foreach (DataGridViewColumn col in dtg.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Bahnschrift", Font.Size, FontStyle.Bold, GraphicsUnit.Pixel);
            //}

            for (int i = 0; i <= dtg.Rows.Count - 1; i++)
            {
                //var aa = dtg.RowTemplate.Height;
                //dtg.Rows[i].Height = 40;
                if (i % 2 == 0)
                    dtg.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                else
                    dtg.Rows[i].DefaultCellStyle.BackColor = Color.DimGray;

                dtg.Rows[i].DefaultCellStyle.ForeColor = Color.White;
            }
            for (int i = 0; i <= dtg.Columns.Count - 1; i++)
            {
                dtg.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //UVTServiceSoapClient client1 = new UVTServiceSoapClient();
            //var aaa = client1.connectsaphakan();

            //return;

            Response response = new Response();
            if (btnType == "1")
            {
                try
                {
                    UVTServiceSoapClient client = new UVTServiceSoapClient();
                    UVTService.Contacts contacts = new Contacts();
                    List<UVTService.Contacts> contacts_List = new List<Contacts>();
                    RotaDurum rotaDurum = new RotaDurum();
                    string uyari = "";


                    foreach (DataRow dataRow in dt.Rows)
                    {
                        contacts = new Contacts();
                        if (dataRow["Secim"].ToString() != "Y")
                        {
                            continue;
                        }
                        //string aktiviteNo = dataRow["AktiviteNo"].ToString().Trim();

                        //if (aktiviteNo == "")
                        //{
                        string id = dataRow["Personel No"].ToString();
                        string name = dataRow["Personel Adı"].ToString();
                        string saat = richTextBox1.Text;
                        string dakika = richTextBox2.Text;
                        //var a = oContats.GetByKey(Convert.ToInt32(id));

                        DateTime baslangic = DateTime.Now;
                        TimeSpan t = new TimeSpan(Convert.ToInt32(saat), Convert.ToInt32(dakika), 00);
                        baslangic = baslangic.Date + t;

                        contacts.ContactType = "2";
                        contacts.ContactSubType = "-1";
                        contacts.StartTime = baslangic;
                        contacts.Status = "2";
                        contacts.ContactId = id;
                        contacts.PartiNo = partiNo;
                        contacts.RotaKodu = rota;
                        contacts.StartDate = tarih1;
                        contacts.UserId = Giris.id;


                        contacts_List.Add(contacts);
                    }

                    var resp = client.AddContacts(contacts_List.ToArray(), Giris.dbName, Giris.mKodValue);


                    if (resp.Value == 0)
                    {

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();
                        string updatesql = "";
                        updatesql = "UPDATE \"@AIF_URT_PART1\" SET \"U_Durum\" = 'B' where \"U_PartiNo\" = '" + partiNo + "'";

                        cmd = new SqlCommand(updatesql, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                        {
                            Connection.sql.Open();
                        }
                        sda = new SqlDataAdapter(cmd);
                        sda.Fill(dt);

                        #region sql connection chn 
                        Connection.sql.Close();
                        Connection.sql.Dispose();
                        if (Connection.sql.State == ConnectionState.Open)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        #endregion


                        response = client.UpdateProductionOrders(Giris.dbName, Convert.ToInt32(uretimfisNo), "", Giris.mKodValue);

                        rotaDurum.UretimFisNo = Convert.ToInt32(uretimfisNo);
                        rotaDurum.RotaKodu = rota;
                        rotaDurum.PartiNo = partiNo;
                        rotaDurum.DurumKodu = "2";
                        rotaDurum.DurumAciklamasi = "Devam Ediyor";

                        resp = client.AddOrUpdateRotaDurum(rotaDurum, Giris.dbName, Giris.mKodValue);
                         
                        CustomMsgBtn.Show("AKTIVITE IŞLEMLERI TAMAMLANDI", "UYARI", "TAMAM");

                        if (response.Value == 0)
                        {
                            button1.PerformClick();
                        }
                    }


                    #region Old
                    //UVTServiceSoapClient client = new UVTServiceSoapClient();
                    //UVTService.Contacts contacts = new UVTService.Contacts();
                    //RotaDurum rotaDurum = new RotaDurum();
                    //string uyari = "";
                    //foreach (DataRow dataRow in dt.Rows)
                    //{
                    //    if (dataRow["Secim"].ToString() != "Y")
                    //    {
                    //        continue;
                    //    }
                    //    //string aktiviteNo = dataRow["AktiviteNo"].ToString().Trim();

                    //    //if (aktiviteNo == "")
                    //    //{
                    //    string id = dataRow["Personel No"].ToString();
                    //    string name = dataRow["Personel Adı"].ToString();
                    //    string saat = richTextBox1.Text;
                    //    string dakika = richTextBox2.Text;
                    //    //var a = oContats.GetByKey(Convert.ToInt32(id));

                    //    DateTime baslangic = DateTime.Now;
                    //    TimeSpan t = new TimeSpan(Convert.ToInt32(saat), Convert.ToInt32(dakika), 00);
                    //    baslangic = baslangic.Date + t;

                    //    contacts.ContactType = "2";
                    //    contacts.ContactSubType = "-1";
                    //    contacts.StartTime = baslangic;
                    //    contacts.Status = "2";
                    //    contacts.ContactId = id;
                    //    contacts.PartiNo = partiNo;
                    //    contacts.RotaKodu = rota;
                    //    contacts.StartDate = tarih1;
                    //    contacts.UserId = Giris.id;

                    //    response = client.AddContacts(contacts, Giris.dbName, Giris.mKodValue);

                    //    if (response.Value == 0)
                    //    {
                    //        try
                    //        {
                    //            SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    //            dt = new DataTable();
                    //            string updatesql = "";
                    //            updatesql = "UPDATE \"@AIF_URT_PART1\" SET \"U_Durum\" = 'B' where \"U_PartiNo\" = '" + partiNo + "'";

                    //            cmd = new SqlCommand(updatesql, Connection.sql);

                    //            if (Connection.sql.State != ConnectionState.Open)
                    //            {
                    //                Connection.sql.Open();
                    //            }
                    //            sda = new SqlDataAdapter(cmd);
                    //            sda.Fill(dt);

                    //            #region sql connection chn 
                    //            Connection.sql.Close();
                    //            Connection.sql.Dispose();
                    //            if (Connection.sql.State == ConnectionState.Open)
                    //            {
                    //                cmd.ExecuteNonQuery();
                    //            }
                    //            #endregion


                    //            #region üretim siparişi durraklatma

                    //            response = client.UpdateProductionOrders(Giris.dbName, Convert.ToInt32(uretimfisNo), "", Giris.mKodValue);

                    //            if (uyari == "")
                    //            {
                    //                uyari += name + " çalışan için sonuç -->" + response.Description;
                    //            }
                    //            else
                    //            {
                    //                uyari += Environment.NewLine;
                    //                uyari += name + " çalışan için sonuç -->" + response.Description;
                    //            }

                    //            #endregion
                    //        }
                    //        catch (Exception ex)
                    //        {
                    //            CustomMsgBtn.Show("Hata." + ex.Message, "UYARI", "TAMAM");

                    //        }
                    //    }

                    //    if (uyari == "")
                    //    {
                    //        uyari += name + " çalışan için sonuç -->" + response.Description;
                    //    }
                    //    else
                    //    {
                    //        uyari += Environment.NewLine;
                    //        uyari += name + " çalışan için sonuç -->" + response.Description;
                    //    }

                    //    rotaDurum.UretimFisNo = Convert.ToInt32(uretimfisNo);
                    //    rotaDurum.RotaKodu = rota;
                    //    rotaDurum.PartiNo = partiNo;
                    //    rotaDurum.DurumKodu = "2";
                    //    rotaDurum.DurumAciklamasi = "Devam Ediyor";

                    //    var resp = client.AddOrUpdateRotaDurum(rotaDurum, Giris.dbName, Giris.mKodValue);

                    //    //}
                    //}
                    //if (uyari != "")
                    //{
                    //    CustomMsgBtn.Show(uyari, "UYARI", "TAMAM");
                    //}
                    //if (response.Value == 0)
                    //{
                    //    button1.PerformClick();
                    //} 
                    #endregion
                }
                catch (Exception ex)
                {
                }
            }
            else if (btnType == "2" || btnType == "4")
            {

                UVTServiceSoapClient client = new UVTServiceSoapClient();
                UVTService.Contacts contacts = new Contacts();
                List<UVTService.Contacts> contacts_List = new List<Contacts>();
                RotaDurum rotaDurum = new RotaDurum();
                string uyari = "";


                if (btnType == "4")
                {
                    if (uretimdengirisYap == "Y")
                    {
                        UretimdenGirisMiktari f = new UretimdenGirisMiktari(uretimfisNo, 0, partiNo, 0, planlananMiktar, initialWidth, initialHeight, urunKodu, varsayilanDepo, rota, tarih1, siparisTarihi);
                        f.ShowDialog();

                        if (UretimdenGirisMiktari.dialogResult == "Ok")
                        {
                            if (btnType == "4")
                            {
                                rotaDurum.UretimFisNo = Convert.ToInt32(uretimfisNo);
                                rotaDurum.RotaKodu = rota;
                                rotaDurum.PartiNo = partiNo;
                                rotaDurum.DurumKodu = "3";
                                rotaDurum.DurumAciklamasi = "Tamamlandı";

                                response = client.AddOrUpdateRotaDurum(rotaDurum, Giris.dbName, Giris.mKodValue);

                                if (response.Value != 0)
                                {
                                    CustomMsgBtn.Show(response.Description, "UYARI", "TAMAM");
                                    return;
                                }
                            }
                        }
                        else
                        {
                            response.Value = -110;
                        }
                    }
                }


                foreach (DataRow dataRow in dt.Rows)
                {
                    contacts = new Contacts();
                    if (btnType != "4")
                    {
                        if (dataRow["Secim"].ToString() != "Y")
                        {
                            continue;
                        }
                    }

                    if (btnType == "4" && response.Value == -110)
                    {
                        DialogResult answer = CustomMsgBox.Show("Gerçekleşen miktar girilmeden çıkılmıştır. Aktivitelerinizi ve üretim emrini kapatmak istiyor musunuz?", "Uyarı", "Evet", "Hayır");
                        //DialogResult answer = CustomMsgBox.Show("Üretimden giriş oluşmadığıdan aktiviteler kapatılmamıştır. Devam etmek istiyor musunuz?", "Uyarı", "Evet", "Hayır");

                        if (!CustomMsgBox.Value)
                        {
                            return;
                        }
                    }
                    string aktiviteNo = dataRow["AktiviteNo"].ToString().Trim();

                    //if (aktiviteNo != "")
                    //{
                    string id = dataRow["Personel No"].ToString();
                    string name = dataRow["Personel Adı"].ToString();
                    string saat = richTextBox1.Text;
                    string dakika = richTextBox2.Text;

                    DateTime bitis = DateTime.Now;
                    TimeSpan t = new TimeSpan(Convert.ToInt32(saat), Convert.ToInt32(dakika), 00);
                    bitis = bitis.Date + t;

                    contacts.ClgCode = aktiviteNo;
                    contacts.EndTime = bitis;
                    contacts.UserId = Giris.id;
                    if (btnType == "2")
                        contacts.Status = "1";
                    else if (btnType == "4")
                        contacts.Status = "-3";

                    contacts.Closed = "Y";

                    //if (uyari == "")
                    //{
                    //    uyari += name + " çalışan için sonuç -->" + response.Description;
                    //}
                    //else
                    //{
                    //    uyari += Environment.NewLine;
                    //    uyari += name + " çalışan için sonuç -->" + response.Description;
                    //}

                    contacts_List.Add(contacts);

                }



                response = client.UpdateContacts(contacts_List.ToArray(), Giris.dbName, Giris.mKodValue);

                if (btnType == "4")
                {
                    rotaDurum.UretimFisNo = Convert.ToInt32(uretimfisNo);
                    rotaDurum.RotaKodu = rota;
                    rotaDurum.PartiNo = partiNo;
                    rotaDurum.DurumKodu = "3";
                    rotaDurum.DurumAciklamasi = "Tamamlandı";

                    response = client.AddOrUpdateRotaDurum(rotaDurum, Giris.dbName, Giris.mKodValue);
                }

                if (btnType == "2")
                {
                    if (rchDuraklama.Text != "")
                    {
                        response = client.UpdateProductionOrders(Giris.dbName, Convert.ToInt32(uretimfisNo), rchDuraklama.Text, Giris.mKodValue);
                    }
                }


                if (response.Value == 0)
                {
                    CustomMsgBtn.Show("AKTIVITE IŞLEMLERI TAMAMLANDI", "UYARI", "TAMAM");

                    button1.PerformClick();
                }


                #region Old
                //UVTService.UVTServiceSoapClient client = new UVTService.UVTServiceSoapClient();
                //UVTService.Contacts contacts = new UVTService.Contacts();
                //RotaDurum rotaDurum = new RotaDurum();
                //string uyari = "";

                //if (btnType == "4")
                //{
                //    if (uretimdengirisYap == "Y")
                //    {
                //        UretimdenGirisMiktari f = new UretimdenGirisMiktari(uretimfisNo, 0, partiNo, 0, planlananMiktar, initialWidth, initialHeight, urunKodu, varsayilanDepo, rota, tarih1);
                //        f.ShowDialog();

                //        if (UretimdenGirisMiktari.dialogResult == "Ok")
                //        {
                //            if (btnType == "4")
                //            {
                //                rotaDurum.UretimFisNo = Convert.ToInt32(uretimfisNo);
                //                rotaDurum.RotaKodu = rota;
                //                rotaDurum.PartiNo = partiNo;
                //                rotaDurum.DurumKodu = "3";
                //                rotaDurum.DurumAciklamasi = "Tamamlandı";

                //                response = client.AddOrUpdateRotaDurum(rotaDurum, Giris.dbName, Giris.mKodValue);

                //                if (response.Value != 0)
                //                {
                //                    CustomMsgBtn.Show(response.Description, "UYARI", "TAMAM");
                //                    return;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            response.Value = -110;
                //        }
                //    }
                //}

                //foreach (DataRow dataRow in dt.Rows)
                //{
                //    if (btnType != "4")
                //    {
                //        if (dataRow["Secim"].ToString() != "Y")
                //        {
                //            continue;
                //        }
                //    }

                //    if (btnType == "4" && response.Value == -110)
                //    {
                //        DialogResult answer = CustomMsgBox.Show("Gerçekleşen miktar girilmeden çıkılmıştır. Aktivitelerinizi ve üretim emrini kapatmak istiyor musunuz?", "Uyarı", "Evet", "Hayır");
                //        //DialogResult answer = CustomMsgBox.Show("Üretimden giriş oluşmadığıdan aktiviteler kapatılmamıştır. Devam etmek istiyor musunuz?", "Uyarı", "Evet", "Hayır");

                //        if (!CustomMsgBox.Value)
                //        {
                //            return;
                //        }
                //    }
                //    string aktiviteNo = dataRow["AktiviteNo"].ToString().Trim();

                //    //if (aktiviteNo != "")
                //    //{
                //    string id = dataRow["Personel No"].ToString();
                //    string name = dataRow["Personel Adı"].ToString();
                //    string saat = richTextBox1.Text;
                //    string dakika = richTextBox2.Text;

                //    DateTime bitis = DateTime.Now;
                //    TimeSpan t = new TimeSpan(Convert.ToInt32(saat), Convert.ToInt32(dakika), 00);
                //    bitis = bitis.Date + t;

                //    contacts.ClgCode = aktiviteNo;
                //    contacts.EndTime = bitis;
                //    contacts.UserId = Giris.id;
                //    if (btnType == "2")
                //        contacts.Status = "1";
                //    else if (btnType == "4")
                //        contacts.Status = "-3";

                //    contacts.Closed = "Y";

                //    response = client.UpdateContacts(contacts, Giris.dbName, Giris.mKodValue);

                //    if (uyari == "")
                //    {
                //        uyari += name + " çalışan için sonuç -->" + response.Description;
                //    }
                //    else
                //    {
                //        uyari += Environment.NewLine;
                //        uyari += name + " çalışan için sonuç -->" + response.Description;
                //    }

                //    if (btnType == "4")
                //    {
                //        rotaDurum.UretimFisNo = Convert.ToInt32(uretimfisNo);
                //        rotaDurum.RotaKodu = rota;
                //        rotaDurum.PartiNo = partiNo;
                //        rotaDurum.DurumKodu = "3";
                //        rotaDurum.DurumAciklamasi = "Tamamlandı";

                //        response = client.AddOrUpdateRotaDurum(rotaDurum, Giris.dbName, Giris.mKodValue);
                //    }

                //    if (btnType == "2")
                //    {

                //        if (rchDuraklama.Text != "")
                //        {
                //            response = client.UpdateProductionOrders(Giris.dbName, Convert.ToInt32(uretimfisNo), rchDuraklama.Text, Giris.mKodValue);

                //            if (uyari == "")
                //            {
                //                uyari += name + " çalışan için sonuç -->" + response.Description;
                //            }
                //            else
                //            {
                //                uyari += Environment.NewLine;
                //                uyari += name + " çalışan için sonuç -->" + response.Description;
                //            }
                //        }
                //        //rotaDurum.UretimFisNo = Convert.ToInt32(uretimfisNo);
                //        //rotaDurum.RotaKodu = rota;
                //        //rotaDurum.PartiNo = partiNo;
                //        //rotaDurum.DurumKodu = "4";
                //        //rotaDurum.DurumAciklamasi = txtDuraklama.Text;
                //        //response = client.AddOrUpdateRotaDurum(rotaDurum, Giris.dbName, Giris.mKodValue);
                //    }
                //}

                ////}
                //if (uyari != "")
                //{
                //    CustomMsgBtn.Show(uyari, "UYARI", "TAMAM");
                //}
                //if (response.Value == 0)
                //{
                //    button1.PerformClick();
                //} 
                #endregion
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            List<string> varolanPersoneller = new List<string>();

            for (int i = 0; i <= dataGridView1.Rows.Count - 1; i++)
            {
                var id = dataGridView1.Rows[i].Cells["Personel No"].Value.ToString();
                varolanPersoneller.Add(id);
                //varolanPersoneller += varolanPersoneller == "" ? id + "," : id + ",";
            }

            //if (varolanPersoneller != "")
            //{
            //    varolanPersoneller = varolanPersoneller.Remove(varolanPersoneller.Length - 1, 1);
            //}

            string sql = "";

            DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
            string gunfield = "U_Gun" + dtTarih.Day;

            #region Günlük Personel Planlama 2 ekranı

            //sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

            #endregion Günlük Personel Planlama 2 ekranı

            #region Günlük Personel Planlama 3 ekranı

            sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\",'  ' AS \"Saat\",'  ' AS \"Dakika\",'    ' AS \"AktiviteNo\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
            sql += "WHERE Convert(varchar,T0.\"U_Tarih\",112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and \"U_Durum\" = 'X'";

            #endregion Günlük Personel Planlama 3 ekranı

            if (varolanPersoneller.Count > 0)
            {
                sql += " and \"U_PersonelNo\" NOT IN (";

                foreach (var item in varolanPersoneller)
                {
                    sql += "'" + item + "',";
                }

                sql = sql.Remove(sql.Length - 1, 1);

                sql += ")";
            }

            SelectList selectList = new SelectList(sql, dataGridView1, _yeniSatir: "Y", _dtparams: dt, _type: "PersonelEkle");
            selectList.ShowDialog();
            try
            {
                DataGridViewRow row = dataGridView1.Rows[dataGridView1.Rows.Count - 1];
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["ScmCheck"];
                if (chk.Value == chk.FalseValue || chk.Value == null)
                {
                    chk.Value = chk.TrueValue;
                    dataGridView1.EndEdit();
                    setFormatGrid(dataGridView1, 15);
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnDuraklamaSebebi_Click(object sender, EventArgs e)
        {
            string sql1 = "Select \"DocEntry\",\"U_DuraklamaSebep\" as \"DuraklamaSebep\" from \"@AIF_UVT_DURAKLAMA\" WITH (NOLOCK)";

            SelectList selectList = new SelectList(sql1, _txtParam: txtDuraklamaKod, _rchParamDesc: rchDuraklama, _autoresizerow: false);
            selectList.ShowDialog();
        }
    }
}
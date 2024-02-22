using AIF.UVT.DatabaseLayer;
using AIF.UVT.FORM_010OTATURVT;
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

    public partial class TemizlikTakip : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end.



        public TemizlikTakip(string _istasyon, string _istasyonAdi, string _kullaniciid, int _row, int _width, int _height, string _tarih1)
        {
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;

            initialFontSize = button3.Font.Size;
            button3.Resize += Form_Resize;
            //font end
            tarih1 = _tarih1;
            istasyon = _istasyon;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyonAdi = _istasyonAdi;

            txtUretimtarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
        }
        private string istasyon = "";
        private string tarih1 = "";
        private string kullaniciid = "";
        private int row;
        private string istasyonAdi = "";

        private DataGridViewCheckBoxColumn checkColumn = null;
        private DataGridViewCheckBoxColumn checkColumn2 = null;
        private DataGridViewCheckBoxColumn checkColumn3 = null;
        private DataGridViewCheckBoxColumn checkColumn4 = null;

        private DataTable dtCheckbox = new DataTable();
        private DataTable dtCheckbox2 = new DataTable();

        private DataTable dtCIP = new DataTable();
        private DataTable dtCIP2 = new DataTable();
        private DataTable dtAletEkipman = new DataTable();
        private DataTable dtTemizlikBaslik = new DataTable();

        private SqlCommand cmd = null;
        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              button1.Font.Style);

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button2.Font.Style);

            button3.Font = new Font(button3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button3.Font.Style);

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

            txtOnayDurumu.Font = new Font(txtOnayDurumu.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtOnayDurumu.Font.Style);

            txtOnayTarihi.Font = new Font(txtOnayTarihi.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtOnayTarihi.Font.Style);

            rchOnayAciklamasi.Font = new Font(rchOnayAciklamasi.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              rchOnayAciklamasi.Font.Style);

            txtUretimtarihi.Font = new Font(txtUretimtarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimtarihi.Font.Style);

            txtIstasyon.Font = new Font(txtIstasyon.Font.FontFamily, initialFontSize *
             (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
             txtIstasyon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOnayla.Font.Style);

            btnYoneticiOnay.Font = new Font(btnYoneticiOnay.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnYoneticiOnay.Font.Style);

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

        private void TazePeynirTemizlikTakip_Load(object sender, EventArgs e)
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
            txtIstasyon.Text = istasyonAdi == "" ? istasyon : istasyonAdi;

            #endregion MKOD İle Background Değişimi
            TemizlikBaslikVerileri();
            dtgCIP1Load();
            dtgCIP2Load();
            dtgAletEkipmanTemizlikLoad();
        }

        private void TemizlikBaslikVerileri()
        {
            DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));

            string sql = "Select T0.\"U_YoneticiOnay\",Convert(varchar,T0.\"U_YoneticiOnyTar\",103) as \"YoneticiOnyTar\",T0.\"U_YoneticiAciklama\" from \"@AIF_TEMIZLIK\" as T0 WITH (NOLOCK) where Convert(varchar,T0.\"U_Tarih\",112) = '" + dtTarih.ToString("yyyyMMdd") + "' and \"U_IstasyonKodu\"='" + istasyon + "'"; 

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd); 
            dtTemizlikBaslik = new DataTable();
            sda.Fill(dtTemizlikBaslik);

            Connection.sql.Close();
            Connection.sql.Dispose();
            if (Connection.sql.State == ConnectionState.Open)
            {
                cmd.ExecuteNonQuery();
            }

            if (dtTemizlikBaslik.Rows.Count > 0)
            {
                txtOnayDurumu.Text = dtTemizlikBaslik.Rows[0]["U_YoneticiOnay"].ToString() == "E" ? "Onaylandı" : "Onaylanmadı";
                  
                txtOnayTarihi.Text = dtTemizlikBaslik.Rows[0]["YoneticiOnyTar"].ToString();

                rchOnayAciklamasi.Text = dtTemizlikBaslik.Rows[0]["U_YoneticiAciklama"].ToString();
            }
        }

        private void dtgCIP1Load()
        {
            //string sql = "Select \"U_KontrolAdi\" as \"Kontrol Noktası Adı\",T1.\"U_Deger\" as \"Değer\",T1.\"U_DegerKod\" as \"DeğerKod\" from \"@AIF_TEMIZLIK\" as T0 INNER JOIN \"@AIF_TEMIZLIK1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where Convert(varchar,T0.\"U_Tarih\",112) = '" + tarih1 + "' and \"U_IstasyonKodu\"='" + istasyon + "'";

            //cmd = new SqlCommand(sql, Connection.sql);

            //if (Connection.sql.State != ConnectionState.Open)
            //    Connection.sql.Open();

            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //DataTable dttemp = new DataTable();
            //sda.Fill(dtCIP);

            //if (dtCIP.Rows.Count == 0)
            //{
            //    sql = "SELECT \"U_KontrolAdi\" as \"Kontrol Noktası Adı\",'' as \"Değer\",T1.\"U_Deger\" as \"DeğerKod\" FROM \"@AIF_CIP1\" AS T0 INNER JOIN \"@AIF_CIP1_1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_IstasyonKodu\" = '" + istasyon + "'";

            //    cmd = new SqlCommand(sql, Connection.sql);

            //    if (Connection.sql.State != ConnectionState.Open)
            //        Connection.sql.Open();

            //    sda = new SqlDataAdapter(cmd);
            //    dt = new DataTable();
            //    sda.Fill(dtCIP);
            //}

            ////Commit
            ////dtCIP.Columns.Add("Deger", typeof(string));
            //dtgCIP1.DataSource = dtCIP;
            ////dtgCIP1.Columns["Deger"].HeaderText = "Değer Kodu";

            //dtgCIP1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //dtgCIP1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            //dtgCIP1.EnableHeadersVisualStyles = false;
            //dtgCIP1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            ////dtgCIP1.Columns["Deger"].ReadOnly = true;

            //dtgCIP1.Columns["DeğerKod"].Visible = false;

            //vScrollBar1.Maximum = dtgCIP1.RowCount + 5;
        }

        private void dtgCIP2Load()
        {
            DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));

            string sql = "Select \"U_KontrolAdi\" as \"CIP Temizliği Yapılan Makine Alet-Hat-Ekipman\",\"U_AlkaliBasSaat\" as \"Alkali Başlangıç Saati\",cast(\"U_AlkaliSc\" as decimal(15,2)) as \"Alkali Sıcaklığı\",cast(\"U_AlkaliKonMs\" as decimal(15,2)) as \"Alkali Ms\",cast(\"U_AlkaliKonYuzde\" as decimal(15,2)) as \"Alkali Kontrol(%)\",\"U_AlkaliBitSaat\" as \"Alkali Bitiş Saati\",\"U_AsitBasSaat\" as \"Asit Başlangıç Saati\",cast(\"U_AsitSc\" as decimal(15,2)) as \"Asit Sıcaklığı\",cast(\"U_AsitKonMs\" as decimal(15,2)) as \"Asit Kontrol Ms\",cast(\"U_AsitKonYuzde\" as decimal(15,2)) as \"Asit Kontrol(%)\",\"U_AsitBitSaat\" as \"Asit Bitiş Saati\",\"U_TemizlikPers\" as \"Temizlik Personeli\",cast(\"U_OzonitKontrol\" as varchar(150)) as \"Ozonit Kontrol Personel\",cast(\"U_DurulamaPh\" as decimal(15,2)) as \"Durulama PH\",\"U_DezenPrsnl\" as \"Dezenfekte Eden Personel\",cast(\"U_HaslamaSc\" as decimal(15,2)) as \"Haşlama Sıcaklığı\",\"U_HaslamaPrsnl\" as \"Haşlama Personeli\",\"U_KontrolPersonel\" as \"Kontrol Eden Personel\", T1.\"U_Yapildi\" as \"Yapıldı\", T1.\"U_Yapilmadi\" as \"Yapılmadı\" from \"@AIF_TEMIZLIK\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_TEMIZLIK2\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where Convert(varchar,T0.\"U_Tarih\",112) = '" + dtTarih.ToString("yyyyMMdd") + "' and \"U_IstasyonKodu\"='" + istasyon + "'";

            //
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtCIP2);

            #region sql connection chn 
            Connection.sql.Close();
            Connection.sql.Dispose();
            if (Connection.sql.State == ConnectionState.Open)
            {
                cmd.ExecuteNonQuery();
            }
            #endregion
            dtCheckbox = dtCIP2.Copy();

            if (dtCIP2.Rows.Count == 0)
            {
                DataTable dt_Veriler = new DataTable();
                sql = "SELECT \"U_KontrolAdi\" as \"CIP Temizliği Yapılan Makine Alet-Hat-Ekipman\" FROM \"@AIF_CIP2\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_CIP2_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_IstasyonKodu\" = '" + istasyon + "'";

                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt_Veriler);

                #region sql connection chn 
                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
                #endregion

                foreach (DataRow item in dt_Veriler.Rows)
                {
                    DataRow dr = dtCIP2.NewRow();
                    dr["CIP Temizliği Yapılan Makine Alet-Hat-Ekipman"] = item["CIP Temizliği Yapılan Makine Alet-Hat-Ekipman"];
                    dtCIP2.Rows.Add(dr);
                }

                //dtCIP2.Columns.Add("AlkaliBasSaat", typeof(string));
                //dtCIP2.Columns.Add("AlkaliBasSaat", typeof(string));
                //dtCIP2.Columns.Add("AlkaliBasSaat", typeof(string));
                //dtCIP2.Columns.Add("AlkaliBasSaat", typeof(string));
                //dtCIP2.Columns.Add("AlkaliBasSaat", typeof(string));
                //dtCIP2.Columns.Add("AlkaliBasSaat", typeof(string));
            }

            //Commit
            dtgCIP2.DataSource = dtCIP2;

            dtgCIP2.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            //if (dtCIP2.Rows.Count > 0)
            //{
            Checkboxolustur();
            //}

            int i = 0;
            foreach (DataRow dr in dtCheckbox.Rows)
            {
                DataGridViewRow row = dtgCIP2.Rows[i];
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Ok"];
                DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)row.Cells["NotOk"];
                chk.Value = dr["Yapıldı"].ToString() == "Y" ? chk.TrueValue : chk.FalseValue;
                chk2.Value = dr["Yapılmadı"].ToString() == "Y" ? chk2.TrueValue : chk2.FalseValue;
                dtgCIP2.EndEdit();
                i++;
            }

            dtgCIP2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgCIP2.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgCIP2.EnableHeadersVisualStyles = false;
            dtgCIP2.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            vScrollBar2.Maximum = dtgCIP2.RowCount + 5;

            if (dtgCIP2.Columns.Contains("Yapıldı") == true)
            {
                dtgCIP2.Columns["Yapıldı"].Visible = false;
            }

            if (dtgCIP2.Columns.Contains("Yapılmadı") == true)
            {
                dtgCIP2.Columns["Yapılmadı"].Visible = false;
            }
        }

        private void dtgAletEkipmanTemizlikLoad()
        {
            DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));

            string sql = "Select \"U_AlanMakine\" as \"Temizlenen Alan Makine\", T1.\"U_YapilmaSikligi\" as \"Temizlik Yapılma Sıklığı\", T1.\"U_KimyasalAdi\" as \"Kullanılan Kimyasal Adı\", T1.\"U_KimyasalMiktari\" as \"Kullanılan Kimyasal Miktarı\", T1.\"U_KontrolYapildi\" as \"Temizlik Kontrol Yapıldı\", T1.\"U_KontrolYapilmadi\" as \"Temizlik Kontrol Yapılmadı\", T1.\"U_TemizlikYapanPrsnl\" as \"Temizlik Yapan Personel\", T1.\"U_TemizlikKontPrsnl\" as \"Temizlik Kontrol Eden Personel\" from \"@AIF_TEMIZLIK\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_TEMIZLIK3\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where Convert(varchar,T0.\"U_Tarih\",112) = '" + dtTarih.ToString("yyyyMMdd") + "' and \"U_IstasyonKodu\"='" + istasyon + "'";

            //
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            #region sql connection chn 
            Connection.sql.Close();
            Connection.sql.Dispose();
            if (Connection.sql.State == ConnectionState.Open)
            {
                cmd.ExecuteNonQuery();
            }
            #endregion

            dtCheckbox2 = dt.Copy();

            if (dt.Rows.Count == 0)
            {
                sql = "SELECT T1.\"U_AlanMakine\" as \"Temizlenen Alan Makine\", T1.\"U_TemizlikSikligi\" as \"Temizlik Yapılma Sıklığı\",T1.\"U_KimyasalAdi\" as \"Kullanılan Kimyasal Adı\",T1.\"U_KimyasalMiktar\" as \"Kullanılan Kimyasal Miktarı\"  FROM \"@AIF_AET\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_AET1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_IstasyonKodu\" = '" + istasyon + "'";

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

                //dt.Columns.Add("Kullanılan Kimyasal Adı", typeof(string));
                //dt.Columns.Add("Kullanılan Kimyasal Miktarı", typeof(double));
                //dt.Columns.Add("Temizlik Yapan Personel", typeof(string));
                //dt.Columns.Add("Temizlik Kontrol Eden Personel", typeof(string));
            }
            //Commit
            dtgAletEkipmanTemizlik.DataSource = dt;

            //if (dt.Rows.Count > 0)
            //{
            Checkboxolustur2();
            //}
            vScrollBar3.Maximum = dtgAletEkipmanTemizlik.RowCount + 5;

            dtAletEkipman = dt;
            dtCheckbox = dt.Copy();

            dtgAletEkipmanTemizlik.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgAletEkipmanTemizlik.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgAletEkipmanTemizlik.EnableHeadersVisualStyles = false;
            dtgAletEkipmanTemizlik.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            dtgAletEkipmanTemizlik.Columns["Temizlenen Alan Makine"].DisplayIndex = 0;
            dtgAletEkipmanTemizlik.Columns["Temizlik Yapılma Sıklığı"].DisplayIndex = 1;
            dtgAletEkipmanTemizlik.Columns["Kullanılan Kimyasal Adı"].DisplayIndex = 2;
            dtgAletEkipmanTemizlik.Columns["Kullanılan Kimyasal Miktarı"].DisplayIndex = 3;
            dtgAletEkipmanTemizlik.Columns["Temizlik Kontrol Yapıldı"].DisplayIndex = 4;
            dtgAletEkipmanTemizlik.Columns["Temizlik Kontrol Yapılmadı"].DisplayIndex = 5;
            dtgAletEkipmanTemizlik.Columns["Temizlik Yapan Personel"].DisplayIndex = 6;
            dtgAletEkipmanTemizlik.Columns["Temizlik Kontrol Eden Personel"].DisplayIndex = 7;

            dtgAletEkipmanTemizlik.Columns["Kullanılan Kimyasal Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgAletEkipmanTemizlik.Columns["Kullanılan Kimyasal Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            int i = 0;
            foreach (DataRow dr in dtCheckbox.Rows)
            {
                DataGridViewRow row = dtgAletEkipmanTemizlik.Rows[i];
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Ok"];
                DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)row.Cells["NotOk"];
                chk.Value = dr["Temizlik Kontrol Yapıldı"].ToString() == "Y" ? chk.TrueValue : chk.FalseValue;
                chk2.Value = dr["Temizlik Kontrol Yapılmadı"].ToString() == "Y" ? chk2.TrueValue : chk2.FalseValue;
                dtgAletEkipmanTemizlik.EndEdit();
                i++;
            }

            dtgAletEkipmanTemizlik.Columns["Temizlik Kontrol Yapıldı"].Visible = false;
            dtgAletEkipmanTemizlik.Columns["Temizlik Kontrol Yapılmadı"].Visible = false;

            dtgAletEkipmanTemizlik.Columns["Temizlenen Alan Makine"].Width = dtgAletEkipmanTemizlik.Columns["Temizlenen Alan Makine"].Width + 150;

            dtgAletEkipmanTemizlik.Columns["Temizlenen Alan Makine"].ReadOnly = true;
            dtgAletEkipmanTemizlik.Columns["Temizlik Yapılma Sıklığı"].ReadOnly = true;
            dtgAletEkipmanTemizlik.Columns["Temizlik Yapan Personel"].ReadOnly = true;
            dtgAletEkipmanTemizlik.Columns["Temizlik Kontrol Eden Personel"].ReadOnly = true;
        }
         
        private void Checkboxolustur()
        {
            checkColumn = new DataGridViewCheckBoxColumn();

            checkColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkColumn.CellTemplate = new DataGridViewCheckBoxCell();
            checkColumn.FalseValue = true;
            checkColumn.HeaderText = "Yapıldı";
            checkColumn.Name = "Ok";
            checkColumn.TrueValue = true;
            checkColumn.FalseValue = false;
            dtgCIP2.Columns.Add(checkColumn);

            checkColumn2 = new DataGridViewCheckBoxColumn();

            checkColumn2.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkColumn2.CellTemplate = new DataGridViewCheckBoxCell();
            checkColumn2.FalseValue = true;
            checkColumn2.HeaderText = "Yapılmadı";
            checkColumn2.Name = "NotOk";
            checkColumn2.TrueValue = true;
            checkColumn2.FalseValue = false;
            dtgCIP2.Columns.Add(checkColumn2);
        }

        private void Checkboxolustur2()
        {
            checkColumn3 = new DataGridViewCheckBoxColumn();

            checkColumn3.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkColumn3.CellTemplate = new DataGridViewCheckBoxCell();
            checkColumn3.FalseValue = true;
            checkColumn3.HeaderText = "Temizlik Kontrol Yapıldı";
            checkColumn3.Name = "Ok";
            checkColumn3.TrueValue = true;
            checkColumn3.FalseValue = false;
            dtgAletEkipmanTemizlik.Columns.Add(checkColumn3);

            checkColumn4 = new DataGridViewCheckBoxColumn();

            checkColumn4.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkColumn4.CellTemplate = new DataGridViewCheckBoxCell();
            checkColumn4.FalseValue = true;
            checkColumn4.HeaderText = "Temizlik Kontrol Yapılmadı";
            checkColumn4.Name = "NotOk";
            checkColumn4.TrueValue = true;
            checkColumn4.FalseValue = false;
            dtgAletEkipmanTemizlik.Columns.Add(checkColumn4);
        }

        private void dtgCIP1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgCIP1.Columns[e.ColumnIndex].Name == "Değer")
                {
                    var val = dtgCIP1.Rows[e.RowIndex].Cells["DeğerKod"].Value.ToString();

                    if (val == "2")
                    {
                        SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgCIP1);
                        n.ShowDialog();
                    }
                    else if (val == "1")
                    {
                        if (istasyon.StartsWith("IST"))
                        {
                            //string sql = "Select \"empID\" as \"Kullanıcı Kodu\", (\"firstName\" + ' ' + \"lastName\") as 'Ad Soyad' from OHEM where \"Active\" = 'Y'";

                            string field = "U_" + istasyon;

                            DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                            string gunfield = "U_Gun" + dtTarih.Day;
                            string sql = "";

                            #region Günlük Personel Planlama 2 ekranı

                            sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + istasyon.Replace("U_", "") + "' or T1.\"U_Bolum2\" = '" + istasyon.Replace("U_", "") + "' or T1.\"U_Bolum3\" = '" + istasyon.Replace("U_", "") + "') and " + gunfield + " = 'X' ";

                            if (AtanmisIsler.Joker)
                            {
                                sql += " UNION ALL ";

                                sql += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                            }

                            #endregion Günlük Personel Planlama 2 ekranı

                            #region Günlük Personel Planlama 1 ekranı

                            //string sql = "Select \"U_PersonelNo\" as \"Personel No\",\"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"" + field + "\" = 'Y'";

                            #endregion Günlük Personel Planlama 1 ekranı

                            #region Günlük Personel Planlama 3 ekranı

                            //sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                            //sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" =  '" + istasyon.Replace("U_", "") + "' or T1.\"U_Bolum2\" =  '" + istasyon.Replace("U_", "") + "' or T1.\"U_Bolum3\" =  '" + istasyon.Replace("U_", "") + "') and \"U_Durum\" = 'X'";

                            //if (AtanmisIsler.Joker)
                            //{
                            //    sql += " UNION ALL ";

                            //    sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                            //    sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') and \"U_Durum\" = 'X'";
                            //}

                            #endregion Günlük Personel Planlama 3 ekranı

                            SelectList selectList = new SelectList(sql, dtgCIP1, -1, 1, _autoresizerow: false);
                            selectList.ShowDialog();

                            //dtgCIP1.AutoResizeRows();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtgCIP2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].Name == "Ok")
                {
                    DataGridViewRow row = dtgCIP2.Rows[e.RowIndex];
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Ok"];
                    DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)row.Cells["NotOk"];
                    if (chk.Value == chk.FalseValue || chk.Value == null)
                    {
                        chk.Value = chk.TrueValue;
                        chk2.Value = chk2.FalseValue;
                        //dtCIP2.Rows[e.RowIndex]["Ok"] = "Y";
                        //dtCIP2.Rows[e.RowIndex]["NotOk"] = "N";
                    }
                    else
                    {
                        chk.Value = chk.FalseValue;
                        //dtCIP2.Rows[e.RowIndex][""] = "N";
                    }
                    dtgCIP2.EndEdit();
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "NotOk")
                {
                    DataGridViewRow row = dtgCIP2.Rows[e.RowIndex];
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["NotOk"];
                    DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)row.Cells["Ok"];
                    if (chk.Value == chk.FalseValue || chk.Value == null)
                    {
                        chk.Value = chk.TrueValue;
                        chk2.Value = chk2.FalseValue;

                        //dtCIP2.Rows[e.RowIndex]["Yapılmadı"] = "Y";
                        //dtCIP2.Rows[e.RowIndex]["Yapıldı"] = "N";
                    }
                    else
                    {
                        chk.Value = chk.FalseValue;
                        //dtCIP2.Rows[e.RowIndex]["Yapılmadı"] = "N";
                    }
                    dtgCIP2.EndEdit();
                }
            }
            else if (dtgCIP2.Columns[e.ColumnIndex].Name == "Alkali Sıcaklığı" || dtgCIP2.Columns[e.ColumnIndex].Name == "Alkali Ms" || dtgCIP2.Columns[e.ColumnIndex].Name == "Alkali Kontrol(%)" || dtgCIP2.Columns[e.ColumnIndex].Name == "Asit Sıcaklığı" || dtgCIP2.Columns[e.ColumnIndex].Name == "Asit Kontrol Ms" || dtgCIP2.Columns[e.ColumnIndex].Name == "Asit Kontrol(%)" || dtgCIP2.Columns[e.ColumnIndex].Name == "Asit Kontrol(%)" || dtgCIP2.Columns[e.ColumnIndex].Name == "Durulama PH" || dtgCIP2.Columns[e.ColumnIndex].Name == "Haşlama Sıcaklığı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgCIP2, false);
                n.ShowDialog();
            }
            else if (dtgCIP2.Columns[e.ColumnIndex].Name == "Alkali Başlangıç Saati" || dtgCIP2.Columns[e.ColumnIndex].Name == "Alkali Bitiş Saati" || dtgCIP2.Columns[e.ColumnIndex].Name == "Asit Başlangıç Saati" || dtgCIP2.Columns[e.ColumnIndex].Name == "Asit Bitiş Saati")
            {
                SaatTarihGirisi n = new SaatTarihGirisi(dtgCIP2);
                n.ShowDialog();
            }
            else if (dtgCIP2.Columns[e.ColumnIndex].Name == "Temizlik Personeli" || dtgCIP2.Columns[e.ColumnIndex].Name == "Ozonit Kontrol Personel" || dtgCIP2.Columns[e.ColumnIndex].Name == "Dezenfekte Eden Personel" || dtgCIP2.Columns[e.ColumnIndex].Name == "Haşlama Personeli" || dtgCIP2.Columns[e.ColumnIndex].Name == "Kontrol Eden Personel")
            {
                if (istasyon.StartsWith("IST"))
                {
                    //string sql = "Select \"empID\" as \"Kullanıcı Kodu\", (\"firstName\" + ' ' + \"lastName\") as 'Ad Soyad' from OHEM where \"Active\" = 'Y'";

                    string field = "U_" + istasyon;

                    DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                    string gunfield = "U_Gun" + dtTarih.Day;
                    string sql = "";

                    #region Günlük Personel Planlama 2 ekranı

                    sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + istasyon.Replace("U_", "") + "' or T1.\"U_Bolum2\" = '" + istasyon.Replace("U_", "") + "' or T1.\"U_Bolum3\" = '" + istasyon.Replace("U_", "") + "') and " + gunfield + " = 'X' ";

                    if (AtanmisIsler.Joker)
                    {
                        sql += " UNION ALL ";

                        sql += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                    }

                    #endregion Günlük Personel Planlama 2 ekranı

                    SelectList selectList = new SelectList(sql, dtgCIP2, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();

                    //dtgCIP1.AutoResizeRows();
                }
            }
        }

        private void dtgCIP2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dtgAletEkipmanTemizlik_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewCheckBoxColumn &&
                e.RowIndex >= 0)
            {
                if (senderGrid.Columns[e.ColumnIndex].Name == "Ok")
                {
                    DataGridViewRow row = dtgAletEkipmanTemizlik.Rows[e.RowIndex];
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["Ok"];
                    DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)row.Cells["NotOk"];
                    if (chk.Value == chk.FalseValue || chk.Value == null)
                    {
                        chk.Value = chk.TrueValue;
                        chk2.Value = chk2.FalseValue;
                        //dtCIP2.Rows[e.RowIndex]["Ok"] = "Y";
                        //dtCIP2.Rows[e.RowIndex]["NotOk"] = "N";
                    }
                    else
                    {
                        chk.Value = chk.FalseValue;
                        //dtCIP2.Rows[e.RowIndex][""] = "N";
                    }
                    dtgAletEkipmanTemizlik.EndEdit();
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "NotOk")
                {
                    DataGridViewRow row = dtgAletEkipmanTemizlik.Rows[e.RowIndex];
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells["NotOk"];
                    DataGridViewCheckBoxCell chk2 = (DataGridViewCheckBoxCell)row.Cells["Ok"];
                    if (chk.Value == chk.FalseValue || chk.Value == null)
                    {
                        chk.Value = chk.TrueValue;
                        chk2.Value = chk2.FalseValue;

                        //dtCIP2.Rows[e.RowIndex]["Yapılmadı"] = "Y";
                        //dtCIP2.Rows[e.RowIndex]["Yapıldı"] = "N";
                    }
                    else
                    {
                        chk.Value = chk.FalseValue;
                        //dtCIP2.Rows[e.RowIndex]["Yapılmadı"] = "N";
                    }
                    dtgAletEkipmanTemizlik.EndEdit();
                }
            }
            else if (dtgAletEkipmanTemizlik.Columns[e.ColumnIndex].Name == "Temizlik Yapan Personel" || dtgAletEkipmanTemizlik.Columns[e.ColumnIndex].Name == "Temizlik Kontrol Eden Personel")
            {
                if (istasyon.StartsWith("IST"))
                {
                    //string sql = "Select \"empID\" as \"Kullanıcı Kodu\", (\"firstName\" + ' ' + \"lastName\") as 'Ad Soyad' from OHEM where \"Active\" = 'Y'";
                    //int column = dtgAletEkipmanTemizlik.Columns[e.ColumnIndex].Name == "Temizlik Yapan Personel" ? 6 : 7;
                    string field = "U_" + istasyon;

                    DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                    string gunfield = "U_Gun" + dtTarih.Day;

                    string sql = "";

                    #region Günlük Personel Planlama 2 ekranı

                    sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + istasyon.Replace("U_", "") + "' or T1.\"U_Bolum2\" = '" + istasyon.Replace("U_", "") + "' or T1.\"U_Bolum3\" = '" + istasyon.Replace("U_", "") + "') and " + gunfield + " = 'X' ";

                    if (AtanmisIsler.Joker)
                    {
                        sql += " UNION ALL ";

                        sql += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                    }

                    #endregion Günlük Personel Planlama 2 ekranı

                    #region Günlük Personel Planlama 1 ekranı

                    //string sql = "Select \"U_PersonelNo\" as \"Personel No\",\"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"" + field + "\" = 'Y'";

                    #endregion Günlük Personel Planlama 1 ekranı

                    #region Günlük Personel Planlama 3 ekranı

                    //sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                    //sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" =  '" + istasyon.Replace("U_", "") + "' or T1.\"U_Bolum2\" =  '" + istasyon.Replace("U_", "") + "' or T1.\"U_Bolum3\" =  '" + istasyon.Replace("U_", "") + "') and \"U_Durum\" = 'X'";

                    //if (AtanmisIsler.Joker)
                    //{
                    //    sql += " UNION ALL ";

                    //    sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                    //    sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') and \"U_Durum\" = 'X'";
                    //}

                    #endregion Günlük Personel Planlama 3 ekranı

                    SelectList selectList = new SelectList(sql, dtgAletEkipmanTemizlik, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();

                    //dtgAletEkipmanTemizlik.AutoResizeRows();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient UVTServiceSoapClient = new UVTServiceSoapClient();
                AnalizTemizlik nesne = new AnalizTemizlik();
                //CIP1 cIP1 = new CIP1();
                //List<CIP1> cIP1s = new List<CIP1>();
                CIP2 cIP2 = new CIP2();
                List<CIP2> cIP2s = new List<CIP2>();
                AletEkipmanTemizlik aletEkipmanTemizlik = new AletEkipmanTemizlik();
                List<AletEkipmanTemizlik> aletEkipmanTemizliks = new List<AletEkipmanTemizlik>();
                DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));

                nesne.IstasyonKodu = istasyon;
                nesne.IstasyonTanimi = "";
                nesne.Tarih = dtTarih.ToString("yyyyMMdd");
                //foreach (DataGridViewRow dr in dtgCIP1.Rows)
                //{
                //    cIP1 = new CIP1();

                //    cIP1.KontrolNoktasiAdi = dr.Cells["Kontrol Noktası Adı"].Value == DBNull.Value ? "" : dr.Cells["Kontrol Noktası Adı"].Value.ToString();
                //    //cIP1.Deger = dr.Cells["DeğerKod"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Paketleme Öncesi Ürün Sıcaklığı"].Value);
                //    cIP1.DegerKod = dr.Cells["DeğerKod"].Value == DBNull.Value ? "" : dr.Cells["DeğerKod"].Value.ToString();
                //    cIP1.Deger = dr.Cells["Değer"].Value == DBNull.Value ? "" : dr.Cells["Değer"].Value.ToString();

                //    cIP1s.Add(cIP1);
                //}

                //nesne.cIP1s = cIP1s.ToArray();

                foreach (DataGridViewRow dr in dtgCIP2.Rows)
                {
                    cIP2 = new CIP2();

                    cIP2.KontrolNoktasiAdi = dr.Cells["CIP Temizliği Yapılan Makine Alet-Hat-Ekipman"].Value == DBNull.Value ? "" : dr.Cells["CIP Temizliği Yapılan Makine Alet-Hat-Ekipman"].Value.ToString();
                    //cIP1.Deger = dr.Cells["Değer"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Paketleme Öncesi Ürün Sıcaklığı"].Value);

                    cIP2.AlkaliBasSaat = dr.Cells["Alkali Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Alkali Başlangıç Saati"].Value.ToString();
                    cIP2.AlkaliSc = dr.Cells["Alkali Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Alkali Sıcaklığı"].Value);
                    cIP2.AlkaliKonMs = dr.Cells["Alkali Ms"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Alkali Ms"].Value);
                    cIP2.AlkaliKonYuzde = dr.Cells["Alkali Kontrol(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Alkali Kontrol(%)"].Value);
                    cIP2.AlkaliBitSaat = dr.Cells["Alkali Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Alkali Bitiş Saati"].Value.ToString();
                    cIP2.AsitBasSaat = dr.Cells["Asit Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Asit Başlangıç Saati"].Value.ToString();
                    cIP2.AsitSc = dr.Cells["Asit Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Asit Sıcaklığı"].Value);
                    cIP2.AsitKonMs = dr.Cells["Asit Kontrol Ms"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Asit Kontrol Ms"].Value);
                    cIP2.AsitKonYuzde = dr.Cells["Asit Kontrol(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Asit Kontrol(%)"].Value);
                    cIP2.AsitBitSaat = dr.Cells["Asit Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Asit Bitiş Saati"].Value.ToString();
                    cIP2.TemizlikPers = dr.Cells["Temizlik Personeli"].Value == DBNull.Value ? "" : dr.Cells["Temizlik Personeli"].Value.ToString();
                    cIP2.OzonitKontrol = dr.Cells["Ozonit Kontrol Personel"].Value == DBNull.Value ? "" : dr.Cells["Ozonit Kontrol Personel"].Value.ToString();
                    cIP2.DurulamaPh = dr.Cells["Durulama PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Durulama PH"].Value);
                    cIP2.DezenPrsnl = dr.Cells["Dezenfekte Eden Personel"].Value == DBNull.Value ? "" : dr.Cells["Dezenfekte Eden Personel"].Value.ToString();
                    cIP2.HaslamaSc = dr.Cells["Haşlama Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Haşlama Sıcaklığı"].Value);
                    cIP2.HaslamaPrsnl = dr.Cells["Haşlama Personeli"].Value == DBNull.Value ? "" : dr.Cells["Haşlama Personeli"].Value.ToString();
                    cIP2.KontrolPersonel = dr.Cells["Kontrol Eden Personel"].Value == DBNull.Value ? "" : dr.Cells["Kontrol Eden Personel"].Value.ToString();

                    if (dr.Cells["Ok"].Value == null)
                    {
                        cIP2.Yapildi = "N";
                    }
                    else if (dr.Cells["Ok"].Value.ToString() == "True")
                    {
                        cIP2.Yapildi = "Y";
                    }
                    else
                    {
                        cIP2.Yapildi = "N";
                    }

                    if (dr.Cells["NotOk"].Value == null)
                    {
                        cIP2.Yapilmadi = "N";
                    }
                    else if (dr.Cells["NotOk"].Value.ToString() == "True")
                    {
                        cIP2.Yapilmadi = "Y";
                    }
                    else
                    {
                        cIP2.Yapilmadi = "N";
                    }

                    cIP2s.Add(cIP2);
                }

                nesne.cIP2s = cIP2s.ToArray();

                foreach (DataGridViewRow dr in dtgAletEkipmanTemizlik.Rows)
                {
                    aletEkipmanTemizlik = new AletEkipmanTemizlik();

                    aletEkipmanTemizlik.TemizlenenAlanMakine = dr.Cells["Temizlenen Alan Makine"].Value == DBNull.Value ? "" : dr.Cells["Temizlenen Alan Makine"].Value.ToString();
                    aletEkipmanTemizlik.TemizlikYapilmaSikligi = dr.Cells["Temizlik Yapılma Sıklığı"].Value == DBNull.Value ? "" : dr.Cells["Temizlik Yapılma Sıklığı"].Value.ToString();
                    aletEkipmanTemizlik.KullanilanKimysalAdi = dr.Cells["Kullanılan Kimyasal Adı"].Value == DBNull.Value ? "" : dr.Cells["Kullanılan Kimyasal Adı"].Value.ToString();
                    aletEkipmanTemizlik.KullanilanKimysalMiktar = dr.Cells["Kullanılan Kimyasal Miktarı"].Value == DBNull.Value ? "" : dr.Cells["Kullanılan Kimyasal Miktarı"].Value.ToString();

                    if (dr.Cells["Ok"].Value == null)
                    {
                        aletEkipmanTemizlik.TemizlikYapildi = "N";
                    }
                    else if (dr.Cells["Ok"].Value.ToString() == "True")
                    {
                        aletEkipmanTemizlik.TemizlikYapildi = "Y";
                    }
                    else
                    {
                        aletEkipmanTemizlik.TemizlikYapildi = "N";
                    }

                    if (dr.Cells["NotOk"].Value == null)
                    {
                        aletEkipmanTemizlik.TemizlikYapilmadi = "N";
                    }
                    else if (dr.Cells["NotOk"].Value.ToString() == "True")
                    {
                        aletEkipmanTemizlik.TemizlikYapilmadi = "Y";
                    }
                    else
                    {
                        aletEkipmanTemizlik.TemizlikYapilmadi = "N";
                    }

                    aletEkipmanTemizlik.TemizlikYapanPersonel = dr.Cells["Temizlik Yapan Personel"].Value == DBNull.Value ? "" : dr.Cells["Temizlik Yapan Personel"].Value.ToString();
                    aletEkipmanTemizlik.TemizlikKontrolEdenPersonel = dr.Cells["Temizlik Kontrol Eden Personel"].Value == DBNull.Value ? "" : dr.Cells["Temizlik Kontrol Eden Personel"].Value.ToString();

                    aletEkipmanTemizliks.Add(aletEkipmanTemizlik);
                }

                nesne.aletEkipmanTemizliks = aletEkipmanTemizliks.ToArray();

                var resp = UVTServiceSoapClient.AddOrUpdateTemizlik(nesne, Giris.dbName, Giris.mKodValue);

                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                btnOzetEkranaDon.PerformClick();
            }
            catch (Exception ex)
            {
            }
        }

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(istasyon, kullaniciid, row, initialWidth, initialHeight, tarih1,istasyonAdi);
            banaAitİsler.Show();
            Close();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgCIP1.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception ex)
            {
            }
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgCIP2.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception ex)
            {
            }
        }

        private void vScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dtgAletEkipmanTemizlik.FirstDisplayedScrollingRowIndex = e.NewValue + 2;
            }
            catch (Exception ex)
            {
            }
        }

        private void dtgCIP1_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void dtgCIP2_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                if (e.ScrollOrientation == ScrollOrientation.VerticalScroll)
                {
                    vScrollBar2.Value = e.NewValue;
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtgAletEkipmanTemizlik_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar3.Value = e.NewValue;
        }

        private void btnYoneticiOnay_Click(object sender, EventArgs e)
        {
            try
            {
                TemizlikYoneticiOnay temizlikYoneticiOnay = new TemizlikYoneticiOnay(kullaniciid, istasyon, tarih1);
                DialogResult dialogResult = temizlikYoneticiOnay.ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    btnOzetEkranaDon.PerformClick();
                }
                #region yönetici ekranına alındı
                //UVTServiceSoapClient UVTServiceSoapClient = new UVTServiceSoapClient();
                //AnalizTemizlik nesne = new AnalizTemizlik();

                //nesne.IstasyonKodu = istasyon;
                //nesne.IstasyonTanimi = "";
                //DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                //nesne.Tarih = dtTarih.ToString("yyyyMMdd");
                //nesne.YoneticiOnayi = "E";
                //nesne.YoneticiOnayTarihi = dtTarih.ToString("yyyyMMdd");

                //var resp = UVTServiceSoapClient.AddOrUpdateTemizlik(nesne, Giris.dbName, Giris.mKodValue);

                //CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                //btnOzetEkranaDon.PerformClick(); 
                #endregion
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show(ex.Message, "UYARI", "TAMAM");
            }
        }
    }
}
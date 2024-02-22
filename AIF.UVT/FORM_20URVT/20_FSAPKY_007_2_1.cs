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
    public partial class _20_FSAPKY_007_2_1 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_007_2_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
        {
            InitializeComponent();

            UretimFisNo = _UretimFisNo;
            partiNo = _PartiNo;
            UrunTanimi = _UrunTanimi;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;
            urunKodu = _urunKodu;
            #region Font
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;
            #endregion
        }
        private void Form_Resize(object sender, EventArgs e)
        {
            #region Font
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

            label8.Font = new Font(label8.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              label8.Font.Style);

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtUretimTarihi.Font.Style);

            txtUretimFisNo.Font = new Font(txtUretimFisNo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimFisNo.Font.Style);

            txtPartiNo.Font = new Font(txtPartiNo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtPartiNo.Font.Style);

            txtUrunTanimi.Font = new Font(txtUrunTanimi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUrunTanimi.Font.Style);

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOnayla.Font.Style);

            btnSagaGit.Font = new Font(btnSagaGit.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSagaGit.Font.Style);

            ResumeLayout();
            #endregion
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
        DataTable dataTable2 = new DataTable();


        private static string UretimFisNo = "";
        private static string UrunKodu = "";
        private static string partiNo = "";
        private string istasyon = "";
        private static string UrunTanimi = "";
        private static string urunKodu = "";
        private string type = "";
        private string kullaniciid = "";
        private static string tarih1 = "";
        private int row = 0;
        private SqlCommand cmd = null;

        DataTable dtgfSAPKY007_2_1_1_DataTable = new DataTable();
        DataTable dtgfSAPKY007_2_1_2_DataTable = new DataTable();
        DataTable dtgfSAPKY007_2_2_1_DataTable = new DataTable();
        DataTable dtgfSAPKY007_2_2_2_DataTable = new DataTable(); 

        public static Button btnOzet = null;
        //public static string digerKaliteKontroller = null;
        //public static string seciliAnaliz = null;

        private void _20_FSAPKY_007_2_1_Load(object sender, EventArgs e)
        {
            try
            {
                //digerKaliteKontroller = null;

                txtPartiNo.Text = partiNo;
                txtUretimFisNo.Text = UretimFisNo;
                txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                txtUrunTanimi.Text = UrunTanimi;
                btnOzet = btnOzetEkranaDon;


                #region Diğer kalite kontrol yapıldı mı sorgusu



                string sql = "SELECT \"U_DgrKltKontrol\" FROM \"@AIF_FSAPKY007_2_1\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dataTable1);


                if (dataTable1.Rows.Count > 0)
                {
                    txtKontrol1.Text = dataTable1.Rows[0][0].ToString(); 
                }
                else
                {
                    txtKontrol1.Text = "";
                }

                #endregion


                #region dataGridView1 

                datagridView1Load();

                //dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Başlangıç Saati", typeof(string));
                //dataTable1.Columns.Add("Pastorizasyon Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Pastorizasyon Çıkış", typeof(string));
                //dataTable1.Columns.Add("Holder Süresi", typeof(string));
                //dataTable1.Columns.Add("Homojenizasyon Basınç", typeof(string));
                //dataTable1.Columns.Add("Sulu Ayran Sütü Miktarı", typeof(string));
                //dataTable1.Columns.Add("Çekilen Krema Miktarı", typeof(string));
                //dataTable1.Columns.Add("Stand. Ayran Sütü Miktarı", typeof(string));
                //dataTable1.Columns.Add("Bitiş Saati", typeof(string));
                //dataTable1.Columns.Add("Operatör Adı", typeof(string));

                //dataTable1.Rows.Add("");
                //dataGridView1.DataSource = dataTable1;

                //dataGridView1.AllowUserToAddRows = false;
                //dataGridView1.AllowUserToDeleteRows = false;
                //dataGridView1.AllowUserToResizeColumns = false;
                //dataGridView1.AllowUserToResizeRows = false;
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 191, 143);
                //dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(220, 230, 241);

                //dataGridView1.EnableHeadersVisualStyles = false;
                //dataGridView1.RowHeadersVisible = false;

                //dataGridView1.ColumnHeadersHeight = 50;
                //dataGridView1.RowTemplate.Height = 40;

                //foreach (DataGridViewColumn column in dataGridView1.Columns)
                //{
                //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                //    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //    column.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                //}
                #endregion

                #region dataGridView2

                datagridView2Load();

                //dataTable2.Columns.Add("#", "#");
                //dataTable2.Columns.Add("Ayran Proses Tank No", typeof(string));
                //dataTable2.Columns.Add("Stand. Ayran Sütü Miktarı", typeof(string));
                //dataTable2.Columns.Add("Kültürleme Sıcaklığı", typeof(string));
                //dataTable2.Columns.Add("Kültürleme Saati", typeof(string));
                //dataTable2.Columns.Add("Kültürleme PH", typeof(string));
                //dataTable2.Columns.Add("Kırım Saati", typeof(string));
                //dataTable2.Columns.Add("Kırım PH", typeof(string));
                //dataTable2.Columns.Add("Kırım SH", typeof(string));
                //dataTable2.Columns.Add("Soğutma Eşanjörü Çıkış Sıcaklığı", typeof(string));
                //dataTable2.Columns.Add("Operatör Adı", typeof(string));

                //dataTable2.Rows.Add("");
                //dataTable2.Rows.Add("");
                //dataTable2.Rows.Add("");
                //dataTable2.Rows.Add("");
                //dataGridView2.DataSource = dataTable2;

                //dataGridView2.AllowUserToAddRows = false;
                //dataGridView2.AllowUserToDeleteRows = false;
                //dataGridView2.AllowUserToResizeColumns = false;
                //dataGridView2.AllowUserToResizeRows = false;
                //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(146, 208, 80);
                //dataGridView2.DefaultCellStyle.BackColor = Color.FromArgb(220, 230, 241);

                //dataGridView2.EnableHeadersVisualStyles = false;
                //dataGridView2.RowHeadersVisible = false;

                //dataGridView2.ColumnHeadersHeight = 50;
                //dataGridView2.RowTemplate.Height = 40;

                //foreach (DataGridViewColumn column in dataGridView2.Columns)
                //{
                //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                //    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //    column.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                //}
                #endregion

                #region Ikinci ekran 1,2 ve 3.gridlerin yüklenmesi

                datagridView1Load_IkinciEkran();
                datagridView2Load_IkinciEkran();

                #endregion

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
            //_20_ANALIZ_EKRANLARI _20_ANALIZ_EKRANLARI = new _20_ANALIZ_EKRANLARI();
            //_20_ANALIZ_EKRANLARI.Show();
            //Close();
        }

        private void btnSagaGit_Click(object sender, EventArgs e)
        {
            _20_FSAPKY_007_2_2 _20_FSAPKY_007_2_2 = new _20_FSAPKY_007_2_2(type, kullaniciid, UretimFisNo, partiNo, UrunTanimi, istasyon, row, tarih1, urunKodu, dtgfSAPKY007_2_1_1_DataTable, dtgfSAPKY007_2_1_2_DataTable, dtgfSAPKY007_2_2_1_DataTable, dtgfSAPKY007_2_2_2_DataTable, txtKontrol1);
            _20_FSAPKY_007_2_2.ShowDialog();


            if (_20_FSAPKY_007_2_2.geriDonme == "OzeteDon")
            {
                btnOzetEkranaDon.PerformClick();
            }

        }

        private void datagridView1Load()
        {
            string sql = "SELECT T1.\"U_BasSaati\" as \"Başlangıç Saati\",\"U_PastSic\" as \"Pastorizasyon Sıcaklığı\",T1.\"U_PastCikis\" as \"Pastorizasyon Çıkış\",\"U_HolderSur\" as \"Holder Süresi\",\"U_HmjBasinc\" as \"Homojenizasyon Basınç\",\"U_SuluSutMik\" as \"Sulu Ayran Sütü Miktarı\", \"U_CekKreMik\" as \"Çekilen Krema Miktarı\", \"U_StanSutMik\" as \"Stand. Ayran Sütü Miktarı\", \"U_BitisSaat\" as \"Bitiş Saati\", \"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY007_2_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY007_2_1_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY007_2_1_1_DataTable);

            //Commit
            dataGridView1.DataSource = dtgfSAPKY007_2_1_1_DataTable;

            dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 191, 143);
            dataGridView1.DefaultCellStyle.BackColor = Color.WhiteSmoke;

            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.RowHeadersVisible = false;

            dataGridView1.ColumnHeadersHeight = 50;
            dataGridView1.RowTemplate.Height = 40;

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            if (dtgfSAPKY007_2_1_1_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY007_2_1_1_DataTable.NewRow();
                dr["Başlangıç Saati"] = "";
                dr["Pastorizasyon Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Pastorizasyon Çıkış"] = Convert.ToString("0", cultureTR);
                dr["Holder Süresi"] = Convert.ToString("0", cultureTR);
                dr["Homojenizasyon Basınç"] = Convert.ToString("0", cultureTR);
                dr["Sulu Ayran Sütü Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Çekilen Krema Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Stand. Ayran Sütü Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Bitiş Saati"] = "";
                dr["Operatör Adı"] = "";

                dtgfSAPKY007_2_1_1_DataTable.Rows.Add(dr);
            }
            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {
            string sql = "SELECT T1.\"U_ProsTnkNo\" as \"Ayran Proses Tank No\",\"U_AyrSutMik\" as \"Stand. Ayran Sütü Miktarı\",T1.\"U_KulturSic\" as \"Kültürleme Sıcaklığı\",\"U_KulturSaat\" as \"Kültürleme Saati\",\"U_KulturPH\" as \"Kültürleme PH\",\"U_KirimSaat\" as \"Kırım Saati\", \"U_KirimPH\" as \"Kırım PH\", \"U_KirimSH\" as \"Kırım SH\", \"U_SogCikSic\" as \"Soğutma Eşanjörü Çıkış Sıcaklığı\", \"U_LabPersAdi\" as \"Lab.Personel Adı\" FROM \"@AIF_FSAPKY007_2_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY007_2_1_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY007_2_1_2_DataTable);

            //Commit
            dataGridView2.DataSource = dtgfSAPKY007_2_1_2_DataTable;

            dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 191, 143);
            dataGridView2.DefaultCellStyle.BackColor = Color.WhiteSmoke;

            dataGridView2.EnableHeadersVisualStyles = false;
            dataGridView2.RowHeadersVisible = false;

            dataGridView2.ColumnHeadersHeight = 50;
            dataGridView2.RowTemplate.Height = 40;

            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }


            if (dtgfSAPKY007_2_1_2_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY007_2_1_2_DataTable.NewRow();
                dr["Ayran Proses Tank No"] = "";
                dr["Stand. Ayran Sütü Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Kültürleme Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Kültürleme Saati"] = "";
                dr["Kültürleme PH"] = Convert.ToString("0", cultureTR);
                dr["Kırım Saati"] = "";
                dr["Kırım PH"] = Convert.ToString("0", cultureTR);
                dr["Kırım SH"] = Convert.ToString("0", cultureTR);
                dr["Soğutma Eşanjörü Çıkış Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Lab.Personel Adı"] = "";

                dtgfSAPKY007_2_1_2_DataTable.Rows.Add(dr);
            }
            dataGridView2.Columns["Lab.Personel Adı"].ReadOnly = true;
        }
        private void datagridView1Load_IkinciEkran()
        {

            string sql = "SELECT T1.\"U_TankNo\" as \"Tank No\",\"U_PaletNo\" as \"Palet No\",T1.\"U_AnlzSaat1\" as \"1.Analiz(Saat)\",\"U_AnlzSaat2\" as \"2.Analiz(Saat)\",\"U_AnlzSaat3\" as \"3.Analiz(Saat)\",\"U_AnlzSaat4\" as \"4.Analiz(Saat)\", \"U_AnlzSaat5\" as \"5.Analiz(Saat)\", \"U_AnlzPH1\" as \"1.Analiz(PH)\", \"U_AnlzPH2\" as \"2.Analiz(PH)\", \"U_AnlzPH3\" as \"3.Analiz(PH)\", \"U_AnlzPH4\" as \"4.Analiz(PH)\", \"U_AnlzPH5\" as \"5.Analiz(PH)\", \"U_AnlzSic1\" as \"1.Analiz(SH)\" , \"U_AnlzSic2\" as \"2.Analiz(SH)\" , \"U_AnlzSic3\" as \"3.Analiz(SH)\" , \"U_AnlzSic4\" as \"4.Analiz(SH)\" , \"U_AnlzSic5\" as \"5.Analiz(SH)\" , \"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY007_2_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY007_2_2_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY007_2_2_1_DataTable);

            if (dtgfSAPKY007_2_2_1_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY007_2_2_1_DataTable.NewRow();
                dr["Tank No"] = "";
                dr["Palet No"] = "";
                dr["1.Analiz(Saat)"] = "";
                dr["2.Analiz(Saat)"] = "";
                dr["3.Analiz(Saat)"] = "";
                dr["4.Analiz(Saat)"] = "";
                dr["5.Analiz(Saat)"] = "";
                dr["1.Analiz(PH)"] = Convert.ToString("0", cultureTR);
                dr["2.Analiz(PH)"] = Convert.ToString("0", cultureTR);
                dr["3.Analiz(PH)"] = Convert.ToString("0", cultureTR);
                dr["4.Analiz(PH)"] = Convert.ToString("0", cultureTR);
                dr["5.Analiz(PH)"] = Convert.ToString("0", cultureTR);
                dr["1.Analiz(SH)"] = Convert.ToString("0", cultureTR);
                dr["2.Analiz(SH)"] = Convert.ToString("0", cultureTR);
                dr["3.Analiz(SH)"] = Convert.ToString("0", cultureTR);
                dr["4.Analiz(SH)"] = Convert.ToString("0", cultureTR);
                dr["5.Analiz(SH)"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";

                dtgfSAPKY007_2_2_1_DataTable.Rows.Add(dr);
            }
        }

        private void datagridView2Load_IkinciEkran()
        {

            string sql = "SELECT T1.\"U_TankNo\" as \"Tank No\",\"U_Saat\" as \"Saat\",T1.\"U_PH\" as \"PH\",\"U_PH\" as \"SH\",\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY007_2_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY007_2_2_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY007_2_2_2_DataTable);

            if (dtgfSAPKY007_2_2_2_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY007_2_2_2_DataTable.NewRow();
                dr["Tank No"] = "";
                dr["Saat"] = "";
                dr["PH"] = Convert.ToString("0", cultureTR);
                dr["SH"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";

                dtgfSAPKY007_2_2_2_DataTable.Rows.Add(dr);
            } 
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Pastorizasyon Sıcaklığı" || dataGridView1.Columns[e.ColumnIndex].Name == "Pastorizasyon Çıkış" || dataGridView1.Columns[e.ColumnIndex].Name == "Homojenizasyon Basınç" || dataGridView1.Columns[e.ColumnIndex].Name == "Holder Süresi" || dataGridView1.Columns[e.ColumnIndex].Name == "Sulu Ayran Sütü Miktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Çekilen Krema Miktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Stand. Ayran Sütü Miktarı")
            {
                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Başlangıç Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Bitiş Saati")
            {

                SaatTarihGirisi n = new SaatTarihGirisi(dataGridView1);
                n.ShowDialog();
            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Operatör Adı")
            {
                if (istasyon.StartsWith("20-"))
                {
                    DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                    string gunfield = "U_Gun" + dtTarih.Day;
                    string sql = "";

                    #region Günlük Personel Planlama 3 ekranı

                    sql = "SELECT TOP 1 '' AS \"Personel No\", '' AS \"Personel Adı\" FROM OCRD WITH (NOLOCK) UNION ALL SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                    sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and \"U_Durum\" = 'X'";

                    if (AtanmisIsler.Joker)
                    {
                        //sql += " UNION ALL ";

                        sql = "SELECT TOP 1 '' AS \"Personel No\", '' AS \"Personel Adı\" FROM OCRD WITH (NOLOCK) UNION ALL SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                        sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') and \"U_Durum\" = 'X'";
                    }

                    #endregion Günlük Personel Planlama 3 ekranı

                    SelectList selectList = new SelectList(sql, dataGridView1, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Ayran Proses Tank No")
            {

                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog(); 
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Stand. Ayran Sütü Miktarı" || dataGridView2.Columns[e.ColumnIndex].Name == "Kültürleme Sıcaklığı" || dataGridView2.Columns[e.ColumnIndex].Name == "Kültürleme PH" || dataGridView2.Columns[e.ColumnIndex].Name == "Kırım PH" || dataGridView2.Columns[e.ColumnIndex].Name == "Kırım SH" || dataGridView2.Columns[e.ColumnIndex].Name == "Soğutma Eşanjörü Çıkış Sıcaklığı")
            {
                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog();
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Kültürleme Saati" || dataGridView2.Columns[e.ColumnIndex].Name == "Kırım Saati")
            {
                //    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, true);
                //    //n.ShowDialog();

                SaatTarihGirisi n = new SaatTarihGirisi(dataGridView2);
                n.ShowDialog();
            }

            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Lab.Personel Adı")
            {
                if (istasyon.StartsWith("20-"))
                {
                    DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                    string gunfield = "U_Gun" + dtTarih.Day;
                    string sql = "";

                    #region Günlük Personel Planlama 3 ekranı

                    sql = "SELECT TOP 1 '' AS \"Personel No\", '' AS \"Personel Adı\" FROM OCRD UNION ALL SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                    sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and \"U_Durum\" = 'X'";

                    if (AtanmisIsler.Joker)
                    {
                        //sql += " UNION ALL ";

                        sql = "SELECT TOP 1 '' AS \"Personel No\", '' AS \"Personel Adı\" FROM OCRD WITH (NOLOCK) UNION ALL SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                        sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') and \"U_Durum\" = 'X'";
                    }

                    #endregion Günlük Personel Planlama 3 ekranı

                    SelectList selectList = new SelectList(sql, dataGridView2, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();
                }
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            partiNo = txtPartiNo.Text;
            UretimFisNo = txtUretimFisNo.Text;
            UrunTanimi = txtUrunTanimi.Text;
            //urunKodu = txt.Text;  
            tabloyaKaydetmeIslemleri();
        }

        public void tabloyaKaydetmeIslemleri()
        {

            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                FSAPKY007_2 nesne = new FSAPKY007_2();
                FSAPKY007_2_1_1 fSAPKY007_2_1_1 = new FSAPKY007_2_1_1();
                List<FSAPKY007_2_1_1> fSAPKY007_2_1_1s = new List<FSAPKY007_2_1_1>();
                FSAPKY007_2_1_2 fSAPKY007_2_1_2 = new FSAPKY007_2_1_2();
                List<FSAPKY007_2_1_2> fSAPKY007_2_1_2s = new List<FSAPKY007_2_1_2>();
                FSAPKY007_2_2_1 fSAPKY007_2_2_1 = new FSAPKY007_2_2_1();
                List<FSAPKY007_2_2_1> fSAPKY007_2_2_1s = new List<FSAPKY007_2_2_1>();
                FSAPKY007_2_2_2 fSAPKY007_2_2_2 = new FSAPKY007_2_2_2();
                List<FSAPKY007_2_2_2> fSAPKY007_2_2_2s = new List<FSAPKY007_2_2_2>();


                nesne.PartiNo = partiNo;
                nesne.UrunKodu = urunKodu;
                nesne.UrunTanimi = UrunTanimi;

                #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
                //nesne.Tarih = tarih1;
                DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                nesne.Tarih = uretimtarihi.ToString("yyyyMMdd");
                #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

                nesne.DigerKaliteKontroller = txtKontrol1.Text;

                foreach (DataRow dr in dtgfSAPKY007_2_1_1_DataTable.Rows)
                {
                    fSAPKY007_2_1_1 = new FSAPKY007_2_1_1();
                    fSAPKY007_2_1_1.BaslangicSaati = dr["Başlangıç Saati"] == DBNull.Value ? "" : dr["Başlangıç Saati"].ToString();
                    fSAPKY007_2_1_1.PastorizasyonSicakligi = dr["Pastorizasyon Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastorizasyon Sıcaklığı"]);
                    fSAPKY007_2_1_1.PastorizasyonCikis = dr["Pastorizasyon Çıkış"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastorizasyon Çıkış"]);
                    fSAPKY007_2_1_1.HolderSuresi = (dr["Holder Süresi"] == DBNull.Value || dr["Holder Süresi"].ToString() == "") ? 0 : Convert.ToInt32(dr["Holder Süresi"]);
                    fSAPKY007_2_1_1.HomojenizasyonBasinc = dr["Homojenizasyon Basınç"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Homojenizasyon Basınç"]);
                    fSAPKY007_2_1_1.SuluAyranSutuMiktari = dr["Sulu Ayran Sütü Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Sulu Ayran Sütü Miktarı"]);
                    fSAPKY007_2_1_1.CekilenKremaMiktari = dr["Çekilen Krema Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Çekilen Krema Miktarı"]);
                    fSAPKY007_2_1_1.StandartAyranSutuMiktari = dr["Stand. Ayran Sütü Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Stand. Ayran Sütü Miktarı"]);
                    fSAPKY007_2_1_1.BitisSaati = dr["Bitiş Saati"] == DBNull.Value ? "" : dr["Bitiş Saati"].ToString();
                    fSAPKY007_2_1_1.OperatorAdi = dr["Operatör Adı"] == DBNull.Value ? "" : dr["Operatör Adı"].ToString();

                    fSAPKY007_2_1_1s.Add(fSAPKY007_2_1_1);
                }

                nesne.fSAPKY007_2_1_1s = fSAPKY007_2_1_1s.ToArray();


                foreach (DataRow dr in dtgfSAPKY007_2_1_2_DataTable.Rows)
                {
                    fSAPKY007_2_1_2 = new FSAPKY007_2_1_2();
                    fSAPKY007_2_1_2.AyranProsessTankNo = dr["Ayran Proses Tank No"] == DBNull.Value ? "" : dr["Ayran Proses Tank No"].ToString();

                    if (fSAPKY007_2_1_2.AyranProsessTankNo == "")
                    {
                        continue;
                    }
                    fSAPKY007_2_1_2.StandartAyranSutuMiktari = dr["Stand. Ayran Sütü Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Stand. Ayran Sütü Miktarı"]);
                    fSAPKY007_2_1_2.KulturlemeSicakligi = (dr["Kültürleme Sıcaklığı"] == DBNull.Value || dr["Kültürleme Sıcaklığı"].ToString() == "") ? 0 : Convert.ToInt32(dr["Kültürleme Sıcaklığı"]);
                    fSAPKY007_2_1_2.KulturlemeSaati = dr["Kültürleme Saati"] == DBNull.Value ? "" : dr["Kültürleme Saati"].ToString();
                    fSAPKY007_2_1_2.KulturlemePH = dr["Kültürleme PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kültürleme PH"]);
                    fSAPKY007_2_1_2.KirimSaati = dr["Kırım Saati"] == DBNull.Value ? "" : dr["Kırım Saati"].ToString();
                    fSAPKY007_2_1_2.KirimPH = dr["Kırım PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kırım PH"]);
                    fSAPKY007_2_1_2.KirimSH = dr["Kırım SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kırım SH"]);
                    fSAPKY007_2_1_2.SogutmaEsanjoruCikisSicakligi = dr["Soğutma Eşanjörü Çıkış Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Soğutma Eşanjörü Çıkış Sıcaklığı"]);
                    fSAPKY007_2_1_2.LabPersonelAdi = dr["Lab.Personel Adı"] == DBNull.Value ? "" : dr["Lab.Personel Adı"].ToString();

                    fSAPKY007_2_1_2s.Add(fSAPKY007_2_1_2);
                }

                nesne.fSAPKY007_2_1_2s = fSAPKY007_2_1_2s.ToArray();

                foreach (DataRow dr in dtgfSAPKY007_2_2_1_DataTable.Rows)
                {
                    fSAPKY007_2_2_1 = new FSAPKY007_2_2_1();
                    fSAPKY007_2_2_1.TankNo = dr["Tank No"] == DBNull.Value ? "" : dr["Tank No"].ToString();

                    if (fSAPKY007_2_2_1.TankNo == "")
                    {
                        continue;
                    }
                    fSAPKY007_2_2_1.PaletNo = dr["Palet No"] == DBNull.Value ? "" : dr["Palet No"].ToString();
                    fSAPKY007_2_2_1.BirinciAnalizSaat = dr["1.Analiz(Saat)"] == DBNull.Value ? "" : dr["1.Analiz(Saat)"].ToString();
                    fSAPKY007_2_2_1.IkinciAnalizSaat = dr["2.Analiz(Saat)"] == DBNull.Value ? "" : dr["2.Analiz(Saat)"].ToString();
                    fSAPKY007_2_2_1.UcuncuAnalizSaat = dr["3.Analiz(Saat)"] == DBNull.Value ? "" : dr["3.Analiz(Saat)"].ToString();
                    fSAPKY007_2_2_1.DorduncuAnalizSaat = dr["4.Analiz(Saat)"] == DBNull.Value ? "" : dr["4.Analiz(Saat)"].ToString();
                    fSAPKY007_2_2_1.BesinciAnalizSaat = dr["5.Analiz(Saat)"] == DBNull.Value ? "" : dr["5.Analiz(Saat)"].ToString();


                    fSAPKY007_2_2_1.BirinciAnalizPH = dr["1.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["1.Analiz(PH)"]);
                    fSAPKY007_2_2_1.IkinciAnalizPH = dr["2.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["2.Analiz(PH)"]);
                    fSAPKY007_2_2_1.UcuncuAnalizPH = dr["3.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["3.Analiz(PH)"]);
                    fSAPKY007_2_2_1.DorduncuAnalizPH = dr["4.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["4.Analiz(PH)"]);
                    fSAPKY007_2_2_1.BesinciAnalizPH = dr["5.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["5.Analiz(PH)"]);
                    fSAPKY007_2_2_1.BirinciAnalizSH = dr["1.Analiz(SH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["1.Analiz(SH)"]);
                    fSAPKY007_2_2_1.IkinciAnalizSH = dr["2.Analiz(SH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["2.Analiz(SH)"]);
                    fSAPKY007_2_2_1.UcuncuAnalizSH = dr["3.Analiz(SH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["3.Analiz(SH)"]);
                    fSAPKY007_2_2_1.DorduncuAnalizSH = dr["4.Analiz(SH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["4.Analiz(SH)"]);
                    fSAPKY007_2_2_1.BesinciAnalizSH = dr["5.Analiz(SH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["5.Analiz(SH)"]);
                    fSAPKY007_2_2_1.OperatorAdi = dr["Operatör Adı"] == DBNull.Value ? "" : dr["Operatör Adı"].ToString();

                    fSAPKY007_2_2_1s.Add(fSAPKY007_2_2_1);
                }

                nesne.fSAPKY007_2_2_1s = fSAPKY007_2_2_1s.ToArray();

                foreach (DataRow dr in dtgfSAPKY007_2_2_2_DataTable.Rows)
                {
                    fSAPKY007_2_2_2 = new FSAPKY007_2_2_2();
                    fSAPKY007_2_2_2.TankNo = dr["Tank No"] == DBNull.Value ? "" : dr["Tank No"].ToString();
                    fSAPKY007_2_2_2.Saat = dr["Saat"] == DBNull.Value ? "" : dr["Saat"].ToString();
                    fSAPKY007_2_2_2.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    fSAPKY007_2_2_2.SH = dr["SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SH"]);
                    fSAPKY007_2_2_2.OperatorAdi = dr["Operatör Adı"] == DBNull.Value ? "" : dr["Operatör Adı"].ToString();

                    fSAPKY007_2_2_2s.Add(fSAPKY007_2_2_2);
                }

                nesne.fSAPKY007_2_2_2s = fSAPKY007_2_2_2s.ToArray();

                var resp = client.addOrUpdateFSAPKY007_2(nesne, Giris.dbName, Giris.mKodValue);
                 
                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                if (resp.Value == 0)
                {
                    btnOzet.PerformClick();
                }
            }
            catch (Exception)
            {
            }
        }

        private void txtUretimTarihi_Click(object sender, EventArgs e)
        {
            TarihGirisi tarihGirisi = new TarihGirisi(null, txtUretimTarihi);
            tarihGirisi.ShowDialog();
        }
    }
}

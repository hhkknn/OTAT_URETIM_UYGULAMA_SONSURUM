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
    public partial class _20_FSAPKY_004_1_1 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_004_1_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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
        private static string partiNo = "";
        private static string istasyon = "";
        private static string UrunTanimi = "";
        private static string type = "";
        private static string kullaniciid = "";
        private static int row = 0;
        private SqlCommand cmd = null;
        private static string tarih1 = "";
        private static string urunKodu = "";


        //public DataGridView dtgfSAPKY004_1_1_1Static = new DataGridView();
        //public DataGridView dtgfSAPKY004_1_1_2Static = new DataGridView();
        //public DataGridView dtgfSAPKY004_1_2_1Static = new DataGridView();
        //public DataGridView dtgfSAPKY004_1_2_2Static = new DataGridView();
        //public DataGridView dtgfSAPKY004_1_2_3Static = new DataGridView();
        public DataTable dtgfSAPKY004_1_1_1_DataTable = new DataTable();
        public DataTable dtgfSAPKY004_1_1_2_DataTable = new DataTable();
        public DataTable dtgfSAPKY004_1_2_1_DataTable = new DataTable();
        public DataTable dtgfSAPKY004_1_2_2_DataTable = new DataTable();
        public DataTable dtgfSAPKY004_1_2_3_DataTable = new DataTable();


        public static Button btnOzet = null;
        //public static string Kontrol1 = null;
        //public static string Kontrol2 = null;

        private void _20_FSAPKY_004_1_1_Load(object sender, EventArgs e)
        {
            try
            {

                txtPartiNo.Text = partiNo;
                txtUretimFisNo.Text = UretimFisNo;
                txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                txtUrunTanimi.Text = UrunTanimi;
                btnOzet = btnOzetEkranaDon;


                string sql = "SELECT T0.\"U_Kontrol1\",T0.\"U_Kontrol2\" FROM \"@AIF_FSAPKY004_1_1\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dataTable1);

                if (dataTable1.Rows.Count > 0)
                {
                    txtKontrol1.Text = dataTable1.Rows[0][0].ToString();
                    txtKontrol2.Text = dataTable1.Rows[0][1].ToString();
                }




                #region dataGridView1 

                datagridView1Load();
                //dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Proses Tank No", typeof(string));
                //dataTable1.Columns.Add("UF Sütü Miktarı", typeof(string));
                //dataTable1.Columns.Add("Rework Miktarı", typeof(string));
                //dataTable1.Columns.Add("Mayalama Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Mayalama Saati", typeof(string));
                //dataTable1.Columns.Add("Kırım Saati", typeof(string));
                //dataTable1.Columns.Add("UF Operatör Adı", typeof(string));

                //dataTable1.Rows.Add("");
                //dataTable1.Rows.Add("");
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
                //dataTable2.Columns.Add("UF Sütü PH", typeof(string));
                //dataTable2.Columns.Add("UF Sütü SH", typeof(string));
                //dataTable2.Columns.Add("UF Sütü KM", typeof(string));
                //dataTable2.Columns.Add("UF Sütü Yağı", typeof(string));
                //dataTable2.Columns.Add("Kırım PH", typeof(string));
                //dataTable2.Columns.Add("Kırım SH", typeof(string));
                //dataTable2.Columns.Add("Laboratuvar Personel Adı", typeof(string));

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
                datagridView3Load_IkinciEkran();

                #endregion

                //dtgfSAPKY004_1_1_1Static = dataGridView1;
                //dtgfSAPKY004_1_1_2Static = dataGridView2;
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

        private void btnSagaGit_Click(object sender, EventArgs e)
        {
            _20_FSAPKY_004_1_2 _20_FSAPKY_004_1_2 = new _20_FSAPKY_004_1_2(type, kullaniciid, UretimFisNo, partiNo, UrunTanimi, istasyon, row, tarih1, urunKodu, dtgfSAPKY004_1_1_1_DataTable, dtgfSAPKY004_1_1_2_DataTable, dtgfSAPKY004_1_2_1_DataTable, dtgfSAPKY004_1_2_2_DataTable, dtgfSAPKY004_1_2_3_DataTable, txtKontrol1, txtKontrol2);
            _20_FSAPKY_004_1_2.ShowDialog();


            if (_20_FSAPKY_004_1_2.geriDonme == "OzeteDon")
            {
                btnOzetEkranaDon.PerformClick();
            }

        }
        private void datagridView1Load()
        {

            string sql = "SELECT T1.\"U_ProsTnkNo\" as \"Proses Tank No\",T1.\"U_UFSutMik\" as \"UF Sütü Miktarı\",\"U_ReworkMik\" as \"Rework Miktarı\",T1.\"U_MayaSicaklik\" as \"Mayalama Sıcaklığı\",\"U_MayaSaat\" as \"Mayalama Saati\",T1.\"U_KirimSaat\" as \"Kırım Saati\",\"U_UFOprtAdi\" as \"UF Operatör Adı\" FROM \"@AIF_FSAPKY004_1_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY004_1_1_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY004_1_1_1_DataTable);

            //Commit
            dataGridView1.DataSource = dtgfSAPKY004_1_1_1_DataTable;

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

            if (dtgfSAPKY004_1_1_1_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY004_1_1_1_DataTable.NewRow();
                dr["Proses Tank No"] = "";
                dr["UF Sütü Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Rework Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Mayalama Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Mayalama Saati"] = "";
                dr["Kırım Saati"] = "";
                dr["UF Operatör Adı"] = "";
                dtgfSAPKY004_1_1_1_DataTable.Rows.Add(dr);
            }
            dataGridView1.Columns["UF Operatör Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {

            string sql = "SELECT T1.\"U_UFSutPH\" as \"UF Sütü PH\",T1.\"U_UFSutSH\" as \"UF Sütü SH\",\"U_UFSutKM\" as \"UF Sütü KM\",\"U_UFSutYag\" as \"UF Sütü Yağı\",\"U_KirimPH\" as \"Kırım PH\",\"U_KirimSH\" as \"Kırım SH\",\"U_LabPersAdi\" as \"Laboratuvar Personel Adı\"  FROM \"@AIF_FSAPKY004_1_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY004_1_1_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";


            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY004_1_1_2_DataTable);

            //Commit
            dataGridView2.DataSource = dtgfSAPKY004_1_1_2_DataTable;

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


            if (dtgfSAPKY004_1_1_2_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY004_1_1_2_DataTable.NewRow();
                dr["UF Sütü PH"] = Convert.ToString("0", cultureTR);
                dr["UF Sütü SH"] = Convert.ToString("0", cultureTR);
                dr["UF Sütü KM"] = Convert.ToString("0", cultureTR);
                dr["UF Sütü Yağı"] = Convert.ToString("0", cultureTR);
                dr["Kırım PH"] = Convert.ToString("0", cultureTR);
                dr["Kırım SH"] = Convert.ToString("0", cultureTR);
                dr["Laboratuvar Personel Adı"] = "";

                dtgfSAPKY004_1_1_2_DataTable.Rows.Add(dr);
            }

            dataGridView2.Columns["Laboratuvar Personel Adı"].ReadOnly = true;
        }

        private void datagridView1Load_IkinciEkran()
        {
            string sql = "SELECT T1.\"U_UFGirisSic\" as \"UF Giriş Sıcaklığı\",T1.\"U_UFGirisSaat\" as \"UF Giriş Saati\",\"U_UFFaktor\" as \"UF Faktörü\",T1.\"U_UFCikisSic\" as \"UF Çıkış Sıcaklığı\",\"U_UFBitSaat\" as \"UF Bitiş Saati\",T1.\"U_UFOprtAdi\" as \"UF Operatör Adı\" FROM \"@AIF_FSAPKY004_1_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY004_1_2_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY004_1_2_1_DataTable);

            if (dtgfSAPKY004_1_2_1_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY004_1_2_1_DataTable.NewRow();
                dr["UF Giriş Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["UF Giriş Saati"] = "";
                dr["UF Faktörü"] = Convert.ToString("0", cultureTR);
                dr["UF Çıkış Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["UF Bitiş Saati"] = "";
                dr["UF Operatör Adı"] = "";
                dtgfSAPKY004_1_2_1_DataTable.Rows.Add(dr);
            }
        }

        private void datagridView2Load_IkinciEkran()
        {
            string sql = "SELECT T1.\"U_ReworkPH\" as \"Rework PH\",T1.\"U_ReworkKM\" as \"Rework KM\",\"U_ReworkYag\" as \"Rework Yağ\",\"U_LabPersAdi\" as \"Laboratuvar Personel Adı\"  FROM \"@AIF_FSAPKY004_1_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY004_1_2_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";


            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY004_1_2_2_DataTable);

            if (dtgfSAPKY004_1_2_2_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY004_1_2_2_DataTable.NewRow();
                dr["Rework PH"] = Convert.ToString("0", cultureTR);
                dr["Rework KM"] = Convert.ToString("0", cultureTR);
                dr["Rework Yağ"] = Convert.ToString("0", cultureTR);
                dr["Laboratuvar Personel Adı"] = "";

                dtgfSAPKY004_1_2_2_DataTable.Rows.Add(dr);
            }
        }

        private void datagridView3Load_IkinciEkran()
        {

            string sql = "SELECT T1.\"U_KnsUrunPH\" as \"Konsantre Ürün PH\",T1.\"U_KnsUrunSH\" as \"Konsantre Ürün SH\",\"U_KnsUrunKM\" as \"Konsantre Ürün KM\",\"U_KnsUrunYag\" as \"Konsantre Ürün Yağı\",\"U_LabPersAdi\" as \"Laboratuvar Personel Adı\"  FROM \"@AIF_FSAPKY004_1_1\" AS T0  WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY004_1_2_3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";


            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY004_1_2_3_DataTable);

            if (dtgfSAPKY004_1_2_3_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY004_1_2_3_DataTable.NewRow();
                dr["Konsantre Ürün PH"] = Convert.ToString("0", cultureTR);
                dr["Konsantre Ürün SH"] = Convert.ToString("0", cultureTR);
                dr["Konsantre Ürün KM"] = Convert.ToString("0", cultureTR);
                dr["Konsantre Ürün Yağı"] = Convert.ToString("0", cultureTR);
                dr["Laboratuvar Personel Adı"] = "";

                dtgfSAPKY004_1_2_3_DataTable.Rows.Add(dr);
            }

        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Proses Tank No")
            {

                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();

                //string val = "";

                //if (dataTable1.Rows.Count == 0)
                //{
                //    val = dataGridView1.Rows[0].Cells[e.ColumnIndex].Value.ToString();
                //}
                //else
                //{
                //    val = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[e.ColumnIndex].Value.ToString();

                //}

                //if (val != "")
                //{
                //    DataRow dr = dataTable1.NewRow();
                //    dr["Proses Tank No"] = "";

                //    dataTable1.Rows.Add(dr);

                //}
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "UF Sütü Miktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Rework Miktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Mayalama Sıcaklığı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Mayalama Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Kırım Saati")
            {
                SaatTarihGirisi n = new SaatTarihGirisi(dataGridView1);
                n.ShowDialog();
            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "UF Operatör Adı")
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

                    SelectList selectList = new SelectList(sql, dataGridView1, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "UF Sütü PH" || dataGridView2.Columns[e.ColumnIndex].Name == "UF Sütü SH" || dataGridView2.Columns[e.ColumnIndex].Name == "UF Sütü KM" || dataGridView2.Columns[e.ColumnIndex].Name == "UF Sütü Yağı" || dataGridView2.Columns[e.ColumnIndex].Name == "Kırım PH" || dataGridView2.Columns[e.ColumnIndex].Name == "Kırım SH")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog();
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Laboratuvar Personel Adı")
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

            tabloyaKaydetmeIslemleri();
        }

        private void tabloyaKaydetmeIslemleri()
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                FSAPKY004_1_1 nesne = new FSAPKY004_1_1();
                FSAPKY004_1_1_1 fSAPKY004_1_1_1 = new FSAPKY004_1_1_1();
                List<FSAPKY004_1_1_1> fSAPKY004_1_1_1s = new List<FSAPKY004_1_1_1>();
                FSAPKY004_1_1_2 fSAPKY004_1_1_2 = new FSAPKY004_1_1_2();
                List<FSAPKY004_1_1_2> fSAPKY004_1_1_2s = new List<FSAPKY004_1_1_2>();
                FSAPKY004_1_2_1 fSAPKY004_1_2_1 = new FSAPKY004_1_2_1();
                List<FSAPKY004_1_2_1> fSAPKY004_1_2_1s = new List<FSAPKY004_1_2_1>();
                FSAPKY004_1_2_2 fSAPKY004_1_2_2 = new FSAPKY004_1_2_2();
                List<FSAPKY004_1_2_2> fSAPKY004_1_2_2s = new List<FSAPKY004_1_2_2>();
                FSAPKY004_1_2_3 fSAPKY004_1_2_3 = new FSAPKY004_1_2_3();
                List<FSAPKY004_1_2_3> fSAPKY004_1_2_3s = new List<FSAPKY004_1_2_3>();



                nesne.PartiNo = partiNo;
                nesne.UrunKodu = urunKodu;
                nesne.UrunTanimi = UrunTanimi;

                #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
                //nesne.Tarih = tarih1;
                DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                nesne.Tarih = uretimtarihi.ToString("yyyyMMdd");
                #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

                nesne.Kontrol1 = txtKontrol1.Text;
                nesne.Kontrol2 = txtKontrol2.Text;


                foreach (DataRow dr in dtgfSAPKY004_1_1_1_DataTable.Rows)
                {
                    fSAPKY004_1_1_1 = new FSAPKY004_1_1_1();

                    fSAPKY004_1_1_1.ProsesTankNo = dr["Proses Tank No"] == DBNull.Value ? "" : dr["Proses Tank No"].ToString();
                    if (fSAPKY004_1_1_1.ProsesTankNo == "")
                    {
                        continue;
                    }
                    fSAPKY004_1_1_1.UFSutuMiktari = dr["UF Sütü Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["UF Sütü Miktarı"]);
                    fSAPKY004_1_1_1.ReworkMiktari = dr["Rework Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Rework Miktarı"]);
                    fSAPKY004_1_1_1.MayalamaSicakligi = dr["Mayalama Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Mayalama Sıcaklığı"]);
                    fSAPKY004_1_1_1.MayalamaSaati = dr["Mayalama Saati"] == DBNull.Value ? "" : dr["Mayalama Saati"].ToString();
                    fSAPKY004_1_1_1.KirimSaati = dr["Kırım Saati"] == DBNull.Value ? "" : dr["Kırım Saati"].ToString();
                    fSAPKY004_1_1_1.UFOperatorAdi = dr["UF Operatör Adı"] == DBNull.Value ? "" : dr["UF Operatör Adı"].ToString();

                    fSAPKY004_1_1_1s.Add(fSAPKY004_1_1_1);
                }



                foreach (DataRow dr in dtgfSAPKY004_1_1_2_DataTable.Rows)
                {
                    fSAPKY004_1_1_2 = new FSAPKY004_1_1_2();
                    fSAPKY004_1_1_2.UFSutuPH = dr["UF Sütü PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["UF Sütü PH"]);
                    fSAPKY004_1_1_2.UFSutuSH = dr["UF Sütü SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["UF Sütü SH"]);
                    fSAPKY004_1_1_2.UFSutuKM = dr["UF Sütü KM"] == DBNull.Value ? 0 : Convert.ToInt32(dr["UF Sütü KM"]);
                    fSAPKY004_1_1_2.UFSutuYagi = dr["UF Sütü Yağı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["UF Sütü Yağı"]);
                    fSAPKY004_1_1_2.KirimPH = dr["Kırım PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kırım PH"]);
                    fSAPKY004_1_1_2.KirimSH = dr["Kırım SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kırım SH"]);
                    fSAPKY004_1_1_2.LabPersonelAdi = dr["Laboratuvar Personel Adı"] == DBNull.Value ? "" : dr["Laboratuvar Personel Adı"].ToString();

                    fSAPKY004_1_1_2s.Add(fSAPKY004_1_1_2);
                }

                nesne.fSAPKY004_1_1_2s = fSAPKY004_1_1_2s.ToArray();


                foreach (DataRow dr in dtgfSAPKY004_1_2_1_DataTable.Rows)
                {
                    fSAPKY004_1_2_1 = new FSAPKY004_1_2_1();
                    fSAPKY004_1_2_1.UFGirisSicakligi = dr["UF Giriş Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["UF Giriş Sıcaklığı"]);
                    fSAPKY004_1_2_1.UFGirisSaati = dr["UF Giriş Saati"] == DBNull.Value ? "" : dr["UF Giriş Saati"].ToString();
                    fSAPKY004_1_2_1.UFFaktoru = dr["UF Faktörü"] == DBNull.Value ? 0 : Convert.ToDouble(dr["UF Faktörü"]);
                    fSAPKY004_1_2_1.UFCikisSicakligi = dr["UF Çıkış Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["UF Çıkış Sıcaklığı"]);
                    fSAPKY004_1_2_1.UFBitisSaati = dr["UF Bitiş Saati"] == DBNull.Value ? "" : dr["UF Bitiş Saati"].ToString();
                    fSAPKY004_1_2_1.UFOperatorAdi = dr["UF Operatör Adı"] == DBNull.Value ? "" : dr["UF Operatör Adı"].ToString();

                    fSAPKY004_1_2_1s.Add(fSAPKY004_1_2_1);
                }

                nesne.fSAPKY004_1_2_1s = fSAPKY004_1_2_1s.ToArray();

                foreach (DataRow dr in dtgfSAPKY004_1_2_2_DataTable.Rows)
                {
                    fSAPKY004_1_2_2 = new FSAPKY004_1_2_2();
                    fSAPKY004_1_2_2.ReworkPH = dr["Rework PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Rework PH"]);
                    fSAPKY004_1_2_2.ReworkKM = dr["Rework KM"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Rework KM"]);
                    fSAPKY004_1_2_2.ReworkYag = dr["Rework Yağ"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Rework Yağ"]);
                    fSAPKY004_1_2_2.LabPersonelAdi = dr["Laboratuvar Personel Adı"] == DBNull.Value ? "" : dr["Laboratuvar Personel Adı"].ToString();

                    fSAPKY004_1_2_2s.Add(fSAPKY004_1_2_2);
                }

                nesne.fSAPKY004_1_2_2s = fSAPKY004_1_2_2s.ToArray();


                foreach (DataRow dr in dtgfSAPKY004_1_2_3_DataTable.Rows)
                {
                    fSAPKY004_1_2_3 = new FSAPKY004_1_2_3();
                    fSAPKY004_1_2_3.KonsantreUrunPH = dr["Konsantre Ürün PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Konsantre Ürün PH"]);
                    fSAPKY004_1_2_3.KonsantreUrunSH = dr["Konsantre Ürün SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Konsantre Ürün SH"]);
                    fSAPKY004_1_2_3.KonsantreUrunKM = dr["Konsantre Ürün KM"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Konsantre Ürün KM"]);
                    fSAPKY004_1_2_3.KonsantreUrunYag = dr["Konsantre Ürün Yağı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Konsantre Ürün Yağı"]);
                    fSAPKY004_1_2_3.LabPersonelAdi = dr["Laboratuvar Personel Adı"] == DBNull.Value ? "" : dr["Laboratuvar Personel Adı"].ToString();

                    fSAPKY004_1_2_3s.Add(fSAPKY004_1_2_3);
                }

                nesne.fSAPKY004_1_2_3s = fSAPKY004_1_2_3s.ToArray();

                var resp = client.addOrUpdateFSAPKY004_1_1(nesne, Giris.dbName, Giris.mKodValue);

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
        public static void TabloyaKaydet()
        {

            //try
            //{
            //    fSAPKY004_1_1_1s = new List<FSAPKY004_1_1_1>();
            //    fSAPKY004_1_1_2s = new List<FSAPKY004_1_1_2>();
            //    fSAPKY004_1_2_1s = new List<FSAPKY004_1_2_1>();
            //    fSAPKY004_1_2_2s = new List<FSAPKY004_1_2_2>();


            //    nesne.PartiNo = partiNo;
            //    nesne.UrunKodu = urunKodu;
            //    nesne.UrunTanimi = UrunTanimi;
            //    nesne.Tarih = tarih1;
            //    nesne.Kontrol1 = Kontrol1;
            //    nesne.Kontrol2 = Kontrol2;


            //    foreach (DataGridViewRow dr in dtgfSAPKY004_1_1_1Static.Rows)
            //    {
            //        fSAPKY004_1_1_1 = new FSAPKY004_1_1_1();

            //        fSAPKY004_1_1_1.ProsesTankNo = dr.Cells["Proses Tank No"].Value == DBNull.Value ? "" : dr.Cells["Proses Tank No"].Value.ToString();
            //        if (fSAPKY004_1_1_1.ProsesTankNo == "")
            //        {
            //            continue;
            //        }
            //        fSAPKY004_1_1_1.UFSutuMiktari = dr.Cells["UF Sütü Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["UF Sütü Miktarı"].Value);
            //        fSAPKY004_1_1_1.ReworkMiktari = dr.Cells["Rework Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Rework Miktarı"].Value);
            //        fSAPKY004_1_1_1.MayalamaSicakligi = dr.Cells["Mayalama Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToInt32(dr.Cells["Mayalama Sıcaklığı"].Value);
            //        fSAPKY004_1_1_1.MayalamaSaati = dr.Cells["Mayalama Saati"].Value == DBNull.Value ? "" : dr.Cells["Mayalama Saati"].Value.ToString();
            //        fSAPKY004_1_1_1.KirimSaati = dr.Cells["Kırım Saati"].Value == DBNull.Value ? "" : dr.Cells["Kırım Saati"].Value.ToString();
            //        fSAPKY004_1_1_1.UFOperatorAdi = dr.Cells["UF Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["UF Operatör Adı"].Value.ToString();

            //        fSAPKY004_1_1_1s.Add(fSAPKY004_1_1_1);
            //    }

            //    nesne.fSAPKY004_1_1_1s = fSAPKY004_1_1_1s.ToArray();

            //    foreach (DataGridViewRow dr in dtgfSAPKY004_1_1_2Static.Rows)
            //    {
            //        fSAPKY004_1_1_2 = new FSAPKY004_1_1_2();
            //        fSAPKY004_1_1_2.UFSutuPH = dr.Cells["UF Sütü PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["UF Sütü PH"].Value);
            //        fSAPKY004_1_1_2.UFSutuSH = dr.Cells["UF Sütü SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["UF Sütü SH"].Value);
            //        fSAPKY004_1_1_2.UFSutuKM = dr.Cells["UF Sütü KM"].Value == DBNull.Value ? 0 : Convert.ToInt32(dr.Cells["UF Sütü KM"].Value);
            //        fSAPKY004_1_1_2.UFSutuYagi = dr.Cells["UF Sütü Yağı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["UF Sütü Yağı"].Value);
            //        fSAPKY004_1_1_2.KirimPH = dr.Cells["Kırım PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kırım PH"].Value);
            //        fSAPKY004_1_1_2.KirimSH = dr.Cells["Kırım SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kırım SH"].Value);
            //        fSAPKY004_1_1_2.LabPersonelAdi = dr.Cells["Laboratuvar Personel Adı"].Value == DBNull.Value ? "" : dr.Cells["Laboratuvar Personel Adı"].Value.ToString();

            //        fSAPKY004_1_1_2s.Add(fSAPKY004_1_1_2);
            //    }

            //    nesne.fSAPKY004_1_1_2s = fSAPKY004_1_1_2s.ToArray();

            //    foreach (DataGridViewRow dr in dtgfSAPKY004_1_2_1Static.Rows)
            //    {
            //        fSAPKY004_1_2_1 = new FSAPKY004_1_2_1();
            //        fSAPKY004_1_2_1.UFGirisSicakligi = dr.Cells["UF Giriş Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["UF Giriş Sıcaklığı"].Value);
            //        fSAPKY004_1_2_1.UFGirisSaati = dr.Cells["UF Giriş Saati"].Value == DBNull.Value ? "" : dr.Cells["UF Giriş Saati"].Value.ToString();
            //        fSAPKY004_1_2_1.UFFaktoru = dr.Cells["UF Faktörü"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["UF Faktörü"].Value);
            //        fSAPKY004_1_2_1.UFCikisSicakligi = dr.Cells["UF Çıkış Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["UF Çıkış Sıcaklığı"].Value);
            //        fSAPKY004_1_2_1.UFBitisSaati = dr.Cells["UF Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["UF Bitiş Saati"].Value.ToString();
            //        fSAPKY004_1_2_1.UFOperatorAdi = dr.Cells["UF Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["UF Operatör Adı"].Value.ToString();

            //        fSAPKY004_1_2_1s.Add(fSAPKY004_1_2_1);
            //    }

            //    nesne.fSAPKY004_1_2_1s = fSAPKY004_1_2_1s.ToArray();


            //    foreach (DataGridViewRow dr in dtgfSAPKY004_1_2_2Static.Rows)
            //    {
            //        fSAPKY004_1_2_2 = new FSAPKY004_1_2_2();
            //        fSAPKY004_1_2_2.ReworkPH = dr.Cells["Rework PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Rework PH"].Value);
            //        fSAPKY004_1_2_2.ReworkKM = dr.Cells["Rework KM"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Rework KM"].Value);
            //        fSAPKY004_1_2_2.ReworkYag = dr.Cells["Rework Yağ"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Rework Yağ"].Value);
            //        fSAPKY004_1_2_2.LabPersonelAdi = dr.Cells["Laboratuvar Personel Adı"].Value == DBNull.Value ? "" : dr.Cells["Laboratuvar Personel Adı"].Value.ToString();

            //        fSAPKY004_1_2_2s.Add(fSAPKY004_1_2_2);
            //    }

            //    nesne.fSAPKY004_1_2_2s = fSAPKY004_1_2_2s.ToArray();


            //    foreach (DataGridViewRow dr in dtgfSAPKY004_1_2_3Static.Rows)
            //    {
            //        fSAPKY004_1_2_3 = new FSAPKY004_1_2_3();
            //        fSAPKY004_1_2_3.KonsantreUrunPH = dr.Cells["Konsantre Ürün PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Konsantre Ürün PH"].Value);
            //        fSAPKY004_1_2_3.KonsantreUrunSH = dr.Cells["Konsantre Ürün SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Konsantre Ürün SH"].Value);
            //        fSAPKY004_1_2_3.KonsantreUrunKM = dr.Cells["Konsantre Ürün KM"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Konsantre Ürün KM"].Value);
            //        fSAPKY004_1_2_3.KonsantreUrunYag = dr.Cells["Konsantre Ürün Yağı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Konsantre Ürün Yağı"].Value);
            //        fSAPKY004_1_2_3.LabPersonelAdi = dr.Cells["Laboratuvar Personel Adı"].Value == DBNull.Value ? "" : dr.Cells["Laboratuvar Personel Adı"].Value.ToString();

            //        fSAPKY004_1_2_3s.Add(fSAPKY004_1_2_3);
            //    }

            //    nesne.fSAPKY004_1_2_3s = fSAPKY004_1_2_3s.ToArray();

            //    var resp = client.addOrUpdateFSAPKY004_1_1(nesne, Giris.dbName, Giris.mKodValue);

            //    //MessageBox.Show(resp.Description);
            //    CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

            //    if (resp.Value == 0)
            //    {
            //        btnOzet.PerformClick();
            //    }
            //}
            //catch (Exception)
            //{
            //}
        }

        private void txtUretimTarihi_Click(object sender, EventArgs e)
        {
            TarihGirisi tarihGirisi = new TarihGirisi(null, txtUretimTarihi);
            tarihGirisi.ShowDialog();
        }
    }
}

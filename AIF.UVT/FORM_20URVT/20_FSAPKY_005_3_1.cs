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
    public partial class _20_FSAPKY_005_3_1 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_005_3_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button1.Font.Style);

            richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               richTextBox1.Font.Style);

            richTextBox2.Font = new Font(richTextBox2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               richTextBox2.Font.Style);

            btnEvet.Font = new Font(btnEvet.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnEvet.Font.Style);

            btnHayir.Font = new Font(btnHayir.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnHayir.Font.Style);

            btnEvet2.Font = new Font(btnEvet2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnEvet2.Font.Style);

            btnHayir2.Font = new Font(btnHayir2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnHayir2.Font.Style);

            btnSagaGit.Font = new Font(btnSagaGit.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSagaGit.Font.Style);

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOnayla.Font.Style);

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
        Color buttondefaultrenk = Color.Gray;


        //public static string Kontrol1 = null;
        //public static string Kontrol2 = null; 
        //public static string seciliAnaliz = null;
        public static Button btnOzet = null;

        public DataTable dtgfSAPKY005_3_1_1_DataTable = new DataTable();
        public DataTable dtgfSAPKY005_3_1_2_DataTable = new DataTable();
        public DataTable dtgfSAPKY005_3_2_1_DataTable = new DataTable();
        public DataTable dtgfSAPKY005_3_2_2_DataTable = new DataTable();
        TextBox txtkontrol1_IlkEkran;
        TextBox txtkontrol2_IlkEkran;


        private void _20_FSAPKY_005_3_1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Ambalajlarda kırık,çatlak veya herhangi bir deformasyon yoktur.Yabancı Fiziksel Madde Kontaminasyonu Yoktur.Hayırsa Uygun olmayan ürün prosedürünü uygula.";
            richTextBox2.Text = "Ağırlık Kontrolü yapılmıştır,uygundur.Hayırsa Uygun olmayan ürün prosedürünü uygula.";

            try
            {
                #region Kontrol yapıldı mı sorgusu

                string sql = "SELECT \"U_Kontrol1\",\"U_Kontrol2\"  FROM \"@AIF_FSAPKY005_3_1\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
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

                if (txtKontrol1.Text == "Y")
                {
                    btnHayir.BackColor = buttondefaultrenk;
                    btnEvet.BackColor = Color.GreenYellow;
                }
                else if (txtKontrol1.Text == "N")
                {
                    btnHayir.BackColor = Color.OrangeRed;
                    btnEvet.BackColor = buttondefaultrenk;
                }

                if (txtKontrol2.Text == "Y")
                {
                    btnHayir2.BackColor = buttondefaultrenk;
                    btnEvet2.BackColor = Color.GreenYellow;
                }
                else if (txtKontrol2.Text == "N")
                {
                    btnHayir2.BackColor = Color.OrangeRed;
                    btnEvet2.BackColor = buttondefaultrenk;
                }
                #endregion

                txtPartiNo.Text = partiNo;
                txtUretimFisNo.Text = UretimFisNo;
                txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                txtUrunTanimi.Text = UrunTanimi;
                btnOzet = btnOzetEkranaDon;

                buttondefaultrenk = btnEvet.BackColor;

                #region dataGridView1 
                datagridView1Load();
                ////dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Ürün Adı", typeof(string));
                //dataTable1.Columns.Add("Dolum Başlama PH 1", typeof(string));
                //dataTable1.Columns.Add("Dolum Başlama PH 2", typeof(string));
                //dataTable1.Columns.Add("Dolum Başlama PH 3", typeof(string));
                //dataTable1.Columns.Add("Dolum Başlama PH 4", typeof(string));
                //dataTable1.Columns.Add("Dolum Başlama PH 5", typeof(string));
                //dataTable1.Columns.Add("Dolum Başlama PH 6", typeof(string));
                //dataTable1.Columns.Add("Dolum Başlama PH 7", typeof(string));
                //dataTable1.Columns.Add("Dolum Başlama PH 8", typeof(string));
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
                ////dataTable2.Columns.Add("#", "#");
                //dataTable2.Columns.Add("Ürün Adı", typeof(string));
                //dataTable2.Columns.Add("Örnek 1", typeof(string));
                //dataTable2.Columns.Add("Örnek 2", typeof(string));
                //dataTable2.Columns.Add("Örnek 3", typeof(string));
                //dataTable2.Columns.Add("Örnek 4", typeof(string));
                //dataTable2.Columns.Add("Örnek 5", typeof(string));
                //dataTable2.Columns.Add("Örnek 6", typeof(string));
                //dataTable2.Columns.Add("Örnek 7", typeof(string));
                //dataTable2.Columns.Add("Örnek 8", typeof(string));
                //dataTable2.Columns.Add("Örnek 9", typeof(string));
                //dataTable2.Columns.Add("Örnek 10", typeof(string));
                //dataTable2.Columns.Add("Operatör Adı", typeof(string));

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
            _20_FSAPKY_005_3_2 _20_FSAPKY_005_3_2 = new _20_FSAPKY_005_3_2(type, kullaniciid, UretimFisNo, partiNo, UrunTanimi, istasyon, row, tarih1, urunKodu, dtgfSAPKY005_3_1_1_DataTable, dtgfSAPKY005_3_1_2_DataTable, dtgfSAPKY005_3_2_1_DataTable, dtgfSAPKY005_3_2_2_DataTable, txtKontrol1.Text, txtKontrol2.Text);
            _20_FSAPKY_005_3_2.ShowDialog();

            if (_20_FSAPKY_005_3_2.geriDonme == "OzeteDon")
            {
                btnOzetEkranaDon.PerformClick();
            }

        }
        private void datagridView1Load()
        {
            string sql = "SELECT T1.\"U_UrunAdi\" as \"Ürün Adı\",T1.\"U_DolBasPH1\" as \"Dolum Başlama PH 1\",T1.\"U_DolBasPH2\" as \"Dolum Başlama PH 2\",T1.\"U_DolBasPH3\" as \"Dolum Başlama PH 3\",T1.\"U_DolBasPH4\" as \"Dolum Başlama PH 4\",T1.\"U_DolBasPH5\" as \"Dolum Başlama PH 5\",T1.\"U_DolBasPH6\" as \"Dolum Başlama PH 6\",T1.\"U_DolBasPH7\" as \"Dolum Başlama PH 7\",T1.\"U_DolBasPH8\" as \"Dolum Başlama PH 8\",T1.\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY005_3_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY005_3_1_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY005_3_1_1_DataTable);

            //Commit
            dataGridView1.DataSource = dtgfSAPKY005_3_1_1_DataTable;

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

            if (dtgfSAPKY005_3_1_1_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY005_3_1_1_DataTable.NewRow();
                dr["Ürün Adı"] = "";
                dr["Dolum Başlama PH 1"] = Convert.ToString("0", cultureTR);
                dr["Dolum Başlama PH 2"] = Convert.ToString("0", cultureTR);
                dr["Dolum Başlama PH 3"] = Convert.ToString("0", cultureTR);
                dr["Dolum Başlama PH 4"] = Convert.ToString("0", cultureTR);
                dr["Dolum Başlama PH 5"] = Convert.ToString("0", cultureTR);
                dr["Dolum Başlama PH 6"] = Convert.ToString("0", cultureTR);
                dr["Dolum Başlama PH 7"] = Convert.ToString("0", cultureTR);
                dr["Dolum Başlama PH 8"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";
                dtgfSAPKY005_3_1_1_DataTable.Rows.Add(dr);
            }
            dataGridView1.Columns["Ürün Adı"].ReadOnly = true;
            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {
            string sql = "SELECT T1.\"U_UrunAdi\" as \"Ürün Adı\",T1.\"U_Ornek1\" as \"Örnek 1\",T1.\"U_Ornek2\" as \"Örnek 2\",T1.\"U_Ornek3\" as \"Örnek 3\",T1.\"U_Ornek4\" as \"Örnek 4\",T1.\"U_Ornek5\" as \"Örnek 5\",T1.\"U_Ornek6\" as \"Örnek 6\",T1.\"U_Ornek7\" as \"Örnek 7\",T1.\"U_Ornek8\" as \"Örnek 8\",T1.\"U_Ornek9\" as \"Örnek 9\",T1.\"U_Ornek10\" as \"Örnek 10\",T1.\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY005_3_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY005_3_1_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY005_3_1_2_DataTable);

            dataGridView2.DataSource = dtgfSAPKY005_3_1_2_DataTable;

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


            if (dtgfSAPKY005_3_1_2_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY005_3_1_2_DataTable.NewRow();
                dr["Ürün Adı"] = "";
                dr["Örnek 1"] = Convert.ToString("0", cultureTR);
                dr["Örnek 2"] = Convert.ToString("0", cultureTR);
                dr["Örnek 3"] = Convert.ToString("0", cultureTR);
                dr["Örnek 4"] = Convert.ToString("0", cultureTR);
                dr["Örnek 5"] = Convert.ToString("0", cultureTR);
                dr["Örnek 6"] = Convert.ToString("0", cultureTR);
                dr["Örnek 7"] = Convert.ToString("0", cultureTR);
                dr["Örnek 8"] = Convert.ToString("0", cultureTR);
                dr["Örnek 9"] = Convert.ToString("0", cultureTR);
                dr["Örnek 10"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";

                dtgfSAPKY005_3_1_2_DataTable.Rows.Add(dr);
            }

            dataGridView2.Columns["Ürün Adı"].ReadOnly = true;
            dataGridView2.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void datagridView1Load_IkinciEkran()
        {
            string sql = "SELECT T1.\"U_TankNo\" as \"Tank No\",\"U_PaletNo\" as \"Palet No\",T1.\"U_AnlzSaat1\" as \"1.Analiz(Saat)\",\"U_AnlzSaat2\" as \"2.Analiz(Saat)\",\"U_AnlzSaat3\" as \"3.Analiz(Saat)\",\"U_AnlzSaat4\" as \"4.Analiz(Saat)\", \"U_AnlzSaat5\" as \"5.Analiz(Saat)\", \"U_AnlzPH1\" as \"1.Analiz(PH)\", \"U_AnlzPH2\" as \"2.Analiz(PH)\", \"U_AnlzPH3\" as \"3.Analiz(PH)\", \"U_AnlzPH4\" as \"4.Analiz(PH)\", \"U_AnlzPH5\" as \"5.Analiz(PH)\", \"U_AnlzSic1\" as \"1.Analiz(Sıc(C))\" , \"U_AnlzSic2\" as \"2.Analiz(Sıc(C))\" , \"U_AnlzSic3\" as \"3.Analiz(Sıc(C))\" , \"U_AnlzSic4\" as \"4.Analiz(Sıc(C))\" , \"U_AnlzSic5\" as \"5.Analiz(Sıc(C))\" , \"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY005_3_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY005_3_2_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY005_3_2_1_DataTable);

            if (dtgfSAPKY005_3_2_1_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY005_3_2_1_DataTable.NewRow();
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
                dr["1.Analiz(Sıc(C))"] = Convert.ToString("0", cultureTR);
                dr["2.Analiz(Sıc(C))"] = Convert.ToString("0", cultureTR);
                dr["3.Analiz(Sıc(C))"] = Convert.ToString("0", cultureTR);
                dr["4.Analiz(Sıc(C))"] = Convert.ToString("0", cultureTR);
                dr["5.Analiz(Sıc(C))"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";

                dtgfSAPKY005_3_2_1_DataTable.Rows.Add(dr);
            } 
        }

        private void datagridView2Load_IkinciEkran()
        {

            string sql = "SELECT T1.\"U_TankNo\" as \"Tank No\",\"U_PaletNo\" as \"Palet No\",\"U_Saat\" as \"Saat\",T1.\"U_PH\" as \"PH\",\"U_PH\" as \"SH\",\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY005_3_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY005_3_2_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY005_3_2_2_DataTable);

            if (dtgfSAPKY005_3_2_2_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY005_3_2_2_DataTable.NewRow();
                dr["Tank No"] = "";
                dr["Palet No"] = "";
                dr["Saat"] = "";
                dr["PH"] = Convert.ToString("0", cultureTR);
                dr["SH"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";

                dtgfSAPKY005_3_2_2_DataTable.Rows.Add(dr);
            } 
        }


        private void btnEvet_Click(object sender, EventArgs e)
        {
            btnHayir.BackColor = buttondefaultrenk;
            btnEvet.BackColor = Color.GreenYellow;
            txtKontrol1.Text = "Y";
        }

        private void btnHayir_Click(object sender, EventArgs e)
        {
            btnHayir.BackColor = Color.OrangeRed;
            btnEvet.BackColor = buttondefaultrenk;
            txtKontrol1.Text = "N";
        }

        private void btnEvet2_Click(object sender, EventArgs e)
        {
            btnHayir2.BackColor = buttondefaultrenk;
            btnEvet2.BackColor = Color.GreenYellow;
            txtKontrol2.Text = "Y";
        }

        private void btnHayir2_Click(object sender, EventArgs e)
        {

            btnHayir2.BackColor = Color.OrangeRed;
            btnEvet2.BackColor = buttondefaultrenk;
            txtKontrol2.Text = "N";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Ürün Adı")
            {
                string sql = "";
                sql = "Select \"U_Deger1\" from \"@AIF_GNLKANLZPRM\" WITH (NOLOCK) where \"U_Kod\" ='01'";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                sda = new SqlDataAdapter(cmd);
                DataTable dt_Sorgu = new DataTable();
                sda.Fill(dt_Sorgu);

                if (dt_Sorgu.Rows.Count > 0)
                {
                    string sql1 = "Select TOP 1 '' as \"Kalem Kodu\",'' as \"Kalem Adı\" FROM OITM WITH (NOLOCK) ";
                    sql1 += " UNION ALL ";
                    sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM WITH (NOLOCK) where \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' ";

                    SelectList selectList = new SelectList(sql1, dataGridView1, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();
                }
                else
                {
                    CustomMsgBtn.Show("Ürün Bulunamadı.", "UYARI", "TAMAM");

                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Dolum Başlama PH 1" || dataGridView1.Columns[e.ColumnIndex].Name == "Dolum Başlama PH 2" || dataGridView1.Columns[e.ColumnIndex].Name == "Dolum Başlama PH 3" || dataGridView1.Columns[e.ColumnIndex].Name == "Dolum Başlama PH 4" || dataGridView1.Columns[e.ColumnIndex].Name == "Dolum Başlama PH 5" || dataGridView1.Columns[e.ColumnIndex].Name == "Dolum Başlama PH 6" || dataGridView1.Columns[e.ColumnIndex].Name == "Dolum Başlama PH 7" || dataGridView1.Columns[e.ColumnIndex].Name == "Dolum Başlama PH 8")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
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
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Ürün Adı")
            {
                string sql = "";
                sql = "Select \"U_Deger1\" from \"@AIF_GNLKANLZPRM\" WITH (NOLOCK) where \"U_Kod\" ='01'";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                sda = new SqlDataAdapter(cmd);
                DataTable dt_Sorgu = new DataTable();
                sda.Fill(dt_Sorgu);

                if (dt_Sorgu.Rows.Count > 0)
                {
                    string sql1 = "Select TOP 1 '' as \"Kalem Kodu\",'' as \"Kalem Adı\" FROM OITM WITH (NOLOCK) ";
                    sql1 += " UNION ALL ";
                    sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM WITH (NOLOCK) where \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' ";

                    SelectList selectList = new SelectList(sql1, dataGridView2, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();
                }
                else
                {
                    CustomMsgBtn.Show("Ürün Bulunamadı.", "UYARI", "TAMAM");

                }
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 1" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 2" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 3" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 4" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 5" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 6" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 7" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 8" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 9" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 10")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog();
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Operatör Adı")
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
            //Kontrol1 = txtKontrol1.Text;
            //Kontrol2 = txtKontrol2.Text;
            tabloyaKaydetmeIslemleri();
        }

        public void tabloyaKaydetmeIslemleri()
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                FSAPKY005_3_1 nesne = new FSAPKY005_3_1();

                FSAPKY005_3_1_1 fSAPKY005_3_1_1 = new FSAPKY005_3_1_1();
                List<FSAPKY005_3_1_1> fSAPKY005_3_1_1s = new List<FSAPKY005_3_1_1>();

                FSAPKY005_3_1_2 fSAPKY005_3_1_2 = new FSAPKY005_3_1_2();
                List<FSAPKY005_3_1_2> fSAPKY005_3_1_2s = new List<FSAPKY005_3_1_2>();

                FSAPKY005_3_2_1 fSAPKY005_3_2_1 = new FSAPKY005_3_2_1();
                List<FSAPKY005_3_2_1> fSAPKY005_3_2_1s = new List<FSAPKY005_3_2_1>();

                FSAPKY005_3_2_2 fSAPKY005_3_2_2 = new FSAPKY005_3_2_2();
                List<FSAPKY005_3_2_2> fSAPKY005_3_2_2s = new List<FSAPKY005_3_2_2>(); 

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
                nesne.Aciklama = "";

                foreach(DataRow dr in dtgfSAPKY005_3_1_1_DataTable.Rows)
                {
                    fSAPKY005_3_1_1 = new FSAPKY005_3_1_1();

                    fSAPKY005_3_1_1.UrunAdi = dr["Ürün Adı"] == DBNull.Value ? "" : dr["Ürün Adı"].ToString();
                    if (fSAPKY005_3_1_1.UrunAdi == "")
                    {
                        continue;
                    }
                    fSAPKY005_3_1_1.DolBasPH1 = dr["Dolum Başlama PH 1"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Başlama PH 1"]);
                    fSAPKY005_3_1_1.DolBasPH2 = dr["Dolum Başlama PH 2"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Başlama PH 2"]);
                    fSAPKY005_3_1_1.DolBasPH3 = dr["Dolum Başlama PH 3"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Başlama PH 3"]);
                    fSAPKY005_3_1_1.DolBasPH4 = dr["Dolum Başlama PH 4"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Başlama PH 4"]);
                    fSAPKY005_3_1_1.DolBasPH5 = dr["Dolum Başlama PH 5"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Başlama PH 5"]);
                    fSAPKY005_3_1_1.DolBasPH6 = dr["Dolum Başlama PH 6"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Başlama PH 6"]);
                    fSAPKY005_3_1_1.DolBasPH7 = dr["Dolum Başlama PH 7"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Başlama PH 7"]);
                    fSAPKY005_3_1_1.DolBasPH8 = dr["Dolum Başlama PH 8"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Başlama PH 8"]);
                    fSAPKY005_3_1_1.OperatorAdi = dr["Operatör Adı"] == DBNull.Value ? "" : dr["Operatör Adı"].ToString();

                    fSAPKY005_3_1_1s.Add(fSAPKY005_3_1_1);
                }

                nesne.fSAPKY005_3_1_1s = fSAPKY005_3_1_1s.ToArray();

                foreach (DataRow dr in dtgfSAPKY005_3_1_2_DataTable.Rows)
                {
                    fSAPKY005_3_1_2 = new FSAPKY005_3_1_2();
                    fSAPKY005_3_1_2.UrunAdi = dr["Ürün Adı"] == DBNull.Value ? "" : dr["Ürün Adı"].ToString();
                    fSAPKY005_3_1_2.Ornek1 = dr["Örnek 1"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Örnek 1"]);
                    fSAPKY005_3_1_2.Ornek2 = dr["Örnek 2"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Örnek 2"]);
                    fSAPKY005_3_1_2.Ornek3 = dr["Örnek 3"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Örnek 3"]);
                    fSAPKY005_3_1_2.Ornek4 = dr["Örnek 4"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Örnek 4"]);
                    fSAPKY005_3_1_2.Ornek5 = dr["Örnek 5"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Örnek 5"]);
                    fSAPKY005_3_1_2.Ornek6 = dr["Örnek 6"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Örnek 6"]);
                    fSAPKY005_3_1_2.Ornek7 = dr["Örnek 7"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Örnek 7"]);
                    fSAPKY005_3_1_2.Ornek8 = dr["Örnek 8"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Örnek 8"]);
                    fSAPKY005_3_1_2.Ornek9 = dr["Örnek 9"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Örnek 9"]);
                    fSAPKY005_3_1_2.Ornek10 = dr["Örnek 10"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Örnek 10"]);
                    fSAPKY005_3_1_2.OperatorAdi = dr["Operatör Adı"] == DBNull.Value ? "" : dr["Operatör Adı"].ToString();

                    fSAPKY005_3_1_2s.Add(fSAPKY005_3_1_2);
                }

                nesne.fSAPKY005_3_1_2s = fSAPKY005_3_1_2s.ToArray();

                foreach (DataRow dr in dtgfSAPKY005_3_2_1_DataTable.Rows)
                {
                    fSAPKY005_3_2_1 = new FSAPKY005_3_2_1();
                    fSAPKY005_3_2_1.TankNumarasi = dr["Tank No"] == DBNull.Value ? "" : dr["Tank No"].ToString();
                    fSAPKY005_3_2_1.PaletNumarasi = dr["Palet No"] == DBNull.Value ? "" : dr["Palet No"].ToString();
                    fSAPKY005_3_2_1.BirinciAnalizSaat = dr["1.Analiz(Saat)"] == DBNull.Value ? "" : dr["1.Analiz(Saat)"].ToString();
                    fSAPKY005_3_2_1.IkinciAnalizSaat = dr["2.Analiz(Saat)"] == DBNull.Value ? "" : dr["2.Analiz(Saat)"].ToString();
                    fSAPKY005_3_2_1.UcuncuAnalizSaat = dr["3.Analiz(Saat)"] == DBNull.Value ? "" : dr["3.Analiz(Saat)"].ToString();
                    fSAPKY005_3_2_1.DorduncuAnalizSaat = dr["4.Analiz(Saat)"] == DBNull.Value ? "" : dr["4.Analiz(Saat)"].ToString();
                    fSAPKY005_3_2_1.BesinciAnalizSaat = dr["5.Analiz(Saat)"] == DBNull.Value ? "" : dr["5.Analiz(Saat)"].ToString();

                    fSAPKY005_3_2_1.BirinciAnalizPH = dr["1.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["1.Analiz(PH)"]);
                    fSAPKY005_3_2_1.IkinciAnalizPH = dr["2.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["2.Analiz(PH)"]);
                    fSAPKY005_3_2_1.UcuncuAnalizPH = dr["3.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["3.Analiz(PH)"]);
                    fSAPKY005_3_2_1.DorduncuAnalizPH = dr["4.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["4.Analiz(PH)"]);
                    fSAPKY005_3_2_1.BesinciAnalizPH = dr["5.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["5.Analiz(PH)"]);

                    fSAPKY005_3_2_1.BirinciAnalizSicaklik = dr["1.Analiz(Sıc(C))"] == DBNull.Value ? 0 : Convert.ToDouble(dr["1.Analiz(Sıc(C))"]);
                    fSAPKY005_3_2_1.BirinciAnalizSicaklik = dr["2.Analiz(Sıc(C))"] == DBNull.Value ? 0 : Convert.ToDouble(dr["2.Analiz(Sıc(C))"]);
                    fSAPKY005_3_2_1.BirinciAnalizSicaklik = dr["3.Analiz(Sıc(C))"] == DBNull.Value ? 0 : Convert.ToDouble(dr["3.Analiz(Sıc(C))"]);
                    fSAPKY005_3_2_1.BirinciAnalizSicaklik = dr["4.Analiz(Sıc(C))"] == DBNull.Value ? 0 : Convert.ToDouble(dr["4.Analiz(Sıc(C))"]);
                    fSAPKY005_3_2_1.BirinciAnalizSicaklik = dr["5.Analiz(Sıc(C))"] == DBNull.Value ? 0 : Convert.ToDouble(dr["5.Analiz(Sıc(C))"]);
                    fSAPKY005_3_2_1.OperatorAdi = dr["Operatör Adı"] == DBNull.Value ? "" : dr["Operatör Adı"].ToString();


                    fSAPKY005_3_2_1s.Add(fSAPKY005_3_2_1);
                }

                nesne.fSAPKY005_3_2_1s = fSAPKY005_3_2_1s.ToArray();


                foreach (DataRow dr in dtgfSAPKY005_3_2_2_DataTable.Rows)
                {
                    fSAPKY005_3_2_2 = new FSAPKY005_3_2_2();
                    fSAPKY005_3_2_2.TankNo = dr["Tank No"] == DBNull.Value ? "" : dr["Tank No"].ToString();
                    fSAPKY005_3_2_2.PaletNo = dr["Palet No"] == DBNull.Value ? "" : dr["Palet No"].ToString();
                    fSAPKY005_3_2_2.Saat = dr["Saat"] == DBNull.Value ? "" : dr["Saat"].ToString();
                    fSAPKY005_3_2_2.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    fSAPKY005_3_2_2.SH = dr["SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SH"]);
                    fSAPKY005_3_2_2.OperatorAdi = dr["Operatör Adı"] == DBNull.Value ? "" : dr["Operatör Adı"].ToString();

                    fSAPKY005_3_2_2s.Add(fSAPKY005_3_2_2);
                }

                nesne.fSAPKY005_3_2_2s = fSAPKY005_3_2_2s.ToArray();

                var resp = client.addOrUpdateFSAPKY005_3_1(nesne, Giris.dbName, Giris.mKodValue);

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

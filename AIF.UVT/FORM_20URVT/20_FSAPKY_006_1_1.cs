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
    public partial class _20_FSAPKY_006_1_1 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_006_1_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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

            btnEvet.Font = new Font(btnEvet.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnEvet.Font.Style);

            btnHayir.Font = new Font(btnHayir.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnHayir.Font.Style);

            richTextBox2.Font = new Font(richTextBox2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               richTextBox2.Font.Style);

            btnEvet2.Font = new Font(btnEvet2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnEvet2.Font.Style);

            btnHayir2.Font = new Font(btnHayir2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnHayir2.Font.Style);

            richTextBox3.Font = new Font(richTextBox3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               richTextBox3.Font.Style);

            btnEvet3.Font = new Font(btnEvet3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnEvet3.Font.Style);

            btnHayir3.Font = new Font(btnHayir3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnHayir3.Font.Style);

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
        Color buttondefaultrenk = Color.Gray;



        //public DataGridView dtgfSAPKY006_1_1_1Static = new DataGridView();
        //public DataGridView dtgfSAPKY006_1_1_2Static = new DataGridView();
        //public DataGridView dtgfSAPKY006_1_2_1Static = null;
        //public DataGridView dtgfSAPKY006_1_2_2Static = new DataGridView();

        public DataTable dtgfSAPKY006_1_1_1_DataTable = new DataTable();
        public DataTable dtgfSAPKY006_1_1_2_DataTable = new DataTable();
        public DataTable dtgfSAPKY006_1_2_1_DataTable = new DataTable();
        public DataTable dtgfSAPKY006_1_2_2_DataTable = new DataTable();

        public static Button btnOzet = null;
        //public static string Kontrol1 = null;
        //public static string Kontrol2 = null;
        //public static string Kontrol3 = null;
        //public static string seciliAnaliz = null;


        private void _20_FSAPKY_006_1_1_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Ağırlık Kontrolü yapılmıştır,uygundur.Hayırsa Uygun olmayan ürün prosedürünü uygula.";
            richTextBox2.Text = "Kültürün kontrolü yapılmıştır. Bir Fiziksel deformasyon ve bulaşma söz konusu değildir. Saklama koşulları sağlanmıştır.Hayırsa Uygun olmayan ürün prosedürünü uygula.";
            richTextBox3.Text = "Ambalajlarda kırık,çatlak veya herhangi bir deformasyon yoktur.Yabancı Fiziksel Madde Kontaminasyonu Yoktur.Hayırsa Uygun olmayan ürün prosedürünü uygula.";

            try
            {
                //nesne = new FSAPKY006_1_1();
                //fSAPKY006_1_1_1 = new FSAPKY006_1_1_1();
                //fSAPKY006_1_1_1s = new List<FSAPKY006_1_1_1>();
                //fSAPKY006_1_1_2 = new FSAPKY006_1_1_2();
                //fSAPKY006_1_1_2s = new List<FSAPKY006_1_1_2>();
                //fSAPKY006_1_2_1 = new FSAPKY006_1_2_1();
                //fSAPKY006_1_2_1s = new List<FSAPKY006_1_2_1>();
                //fSAPKY006_1_2_2 = new FSAPKY006_1_2_2();
                //fSAPKY006_1_2_2s = new List<FSAPKY006_1_2_2>();

                //dtgfSAPKY006_1_1_1Static = new DataGridView();
                //dtgfSAPKY006_1_1_2Static = new DataGridView();
                //dtgfSAPKY006_1_2_1Static = new DataGridView();

                //dtgfSAPKY006_1_2_1Static = new DataGridView();
                //dtgfSAPKY006_1_2_2Static = new DataGridView();

                //dtgfSAPKY006_1_2_1Static_DataTable = new DataTable();
                //dtgfSAPKY006_1_2_2Static_DataTable = new DataTable();

                txtPartiNo.Text = partiNo;
                txtUretimFisNo.Text = UretimFisNo;
                txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                txtUrunTanimi.Text = UrunTanimi;
                btnOzet = btnOzetEkranaDon;

                #region Diğer kalite kontrol yapıldı mı sorgusu

                DataTable Kontroller = new DataTable();

                string sql = "SELECT \"U_Kontrol1\",\"U_Kontrol2\",\"U_Kontrol3\" FROM \"@AIF_FSAPKY006_1_1\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(Kontroller);


                if (Kontroller.Rows.Count > 0)
                {
                    txtKontrol1.Text = Kontroller.Rows[0][0].ToString();
                    txtKontrol2.Text = Kontroller.Rows[0][1].ToString();
                    txtKontrol3.Text = Kontroller.Rows[0][2].ToString();
                }
                else
                {
                    txtKontrol1.Text = "";
                    txtKontrol2.Text = "";
                    txtKontrol3.Text = "";
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

                if (txtKontrol3.Text == "Y")
                {
                    btnHayir3.BackColor = buttondefaultrenk;
                    btnEvet3.BackColor = Color.GreenYellow;
                }
                else if (txtKontrol3.Text == "N")
                {
                    btnHayir3.BackColor = Color.OrangeRed;
                    btnEvet3.BackColor = buttondefaultrenk;
                }


                #endregion

                #region dataGridView1

                datagridView1Load();
                ////dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Tank No", typeof(string));
                //dataTable1.Columns.Add("Stand. Süt Miktarı", typeof(string));
                //dataTable1.Columns.Add("Eklenen Krema", typeof(string));
                //dataTable1.Columns.Add("Eklenen Krema PH", typeof(string));
                //dataTable1.Columns.Add("Dolum Sıcaklığı(C)", typeof(string));
                //dataTable1.Columns.Add("Fırınlama Süresi", typeof(string));
                //dataTable1.Columns.Add("Kültürleme Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Kültürleme Saati", typeof(string));
                //dataTable1.Columns.Add("Kullanılan Kültür PH", typeof(string));
                //dataTable1.Columns.Add("Kullanılan Kültür Oranı", typeof(string));
                //dataTable1.Columns.Add("Operatör Personel Adı", typeof(string));

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
                ////dataTable2.Columns.Add("#", "#");
                //dataTable2.Columns.Add("Çiğ Kremanın Yağ Oranı", typeof(string));
                //dataTable2.Columns.Add("Çiğ Krema PH", typeof(string));
                //dataTable2.Columns.Add("Pastörize Kremanın Yağ Oranı", typeof(string));
                //dataTable2.Columns.Add("Pastörize Krema PH", typeof(string)); 
                //dataTable2.Columns.Add("Laboratuvar Personel Adı", typeof(string));

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

                #region Ikinci ekran 1 ve 2.datagrid load 
                //Bu kısım 2. ekrandaki datagridlerin datatable nesnelerini doldurur.
                datagridView1Load_IkinciEkran();
                datagridView2Load_IkinciEkran();
                //Bu kısım 2. ekrandaki datagridlerin datatable nesnelerini doldurur.
                #endregion

                //dtgfSAPKY006_1_1_1Static = dataGridView1;
                //dtgfSAPKY006_1_1_2Static = dataGridView2;
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
        }

        private void btnSagaGit_Click(object sender, EventArgs e)
        {
            _20_FSAPKY_006_1_2 _20_FSAPKY_006_1_2 = new _20_FSAPKY_006_1_2(type, kullaniciid, UretimFisNo, partiNo, UrunTanimi, istasyon, row, tarih1, urunKodu, dtgfSAPKY006_1_1_1_DataTable, dtgfSAPKY006_1_1_2_DataTable, dtgfSAPKY006_1_2_1_DataTable, dtgfSAPKY006_1_2_2_DataTable, txtKontrol1.Text, txtKontrol2.Text, txtKontrol3.Text);
            _20_FSAPKY_006_1_2.ShowDialog();

            if (_20_FSAPKY_006_1_2.geriDonme == "OzeteDon")
            {
                btnOzetEkranaDon.PerformClick();
            } 
        }

        private void datagridView1Load()
        {

            string sql = "SELECT T1.\"U_TankNo\" as \"Tank No\",T1.\"U_StanSutMik\" as \"Stand. Süt Miktarı\",\"U_EklnKrema\" as \"Eklenen Krema\",T1.\"U_EklnKremaPH\" as \"Eklenen Krema PH\",\"U_FirinSuresi\" as \"Fırınlama Süresi\",T1.\"U_KulturSic\" as \"Kültürleme Sıcaklığı\",\"U_KulturSaat\" as \"Kültürleme Saati\",T1.\"U_KullKultPH\" as \"Kullanılan Kültür PH\",T1.\"U_KullKultOr\" as \"Kullanılan Kültür Oranı\",T1.\"U_OprtPersAdi\" as \"Operatör Personel Adı\" FROM \"@AIF_FSAPKY006_1_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY006_1_1_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY006_1_1_1_DataTable);

            //Commit
            dataGridView1.DataSource = dtgfSAPKY006_1_1_1_DataTable;

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

            if (dtgfSAPKY006_1_1_1_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY006_1_1_1_DataTable.NewRow();
                dr["Tank No"] = "";
                dr["Stand. Süt Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Eklenen Krema"] = Convert.ToString("0", cultureTR);
                dr["Eklenen Krema PH"] = Convert.ToString("0", cultureTR);
                dr["Fırınlama Süresi"] = Convert.ToString("0", cultureTR);
                dr["Kültürleme Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Kültürleme Saati"] = "";
                dr["Kullanılan Kültür PH"] = Convert.ToString("0", cultureTR);
                dr["Kullanılan Kültür Oranı"] = Convert.ToString("0", cultureTR);
                dr["Operatör Personel Adı"] = "";

                dtgfSAPKY006_1_1_1_DataTable.Rows.Add(dr);
            }
            dataGridView1.Columns["Operatör Personel Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {

            //string sql = "SELECT T1.\"U_CigKreYagOr\" as \"Çiğ Kremanın Yağ Oranı\",T1.\"U_CigKrePH\" as \"Çiğ Krema PH\",\"U_PasKreYagOr\" as \"Pastörize Kremanın Yağ Oranı\",\"U_PasKrePH\" as \"Pastörize Krema PH\",\"U_LabPersAdi\" as \"Laboratuvar Personel Adı\"  FROM \"@AIF_FSAPKY006_1_1\" AS T0 INNER JOIN \"@AIF_FSAPKY006_1_1_2\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

            #region alanlar değiştirildi 18 şubat 2022
            string sql = "SELECT T1.\"U_StandSutYag\" as \"Standart Süt Yağ\",T1.\"U_StandSutPH\" as \"Standart Süt PH\",\"U_PastSutYag\" as \"Pastörize Süt Yağ\",\"U_PastSutPH\" as \"Pastörize Süt PH\",\"U_LabPersAdi\" as \"Laboratuvar Personel Adı\" FROM \"@AIF_FSAPKY006_1_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY006_1_1_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

            #endregion

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY006_1_1_2_DataTable);

            //Commit
            dataGridView2.DataSource = dtgfSAPKY006_1_1_2_DataTable;

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


            if (dtgfSAPKY006_1_1_2_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY006_1_1_2_DataTable.NewRow();
                //dr["Çiğ Kremanın Yağ Oranı"] = Convert.ToString("0", cultureTR);
                //dr["Çiğ Krema PH"] = Convert.ToString("0", cultureTR);
                //dr["Pastörize Kremanın Yağ Oranı"] = Convert.ToString("0", cultureTR);
                //dr["Pastörize Krema PH"] = Convert.ToString("0", cultureTR);

                dr["Standart Süt Yağ"] = Convert.ToString("0", cultureTR);
                dr["Standart Süt PH"] = Convert.ToString("0", cultureTR);
                dr["Pastörize Süt Yağ"] = Convert.ToString("0", cultureTR);
                dr["Pastörize Süt PH"] = Convert.ToString("0", cultureTR); 
                dr["Laboratuvar Personel Adı"] = "";

                

                dtgfSAPKY006_1_1_2_DataTable.Rows.Add(dr);
            }

            dataGridView2.Columns["Laboratuvar Personel Adı"].ReadOnly = true;
        }

        private void datagridView1Load_IkinciEkran()
        {

            string sql = "SELECT T1.\"U_TankNo\" as \"Tank No\",\"U_PaletNo\" as \"Palet No\",T1.\"U_AnlzSaat1\" as \"1.Analiz(Saat)\",\"U_AnlzSaat2\" as \"2.Analiz(Saat)\",\"U_AnlzSaat3\" as \"3.Analiz(Saat)\",\"U_AnlzSaat4\" as \"4.Analiz(Saat)\", \"U_AnlzSaat5\" as \"5.Analiz(Saat)\", \"U_AnlzPH1\" as \"1.Analiz(PH)\", \"U_AnlzPH2\" as \"2.Analiz(PH)\", \"U_AnlzPH3\" as \"3.Analiz(PH)\", \"U_AnlzPH4\" as \"4.Analiz(PH)\", \"U_AnlzPH5\" as \"5.Analiz(PH)\", \"U_AnlzSic1\" as \"1.Analiz(Sıc(C))\" , \"U_AnlzSic2\" as \"2.Analiz(Sıc(C))\" , \"U_AnlzSic3\" as \"3.Analiz(Sıc(C))\" , \"U_AnlzSic4\" as \"4.Analiz(Sıc(C))\" , \"U_AnlzSic5\" as \"5.Analiz(Sıc(C))\", \"U_SogOdGrSaat\" as \"Soğuk Oda G.Saat\", \"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY006_1_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY006_1_2_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY006_1_2_1_DataTable);

            if (dtgfSAPKY006_1_2_1_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY006_1_2_1_DataTable.NewRow();
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
                dr["Soğuk Oda G.Saat"] = "";
                dr["Operatör Adı"] = "";

                dtgfSAPKY006_1_2_1_DataTable.Rows.Add(dr);
            }
        }

        private void datagridView2Load_IkinciEkran()
        {
            string sql = "SELECT T1.\"U_TankNo\" as \"Tank No\",T1.\"U_InkOdaNo\" as \"İnkübasyon Oda No\",\"U_Saat\" as \"Saat\",T1.\"U_PH\" as \"PH\",\"U_Sicaklik\" as \"Sıcaklık(C)\",\"U_SogOdGrSaat\" as \"Soğuk Oda G.Saat\",\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY006_1_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY006_1_2_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtgfSAPKY006_1_2_2_DataTable);

            if (dtgfSAPKY006_1_2_2_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgfSAPKY006_1_2_2_DataTable.NewRow();
                dr["Tank No"] = "";
                dr["İnkübasyon Oda No"] = "";
                dr["Saat"] = "";
                dr["PH"] = Convert.ToString("0", cultureTR);
                dr["Sıcaklık(C)"] = Convert.ToString("0", cultureTR);
                dr["Soğuk Oda G.Saat"] = "";
                dr["Operatör Adı"] = "";

                dtgfSAPKY006_1_2_2_DataTable.Rows.Add(dr);
            }
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Tank No" || dataGridView1.Columns[e.ColumnIndex].Name == "Stand. Süt Miktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Eklenen Krema" || dataGridView1.Columns[e.ColumnIndex].Name == "Eklenen Krema PH" || dataGridView1.Columns[e.ColumnIndex].Name == "Fırınlama Süresi" || dataGridView1.Columns[e.ColumnIndex].Name == "Kültürleme Sıcaklığı" || dataGridView1.Columns[e.ColumnIndex].Name == "Kullanılan Kültür PH" || dataGridView1.Columns[e.ColumnIndex].Name == "Kullanılan Kültür Oranı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Kültürleme Saati")
            {
                SaatTarihGirisi n = new SaatTarihGirisi(dataGridView1);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Operatör Personel Adı")
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
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Standart Süt Yağ" || dataGridView2.Columns[e.ColumnIndex].Name == "Standart Süt PH" || dataGridView2.Columns[e.ColumnIndex].Name == "Pastörize Süt Yağ" || dataGridView2.Columns[e.ColumnIndex].Name == "Pastörize Süt PH")
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
            //Kontrol1 = txtKontrol1.Text;
            //Kontrol2 = txtKontrol2.Text;
            //Kontrol3 = txtKontrol3.Text;
            tabloyaKaydetmeIslemleri();
            //TabloyaKaydet();
        }


        private void tabloyaKaydetmeIslemleri()
        {
            UVTServiceSoapClient client = new UVTServiceSoapClient();

            FSAPKY006_1_1 nesne = new FSAPKY006_1_1();
            FSAPKY006_1_1_1 fSAPKY006_1_1_1 = new FSAPKY006_1_1_1();
            List<FSAPKY006_1_1_1> fSAPKY006_1_1_1s = new List<FSAPKY006_1_1_1>();

            FSAPKY006_1_1_2 fSAPKY006_1_1_2 = new FSAPKY006_1_1_2();
            List<FSAPKY006_1_1_2> fSAPKY006_1_1_2s = new List<FSAPKY006_1_1_2>();

            FSAPKY006_1_2_1 fSAPKY006_1_2_1 = new FSAPKY006_1_2_1();
            List<FSAPKY006_1_2_1> fSAPKY006_1_2_1s = new List<FSAPKY006_1_2_1>();

            FSAPKY006_1_2_2 fSAPKY006_1_2_2 = new FSAPKY006_1_2_2();
            List<FSAPKY006_1_2_2> fSAPKY006_1_2_2s = new List<FSAPKY006_1_2_2>();

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
            nesne.Kontrol3 = txtKontrol3.Text;
            nesne.Aciklama = "";


            foreach (DataRow dr in dtgfSAPKY006_1_1_1_DataTable.Rows)
            {
                fSAPKY006_1_1_1 = new FSAPKY006_1_1_1();

                fSAPKY006_1_1_1.TankNumarasi = dr["Tank No"] == DBNull.Value ? "" : dr["Tank No"].ToString();
                if (fSAPKY006_1_1_1.TankNumarasi == "")
                {
                    continue;
                }
                fSAPKY006_1_1_1.StandSuMiktari = dr["Stand. Süt Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Stand. Süt Miktarı"]);
                fSAPKY006_1_1_1.EklenenKrema = dr["Eklenen Krema"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Eklenen Krema"]);
                fSAPKY006_1_1_1.EklenenKremaPH = dr["Eklenen Krema PH"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Eklenen Krema PH"]);
                fSAPKY006_1_1_1.FirinlamaSuresi = dr["Fırınlama Süresi"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Fırınlama Süresi"]);
                fSAPKY006_1_1_1.KulturlemeSicakligi = dr["Kültürleme Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kültürleme Sıcaklığı"]);
                fSAPKY006_1_1_1.KulturlemeSaati = dr["Kültürleme Saati"] == DBNull.Value ? "" : dr["Kültürleme Saati"].ToString();
                fSAPKY006_1_1_1.KullanilanKulturPH = dr["Kullanılan Kültür PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kullanılan Kültür PH"]);
                fSAPKY006_1_1_1.KullanilanKulturOrani = dr["Kullanılan Kültür Oranı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kullanılan Kültür Oranı"]);
                fSAPKY006_1_1_1.OperatorPersonelAdi = dr["Operatör Personel Adı"] == DBNull.Value ? "" : dr["Operatör Personel Adı"].ToString();
                fSAPKY006_1_1_1s.Add(fSAPKY006_1_1_1);
            }
            nesne.fSAPKY006_1_1_1s = fSAPKY006_1_1_1s.ToArray();

            foreach (DataRow dr in dtgfSAPKY006_1_1_2_DataTable.Rows)
            {
                fSAPKY006_1_1_2 = new FSAPKY006_1_1_2();
                fSAPKY006_1_1_2.CigKremaYagOrani = dr["Standart Süt Yağ"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Standart Süt Yağ"]);
                fSAPKY006_1_1_2.CigKremaPH = dr["Standart Süt PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Standart Süt PH"]);
                fSAPKY006_1_1_2.PastKremaYagOrani = dr["Pastörize Süt Yağ"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Pastörize Süt Yağ"]);
                fSAPKY006_1_1_2.PastKremaPH = dr["Pastörize Süt PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastörize Süt PH"]);
                fSAPKY006_1_1_2.LabPersonelAdi = dr["Laboratuvar Personel Adı"] == DBNull.Value ? "" : dr["Laboratuvar Personel Adı"].ToString();

                fSAPKY006_1_1_2s.Add(fSAPKY006_1_1_2);
            }

            nesne.fSAPKY006_1_1_2s = fSAPKY006_1_1_2s.ToArray();


            foreach (DataRow dr in dtgfSAPKY006_1_2_1_DataTable.Rows)
            {
                fSAPKY006_1_2_1 = new FSAPKY006_1_2_1();
                fSAPKY006_1_2_1.TankNumarasi = dr["Tank No"] == DBNull.Value ? "" : dr["Tank No"].ToString();
                fSAPKY006_1_2_1.PaletNumarasi = dr["Palet No"] == DBNull.Value ? "" : dr["Palet No"].ToString();
                fSAPKY006_1_2_1.BirinciAnalizSaat = dr["1.Analiz(Saat)"] == DBNull.Value ? "" : dr["1.Analiz(Saat)"].ToString();
                fSAPKY006_1_2_1.IkinciAnalizSaat = dr["2.Analiz(Saat)"] == DBNull.Value ? "" : dr["2.Analiz(Saat)"].ToString();
                fSAPKY006_1_2_1.UcuncuAnalizSaat = dr["3.Analiz(Saat)"] == DBNull.Value ? "" : dr["3.Analiz(Saat)"].ToString();
                fSAPKY006_1_2_1.DorduncuAnalizSaat = dr["4.Analiz(Saat)"] == DBNull.Value ? "" : dr["4.Analiz(Saat)"].ToString();
                fSAPKY006_1_2_1.BesinciAnalizSaat = dr["5.Analiz(Saat)"] == DBNull.Value ? "" : dr["5.Analiz(Saat)"].ToString();
                fSAPKY006_1_2_1.BirinciAnalizPH = dr["1.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["1.Analiz(PH)"]);
                fSAPKY006_1_2_1.IkinciAnalizPH = dr["2.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["2.Analiz(PH)"]);
                fSAPKY006_1_2_1.UcuncuAnalizPH = dr["3.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["3.Analiz(PH)"]);
                fSAPKY006_1_2_1.DorduncuAnalizPH = dr["4.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["4.Analiz(PH)"]);
                fSAPKY006_1_2_1.BesinciAnalizPH = dr["5.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["5.Analiz(PH)"]);
                fSAPKY006_1_2_1.BirinciAnalizSicaklik = dr["1.Analiz(Sıc(C))"] == DBNull.Value ? 0 : Convert.ToDouble(dr["1.Analiz(Sıc(C))"]);
                fSAPKY006_1_2_1.IkinciAnalizSicaklik = dr["2.Analiz(Sıc(C))"] == DBNull.Value ? 0 : Convert.ToDouble(dr["2.Analiz(Sıc(C))"]);
                fSAPKY006_1_2_1.UcuncuAnalizSicaklik = dr["3.Analiz(Sıc(C))"] == DBNull.Value ? 0 : Convert.ToDouble(dr["3.Analiz(Sıc(C))"]);
                fSAPKY006_1_2_1.DorduncuAnalizSicaklik = dr["4.Analiz(Sıc(C))"] == DBNull.Value ? 0 : Convert.ToDouble(dr["4.Analiz(Sıc(C))"]);
                fSAPKY006_1_2_1.BesinciAnalizSicaklik = dr["5.Analiz(Sıc(C))"] == DBNull.Value ? 0 : Convert.ToDouble(dr["5.Analiz(Sıc(C))"]);

                fSAPKY006_1_2_1.SogukOdaGirisSaati = dr["Soğuk Oda G.Saat"] == DBNull.Value ? "" : dr["Soğuk Oda G.Saat"].ToString();
                fSAPKY006_1_2_1.OperatorAdi = dr["Operatör Adı"] == DBNull.Value ? "" : dr["Operatör Adı"].ToString();

                fSAPKY006_1_2_1s.Add(fSAPKY006_1_2_1);
            }

            nesne.fSAPKY006_1_2_1s = fSAPKY006_1_2_1s.ToArray();



            foreach (DataRow dr in dtgfSAPKY006_1_2_2_DataTable.Rows)
            {
                fSAPKY006_1_2_2 = new FSAPKY006_1_2_2();
                fSAPKY006_1_2_2.TankNumarasi = dr["Tank No"] == DBNull.Value ? "" : dr["Tank No"].ToString();
                fSAPKY006_1_2_2.InkubasyonOdaNo = dr["İnkübasyon Oda No"] == DBNull.Value ? "" : dr["İnkübasyon Oda No"].ToString();
                fSAPKY006_1_2_2.Saat = dr["Saat"] == DBNull.Value ? "" : dr["Saat"].ToString();
                fSAPKY006_1_2_2.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                fSAPKY006_1_2_2.Sicaklik = dr["Sıcaklık(C)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Sıcaklık(C)"]);
                fSAPKY006_1_2_2.SogOdGrSaat = dr["Soğuk Oda G.Saat"] == DBNull.Value ? "" : dr["Soğuk Oda G.Saat"].ToString();
                fSAPKY006_1_2_2.OperatorAdi = dr["Operatör Adı"] == DBNull.Value ? "" : dr["Operatör Adı"].ToString();

                fSAPKY006_1_2_2s.Add(fSAPKY006_1_2_2);
            }

            nesne.fSAPKY006_1_2_2s = fSAPKY006_1_2_2s.ToArray();

            var resp = client.addOrUpdateFSAPKY006_1_1(nesne, Giris.dbName, Giris.mKodValue);

            CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

            if (resp.Value == 0)
            {
                btnOzet.PerformClick();
            }
        }

        public static void TabloyaKaydet()
        {

            //try
            //{


            //    fSAPKY006_1_1_1s = new List<FSAPKY006_1_1_1>();
            //    fSAPKY006_1_1_2s = new List<FSAPKY006_1_1_2>();
            //    fSAPKY006_1_2_1s = new List<FSAPKY006_1_2_1>();
            //    fSAPKY006_1_2_2s = new List<FSAPKY006_1_2_2>();


            //    nesne.PartiNo = partiNo;
            //    nesne.UrunKodu = urunKodu;
            //    nesne.UrunTanimi = UrunTanimi;
            //    nesne.Tarih = tarih1;
            //    nesne.Kontrol1 = Kontrol1;
            //    nesne.Kontrol2 = Kontrol2;
            //    nesne.Kontrol3 = Kontrol3;
            //    nesne.Aciklama = "";

            //    foreach (DataGridViewRow dr in dtgfSAPKY006_1_1_1Static.Rows)
            //    {
            //        fSAPKY006_1_1_1 = new FSAPKY006_1_1_1();

            //        fSAPKY006_1_1_1.TankNumarasi = dr.Cells["Tank No"].Value == DBNull.Value ? "" : dr.Cells["Tank No"].Value.ToString();
            //        if (fSAPKY006_1_1_1.TankNumarasi == "")
            //        {
            //            continue;
            //        }
            //        fSAPKY006_1_1_1.StandSuMiktari = dr.Cells["Stand. Süt Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Stand. Süt Miktarı"].Value);
            //        fSAPKY006_1_1_1.EklenenKrema = dr.Cells["Eklenen Krema"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Eklenen Krema"].Value);
            //        fSAPKY006_1_1_1.EklenenKremaPH = dr.Cells["Eklenen Krema PH"].Value == DBNull.Value ? 0 : Convert.ToInt32(dr.Cells["Eklenen Krema PH"].Value);
            //        fSAPKY006_1_1_1.FirinlamaSuresi = dr.Cells["Fırınlama Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Fırınlama Süresi"].Value);
            //        fSAPKY006_1_1_1.KulturlemeSicakligi = dr.Cells["Kültürleme Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kültürleme Sıcaklığı"].Value);
            //        fSAPKY006_1_1_1.KulturlemeSaati = dr.Cells["Kültürleme Saati"].Value == DBNull.Value ? "" : dr.Cells["Kültürleme Saati"].Value.ToString();
            //        fSAPKY006_1_1_1.KullanilanKulturPH = dr.Cells["Kullanılan Kültür PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kullanılan Kültür PH"].Value);
            //        fSAPKY006_1_1_1.KullanilanKulturOrani = dr.Cells["Kullanılan Kültür Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kullanılan Kültür Oranı"].Value);
            //        fSAPKY006_1_1_1.OperatorPersonelAdi = dr.Cells["Operatör Personel Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Personel Adı"].Value.ToString();
            //        fSAPKY006_1_1_1s.Add(fSAPKY006_1_1_1);
            //    }

            //    nesne.fSAPKY006_1_1_1s = fSAPKY006_1_1_1s.ToArray();

            //    foreach (DataGridViewRow dr in dtgfSAPKY006_1_1_2Static.Rows)
            //    {
            //        fSAPKY006_1_1_2 = new FSAPKY006_1_1_2();
            //        fSAPKY006_1_1_2.CigKremaYagOrani = dr.Cells["Çiğ Kremanın Yağ Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Kremanın Yağ Oranı"].Value);
            //        fSAPKY006_1_1_2.CigKremaPH = dr.Cells["Çiğ Krema PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Krema PH"].Value);
            //        fSAPKY006_1_1_2.PastKremaYagOrani = dr.Cells["Pastörize Kremanın Yağ Oranı"].Value == DBNull.Value ? 0 : Convert.ToInt32(dr.Cells["Pastörize Kremanın Yağ Oranı"].Value);
            //        fSAPKY006_1_1_2.PastKremaPH = dr.Cells["Pastörize Krema PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastörize Krema PH"].Value);
            //        fSAPKY006_1_1_2.LabPersonelAdi = dr.Cells["Laboratuvar Personel Adı"].Value == DBNull.Value ? "" : dr.Cells["Laboratuvar Personel Adı"].Value.ToString();

            //        fSAPKY006_1_1_2s.Add(fSAPKY006_1_1_2);
            //    }

            //    nesne.fSAPKY006_1_1_2s = fSAPKY006_1_1_2s.ToArray();

            //    foreach (DataGridViewRow dr in dtgfSAPKY006_1_2_1Static.Rows)
            //    {
            //        fSAPKY006_1_2_1 = new FSAPKY006_1_2_1();
            //        fSAPKY006_1_2_1.TankNumarasi = dr.Cells["Tank No"].Value == DBNull.Value ? "" : dr.Cells["Tank No"].Value.ToString();
            //        fSAPKY006_1_2_1.PaletNumarasi = dr.Cells["Palet No"].Value == DBNull.Value ? "" : dr.Cells["Palet No"].Value.ToString();
            //        fSAPKY006_1_2_1.BirinciAnalizSaat = dr.Cells["1.Analiz(Saat)"].Value == DBNull.Value ? "" : dr.Cells["1.Analiz(Saat)"].Value.ToString();
            //        fSAPKY006_1_2_1.IkinciAnalizSaat = dr.Cells["2.Analiz(Saat)"].Value == DBNull.Value ? "" : dr.Cells["2.Analiz(Saat)"].Value.ToString();
            //        fSAPKY006_1_2_1.UcuncuAnalizSaat = dr.Cells["3.Analiz(Saat)"].Value == DBNull.Value ? "" : dr.Cells["3.Analiz(Saat)"].Value.ToString();
            //        fSAPKY006_1_2_1.DorduncuAnalizSaat = dr.Cells["4.Analiz(Saat)"].Value == DBNull.Value ? "" : dr.Cells["4.Analiz(Saat)"].Value.ToString();
            //        fSAPKY006_1_2_1.BesinciAnalizSaat = dr.Cells["5.Analiz(Saat)"].Value == DBNull.Value ? "" : dr.Cells["5.Analiz(Saat)"].Value.ToString();
            //        fSAPKY006_1_2_1.BirinciAnalizPH = dr.Cells["1.Analiz(PH)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["1.Analiz(PH)"].Value);
            //        fSAPKY006_1_2_1.IkinciAnalizPH = dr.Cells["2.Analiz(PH)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["2.Analiz(PH)"].Value);
            //        fSAPKY006_1_2_1.UcuncuAnalizPH = dr.Cells["3.Analiz(PH)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["3.Analiz(PH)"].Value);
            //        fSAPKY006_1_2_1.DorduncuAnalizPH = dr.Cells["4.Analiz(PH)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["4.Analiz(PH)"].Value);
            //        fSAPKY006_1_2_1.BesinciAnalizPH = dr.Cells["5.Analiz(PH)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["5.Analiz(PH)"].Value);
            //        fSAPKY006_1_2_1.BirinciAnalizSicaklik = dr.Cells["1.Analiz(Sıc(C))"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["1.Analiz(Sıc(C))"].Value);
            //        fSAPKY006_1_2_1.IkinciAnalizSicaklik = dr.Cells["2.Analiz(Sıc(C))"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["2.Analiz(Sıc(C))"].Value);
            //        fSAPKY006_1_2_1.UcuncuAnalizSicaklik = dr.Cells["3.Analiz(Sıc(C))"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["3.Analiz(Sıc(C))"].Value);
            //        fSAPKY006_1_2_1.DorduncuAnalizSicaklik = dr.Cells["4.Analiz(Sıc(C))"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["4.Analiz(Sıc(C))"].Value);
            //        fSAPKY006_1_2_1.BesinciAnalizSicaklik = dr.Cells["5.Analiz(Sıc(C))"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["5.Analiz(Sıc(C))"].Value);

            //        fSAPKY006_1_2_1.SogukOdaGirisSaati = dr.Cells["Soğuk Oda G.Saat"].Value == DBNull.Value ? "" : dr.Cells["Soğuk Oda G.Saat"].Value.ToString();
            //        fSAPKY006_1_2_1.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

            //        fSAPKY006_1_2_1s.Add(fSAPKY006_1_2_1);
            //    }

            //    nesne.fSAPKY006_1_2_1s = fSAPKY006_1_2_1s.ToArray();


            //    foreach (DataGridViewRow dr in dtgfSAPKY006_1_2_2Static.Rows)
            //    {
            //        fSAPKY006_1_2_2 = new FSAPKY006_1_2_2();
            //        fSAPKY006_1_2_2.TankNumarasi = dr.Cells["Tank No"].Value == DBNull.Value ? "" : dr.Cells["Tank No"].Value.ToString();
            //        fSAPKY006_1_2_2.InkubasyonOdaNo = dr.Cells["İnkübasyon Oda No"].Value == DBNull.Value ? "" : dr.Cells["İnkübasyon Oda No"].Value.ToString();
            //        fSAPKY006_1_2_2.Saat = dr.Cells["Saat"].Value == DBNull.Value ? "" : dr.Cells["Saat"].Value.ToString();
            //        fSAPKY006_1_2_2.PH = dr.Cells["PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH"].Value);
            //        fSAPKY006_1_2_2.Sicaklik = dr.Cells["Sıcaklık(C)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Sıcaklık(C)"].Value);
            //        fSAPKY006_1_2_2.SogOdGrSaat = dr.Cells["Soğuk Oda G.Saat"].Value == DBNull.Value ? "" : dr.Cells["Soğuk Oda G.Saat"].Value.ToString();
            //        fSAPKY006_1_2_2.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

            //        fSAPKY006_1_2_2s.Add(fSAPKY006_1_2_2);
            //    }

            //    nesne.fSAPKY006_1_2_2s = fSAPKY006_1_2_2s.ToArray();

            //    var resp = client.addOrUpdateFSAPKY006_1_1(nesne, Giris.dbName, Giris.mKodValue);

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

        private void btnEvet3_Click(object sender, EventArgs e)
        {
            btnHayir3.BackColor = buttondefaultrenk;
            btnEvet3.BackColor = Color.GreenYellow;
            txtKontrol3.Text = "Y";
        }
        private void btnHayir3_Click(object sender, EventArgs e)
        {
            btnHayir3.BackColor = Color.OrangeRed;
            btnEvet3.BackColor = buttondefaultrenk;
            txtKontrol3.Text = "N";
        }

        private void txtUretimTarihi_Click(object sender, EventArgs e)
        {
            TarihGirisi tarihGirisi = new TarihGirisi(null, txtUretimTarihi);
            tarihGirisi.ShowDialog();
        }
    }
}

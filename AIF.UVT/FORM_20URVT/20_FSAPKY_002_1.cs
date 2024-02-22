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
    public partial class _20_FSAPKY_002_1 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_002_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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
        DataTable dataTable3 = new DataTable();
        DataTable dataTable4 = new DataTable();
        private string UretimFisNo = "";
        private string partiNo = "";
        private string istasyon = "";
        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private string urunKodu = "";
        private int row = 0;
        private SqlCommand cmd = null;
        private string tarih1 = "";
        Color buttondefaultrenk = Color.Gray;
        private void _20_FSAPKY_002_1_Load(object sender, EventArgs e)
        {
            txtPartiNo.Text = partiNo;
            txtUretimFisNo.Text = UretimFisNo;
            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);

            txtUrunTanimi.Text = UrunTanimi;

            buttondefaultrenk = btnEvet.BackColor;

            #region Kontrol yapıldı mı sorgusu

            DataTable dtDgrKltKontrol = new DataTable();


            string sql = "SELECT \"U_Kontrol\" FROM \"@AIF_FSAPKY002_1\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dtDgrKltKontrol);


            if (dtDgrKltKontrol.Rows.Count > 0)
            {
                txtKontrol.Text = dtDgrKltKontrol.Rows[0][0].ToString();
            }
            else
            {
                txtKontrol.Text = "";
            }



            if (txtKontrol.Text == "Y")
            {
                btnHayir.BackColor = buttondefaultrenk;
                btnEvet.BackColor = Color.GreenYellow;
            }
            else if (txtKontrol.Text == "N")
            {
                btnHayir.BackColor = Color.OrangeRed;
                btnEvet.BackColor = buttondefaultrenk;
            }

            #endregion

            richTextBox1.Text = "Kültürün kontrolü yapılmıştır. Bir fiziksel deformasyon ve bulaşma söz konusu değildir. Saklama koşulları sağlanmıştır.Hayır ise Uygun olmayan ürün prosedürünü uygulayınız";

            try
            {
                #region dataGridView1 

                datagridView1Load();
                //dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Proses Tank No", typeof(string));
                //dataTable1.Columns.Add("Teleme Sütü Miktarı", typeof(string));
                //dataTable1.Columns.Add("Mayalama Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Mayalama Saati", typeof(string));
                //dataTable1.Columns.Add("Kırım Saati", typeof(string));
                //dataTable1.Columns.Add("Kırım PH", typeof(string));
                //dataTable1.Columns.Add("Kaşar Prosesi Personeli Adı", typeof(string));

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
                //dataTable2.Columns.Add("Teleme Süt PH", typeof(string));
                //dataTable2.Columns.Add("Teleme Süt SH", typeof(string));
                //dataTable2.Columns.Add("Teleme Süt KM", typeof(string));
                //dataTable2.Columns.Add("Teleme Süt Yağ", typeof(string));
                //dataTable2.Columns.Add("Teleme Yağı", typeof(string));
                //dataTable2.Columns.Add("Teleme Kuru Madde", typeof(string));
                //dataTable2.Columns.Add("Teleme PH", typeof(string));
                //dataTable2.Columns.Add("Laboratuvar Personel Adı", typeof(string));

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

                #region dataGridView3

                datagridView3Load();
                //dataTable3.Columns.Add("#", "#");
                //dataTable3.Columns.Add("Çedarlama Sıcaklığı", typeof(string));
                //dataTable3.Columns.Add("Çedarlama Başlangıç Saati", typeof(string));
                //dataTable3.Columns.Add("Çedarlama Bitiş Saati", typeof(string));
                //dataTable3.Columns.Add("İndirme Başlangıç Saati", typeof(string));
                //dataTable3.Columns.Add("İndirme Bitiş Saati", typeof(string));
                //dataTable3.Columns.Add("İndirme PH", typeof(string));

                //dataTable3.Rows.Add("");
                //dataGridView3.DataSource = dataTable3;

                //dataGridView3.AllowUserToAddRows = false;
                //dataGridView3.AllowUserToDeleteRows = false;
                //dataGridView3.AllowUserToResizeColumns = false;
                //dataGridView3.AllowUserToResizeRows = false;
                //dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 191, 143);
                //dataGridView3.DefaultCellStyle.BackColor = Color.FromArgb(220, 230, 241);

                //dataGridView3.EnableHeadersVisualStyles = false;
                //dataGridView3.RowHeadersVisible = false;

                //dataGridView3.ColumnHeadersHeight = 50;
                //dataGridView3.RowTemplate.Height = 40;

                //foreach (DataGridViewColumn column in dataGridView3.Columns)
                //{
                //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                //    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //    column.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                //}
                #endregion

                #region dataGridView4

                datagridView4Load();
                //dataTable4.Columns.Add("#", "#");
                //dataTable4.Columns.Add("Pıhtı Süresi", typeof(string));
                //dataTable4.Columns.Add("Çedarlama Süresi", typeof(string));
                //dataTable4.Columns.Add("İndirme Süresi", typeof(string));
                //dataTable4.Columns.Add("Toplam Süre", typeof(string));
                //dataTable4.Columns.Add("Teleme Randımanı", typeof(string));

                //dataTable4.Rows.Add("");
                //dataGridView4.DataSource = dataTable4;

                //dataGridView4.AllowUserToAddRows = false;
                //dataGridView4.AllowUserToDeleteRows = false;
                //dataGridView4.AllowUserToResizeColumns = false;
                //dataGridView4.AllowUserToResizeRows = false;
                //dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(49, 134, 155);
                //dataGridView4.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
                //dataGridView4.DefaultCellStyle.BackColor = Color.FromArgb(220, 230, 241);

                //dataGridView4.EnableHeadersVisualStyles = false;
                //dataGridView4.RowHeadersVisible = false;

                //dataGridView4.ColumnHeadersHeight = 50;
                //dataGridView4.RowTemplate.Height = 40; 

                //foreach (DataGridViewColumn column in dataGridView4.Columns)
                //{
                //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                //    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //    column.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                //}
                #endregion
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");
            }

            dataGridView1.Rows[0].Height = dataGridView1.Height - dataGridView1.ColumnHeadersHeight;

        }
        //public static string geriDonme2 = "";

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {

            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
            //_20_ANALIZ_EKRANLARI _20_ANALIZ_EKRANLARI = new _20_ANALIZ_EKRANLARI();
            //_20_ANALIZ_EKRANLARI.Show();
            //Close();
        }

        private void datagridView1Load()
        {

            string sql = "SELECT T1.\"U_ProsTnkNo\" as \"Proses Tank No\",T1.\"U_TelemeSutMik\" as \"Teleme Sütü Miktarı\",\"U_MayaSicaklik\" as \"Mayalama Sıcaklığı\",T1.\"U_MayalamaSaati\" as \"Mayalama Saati\",\"U_KirimSaati\" as \"Kırım Saati\",T1.\"U_KirimPH\" as \"Kırım PH\",\"U_ProsPersAdi\" as \"Kaşar Prosesi Personeli Adı\" FROM \"@AIF_FSAPKY002_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY002_1_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataTable1);

            //Commit
            dataGridView1.DataSource = dataTable1;

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

            if (dataTable1.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dataTable1.NewRow();
                dr["Proses Tank No"] = "";
                dr["Teleme Sütü Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Mayalama Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Mayalama Saati"] = "";
                dr["Kırım Saati"] = "";
                dr["Kırım PH"] = Convert.ToString("0", cultureTR);
                dr["Kaşar Prosesi Personeli Adı"] = "";
                dataTable1.Rows.Add(dr);
            }

            dataGridView1.Columns["Kaşar Prosesi Personeli Adı"].ReadOnly = true;

            //dataGridView1.Columns["Ürün Kodu"].Visible = false;
        }

        private void datagridView2Load()
        {
            string sql = "SELECT T1.\"U_TelemeSutPH\" as \"Teleme Süt PH\",T1.\"U_TelemeSutSH\" as \"Teleme Süt SH\",\"U_TelemeSutKM\" as \"Teleme Süt KM\",T1.\"U_TelemeSutYag\" as \"Teleme Süt Yağ\",\"U_TelemeYag\" as \"Teleme Yağ\",\"U_TelemeKurMad\" as \"Teleme Kuru Madde\",\"U_TelemePH\" as \"Teleme PH\",\"U_LabPersAdi\" as \"Laboratuvar Personel Adı\" FROM \"@AIF_FSAPKY002_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY002_1_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";


            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataTable2);

            //Commit
            dataGridView2.DataSource = dataTable2;

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


            if (dataTable2.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dataTable2.NewRow();
                dr["Teleme Süt PH"] = Convert.ToString("0", cultureTR);
                dr["Teleme Süt SH"] = Convert.ToString("0", cultureTR);
                dr["Teleme Süt KM"] = Convert.ToString("0", cultureTR);
                dr["Teleme Süt Yağ"] = Convert.ToString("0", cultureTR);
                dr["Teleme Yağ"] = Convert.ToString("0", cultureTR);
                dr["Teleme Kuru Madde"] = Convert.ToString("0", cultureTR);
                dr["Teleme PH"] = Convert.ToString("0", cultureTR);
                dr["Laboratuvar Personel Adı"] = "";

                dataTable2.Rows.Add(dr);
            }

            dataGridView2.Columns["Laboratuvar Personel Adı"].ReadOnly = true;

            //dataGridView2.Columns["Ürün Kodu"].Visible = false;
        }

        private void datagridView3Load()
        {

            string sql = "SELECT T1.\"U_CedarSicaklik\" as \"Çedarlama Sıcaklığı\",T1.\"U_CedarBasSaat\" as \"Çedarlama Başlangıç Saati\",\"U_CedarBitSaat\" as \"Çedarlama Bitiş Saati\",T1.\"U_IndrmeBasSaat\" as \"İndirme Başlangıç Saati\",\"U_IndrmeBitSaat\" as \"İndirme Bitiş Saati\",T1.\"U_IndirmePH\" as \"İndirme PH\" FROM \"@AIF_FSAPKY002_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY002_1_3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataTable3);

            //Commit
            dataGridView3.DataSource = dataTable3;

            dataGridView3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView3.AllowUserToAddRows = false;
            dataGridView3.AllowUserToDeleteRows = false;
            dataGridView3.AllowUserToResizeColumns = false;
            dataGridView3.AllowUserToResizeRows = false;
            dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 191, 143);
            dataGridView3.DefaultCellStyle.BackColor = Color.WhiteSmoke;

            dataGridView3.EnableHeadersVisualStyles = false;
            dataGridView3.RowHeadersVisible = false;

            dataGridView3.ColumnHeadersHeight = 50;
            dataGridView3.RowTemplate.Height = 40;

            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            if (dataTable3.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dataTable3.NewRow();
                dr["Çedarlama Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Çedarlama Başlangıç Saati"] = "";
                dr["Çedarlama Bitiş Saati"] = "";
                dr["İndirme Başlangıç Saati"] = "";
                dr["İndirme Bitiş Saati"] = "";
                dr["İndirme PH"] = Convert.ToString("0", cultureTR);

                dataTable3.Rows.Add(dr);
            }


            //dataGridView1.Columns["Ürün Kodu"].Visible = false;
        }

        private void datagridView4Load()
        {

            string sql = "SELECT T1.\"U_PihtiSuresi\" as \"Pıhtı Süresi\",T1.\"U_CedarSuresi\" as \"Çedarlama Süresi\",\"U_IndrmeSuresi\" as \"İndirme Süresi\",T1.\"U_ToplamSure\" as \"Toplam Süre\",\"U_TelemeRand\" as \"Teleme Randımanı\" FROM \"@AIF_FSAPKY002_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY002_1_4\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";


            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataTable4);

            //Commit
            dataGridView4.DataSource = dataTable4;

            dataGridView4.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dataGridView4.AllowUserToAddRows = false;
            dataGridView4.AllowUserToDeleteRows = false;
            dataGridView4.AllowUserToResizeColumns = false;
            dataGridView4.AllowUserToResizeRows = false;
            dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 191, 143);
            dataGridView4.DefaultCellStyle.BackColor = Color.WhiteSmoke;

            dataGridView4.EnableHeadersVisualStyles = false;
            dataGridView4.RowHeadersVisible = false;

            dataGridView4.ColumnHeadersHeight = 50;
            dataGridView4.RowTemplate.Height = 40;

            foreach (DataGridViewColumn column in dataGridView4.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                column.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }



            if (dataTable4.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dataTable4.NewRow();
                dr["Pıhtı Süresi"] = Convert.ToString("0", cultureTR);
                dr["Çedarlama Süresi"] = Convert.ToString("0", cultureTR);
                dr["İndirme Süresi"] = Convert.ToString("0", cultureTR);
                dr["Toplam Süre"] = Convert.ToString("0", cultureTR);
                dr["Teleme Randımanı"] = Convert.ToString("0", cultureTR);

                dataTable4.Rows.Add(dr);
            }

            //dataGridView2.Columns["Ürün Kodu"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Proses Tank No" || dataGridView1.Columns[e.ColumnIndex].Name == "Teleme Sütü Miktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Mayalama Sıcaklığı" || dataGridView1.Columns[e.ColumnIndex].Name == "Kırım PH")
            {
                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Mayalama Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Kırım Saati")
            {
                //    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, true);
                //    //n.ShowDialog();

                SaatTarihGirisi n = new SaatTarihGirisi(dataGridView1);
                n.ShowDialog();
            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Kaşar Prosesi Personeli Adı")
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
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Teleme Süt PH" || dataGridView2.Columns[e.ColumnIndex].Name == "Teleme Süt SH" || dataGridView2.Columns[e.ColumnIndex].Name == "Teleme Süt KM" || dataGridView2.Columns[e.ColumnIndex].Name == "Teleme Süt Yağ" || dataGridView2.Columns[e.ColumnIndex].Name == "Teleme Yağ" || dataGridView2.Columns[e.ColumnIndex].Name == "Teleme Kuru Madde" || dataGridView2.Columns[e.ColumnIndex].Name == "Teleme PH")
            {
                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
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

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex].Name == "Çedarlama Sıcaklığı" || dataGridView3.Columns[e.ColumnIndex].Name == "İndirme PH")
            {
                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView3, false);
                n.ShowDialog();
            }
            else if (dataGridView3.Columns[e.ColumnIndex].Name == "Çedarlama Başlangıç Saati" || dataGridView3.Columns[e.ColumnIndex].Name == "Çedarlama Başlangıç Saati" || dataGridView3.Columns[e.ColumnIndex].Name == "Çedarlama Bitiş Saati" || dataGridView3.Columns[e.ColumnIndex].Name == "İndirme Başlangıç Saati" || dataGridView3.Columns[e.ColumnIndex].Name == "İndirme Bitiş Saati")
            {
                SaatTarihGirisi n = new SaatTarihGirisi(dataGridView3);
                n.ShowDialog();
            }
        }

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.Columns[e.ColumnIndex].Name == "Pıhtı Süresi" || dataGridView4.Columns[e.ColumnIndex].Name == "Çedarlama Süresi" || dataGridView4.Columns[e.ColumnIndex].Name == "İndirme Süresi" || dataGridView4.Columns[e.ColumnIndex].Name == "Toplam Süre" || dataGridView4.Columns[e.ColumnIndex].Name == "Teleme Randımanı")
            {
                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView4, false);
                n.ShowDialog();
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            UVTServiceSoapClient client = new UVTServiceSoapClient();
            FSAPKY002_1 fSAPKY002_1 = new FSAPKY002_1();

            FSAPKY002_1_1 fSAPKY002_1_1 = new FSAPKY002_1_1();
            List<FSAPKY002_1_1> fSAPKY002_1_1s = new List<FSAPKY002_1_1>();



            FSAPKY002_1_2 fSAPKY002_1_2 = new FSAPKY002_1_2();
            List<FSAPKY002_1_2> fSAPKY002_1_2s = new List<FSAPKY002_1_2>();



            FSAPKY002_1_3 fSAPKY002_1_3 = new FSAPKY002_1_3();
            List<FSAPKY002_1_3> fSAPKY002_1_3s = new List<FSAPKY002_1_3>();



            FSAPKY002_1_4 fSAPKY002_1_4 = new FSAPKY002_1_4();
            List<FSAPKY002_1_4> fSAPKY002_1_4s = new List<FSAPKY002_1_4>();



            fSAPKY002_1.PartiNo = txtPartiNo.Text;
            fSAPKY002_1.UrunTanimi = txtUrunTanimi.Text;

            #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
            //fSAPKY002_1.Tarih = tarih1;
            DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            fSAPKY002_1.Tarih = uretimtarihi.ToString("yyyyMMdd");
            #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

            fSAPKY002_1.Aciklama = "";
            fSAPKY002_1.UrunKodu = urunKodu;
            fSAPKY002_1.Kontrol = txtKontrol.Text;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                fSAPKY002_1_1 = new FSAPKY002_1_1();
                fSAPKY002_1_1.ProsesTankNo = dr.Cells["Proses Tank No"].Value == DBNull.Value ? "" : dr.Cells["Proses Tank No"].Value.ToString();
                fSAPKY002_1_1.TelemeSutMiktari = dr.Cells["Teleme Sütü Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Teleme Sütü Miktarı"].Value);
                fSAPKY002_1_1.MayalamaSicakligi = dr.Cells["Mayalama Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Mayalama Sıcaklığı"].Value);
                fSAPKY002_1_1.MayalamaSaati = dr.Cells["Mayalama Saati"].Value == DBNull.Value ? "" : dr.Cells["Mayalama Saati"].Value.ToString();
                fSAPKY002_1_1.KirimSaati = dr.Cells["Kırım Saati"].Value == DBNull.Value ? "" : dr.Cells["Kırım Saati"].Value.ToString();
                fSAPKY002_1_1.KirimPH = dr.Cells["Kırım PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kırım PH"].Value);
                fSAPKY002_1_1.ProsesPersonelAdi = dr.Cells["Kaşar Prosesi Personeli Adı"].Value == DBNull.Value ? "" : dr.Cells["Kaşar Prosesi Personeli Adı"].Value.ToString();

                fSAPKY002_1_1s.Add(fSAPKY002_1_1);
            }

            fSAPKY002_1.fSAPKY002_1_1s = fSAPKY002_1_1s.ToArray();

            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                fSAPKY002_1_2 = new FSAPKY002_1_2();

                fSAPKY002_1_2.TelemeSutPH = dr.Cells["Teleme Süt PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Teleme Süt PH"].Value);
                fSAPKY002_1_2.TelemeSutSH = dr.Cells["Teleme Süt SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Teleme Süt SH"].Value);
                fSAPKY002_1_2.TelemeSutKM = dr.Cells["Teleme Süt KM"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Teleme Süt KM"].Value);
                fSAPKY002_1_2.TelemeSutYagi = dr.Cells["Teleme Süt Yağ"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Teleme Süt Yağ"].Value);
                fSAPKY002_1_2.TelemeKuruMadde = dr.Cells["Teleme Kuru Madde"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Teleme Kuru Madde"].Value);
                fSAPKY002_1_2.TelemePH = dr.Cells["Teleme PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Teleme PH"].Value);
                fSAPKY002_1_2.LabPersonelAdi = dr.Cells["Laboratuvar Personel Adı"].Value == DBNull.Value ? "" : dr.Cells["Laboratuvar Personel Adı"].Value.ToString();


                fSAPKY002_1_2s.Add(fSAPKY002_1_2);
            }

            fSAPKY002_1.fSAPKY002_1_2s = fSAPKY002_1_2s.ToArray();


            foreach (DataGridViewRow dr in dataGridView3.Rows)
            {
                fSAPKY002_1_3 = new FSAPKY002_1_3();

                fSAPKY002_1_3.CedarlamaSicakligi = dr.Cells["Çedarlama Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çedarlama Sıcaklığı"].Value);
                fSAPKY002_1_3.CedarlamaBasSaati = dr.Cells["Çedarlama Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Çedarlama Başlangıç Saati"].Value.ToString();
                fSAPKY002_1_3.CedarlamaBitSaati = dr.Cells["Çedarlama Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Çedarlama Bitiş Saati"].Value.ToString();
                fSAPKY002_1_3.IndirmeBasSaat = dr.Cells["İndirme Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["İndirme Başlangıç Saati"].Value.ToString();
                fSAPKY002_1_3.IndirmeBitSaat = dr.Cells["İndirme Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["İndirme Bitiş Saati"].Value.ToString();
                fSAPKY002_1_3.IndirmePH = dr.Cells["İndirme PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["İndirme PH"].Value);


                fSAPKY002_1_3s.Add(fSAPKY002_1_3);
            }
            fSAPKY002_1.fSAPKY002_1_3s = fSAPKY002_1_3s.ToArray();

            foreach (DataGridViewRow dr in dataGridView4.Rows)
            {
                fSAPKY002_1_4 = new FSAPKY002_1_4();

                fSAPKY002_1_4.PihtiSuresi = dr.Cells["Pıhtı Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pıhtı Süresi"].Value);
                fSAPKY002_1_4.CedarlamaSuresi = dr.Cells["Çedarlama Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çedarlama Süresi"].Value);
                fSAPKY002_1_4.IndirmeSuresi = dr.Cells["İndirme Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["İndirme Süresi"].Value);
                fSAPKY002_1_4.ToplamSure = dr.Cells["Toplam Süre"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Süre"].Value);
                fSAPKY002_1_4.TelemeRandimani = dr.Cells["Teleme Randımanı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Teleme Randımanı"].Value);


                fSAPKY002_1_4s.Add(fSAPKY002_1_4);
            }

            fSAPKY002_1.fSAPKY002_1_4s = fSAPKY002_1_4s.ToArray();

            var resp = client.addOrUpdateFSAPKY002_1(fSAPKY002_1, Giris.dbName, Giris.mKodValue);

            CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

            if (resp.Value == 0)
            {
                btnOzetEkranaDon.PerformClick();
            }
        }

        private void btnEvet_Click(object sender, EventArgs e)
        {
            btnHayir.BackColor = buttondefaultrenk;
            btnEvet.BackColor = Color.GreenYellow;
            txtKontrol.Text = "Y";
        }

        private void btnHayir_Click(object sender, EventArgs e)
        {
            btnHayir.BackColor = Color.OrangeRed;
            btnEvet.BackColor = buttondefaultrenk;
            txtKontrol.Text = "N";
        }
         
        private void txtUretimTarihi_Click(object sender, EventArgs e)
        {
            TarihGirisi tarihGirisi = new TarihGirisi(null, txtUretimTarihi);
            tarihGirisi.ShowDialog();
        }
    }
}

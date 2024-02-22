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
    public partial class _20_FSAPKY_003_1 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_003_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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

            richTextBox2.Font = new Font(richTextBox2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               richTextBox2.Font.Style);

            btnEvet2.Font = new Font(btnEvet2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnEvet2.Font.Style);

            btnHayir2.Font = new Font(btnHayir2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnHayir2.Font.Style);

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOnayla.Font.Style);

            btnSatirEkle.Font = new Font(btnSatirEkle.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnSatirEkle.Font.Style);

            btnSatirSil.Font = new Font(btnSatirSil.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSatirSil.Font.Style);

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
        private void _20_FSAPKY_003_1_Load(object sender, EventArgs e)
        {
            grid1Secildi = true;

            richTextBox1.Text = "Kültürün kontrolü yapılmıştır. Bir fiziksel deformasyon ve bulaşma söz konusu değildir. Saklama koşulları sağlanmıştır.Hayır ise Uygun olmayan ürün prosedürünü uygulayınız";
            richTextBox2.Text = "1-Sirmo otunu suda bekletne ve süzme sırasında Yabancı Madde kalmamıştır.2 - Sirmo Otunun Pastörizasyonu için Krem Peynir makinasının sıcaklığı 90°C ye ulaşmıştır ve sirmootu o sıcaklıkta 5 dk bekletilmiştir. Hayırsa Uygun olmayan ürün prosedürünü uygula.  ";

            try
            {

                txtPartiNo.Text = partiNo;
                txtUretimFisNo.Text = UretimFisNo;
                txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                txtUrunTanimi.Text = UrunTanimi;

                buttondefaultrenk = btnEvet.BackColor;

                #region Kontrol yapıldı mı sorgusu

                DataTable dtDgrKltKontrol = new DataTable();


                string sql = "SELECT \"U_Kontrol1\",\"U_Kontrol2\"  FROM \"@AIF_FSAPKY003_1\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtDgrKltKontrol);


                if (dtDgrKltKontrol.Rows.Count > 0)
                {
                    txtKontrol1.Text = dtDgrKltKontrol.Rows[0][0].ToString();
                    txtKontrol2.Text = dtDgrKltKontrol.Rows[0][1].ToString();
                }
                else
                {
                    txtKontrol1.Text = "";
                    txtKontrol2.Text = "";
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

                #region dataGridView1 
                datagridView1Load();
                ////dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Ünite Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Tekne No", typeof(string));
                //dataTable1.Columns.Add("Üretilen Ürün Adı", typeof(string));
                //dataTable1.Columns.Add("Alınan Süt Miktarı", typeof(string));
                //dataTable1.Columns.Add("Tekne Sütü Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Mayalama Saati", typeof(string));
                //dataTable1.Columns.Add("Kırım Saati", typeof(string));
                //dataTable1.Columns.Add("Baskılama Baş. Saati", typeof(string));
                //dataTable1.Columns.Add("Baskılama Sonu Saati", typeof(string));
                //dataTable1.Columns.Add("Kesme Saati", typeof(string));
                //dataTable1.Columns.Add("Kesme PH", typeof(string));
                //dataTable1.Columns.Add("Salamura İlave Saati", typeof(string));
                //dataTable1.Columns.Add("Peynir Top. Saati", typeof(string));
                //dataTable1.Columns.Add("Peynir Top. PH", typeof(string));
                //dataTable1.Columns.Add("Operatör Adı", typeof(string));

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
                ////dataTable2.Columns.Add("#", "#");
                //dataTable2.Columns.Add("Tekne Salamura PH", typeof(string));
                //dataTable2.Columns.Add("Tekne Saalmura Bölme", typeof(string));
                //dataTable2.Columns.Add("Tekne Salamura Sıcaklığı", typeof(string));

                //dataTable2.Rows.Add("");
                //dataGridView2.DataSource = dataTable2;

                //dataGridView2.AllowUserToAddRows = false;
                //dataGridView2.AllowUserToDeleteRows = false;
                //dataGridView2.AllowUserToResizeColumns = false;
                //dataGridView2.AllowUserToResizeRows = false;
                //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 191, 143);
                //dataGridView2.DefaultCellStyle.BackColor = Color.WhiteSmoke;

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
                ////dataTable3.Columns.Add("#", "#");
                //dataTable3.Columns.Add("Numune No", typeof(string));
                //dataTable3.Columns.Add("Beyaz Peynir Süt PH", typeof(string));
                //dataTable3.Columns.Add("Beyaz Peynir Süt SH", typeof(string));
                //dataTable3.Columns.Add("Beyaz Peynir Süt KM", typeof(string));
                //dataTable3.Columns.Add("Beyaz Peynir Süt Yağı", typeof(string));
                //dataTable3.Columns.Add("Operatör Adı", typeof(string));

                //dataTable3.Rows.Add("");
                //dataTable3.Rows.Add("");
                //dataGridView3.DataSource = dataTable3;

                //dataGridView3.AllowUserToAddRows = false;
                //dataGridView3.AllowUserToDeleteRows = false;
                //dataGridView3.AllowUserToResizeColumns = false;
                //dataGridView3.AllowUserToResizeRows = false;
                //dataGridView3.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //dataGridView3.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(146, 208, 80);
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

        private void datagridView1Load()
        {
            string sql = "SELECT T1.\"U_UniteSic\" as \"Ünite Sıcaklığı\",T1.\"U_TekneNo\" as \"Tekne No\",T1.\"U_UrtUrunAdi\" as \"Üretilen Ürün Adı\",T1.\"U_AlSutMik\" as \"Alınan Süt Mik.\",T1.\"U_TekSutSic\" as \"Tekne Sütü Sıc.\",T1.\"U_MayaSaat\" as \"Mayalama Saati\",T1.\"U_KirimSaat\" as \"Kırım Saati\",T1.\"U_BaskBasSaat\" as \"Baskı. Baş. Saati\",T1.\"U_BaskSonSaat\" as \"Baskı. Son. Saati\",T1.\"U_KesmeSaat\" as \"Kesme Saati\",T1.\"U_KesmePH\" as \"Kesme PH\",T1.\"U_SalIlvSaat\" as \"Salamura İlave Saati\",T1.\"U_PeyTopSaat\" as \"Peynir Top. Saati\",T1.\"U_PeyTopPH\" as \"Peynir Top. PH\",T1.\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY003_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY003_1_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Ünite Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Tekne No"] = "";
                dr["Üretilen Ürün Adı"] = "";
                dr["Alınan Süt Mik."] = Convert.ToString("0", cultureTR);
                dr["Tekne Sütü Sıc."] = Convert.ToString("0", cultureTR);
                dr["Mayalama Saati"] = "";
                dr["Kırım Saati"] = "";
                dr["Baskı. Baş. Saati"] = "";
                dr["Baskı. Son. Saati"] = "";
                dr["Kesme Saati"] = "";
                dr["Kesme PH"] = Convert.ToString("0", cultureTR);
                dr["Salamura İlave Saati"] = "";
                dr["Peynir Top. Saati"] = "";
                dr["Peynir Top. PH"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";
                dataTable1.Rows.Add(dr);
            }

            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {
            string sql = "SELECT T1.\"U_TekneSalPH\" as \"Tekne Salamura PH\",T1.\"U_TekneSalBol\" as \"Tekne Salmura Bölme\",T1.\"U_TekneSalSic\" as \"Tekne Salamura Sıc.\" FROM \"@AIF_FSAPKY003_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY003_1_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dataTable2);

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
                dr["Tekne Salamura PH"] = Convert.ToString("0", cultureTR);
                dr["Tekne Salmura Bölme"] = Convert.ToString("0", cultureTR);
                dr["Tekne Salamura Sıc."] = Convert.ToString("0", cultureTR);
                dataTable2.Rows.Add(dr);
            }

        }

        private void datagridView3Load()
        {
            string sql = "SELECT T1.\"U_NumuneNo\" as \"Numune No\",T1.\"U_BeyPeySutPH\" as \"Beyaz Peynir Süt PH\",T1.\"U_BeyPeySutSH\" as \"Beyaz Peynir Süt SH\",T1.\"U_BeyPeySutKM\" as \"Beyaz Peynir Süt KM\",T1.\"U_BeyPeySutYag\" as \"Beyaz Peynir Süt Yağı\",T1.\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY003_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY003_1_3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Numune No"] = "";
                dr["Beyaz Peynir Süt PH"] = Convert.ToString("0", cultureTR);
                dr["Beyaz Peynir Süt SH"] = Convert.ToString("0", cultureTR);
                dr["Beyaz Peynir Süt KM"] = Convert.ToString("0", cultureTR);
                dr["Beyaz Peynir Süt Yağı"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";
                dataTable3.Rows.Add(dr);
            }

            dataGridView3.Columns["Operatör Adı"].ReadOnly = true;
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
            #region satır ekle sil işlemi için kulanılır
            currentCell = e.RowIndex;
            grid1Secildi = true; 
            #endregion

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Üretilen Ürün Adı")
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
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Tekne No" || dataGridView1.Columns[e.ColumnIndex].Name == "Ünite Sıcaklığı" || dataGridView1.Columns[e.ColumnIndex].Name == "Alınan Süt Mik." || dataGridView1.Columns[e.ColumnIndex].Name == "Tekne Sütü Sıc." || dataGridView1.Columns[e.ColumnIndex].Name == "Kesme PH" || dataGridView1.Columns[e.ColumnIndex].Name == "Peynir Top. PH")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Mayalama Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Kırım Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Baskı. Baş. Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Baskı. Son. Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Kesme Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Salamura İlave Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Peynir Top. Saati")
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
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Tekne Salamura PH" || dataGridView2.Columns[e.ColumnIndex].Name == "Tekne Salmura Bölme" || dataGridView2.Columns[e.ColumnIndex].Name == "Tekne Salamura Sıc.")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog();
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex].Name == "Numune No" || dataGridView3.Columns[e.ColumnIndex].Name == "Beyaz Peynir Süt PH" || dataGridView3.Columns[e.ColumnIndex].Name == "Beyaz Peynir Süt SH" || dataGridView3.Columns[e.ColumnIndex].Name == "Beyaz Peynir Süt KM" || dataGridView3.Columns[e.ColumnIndex].Name == "Beyaz Peynir Süt Yağı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView3, false);
                n.ShowDialog();
            }
            else if (dataGridView3.Columns[e.ColumnIndex].Name == "Operatör Adı")
            {
                if (istasyon.StartsWith("20-"))
                {
                    DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                    string gunfield = "U_Gun" + dtTarih.Day;
                    string sql = "";

                    #region Günlük Personel Planlama 3 ekranı

                    sql = "SELECT TOP 1 '' AS \"Personel No\", '' AS \"Personel Adı\" FROM OCRD WITH (NOLOCK) UNION ALL SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                    sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and \"U_Durum\" = 'X'";

                    if (AtanmisIsler.Joker)
                    {
                        //sql += " UNION ALL ";

                        sql = "SELECT TOP 1 '' AS \"Personel No\", '' AS \"Personel Adı\" FROM OCRD UNION ALL SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                        sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') and \"U_Durum\" = 'X'";
                    }

                    #endregion Günlük Personel Planlama 3 ekranı

                    SelectList selectList = new SelectList(sql, dataGridView3, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();
                }
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            UVTServiceSoapClient client = new UVTServiceSoapClient();

            FSAPKY003_1 fSAPKY003_1 = new FSAPKY003_1();

            FSAPKY003_1_1 fSAPKY003_1_1 = new FSAPKY003_1_1();
            FSAPKY003_1_2 fSAPKY003_1_2 = new FSAPKY003_1_2();
            FSAPKY003_1_3 fSAPKY003_1_3 = new FSAPKY003_1_3();

            List<FSAPKY003_1_1> fSAPKY003_1_1s = new List<FSAPKY003_1_1>();
            List<FSAPKY003_1_2> fSAPKY003_1_2s = new List<FSAPKY003_1_2>();
            List<FSAPKY003_1_3> fSAPKY003_1_3s = new List<FSAPKY003_1_3>();

            fSAPKY003_1.PartiNo = txtPartiNo.Text;
            fSAPKY003_1.UrunTanimi = txtUrunTanimi.Text;

            #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
            //fSAPKY003_1.Tarih = tarih1;
            DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            fSAPKY003_1.Tarih = uretimtarihi.ToString("yyyyMMdd");
            #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

            fSAPKY003_1.Aciklama = "";
            fSAPKY003_1.UrunKodu = urunKodu;
            fSAPKY003_1.Kontrol1 = txtKontrol1.Text;
            fSAPKY003_1.Kontrol2 = txtKontrol2.Text;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                fSAPKY003_1_1 = new FSAPKY003_1_1();
                fSAPKY003_1_1.UniteSicakligi = dr.Cells["Ünite Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Ünite Sıcaklığı"].Value);
                fSAPKY003_1_1.TekneNumarasi = dr.Cells["Tekne No"].Value == DBNull.Value ? "" : dr.Cells["Tekne No"].Value.ToString();
                fSAPKY003_1_1.UretilenUrunAdi = dr.Cells["Üretilen Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Üretilen Ürün Adı"].Value.ToString();
                fSAPKY003_1_1.AlinanSutMiktari = dr.Cells["Alınan Süt Mik."].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Alınan Süt Mik."].Value);
                fSAPKY003_1_1.TekneSutuSicakligi = dr.Cells["Tekne Sütü Sıc."].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tekne Sütü Sıc."].Value);
                fSAPKY003_1_1.MayalamaSaati = dr.Cells["Mayalama Saati"].Value == DBNull.Value ? "" : dr.Cells["Mayalama Saati"].Value.ToString();

                fSAPKY003_1_1.KirimSaati = dr.Cells["Kırım Saati"].Value == DBNull.Value ? "" : dr.Cells["Kırım Saati"].Value.ToString();
                fSAPKY003_1_1.BaskilamaBasSaat = dr.Cells["Baskı. Baş. Saati"].Value == DBNull.Value ? "" : dr.Cells["Baskı. Baş. Saati"].Value.ToString();
                fSAPKY003_1_1.BaskilamaSonSaat = dr.Cells["Baskı. Son. Saati"].Value == DBNull.Value ? "" : dr.Cells["Baskı. Son. Saati"].Value.ToString();
                fSAPKY003_1_1.KesmeSaati = dr.Cells["Kesme Saati"].Value == DBNull.Value ? "" : dr.Cells["Kesme Saati"].Value.ToString();
                fSAPKY003_1_1.KesmePH = dr.Cells["Kesme PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kesme PH"].Value);
                fSAPKY003_1_1.SalamuraIlaveSaati = dr.Cells["Salamura İlave Saati"].Value == DBNull.Value ? "" : dr.Cells["Salamura İlave Saati"].Value.ToString();
                fSAPKY003_1_1.PeynirTopSaat = dr.Cells["Peynir Top. Saati"].Value == DBNull.Value ? "" : dr.Cells["Peynir Top. Saati"].Value.ToString();
                fSAPKY003_1_1.PeynirTopPH = dr.Cells["Peynir Top. PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Peynir Top. PH"].Value);
                fSAPKY003_1_1.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

                fSAPKY003_1_1s.Add(fSAPKY003_1_1);
            }

            fSAPKY003_1.fSAPKY003_1_1s = fSAPKY003_1_1s.ToArray();

            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                fSAPKY003_1_2 = new FSAPKY003_1_2();
                fSAPKY003_1_2.TekneSalamuraPH = dr.Cells["Tekne Salamura PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tekne Salamura PH"].Value);
                fSAPKY003_1_2.TekneSalamuraBolme = dr.Cells["Tekne Salmura Bölme"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tekne Salmura Bölme"].Value);
                fSAPKY003_1_2.TekneSalamuraSicakligi = dr.Cells["Tekne Salamura Sıc."].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tekne Salamura Sıc."].Value);

                fSAPKY003_1_2s.Add(fSAPKY003_1_2);
            }

            fSAPKY003_1.fSAPKY003_1_2s = fSAPKY003_1_2s.ToArray();

            foreach (DataGridViewRow dr in dataGridView3.Rows)
            {
                fSAPKY003_1_3 = new FSAPKY003_1_3();
                fSAPKY003_1_3.NumuneNumarasi = dr.Cells["Numune No"].Value == DBNull.Value ? "" : dr.Cells["Numune No"].Value.ToString();

                fSAPKY003_1_3.BeyazPeynirSutPH = dr.Cells["Beyaz Peynir Süt PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Beyaz Peynir Süt PH"].Value);
                fSAPKY003_1_3.BeyazPeynirSutSH = dr.Cells["Beyaz Peynir Süt SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Beyaz Peynir Süt SH"].Value);
                fSAPKY003_1_3.BeyazPeynirSutKM = dr.Cells["Beyaz Peynir Süt KM"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Beyaz Peynir Süt KM"].Value);
                fSAPKY003_1_3.BeyazPeynirSutYagi = dr.Cells["Beyaz Peynir Süt Yağı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Beyaz Peynir Süt Yağı"].Value);
                fSAPKY003_1_3.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();


                fSAPKY003_1_3s.Add(fSAPKY003_1_3);
            }

            fSAPKY003_1.fSAPKY003_1_3s = fSAPKY003_1_3s.ToArray();

            var resp = client.addOrUpdateFSAPKY003_1(fSAPKY003_1, Giris.dbName, Giris.mKodValue);

            CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");


            if (resp.Value == 0)
            {
                btnOzetEkranaDon.PerformClick();
            }
        }

        private void txtUretimTarihi_Click(object sender, EventArgs e)
        {
            TarihGirisi tarihGirisi = new TarihGirisi(null, txtUretimTarihi);
            tarihGirisi.ShowDialog();
        }

        bool grid1Secildi = false; 
        int currentCell = -1;
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            grid1Secildi = true; 
            #endregion
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
        }
        private void btnSatirSil_Click(object sender, EventArgs e)
        {
            if (grid1Secildi)
            {
                if (currentCell != -1)
                {
                    if (dataGridView1.Rows.Count > 1)
                    {
                        dataGridView1.Rows.RemoveAt(currentCell);
                    }
                }
            }

            currentCell = -1;
        }

        private void btnSatirEkle_Click(object sender, EventArgs e)
        {
            if (grid1Secildi)
            {
                try
                {
                    if (dataGridView1.Rows.Count >= 15)
                    {
                        return;
                    }

                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dataTable1.NewRow();
                    dr["Ünite Sıcaklığı"] = Convert.ToString("0", cultureTR);
                    dr["Tekne No"] = "";
                    dr["Üretilen Ürün Adı"] = "";
                    dr["Alınan Süt Mik."] = Convert.ToString("0", cultureTR);
                    dr["Tekne Sütü Sıc."] = Convert.ToString("0", cultureTR);
                    dr["Mayalama Saati"] = "";
                    dr["Kırım Saati"] = "";
                    dr["Baskı. Baş. Saati"] = "";
                    dr["Baskı. Son. Saati"] = "";
                    dr["Kesme Saati"] = "";
                    dr["Kesme PH"] = Convert.ToString("0", cultureTR);
                    dr["Salamura İlave Saati"] = "";
                    dr["Peynir Top. Saati"] = "";
                    dr["Peynir Top. PH"] = Convert.ToString("0", cultureTR);
                    dr["Operatör Adı"] = "";
                    dataTable1.Rows.Add(dr);

                }
                catch (Exception ex)
                {
                }
            }

        }
    }
}

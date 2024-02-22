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
    public partial class _20_FSAPKY_004_1_2 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_004_1_2(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu, DataTable _dtgfSAPKY004_1_1_1_DataTable, DataTable _dtgfSAPKY004_1_1_2_DataTable, DataTable _dtgfSAPKY004_1_2_1_DataTable, DataTable _dtgfSAPKY004_1_2_2_DataTable, DataTable _dtgfSAPKY004_1_2_3_DataTable, TextBox _kontrol1, TextBox _kontrol2)
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

            dtgfSAPKY004_1_1_1_DataTable = _dtgfSAPKY004_1_1_1_DataTable;
            dtgfSAPKY004_1_1_2_DataTable = _dtgfSAPKY004_1_1_2_DataTable;
            dtgfSAPKY004_1_2_1_DataTable = _dtgfSAPKY004_1_2_1_DataTable;
            dtgfSAPKY004_1_2_2_DataTable = _dtgfSAPKY004_1_2_2_DataTable;
            dtgfSAPKY004_1_2_3_DataTable = _dtgfSAPKY004_1_2_3_DataTable;
            txtkontrol1_IlkEkran = _kontrol1;
            txtkontrol2_IlkEkran = _kontrol2;
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

            btnSolaGit.Font = new Font(btnSolaGit.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSolaGit.Font.Style);

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
        private int row = 0;
        private SqlCommand cmd = null;
        private string tarih1 = "";
        private string urunKodu = "";
        Color buttondefaultrenk = Color.Gray;
        public static string geriDonme = "";
        DataTable dtgfSAPKY004_1_1_1_DataTable = new DataTable();
        DataTable dtgfSAPKY004_1_1_2_DataTable = new DataTable();
        DataTable dtgfSAPKY004_1_2_1_DataTable = new DataTable();
        DataTable dtgfSAPKY004_1_2_2_DataTable = new DataTable();
        DataTable dtgfSAPKY004_1_2_3_DataTable = new DataTable();
        TextBox txtkontrol1_IlkEkran;
        TextBox txtkontrol2_IlkEkran;
        private void _20_FSAPKY_004_1_2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Kültürün kontrolü yapılmıştır. Bir fiziksel deformasyon ve bulaşma söz konusu değildir. Saklama koşulları sağlanmıştır.Hayır ise Uygun olmayan ürün prosedürünü uygulayınız";
            richTextBox2.Text = "Krem Peynir Makinesinde Fermente Baz -Çeşni Karışımı 90 °C de 5 dakika pastörize edilmiştir.Uygundur.Hayırsa Uygun olmayan ürün prosedürünü uygula.Hayır ise Uygun olmayan ürün prosedürünü uygulayınız";

            txtPartiNo.Text = partiNo;
            txtUretimFisNo.Text = UretimFisNo;
            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
            txtUrunTanimi.Text = UrunTanimi;

            txtKontrol1.Text = txtkontrol1_IlkEkran.Text;


            buttondefaultrenk = btnEvet.BackColor;

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

            txtKontrol2.Text = txtkontrol2_IlkEkran.Text;


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



            try
            {
                #region dataGridView1 

                datagridView1Load();
                //dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("UF Giriş Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("UF Giriş Saati", typeof(string));
                //dataTable1.Columns.Add("UF Faktörü", typeof(string));
                //dataTable1.Columns.Add("UF Çıkış Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("UF Bitiş Saati", typeof(string));
                //dataTable1.Columns.Add("UF Operatör Adı", typeof(string));

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
                //dataTable2.Columns.Add("Rework PH", typeof(string));
                //dataTable2.Columns.Add("Rework KM", typeof(string));
                //dataTable2.Columns.Add("Rework Yağ", typeof(string));
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
                //dataTable3.Columns.Add("Konsantre Ürün PH", typeof(string));
                //dataTable3.Columns.Add("Konsantre Ürün SH", typeof(string));
                //dataTable3.Columns.Add("Konsantre Ürün KM", typeof(string));
                //dataTable3.Columns.Add("Konsantre Ürün Yağı", typeof(string));
                //dataTable3.Columns.Add("Laboratuvar Personel Adı", typeof(string));

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
            geriDonme = "OzeteDon";
            Close();
        }

        private void btnSolaGit_Click(object sender, EventArgs e)
        {
            //_20_FSAPKY_004_1_1.dtgfSAPKY004_1_2_1Static_DataTable = dataTable1;
            //_20_FSAPKY_004_1_1.dtgfSAPKY004_1_2_2Static_DataTable = dataTable2;
            //_20_FSAPKY_004_1_1.dtgfSAPKY004_1_2_3Static_DataTable = dataTable3;
            //_20_FSAPKY_004_1_1.Kontrol1 = txtKontrol1.Text;
            //_20_FSAPKY_004_1_1.Kontrol2 = txtKontrol2.Text;
            geriDonme = "SolaGit";
            Close();
        }


        private void datagridView1Load()
        {
            dataGridView1.DataSource = dtgfSAPKY004_1_2_1_DataTable;

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

            dataGridView1.Columns["UF Operatör Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {

            dataGridView2.DataSource = dtgfSAPKY004_1_2_2_DataTable;


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

            dataGridView2.Columns["Laboratuvar Personel Adı"].ReadOnly = true;
        }

        private void datagridView3Load()
        {

            dataGridView3.DataSource = dtgfSAPKY004_1_2_3_DataTable;


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

            dataGridView3.Columns["Laboratuvar Personel Adı"].ReadOnly = true;

        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            //_20_FSAPKY_004_1_1.dtgfSAPKY004_1_2_1Static = dataGridView1;
            //_20_FSAPKY_004_1_1.dtgfSAPKY004_1_2_2Static = dataGridView2;
            //_20_FSAPKY_004_1_1.dtgfSAPKY004_1_2_3Static = dataGridView3;
            //_20_FSAPKY_004_1_1.dtgfSAPKY004_1_2_1Static_DataTable = dataTable1;
            //_20_FSAPKY_004_1_1.dtgfSAPKY004_1_2_2Static_DataTable = dataTable2;
            //_20_FSAPKY_004_1_1.dtgfSAPKY004_1_2_3Static_DataTable = dataTable3;
            //_20_FSAPKY_004_1_1.Kontrol1 = txtKontrol1.Text;
            //_20_FSAPKY_004_1_1.Kontrol2 = txtKontrol2.Text;
            //_20_FSAPKY_004_1_1.TabloyaKaydet();
            tabloyaKaydetmeIslemleri();
            //Close();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "UF Giriş Sıcaklığı" || dataGridView1.Columns[e.ColumnIndex].Name == "UF Faktörü" || dataGridView1.Columns[e.ColumnIndex].Name == "UF Çıkış Sıcaklığı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "UF Giriş Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "UF Bitiş Saati")
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

            if (dataGridView2.Columns[e.ColumnIndex].Name == "Rework PH" || dataGridView2.Columns[e.ColumnIndex].Name == "Rework KM" || dataGridView2.Columns[e.ColumnIndex].Name == "Rework Yağ")
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

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex].Name == "Konsantre Ürün PH" || dataGridView3.Columns[e.ColumnIndex].Name == "Konsantre Ürün SH" || dataGridView3.Columns[e.ColumnIndex].Name == "Konsantre Ürün KM" || dataGridView3.Columns[e.ColumnIndex].Name == "Konsantre Ürün Yağı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView3, false);
                n.ShowDialog();
            }

            else if (dataGridView3.Columns[e.ColumnIndex].Name == "Laboratuvar Personel Adı")
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

                    SelectList selectList = new SelectList(sql, dataGridView3, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();
                }
            }
        }

        private void btnEvet_Click(object sender, EventArgs e)
        {
            btnHayir.BackColor = buttondefaultrenk;
            btnEvet.BackColor = Color.GreenYellow;
            txtKontrol1.Text = "Y";
            txtkontrol1_IlkEkran.Text = "Y";
        }

        private void btnHayir_Click(object sender, EventArgs e)
        {
            btnHayir.BackColor = Color.OrangeRed;
            btnEvet.BackColor = buttondefaultrenk;
            txtKontrol1.Text = "N";
            txtkontrol1_IlkEkran.Text = "N";
        }

        private void btnEvet2_Click(object sender, EventArgs e)
        {
            btnHayir2.BackColor = buttondefaultrenk;
            btnEvet2.BackColor = Color.GreenYellow;
            txtKontrol2.Text = "Y";
            txtkontrol2_IlkEkran.Text = "Y";
        }

        private void btnHayir2_Click(object sender, EventArgs e)
        {
            btnHayir2.BackColor = Color.OrangeRed;
            btnEvet2.BackColor = buttondefaultrenk;
            txtKontrol2.Text = "N";
            txtkontrol2_IlkEkran.Text = "N";
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
                //fSAPKY007_3.Tarih = tarih1;
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
                    btnOzetEkranaDon.PerformClick();
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

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
    public partial class _20_FSAPKY_012_2 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_012_2(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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
            #region Font.
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

            btnOlcumGir.Font = new Font(btnOlcumGir.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnOlcumGir.Font.Style);

            btnMiktarGir.Font = new Font(btnMiktarGir.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnMiktarGir.Font.Style);

            btnSaatGir.Font = new Font(btnSaatGir.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSaatGir.Font.Style);

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
        private void _20_FSAPKY_012_2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Ambalajlarda kırık,çatlak veya herhangi bir deformasyon yoktur.Yabancı Fiziksel Madde Kontaminasyonu Yoktur.Hayırsa Uygun olmayan ürün prosedürünü uygula.";

            try
            {
                txtPartiNo.Text = partiNo;
                txtUretimFisNo.Text = UretimFisNo;
                txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                txtUrunTanimi.Text = UrunTanimi;

                buttondefaultrenk = btnEvet.BackColor;

                #region Kontrol yapıldı mı sorgusu

                DataTable dtKontroller = new DataTable();


                string sql = "SELECT \"U_Kontrol1\" FROM \"@AIF_FSAPKY012_2\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtKontroller);


                if (dtKontroller.Rows.Count > 0)
                {
                    txtKontrol1.Text = dtKontroller.Rows[0][0].ToString();
                }
                else
                {
                    txtKontrol1.Text = "";
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

                #endregion

                #region dataGridView1 
                datagridView1Load();
                ////dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Ürün Adı", typeof(string));
                //dataTable1.Columns.Add("Paketleme Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Üretim Tarihi", typeof(string));
                //dataTable1.Columns.Add("Son Tüketim Tarihi", typeof(string));
                //dataTable1.Columns.Add("Parti Numarası", typeof(string));
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
                //dataTable2.Columns.Add("pH 1.Ölçüm", typeof(string));
                //dataTable2.Columns.Add("pH 2.Ölçüm", typeof(string));
                //dataTable2.Columns.Add("pH 3.Ölçüm", typeof(string));
                //dataTable2.Columns.Add("pH 4.Ölçüm", typeof(string));
                //dataTable2.Columns.Add("pH 5.Ölçüm", typeof(string));
                //dataTable2.Columns.Add("pH 6.Ölçüm", typeof(string));
                //dataTable2.Columns.Add("pH 7.Ölçüm", typeof(string));
                //dataTable2.Columns.Add("pH 8.Ölçüm", typeof(string));
                //dataTable2.Columns.Add("pH 9.Ölçüm", typeof(string));
                //dataTable2.Columns.Add("pH 10.Ölçüm", typeof(string));
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
            string sql = "SELECT T1.\"U_UrunAdi\" as \"Ürün Adı\",T1.\"U_PaketSic\" as \"Paketleme Sıcaklığı\",T1.\"U_UretimTar\" as \"Üretim Tarihi\",T1.\"U_SonTukTar\" as \"Son Tüketim Tarihi\",T1.\"U_PartiNo\" as \"Parti Numarası\",T1.\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY012_2\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY012_2_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Ürün Adı"] = "";
                dr["Paketleme Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["Üretim Tarihi"] = "";
                //dr["Son Tüketim Tarihi"] = "";
                dr["Parti Numarası"] = "";
                dr["Operatör Adı"] = "";
                dataTable1.Rows.Add(dr);
            }
            dataGridView1.Columns["Ürün Adı"].ReadOnly = true;
            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }


        private void datagridView2Load()
        {
            string sql = "SELECT T1.\"U_UrunAdi\" as \"Ürün Adı\",T1.\"U_pHOlcum1\" as \"pH 1.Ölçüm\",T1.\"U_pHOlcum2\" as \"pH 2.Ölçüm\",T1.\"U_pHOlcum3\" as \"pH 3.Ölçüm\",T1.\"U_pHOlcum4\" as \"pH 4.Ölçüm\",T1.\"U_pHOlcum5\" as \"pH 5.Ölçüm\",T1.\"U_pHOlcum6\" as \"pH 6.Ölçüm\",T1.\"U_pHOlcum7\" as \"pH 7.Ölçüm\",T1.\"U_pHOlcum8\" as \"pH 8.Ölçüm\",T1.\"U_pHOlcum9\" as \"pH 9.Ölçüm\",T1.\"U_pHOlcum10\" as \"pH 10.Ölçüm\",T1.\"U_pHMiktar1\" as \"pH 1.Miktar\",T1.\"U_pHMiktar2\" as \"pH 2.Miktar\",T1.\"U_pHMiktar3\" as \"pH 3.Miktar\",T1.\"U_pHMiktar4\" as \"pH 4.Miktar\",T1.\"U_pHMiktar5\" as \"pH 5.Miktar\",T1.\"U_pHMiktar6\" as \"pH 6.Miktar\",T1.\"U_pHMiktar7\" as \"pH 7.Miktar\",T1.\"U_pHMiktar8\" as \"pH 8.Miktar\",T1.\"U_pHMiktar9\" as \"pH 9.Miktar\",T1.\"U_pHMiktar10\" as \"pH 10.Miktar\", T1.\"U_pHSaat1\" as \"pH 1.Saat\",T1.\"U_pHSaat2\" as \"pH 2.Saat\",T1.\"U_pHSaat3\" as \"pH 3.Saat\",T1.\"U_pHSaat4\" as \"pH 4.Saat\",T1.\"U_pHSaat5\" as \"pH 5.Saat\",T1.\"U_pHSaat6\" as \"pH 6.Saat\",T1.\"U_pHSaat7\" as \"pH 7.Saat\",T1.\"U_pHSaat8\" as \"pH 8.Saat\",T1.\"U_pHSaat9\" as \"pH 9.Saat\",T1.\"U_pHSaat10\" as \"pH 10.Saat\", T1.\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY012_2\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY012_2_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Ürün Adı"] = "";
                dr["pH 1.Ölçüm"] = Convert.ToString("0", cultureTR);
                dr["pH 2.Ölçüm"] = Convert.ToString("0", cultureTR);
                dr["pH 3.Ölçüm"] = Convert.ToString("0", cultureTR);
                dr["pH 4.Ölçüm"] = Convert.ToString("0", cultureTR);
                dr["pH 5.Ölçüm"] = Convert.ToString("0", cultureTR);
                dr["pH 6.Ölçüm"] = Convert.ToString("0", cultureTR);
                dr["pH 7.Ölçüm"] = Convert.ToString("0", cultureTR);
                dr["pH 8.Ölçüm"] = Convert.ToString("0", cultureTR);
                dr["pH 9.Ölçüm"] = Convert.ToString("0", cultureTR);
                dr["pH 10.Ölçüm"] = Convert.ToString("0", cultureTR);

                dr["pH 1.Miktar"] = Convert.ToString("0", cultureTR);
                dr["pH 2.Miktar"] = Convert.ToString("0", cultureTR);
                dr["pH 3.Miktar"] = Convert.ToString("0", cultureTR);
                dr["pH 4.Miktar"] = Convert.ToString("0", cultureTR);
                dr["pH 5.Miktar"] = Convert.ToString("0", cultureTR);
                dr["pH 6.Miktar"] = Convert.ToString("0", cultureTR);
                dr["pH 7.Miktar"] = Convert.ToString("0", cultureTR);
                dr["pH 8.Miktar"] = Convert.ToString("0", cultureTR);
                dr["pH 9.Miktar"] = Convert.ToString("0", cultureTR);
                dr["pH 10.Miktar"] = Convert.ToString("0", cultureTR);

                dr["pH 1.Saat"] = "";
                dr["pH 2.Saat"] = "";
                dr["pH 3.Saat"] = "";
                dr["pH 4.Saat"] = "";
                dr["pH 5.Saat"] = "";
                dr["pH 6.Saat"] = "";
                dr["pH 7.Saat"] = "";
                dr["pH 8.Saat"] = "";
                dr["pH 9.Saat"] = "";
                dr["pH 10.Saat"] = "";

                dr["Operatör Adı"] = "";
                dataTable2.Rows.Add(dr);
            }

            dataGridView2.Columns["Ürün Adı"].ReadOnly = true;
            dataGridView2.Columns["Operatör Adı"].ReadOnly = true;

            btnOlcumGir.PerformClick();
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
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Paketleme Sıcaklığı" || dataGridView1.Columns[e.ColumnIndex].Name == "Parti Numarası")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Üretim Tarihi" || dataGridView1.Columns[e.ColumnIndex].Name == "Son Tüketim Tarihi")
            {
                TarihGirisi n = new TarihGirisi(dataGridView1);
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
            #region satır ekle sil işlemi için kulanılır
            currentCell = e.RowIndex;
            grid2Secildi = true;
            #endregion

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
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "pH 1.Ölçüm" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 2.Ölçüm" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 3.Ölçüm" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 4.Ölçüm" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 5.Ölçüm" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 6.Ölçüm" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 7.Ölçüm" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 8.Ölçüm" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 9.Ölçüm" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 10.Ölçüm" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 1.Miktar" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 2.Miktar" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 3.Miktar" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 4.Miktar" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 5.Miktar" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 6.Miktar" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 7.Miktar" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 8.Miktar" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 9.Miktar" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 10.Miktar")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog();
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "pH 1.Saat" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 2.Saat" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 3.Saat" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 4.Saat" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 5.Saat" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 6.Saat" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 7.Saat" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 8.Saat" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 9.Saat" || dataGridView2.Columns[e.ColumnIndex].Name == "pH 10.Saat")
            {
                SaatTarihGirisi n = new SaatTarihGirisi(dataGridView2);
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
            UVTServiceSoapClient client = new UVTServiceSoapClient();
            FSAPKY012_2 fSAPKY012_2 = new FSAPKY012_2();
            List<FSAPKY012_2_1> fSAPKY012_2_1s = new List<FSAPKY012_2_1>();
            FSAPKY012_2_1 fSAPKY012_2_1 = new FSAPKY012_2_1();
            List<FSAPKY012_2_2> fSAPKY012_2_2s = new List<FSAPKY012_2_2>();
            FSAPKY012_2_2 fSAPKY012_2_2 = new FSAPKY012_2_2();
             
            fSAPKY012_2.PartiNo = txtPartiNo.Text;
            fSAPKY012_2.UrunTanimi = txtUrunTanimi.Text;

            #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
            //fSAPKY012_2.Tarih = tarih1;
            DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            fSAPKY012_2.Tarih = uretimtarihi.ToString("yyyyMMdd");
            #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

            fSAPKY012_2.Aciklama = "";
            fSAPKY012_2.UrunKodu = urunKodu;
            fSAPKY012_2.Kontrol1 = txtKontrol1.Text;


            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                fSAPKY012_2_1 = new FSAPKY012_2_1();
                fSAPKY012_2_1.UrunAdi = dr.Cells["Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Ürün Adı"].Value.ToString();
                fSAPKY012_2_1.PaketlemeSicakligi = dr.Cells["Paketleme Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Paketleme Sıcaklığı"].Value);
                fSAPKY012_2_1.UretimTarihi = dr.Cells["Üretim Tarihi"].Value == DBNull.Value ? new DateTime(1900, 01, 01) : Convert.ToDateTime(dr.Cells["Üretim Tarihi"].Value);
                fSAPKY012_2_1.SonTuketimTarihi = dr.Cells["Son Tüketim Tarihi"].Value == DBNull.Value ? new DateTime(1900, 01, 01) : Convert.ToDateTime(dr.Cells["Son Tüketim Tarihi"].Value);
                fSAPKY012_2_1.PartiNo = dr.Cells["Parti Numarası"].Value == DBNull.Value ? "" : dr.Cells["Parti Numarası"].Value.ToString();
                fSAPKY012_2_1.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

                fSAPKY012_2_1s.Add(fSAPKY012_2_1);
            }

            fSAPKY012_2.fSAPKY012_2_1s = fSAPKY012_2_1s.ToArray();


            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                fSAPKY012_2_2 = new FSAPKY012_2_2();
                fSAPKY012_2_2.UrunAdi = dr.Cells["Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Ürün Adı"].Value.ToString();
                fSAPKY012_2_2.PHOlcum1 = dr.Cells["pH 1.Ölçüm"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 1.Ölçüm"].Value); 
                fSAPKY012_2_2.PHOlcum2 = dr.Cells["pH 2.Ölçüm"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 2.Ölçüm"].Value); 
                fSAPKY012_2_2.PHOlcum3 = dr.Cells["pH 3.Ölçüm"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 3.Ölçüm"].Value); 
                fSAPKY012_2_2.PHOlcum4 = dr.Cells["pH 4.Ölçüm"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 4.Ölçüm"].Value); 
                fSAPKY012_2_2.PHOlcum5 = dr.Cells["pH 5.Ölçüm"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 5.Ölçüm"].Value); 
                fSAPKY012_2_2.PHOlcum6 = dr.Cells["pH 6.Ölçüm"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 6.Ölçüm"].Value); 
                fSAPKY012_2_2.PHOlcum7 = dr.Cells["pH 7.Ölçüm"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 7.Ölçüm"].Value); 
                fSAPKY012_2_2.PHOlcum8 = dr.Cells["pH 8.Ölçüm"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 8.Ölçüm"].Value); 
                fSAPKY012_2_2.PHOlcum9 = dr.Cells["pH 9.Ölçüm"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 9.Ölçüm"].Value); 
                fSAPKY012_2_2.PHOlcum10 = dr.Cells["pH 10.Ölçüm"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 10.Ölçüm"].Value);

                fSAPKY012_2_2.PHMiktar1 = dr.Cells["pH 1.Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 1.Miktar"].Value); 
                fSAPKY012_2_2.PHMiktar2 = dr.Cells["pH 2.Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 2.Miktar"].Value); 
                fSAPKY012_2_2.PHMiktar3 = dr.Cells["pH 3.Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 3.Miktar"].Value); 
                fSAPKY012_2_2.PHMiktar4 = dr.Cells["pH 4.Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 4.Miktar"].Value); 
                fSAPKY012_2_2.PHMiktar5 = dr.Cells["pH 5.Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 5.Miktar"].Value); 
                fSAPKY012_2_2.PHMiktar6 = dr.Cells["pH 6.Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 6.Miktar"].Value); 
                fSAPKY012_2_2.PHMiktar7 = dr.Cells["pH 7.Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 7.Miktar"].Value); 
                fSAPKY012_2_2.PHMiktar8 = dr.Cells["pH 8.Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 8.Miktar"].Value); 
                fSAPKY012_2_2.PHMiktar9 = dr.Cells["pH 9.Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 9.Miktar"].Value);
                fSAPKY012_2_2.PHMiktar10 = dr.Cells["pH 10.Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["pH 10.Miktar"].Value);

                fSAPKY012_2_2.PHSaat1 = dr.Cells["pH 1.Saat"].Value == DBNull.Value ? "" : dr.Cells["pH 1.Saat"].Value.ToString();
                fSAPKY012_2_2.PHSaat2 = dr.Cells["pH 2.Saat"].Value == DBNull.Value ? "" : dr.Cells["pH 2.Saat"].Value.ToString();
                fSAPKY012_2_2.PHSaat3 = dr.Cells["pH 3.Saat"].Value == DBNull.Value ? "" : dr.Cells["pH 3.Saat"].Value.ToString();
                fSAPKY012_2_2.PHSaat4 = dr.Cells["pH 4.Saat"].Value == DBNull.Value ? "" : dr.Cells["pH 4.Saat"].Value.ToString();
                fSAPKY012_2_2.PHSaat5 = dr.Cells["pH 5.Saat"].Value == DBNull.Value ? "" : dr.Cells["pH 5.Saat"].Value.ToString();
                fSAPKY012_2_2.PHSaat6 = dr.Cells["pH 6.Saat"].Value == DBNull.Value ? "" : dr.Cells["pH 6.Saat"].Value.ToString();
                fSAPKY012_2_2.PHSaat7 = dr.Cells["pH 7.Saat"].Value == DBNull.Value ? "" : dr.Cells["pH 7.Saat"].Value.ToString();
                fSAPKY012_2_2.PHSaat8 = dr.Cells["pH 8.Saat"].Value == DBNull.Value ? "" : dr.Cells["pH 8.Saat"].Value.ToString();
                fSAPKY012_2_2.PHSaat9 = dr.Cells["pH 9.Saat"].Value == DBNull.Value ? "" : dr.Cells["pH 9.Saat"].Value.ToString();
                fSAPKY012_2_2.PHSaat10 = dr.Cells["pH 10.Saat"].Value == DBNull.Value ? "" : dr.Cells["pH 10.Saat"].Value.ToString();

                fSAPKY012_2_2.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

                fSAPKY012_2_2s.Add(fSAPKY012_2_2);
            }

            fSAPKY012_2.fSAPKY012_2_2s = fSAPKY012_2_2s.ToArray();

            var resp = client.addOrUpdateFSAPKY012_2(fSAPKY012_2, Giris.dbName, Giris.mKodValue);

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

        private void btnOlcumGir_Click(object sender, EventArgs e)
        {
            btnOlcumGir.BackColor = Color.LightGreen;
            btnMiktarGir.BackColor = DefaultBackColor;
            btnSaatGir.BackColor = DefaultBackColor;

            dataGridView2.Columns["pH 1.Ölçüm"].Visible = true;
            dataGridView2.Columns["pH 2.Ölçüm"].Visible = true;
            dataGridView2.Columns["pH 3.Ölçüm"].Visible = true;
            dataGridView2.Columns["pH 4.Ölçüm"].Visible = true;
            dataGridView2.Columns["pH 5.Ölçüm"].Visible = true;
            dataGridView2.Columns["pH 6.Ölçüm"].Visible = true;
            dataGridView2.Columns["pH 7.Ölçüm"].Visible = true;
            dataGridView2.Columns["pH 8.Ölçüm"].Visible = true;
            dataGridView2.Columns["pH 9.Ölçüm"].Visible = true;
            dataGridView2.Columns["pH 10.Ölçüm"].Visible = true;

            dataGridView2.Columns["pH 1.Miktar"].Visible = false;
            dataGridView2.Columns["pH 2.Miktar"].Visible = false;
            dataGridView2.Columns["pH 3.Miktar"].Visible = false;
            dataGridView2.Columns["pH 4.Miktar"].Visible = false;
            dataGridView2.Columns["pH 5.Miktar"].Visible = false;
            dataGridView2.Columns["pH 6.Miktar"].Visible = false;
            dataGridView2.Columns["pH 7.Miktar"].Visible = false;
            dataGridView2.Columns["pH 8.Miktar"].Visible = false;
            dataGridView2.Columns["pH 9.Miktar"].Visible = false;
            dataGridView2.Columns["pH 10.Miktar"].Visible = false;

            dataGridView2.Columns["pH 1.Saat"].Visible = false;
            dataGridView2.Columns["pH 2.Saat"].Visible = false;
            dataGridView2.Columns["pH 3.Saat"].Visible = false;
            dataGridView2.Columns["pH 4.Saat"].Visible = false;
            dataGridView2.Columns["pH 5.Saat"].Visible = false;
            dataGridView2.Columns["pH 6.Saat"].Visible = false;
            dataGridView2.Columns["pH 7.Saat"].Visible = false;
            dataGridView2.Columns["pH 8.Saat"].Visible = false;
            dataGridView2.Columns["pH 9.Saat"].Visible = false;
            dataGridView2.Columns["pH 10.Saat"].Visible = false;

        }

        private void btnMiktarGir_Click(object sender, EventArgs e)
        {
            btnMiktarGir.BackColor = Color.LightGreen;
            btnOlcumGir.BackColor = DefaultBackColor;
            btnSaatGir.BackColor = DefaultBackColor;

            dataGridView2.Columns["pH 1.Miktar"].Visible = true;
            dataGridView2.Columns["pH 2.Miktar"].Visible = true;
            dataGridView2.Columns["pH 3.Miktar"].Visible = true;
            dataGridView2.Columns["pH 4.Miktar"].Visible = true;
            dataGridView2.Columns["pH 5.Miktar"].Visible = true;
            dataGridView2.Columns["pH 6.Miktar"].Visible = true;
            dataGridView2.Columns["pH 7.Miktar"].Visible = true;
            dataGridView2.Columns["pH 8.Miktar"].Visible = true;
            dataGridView2.Columns["pH 9.Miktar"].Visible = true;
            dataGridView2.Columns["pH 10.Miktar"].Visible = true;

            dataGridView2.Columns["pH 1.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 2.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 3.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 4.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 5.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 6.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 7.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 8.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 9.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 10.Ölçüm"].Visible = false;

            dataGridView2.Columns["pH 1.Saat"].Visible = false;
            dataGridView2.Columns["pH 2.Saat"].Visible = false;
            dataGridView2.Columns["pH 3.Saat"].Visible = false;
            dataGridView2.Columns["pH 4.Saat"].Visible = false;
            dataGridView2.Columns["pH 5.Saat"].Visible = false;
            dataGridView2.Columns["pH 6.Saat"].Visible = false;
            dataGridView2.Columns["pH 7.Saat"].Visible = false;
            dataGridView2.Columns["pH 8.Saat"].Visible = false;
            dataGridView2.Columns["pH 9.Saat"].Visible = false;
            dataGridView2.Columns["pH 10.Saat"].Visible = false;
        }

        private void btnSaatGir_Click(object sender, EventArgs e)
        {
            btnSaatGir.BackColor = Color.LightGreen;
            btnOlcumGir.BackColor = DefaultBackColor;
            btnMiktarGir.BackColor = DefaultBackColor;

            dataGridView2.Columns["pH 1.Saat"].Visible = true;
            dataGridView2.Columns["pH 2.Saat"].Visible = true;
            dataGridView2.Columns["pH 3.Saat"].Visible = true;
            dataGridView2.Columns["pH 4.Saat"].Visible = true;
            dataGridView2.Columns["pH 5.Saat"].Visible = true;
            dataGridView2.Columns["pH 6.Saat"].Visible = true;
            dataGridView2.Columns["pH 7.Saat"].Visible = true;
            dataGridView2.Columns["pH 8.Saat"].Visible = true;
            dataGridView2.Columns["pH 9.Saat"].Visible = true;
            dataGridView2.Columns["pH 10.Saat"].Visible = true;

            dataGridView2.Columns["pH 1.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 2.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 3.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 4.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 5.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 6.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 7.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 8.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 9.Ölçüm"].Visible = false;
            dataGridView2.Columns["pH 10.Ölçüm"].Visible = false;

            dataGridView2.Columns["pH 1.Miktar"].Visible = false;
            dataGridView2.Columns["pH 2.Miktar"].Visible = false;
            dataGridView2.Columns["pH 3.Miktar"].Visible = false;
            dataGridView2.Columns["pH 4.Miktar"].Visible = false;
            dataGridView2.Columns["pH 5.Miktar"].Visible = false;
            dataGridView2.Columns["pH 6.Miktar"].Visible = false;
            dataGridView2.Columns["pH 7.Miktar"].Visible = false;
            dataGridView2.Columns["pH 8.Miktar"].Visible = false;
            dataGridView2.Columns["pH 9.Miktar"].Visible = false;
            dataGridView2.Columns["pH 10.Miktar"].Visible = false;
        }


        bool grid2Secildi = false;
        int currentCell = -1;
        private void dataGridView2_Click(object sender, EventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            grid2Secildi = true;
            #endregion
        }

        private void btnSatirSil_Click(object sender, EventArgs e)
        {
            if (grid2Secildi)
            {
                if (currentCell != -1)
                {
                    if (dataGridView2.Rows.Count > 1)
                    {
                        dataGridView2.Rows.RemoveAt(currentCell);
                    }
                }
            }

            currentCell = -1;
        }
        private void btnSatirEkle_Click(object sender, EventArgs e)
        {
            if (grid2Secildi)
            {
                try
                {
                    if (dataGridView2.Rows.Count >= 15)
                    {
                        return;
                    }

                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dataTable2.NewRow();
                    dr["Ürün Adı"] = "";
                    dr["pH 1.Ölçüm"] = Convert.ToString("0", cultureTR);
                    dr["pH 2.Ölçüm"] = Convert.ToString("0", cultureTR);
                    dr["pH 3.Ölçüm"] = Convert.ToString("0", cultureTR);
                    dr["pH 4.Ölçüm"] = Convert.ToString("0", cultureTR);
                    dr["pH 5.Ölçüm"] = Convert.ToString("0", cultureTR);
                    dr["pH 6.Ölçüm"] = Convert.ToString("0", cultureTR);
                    dr["pH 7.Ölçüm"] = Convert.ToString("0", cultureTR);
                    dr["pH 8.Ölçüm"] = Convert.ToString("0", cultureTR);
                    dr["pH 9.Ölçüm"] = Convert.ToString("0", cultureTR);
                    dr["pH 10.Ölçüm"] = Convert.ToString("0", cultureTR);

                    dr["pH 1.Miktar"] = Convert.ToString("0", cultureTR);
                    dr["pH 2.Miktar"] = Convert.ToString("0", cultureTR);
                    dr["pH 3.Miktar"] = Convert.ToString("0", cultureTR);
                    dr["pH 4.Miktar"] = Convert.ToString("0", cultureTR);
                    dr["pH 5.Miktar"] = Convert.ToString("0", cultureTR);
                    dr["pH 6.Miktar"] = Convert.ToString("0", cultureTR);
                    dr["pH 7.Miktar"] = Convert.ToString("0", cultureTR);
                    dr["pH 8.Miktar"] = Convert.ToString("0", cultureTR);
                    dr["pH 9.Miktar"] = Convert.ToString("0", cultureTR);
                    dr["pH 10.Miktar"] = Convert.ToString("0", cultureTR);

                    dr["pH 1.Saat"] = "";
                    dr["pH 2.Saat"] = "";
                    dr["pH 3.Saat"] = "";
                    dr["pH 4.Saat"] = "";
                    dr["pH 5.Saat"] = "";
                    dr["pH 6.Saat"] = "";
                    dr["pH 7.Saat"] = "";
                    dr["pH 8.Saat"] = "";
                    dr["pH 9.Saat"] = "";
                    dr["pH 10.Saat"] = "";

                    dr["Operatör Adı"] = "";
                    dataTable2.Rows.Add(dr);
                

                }
                catch (Exception ex)
                {
                }
            }
        }

    }
}

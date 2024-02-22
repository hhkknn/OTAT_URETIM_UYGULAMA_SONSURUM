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
    public partial class _20_FSAPKY_003_2 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_003_2(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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
        private void _20_FSAPKY_003_2_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Ambalajlarda kırık,çatlak veya herhangi bir deformasyon yoktur.Yabancı Fiziksel Madde Kontaminasyonu Yoktur.Hayırsa Uygun olmayan ürün prosedürünü uygula.";
            richTextBox2.Text = "Ağırlık Kontrolü yapılmıştır,uygundur.Hayırsa Uygun olmayan ürün prosedürünü uygula.";

            try
            {


                txtPartiNo.Text = partiNo;
                txtUretimFisNo.Text = UretimFisNo;
                txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                txtUrunTanimi.Text = UrunTanimi;

                buttondefaultrenk = btnEvet.BackColor; 

                #region Kontrol yapıldı mı sorgusu

                DataTable dtDgrKltKontrol = new DataTable();


                string sql = "SELECT \"U_Kontrol1\",\"U_Kontrol2\"  FROM \"@AIF_FSAPKY003_2\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                //dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Kapatma PH", typeof(string));
                //dataTable1.Columns.Add("Üretim Tarihi", typeof(string));
                //dataTable1.Columns.Add("Son Tüketim Tarihi", typeof(string));
                //dataTable1.Columns.Add("Parti No", typeof(string));
                //dataTable1.Columns.Add("Dolum Salamura PH", typeof(string));
                //dataTable1.Columns.Add("Dolum Salamura Bölme", typeof(string));
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
                //dataTable2.Columns.Add("Örnek 1", typeof(string));
                //dataTable2.Columns.Add("Örnek 2", typeof(string));
                //dataTable2.Columns.Add("Örnek 3", typeof(string));
                //dataTable2.Columns.Add("Örnek 4", typeof(string));
                //dataTable2.Columns.Add("Örnek 5", typeof(string));

                //dataTable2.Rows.Add("");
                //dataGridView2.DataSource = dataTable2;

                //dataGridView2.AllowUserToAddRows = false;
                //dataGridView2.AllowUserToDeleteRows = false;
                //dataGridView2.AllowUserToResizeColumns = false;
                //dataGridView2.AllowUserToResizeRows = false;
                //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 191, 143);
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
        }

        private void datagridView1Load()
        {

            string sql = "SELECT T1.\"U_KapatmaPH\" as \"Kapatma PH\",T1.\"U_UretimTar\" as \"Üretim Tarihi\",\"U_SonTukTar\" as \"Son Tüketim Tarihi\",T1.\"U_PartiNo\" as \"Parti No\",\"U_DolSalPH\" as \"Dolum Salamura PH\",\"U_DolSalBol\" as \"Dolum Salamura Bome\",T1.\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY003_2\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY003_2_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Kapatma PH"] = Convert.ToString("0", cultureTR);
                dr["Parti No"] = "";
                dr["Dolum Salamura PH"] = Convert.ToString("0", cultureTR);
                dr["Dolum Salamura Bome"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";
                dataTable1.Rows.Add(dr);
            }
            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {


            string sql = "SELECT T1.\"U_Ornek1\" as \"Örnek 1\",T1.\"U_Ornek2\" as \"Örnek 2\",T1.\"U_Ornek3\" as \"Örnek 3\",T1.\"U_Ornek4\" as \"Örnek 4\",T1.\"U_Ornek5\" as \"Örnek 5\" FROM \"@AIF_FSAPKY003_2\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY003_2_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Örnek 1"] = Convert.ToString("0", cultureTR);
                dr["Örnek 2"] = Convert.ToString("0", cultureTR);
                dr["Örnek 3"] = Convert.ToString("0", cultureTR);
                dr["Örnek 4"] = Convert.ToString("0", cultureTR);
                dr["Örnek 5"] = Convert.ToString("0", cultureTR);
                dataTable2.Rows.Add(dr);
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

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            UVTServiceSoapClient client = new UVTServiceSoapClient();
            FSAPKY003_2 fSAPKY003_2 = new FSAPKY003_2();
            List<FSAPKY003_2_1> fSAPKY003_2_1s = new List<FSAPKY003_2_1>();
            FSAPKY003_2_1 fSAPKY003_2_1 = new FSAPKY003_2_1();
            List<FSAPKY003_2_2> fSAPKY003_2_2s = new List<FSAPKY003_2_2>();
            FSAPKY003_2_2 fSAPKY003_2_2 = new FSAPKY003_2_2();



            fSAPKY003_2.PartiNo = txtPartiNo.Text;
            fSAPKY003_2.UrunTanimi = txtUrunTanimi.Text;

            #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
            //fSAPKY003_2.Tarih = tarih1;
            DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            fSAPKY003_2.Tarih = uretimtarihi.ToString("yyyyMMdd");
            #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

            fSAPKY003_2.Aciklama = "";
            fSAPKY003_2.UrunKodu = urunKodu;
            fSAPKY003_2.Kontrol1 = txtKontrol1.Text;
            fSAPKY003_2.Kontrol2 = txtKontrol2.Text;



            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                fSAPKY003_2_1 = new FSAPKY003_2_1();
                fSAPKY003_2_1.KapatmaPH = dr.Cells["Kapatma PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kapatma PH"].Value);
                fSAPKY003_2_1.UretimTarihi = dr.Cells["Üretim Tarihi"].Value == DBNull.Value ? new DateTime(1900, 01, 01) : Convert.ToDateTime(dr.Cells["Üretim Tarihi"].Value);
                fSAPKY003_2_1.SonTuketimTarihi = dr.Cells["Son Tüketim Tarihi"].Value == DBNull.Value ? new DateTime(1900, 01, 01) : Convert.ToDateTime(dr.Cells["Son Tüketim Tarihi"].Value);
                fSAPKY003_2_1.PartiNumarasi = dr.Cells["Parti No"].Value == DBNull.Value ? "" : dr.Cells["Parti No"].Value.ToString();
                fSAPKY003_2_1.DolumSalamuraPH = dr.Cells["Dolum Salamura PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Dolum Salamura PH"].Value);
                fSAPKY003_2_1.DolumSalamuraBolme = dr.Cells["Dolum Salamura Bome"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Dolum Salamura Bome"].Value);
                fSAPKY003_2_1.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

                fSAPKY003_2_1s.Add(fSAPKY003_2_1);
            }

            fSAPKY003_2.fSAPKY003_2_1s = fSAPKY003_2_1s.ToArray();

            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                fSAPKY003_2_2 = new FSAPKY003_2_2();
                fSAPKY003_2_2.Ornek1 = dr.Cells["Örnek 1"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 1"].Value);
                fSAPKY003_2_2.Ornek2 = dr.Cells["Örnek 2"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 2"].Value);
                fSAPKY003_2_2.Ornek3 = dr.Cells["Örnek 3"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 3"].Value);
                fSAPKY003_2_2.Ornek4 = dr.Cells["Örnek 4"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 4"].Value);
                fSAPKY003_2_2.Ornek5 = dr.Cells["Örnek 5"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 5"].Value);

                fSAPKY003_2_2s.Add(fSAPKY003_2_2);
            }

            fSAPKY003_2.fSAPKY003_2_2s = fSAPKY003_2_2s.ToArray();

            var resp = client.addOrUpdateFSAPKY003_2(fSAPKY003_2, Giris.dbName, Giris.mKodValue);

            CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");


            if (resp.Value == 0)
            {
                btnOzetEkranaDon.PerformClick();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Kapatma PH" || dataGridView1.Columns[e.ColumnIndex].Name == "Dolum Salamura PH" || dataGridView1.Columns[e.ColumnIndex].Name == "Dolum Salamura Bome")
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
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 1" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 2" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 3" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 4" || dataGridView2.Columns[e.ColumnIndex].Name == "Örnek 5")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog();
            }

        }

        private void txtUretimTarihi_Click(object sender, EventArgs e)
        {
            TarihGirisi tarihGirisi = new TarihGirisi(null,txtUretimTarihi);
            tarihGirisi.ShowDialog();
        }
    }
}

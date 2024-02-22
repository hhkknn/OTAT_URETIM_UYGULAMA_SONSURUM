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
    public partial class _20_FSAPKY_002_3 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_002_3(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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
        private void _20_FSAPKY_002_3_Load(object sender, EventArgs e)
        {
            richTextBox1.Text = "Ambalajlarda kırık,çatlak veya herhangi bir deformasyon yoktur.Yabancı Fiziksel Madde Kontaminasyonu Yoktur.Hayırsa Uygun olmayan ürün prosedürünü uygula.";

            richTextBox2.Text = "Gaz Ölçümü yapılmıştır,uygundur.Hayırsa Uygun olmayan ürün prosedürünü uygula.";

            richTextBox3.Text = "Ağırlık Kontrolü yapılmıştır,uygundur.Hayırsa Uygun olmayan ürün prosedürünü uygula.";

            txtPartiNo.Text = partiNo;
            txtUretimFisNo.Text = UretimFisNo;
            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
            txtUrunTanimi.Text = UrunTanimi;


            buttondefaultrenk = btnEvet.BackColor;

            #region Kontroller yapıldı mı sorgusu

            DataTable Kontroller = new DataTable();


            string sql = "SELECT \"U_Kontrol1\",\"U_Kontrol2\",\"U_Kontrol3\" FROM \"@AIF_FSAPKY002_3\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(Kontroller);


            if (Kontroller.Rows.Count > 0)
            {
                txtKontrol1.Text = Kontroller.Rows[0][0].ToString();
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


            if (Kontroller.Rows.Count > 0)
            {
                txtKontrol2.Text = Kontroller.Rows[0][1].ToString();
            }
            else
            {
                txtKontrol2.Text = "";
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


            if (Kontroller.Rows.Count > 0)
            {
                txtKontrol3.Text = Kontroller.Rows[0][2].ToString();
            }
            else
            {
                txtKontrol3.Text = "";
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

            try
            {
                #region dataGridView1 

                datagridView1Load();
                //dataTable1.Columns.Add("#", "#");
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
                //dataTable2.Columns.Add("#", "#");
                //dataTable2.Columns.Add("Saat", typeof(string));
                //dataTable2.Columns.Add("Ürün Adı", typeof(string));
                //dataTable2.Columns.Add("1.Göz CO2 %", typeof(string));
                //dataTable2.Columns.Add("1.Göz O2 %", typeof(string));
                //dataTable2.Columns.Add("2.Göz CO2 %", typeof(string));
                //dataTable2.Columns.Add("2.Göz O2 %", typeof(string));
                //dataTable2.Columns.Add("3.Göz CO2 %", typeof(string));
                //dataTable2.Columns.Add("3.Göz O2 %", typeof(string));
                //dataTable2.Columns.Add("Operatör Adı", typeof(string));

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

                //for (int j = 0; j < this.dataGridView2.ColumnCount; j++)
                //{
                //    this.dataGridView2.Columns[j].Width = 45;
                //}

                //this.dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //this.dataGridView2.ColumnHeadersHeight = this.dataGridView2.ColumnHeadersHeight * 2;
                //this.dataGridView2.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;
                //this.dataGridView2.CellPainting += new DataGridViewCellPaintingEventHandler(dataGridView2_CellPainting);
                //this.dataGridView2.Paint += new PaintEventHandler(dataGridView2_Paint);
                //this.dataGridView2.Scroll += new ScrollEventHandler(dataGridView2_Scroll);
                //this.dataGridView2.ColumnWidthChanged += new DataGridViewColumnEventHandler(dataGridView2_ColumnWidthChanged);
                #endregion

                #region dataGridView3

                datagridView3Load();
                //dataTable3.Columns.Add("#", "#");
                //dataTable3.Columns.Add("Ürün Adı", typeof(string));
                //dataTable3.Columns.Add("Örnek 1", typeof(string));
                //dataTable3.Columns.Add("Örnek 2", typeof(string));
                //dataTable3.Columns.Add("Örnek 3", typeof(string));
                //dataTable3.Columns.Add("Örnek 4", typeof(string));
                //dataTable3.Columns.Add("Örnek 5", typeof(string));
                //dataTable3.Columns.Add("Örnek 6", typeof(string));
                //dataTable3.Columns.Add("Örnek 7", typeof(string));
                //dataTable3.Columns.Add("Örnek 8", typeof(string));
                //dataTable3.Columns.Add("Örnek 9", typeof(string));
                //dataTable3.Columns.Add("Örnek 10", typeof(string));
                //dataTable3.Columns.Add("Operatör Adı", typeof(string));

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
                //dataTable4.Columns.Add("Ürün Adı", typeof(string));
                //dataTable4.Columns.Add("Duyusal Analiz Onayı", typeof(string));
                //dataTable4.Columns.Add("Sorumlu Mühendis", typeof(string));

                //dataTable4.Rows.Add("");
                //dataGridView4.DataSource = dataTable4;

                //dataGridView4.AllowUserToAddRows = false;
                //dataGridView4.AllowUserToDeleteRows = false;
                //dataGridView4.AllowUserToResizeColumns = false;
                //dataGridView4.AllowUserToResizeRows = false;
                //dataGridView4.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView4.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //dataGridView4.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(146,208,80);
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

            string sql = "SELECT T1.\"U_UrunKodu\" as \"Ürün Kodu\",T1.\"U_UrunAdi\" as \"Ürün Adı\",\"U_PaketSicak\" as \"Paketleme Sıcaklığı\",T1.\"U_UretimTarih\" as \"Üretim Tarihi\",\"U_SonTukTarih\" as \"Son Tüketim Tarihi\",T1.\"U_PartiNo\" as \"Parti Numarası\",\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY002_3\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY002_3_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Ürün Kodu"] = "";
                dr["Ürün Adı"] = "";
                dr["Paketleme Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Parti Numarası"] = "";
                dr["Operatör Adı"] = "";
                dataTable1.Rows.Add(dr);
            }

            dataGridView1.Columns["Ürün Kodu"].Visible = false;
            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {
            string sql = "SELECT T1.\"U_Saat\" as \"Saat\",T1.\"U_UrunKodu\" as \"Ürün Kodu\",T1.\"U_UrunAdi\" as \"Ürün Adı\",\"U_BirGozCO2\" as \"1.Göz CO2 %\",\"U_BirGozO2\" as \"1.Göz O2 %\",\"U_IkiGozCO2\" as \"2.Göz CO2 %\",\"U_IkiGozO2\" as \"2.Göz O2 %\",\"U_UcGozCO2\" as \"3.Göz CO2 %\",\"U_UcGozO2\" as \"3.Göz O2 %\",\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY002_3\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY002_3_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";


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
                dr["Saat"] = "";
                dr["Ürün Kodu"] = "";
                dr["Ürün Adı"] = "";
                dr["1.Göz CO2 %"] = Convert.ToString("0", cultureTR);
                dr["1.Göz O2 %"] = Convert.ToString("0", cultureTR);
                dr["2.Göz CO2 %"] = Convert.ToString("0", cultureTR);
                dr["2.Göz O2 %"] = Convert.ToString("0", cultureTR);
                dr["3.Göz CO2 %"] = Convert.ToString("0", cultureTR);
                dr["3.Göz O2 %"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";

                dataTable2.Rows.Add(dr);
            }

            dataGridView2.Columns["Ürün Kodu"].Visible = false;
            dataGridView2.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void datagridView3Load()
        {
            string sql = "SELECT T1.\"U_UrunKodu\" as \"Ürün Kodu\",T1.\"U_UrunAdi\" as \"Ürün Adı\",T1.\"U_Ornek1\" as \"Örnek 1\",T1.\"U_Ornek2\" as \"Örnek 2\",T1.\"U_Ornek3\" as \"Örnek 3\",T1.\"U_Ornek4\" as \"Örnek 4\",T1.\"U_Ornek5\" as \"Örnek 5\",T1.\"U_Ornek6\" as \"Örnek 6\",T1.\"U_Ornek7\" as \"Örnek 7\",T1.\"U_Ornek8\" as \"Örnek 8\",T1.\"U_Ornek9\" as \"Örnek 9\",T1.\"U_Ornek10\" as \"Örnek 10\",T1.\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY002_3\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY002_3_3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Ürün Kodu"] = "";
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
                dataTable3.Rows.Add(dr);
            }

            dataGridView3.Columns["Ürün Kodu"].Visible = false;
            dataGridView3.Columns["Operatör Adı"].ReadOnly = true;

        }

        private void datagridView4Load()
        {
            string sql = "SELECT T1.\"U_UrunKodu\" as \"Ürün Kodu\",T1.\"U_UrunAdi\" as \"Ürün Adı\",\"U_DuyAnlzOny\" as \"Duyusal Analiz Onayı\",\"U_SorumluMuh\" as \"Sorumlu Mühendis\" FROM \"@AIF_FSAPKY002_3\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY002_3_4\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";


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
                dr["Ürün Kodu"] = "";
                dr["Ürün Adı"] = "";
                dr["Duyusal Analiz Onayı"] = "";
                dr["Sorumlu Mühendis"] = "";

                dataTable4.Rows.Add(dr);
            }

            dataGridView4.Columns["Ürün Kodu"].Visible = false;
            dataGridView4.Columns["Sorumlu Mühendis"].ReadOnly = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Paketleme Sıcaklığı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Ürün Adı")
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

                    SelectList selectList = new SelectList(sql1, dataGridView1, 0, 1, _autoresizerow: false);
                    selectList.ShowDialog();
                }
                else
                {
                    CustomMsgBtn.Show("Ürün Bulunamadı.", "UYARI", "TAMAM");

                }

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
            if (dataGridView2.Columns[e.ColumnIndex].Name == "1.Göz CO2 %" || dataGridView2.Columns[e.ColumnIndex].Name == "1.Göz O2 %" || dataGridView2.Columns[e.ColumnIndex].Name == "2.Göz CO2 %" || dataGridView2.Columns[e.ColumnIndex].Name == "2.Göz O2 %" || dataGridView2.Columns[e.ColumnIndex].Name == "3.Göz CO2 %" || dataGridView2.Columns[e.ColumnIndex].Name == "3.Göz O2 %")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog();
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Ürün Adı")
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

                    SelectList selectList = new SelectList(sql1, dataGridView2, 1, 2, _autoresizerow: false);
                    selectList.ShowDialog();
                }
                else
                {
                    CustomMsgBtn.Show("Ürün Bulunamadı.", "UYARI", "TAMAM");

                }

            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Saat")
            {
                //    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, true);
                //    //n.ShowDialog();

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

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.Columns[e.ColumnIndex].Name == "Örnek 1" || dataGridView3.Columns[e.ColumnIndex].Name == "Örnek 2" || dataGridView3.Columns[e.ColumnIndex].Name == "Örnek 3" || dataGridView3.Columns[e.ColumnIndex].Name == "Örnek 4" || dataGridView3.Columns[e.ColumnIndex].Name == "Örnek 5" || dataGridView3.Columns[e.ColumnIndex].Name == "Örnek 6" || dataGridView3.Columns[e.ColumnIndex].Name == "Örnek 7" || dataGridView3.Columns[e.ColumnIndex].Name == "Örnek 8" || dataGridView3.Columns[e.ColumnIndex].Name == "Örnek 9" || dataGridView3.Columns[e.ColumnIndex].Name == "Örnek 10")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView3, false);
                n.ShowDialog();
            }
            else if (dataGridView3.Columns[e.ColumnIndex].Name == "Ürün Adı")
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

                    SelectList selectList = new SelectList(sql1, dataGridView3, 0, 1, _autoresizerow: false);
                    selectList.ShowDialog();
                }
                else
                {
                    CustomMsgBtn.Show("Ürün Bulunamadı.", "UYARI", "TAMAM");

                }

            }
            else if (dataGridView3.Columns[e.ColumnIndex].Name == "Operatör Adı")
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

        private void dataGridView4_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView4.Columns[e.ColumnIndex].Name == "Ürün Adı")
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

                    SelectList selectList = new SelectList(sql1, dataGridView4, 0, 1, _autoresizerow: false);
                    selectList.ShowDialog();
                }
                else
                {
                    CustomMsgBtn.Show("Ürün Bulunamadı.", "UYARI", "TAMAM");

                }

            }
            else if (dataGridView4.Columns[e.ColumnIndex].Name == "Duyusal Analiz Onayı")
            {
                string sql = "Select TOP 1 'Evet' as \"Onay1\" , 'Evet' as \"Onay\" ";
                sql += " UNION ALL ";
                sql += "Select TOP 1 'Hayır' as \"Onay1\" , 'Hayır' as \"Onay\"  ";
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                sda = new SqlDataAdapter(cmd);
                DataTable dt_Sorgu = new DataTable();
                sda.Fill(dt_Sorgu);

                if (dt_Sorgu.Rows.Count > 0)
                {
                    SelectList selectList = new SelectList(sql, dataGridView4, 2, -1, _autoresizerow: false);
                    selectList.ShowDialog();
                }
                else
                {
                    CustomMsgBtn.Show("Ürün Bulunamadı.", "UYARI", "TAMAM");

                }

            }
            else if (dataGridView4.Columns[e.ColumnIndex].Name == "Sorumlu Mühendis")
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

                    SelectList selectList = new SelectList(sql, dataGridView4, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();
                }
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

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                FSAPKY002_3 fSAPKY002_3 = new FSAPKY002_3();

                FSAPKY002_3_1 fSAPKY002_3_1 = new FSAPKY002_3_1();
                List<FSAPKY002_3_1> fSAPKY002_3_1s = new List<FSAPKY002_3_1>();



                FSAPKY002_3_2 fSAPKY002_3_2 = new FSAPKY002_3_2();
                List<FSAPKY002_3_2> fSAPKY002_3_2s = new List<FSAPKY002_3_2>();



                FSAPKY002_3_3 fSAPKY002_3_3 = new FSAPKY002_3_3();
                List<FSAPKY002_3_3> fSAPKY002_3_3s = new List<FSAPKY002_3_3>();



                FSAPKY002_3_4 fSAPKY002_3_4 = new FSAPKY002_3_4();
                List<FSAPKY002_3_4> fSAPKY002_3_4s = new List<FSAPKY002_3_4>();



                fSAPKY002_3.PartiNo = txtPartiNo.Text;
                fSAPKY002_3.UrunTanimi = txtUrunTanimi.Text;

                #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
                //fSAPKY002_3.Tarih = tarih1;
                DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                fSAPKY002_3.Tarih = uretimtarihi.ToString("yyyyMMdd");
                #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

                fSAPKY002_3.Aciklama = "";
                fSAPKY002_3.UrunKodu = urunKodu;
                fSAPKY002_3.Kontrol1 = txtKontrol1.Text;
                fSAPKY002_3.Kontrol2 = txtKontrol2.Text;
                fSAPKY002_3.Kontrol3 = txtKontrol3.Text;


                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    fSAPKY002_3_1 = new FSAPKY002_3_1();
                    fSAPKY002_3_1.UrunKodu = dr.Cells["Ürün Kodu"].Value == DBNull.Value ? "" : dr.Cells["Ürün Kodu"].Value.ToString();
                    fSAPKY002_3_1.UrunAdi = dr.Cells["Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Ürün Adı"].Value.ToString();
                    fSAPKY002_3_1.PaketlemeSicakligi = dr.Cells["Paketleme Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Paketleme Sıcaklığı"].Value);
                    fSAPKY002_3_1.UretimTarihi = dr.Cells["Üretim Tarihi"].Value == DBNull.Value ? new DateTime(1900, 01, 01) : Convert.ToDateTime(dr.Cells["Üretim Tarihi"].Value);
                    fSAPKY002_3_1.SonTuketimTarihi = dr.Cells["Son Tüketim Tarihi"].Value == DBNull.Value ? new DateTime(1900, 01, 01) : Convert.ToDateTime(dr.Cells["Son Tüketim Tarihi"].Value);
                    fSAPKY002_3_1.PartiNumarasi = dr.Cells["Parti Numarası"].Value == DBNull.Value ? "" : dr.Cells["Parti Numarası"].Value.ToString();
                    fSAPKY002_3_1.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

                    fSAPKY002_3_1s.Add(fSAPKY002_3_1);
                }

                fSAPKY002_3.fSAPKY002_3_1s = fSAPKY002_3_1s.ToArray();

                foreach (DataGridViewRow dr in dataGridView2.Rows)
                {
                    fSAPKY002_3_2 = new FSAPKY002_3_2();

                    fSAPKY002_3_2.Saat = dr.Cells["Saat"].Value == DBNull.Value ? "" : dr.Cells["Saat"].Value.ToString();
                    fSAPKY002_3_2.UrunKodu = dr.Cells["Ürün Kodu"].Value == DBNull.Value ? "" : dr.Cells["Ürün Kodu"].Value.ToString();
                    fSAPKY002_3_2.UrunAdi = dr.Cells["Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Ürün Adı"].Value.ToString();
                    fSAPKY002_3_2.BirinciGozCO2 = dr.Cells["1.Göz CO2 %"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["1.Göz CO2 %"].Value);
                    fSAPKY002_3_2.BirinciGozO2 = dr.Cells["1.Göz O2 %"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["1.Göz O2 %"].Value);
                    fSAPKY002_3_2.IkinciGozCO2 = dr.Cells["2.Göz CO2 %"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["2.Göz CO2 %"].Value);
                    fSAPKY002_3_2.IkinciGozO2 = dr.Cells["2.Göz O2 %"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["2.Göz O2 %"].Value);
                    fSAPKY002_3_2.UcuncuGozCO2 = dr.Cells["3.Göz CO2 %"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["3.Göz CO2 %"].Value);
                    fSAPKY002_3_2.UcuncuGozO2 = dr.Cells["3.Göz O2 %"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["3.Göz O2 %"].Value);
                    fSAPKY002_3_2.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();


                    fSAPKY002_3_2s.Add(fSAPKY002_3_2);
                }

                fSAPKY002_3.fSAPKY002_3_2s = fSAPKY002_3_2s.ToArray();


                foreach (DataGridViewRow dr in dataGridView3.Rows)
                {
                    fSAPKY002_3_3 = new FSAPKY002_3_3();

                    fSAPKY002_3_3.UrunKodu = dr.Cells["Ürün Kodu"].Value == DBNull.Value ? "" : dr.Cells["Ürün Kodu"].Value.ToString();
                    fSAPKY002_3_3.UrunAdi = dr.Cells["Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Ürün Adı"].Value.ToString();
                    fSAPKY002_3_3.Ornek1 = dr.Cells["Örnek 1"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 1"].Value);
                    fSAPKY002_3_3.Ornek2 = dr.Cells["Örnek 2"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 2"].Value);
                    fSAPKY002_3_3.Ornek3 = dr.Cells["Örnek 3"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 3"].Value);
                    fSAPKY002_3_3.Ornek4 = dr.Cells["Örnek 4"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 4"].Value);
                    fSAPKY002_3_3.Ornek5 = dr.Cells["Örnek 5"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 5"].Value);
                    fSAPKY002_3_3.Ornek6 = dr.Cells["Örnek 6"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 6"].Value);
                    fSAPKY002_3_3.Ornek7 = dr.Cells["Örnek 7"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 7"].Value);
                    fSAPKY002_3_3.Ornek8 = dr.Cells["Örnek 8"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 8"].Value);
                    fSAPKY002_3_3.Ornek9 = dr.Cells["Örnek 9"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 9"].Value);
                    fSAPKY002_3_3.Ornek10 = dr.Cells["Örnek 10"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Örnek 10"].Value);
                    fSAPKY002_3_3.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();


                    fSAPKY002_3_3s.Add(fSAPKY002_3_3);
                }
                fSAPKY002_3.fSAPKY002_3_3s = fSAPKY002_3_3s.ToArray();


                //dataTable4.Columns.Add("Ürün Adı", typeof(string));
                //dataTable4.Columns.Add("Duyusal Analiz Onayı", typeof(string));
                //dataTable4.Columns.Add("Sorumlu Mühendis", typeof(string));

                foreach (DataGridViewRow dr in dataGridView4.Rows)
                {
                    fSAPKY002_3_4 = new FSAPKY002_3_4();

                    fSAPKY002_3_4.UrunKodu = dr.Cells["Ürün Kodu"].Value == DBNull.Value ? "" : dr.Cells["Ürün Kodu"].Value.ToString();
                    fSAPKY002_3_4.UrunAdi = dr.Cells["Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Ürün Adı"].Value.ToString();
                    fSAPKY002_3_4.DuyusalAnalizOnayi = dr.Cells["Duyusal Analiz Onayı"].Value == DBNull.Value ? "" : dr.Cells["Duyusal Analiz Onayı"].Value.ToString();
                    fSAPKY002_3_4.SorumluMuhendis = dr.Cells["Sorumlu Mühendis"].Value == DBNull.Value ? "" : dr.Cells["Sorumlu Mühendis"].Value.ToString();


                    fSAPKY002_3_4s.Add(fSAPKY002_3_4);
                }

                fSAPKY002_3.fSAPKY002_3_4s = fSAPKY002_3_4s.ToArray();

                var resp = client.addOrUpdateFSAPKY002_3(fSAPKY002_3, Giris.dbName, Giris.mKodValue);

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

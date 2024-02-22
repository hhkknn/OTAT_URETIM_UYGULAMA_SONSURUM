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
    public partial class _20_FSAPKY_004_2 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_004_2(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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
        private SqlCommand cmd;

        private string UretimFisNo = "";
        private string partiNo = "";
        private string istasyon = "";
        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private int row = 0;
        private string tarih1 = "";
        private string urunKodu = "";
        private void _20_FSAPKY_004_2_Load(object sender, EventArgs e)
        {
            try
            {
                grid1Secildi = true;

                txtPartiNo.Text = partiNo;
                txtUretimFisNo.Text = UretimFisNo;
                txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                txtUrunTanimi.Text = UrunTanimi;

                #region dataGridView1 
                datagridView1Load();
                //dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Proses No", typeof(string));
                //dataTable1.Columns.Add("Yarı Mamül Miktarı", typeof(string));
                //dataTable1.Columns.Add("Eklenen Lor Miktarı", typeof(string));
                //dataTable1.Columns.Add("Homojen Basıncı", typeof(string));
                //dataTable1.Columns.Add("Pastorizasyon Sıcaklığı", typeof(string));
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
                //dataTable2.Columns.Add("Yarı Mamül PH", typeof(string));
                //dataTable2.Columns.Add("Yarı Mamül SH", typeof(string));
                //dataTable2.Columns.Add("Yarı Mamül KM", typeof(string));
                //dataTable2.Columns.Add("Yarı Mamül Yağ", typeof(string));
                //dataTable2.Columns.Add("Lor KM", typeof(string));
                //dataTable2.Columns.Add("LOR Yağ", typeof(string));
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

                #region dataGridView3

                datagridView3Load();
                //dataTable3.Columns.Add("#", "#");
                //dataTable3.Columns.Add("Ürün Adı", typeof(string));
                //dataTable3.Columns.Add("Duyusal Analiz Onayı", typeof(string));
                //dataTable3.Columns.Add("Sorumlu Mühendis", typeof(string));

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
        }


        private void datagridView1Load()
        {

            string sql = "SELECT T1.\"U_ProsesNo\" as \"Proses No\",T1.\"U_YariMamMik\" as \"Yarı Mamül Miktarı\",\"U_EkLorMik\" as \"Eklenen Lor Miktarı\",T1.\"U_HmjBasinc\" as \"Homojen Basıncı\",\"U_PastSic\" as \"Pastorizasyon Sıcaklığı\",\"U_UFOprtAdi\" as \"UF Operatör Adı\" FROM \"@AIF_FSAPKY004_2\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY004_2_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

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
                dr["Proses No"] = "";
                dr["Yarı Mamül Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Eklenen Lor Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Homojen Basıncı"] = Convert.ToString("0", cultureTR);
                dr["Pastorizasyon Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["UF Operatör Adı"] = "";
                dataTable1.Rows.Add(dr);
            }
            dataGridView1.Columns["UF Operatör Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {


            string sql = "SELECT T1.\"U_YariMamPH\" as \"Yarı Mamül PH\",T1.\"U_YariMamSH\" as \"Yarı Mamül SH\",\"U_YariMamKM\" as \"Yarı Mamül KM\",\"U_YariMamYag\" as \"Yarı Mamül Yağ\",\"U_LorKM\" as \"Lor KM\",\"U_LorYagi\" as \"Lor Yağ\",\"U_LabPersAdi\" as \"Laboratuvar Personel Adı\"  FROM \"@AIF_FSAPKY004_2\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY004_2_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";


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
                dr["Yarı Mamül PH"] = Convert.ToString("0", cultureTR);
                dr["Yarı Mamül SH"] = Convert.ToString("0", cultureTR);
                dr["Yarı Mamül KM"] = Convert.ToString("0", cultureTR);
                dr["Yarı Mamül Yağ"] = Convert.ToString("0", cultureTR);
                dr["Lor KM"] = Convert.ToString("0", cultureTR);
                dr["Lor Yağ"] = Convert.ToString("0", cultureTR);
                dr["Laboratuvar Personel Adı"] = "";

                dataTable2.Rows.Add(dr);
            }

            dataGridView2.Columns["Laboratuvar Personel Adı"].ReadOnly = true;
        }

        private void datagridView3Load()
        {
            string sql = "SELECT T1.\"U_UrunKodu\" as \"Ürün Kodu\",T1.\"U_UrunAdi\" as \"Ürün Adı\",\"U_DuyAnlzOny\" as \"Duyusal Analiz Onayı\",\"U_SorumluMuh\" as \"Sorumlu Mühendis\" FROM \"@AIF_FSAPKY004_2\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY004_2_3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";


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
                dr["Duyusal Analiz Onayı"] = "";
                dr["Sorumlu Mühendis"] = "";

                dataTable3.Rows.Add(dr);
            }

            dataGridView3.Columns["Ürün Kodu"].Visible = false;
            dataGridView3.Columns["Sorumlu Mühendis"].ReadOnly = true;

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            currentCell = e.RowIndex;
            grid1Secildi = true;
            grid2Secildi = false;
            //grid3Secildi = false;
            #endregion

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Proses No")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();

                string val = "";

                if (dataTable1.Rows.Count == 0)
                {
                    val = dataGridView1.Rows[0].Cells[e.ColumnIndex].Value.ToString();
                }
                else
                {
                    val = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[e.ColumnIndex].Value.ToString();

                }

                if (val != "")
                {
                    DataRow dr = dataTable1.NewRow();
                    dr["Proses No"] = "";

                    dataTable1.Rows.Add(dr);

                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Yarı Mamül Miktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Eklenen Lor Miktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Homojen Basıncı" || dataGridView1.Columns[e.ColumnIndex].Name == "Pastorizasyon Sıcaklığı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
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
            #region satır ekle sil işlemi için kulanılır
            currentCell = e.RowIndex;
            grid1Secildi = false;
            grid2Secildi = true;
            //grid3Secildi = false;
            #endregion

            if (dataGridView2.Columns[e.ColumnIndex].Name == "Yarı Mamül PH" || dataGridView2.Columns[e.ColumnIndex].Name == "Yarı Mamül SH" || dataGridView2.Columns[e.ColumnIndex].Name == "Yarı Mamül KM" || dataGridView2.Columns[e.ColumnIndex].Name == "Yarı Mamül Yağ" || dataGridView2.Columns[e.ColumnIndex].Name == "Lor KM" || dataGridView2.Columns[e.ColumnIndex].Name == "Lor Yağ")
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
            #region satır ekle sil işlemi için kulanılır
            //currentCell = e.RowIndex;
            //grid1Secildi = false;
            //grid2Secildi = false;
            //grid3Secildi = true;
            #endregion

            if (dataGridView3.Columns[e.ColumnIndex].Name == "Ürün Adı")
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
            else if (dataGridView3.Columns[e.ColumnIndex].Name == "Duyusal Analiz Onayı")
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
                    SelectList selectList = new SelectList(sql, dataGridView3, 2, -1, _autoresizerow: false);
                    selectList.ShowDialog();
                }
                else
                {
                    CustomMsgBtn.Show("Ürün Bulunamadı.", "UYARI", "TAMAM");

                }

            }
            else if (dataGridView3.Columns[e.ColumnIndex].Name == "Sorumlu Mühendis")
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

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                FSAPKY004_2 fSAPKY004_2 = new FSAPKY004_2();
                List<FSAPKY004_2_1> fSAPKY004_2_1s = new List<FSAPKY004_2_1>();
                FSAPKY004_2_1 fSAPKY004_2_1 = new FSAPKY004_2_1();
                List<FSAPKY004_2_2> fSAPKY004_2_2s = new List<FSAPKY004_2_2>();
                FSAPKY004_2_2 fSAPKY004_2_2 = new FSAPKY004_2_2();
                List<FSAPKY004_2_3> fSAPKY004_2_3s = new List<FSAPKY004_2_3>();
                FSAPKY004_2_3 fSAPKY004_2_3 = new FSAPKY004_2_3();



                fSAPKY004_2.PartiNo = txtPartiNo.Text;
                fSAPKY004_2.UrunTanimi = txtUrunTanimi.Text;

                #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
                //fSAPKY004_2.Tarih = tarih1;
                DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                fSAPKY004_2.Tarih = uretimtarihi.ToString("yyyyMMdd");
                #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

                fSAPKY004_2.Aciklama = "";
                fSAPKY004_2.UrunKodu = urunKodu;

                foreach (DataGridViewRow dr in dataGridView1.Rows)
                {
                    fSAPKY004_2_1 = new FSAPKY004_2_1();
                    fSAPKY004_2_1.ProsesNo = dr.Cells["Proses No"].Value == DBNull.Value ? "" : dr.Cells["Proses No"].Value.ToString();
                    fSAPKY004_2_1.YariMamulMiktari = dr.Cells["Yarı Mamül Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yarı Mamül Miktarı"].Value);
                    fSAPKY004_2_1.EklenenLorMiktari = dr.Cells["Eklenen Lor Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Eklenen Lor Miktarı"].Value);
                    fSAPKY004_2_1.HomojenBasinci = dr.Cells["Homojen Basıncı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Homojen Basıncı"].Value);
                    fSAPKY004_2_1.PastorizasyonSicakligi = dr.Cells["Pastorizasyon Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastorizasyon Sıcaklığı"].Value);
                    fSAPKY004_2_1.UFOperatorAdi = dr.Cells["UF Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["UF Operatör Adı"].Value.ToString();

                    fSAPKY004_2_1s.Add(fSAPKY004_2_1);
                }

                fSAPKY004_2.fSAPKY004_2_1s = fSAPKY004_2_1s.ToArray();

                foreach (DataGridViewRow dr in dataGridView2.Rows)
                {
                    fSAPKY004_2_2 = new FSAPKY004_2_2();
                    fSAPKY004_2_2.YariMamulPH = dr.Cells["Yarı Mamül PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yarı Mamül PH"].Value);
                    fSAPKY004_2_2.YariMamulSH = dr.Cells["Yarı Mamül SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yarı Mamül SH"].Value);
                    fSAPKY004_2_2.YariMamulKM = dr.Cells["Yarı Mamül KM"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yarı Mamül KM"].Value);
                    fSAPKY004_2_2.YariMamulYag = dr.Cells["Yarı Mamül Yağ"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yarı Mamül Yağ"].Value);
                    fSAPKY004_2_2.LorKM = dr.Cells["Lor KM"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Lor KM"].Value);
                    fSAPKY004_2_2.LorYagi = dr.Cells["Lor Yağ"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Lor Yağ"].Value);
                    fSAPKY004_2_2.LabPersonelAdi = dr.Cells["Laboratuvar Personel Adı"].Value == DBNull.Value ? "" : dr.Cells["Laboratuvar Personel Adı"].Value.ToString();


                    fSAPKY004_2_2s.Add(fSAPKY004_2_2);
                }

                fSAPKY004_2.fSAPKY004_2_2s = fSAPKY004_2_2s.ToArray();


                foreach (DataGridViewRow dr in dataGridView3.Rows)
                {
                    fSAPKY004_2_3 = new FSAPKY004_2_3();
                    fSAPKY004_2_3.UrunKodu = dr.Cells["Ürün Kodu"].Value == DBNull.Value ? "" : dr.Cells["Ürün Kodu"].Value.ToString();
                    fSAPKY004_2_3.UrunAdi = dr.Cells["Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Ürün Adı"].Value.ToString();
                    fSAPKY004_2_3.DuyusalAnalizOnayi = dr.Cells["Duyusal Analiz Onayı"].Value == DBNull.Value ? "" : dr.Cells["Duyusal Analiz Onayı"].Value.ToString();
                    fSAPKY004_2_3.SorumluMuhendis = dr.Cells["Sorumlu Mühendis"].Value == DBNull.Value ? "" : dr.Cells["Sorumlu Mühendis"].Value.ToString();


                    fSAPKY004_2_3s.Add(fSAPKY004_2_3);
                }

                fSAPKY004_2.fSAPKY004_2_3s = fSAPKY004_2_3s.ToArray();


                var resp = client.addOrUpdateFSAPKY004_2(fSAPKY004_2, Giris.dbName, Giris.mKodValue);

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
        bool grid1Secildi = false;
        bool grid2Secildi = false;
        bool grid3Secildi = false;
        int currentCell = -1;
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            grid1Secildi = true;
            grid2Secildi = false;
            //grid3Secildi = false;
            #endregion
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            grid1Secildi = false;
            grid2Secildi = true;
            //grid3Secildi = false;
            #endregion
        }

        private void dataGridView3_Click(object sender, EventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            grid1Secildi = false;
            grid2Secildi = false;
            //grid3Secildi = true;
            #endregion
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

            //if (grid3Secildi)
            //{
            //    if (currentCell != -1)
            //    {
            //        if (dataGridView3.Rows.Count > 1)
            //        {
            //            dataGridView3.Rows.RemoveAt(currentCell);
            //        }
            //    }
            //}

            currentCell = -1;
        }

        private void btnSatirEkle_Click(object sender, EventArgs e)
        {
            if (grid1Secildi)
            {
                try
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dataTable1.NewRow();
                    dr["Proses No"] = "";
                    dr["Yarı Mamül Miktarı"] = Convert.ToString("0", cultureTR);
                    dr["Eklenen Lor Miktarı"] = Convert.ToString("0", cultureTR);
                    dr["Homojen Basıncı"] = Convert.ToString("0", cultureTR);
                    dr["Pastorizasyon Sıcaklığı"] = Convert.ToString("0", cultureTR);
                    dr["UF Operatör Adı"] = "";
                    dataTable1.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                }
            }

            if (grid2Secildi)
            {
                try
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dataTable2.NewRow();
                    dr["Yarı Mamül PH"] = Convert.ToString("0", cultureTR);
                    dr["Yarı Mamül SH"] = Convert.ToString("0", cultureTR);
                    dr["Yarı Mamül KM"] = Convert.ToString("0", cultureTR);
                    dr["Yarı Mamül Yağ"] = Convert.ToString("0", cultureTR);
                    dr["Lor KM"] = Convert.ToString("0", cultureTR);
                    dr["Lor Yağ"] = Convert.ToString("0", cultureTR);
                    dr["Laboratuvar Personel Adı"] = "";

                    dataTable2.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                }
            }

            //if (grid3Secildi)
            //{ 
            //    try
            //    {
            //        System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

            //        DataRow dr = dataTable3.NewRow();
            //        dr["Ürün Kodu"] = "";
            //        dr["Ürün Adı"] = "";
            //        dr["Duyusal Analiz Onayı"] = "";
            //        dr["Sorumlu Mühendis"] = "";

            //        dataTable3.Rows.Add(dr);
            //    }
            //    catch (Exception ex)
            //    {
            //    } 
            //}
        }
    }
}

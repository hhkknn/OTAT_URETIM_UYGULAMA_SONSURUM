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
    public partial class _20_FSAPKY_007_2_2 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_007_2_2(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu, DataTable _dtgfSAPKY007_2_1_1_DataTable, DataTable _dtgfSAPKY007_2_1_2_DataTable, DataTable _dtgfSAPKY007_2_2_1_DataTable, DataTable _dtgfSAPKY007_2_2_2_DataTable, TextBox _kontrol1)
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

            dtgfSAPKY007_2_1_1_DataTable = _dtgfSAPKY007_2_1_1_DataTable;
            dtgfSAPKY007_2_1_2_DataTable = _dtgfSAPKY007_2_1_2_DataTable;
            dtgfSAPKY007_2_2_1_DataTable = _dtgfSAPKY007_2_2_1_DataTable;
            dtgfSAPKY007_2_2_2_DataTable = _dtgfSAPKY007_2_2_2_DataTable; 
            txtkontrol1_IlkEkran = _kontrol1; 

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

            label9.Font = new Font(label9.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              label9.Font.Style);

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

            btnAnaliz1.Font = new Font(btnAnaliz1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnAnaliz1.Font.Style);

            btnAnaliz2.Font = new Font(btnAnaliz2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnAnaliz2.Font.Style);

            btnAnaliz3.Font = new Font(btnAnaliz3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnAnaliz3.Font.Style);

            btnAnaliz4.Font = new Font(btnAnaliz4.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnAnaliz4.Font.Style);

            btnAnaliz5.Font = new Font(btnAnaliz5.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnAnaliz5.Font.Style);

            button6.Font = new Font(button6.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button6.Font.Style);

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

        private string UretimFisNo = "";
        private string partiNo = "";
        private string istasyon = "";
        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private string urunKodu = "";
        private int row = 0;
        //private SqlCommand cmd = null;
        private string tarih1 = "";
        private SqlCommand cmd = null;
        Color buttondefaultrenk = Color.Gray;

        DataTable dtgfSAPKY007_2_1_1_DataTable = new DataTable();
        DataTable dtgfSAPKY007_2_1_2_DataTable = new DataTable();
        DataTable dtgfSAPKY007_2_2_1_DataTable = new DataTable();
        DataTable dtgfSAPKY007_2_2_2_DataTable = new DataTable();

        TextBox txtkontrol1_IlkEkran;


        private void _20_FSAPKY_007_2_2_Load(object sender, EventArgs e)
        {
            txtPartiNo.Text = partiNo;
            txtUretimFisNo.Text = UretimFisNo;
            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
            txtUrunTanimi.Text = UrunTanimi;
            richTextBox1.Text = "Kültürün kontrolü yapılmıştır.Bir fiziksel deformasyon ve bulaşma söz konusu değildir.Saklama koşulları sağlanmıştır.Hayır ise Uygun olmayan ürün prosedürünü uygulayınız.";

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
            try
            {
                #region dataGridView1 

                datagridView1Load();
                //dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Tank No", typeof(string));
                //dataTable1.Columns.Add("Palet No", typeof(string));
                //dataTable1.Columns.Add("1.Analiz(Saat)", typeof(string));
                //dataTable1.Columns.Add("2.Analiz(Saat)", typeof(string));
                //dataTable1.Columns.Add("3.Analiz(Saat)", typeof(string));
                //dataTable1.Columns.Add("4.Analiz(Saat)", typeof(string));
                //dataTable1.Columns.Add("5.Analiz(Saat)", typeof(string));
                //dataTable1.Columns.Add("1.Analiz(PH)", typeof(string));
                //dataTable1.Columns.Add("2.Analiz(PH)", typeof(string));
                //dataTable1.Columns.Add("3.Analiz(PH)", typeof(string));
                //dataTable1.Columns.Add("4.Analiz(PH)", typeof(string));
                //dataTable1.Columns.Add("5.Analiz(PH)", typeof(string));
                //dataTable1.Columns.Add("1.Analiz(SH)", typeof(string));
                //dataTable1.Columns.Add("2.Analiz(SH)", typeof(string));
                //dataTable1.Columns.Add("3.Analiz(SH)", typeof(string));
                //dataTable1.Columns.Add("4.Analiz(SH)", typeof(string));
                //dataTable1.Columns.Add("5.Analiz(SH)", typeof(string));
                //dataTable1.Columns.Add("Operatör Adı", typeof(string));

                //dataTable1.Rows.Add("");
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
                //dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(146, 208, 80);
                //dataGridView1.DefaultCellStyle.BackColor = Color.WhiteSmoke;

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
                //dataTable2.Columns.Add("Tank No", typeof(string));
                //dataTable2.Columns.Add("Saat", typeof(string));
                //dataTable2.Columns.Add("PH", typeof(string));
                //dataTable2.Columns.Add("SH", typeof(string));
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
                 

                if (txtSeciliAnaliz.Text == "analiz1")
                {
                    btnAnaliz2.BackColor = buttondefaultrenk;
                    btnAnaliz3.BackColor = buttondefaultrenk;
                    btnAnaliz4.BackColor = buttondefaultrenk;
                    btnAnaliz5.BackColor = buttondefaultrenk;
                    btnAnaliz1.BackColor = Color.GreenYellow;
                }
                else if (txtSeciliAnaliz.Text == "analiz2")
                {
                    btnAnaliz1.BackColor = buttondefaultrenk;
                    btnAnaliz3.BackColor = buttondefaultrenk;
                    btnAnaliz4.BackColor = buttondefaultrenk;
                    btnAnaliz5.BackColor = buttondefaultrenk;
                    btnAnaliz2.BackColor = Color.GreenYellow;
                }
                else if (txtSeciliAnaliz.Text == "analiz3")
                {
                    btnAnaliz1.BackColor = buttondefaultrenk;
                    btnAnaliz2.BackColor = buttondefaultrenk;
                    btnAnaliz4.BackColor = buttondefaultrenk;
                    btnAnaliz5.BackColor = buttondefaultrenk;
                    btnAnaliz3.BackColor = Color.GreenYellow;
                }
                else if (txtSeciliAnaliz.Text == "analiz4")
                {
                    btnAnaliz1.BackColor = buttondefaultrenk;
                    btnAnaliz2.BackColor = buttondefaultrenk;
                    btnAnaliz3.BackColor = buttondefaultrenk;
                    btnAnaliz5.BackColor = buttondefaultrenk;
                    btnAnaliz4.BackColor = Color.GreenYellow;
                }
                else if (txtSeciliAnaliz.Text == "analiz5")
                {
                    btnAnaliz1.BackColor = buttondefaultrenk;
                    btnAnaliz2.BackColor = buttondefaultrenk;
                    btnAnaliz3.BackColor = buttondefaultrenk;
                    btnAnaliz4.BackColor = buttondefaultrenk;
                    btnAnaliz5.BackColor = Color.GreenYellow;
                }
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
            //_20_ANALIZ_EKRANLARI _20_ANALIZ_EKRANLARI = new _20_ANALIZ_EKRANLARI();
            //_20_ANALIZ_EKRANLARI.Show();
            //Close();
        }

        private void btnSolaGit_Click(object sender, EventArgs e)
        {
            geriDonme = "SolaGit";
            Close();
        }

        private void datagridView1Load()
        {

            dataGridView1.DataSource = dtgfSAPKY007_2_2_1_DataTable;


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

            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {

            dataGridView2.DataSource = dtgfSAPKY007_2_2_2_DataTable;

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

            dataGridView2.Columns["Operatör Adı"].ReadOnly = true;
        }
        public static string geriDonme = "";
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Tank No" || dataGridView1.Columns[e.ColumnIndex].Name == "Palet No")
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
            else if (txtSeciliAnaliz.Text == "analiz1")
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "1.Analiz(PH)" || dataGridView1.Columns[e.ColumnIndex].Name == "1.Analiz(SH)")
                {
                    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                    n.ShowDialog();
                }
                if (dataGridView1.Columns[e.ColumnIndex].Name == "1.Analiz(Saat)")
                {
                    SaatTarihGirisi n = new SaatTarihGirisi(dataGridView1);
                    n.ShowDialog();
                }
            }
            else if (txtSeciliAnaliz.Text == "analiz2")
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "2.Analiz(PH)" || dataGridView1.Columns[e.ColumnIndex].Name == "2.Analiz(SH)")
                {
                    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                    n.ShowDialog();
                }

                if (dataGridView1.Columns[e.ColumnIndex].Name == "2.Analiz(Saat)")
                {
                    SaatTarihGirisi n = new SaatTarihGirisi(dataGridView1);
                    n.ShowDialog();
                }
            }
            else if (txtSeciliAnaliz.Text == "analiz3")
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "3.Analiz(PH)" || dataGridView1.Columns[e.ColumnIndex].Name == "3.Analiz(SH)")
                {
                    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                    n.ShowDialog();
                }

                if (dataGridView1.Columns[e.ColumnIndex].Name == "3.Analiz(Saat)")
                {
                    SaatTarihGirisi n = new SaatTarihGirisi(dataGridView1);
                    n.ShowDialog();
                }
            }
            else if (txtSeciliAnaliz.Text == "analiz4")
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "4.Analiz(PH)" || dataGridView1.Columns[e.ColumnIndex].Name == "4.Analiz(SH)")
                {
                    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                    n.ShowDialog();
                }

                if (dataGridView1.Columns[e.ColumnIndex].Name == "4.Analiz(Saat)")
                {
                    SaatTarihGirisi n = new SaatTarihGirisi(dataGridView1);
                    n.ShowDialog();
                }
            }
            else if (txtSeciliAnaliz.Text == "analiz5")
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "5.Analiz(PH)" || dataGridView1.Columns[e.ColumnIndex].Name == "5.Analiz(SH)")
                {
                    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                    n.ShowDialog();
                }

                if (dataGridView1.Columns[e.ColumnIndex].Name == "5.Analiz(Saat)")
                {
                    SaatTarihGirisi n = new SaatTarihGirisi(dataGridView1);
                    n.ShowDialog();
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Tank No" || dataGridView2.Columns[e.ColumnIndex].Name == "PH" || dataGridView2.Columns[e.ColumnIndex].Name == "SH")
            {
                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog();
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Saat")
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

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            tabloyaKaydetmeIslemleri();
        }

        private void btnAnaliz1_Click(object sender, EventArgs e)
        {
            btnAnaliz2.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = buttondefaultrenk;
            btnAnaliz1.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz1";
            //_20_FSAPKY_007_2_1.seciliAnaliz = "analiz1";
        }

        private void btnAnaliz2_Click(object sender, EventArgs e)
        {
            btnAnaliz1.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = buttondefaultrenk;
            btnAnaliz2.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz2";
            //_20_FSAPKY_007_2_1.seciliAnaliz = "analiz2";
        }

        private void btnAnaliz3_Click(object sender, EventArgs e)
        {
            btnAnaliz1.BackColor = buttondefaultrenk;
            btnAnaliz2.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz3";
            //_20_FSAPKY_007_2_1.seciliAnaliz = "analiz3";

        }

        private void btnAnaliz4_Click(object sender, EventArgs e)
        {
            btnAnaliz1.BackColor = buttondefaultrenk;
            btnAnaliz2.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz4";
            //_20_FSAPKY_007_2_1.seciliAnaliz = "analiz4";

        }

        private void btnAnaliz5_Click(object sender, EventArgs e)
        {
            btnAnaliz1.BackColor = buttondefaultrenk;
            btnAnaliz2.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz5";
            //_20_FSAPKY_007_2_1.seciliAnaliz = "analiz5";

        }

        public void tabloyaKaydetmeIslemleri()
        {

            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                FSAPKY007_2 nesne = new FSAPKY007_2();
                FSAPKY007_2_1_1 fSAPKY007_2_1_1 = new FSAPKY007_2_1_1();
                List<FSAPKY007_2_1_1> fSAPKY007_2_1_1s = new List<FSAPKY007_2_1_1>();
                FSAPKY007_2_1_2 fSAPKY007_2_1_2 = new FSAPKY007_2_1_2();
                List<FSAPKY007_2_1_2> fSAPKY007_2_1_2s = new List<FSAPKY007_2_1_2>();
                FSAPKY007_2_2_1 fSAPKY007_2_2_1 = new FSAPKY007_2_2_1();
                List<FSAPKY007_2_2_1> fSAPKY007_2_2_1s = new List<FSAPKY007_2_2_1>();
                FSAPKY007_2_2_2 fSAPKY007_2_2_2 = new FSAPKY007_2_2_2();
                List<FSAPKY007_2_2_2> fSAPKY007_2_2_2s = new List<FSAPKY007_2_2_2>();


                nesne.PartiNo = partiNo;
                nesne.UrunKodu = urunKodu;
                nesne.UrunTanimi = UrunTanimi;

                #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
                //nesne.Tarih = tarih1;
                DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                nesne.Tarih = uretimtarihi.ToString("yyyyMMdd");
                #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

                nesne.DigerKaliteKontroller = txtKontrol1.Text;

                foreach (DataRow dr in dtgfSAPKY007_2_1_1_DataTable.Rows)
                {
                    fSAPKY007_2_1_1 = new FSAPKY007_2_1_1();
                    fSAPKY007_2_1_1.BaslangicSaati = dr["Başlangıç Saati"] == DBNull.Value ? "" : dr["Başlangıç Saati"].ToString();
                    fSAPKY007_2_1_1.PastorizasyonSicakligi = dr["Pastorizasyon Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastorizasyon Sıcaklığı"]);
                    fSAPKY007_2_1_1.PastorizasyonCikis = dr["Pastorizasyon Çıkış"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastorizasyon Çıkış"]);
                    fSAPKY007_2_1_1.HolderSuresi = (dr["Holder Süresi"] == DBNull.Value || dr["Holder Süresi"].ToString() == "") ? 0 : Convert.ToInt32(dr["Holder Süresi"]);
                    fSAPKY007_2_1_1.HomojenizasyonBasinc = dr["Homojenizasyon Basınç"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Homojenizasyon Basınç"]);
                    fSAPKY007_2_1_1.SuluAyranSutuMiktari = dr["Sulu Ayran Sütü Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Sulu Ayran Sütü Miktarı"]);
                    fSAPKY007_2_1_1.CekilenKremaMiktari = dr["Çekilen Krema Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Çekilen Krema Miktarı"]);
                    fSAPKY007_2_1_1.StandartAyranSutuMiktari = dr["Stand. Ayran Sütü Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Stand. Ayran Sütü Miktarı"]);
                    fSAPKY007_2_1_1.BitisSaati = dr["Bitiş Saati"] == DBNull.Value ? "" : dr["Bitiş Saati"].ToString();
                    fSAPKY007_2_1_1.OperatorAdi = dr["Operatör Adı"] == DBNull.Value ? "" : dr["Operatör Adı"].ToString();

                    fSAPKY007_2_1_1s.Add(fSAPKY007_2_1_1);
                }

                nesne.fSAPKY007_2_1_1s = fSAPKY007_2_1_1s.ToArray();


                foreach (DataRow dr in dtgfSAPKY007_2_1_2_DataTable.Rows)
                {
                    fSAPKY007_2_1_2 = new FSAPKY007_2_1_2();
                    fSAPKY007_2_1_2.AyranProsessTankNo = dr["Ayran Proses Tank No"] == DBNull.Value ? "" : dr["Ayran Proses Tank No"].ToString();

                    if (fSAPKY007_2_1_2.AyranProsessTankNo == "")
                    {
                        continue;
                    }
                    fSAPKY007_2_1_2.StandartAyranSutuMiktari = dr["Stand. Ayran Sütü Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Stand. Ayran Sütü Miktarı"]);
                    fSAPKY007_2_1_2.KulturlemeSicakligi = (dr["Kültürleme Sıcaklığı"] == DBNull.Value || dr["Kültürleme Sıcaklığı"].ToString() == "") ? 0 : Convert.ToInt32(dr["Kültürleme Sıcaklığı"]);
                    fSAPKY007_2_1_2.KulturlemeSaati = dr["Kültürleme Saati"] == DBNull.Value ? "" : dr["Kültürleme Saati"].ToString();
                    fSAPKY007_2_1_2.KulturlemePH = dr["Kültürleme PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kültürleme PH"]);
                    fSAPKY007_2_1_2.KirimSaati = dr["Kırım Saati"] == DBNull.Value ? "" : dr["Kırım Saati"].ToString();
                    fSAPKY007_2_1_2.KirimPH = dr["Kırım PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kırım PH"]);
                    fSAPKY007_2_1_2.KirimSH = dr["Kırım SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kırım SH"]);
                    fSAPKY007_2_1_2.SogutmaEsanjoruCikisSicakligi = dr["Soğutma Eşanjörü Çıkış Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Soğutma Eşanjörü Çıkış Sıcaklığı"]);
                    fSAPKY007_2_1_2.LabPersonelAdi = dr["Lab.Personel Adı"] == DBNull.Value ? "" : dr["Lab.Personel Adı"].ToString();

                    fSAPKY007_2_1_2s.Add(fSAPKY007_2_1_2);
                }

                nesne.fSAPKY007_2_1_2s = fSAPKY007_2_1_2s.ToArray();

                foreach (DataRow dr in dtgfSAPKY007_2_2_1_DataTable.Rows)
                {
                    fSAPKY007_2_2_1 = new FSAPKY007_2_2_1();
                    fSAPKY007_2_2_1.TankNo = dr["Tank No"] == DBNull.Value ? "" : dr["Tank No"].ToString();

                    if (fSAPKY007_2_2_1.TankNo == "")
                    {
                        continue;
                    }
                    fSAPKY007_2_2_1.PaletNo = dr["Palet No"] == DBNull.Value ? "" : dr["Palet No"].ToString();
                    fSAPKY007_2_2_1.BirinciAnalizSaat = dr["1.Analiz(Saat)"] == DBNull.Value ? "" : dr["1.Analiz(Saat)"].ToString();
                    fSAPKY007_2_2_1.IkinciAnalizSaat = dr["2.Analiz(Saat)"] == DBNull.Value ? "" : dr["2.Analiz(Saat)"].ToString();
                    fSAPKY007_2_2_1.UcuncuAnalizSaat = dr["3.Analiz(Saat)"] == DBNull.Value ? "" : dr["3.Analiz(Saat)"].ToString();
                    fSAPKY007_2_2_1.DorduncuAnalizSaat = dr["4.Analiz(Saat)"] == DBNull.Value ? "" : dr["4.Analiz(Saat)"].ToString();
                    fSAPKY007_2_2_1.BesinciAnalizSaat = dr["5.Analiz(Saat)"] == DBNull.Value ? "" : dr["5.Analiz(Saat)"].ToString();


                    fSAPKY007_2_2_1.BirinciAnalizPH = dr["1.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["1.Analiz(PH)"]);
                    fSAPKY007_2_2_1.IkinciAnalizPH = dr["2.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["2.Analiz(PH)"]);
                    fSAPKY007_2_2_1.UcuncuAnalizPH = dr["3.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["3.Analiz(PH)"]);
                    fSAPKY007_2_2_1.DorduncuAnalizPH = dr["4.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["4.Analiz(PH)"]);
                    fSAPKY007_2_2_1.BesinciAnalizPH = dr["5.Analiz(PH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["5.Analiz(PH)"]);
                    fSAPKY007_2_2_1.BirinciAnalizSH = dr["1.Analiz(SH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["1.Analiz(SH)"]);
                    fSAPKY007_2_2_1.IkinciAnalizSH = dr["2.Analiz(SH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["2.Analiz(SH)"]);
                    fSAPKY007_2_2_1.UcuncuAnalizSH = dr["3.Analiz(SH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["3.Analiz(SH)"]);
                    fSAPKY007_2_2_1.DorduncuAnalizSH = dr["4.Analiz(SH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["4.Analiz(SH)"]);
                    fSAPKY007_2_2_1.BesinciAnalizSH = dr["5.Analiz(SH)"] == DBNull.Value ? 0 : Convert.ToDouble(dr["5.Analiz(SH)"]);
                    fSAPKY007_2_2_1.OperatorAdi = dr["Operatör Adı"] == DBNull.Value ? "" : dr["Operatör Adı"].ToString();

                    fSAPKY007_2_2_1s.Add(fSAPKY007_2_2_1);
                }

                nesne.fSAPKY007_2_2_1s = fSAPKY007_2_2_1s.ToArray();

                foreach (DataRow dr in dtgfSAPKY007_2_2_2_DataTable.Rows)
                {
                    fSAPKY007_2_2_2 = new FSAPKY007_2_2_2();
                    fSAPKY007_2_2_2.TankNo = dr["Tank No"] == DBNull.Value ? "" : dr["Tank No"].ToString();
                    fSAPKY007_2_2_2.Saat = dr["Saat"] == DBNull.Value ? "" : dr["Saat"].ToString();
                    fSAPKY007_2_2_2.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    fSAPKY007_2_2_2.SH = dr["SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SH"]);
                    fSAPKY007_2_2_2.OperatorAdi = dr["Operatör Adı"] == DBNull.Value ? "" : dr["Operatör Adı"].ToString();

                    fSAPKY007_2_2_2s.Add(fSAPKY007_2_2_2);
                }

                nesne.fSAPKY007_2_2_2s = fSAPKY007_2_2_2s.ToArray();

                var resp = client.addOrUpdateFSAPKY007_2(nesne, Giris.dbName, Giris.mKodValue);

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

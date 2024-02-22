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
    public partial class _20_FSAPKY_005_3_2 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_005_3_2(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu, DataTable _dtgfSAPKY005_3_1_1_DataTable, DataTable _dtgfSAPKY005_3_1_2_DataTable, DataTable _dtgfSAPKY005_3_2_1_DataTable, DataTable _dtgfSAPKY005_3_2_2_DataTable, string _kontrol1, string _kontrol2)
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


            dtgfSAPKY005_3_1_1_DataTable = _dtgfSAPKY005_3_1_1_DataTable;
            dtgfSAPKY005_3_1_2_DataTable = _dtgfSAPKY005_3_1_2_DataTable;
            dtgfSAPKY005_3_2_1_DataTable = _dtgfSAPKY005_3_2_1_DataTable;
            dtgfSAPKY005_3_2_2_DataTable = _dtgfSAPKY005_3_2_2_DataTable; 
            kontrol1 = _kontrol1;
            kontrol2 = _kontrol2;
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

            btnSolaGit.Font = new Font(btnSolaGit.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSolaGit.Font.Style);

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
        public static string geriDonme = "";
        DataTable dtgfSAPKY005_3_1_1_DataTable = new DataTable();
        DataTable dtgfSAPKY005_3_1_2_DataTable = new DataTable();
        DataTable dtgfSAPKY005_3_2_1_DataTable = new DataTable();
        DataTable dtgfSAPKY005_3_2_2_DataTable = new DataTable();
        string kontrol1 = "";
        string kontrol2 = ""; 
        private void _20_FSAPKY_005_3_2_Load(object sender, EventArgs e)
        {
            try
            {
                txtPartiNo.Text = partiNo;
                txtUretimFisNo.Text = UretimFisNo;
                txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                txtUrunTanimi.Text = UrunTanimi;

                //txtSeciliAnaliz.Text = txtSeciliAnaliz_IkinciEkran.Text;

                #region dataGridView1 
                datagridView1Load();
                ////dataTable1.Columns.Add("#", "#");
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
                //dataTable1.Columns.Add("1.Analiz(Sıc(C))", typeof(string));
                //dataTable1.Columns.Add("2.Analiz(Sıc(C))", typeof(string));
                //dataTable1.Columns.Add("3.Analiz(Sıc(C))", typeof(string));
                //dataTable1.Columns.Add("4.Analiz(Sıc(C))", typeof(string));
                //dataTable1.Columns.Add("5.Analiz(Sıc(C))", typeof(string));
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
                //dataTable2.Columns.Add("Tank No", typeof(string));
                //dataTable2.Columns.Add("Palet No", typeof(string));
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
        }

        private void btnSolaGit_Click(object sender, EventArgs e)
        {
            geriDonme = "SolaGit";
            Close();
        }

        private void datagridView1Load()
        {
            dataGridView1.DataSource = dtgfSAPKY005_3_2_1_DataTable;
              
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

            dataGridView1.Columns["Tank No"].ReadOnly = true;
            dataGridView1.Columns["Palet No"].ReadOnly = true;
            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {
            dataGridView2.DataSource = dtgfSAPKY005_3_2_2_DataTable;

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
             
            dataGridView2.Columns["Tank No"].ReadOnly = true;
            dataGridView2.Columns["Palet No"].ReadOnly = true;
            dataGridView2.Columns["Operatör Adı"].ReadOnly = true;
        }

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
                if (dataGridView1.Columns[e.ColumnIndex].Name == "1.Analiz(PH)" || dataGridView1.Columns[e.ColumnIndex].Name == "1.Analiz(Sıc(C))")
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
                if (dataGridView1.Columns[e.ColumnIndex].Name == "2.Analiz(PH)" || dataGridView1.Columns[e.ColumnIndex].Name == "2.Analiz(Sıc(C))")
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
                if (dataGridView1.Columns[e.ColumnIndex].Name == "3.Analiz(PH)" || dataGridView1.Columns[e.ColumnIndex].Name == "3.Analiz(Sıc(C))")
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
                if (dataGridView1.Columns[e.ColumnIndex].Name == "4.Analiz(PH)" || dataGridView1.Columns[e.ColumnIndex].Name == "4.Analiz(Sıc(C))")
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
                if (dataGridView1.Columns[e.ColumnIndex].Name == "5.Analiz(PH)" || dataGridView1.Columns[e.ColumnIndex].Name == "5.Analiz(Sıc(C))")
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
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Tank No" || dataGridView2.Columns[e.ColumnIndex].Name == "Palet No" || dataGridView2.Columns[e.ColumnIndex].Name == "PH" || dataGridView2.Columns[e.ColumnIndex].Name == "SH")
            {
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
        private void btnOnayla_Click(object sender, EventArgs e)
        {
            tabloyaKaydetmeIslemleri();
            //Close();
        }

        private void btnAnaliz1_Click(object sender, EventArgs e)
        {
            btnAnaliz2.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = buttondefaultrenk;
            btnAnaliz1.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz1";
            //_20_FSAPKY_005_3_1.seciliAnaliz = "analiz1";
        }
        private void btnAnaliz2_Click(object sender, EventArgs e)
        {
            btnAnaliz1.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = buttondefaultrenk;
            btnAnaliz2.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz2";
            //_20_FSAPKY_005_3_1.seciliAnaliz = "analiz2";
        }
        private void btnAnaliz3_Click(object sender, EventArgs e)
        {
            btnAnaliz1.BackColor = buttondefaultrenk;
            btnAnaliz2.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz3";
            //_20_FSAPKY_005_3_1.seciliAnaliz = "analiz3";
        }
        private void btnAnaliz4_Click(object sender, EventArgs e)
        {
            btnAnaliz1.BackColor = buttondefaultrenk;
            btnAnaliz2.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz4";
            //_20_FSAPKY_005_3_1.seciliAnaliz = "analiz4";
        }
        private void btnAnaliz5_Click(object sender, EventArgs e)
        {
            btnAnaliz1.BackColor = buttondefaultrenk;
            btnAnaliz2.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz5";
            //_20_FSAPKY_005_3_1.seciliAnaliz = "analiz5";
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

                nesne.Kontrol1 = kontrol1;
                nesne.Kontrol2 = kontrol2;
                nesne.Aciklama = "";

                foreach (DataRow dr in dtgfSAPKY005_3_1_1_DataTable.Rows)
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

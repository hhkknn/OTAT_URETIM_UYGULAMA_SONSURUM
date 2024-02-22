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
    public partial class _20_FSAPKY_006_1_2 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_006_1_2(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu, DataTable _dtgfSAPKY006_1_1_1_DataTable, DataTable _dtgfSAPKY006_1_1_2_DataTable, DataTable _dtgfSAPKY006_1_2_1_DataTable, DataTable _dtgfSAPKY006_1_2_2_DataTable, string _kontrol1, string _kontrol2, string _kontrol3)
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

            dtgfSAPKY006_1_1_1_DataTable = _dtgfSAPKY006_1_1_1_DataTable;
            dtgfSAPKY006_1_1_2_DataTable = _dtgfSAPKY006_1_1_2_DataTable;
            dtgfSAPKY006_1_2_1_DataTable = _dtgfSAPKY006_1_2_1_DataTable;
            dtgfSAPKY006_1_2_2_DataTable = _dtgfSAPKY006_1_2_2_DataTable;

            kontrol1 = _kontrol1;
            kontrol2 = _kontrol2;
            kontrol3 = _kontrol3;

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
        private int row = 0;
        private SqlCommand cmd = null;
        private string tarih1 = "";
        private string urunKodu = "";
        Color buttondefaultrenk = Color.Gray;
        public static string geriDonme = "";
        DataTable dtgfSAPKY006_1_1_1_DataTable = new DataTable();
        DataTable dtgfSAPKY006_1_1_2_DataTable = new DataTable();
        DataTable dtgfSAPKY006_1_2_1_DataTable = new DataTable();
        DataTable dtgfSAPKY006_1_2_2_DataTable = new DataTable();
        string kontrol1 = "";
        string kontrol2 = "";
        string kontrol3 = "";

        private void _20_FSAPKY_006_1_2_Load(object sender, EventArgs e)
        {
            try
            {
                txtPartiNo.Text = partiNo;
                txtUretimFisNo.Text = UretimFisNo;
                txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                txtUrunTanimi.Text = UrunTanimi;

                //txtSeciliAnaliz.Text = _20_FSAPKY_006_1_1.seciliAnaliz;

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
                //dataTable1.Columns.Add("1.Analiz(Sıcaklık(C))", typeof(string));
                //dataTable1.Columns.Add("2.Analiz(Sıcaklık(C))", typeof(string));
                //dataTable1.Columns.Add("3.Analiz(Sıcaklık(C))", typeof(string));
                //dataTable1.Columns.Add("4.Analiz(Sıcaklık(C))", typeof(string));
                //dataTable1.Columns.Add("5.Analiz(Sıcaklık(C))", typeof(string));
                //dataTable1.Columns.Add("Soğuk Oda G.Saat", typeof(string));
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
                ////dataTable2.Columns.Add("#", "#");
                //dataTable2.Columns.Add("Tank No", typeof(string));
                //dataTable2.Columns.Add("İnkübasyon Oda No", typeof(string));
                //dataTable2.Columns.Add("Saat", typeof(string));
                //dataTable2.Columns.Add("PH", typeof(string));
                //dataTable2.Columns.Add("Sıcaklık", typeof(string));
                //dataTable2.Columns.Add("Soğuk Oda G.Saat", typeof(string));
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

                //_20_FSAPKY_006_1_1.dtgfSAPKY006_1_2_1Static = dataGridView1;
                //_20_FSAPKY_006_1_1.dtgfSAPKY006_1_2_2Static = dataGridView2;

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
            //BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            //banaAitİsler.Show();
            geriDonme = "OzeteDon";
            Close();
            //_20_ANALIZ_EKRANLARI _20_ANALIZ_EKRANLARI = new _20_ANALIZ_EKRANLARI();
            //_20_ANALIZ_EKRANLARI.Show();
            //Close();
        }

        private void btnSolaGit_Click(object sender, EventArgs e)
        {
            //_20_FSAPKY_006_1_1.dtgfSAPKY006_1_2_1Static_DataTable = dataTable1;
            //_20_FSAPKY_006_1_1.dtgfSAPKY006_1_2_2Static_DataTable = dataTable2;
            geriDonme = "SolaGit";
            Close();
        }


        private void datagridView1Load()
        {
            dataGridView1.DataSource = dtgfSAPKY006_1_2_1_DataTable;

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
            dataGridView2.DataSource = dtgfSAPKY006_1_2_2_DataTable;

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


            //if (dataTable2.Rows.Count == 0)
            //{
            //    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

            //    DataRow dr = dataTable2.NewRow();
            //    dr["Tank No"] = "";
            //    dr["İnkübasyon Oda No"] = "";
            //    dr["Saat"] = "";
            //    dr["PH"] = Convert.ToString("0", cultureTR);
            //    dr["Sıcaklık(C)"] = Convert.ToString("0", cultureTR);
            //    dr["Soğuk Oda G.Saat"] = "";
            //    dr["Operatör Adı"] = "";

            //    dataTable2.Rows.Add(dr);
            //}
            dataGridView2.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Tank No" || dataGridView1.Columns[e.ColumnIndex].Name == "Palet No")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();

                //string val = "";

                //if (dataTable1.Rows.Count == 0)
                //{
                //    val = dataGridView1.Rows[0].Cells[e.ColumnIndex].Value.ToString();
                //}
                //else
                //{
                //    val = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[e.ColumnIndex].Value.ToString();

                //}

                //if (val != "")
                //{
                //    DataRow dr = dataTable1.NewRow();
                //    dr["Tank No"] = "";

                //    dataTable1.Rows.Add(dr);

                //}
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Soğuk Oda G.Saat")
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
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Tank No" || dataGridView2.Columns[e.ColumnIndex].Name == "İnkübasyon Oda No" || dataGridView2.Columns[e.ColumnIndex].Name == "PH" || dataGridView2.Columns[e.ColumnIndex].Name == "Sıcaklık(C)")
            {
                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog();
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Saat" || dataGridView2.Columns[e.ColumnIndex].Name == "Soğuk Oda G.Saat")
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
            //_20_FSAPKY_006_1_1.dtgfSAPKY006_1_2_1Static = dataGridView1;
            //_20_FSAPKY_006_1_1.dtgfSAPKY006_1_2_2Static = dataGridView2;
            //_20_FSAPKY_006_1_1.dtgfSAPKY006_1_2_1Static_DataTable = dataTable1;
            //_20_FSAPKY_006_1_1.dtgfSAPKY006_1_2_2Static_DataTable = dataTable2;
            //_20_FSAPKY_006_1_1.seciliAnaliz = txtSeciliAnaliz.Text;
            //_20_FSAPKY_006_1_1.TabloyaKaydet();

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
        }

        private void btnAnaliz2_Click(object sender, EventArgs e)
        {
            btnAnaliz1.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = buttondefaultrenk;
            btnAnaliz2.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz2"; 
        }

        private void btnAnaliz3_Click(object sender, EventArgs e)
        {
            btnAnaliz1.BackColor = buttondefaultrenk;
            btnAnaliz2.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz3"; 

        }

        private void btnAnaliz4_Click(object sender, EventArgs e)
        {
            btnAnaliz1.BackColor = buttondefaultrenk;
            btnAnaliz2.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz4"; 

        }

        private void btnAnaliz5_Click(object sender, EventArgs e)
        {
            btnAnaliz1.BackColor = buttondefaultrenk;
            btnAnaliz2.BackColor = buttondefaultrenk;
            btnAnaliz3.BackColor = buttondefaultrenk;
            btnAnaliz4.BackColor = buttondefaultrenk;
            btnAnaliz5.BackColor = Color.GreenYellow;
            txtSeciliAnaliz.Text = "analiz5"; 
        }


        private void tabloyaKaydetmeIslemleri()
        {
            try
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
                //besne.Tarih = tarih1;
                DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                nesne.Tarih = uretimtarihi.ToString("yyyyMMdd");
                #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

                nesne.Kontrol1 = kontrol1;
                nesne.Kontrol2 = kontrol2;
                nesne.Kontrol3 = kontrol3;
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

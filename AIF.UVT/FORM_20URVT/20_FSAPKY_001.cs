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
    public partial class _20_FSAPKY_001 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_001(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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
        private void _20_FSAPKY001_Load(object sender, EventArgs e)
        {
            try
            {

                txtPartiNo.Text = partiNo;
                txtUretimFisNo.Text = UretimFisNo;
                txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                txtUrunTanimi.Text = UrunTanimi;
                //dateUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                #region dataGridView1 

                datagridView1Load();
                //dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Başlangıç
                //i", typeof(string));
                //dataTable1.Columns.Add("Pastorizasyon Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Pastorizasyon Çıkış", typeof(string));
                //dataTable1.Columns.Add("Holder Süresi", typeof(string));
                //dataTable1.Columns.Add("Homojenizasyon Basınç", typeof(string));
                //dataTable1.Columns.Add("Çiğ Süt Müktarı", typeof(string));
                //dataTable1.Columns.Add("Çekilen Krema", typeof(string));
                //dataTable1.Columns.Add("Eklenen Krema", typeof(string));
                //dataTable1.Columns.Add("Stand. Süt Miktarı", typeof(string)); 
                //dataTable1.Columns.Add("Bitiş Saati", typeof(string));
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
                //dataTable2.Columns.Add("Çiğ Süt Alındığı Depolama Tankı", typeof(string));
                //dataTable2.Columns.Add("Alınan Çiğ Süt Miktarı", typeof(string));
                //dataTable2.Columns.Add("Çiğ Süt PH", typeof(string));
                //dataTable2.Columns.Add("Çiğ Süt SH", typeof(string));
                //dataTable2.Columns.Add("Çiğ Süt KM", typeof(string));
                //dataTable2.Columns.Add("Çiğ Süt Yağı", typeof(string));
                //dataTable2.Columns.Add("Operatör Adı", typeof(string));

                //dataTable2.Rows.Add("");
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
            string sql = "SELECT T1.\"U_BasSaati\" as \"Başlangıç Saati\",T1.\"U_PasSicaklik\" as \"Pastorizasyon Sıcaklığı\",\"U_PasCikis\" as \"Pastorizasyon Çıkış\",T1.\"U_HolderSuresi\" as \"Holder Süresi\",\"U_HmjBasinc\" as \"Homojenizasyon Basınç\",T1.\"U_CigSutMik\" as \"Çiğ Süt Müktarı\",\"U_CekilenKrema\" as \"Çekilen Krema\",\"U_EklnKrema\" as \"Eklenen Krema\",\"U_StandSutMik\" as \"Stand. Süt Miktarı\" ,\"U_BitSaat\" as \"Bitiş Saati\" ,\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY001\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY001_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Başlangıç Saati"] = "";
                dr["Pastorizasyon Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Pastorizasyon Çıkış"] = Convert.ToString("0", cultureTR);
                dr["Holder Süresi"] = Convert.ToString("0", cultureTR);
                dr["Homojenizasyon Basınç"] = Convert.ToString("0", cultureTR);
                dr["Çiğ Süt Müktarı"] = Convert.ToString("0", cultureTR);
                dr["Çekilen Krema"] = Convert.ToString("0", cultureTR);
                dr["Eklenen Krema"] = Convert.ToString("0", cultureTR);
                dr["Stand. Süt Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Bitiş Saati"] = "";
                dr["Operatör Adı"] = "";

                dataTable1.Rows.Add(dr);
            }


            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {

            string sql = "SELECT T1.\"U_CigSutDepTnk\" as \"Çiğ Süt Alındığı Depolama Tankı\",T1.\"U_CigSutMik\" as \"Alınan Çiğ Süt Miktarı\",\"U_CigSutPH\" as \"Çiğ Süt PH\",T1.\"U_CigSutSH\" as \"Çiğ Süt SH\",\"U_CigSutKM\" as \"Çiğ Süt KM\",\"U_CigSutYag\" as \"Çiğ Süt Yağı\",\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY001\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY001_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";


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


            //if (dataTable2.Rows.Count == 0)
            //{
            System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

            DataRow dr = dataTable2.NewRow();
            dr["Çiğ Süt Alındığı Depolama Tankı"] = "";
            dr["Alınan Çiğ Süt Miktarı"] = Convert.ToString("0", cultureTR);
            dr["Çiğ Süt PH"] = Convert.ToString("0", cultureTR);
            dr["Çiğ Süt SH"] = Convert.ToString("0", cultureTR);
            dr["Çiğ Süt KM"] = Convert.ToString("0", cultureTR);
            dr["Çiğ Süt Yağı"] = Convert.ToString("0", cultureTR);
            dr["Operatör Adı"] = "";

            dataTable2.Rows.Add(dr);
            //}

            dataGridView2.Columns["Operatör Adı"].ReadOnly = true;

            //dataGridView2.Columns["Ürün Kodu"].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Pastorizasyon Sıcaklığı" || dataGridView1.Columns[e.ColumnIndex].Name == "Pastorizasyon Çıkış" || dataGridView1.Columns[e.ColumnIndex].Name == "Holder Süresi" || dataGridView1.Columns[e.ColumnIndex].Name == "Homojenizasyon Basınç" || dataGridView1.Columns[e.ColumnIndex].Name == "Çiğ Süt Müktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Çekilen Krema" || dataGridView1.Columns[e.ColumnIndex].Name == "Eklenen Krema" || dataGridView1.Columns[e.ColumnIndex].Name == "Stand. Süt Miktarı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Başlangıç Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Bitiş Saati")
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

                    sql = " " + personelBoslukSatiri + " SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                    sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and \"U_Durum\" = 'X'";

                    if (AtanmisIsler.Joker)
                    {
                        //sql += " UNION ALL ";

                        sql = " " + personelBoslukSatiri + " SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                        sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') and \"U_Durum\" = 'X'";
                    }

                    #endregion Günlük Personel Planlama 3 ekranı

                    SelectList selectList = new SelectList(sql, dataGridView1, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();
                }
            }
        }

        string personelBoslukSatiri = "SELECT TOP 1 '' AS \"Personel No\", '' AS \"Personel Adı\" FROM OCRD WITH (NOLOCK) UNION ALL ";
        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Çiğ Süt Alındığı Depolama Tankı" || dataGridView2.Columns[e.ColumnIndex].Name == "Alınan Çiğ Süt Miktarı" || dataGridView2.Columns[e.ColumnIndex].Name == "Çiğ Süt PH" || dataGridView2.Columns[e.ColumnIndex].Name == "Çiğ Süt SH" || dataGridView2.Columns[e.ColumnIndex].Name == "Çiğ Süt KM" || dataGridView2.Columns[e.ColumnIndex].Name == "Çiğ Süt Yağı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog();

            }

            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Operatör Adı")
            {
                if (istasyon.StartsWith("20-"))
                {
                    DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                    string gunfield = "U_Gun" + dtTarih.Day;
                    string sql = "";

                    #region Günlük Personel Planlama 2 ekranı

                    //sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

                    //if (AtanmisIsler.Joker)
                    //{
                    //    sql += " UNION ALL ";

                    //    sql += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                    //}

                    #endregion Günlük Personel Planlama 2 ekranı

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
            FSAPKY001 fSAPKY001 = new FSAPKY001();
            List<FSAPKY001_1> fSAPKY001_1s = new List<FSAPKY001_1>();
            FSAPKY001_1 fSAPKY001_1 = new FSAPKY001_1();
            List<FSAPKY001_2> fSAPKY001_2s = new List<FSAPKY001_2>();
            FSAPKY001_2 fSAPKY001_2 = new FSAPKY001_2();


            fSAPKY001.PartiNo = txtPartiNo.Text;
            fSAPKY001.UrunTanimi = txtUrunTanimi.Text;

            #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
            //fSAPKY001.Tarih = tarih1;
            DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            fSAPKY001.Tarih = uretimtarihi.ToString("yyyyMMdd");
            #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

            fSAPKY001.Aciklama = "";
            fSAPKY001.UrunKodu = urunKodu;


            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                fSAPKY001_1 = new FSAPKY001_1();
                fSAPKY001_1.BaslangicSaati = dr.Cells["Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Başlangıç Saati"].Value.ToString();
                fSAPKY001_1.PastorizasyonSicaklik = dr.Cells["Pastorizasyon Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastorizasyon Sıcaklığı"].Value);
                fSAPKY001_1.PastorizasyonCikis = dr.Cells["Pastorizasyon Çıkış"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastorizasyon Çıkış"].Value);
                fSAPKY001_1.HolderSuresi = dr.Cells["Holder Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Holder Süresi"].Value);
                fSAPKY001_1.HomojenizasyonBasinc = dr.Cells["Homojenizasyon Basınç"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Homojenizasyon Basınç"].Value);
                fSAPKY001_1.CigSutMiktari = dr.Cells["Çiğ Süt Müktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Süt Müktarı"].Value);
                fSAPKY001_1.CekilenKrema = dr.Cells["Çekilen Krema"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çekilen Krema"].Value);
                fSAPKY001_1.EklenenKrema = dr.Cells["Eklenen Krema"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Eklenen Krema"].Value);
                fSAPKY001_1.StandartSutMiktari = dr.Cells["Stand. Süt Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Stand. Süt Miktarı"].Value);
                fSAPKY001_1.BitisSaati = dr.Cells["Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Bitiş Saati"].Value.ToString();
                fSAPKY001_1.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

                fSAPKY001_1s.Add(fSAPKY001_1);
            }

            fSAPKY001.fSAPKY001_1s = fSAPKY001_1s.ToArray();

            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                fSAPKY001_2 = new FSAPKY001_2();

                if (dr.Cells["Çiğ Süt Alındığı Depolama Tankı"].Value.ToString() == "")
                {
                    continue;
                }
                fSAPKY001_2.CigSutDepoTanki = dr.Cells["Çiğ Süt Alındığı Depolama Tankı"].Value == DBNull.Value ? "" : dr.Cells["Çiğ Süt Alındığı Depolama Tankı"].Value.ToString();
                fSAPKY001_2.CigSutMiktari = dr.Cells["Alınan Çiğ Süt Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Alınan Çiğ Süt Miktarı"].Value);
                fSAPKY001_2.CigSutPH = dr.Cells["Çiğ Süt PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Süt PH"].Value);
                fSAPKY001_2.CigSutSH = dr.Cells["Çiğ Süt SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Süt SH"].Value);
                fSAPKY001_2.CigSutKM = dr.Cells["Çiğ Süt KM"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Süt KM"].Value);
                fSAPKY001_2.CigSutYag = dr.Cells["Çiğ Süt Yağı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Süt Yağı"].Value);
                fSAPKY001_2.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();


                fSAPKY001_2s.Add(fSAPKY001_2);
            }

            fSAPKY001.fSAPKY001_2s = fSAPKY001_2s.ToArray();


            var resp = client.addOrUpdateFSAPKY001(fSAPKY001, Giris.dbName, Giris.mKodValue);

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

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dataGridView1.Columns[e.ColumnIndex].Name == "Çiğ Süt Müktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Çekilen Krema" || dataGridView1.Columns[e.ColumnIndex].Name == "Eklenen Krema")
                {
                    double cigSutMik = 0;
                    double cekilenKrema = 0;
                    double eklenenKrema = 0;
                    double standSutMik = 0;

                    cigSutMik = dataGridView1.Rows[e.RowIndex].Cells["Çiğ Süt Müktarı"].Value == null ? 0 : Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Çiğ Süt Müktarı"].Value);
                    cekilenKrema = dataGridView1.Rows[e.RowIndex].Cells["Çekilen Krema"].Value == null ? 0 : Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Çekilen Krema"].Value);
                    eklenenKrema = dataGridView1.Rows[e.RowIndex].Cells["Eklenen Krema"].Value == null ? 0 : Convert.ToDouble(dataGridView1.Rows[e.RowIndex].Cells["Eklenen Krema"].Value);

                    standSutMik = cigSutMik - cekilenKrema + eklenenKrema;

                    if (standSutMik > 0)
                    {
                        dataGridView1.Rows[e.RowIndex].Cells["Stand. Süt Miktarı"].Value = standSutMik;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
    }
}

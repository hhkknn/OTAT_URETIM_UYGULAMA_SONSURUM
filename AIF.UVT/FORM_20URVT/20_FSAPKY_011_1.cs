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
    public partial class _20_FSAPKY_011_1 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_011_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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
        private void _20_FSAPKY_011_1_Load(object sender, EventArgs e)
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
                //dataTable1.Columns.Add("Kullanılan Krema", typeof(string));
                //dataTable1.Columns.Add("Kullanılan Süt Miktarı", typeof(string));
                //dataTable1.Columns.Add("Kremanın Son Yağı", typeof(string));
                //dataTable1.Columns.Add("Pastörizasyona Başlama Saati", typeof(string));
                //dataTable1.Columns.Add("Pastörizasyon Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Pastörizasyon Bitiş Saati", typeof(string));
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
                //dataTable2.Columns.Add("Krema PH", typeof(string));
                //dataTable2.Columns.Add("Krema Yağ Oranı", typeof(string));
                //dataTable2.Columns.Add("Krema Son Yağ Oranı", typeof(string)); 
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
            string sql = "SELECT T1.\"U_KullKrema\" as \"Kullanılan Krema\",T1.\"U_KullSutMik\" as \"Kullanılan Süt Miktarı\",\"U_KreSonYag\" as \"Kremanın Son Yağı\",T1.\"U_PastBasSa\" as \"Pastörizasyona Başlama Saati\",\"U_PastSicak\" as \"Pastörizasyon Sıcaklığı\",\"U_PastBitSa\" as \"Pastörizasyon Bitiş Saati\",T1.\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY011_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY011_1_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Kullanılan Krema"] = Convert.ToString("0", cultureTR);
                dr["Kullanılan Süt Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Kremanın Son Yağı"] = Convert.ToString("0", cultureTR);
                dr["Pastörizasyona Başlama Saati"] = "";
                dr["Pastörizasyon Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Pastörizasyon Bitiş Saati"] = "";
                dr["Operatör Adı"] = "";
                dataTable1.Rows.Add(dr);
            }
            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }


        private void datagridView2Load()
        {
            string sql = "SELECT T1.\"U_KremaPH\" as \"Krema PH\",T1.\"U_YagOrani\" as \"Krema Yağ Oranı\",\"U_SonYagOr\" as \"Krema Son Yağ Oranı\",T1.\"U_LabPersAdi\" as \"Laboratuvar Personel Adı\" FROM \"@AIF_FSAPKY011_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY011_1_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Krema PH"] = Convert.ToString("0", cultureTR);
                dr["Krema Yağ Oranı"] = Convert.ToString("0", cultureTR);
                dr["Krema Son Yağ Oranı"] = Convert.ToString("0", cultureTR);
                dr["Laboratuvar Personel Adı"] = "";
                dataTable2.Rows.Add(dr);
            }
            dataGridView2.Columns["Laboratuvar Personel Adı"].ReadOnly = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            currentCell = e.RowIndex;
            grid1Secildi = true;
            grid2Secildi = false; 
            #endregion

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Kullanılan Krema" || dataGridView1.Columns[e.ColumnIndex].Name == "Kullanılan Süt Miktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Kremanın Son Yağı" || dataGridView1.Columns[e.ColumnIndex].Name == "Pastörizasyon Sıcaklığı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Pastörizasyona Başlama Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Pastörizasyon Bitiş Saati")
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
            #region satır ekle sil işlemi için kulanılır
            currentCell = e.RowIndex;
            grid1Secildi = false;
            grid2Secildi = true; 
            #endregion
            if (dataGridView2.Columns[e.ColumnIndex].Name == "Krema PH" || dataGridView2.Columns[e.ColumnIndex].Name == "Krema Yağ Oranı" || dataGridView2.Columns[e.ColumnIndex].Name == "Krema Son Yağ Oranı")
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

                    sql = "SELECT TOP 1 '' AS \"Personel No\", '' AS \"Personel Adı\" FROM OCRD UNION ALL SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
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
            FSAPKY011_1 fSAPKY011_1 = new FSAPKY011_1();
            List<FSAPKY011_1_1> fSAPKY011_1_1s = new List<FSAPKY011_1_1>();
            FSAPKY011_1_1 fSAPKY011_1_1 = new FSAPKY011_1_1();
            List<FSAPKY011_1_2> fSAPKY011_1_2s = new List<FSAPKY011_1_2>();
            FSAPKY011_1_2 fSAPKY011_1_2 = new FSAPKY011_1_2();



            fSAPKY011_1.PartiNo = txtPartiNo.Text;
            fSAPKY011_1.UrunTanimi = txtUrunTanimi.Text;

            #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
            //fSAPKY011_1.Tarih = tarih1;
            DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            fSAPKY011_1.Tarih = uretimtarihi.ToString("yyyyMMdd");
            #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

            fSAPKY011_1.Aciklama = "";
            fSAPKY011_1.UrunKodu = urunKodu;


            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                fSAPKY011_1_1 = new FSAPKY011_1_1();
                fSAPKY011_1_1.KullanilanKrema = dr.Cells["Kullanılan Krema"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kullanılan Krema"].Value);
                fSAPKY011_1_1.KullanilanSutMiktari = dr.Cells["Kullanılan Süt Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kullanılan Süt Miktarı"].Value);
                fSAPKY011_1_1.KremaSonYagi = dr.Cells["Kremanın Son Yağı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kremanın Son Yağı"].Value);
                fSAPKY011_1_1.PastorizasyonBaslangicSaati = dr.Cells["Pastörizasyona Başlama Saati"].Value == DBNull.Value ? "" : dr.Cells["Pastörizasyona Başlama Saati"].Value.ToString();
                fSAPKY011_1_1.PastrizasyonSicakligi = dr.Cells["Pastörizasyon Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastörizasyon Sıcaklığı"].Value);
                fSAPKY011_1_1.PastorizasyonBitisSaati = dr.Cells["Pastörizasyon Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Pastörizasyon Bitiş Saati"].Value.ToString();
                fSAPKY011_1_1.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

                fSAPKY011_1_1s.Add(fSAPKY011_1_1);
            }

            fSAPKY011_1.fSAPKY011_1_1s = fSAPKY011_1_1s.ToArray();

            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                fSAPKY011_1_2 = new FSAPKY011_1_2();
                fSAPKY011_1_2.KremaPH = dr.Cells["Krema PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Krema PH"].Value);
                fSAPKY011_1_2.KremaYagOrani = dr.Cells["Krema Yağ Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Krema Yağ Oranı"].Value);
                fSAPKY011_1_2.KremaSonYagOrani = dr.Cells["Krema Son Yağ Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Krema Son Yağ Oranı"].Value);
                fSAPKY011_1_2.LabPersonelAdi = dr.Cells["Laboratuvar Personel Adı"].Value == DBNull.Value ? "" : dr.Cells["Laboratuvar Personel Adı"].Value.ToString();

                fSAPKY011_1_2s.Add(fSAPKY011_1_2);
            }

            fSAPKY011_1.fSAPKY011_1_2s = fSAPKY011_1_2s.ToArray();

            var resp = client.addOrUpdateFSAPKY011_1(fSAPKY011_1, Giris.dbName, Giris.mKodValue);
             
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
        bool grid2Secildi = false; 
        int currentCell = -1;
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            grid1Secildi = true;
            grid2Secildi = false;
            #endregion
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            grid1Secildi = false;
            grid2Secildi = true;
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
            currentCell = -1;
        }

        private void btnSatirEkle_Click(object sender, EventArgs e)
        {
            if (grid1Secildi)
            {
                try
                {
                    if (dataGridView1.Rows.Count >= 3)
                    {
                        return;
                    }
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dataTable1.NewRow();
                    dr["Kullanılan Krema"] = Convert.ToString("0", cultureTR);
                    dr["Kullanılan Süt Miktarı"] = Convert.ToString("0", cultureTR);
                    dr["Kremanın Son Yağı"] = Convert.ToString("0", cultureTR);
                    dr["Pastörizasyona Başlama Saati"] = "";
                    dr["Pastörizasyon Sıcaklığı"] = Convert.ToString("0", cultureTR);
                    dr["Pastörizasyon Bitiş Saati"] = "";
                    dr["Operatör Adı"] = "";
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
                    if (dataGridView2.Rows.Count >= 3)
                    {
                        return;
                    }
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dataTable2.NewRow();
                    dr["Krema PH"] = Convert.ToString("0", cultureTR);
                    dr["Krema Yağ Oranı"] = Convert.ToString("0", cultureTR);
                    dr["Krema Son Yağ Oranı"] = Convert.ToString("0", cultureTR);
                    dr["Laboratuvar Personel Adı"] = "";
                    dataTable2.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}
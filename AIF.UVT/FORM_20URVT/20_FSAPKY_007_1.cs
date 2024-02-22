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
    //cmmt
    public partial class _20_FSAPKY_007_1 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_007_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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

            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4); ;
            txtPartiNo.Text = partiNo;
            txtUrunTanimi.Text = UrunTanimi;
            txtUretimFisNo.Text = UretimFisNo;
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
        //private SqlCommand cmd = null;
        private string tarih1 = "";
        private void _20_FSAPKY_007_1_Load(object sender, EventArgs e)
        {
            try
            {
                #region dataGridView1 

                datagridView1Load();
                ////dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Tank No", typeof(string));
                //dataTable1.Columns.Add("Kullanılan Çiğ Süt", typeof(double));
                //dataTable1.Columns.Add("Kullanılan Çiğ Sütün Çekildiği Saat", typeof(string));
                //dataTable1.Columns.Add("Kullanılan Su", typeof(double));
                //dataTable1.Columns.Add("Suyun Eklenme Saati", typeof(string));
                //dataTable1.Columns.Add("Toplam Ayran Sütü", typeof(double));
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
                //dataTable2.Columns.Add("Çiğ Süt PH", typeof(string));
                //dataTable2.Columns.Add("Çiğ Süt SH", typeof(string));
                //dataTable2.Columns.Add("Çiğ Süt KM", typeof(string));
                //dataTable2.Columns.Add("Çiğ Süt Yağı", typeof(string));
                //dataTable2.Columns.Add("Ayran Sütü PH", typeof(string));
                //dataTable2.Columns.Add("Ayran Sütü SH", typeof(string));
                //dataTable2.Columns.Add("Ayran Sütü KM", typeof(string));
                //dataTable2.Columns.Add("Ayran Sütü Yağı", typeof(string));
                //dataTable2.Columns.Add("Teknik Personel Adı", typeof(string));

                //dataTable2.Rows.Add("");
                //dataGridView2.DataSource = dataTable2;

                //dataGridView2.AllowUserToAddRows = false;
                //dataGridView2.AllowUserToDeleteRows = false;
                //dataGridView2.AllowUserToResizeColumns = false;
                //dataGridView2.AllowUserToResizeRows = false;
                //dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(146, 208, 80);
                //dataGridView2.DefaultCellStyle.BackColor = Color.WhiteSmoke;

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Tank No")
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
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Kullanılan Çiğ Süt" || dataGridView1.Columns[e.ColumnIndex].Name == "Kullanılan Su" || dataGridView1.Columns[e.ColumnIndex].Name == "Toplam Ayran Sütü")
            {
                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Suyun Eklenme Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Kullanılan Çiğ Sütün Çekildiği Saat")
            {
                //    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, true);
                //    //n.ShowDialog();

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
            if (dataGridView2.Columns[e.ColumnIndex].Name != "Teknik Personel Adı")
            {

                //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog();
            }
            else
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

                        sql = "SELECT TOP 1 '' AS \"Personel No\", '' AS \"Personel Adı\" FROM OCRD UNION ALL SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
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
            List<FSAPKY007_1> fSAPKY007_1s = new List<FSAPKY007_1>();
            FSAPKY007_1 fSAPKY007_1 = new FSAPKY007_1();
            List<FSAPKY007_1_1> fSAPKY007_1_1s = new List<FSAPKY007_1_1>();
            FSAPKY007_1_1 fSAPKY007_1_1 = new FSAPKY007_1_1();
            List<FSAPKY007_1_2> fSAPKY007_1_2s = new List<FSAPKY007_1_2>();
            FSAPKY007_1_2 fSAPKY007_1_2 = new FSAPKY007_1_2();


            fSAPKY007_1.PartiNo = txtPartiNo.Text;
            fSAPKY007_1.UrunTanimi = txtUrunTanimi.Text;

            #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
            //fSAPKY007_1.Tarih = tarih1;
            DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            fSAPKY007_1.Tarih = uretimtarihi.ToString("yyyyMMdd");
            #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

            fSAPKY007_1.Aciklama = "";
            fSAPKY007_1.UrunKodu = urunKodu;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                if (dr.Cells["Tank No"].Value == null || dr.Cells["Tank No"].Value.ToString() == "")
                {
                    continue;
                }
                fSAPKY007_1_1 = new FSAPKY007_1_1();
                fSAPKY007_1_1.TankNo = dr.Cells["Tank No"].Value == DBNull.Value ? "" : dr.Cells["Tank No"].Value.ToString();
                fSAPKY007_1_1.KullCigSut = dr.Cells["Kullanılan Çiğ Süt"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kullanılan Çiğ Süt"].Value);
                fSAPKY007_1_1.CigSutCekSa = dr.Cells["Kullanılan Çiğ Sütün Çekildiği Saat"].Value == DBNull.Value ? "" : dr.Cells["Kullanılan Çiğ Sütün Çekildiği Saat"].Value.ToString();
                fSAPKY007_1_1.KullSu = dr.Cells["Kullanılan Su"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kullanılan Su"].Value);
                fSAPKY007_1_1.SuEkSaat = dr.Cells["Suyun Eklenme Saati"].Value == DBNull.Value ? "" : dr.Cells["Suyun Eklenme Saati"].Value.ToString();
                fSAPKY007_1_1.TopAyrSut = dr.Cells["Toplam Ayran Sütü"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Ayran Sütü"].Value);
                fSAPKY007_1_1.OprtAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

                fSAPKY007_1_1s.Add(fSAPKY007_1_1);
            }

            fSAPKY007_1.fSAPKY007_1_1s = fSAPKY007_1_1s.ToArray();

            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                fSAPKY007_1_2 = new FSAPKY007_1_2();
                fSAPKY007_1_2.CigSutPH = dr.Cells["Çiğ Süt PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Süt PH"].Value);
                fSAPKY007_1_2.CigSutSH = dr.Cells["Çiğ Süt SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Süt SH"].Value);
                fSAPKY007_1_2.CigSutKM = dr.Cells["Çiğ Süt KM"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Süt KM"].Value);
                fSAPKY007_1_2.CigSutYag = dr.Cells["Çiğ Süt Yağı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Süt Yağı"].Value);
                fSAPKY007_1_2.AyrSutPH = dr.Cells["Ayran Sütü PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Ayran Sütü PH"].Value);
                fSAPKY007_1_2.AyrSutSH = dr.Cells["Ayran Sütü SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Ayran Sütü SH"].Value);
                fSAPKY007_1_2.AyrSutKM = dr.Cells["Ayran Sütü KM"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Ayran Sütü KM"].Value);
                fSAPKY007_1_2.AyrSutYag = dr.Cells["Ayran Sütü Yağı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Ayran Sütü Yağı"].Value);
                fSAPKY007_1_2.TekPersAdi = dr.Cells["Teknik Personel Adı"].Value == DBNull.Value ? "" : (dr.Cells["Teknik Personel Adı"].Value.ToString());


                fSAPKY007_1_2s.Add(fSAPKY007_1_2);
            }

            fSAPKY007_1.fSAPKY007_1_2s = fSAPKY007_1_2s.ToArray();


            var resp = client.addOrUpdateFSAPKY007_1(fSAPKY007_1, Giris.dbName, Giris.mKodValue);
             
            CustomMsgBtn.Show(resp.Description,"UYARI","TAMAM");


            if (resp.Value == 0)
            {
                btnOzetEkranaDon.PerformClick();
            }
        }

        private void datagridView1Load()
        {
            string sql = "SELECT T1.\"U_TankNo\" as \"Tank No\",\"U_KullCigSut\" as \"Kullanılan Çiğ Süt\",T1.\"U_CigSutCekSa\" as \"Kullanılan Çiğ Sütün Çekildiği Saat\",\"U_KullSu\" as \"Kullanılan Su\",\"U_SuEkSaat\" as \"Suyun Eklenme Saati\",\"U_TopAyrSut\" as \"Toplam Ayran Sütü\", \"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY007_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY007_1_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Tank No"] = "";
                dr["Kullanılan Çiğ Süt"] = Convert.ToString("0", cultureTR);
                dr["Kullanılan Çiğ Sütün Çekildiği Saat"] = "";
                dr["Kullanılan Su"] = Convert.ToString("0", cultureTR);
                dr["Suyun Eklenme Saati"] = "";
                dr["Toplam Ayran Sütü"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";

                dataTable1.Rows.Add(dr);
            }
            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;

        }

        private void datagridView2Load()
        {

            string sql = "SELECT T1.\"U_CigSutPH\" as \"Çiğ Süt PH\",\"U_CigSutSH\" as \"Çiğ Süt SH\",T1.\"U_CigSutKM\" as \"Çiğ Süt KM\",\"U_CigSutYag\" as \"Çiğ Süt Yağı\",\"U_AyrSutPH\" as \"Ayran Sütü PH\",\"U_AyrSutSH\" as \"Ayran Sütü SH\", \"U_AyrSutKM\" as \"Ayran Sütü KM\", \"U_AyrSutYag\" as \"Ayran Sütü Yağı\", \"U_TekPersAdi\" as \"Teknik Personel Adı\" FROM \"@AIF_FSAPKY007_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY007_1_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Çiğ Süt PH"] = Convert.ToString("0", cultureTR);
                dr["Çiğ Süt SH"] = Convert.ToString("0", cultureTR);
                dr["Çiğ Süt KM"] = Convert.ToString("0", cultureTR);
                dr["Çiğ Süt Yağı"] = Convert.ToString("0", cultureTR);
                dr["Ayran Sütü PH"] = Convert.ToString("0", cultureTR);
                dr["Ayran Sütü SH"] = Convert.ToString("0", cultureTR);
                dr["Ayran Sütü KM"] = Convert.ToString("0", cultureTR);
                dr["Ayran Sütü Yağı"] = Convert.ToString("0", cultureTR);
                dr["Teknik Personel Adı"] = "";

                dataTable2.Rows.Add(dr);
            }
            dataGridView2.Columns["Teknik Personel Adı"].ReadOnly = true;
        }

        private void txtUretimTarihi_Click(object sender, EventArgs e)
        {
            TarihGirisi tarihGirisi = new TarihGirisi(null, txtUretimTarihi);
            tarihGirisi.ShowDialog();
        }
    }
}

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
    public partial class _20_FSAPKY_005_2 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_005_2(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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
        Color buttondefaultrenk = Color.Gray;

        private void _20_FSAPKY_005_2_Load(object sender, EventArgs e)
        {
            grid1Secildi = true;

            richTextBox1.Text = "Kültürün kontrolü yapılmıştır. Bir fiziksel deformasyon ve bulaşma söz konusu değildir. Saklama koşulları sağlanmıştır.Hayır ise Uygun olmayan ürün prosedürünü uygulayınız.";

            try
            {
                txtPartiNo.Text = partiNo;
                txtUretimFisNo.Text = UretimFisNo;
                txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
                txtUrunTanimi.Text = UrunTanimi;

                buttondefaultrenk = btnEvet.BackColor;

                #region Kontrol yapıldı mı sorgusu

                DataTable dtDgrKltKontrol = new DataTable();

                string sql = "SELECT \"U_Kontrol1\"  FROM \"@AIF_FSAPKY005_2\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtDgrKltKontrol);

                if (dtDgrKltKontrol.Rows.Count > 0)
                {
                    txtKontrol1.Text = dtDgrKltKontrol.Rows[0][0].ToString();
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
                //dataTable1.Columns.Add("Tank No", typeof(string));
                //dataTable1.Columns.Add("Stand. Süt Miktarı", typeof(string));
                //dataTable1.Columns.Add("Stand. Süt Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Kültürleme Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Operatör Adı", typeof(string));
                //dataTable1.Columns.Add("Stand. Süt PH", typeof(string));
                //dataTable1.Columns.Add("Stand. Süt SH", typeof(string));
                //dataTable1.Columns.Add("Stand. Süt KM", typeof(string));
                //dataTable1.Columns.Add("Teknik Personel Adı", typeof(string));

                //dataTable1.Rows.Add("");
                //dataTable1.Rows.Add("");
                //dataGridView1.DataSource = dataTable1;

                //dataGridView1.AllowUserToAddRows = false;
                //dataGridView1.AllowUserToDeleteRows = false;
                //dataGridView1.AllowUserToResizeColumns = false;
                //dataGridView1.AllowUserToResizeRows = false;
                //dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                ////dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(250, 191, 143);
                //dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(220, 230, 241);

                //dataGridView1.EnableHeadersVisualStyles = false;
                //dataGridView1.RowHeadersVisible = false;

                //dataGridView1.ColumnHeadersHeight = 50;
                //dataGridView1.RowTemplate.Height = 40;

                //for (int i = 0; i < dataGridView1.Columns.Count - 4; i++)
                //{
                //    dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.FromArgb(250, 191, 143);
                //}
                //for (int i = 5; i < dataGridView1.Columns.Count; i++)
                //{
                //    dataGridView1.Columns[i].HeaderCell.Style.BackColor = Color.FromArgb(146, 208, 80);
                //}
                //foreach (DataGridViewColumn column in dataGridView1.Columns)
                //{
                //    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                //    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //    column.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                //}
                #endregion

                #region dataGridView2
                datagridView2Load();
                //    //dataTable2.Columns.Add("#", "#");
                //    dataTable2.Columns.Add("Ürün Adı", typeof(string));
                //    dataTable2.Columns.Add("Doluma Başlama Onayı", typeof(string));
                //    dataTable2.Columns.Add("Sorumlu Mühendis", typeof(string));

                //    dataTable2.Rows.Add("");
                //    dataGridView2.DataSource = dataTable2;

                //    dataGridView2.AllowUserToAddRows = false;
                //    dataGridView2.AllowUserToDeleteRows = false;
                //    dataGridView2.AllowUserToResizeColumns = false;
                //    dataGridView2.AllowUserToResizeRows = false;
                //    dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                //    dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                //    dataGridView2.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(146, 208, 80);
                //    dataGridView2.DefaultCellStyle.BackColor = Color.FromArgb(220, 230, 241);

                //    dataGridView2.EnableHeadersVisualStyles = false;
                //    dataGridView2.RowHeadersVisible = false;

                //    dataGridView2.ColumnHeadersHeight = 50;
                //    dataGridView2.RowTemplate.Height = 40;

                //    foreach (DataGridViewColumn column in dataGridView2.Columns)
                //    {
                //        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                //        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                //        column.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
                //    }
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
            string sql = "SELECT T1.\"U_TankNo\" as \"Tank No\",T1.\"U_StanSutMik\" as \"Stand. Süt Miktarı\",T1.\"U_StanSutSic\" as \"Stand. Süt Sıcaklığı\",T1.\"U_KulturSic\" as \"Kültürleme Sıcaklığı\",T1.\"U_OprtAdi\" as \"Operatör Adı\",T1.\"U_StanSutPH\" as \"Stand. Süt PH\",T1.\"U_StanSutSH\" as \"Stand. Süt SH\",T1.\"U_StanSutKM\" as \"Stand. Süt KM\",T1.\"U_TekPersAdi\" as \"Teknik Personel Adı\" FROM \"@AIF_FSAPKY005_2\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY005_2_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Stand. Süt Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Stand. Süt Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Kültürleme Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";
                dr["Stand. Süt PH"] = Convert.ToString("0", cultureTR);
                dr["Stand. Süt SH"] = Convert.ToString("0", cultureTR);
                dr["Stand. Süt KM"] = Convert.ToString("0", cultureTR);
                dr["Teknik Personel Adı"] = "";

                dataTable1.Rows.Add(dr);
            }
            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void datagridView2Load()
        {


            string sql = "SELECT T1.\"U_UrunAdi\" as \"Ürün Adı\",T1.\"U_DolBasOny\" as \"Doluma Başlama Onayı\",T1.\"U_SorumluMuh\" as \"Sorumlu Mühendis\" FROM \"@AIF_FSAPKY005_2\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY005_2_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Doluma Başlama Onayı"] = "";
                dr["Sorumlu Mühendis"] = "";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            currentCell = e.RowIndex;
            grid1Secildi = true; 
            #endregion

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Tank No" || dataGridView1.Columns[e.ColumnIndex].Name == "Stand. Süt Miktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Stand. Süt Sıcaklığı" || dataGridView1.Columns[e.ColumnIndex].Name == "Kültürleme Sıcaklığı" || dataGridView1.Columns[e.ColumnIndex].Name == "Stand. Süt PH" || dataGridView1.Columns[e.ColumnIndex].Name == "Stand. Süt SH" || dataGridView1.Columns[e.ColumnIndex].Name == "Stand. Süt KM")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Operatör Adı" || dataGridView1.Columns[e.ColumnIndex].Name == "Teknik Personel Adı")
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
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Doluma Başlama Onayı")
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
                    SelectList selectList = new SelectList(sql, dataGridView2, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();
                }
                else
                {
                    CustomMsgBtn.Show("Ürün Bulunamadı.", "UYARI", "TAMAM");

                }
            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Sorumlu Mühendis")
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

            FSAPKY005_2 fSAPKY005_2 = new FSAPKY005_2();

            FSAPKY005_2_1 fSAPKY005_2_1 = new FSAPKY005_2_1();
            FSAPKY005_2_2 fSAPKY005_2_2 = new FSAPKY005_2_2();

            List<FSAPKY005_2_1> fSAPKY005_2_1s = new List<FSAPKY005_2_1>();
            List<FSAPKY005_2_2> fSAPKY005_2_2s = new List<FSAPKY005_2_2>();

            fSAPKY005_2.PartiNo = txtPartiNo.Text;
            fSAPKY005_2.UrunTanimi = txtUrunTanimi.Text;

            #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
            //fSAPKY005_2.Tarih = tarih1;
            DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            fSAPKY005_2.Tarih = uretimtarihi.ToString("yyyyMMdd");
            #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

            fSAPKY005_2.Aciklama = "";
            fSAPKY005_2.UrunKodu = urunKodu;
            fSAPKY005_2.Kontrol1 = txtKontrol1.Text;

            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                fSAPKY005_2_1 = new FSAPKY005_2_1();
                fSAPKY005_2_1.TankNumarasi = dr.Cells["Tank No"].Value == DBNull.Value ? "" : dr.Cells["Tank No"].Value.ToString();
                fSAPKY005_2_1.StanSutMiktari = dr.Cells["Stand. Süt Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Stand. Süt Miktarı"].Value);
                fSAPKY005_2_1.StanSutSicakligi = dr.Cells["Stand. Süt Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Stand. Süt Sıcaklığı"].Value);
                fSAPKY005_2_1.KulturlemeSicakligi = dr.Cells["Kültürleme Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kültürleme Sıcaklığı"].Value);
                fSAPKY005_2_1.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

                fSAPKY005_2_1.StanSutPH = dr.Cells["Stand. Süt PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Stand. Süt PH"].Value);
                fSAPKY005_2_1.StanSutSH = dr.Cells["Stand. Süt SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Stand. Süt SH"].Value);
                fSAPKY005_2_1.StanSutKM = dr.Cells["Stand. Süt KM"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Stand. Süt KM"].Value);
                fSAPKY005_2_1.TekPersAdi = dr.Cells["Teknik Personel Adı"].Value == DBNull.Value ? "" : dr.Cells["Teknik Personel Adı"].Value.ToString();


                fSAPKY005_2_1s.Add(fSAPKY005_2_1);
            }

            fSAPKY005_2.fSAPKY005_2_1s = fSAPKY005_2_1s.ToArray();

            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                fSAPKY005_2_2 = new FSAPKY005_2_2();
                fSAPKY005_2_2.UrunAdi = dr.Cells["Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Ürün Adı"].Value.ToString();
                fSAPKY005_2_2.DolumaBaslamaOnayi = dr.Cells["Doluma Başlama Onayı"].Value == DBNull.Value ? "" : dr.Cells["Doluma Başlama Onayı"].Value.ToString();
                fSAPKY005_2_2.SorumluMuhendis = dr.Cells["Sorumlu Mühendis"].Value == DBNull.Value ? "" : dr.Cells["Sorumlu Mühendis"].Value.ToString();

                fSAPKY005_2_2s.Add(fSAPKY005_2_2);
            }

            fSAPKY005_2.fSAPKY005_2_2s = fSAPKY005_2_2s.ToArray();

            var resp = client.addOrUpdateFSAPKY005_2(fSAPKY005_2, Giris.dbName, Giris.mKodValue);

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
        int currentCell = -1;
        private void dataGridView1_Click(object sender, EventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            grid1Secildi = true; 
            #endregion
        }

        private void dataGridView2_Click(object sender, EventArgs e)
        {
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

            currentCell = -1;
        }

        private void btnSatirEkle_Click(object sender, EventArgs e)
        {
            if (grid1Secildi)
            {
                try
                {
                    if (dataGridView1.Rows.Count >= 15)
                    {
                        return;
                    }

                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dataTable1.NewRow();
                    dr["Tank No"] = "";
                    dr["Stand. Süt Miktarı"] = Convert.ToString("0", cultureTR);
                    dr["Stand. Süt Sıcaklığı"] = Convert.ToString("0", cultureTR);
                    dr["Kültürleme Sıcaklığı"] = Convert.ToString("0", cultureTR);
                    dr["Operatör Adı"] = "";
                    dr["Stand. Süt PH"] = Convert.ToString("0", cultureTR);
                    dr["Stand. Süt SH"] = Convert.ToString("0", cultureTR);
                    dr["Stand. Süt KM"] = Convert.ToString("0", cultureTR);
                    dr["Teknik Personel Adı"] = "";

                    dataTable1.Rows.Add(dr);

                }
                catch (Exception ex)
                {
                }
            }  
        }
    }
}

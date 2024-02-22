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
    public partial class _20_FSAPKY_012_1 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_012_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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
        private void _20_FSAPKY_012_1_Load(object sender, EventArgs e)
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


                string sql = "SELECT \"U_DigerKontrol\" FROM \"@AIF_FSAPKY012_1\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtDgrKltKontrol);


                if (dtDgrKltKontrol.Rows.Count > 0)
                {
                    txtKontrol.Text = dtDgrKltKontrol.Rows[0][0].ToString();
                }
                else
                {
                    txtKontrol.Text = "";
                }



                if (txtKontrol.Text == "Y")
                {
                    btnHayir.BackColor = buttondefaultrenk;
                    btnEvet.BackColor = Color.GreenYellow;
                }
                else if (txtKontrol.Text == "N")
                {
                    btnHayir.BackColor = Color.OrangeRed;
                    btnEvet.BackColor = buttondefaultrenk;
                }

                #endregion


                #region dataGridView1 

                datagridView1Load();
                //dataTable1.Columns.Add("#", "#");
                //dataTable1.Columns.Add("Çiğ Krema Miktarı", typeof(string));
                //dataTable1.Columns.Add("Krema Pastörizasyon", typeof(string));
                //dataTable1.Columns.Add("Pastörizasyon Başlangıç Saati", typeof(string));
                //dataTable1.Columns.Add("Pastörizasyon Bitiş Saati", typeof(string));
                //dataTable1.Columns.Add("Mayalama Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Kültür Ekleme Oranı", typeof(string));
                //dataTable1.Columns.Add("Tereyağı Operatör Adı", typeof(string));

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
                //dataTable2.Columns.Add("Çiğ Kremanın Yağ Oranı", typeof(string));
                //dataTable2.Columns.Add("Çiğ Krema PH", typeof(string));
                //dataTable2.Columns.Add("Pastörize Kremanın Yağ Oranı", typeof(string));
                //dataTable2.Columns.Add("Pastörize Krema PH", typeof(string)); 
                //dataTable2.Columns.Add("Laboratuvar Personelinin Adı", typeof(string));

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


            string sql = "SELECT T1.\"U_CigKreMik\" as \"Çiğ Krema Miktarı\",T1.\"U_KremaPast\" as \"Krema Pastörizasyon\",\"U_PastBasSa\" as \"Pastörizasyon Başlangıç Saati\",T1.\"U_PastBitSa\" as \"Pastörizasyon Bitiş Saati\",\"U_MayaSicak\" as \"Mayalama Sıcaklığı\",\"U_KultrEkOr\" as \"Kültür Ekleme Oranı\",T1.\"U_TrygOprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY012_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY012_1_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Çiğ Krema Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Krema Pastörizasyon"] = Convert.ToString("0", cultureTR);
                dr["Pastörizasyon Başlangıç Saati"] = ""; ;
                dr["Pastörizasyon Bitiş Saati"] = "";
                dr["Mayalama Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Kültür Ekleme Oranı"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";
                dataTable1.Rows.Add(dr);
            }
            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }


        private void datagridView2Load()
        {
            string sql = "SELECT T1.\"U_CigKreYagOr\" as \"Çiğ Kremanın Yağ Oranı\",T1.\"U_CigKremaPH\" as \"Çiğ Krema PH\",\"U_PasKreYagOr\" as \"Pastörize Kremanın Yağ Oranı\",T1.\"U_PasKrePH\" as \"Pastörize Krema PH\",T1.\"U_LabPersAdi\" as \"Laboratuvar Personelinin Adı\" FROM \"@AIF_FSAPKY012_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY012_1_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Çiğ Kremanın Yağ Oranı"] = Convert.ToString("0", cultureTR);
                dr["Çiğ Krema PH"] = Convert.ToString("0", cultureTR);
                dr["Pastörize Kremanın Yağ Oranı"] = Convert.ToString("0", cultureTR);
                dr["Pastörize Krema PH"] = Convert.ToString("0", cultureTR);
                dr["Laboratuvar Personelinin Adı"] = "";
                dataTable2.Rows.Add(dr);
            }
            dataGridView2.Columns["Laboratuvar Personelinin Adı"].ReadOnly = true;
        }

        private void btnEvet_Click(object sender, EventArgs e)
        {
            btnHayir.BackColor = buttondefaultrenk;
            btnEvet.BackColor = Color.GreenYellow;
            txtKontrol.Text = "Y";
        }

        private void btnHayir_Click(object sender, EventArgs e)
        {
            btnHayir.BackColor = Color.OrangeRed;
            btnEvet.BackColor = buttondefaultrenk;
            txtKontrol.Text = "N";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            currentCell = e.RowIndex;
            grid1Secildi = true;
            grid2Secildi = false;
            #endregion

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Çiğ Krema Miktarı" || dataGridView1.Columns[e.ColumnIndex].Name == "Krema Pastörizasyon" || dataGridView1.Columns[e.ColumnIndex].Name == "Mayalama Sıcaklığı" || dataGridView1.Columns[e.ColumnIndex].Name == "Kültür Ekleme Oranı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Pastörizasyon Başlangıç Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Pastörizasyon Bitiş Saati")
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
            #region satır ekle sil işlemi için kulanılır
            currentCell = e.RowIndex;
            grid1Secildi = false;
            grid2Secildi = true;
            #endregion

            if (dataGridView2.Columns[e.ColumnIndex].Name == "Çiğ Kremanın Yağ Oranı" || dataGridView2.Columns[e.ColumnIndex].Name == "Çiğ Krema PH" || dataGridView2.Columns[e.ColumnIndex].Name == "Pastörize Kremanın Yağ Oranı" || dataGridView2.Columns[e.ColumnIndex].Name == "Pastörize Krema PH")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2, false);
                n.ShowDialog();
            } 
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Laboratuvar Personelinin Adı")
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
            FSAPKY012_1 fSAPKY012_1 = new FSAPKY012_1();
            List<FSAPKY012_1_1> fSAPKY012_1_1s = new List<FSAPKY012_1_1>();
            FSAPKY012_1_1 fSAPKY012_1_1 = new FSAPKY012_1_1();
            List<FSAPKY012_1_2> fSAPKY012_1_2s = new List<FSAPKY012_1_2>();
            FSAPKY012_1_2 fSAPKY012_1_2 = new FSAPKY012_1_2();



            fSAPKY012_1.PartiNo = txtPartiNo.Text;
            fSAPKY012_1.UrunTanimi = txtUrunTanimi.Text;

            #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
            //fSAPKY012_1.Tarih = tarih1;
            DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            fSAPKY012_1.Tarih = uretimtarihi.ToString("yyyyMMdd");
            #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

            fSAPKY012_1.Aciklama = "";
            fSAPKY012_1.UrunKodu = urunKodu;
            fSAPKY012_1.DigerKontrol = txtKontrol.Text;


            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                fSAPKY012_1_1 = new FSAPKY012_1_1();
                fSAPKY012_1_1.CigKremeMiktari = dr.Cells["Çiğ Krema Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Krema Miktarı"].Value);
                fSAPKY012_1_1.KremaPastorizasyon = dr.Cells["Krema Pastörizasyon"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Krema Pastörizasyon"].Value);
                fSAPKY012_1_1.PastorizasyonBaslangicSaati = dr.Cells["Pastörizasyon Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Pastörizasyon Başlangıç Saati"].Value.ToString();
                fSAPKY012_1_1.PastorizasyonBitisSaati = dr.Cells["Pastörizasyon Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Pastörizasyon Bitiş Saati"].Value.ToString();
                fSAPKY012_1_1.MayalamaSicakligi = dr.Cells["Mayalama Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Mayalama Sıcaklığı"].Value);
                fSAPKY012_1_1.KulturEklemeOrani = dr.Cells["Kültür Ekleme Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kültür Ekleme Oranı"].Value);
                fSAPKY012_1_1.TereyagOperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

                fSAPKY012_1_1s.Add(fSAPKY012_1_1);
            }

            fSAPKY012_1.fSAPKY012_1_1s = fSAPKY012_1_1s.ToArray(); 


            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                fSAPKY012_1_2 = new FSAPKY012_1_2();
                fSAPKY012_1_2.CigKremaninYagOrani = dr.Cells["Çiğ Kremanın Yağ Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Kremanın Yağ Oranı"].Value);
                fSAPKY012_1_2.CigKremaPH = dr.Cells["Çiğ Krema PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çiğ Krema PH"].Value);
                fSAPKY012_1_2.PastorizeKremaninYagOrani = dr.Cells["Pastörize Kremanın Yağ Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastörize Kremanın Yağ Oranı"].Value);
                fSAPKY012_1_2.PastorizeKremaPH = dr.Cells["Pastörize Krema PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastörize Krema PH"].Value);
                fSAPKY012_1_2.LabPersonelAdi = dr.Cells["Laboratuvar Personelinin Adı"].Value == DBNull.Value ? "" : dr.Cells["Laboratuvar Personelinin Adı"].Value.ToString();

                fSAPKY012_1_2s.Add(fSAPKY012_1_2);
            }

            fSAPKY012_1.fSAPKY012_1_2s = fSAPKY012_1_2s.ToArray();

            var resp = client.addOrUpdateFSAPKY012_1(fSAPKY012_1, Giris.dbName, Giris.mKodValue);
             
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
                    if (dataGridView1.Rows.Count >= 5)
                    {
                        return;
                    }

                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dataTable1.NewRow();
                    dr["Çiğ Krema Miktarı"] = Convert.ToString("0", cultureTR);
                    dr["Krema Pastörizasyon"] = Convert.ToString("0", cultureTR);
                    dr["Pastörizasyon Başlangıç Saati"] = ""; ;
                    dr["Pastörizasyon Bitiş Saati"] = "";
                    dr["Mayalama Sıcaklığı"] = Convert.ToString("0", cultureTR);
                    dr["Kültür Ekleme Oranı"] = Convert.ToString("0", cultureTR);
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
                    if (dataGridView2.Rows.Count >= 5)
                    {
                        return;
                    }

                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dataTable2.NewRow();
                    dr["Çiğ Kremanın Yağ Oranı"] = Convert.ToString("0", cultureTR);
                    dr["Çiğ Krema PH"] = Convert.ToString("0", cultureTR);
                    dr["Pastörize Kremanın Yağ Oranı"] = Convert.ToString("0", cultureTR);
                    dr["Pastörize Krema PH"] = Convert.ToString("0", cultureTR);
                    dr["Laboratuvar Personelinin Adı"] = "";
                    dataTable2.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}

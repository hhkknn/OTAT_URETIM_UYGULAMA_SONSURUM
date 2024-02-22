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
    public partial class _20_FSAPKY_009_1 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_009_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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
        private void _20_FSAPKY_009_1_Load(object sender, EventArgs e)
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
                //dataTable1.Columns.Add("Pişirim No", typeof(string));
                //dataTable1.Columns.Add("Başlangıç Saati", typeof(string));
                //dataTable1.Columns.Add("Pişirim Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Bitiş Saati", typeof(string));
                //dataTable1.Columns.Add("UF Operatör Adı", typeof(string));
                //dataTable1.Columns.Add("Pişirim Öncesi Yarımamül PH", typeof(string));
                //dataTable1.Columns.Add("Pişirim Sonrası Yarımamül PH", typeof(string));
                //dataTable1.Columns.Add("Kurumadde", typeof(string));
                //dataTable1.Columns.Add("Yağ", typeof(string));
                //dataTable1.Columns.Add("Laboratuvar Pers. Adı", typeof(string));

                //dataTable1.Rows.Add("");
                //dataTable1.Rows.Add("");
                //dataTable1.Rows.Add("");
                //dataTable1.Rows.Add("");
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
                //dataTable2.Columns.Add("#", "#");
                //dataTable2.Columns.Add("Ürün Adı", typeof(string));
                //dataTable2.Columns.Add("Duyusal Analiz Onayı", typeof(string));
                //dataTable2.Columns.Add("Sorumlu Mühendis", typeof(string));

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

            string sql = "SELECT T1.\"U_PisirNo\" as \"Pişirim No\",T1.\"U_BasSaat\" as \"Başlangıç Saati\",\"U_PisirSic\" as \"Pişirim Sıcaklığı\",T1.\"U_BitSaat\" as \"Bitiş Saati\",\"U_UFOprtAdi\" as \"UF Operatör Adı\",\"U_PisOnYrmPH\" as \"Pişirim Öncesi Yarımamül PH\",T1.\"U_PisSonYrmPH\" as \"Pişirim Sonrası Yarımamül PH\",T1.\"U_KuruMadde\" as \"Kurumadde\",T1.\"U_Yag\" as \"Yağ\",T1.\"U_LabPersAdi\" as \"Laboratuvar Pers. Adı\" FROM \"@AIF_FSAPKY009_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY009_1_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Pişirim No"] = DBNull.Value;
                dr["Başlangıç Saati"] = "";
                dr["Pişirim Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Bitiş Saati"] = "";
                dr["UF Operatör Adı"] = "";
                dr["Pişirim Öncesi Yarımamül PH"] = Convert.ToString("0", cultureTR);
                dr["Pişirim Sonrası Yarımamül PH"] = Convert.ToString("0", cultureTR);
                dr["Kurumadde"] = Convert.ToString("0", cultureTR);
                dr["Yağ"] = Convert.ToString("0", cultureTR);
                dr["Laboratuvar Pers. Adı"] = "";
                dataTable1.Rows.Add(dr);
            }
            dataGridView1.Columns["UF Operatör Adı"].ReadOnly = true;
            dataGridView1.Columns["Laboratuvar Pers. Adı"].ReadOnly = true;

        }


        private void datagridView2Load()
        {

            string sql = "SELECT T1.\"U_UrunKodu\" as \"Ürün Kodu\",T1.\"U_UrunAdi\" as \"Ürün Adı\",\"U_DuyAnOrn\" as \"Duyusal Analiz Onayı\",T1.\"U_SorumluMuh\" as \"Sorumlu Mühendis\" FROM \"@AIF_FSAPKY009_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY009_1_2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                dr["Ürün Kodu"] = "";
                dr["Ürün Adı"] = "";
                dr["Duyusal Analiz Onayı"] = "";
                dr["Sorumlu Mühendis"] = "";
                dataTable2.Rows.Add(dr);
            }

            dataGridView2.Columns["Ürün Kodu"].Visible = false;
            dataGridView2.Columns["Sorumlu Mühendis"].ReadOnly = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            currentCell = e.RowIndex;
            grid1Secildi = true;
            #endregion

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Pişirim No" || dataGridView1.Columns[e.ColumnIndex].Name == "Pişirim Sıcaklığı" || dataGridView1.Columns[e.ColumnIndex].Name == "Pişirim Öncesi Yarımamül PH" || dataGridView1.Columns[e.ColumnIndex].Name == "Pişirim Sonrası Yarımamül PH" || dataGridView1.Columns[e.ColumnIndex].Name == "Kurumadde" || dataGridView1.Columns[e.ColumnIndex].Name == "Yağ")
            {

                if (dataGridView1.Columns[e.ColumnIndex].Name == "Pişirim No")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false, true);
                    n.ShowDialog();

                    if (dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Pişirim No"].Value != DBNull.Value && dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells["Pişirim No"].Value.ToString() != "0")
                    {
                        if (dataGridView1.Rows.Count >= 15)
                        {
                            return;
                        }

                        DataRow dr = dataTable1.NewRow();
                        dr["Pişirim No"] = DBNull.Value;

                        dataTable1.Rows.Add(dr);
                    }
                }
                else
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                    n.ShowDialog();
                }
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Başlangıç Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Bitiş Saati")
            {
                SaatTarihGirisi n = new SaatTarihGirisi(dataGridView1);
                n.ShowDialog();
            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "UF Operatör Adı" || dataGridView1.Columns[e.ColumnIndex].Name == "Laboratuvar Pers. Adı")
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

                    SelectList selectList = new SelectList(sql1, dataGridView2, 0, 1, _autoresizerow: false);
                    selectList.ShowDialog();
                }
                else
                { 
                    CustomMsgBtn.Show("Ürün Bulunamadı.", "UYARI", "TAMAM");

                }

            }
            else if (dataGridView2.Columns[e.ColumnIndex].Name == "Duyusal Analiz Onayı")
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
                    SelectList selectList = new SelectList(sql, dataGridView2, 2, -1, _autoresizerow: false);
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
            FSAPKY009_1 fSAPKY009_1 = new FSAPKY009_1();
            List<FSAPKY009_1_1> fSAPKY009_1_1s = new List<FSAPKY009_1_1>();
            FSAPKY009_1_1 fSAPKY009_1_1 = new FSAPKY009_1_1();
            List<FSAPKY009_1_2> fSAPKY009_1_2s = new List<FSAPKY009_1_2>();
            FSAPKY009_1_2 fSAPKY009_1_2 = new FSAPKY009_1_2();



            fSAPKY009_1.PartiNo = txtPartiNo.Text;
            fSAPKY009_1.UrunTanimi = txtUrunTanimi.Text;

            #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
            //fSAPKY009_1.Tarih = tarih1;
            DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            fSAPKY009_1.Tarih = uretimtarihi.ToString("yyyyMMdd");
            #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

            fSAPKY009_1.Aciklama = "";
            fSAPKY009_1.UrunKodu = urunKodu;


            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                fSAPKY009_1_1 = new FSAPKY009_1_1();
                fSAPKY009_1_1.PisirmeNo = (dr.Cells["Pişirim No"].Value == DBNull.Value || dr.Cells["Pişirim No"].Value.ToString() == "") ? 0 : Convert.ToInt32(dr.Cells["Pişirim No"].Value); 
                fSAPKY009_1_1.BaslangicSaati = dr.Cells["Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Başlangıç Saati"].Value.ToString();
                fSAPKY009_1_1.PisirimSicakligi = dr.Cells["Pişirim Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pişirim Sıcaklığı"].Value);
                fSAPKY009_1_1.BitisSaati = dr.Cells["Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Bitiş Saati"].Value.ToString();
                fSAPKY009_1_1.UFOperatorAdi = dr.Cells["UF Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["UF Operatör Adı"].Value.ToString();
                fSAPKY009_1_1.PisirimOncesiYariMamulPH = dr.Cells["Pişirim Öncesi Yarımamül PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pişirim Öncesi Yarımamül PH"].Value);
                fSAPKY009_1_1.PisirimSonrasiYariMamulPH = dr.Cells["Pişirim Sonrası Yarımamül PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pişirim Sonrası Yarımamül PH"].Value);
                fSAPKY009_1_1.Kurumadde = dr.Cells["Kurumadde"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kurumadde"].Value);
                fSAPKY009_1_1.Yag = dr.Cells["Yağ"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ"].Value);
                fSAPKY009_1_1.LabPersonelAdi = dr.Cells["Laboratuvar Pers. Adı"].Value == DBNull.Value ? "" : dr.Cells["Laboratuvar Pers. Adı"].Value.ToString();

                fSAPKY009_1_1s.Add(fSAPKY009_1_1);
            }

            fSAPKY009_1.fSAPKY009_1_1s = fSAPKY009_1_1s.ToArray();

            foreach (DataGridViewRow dr in dataGridView2.Rows)
            {
                fSAPKY009_1_2 = new FSAPKY009_1_2();
                fSAPKY009_1_2.UrunKodu = dr.Cells["Ürün Kodu"].Value == DBNull.Value ? "" : dr.Cells["Ürün Kodu"].Value.ToString();
                fSAPKY009_1_2.UrunAdi = dr.Cells["Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Ürün Adı"].Value.ToString();
                fSAPKY009_1_2.DuyusalAnalizOnayi = dr.Cells["Duyusal Analiz Onayı"].Value == DBNull.Value ? "" : dr.Cells["Duyusal Analiz Onayı"].Value.ToString();
                fSAPKY009_1_2.SorumluMuhendis = dr.Cells["Sorumlu Mühendis"].Value == DBNull.Value ? "" : dr.Cells["Sorumlu Mühendis"].Value.ToString();

                fSAPKY009_1_2s.Add(fSAPKY009_1_2);
            }

            fSAPKY009_1.fSAPKY009_1_2s = fSAPKY009_1_2s.ToArray();

            var resp = client.addOrUpdateFSAPKY009_1(fSAPKY009_1, Giris.dbName, Giris.mKodValue);
             
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
                    dr["Pişirim No"] = DBNull.Value;
                    dr["Başlangıç Saati"] = "";
                    dr["Pişirim Sıcaklığı"] = Convert.ToString("0", cultureTR);
                    dr["Bitiş Saati"] = "";
                    dr["UF Operatör Adı"] = "";
                    dr["Pişirim Öncesi Yarımamül PH"] = Convert.ToString("0", cultureTR);
                    dr["Pişirim Sonrası Yarımamül PH"] = Convert.ToString("0", cultureTR);
                    dr["Kurumadde"] = Convert.ToString("0", cultureTR);
                    dr["Yağ"] = Convert.ToString("0", cultureTR);
                    dr["Laboratuvar Pers. Adı"] = "";
                    dataTable1.Rows.Add(dr); 

                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}

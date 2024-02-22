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
    public partial class _20_FSAPKY_010_1 : Form
    {
        #region Font
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        #endregion
        public _20_FSAPKY_010_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunKodu)
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
        private void _20_FSAPKY_010_1_Load(object sender, EventArgs e)
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
                //dataTable1.Columns.Add("Krema Yağ Oranı", typeof(string));
                //dataTable1.Columns.Add("Krema Sıcaklığı", typeof(string));
                //dataTable1.Columns.Add("Yayıklama Başlangıç Saati", typeof(string));
                //dataTable1.Columns.Add("Yayıklama Bitiş Saati", typeof(string));
                //dataTable1.Columns.Add("Tereyağı Randımanı", typeof(string));
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
            string sql = "SELECT T1.\"U_KullKrema\" as \"Kullanılan Krema\",T1.\"U_KreYagOr\" as \"Krema Yağ Oranı\",\"U_KreSicak\" as \"Krema Sıcaklığı\",T1.\"U_YayBasSaat\" as \"Yayıklama Başlangıç Saati\",\"U_YayBitSaat\" as \"Yayıklama Bitiş Saati\",T1.\"U_TrygRand\" as \"Tereyağı Randımanı\",\"U_OprtAdi\" as \"Operatör Adı\" FROM \"@AIF_FSAPKY010_1\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_FSAPKY010_1_1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

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
                dr["Krema Yağ Oranı"] = Convert.ToString("0", cultureTR);
                dr["Krema Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Yayıklama Başlangıç Saati"] = "";
                dr["Yayıklama Bitiş Saati"] = "";
                dr["Tereyağı Randımanı"] = Convert.ToString("0", cultureTR);
                dr["Operatör Adı"] = "";

                dataTable1.Rows.Add(dr);
            }
            dataGridView1.Columns["Operatör Adı"].ReadOnly = true;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            #region satır ekle sil işlemi için kulanılır
            currentCell = e.RowIndex;
            grid1Secildi = true;  
            #endregion

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Kullanılan Krema" || dataGridView1.Columns[e.ColumnIndex].Name == "Krema Yağ Oranı" || dataGridView1.Columns[e.ColumnIndex].Name == "Krema Sıcaklığı" || dataGridView1.Columns[e.ColumnIndex].Name == "Tereyağı Randımanı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView1, false);
                n.ShowDialog();
            }
            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Yayıklama Başlangıç Saati" || dataGridView1.Columns[e.ColumnIndex].Name == "Yayıklama Bitiş Saati")
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

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            UVTServiceSoapClient client = new UVTServiceSoapClient();
            FSAPKY010_1 fSAPKY010_1 = new FSAPKY010_1();
            List<FSAPKY010_1_1> fSAPKY010_1_1s = new List<FSAPKY010_1_1>();
            FSAPKY010_1_1 fSAPKY010_1_1 = new FSAPKY010_1_1();



            fSAPKY010_1.PartiNo = txtPartiNo.Text;
            fSAPKY010_1.UrunTanimi = txtUrunTanimi.Text;

            #region Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.
            //fSAPKY010_1.Tarih = tarih1;
            DateTime uretimtarihi = DateTime.ParseExact(txtUretimTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            fSAPKY010_1.Tarih = uretimtarihi.ToString("yyyyMMdd");
            #endregion Tarih değiştirilebilir yapılmıştır.Eski tarih1 kapatılmıştır.

            fSAPKY010_1.Aciklama = "";
            fSAPKY010_1.UrunKodu = urunKodu;


            foreach (DataGridViewRow dr in dataGridView1.Rows)
            {
                fSAPKY010_1_1 = new FSAPKY010_1_1();
                fSAPKY010_1_1.KullanilanKrema = dr.Cells["Kullanılan Krema"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kullanılan Krema"].Value);
                fSAPKY010_1_1.KremaYagOrani = dr.Cells["Krema Yağ Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Krema Yağ Oranı"].Value);
                fSAPKY010_1_1.KremaSicakligi = dr.Cells["Krema Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Krema Sıcaklığı"].Value);
                fSAPKY010_1_1.YayiklamaBaslangicSaati = dr.Cells["Yayıklama Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Yayıklama Başlangıç Saati"].Value.ToString();
                fSAPKY010_1_1.YayiklamaBitisSaati = dr.Cells["Yayıklama Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Yayıklama Bitiş Saati"].Value.ToString();
                fSAPKY010_1_1.TereyagRandimani = dr.Cells["Tereyağı Randımanı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tereyağı Randımanı"].Value);
                fSAPKY010_1_1.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();

                fSAPKY010_1_1s.Add(fSAPKY010_1_1);
            }

            fSAPKY010_1.fSAPKY010_1_1s = fSAPKY010_1_1s.ToArray();

            var resp = client.addOrUpdateFSAPKY010_1(fSAPKY010_1, Giris.dbName, Giris.mKodValue);
             
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
                    dr["Kullanılan Krema"] = Convert.ToString("0", cultureTR);
                    dr["Krema Yağ Oranı"] = Convert.ToString("0", cultureTR);
                    dr["Krema Sıcaklığı"] = Convert.ToString("0", cultureTR);
                    dr["Yayıklama Başlangıç Saati"] = "";
                    dr["Yayıklama Bitiş Saati"] = "";
                    dr["Tereyağı Randımanı"] = Convert.ToString("0", cultureTR);
                    dr["Operatör Adı"] = "";

                    dataTable1.Rows.Add(dr);
                }
                catch (Exception ex)
                {
                } 
            }
        }
    }
}

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
    public partial class TelemeProsesTakip_2 : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end.

        public TelemeProsesTakip_2(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1)
        {
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            initialFontSize = label3.Font.Size;
            label3.Resize += Form_Resize;

            initialFontSize = txtUretimFisNo.Font.Size;
            txtUretimFisNo.Resize += Form_Resize;

            initialFontSize = txtPartiNo.Font.Size;
            txtPartiNo.Resize += Form_Resize;

            initialFontSize = txtPartiNo.Font.Size;
            txtPartiNo.Resize += Form_Resize;

            initialFontSize = txtUrunTanimi.Font.Size;
            txtUrunTanimi.Resize += Form_Resize;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;

            initialFontSize = btnOzetEkranaDon.Font.Size;
            btnOzetEkranaDon.Resize += Form_Resize;

            initialFontSize = button4.Font.Size;
            button4.Resize += Form_Resize;

            initialFontSize = button5.Font.Size;
            button5.Resize += Form_Resize;
            //font end

            UretimFisNo = _UretimFisNo;
            partiNo = _PartiNo;
            UrunTanimi = _UrunTanimi;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;
            txtUretimFisNo.Text = UretimFisNo;
            txtPartiNo.Text = partiNo;
            txtUrunTanimi.Text = UrunTanimi;
            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
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

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button2.Font.Style);

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);

            button4.Font = new Font(button4.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button4.Font.Style);

            button5.Font = new Font(button5.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button5.Font.Style);

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
            (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            label4.Font.Style);

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimTarihi.Font.Style);
            ResumeLayout();
            //font end
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

        private string UretimFisNo = "";
        private string partiNo = "";
        private string istasyon = "";
        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private int row = 0;
        private string tarih1 = "";
        private SqlCommand cmd = null;

        private void TelemeProsesTakip_2_Load(object sender, EventArgs e)
        {
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_TLMMML_ANALIZ\" AS T0  WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                txtAciklama.Text = dt.Rows[0].ItemArray[0].ToString();
            }

            //dtgMamulOzellikleri1.BackColor = Color.IndianRed;
            //dtgMamulOzellikleri1.ForeColor = Color.White;

            //btnMamulOzellikleri2.BackColor = Color.RoyalBlue;
            //btnMamulOzellikleri2.ForeColor = Color.White;

            dtgMamulOzellikleri1Load();
            dtgMamulOzellikleri2Load();
        }

        private void dtgMamulOzellikleri1Load()
        {
            //string sql = "Select T1.\"ItemCode\" as \"Malzeme Kodu\",T1.\"Dscription\" as \"Malzeme Tanımı\", SUM(T1.\"Quantity\") as \"Miktar\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' group by T1.\"ItemCode\",T1.\"Dscription\"";

            string sql = "SELECT Convert(float,T1.\"U_UrtmSonrasiTelemeMik\") as \"Üretim Sonrası Teleme Miktarı(KG)\",Convert(float,T1.\"U_UrtmSonrasiTelemeMik1\") as \"1 Gün Sonra Teleme Miktarı(KG)\",Convert(float,T1.\"U_UretimRandimani\") as \"Üretim Randımanı\",T1.\"U_PersonelKodu\" as \"Personel Kodu\",T1.\"U_PersonelAdi\" as \"Personel Adı\" FROM \"@AIF_TLMMML_ANALIZ\" AS T0  WITH (NOLOCK) INNER JOIN \"@AIF_TLMMML_ANALIZ1\" AS T1  WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgMamulOzellikleri1.DataSource = dt;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgMamulOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgMamulOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgMamulOzellikleri1.EnableHeadersVisualStyles = false;
            dtgMamulOzellikleri1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgMamulOzellikleri1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Üretim Sonrası Teleme Miktarı(KG)"] = Convert.ToString("0", cultureTR);
                dr["1 Gün Sonra Teleme Miktarı(KG)"] = Convert.ToString("0", cultureTR);
                dr["Üretim Randımanı"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }
            //dt.Rows.Add();

            dtgMamulOzellikleri1.Columns["Üretim Sonrası Teleme Miktarı(KG)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri1.Columns["Üretim Sonrası Teleme Miktarı(KG)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri1.Columns["1 Gün Sonra Teleme Miktarı(KG)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri1.Columns["1 Gün Sonra Teleme Miktarı(KG)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri1.Columns["Üretim Randımanı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri1.Columns["Üretim Randımanı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgMamulOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgMamulOzellikleri1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;
        }

        private void dtgMamulOzellikleri2Load()
        {
            string sql = "SELECT Convert(float,T1.\"U_KuruMadde\") as \"Kuru Madde(%)\",Convert(float,T1.\"U_YagOrani\") as \"Yağ Oranı(%)\",Convert(float,T1.\"U_PH\") as \"PH Değeri\",Convert(float,T1.\"U_SH\") as \"SH Değeri\",Convert(float,T1.\"U_TuzOrani\") as \"Tuz Oranı\" FROM \"@AIF_TLMMML_ANALIZ\" AS T0  WITH (NOLOCK) INNER JOIN \"@AIF_TLMMML_ANALIZ2\" AS T1  WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgMamulOzellikleri2.DataSource = dt;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgMamulOzellikleri2.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgMamulOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgMamulOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dtgMamulOzellikleri2.EnableHeadersVisualStyles = false;
            dtgMamulOzellikleri2.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgMamulOzellikleri2.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri2);

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Kuru Madde(%)"] = Convert.ToString("0", cultureTR);
                dr["Yağ Oranı(%)"] = Convert.ToString("0", cultureTR);
                dr["PH Değeri"] = Convert.ToString("0", cultureTR);
                dr["SH Değeri"] = Convert.ToString("0", cultureTR);
                dr["Tuz Oranı"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }
            //dt.Rows.Add();

            dtgMamulOzellikleri2.Columns["Kuru Madde(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["Kuru Madde(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri2.Columns["Yağ Oranı(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["Yağ Oranı(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri2.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri2.Columns["SH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["SH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri2.Columns["Tuz Oranı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["Tuz Oranı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgMamulOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri2.AutoResizeRows();

            foreach (DataGridViewColumn column in dtgMamulOzellikleri2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri2.Rows[0].Height = dtgMamulOzellikleri2.Height - dtgMamulOzellikleri2.ColumnHeadersHeight;
        }

        private void dtgMamulOzellikleri1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Sil")
                //{
                //    dtgMamulOzellikleri1[0, e.RowIndex].Value = "0";
                //    dtgMamulOzellikleri1[1, e.RowIndex].Value = "0";
                //    dtgMamulOzellikleri1[2, e.RowIndex].Value = "0";
                //    dtgMamulOzellikleri1[3, e.RowIndex].Value = "";
                //    dtgMamulOzellikleri1[4, e.RowIndex].Value = "";
                //    return;
                //}
                if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "1 Gün Sonra Teleme Miktarı(KG)")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOzellikleri1);
                    n.ShowDialog();
                    //var netSutMiktari = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value);
                    //var birgunSonraTartilan = dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                    //if (netSutMiktari > 0 && birgunSonraTartilan > 0)
                    //{
                    //    var sonuc = netSutMiktari / birgunSonraTartilan;
                    //    dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc.ToString();

                    //}

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt2 = new DataTable();

                    string uretimdenCikissql = "Select T0.\"DocEntry\",ISNULL(T1.\"Quantity\",0) from \"OIGE\" as T0 WITH (NOLOCK) INNER JOIN \"IGE1\" as T1  WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "'";

                    cmd = new SqlCommand(uretimdenCikissql, Connection.sql);
                    sda = new SqlDataAdapter(cmd);
                    sda.Fill(dt2);

                    if (dt2.Rows.Count > 0)
                    {
                        var uretimicinCikisNo = dt2.Rows[0][0].ToString();
                        var miktar = Convert.ToDouble(dt2.Rows[0][1]);
                        var birgunSonraTartilan = dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                        if (birgunSonraTartilan > 0)
                        {
                            var sonuc = miktar / birgunSonraTartilan;
                            dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc;
                        }
                    }
                }
                else if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Personel Kodu" || dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Personel Adı")
                {
                    if (istasyon.StartsWith("IST"))
                    {
                        //string sql = "Select \"empID\" as \"Kullanıcı Kodu\", (\"firstName\" + ' ' + \"lastName\") as 'Ad Soyad' from OHEM where \"Active\" = 'Y'";

                        string field = "U_" + istasyon;

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

                        #region Günlük Personel Planlama 1 ekranı

                        //string sql = "Select \"U_PersonelNo\" as \"Personel No\",\"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"" + field + "\" = 'Y'";

                        #endregion Günlük Personel Planlama 1 ekranı

                        #region Günlük Personel Planlama 3 ekranı

                        //sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                        //sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and \"U_Durum\" = 'X'";

                        //if (AtanmisIsler.Joker)
                        //{
                        //    sql += " UNION ALL ";

                        //    sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                        //    sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') and \"U_Durum\" = 'X'";
                        //}

                        #endregion Günlük Personel Planlama 3 ekranı

                        #region Günlük Personel Planlama 4 ekranı
                        sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

                        if (AtanmisIsler.Joker)
                        {
                            sql += " UNION ALL ";

                            sql += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                        }
                        #endregion Günlük Personel Planlama 4 ekranı

                        SelectList selectList = new SelectList(sql, dtgMamulOzellikleri1, 3, 4, _autoresizerow: false);
                        selectList.ShowDialog();

                        //dtgMamulOzellikleri1.AutoResizeRows();
                    }
                    //UVTServiceSoapClient UVTServiceSoapClient = new UVTServiceSoapClient();
                    //var resp = UVTServiceSoapClient.GetEmployess();

                    //SelectList nesne = new SelectList("", dtgMamulOzellikleri1, 3, 4, _dtparams: resp.List);
                    //nesne.ShowDialog();
                }
                else if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name != "Personel Kodu" && dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name != "Personel Adı" /*&& dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name != "Sil"*/)
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOzellikleri1);
                    n.ShowDialog();
                }
            }
        }

        private void dtgMamulOzellikleri2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //if (dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "Sil")
                //{
                //    dtgMamulOzellikleri2[0, e.RowIndex].Value = "0";
                //    dtgMamulOzellikleri2[1, e.RowIndex].Value = "0";
                //    dtgMamulOzellikleri2[2, e.RowIndex].Value = "0";
                //    dtgMamulOzellikleri2[3, e.RowIndex].Value = "0";
                //    return;
                //}
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOzellikleri2, false);
                n.ShowDialog();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                TelemeMamulTakipAnaliz nesne = new TelemeMamulTakipAnaliz();
                MamulOzellikleri mamulOzellikleri = new MamulOzellikleri();
                List<MamulOzellikleri> mamulOzellikleris = new List<MamulOzellikleri>();
                MamulOzellikleri1 mamulOzellikleri1 = new MamulOzellikleri1();
                List<MamulOzellikleri1> mamulOzellikleri1s = new List<MamulOzellikleri1>();

                nesne.PartiNo = txtPartiNo.Text;
                nesne.Aciklama = txtAciklama.Text;
                nesne.UretimTarihi = tarih1;

                foreach (DataGridViewRow dr in dtgMamulOzellikleri1.Rows)
                {
                    mamulOzellikleri = new MamulOzellikleri();

                    mamulOzellikleri.UretimSonrasiTelemeMiktari = dr.Cells["Üretim Sonrası Teleme Miktarı(KG)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretim Sonrası Teleme Miktarı(KG)"].Value);

                    mamulOzellikleri.BirGunSonraTelemeMiktari = dr.Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                    mamulOzellikleri.UretimRandimani = dr.Cells["Üretim Randımanı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretim Randımanı"].Value);

                    mamulOzellikleri.PersonelKodu = dr.Cells["Personel Kodu"].Value == DBNull.Value ? "" : dr.Cells["Personel Kodu"].Value.ToString();
                    mamulOzellikleri.PersonelAdi = dr.Cells["Personel Adı"].Value == DBNull.Value ? "" : dr.Cells["Personel Adı"].Value.ToString();

                    mamulOzellikleris.Add(mamulOzellikleri);
                }

                nesne.mamulOzellikleriDetay = mamulOzellikleris.ToArray();

                foreach (DataGridViewRow dr in dtgMamulOzellikleri2.Rows)
                {
                    mamulOzellikleri1 = new MamulOzellikleri1();

                    mamulOzellikleri1.KuruMadde = dr.Cells["Kuru Madde(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde(%)"].Value);
                    mamulOzellikleri1.YagOrani = dr.Cells["Yağ Oranı(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ Oranı(%)"].Value);
                    mamulOzellikleri1.PH = dr.Cells["PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH Değeri"].Value);
                    mamulOzellikleri1.SH = dr.Cells["SH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH Değeri"].Value);
                    mamulOzellikleri1.TuzOrani = dr.Cells["Tuz Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tuz Oranı"].Value);

                    mamulOzellikleri1s.Add(mamulOzellikleri1);
                }

                nesne.mamulOzellikleri1Detay = mamulOzellikleri1s.ToArray();

                var resp = client.AddOrUpdateTelemeMamulAnalizTakip(nesne, Giris.dbName, Giris.mKodValue);

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

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();
        }
    }
}
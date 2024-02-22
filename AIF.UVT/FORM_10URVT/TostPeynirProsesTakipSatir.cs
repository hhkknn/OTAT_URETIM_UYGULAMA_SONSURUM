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

namespace AIF.UVT.FORM_010OTATURVT
{
    public partial class TostPeynirProsesTakipSatir : Form
    {
        //font start.tasrım
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //font end
        public TostPeynirProsesTakipSatir(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, int _width, int _height, string _tarih1, string _urunKodu)
        {
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;
            //font end

            UretimFisNo = _UretimFisNo;
            partiNo = _PartiNo;
            UrunTanimi = _UrunTanimi;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;
            urunKodu = _urunKodu;
            txtUretimSiparisNo.Text = UretimFisNo;
            txtUrunTanimi.Text = UrunTanimi;
            txtPartyNo.Text = partiNo;

            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
            txtPaketlemeTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
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

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimTarihi.Font.Style);

            txtPaketlemeTarihi.Font = new Font(txtPaketlemeTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtPaketlemeTarihi.Font.Style);

            txtUrunSislemesiYapan.Font = new Font(txtUrunSislemesiYapan.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUrunSislemesiYapan.Font.Style);

            txtUrunSislemesiKontrolEden.Font = new Font(txtUrunSislemesiKontrolEden.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUrunSislemesiKontrolEden.Font.Style);

            txtUretimSiparisNo.Font = new Font(txtUretimSiparisNo.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              txtUretimSiparisNo.Font.Style);

            txtPartyNo.Font = new Font(txtPartyNo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtPartyNo.Font.Style);

            txtUrunTanimi.Font = new Font(txtUrunTanimi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUrunTanimi.Font.Style);

            button4.Font = new Font(button4.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button4.Font.Style);

            button5.Font = new Font(button5.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button5.Font.Style);

            btnAciklama.Font = new Font(btnAciklama.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnAciklama.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnOnayla.Font.Style);

            btnOzetEkraniDon.Font = new Font(btnOzetEkraniDon.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnOzetEkraniDon.Font.Style);
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

        private DataTable dtGramaj = new DataTable();
        private string urunKodu = "";

        private void TostPeynirProsesTakipSatir_Load(object sender, EventArgs e)
        {
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_TSTPRSS2_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
            dtgGramaj.RowTemplate.Height = 60;

            dtgSarfMalzemeKullanim();
            dtgGramajKontrol();

            //DataGridViewColumn dataGridViewColumn = dtMamulOz.Columns["Kuru Madde(%)"];
            //dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            //dataGridViewColumn = dtMamulOz.Columns["Yağ Oranı (%)"];
            //dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            //dataGridViewColumn = dtMamulOz.Columns["PH Değeri"];
            //dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            //dataGridViewColumn = dtMamulOz.Columns["SH Değeri"];
            //dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            //dataGridViewColumn = dtMamulOz.Columns["Tuz Oranı(%)"];
            //dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;
        }

        private void dtgSarfMalzemeKullanim()
        {
            string sql = "SELECT T1.\"U_MalzemeAdi\" as \"Malzeme Adı\",T1.\"U_MalMarkaTedarikci\" as \"Malzeme Marka ve Tedarikçi\",T1.\"U_SarfMalzemePartiNo\" as \"Sarf Malzemesi Parti No\",Convert(float,T1.\"U_Miktar\") as \"Miktar\",T1.\"U_Birim\" as \"Birim\" FROM \"@AIF_TSTPRSS2_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TSTPRSS2_ANLZ2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_UretimTarihi\" = '" + tarih1 + "'";

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgSarfMalzeme.DataSource = dt;

            dtgSarfMalzeme.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgSarfMalzeme.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dtgSarfMalzeme.EnableHeadersVisualStyles = false;
            dtgSarfMalzeme.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            dtgSarfMalzeme.ReadOnly = true;
            if (dt.Rows.Count == 0)
            {
                //sql = "select T0.ItemName as \"Malzeme Adı\",CardName as \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1 T0 inner join OITM T1 ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE where U_BatchNumber = '" + partiNo + "')";

                //sql = "SELECT T1.dscription as \"Malzeme Adı\" ,(select TOP 1 CardName from IBT1 where BatchNum = t3.BatchNum and Direction = '0' order by DocDate desc) as \"Malzemenin Markası ve Tedarikçisi\",t3.BatchNum as \"Sarf Malzemesi Parti No\", sum(t3.Quantity) as \"Miktar\", T4.CntUnitMsr as \"Birim\"  FROM OWOR T0 WITH (NOLOCK) ";
                //sql += "INNER JOIN IGE1 T1 WITH (NOLOCK) ON T0.DocEntry = T1.BaseEntry ";
                //sql += "INNER JOIN IBT1 T3 WITH (NOLOCK) ON T1.Docentry = T3.BaseEntry and T3.BaseLinNum = T1.LineNum ";
                //sql += "INNER JOIN OITM T4 WITH (NOLOCK) ON T1.ItemCode = T4.ItemCode ";
                //sql += "WHERE T0.[U_ISTASYON] = '"+istasyon+"' and T0.[PostDate] = '" + tarih1 + "' AND T1.BASETYPE = '202' and t3.BaseType = '60' and T4.QryGroup1 = 'Y' group by T1.dscription ,t3.BatchNum,  T4.CntUnitMsr";
                #region old
                //sql = "select T0.ItemName as \"Malzeme Adı\",CardName as \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1 T0 WITH (NOLOCK) inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo + "') and ISNULL(T1.\"QryGroup1\",'')='Y'";
                #endregion
                sql = "select T0.ItemName as \"Malzeme Adı\",ISNULL((SELECT TOP 1 TT.CardName FROM IBT1_LINK AS TT INNER JOIN OCRD T09 ON TT.CardCode = T09.CardCode WHERE TT.ItemCode = T0.ItemCode AND TT.BatchNum = T0.BatchNum ORDER BY TT.DocDate DESC ),'') AS \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1_LINK T0 WITH (NOLOCK) inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo + "') and ISNULL(T1.\"QryGroup1\",'')='Y'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                sda = new SqlDataAdapter(cmd);
                dttemp = new DataTable();
                sda.Fill(dttemp);

                foreach (DataRow dr1 in dttemp.Rows)
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dt.NewRow();
                    dr["Malzeme Adı"] = dr1["Malzeme Adı"].ToString();
                    dr["Malzeme Marka ve Tedarikçi"] = dr1["Malzemenin Markası ve Tedarikçisi"].ToString();
                    dr["Sarf Malzemesi Parti No"] = dr1["Sarf Malzemesi Parti No"].ToString();
                    dr["Miktar"] = Convert.ToDouble(dr1["Miktar"].ToString());
                    dr["Birim"] = dr1["Birim"].ToString();

                    dt.Rows.Add(dr);
                }

                //DataRow dr = dt.NewRow();
                //dr["Miktar"] = Convert.ToString("0", cultureTR);

                //dt.Rows.Add(dr);
            }

            dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            //dtgSarfMalzeme.Columns["Yağ Oranı (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgSarfMalzeme.Columns["Yağ Oranı (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            //dtgSarfMalzeme.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgSarfMalzeme.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            //dtgSarfMalzeme.Columns["SH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgSarfMalzeme.Columns["SH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            //dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgSarfMalzeme.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgSarfMalzeme.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgSarfMalzeme.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }
        private void dtgGramajKontrol()
        {
            string sql = "SELECT T1.\"U_UrunCesidi\" as \"Ürün Çeşidi\", T1.\"U_PartiNo\" as \"Parti No\", T1.\"U_BirinciOrnek\" as \"1.Örnek\", T1.\"U_IkinciOrnek\" as \"2.Örnek\", T1.\"U_UcuncuOrnek\" as \"3.Örnek\", T1.\"U_DorduncuOrnek\" as \"4.Örnek\", T1.\"U_BesinciOrnek\" as \"5.Örnek\", T1.\"U_AltinciOrnek\" as \"6.Örnek\", T1.\"U_YedinciOrnek\" as \"7.Örnek\"  FROM \"@AIF_TSTPRSS2_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TSTPRSS2_ANLZ4\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);
            dtGramaj = dt;

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtGramaj.NewRow();
                dr["Ürün Çeşidi"] = txtUrunTanimi.Text;
                dr["Parti No"] = txtPartyNo.Text;
                dr["1.Örnek"] = 0;
                dr["2.Örnek"] = 0;
                dr["3.Örnek"] = 0;
                dr["4.Örnek"] = 0;
                dr["5.Örnek"] = 0;
                dr["6.Örnek"] = 0;
                dr["7.Örnek"] = 0;

                dtGramaj.Rows.Add(dr);
            }

            //Commit
            dtgGramaj.DataSource = dt;
            dtgGramaj.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgGramaj.EnableHeadersVisualStyles = false;
            dtgGramaj.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            dtgGramaj.Columns["1.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGramaj.Columns["1.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgGramaj.Columns["2.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGramaj.Columns["2.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgGramaj.Columns["3.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGramaj.Columns["3.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgGramaj.Columns["4.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGramaj.Columns["4.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgGramaj.Columns["5.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGramaj.Columns["5.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgGramaj.Columns["6.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGramaj.Columns["6.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgGramaj.Columns["7.Örnek"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGramaj.Columns["7.Örnek"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgGramaj.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgGramaj.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;
            dtgGramaj.Columns["Ürün Çeşidi"].HeaderCell.Style.BackColor = Color.LimeGreen;
            dtgGramaj.Columns["Parti No"].HeaderCell.Style.BackColor = Color.LimeGreen;
            dtgGramaj.Columns["Ürün Çeşidi"].ReadOnly = true;
            dtgGramaj.Columns["Parti No"].ReadOnly = true;
            foreach (DataGridViewColumn column in dtgGramaj.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dtgGramaj.RowTemplate.Height = 60;

        }
        private void dtgGramaj_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgGramaj.Columns[e.ColumnIndex].Name == "1.Örnek" || dtgGramaj.Columns[e.ColumnIndex].Name == "2.Örnek" || dtgGramaj.Columns[e.ColumnIndex].Name == "3.Örnek" || dtgGramaj.Columns[e.ColumnIndex].Name == "4.Örnek" || dtgGramaj.Columns[e.ColumnIndex].Name == "5.Örnek" || dtgGramaj.Columns[e.ColumnIndex].Name == "6.Örnek" || dtgGramaj.Columns[e.ColumnIndex].Name == "7.Örnek")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgGramaj);
                    n.ShowDialog();

                    #region Süt Gönderim Saat Kontrolleri

                    //var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Süt Gönderim Başlangıç Saati"].Value.ToString();
                    //var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Süt Gönderim Bitiş Saati"].Value.ToString();

                    //if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                    //{
                    //    TimeSpan girisCikisFarki = DateTime.Parse(bitisSaati).Subtract(DateTime.Parse(baslangicSaati));
                    //    dtgProsesOzellikleri2_1.Rows[0].Cells["Süt Gönderim Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                    //}
                    //else
                    //{
                    //    dtgProsesOzellikleri2_1.Rows[0].Cells["Süt Gönderim Süresi (DK)"].Value = "0";
                    //}

                    //ProsesOzellikleri1Topla();

                    #endregion Süt Gönderim Saat Kontrolleri
                }
                #region kapatıldı 20230403
                //else if (dtgGramaj.Columns[e.ColumnIndex].Name == "Ürün Çeşidi")
                //{
                //    string sql_AnalizParam = "Select \"U_Deger1\",\"U_Deger2\" from \"@AIF_GNLKANLZPRM\" WITH (NOLOCK) where \"U_Kod\" ='3'";
                //    cmd = new SqlCommand(sql_AnalizParam, Connection.sql);

                //    if (Connection.sql.State != ConnectionState.Open)
                //        Connection.sql.Open();

                //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //    DataTable dt_Sorgu = new DataTable();
                //    sda.Fill(dt_Sorgu);

                //    //dtgSecim.DataSource = dt;
                //    //dtSecim = dt;

                //    Connection.sql.Close();

                //    if (dt_Sorgu.Rows.Count > 0)
                //    {
                //        string sql1 = "Select TOP 1 '' as \"Kalem Kodu\",'' as \"Kalem Adı\" FROM OITM WITH (NOLOCK) where \"U_ItemGroup2\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][1].ToString() + "' ";
                //        sql1 += " UNION ALL ";
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM WITH (NOLOCK) where \"U_ItemGroup2\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][1].ToString() + "'";

                //        SelectList selectList = new SelectList(sql1, dtgGramaj, -1, 0, _autoresizerow: false);
                //        selectList.ShowDialog();

                //        var sonSatir = dtgGramaj.Rows[dtgGramaj.RowCount - 1].Cells[e.ColumnIndex].Value.ToString();

                //        if (sonSatir != "")
                //        {
                //            System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                //            DataRow dr = dtGramaj.NewRow();
                //            dr["Ürün Çeşidi"] = txtUrunTanimi.Text;
                //            dr["Parti No"] = txtPartyNo.Text;
                //            dr["1.Örnek"] = 0;
                //            dr["2.Örnek"] = 0;
                //            dr["3.Örnek"] = 0;
                //            dr["4.Örnek"] = 0;
                //            dr["5.Örnek"] = 0;
                //            dr["6.Örnek"] = 0;
                //            dr["7.Örnek"] = 0;

                //            dtGramaj.Rows.Add(dr);
                //        }
                //    }
                //    else
                //    {
                //        CustomMsgBtn.Show("Ürün çeşidi için parametre tablosu doldurulmamıştır.", "UYARI", "TAMAM");
                //    }
                //} 
                #endregion
            }
            catch (Exception)
            {
            }
        }

        private void btnAciklama_Click(object sender, EventArgs e)
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                TostPeynirTakipAnaliz2 nesne = new TostPeynirTakipAnaliz2();

                TostPeynir2SarfMalzemeKullanim tostPeynir2SarfMalzemeKullanim = new TostPeynir2SarfMalzemeKullanim();
                List<TostPeynir2SarfMalzemeKullanim> tostPeynir2SarfMalzemeKullanims = new List<TostPeynir2SarfMalzemeKullanim>();

                TostPeynir2GramajKontrol tostPeynir2GramajKontrol = new TostPeynir2GramajKontrol();
                List<TostPeynir2GramajKontrol> tostPeynir2GramajKontrols = new List<TostPeynir2GramajKontrol>();

                nesne.PartiNo = txtPartyNo.Text;
                nesne.Aciklama = txtAciklama.Text;
                nesne.KalemKodu = urunKodu;
                nesne.KalemTanimi = txtUrunTanimi.Text;

                nesne.UretimTarihi = txtUretimTarihi.Text.Substring(6, 4) + txtUretimTarihi.Text.Substring(3, 2) + txtUretimTarihi.Text.Substring(0, 2);
                nesne.PaketlemeTarihi = txtPaketlemeTarihi.Text.Substring(6, 4) + txtPaketlemeTarihi.Text.Substring(3, 2) + txtPaketlemeTarihi.Text.Substring(0, 2);
                nesne.UrunSislemesiKontroEdenPersonel = txtUrunSislemesiKontrolEden.Text;
                nesne.UrunSislemesiYapanPersonel = txtUrunSislemesiYapan.Text;
                nesne.EkranTipi = "S";
                foreach (DataGridViewRow dr in dtgSarfMalzeme.Rows)
                {
                    tostPeynir2SarfMalzemeKullanim = new TostPeynir2SarfMalzemeKullanim();

                    tostPeynir2SarfMalzemeKullanim.MalzemeAdi = dr.Cells["Malzeme Adı"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Adı"].Value.ToString();
                    tostPeynir2SarfMalzemeKullanim.MalzemeMarkaTedarikcisi = dr.Cells["Malzeme Marka ve Tedarikçi"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Marka ve Tedarikçi"].Value.ToString();
                    tostPeynir2SarfMalzemeKullanim.SarfMalzemePartiNo = dr.Cells["Sarf Malzemesi Parti No"].Value == DBNull.Value ? "" : dr.Cells["Sarf Malzemesi Parti No"].Value.ToString();
                    tostPeynir2SarfMalzemeKullanim.Miktar = dr.Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Miktar"].Value);
                    tostPeynir2SarfMalzemeKullanim.Birim = dr.Cells["Birim"].Value == DBNull.Value ? "" : dr.Cells["Birim"].Value.ToString();

                    tostPeynir2SarfMalzemeKullanims.Add(tostPeynir2SarfMalzemeKullanim);
                }

                nesne.tostPeynir2SarfMalzemeKullanims = tostPeynir2SarfMalzemeKullanims.ToArray();

                foreach (DataGridViewRow dr in dtgGramaj.Rows)
                {
                    tostPeynir2GramajKontrol = new TostPeynir2GramajKontrol();

                    tostPeynir2GramajKontrol.UrunCesidi = dr.Cells["Ürün Çeşidi"].Value == DBNull.Value ? "" : dr.Cells["Ürün Çeşidi"].Value.ToString();
                    tostPeynir2GramajKontrol.PartiNo = dr.Cells["Parti No"].Value == DBNull.Value ? "" : dr.Cells["Parti No"].Value.ToString();
                    tostPeynir2GramajKontrol.BirinciOrnek = dr.Cells["1.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["1.Örnek"].Value);
                    tostPeynir2GramajKontrol.IkinciOrnek = dr.Cells["2.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["2.Örnek"].Value);
                    tostPeynir2GramajKontrol.UcuncuOrnek = dr.Cells["3.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["3.Örnek"].Value);
                    tostPeynir2GramajKontrol.DorduncuOrnek = dr.Cells["4.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["4.Örnek"].Value);
                    tostPeynir2GramajKontrol.BesinciOrnek = dr.Cells["5.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["5.Örnek"].Value);
                    tostPeynir2GramajKontrol.AltinciOrnek = dr.Cells["6.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["6.Örnek"].Value);
                    tostPeynir2GramajKontrol.YedinciOrnek = dr.Cells["7.Örnek"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["7.Örnek"].Value);

                    tostPeynir2GramajKontrols.Add(tostPeynir2GramajKontrol);
                }

                nesne.tostPeynir2GramajKontrols = tostPeynir2GramajKontrols.ToArray();

                var resp = client.AddOrUpdateTostPeynirProsesAnalizTakip2(nesne, Giris.dbName, Giris.mKodValue);


                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                if (resp.Value == 0)
                {
                    btnOzetEkraniDon.PerformClick();
                }
            }
            catch (Exception)
            {
            }
        }

        private void btnOzetEkraniDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }
    }
}

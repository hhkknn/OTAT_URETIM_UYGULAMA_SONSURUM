using AIF.UVT.DatabaseLayer;
using AIF.UVT.FORM_ORTAK;
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
    public partial class KaliteGiris : Form
    {
        //font start
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //font end
        public KaliteGiris(string _kullaniciid, int _formNo, string _tarih1, string _kaliteFormAciklama)
        {
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = txtRaporTarihi.Font.Size;
            txtRaporTarihi.Resize += Form_Resize;

            initialFontSize = btnKaliteFormu.Font.Size;
            btnKaliteFormu.Resize += Form_Resize;

            initialFontSize = dtgKaliteGiris.Font.Size;
            dtgKaliteGiris.Resize += Form_Resize;

            initialFontSize = btnOzetEkranaDon.Font.Size;
            btnOzetEkranaDon.Resize += Form_Resize;

            initialFontSize = btnOnayla.Font.Size;
            btnOnayla.Resize += Form_Resize;


            kullaniciid = _kullaniciid;
            formNo = _formNo;
            tarih1 = _tarih1;
            kaliteFormAciklama = _kaliteFormAciklama;

            txtRaporTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
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

            txtRaporTarihi.Font = new Font(txtRaporTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtRaporTarihi.Font.Style);

            btnKaliteFormu.Font = new Font(btnKaliteFormu.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnKaliteFormu.Font.Style);

            dtgKaliteGiris.Font = new Font(dtgKaliteGiris.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               dtgKaliteGiris.Font.Style);

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnOnayla.Font.Style);

            //dtpRaporTarihi.FontStyle("", 14, FontStyle.Bold);
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

        private SqlCommand cmd = null;
        private string kullaniciid = "";
        private int formNo = 0;
        private static string tarih1 = "";
        private string kaliteFormAciklama = "";

        private void KaliteGiris_Load(object sender, EventArgs e)
        {
            #region MKOD İle Background Değişimi

            var lastOpenedForm = Application.OpenForms.Cast<Form>().Last();

            if (Giris.mKodValue == "010OTATURVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.OTAT_UVT_ArkaPlanV3;
            }
            else if (Giris.mKodValue == "20URVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.YORUK_UVT_ArkaPlanv2;
            }

            #endregion MKOD İle Background Değişimi

            btnKaliteFormu.Text = kaliteFormAciklama;
            string sql = "";

            #region kalite sonuç
            sql = "Select T1.\"U_IstKodu\" AS \"İstasyon Kodu\",T1.\"U_IstAdi\" AS \"İstasyon\", T1.\"U_Aciklama\"  AS \"Açıklama\", T1.\"U_Aciklama2\" AS \"Açıklama 2\",T1.\"U_KalPerAcik\" as \"Kalite Personel Açıklama Girişi\",T1.\"U_Tur\" as \"Tür\",T1.\"U_UygnUygnDgl\" as \"Uygun / Uygun Değil\",T1.\"U_Deger1\" as \"Değer 1\",T1.\"U_Deger2\" as \"Değer 2\" ,T1.\"U_Deger3\" as \"Değer 3\" ,T1.\"U_Deger4\" as \"Değer 4\" ,T1.\"U_Deger5\" as \"Değer 5\" ,T1.\"U_Deger6\" as \"Değer 6\" ,T1.\"U_Deger7\" as \"Değer 7\" ,T1.\"U_Deger8\" as \"Değer 8\" ,T1.\"U_Deger9\" as \"Değer 9\" ,T1.\"U_Deger10\" as \"Değer 10\" ,T1.\"U_Deger11\" as \"Değer 11\" ,T1.\"U_Deger12\" as \"Değer 12\" ,T1.\"U_Deger13\" as \"Değer 13\" ,T1.\"U_Deger14\" as \"Değer 14\" ,T1.\"U_Deger15\" as \"Değer 15\" ,T1.\"U_Deger16\" as \"Değer 16\" ,T1.\"U_Deger17\" as \"Değer 17\" ,T1.\"U_Deger18\" as \"Değer 18\" ,T1.\"U_Deger19\" as \"Değer 19\" ,T1.\"U_Deger20\" as \"Değer 20\",T1.\"U_SaatAraligi\" as \"Saat Aralığı\"  from \"@AIF_KALITESONUC\" T0 WITH (NOLOCK) INNER JOIN \"@AIF_KALITESONUC1\" T1 WITH (NOLOCK) ON T0.\"DocEntry\"= T1.\"DocEntry\"  WHERE T0.\"U_RaporTarihi\" = '" + tarih1 + "' and T0.\"U_FormBelgeNo\" = '" + formNo + "' ";
            #endregion

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            if (dt.Rows.Count == 0)
            {
                #region kalite detay
                sql = "Select T1.\"U_IstKodu\" AS \"İstasyon Kodu\",T1.\"U_IstAdi\" AS \"İstasyon\", T1.\"U_Aciklama\" AS \"Açıklama\",T1.\"U_Aciklama2\" AS \"Açıklama 2\",T1.\"U_KalPerAcik\" as \"Kalite Personel Açıklama Girişi\",T1.\"U_Tur\" as \"Tür\",Cast('' as varchar(20)) as \"Uygun / Uygun Değil\",T1.\"U_Deger1\" as \"Değer 1\",T1.\"U_Deger2\" as \"Değer 2\" ,T1.\"U_Deger3\" as \"Değer 3\" ,T1.\"U_Deger4\" as \"Değer 4\" ,T1.\"U_Deger5\" as \"Değer 5\" ,T1.\"U_Deger6\" as \"Değer 6\" ,T1.\"U_Deger7\" as \"Değer 7\" ,T1.\"U_Deger8\" as \"Değer 8\" ,T1.\"U_Deger9\" as \"Değer 9\" ,T1.\"U_Deger10\" as \"Değer 10\" ,T1.\"U_Deger11\" as \"Değer 11\" ,T1.\"U_Deger12\" as \"Değer 12\" ,T1.\"U_Deger13\" as \"Değer 13\" ,T1.\"U_Deger14\" as \"Değer 14\" ,T1.\"U_Deger15\" as \"Değer 15\" ,T1.\"U_Deger16\" as \"Değer 16\" ,T1.\"U_Deger17\" as \"Değer 17\" ,T1.\"U_Deger18\" as \"Değer 18\" ,T1.\"U_Deger19\" as \"Değer 19\" ,T1.\"U_Deger20\" as \"Değer 20\",T1.\"U_SaatAraligi\" as \"Saat Aralığı\"  from \"@AIF_KALITEDETAY\" T0 WITH (NOLOCK) INNER JOIN \"@AIF_KALITEDETAY1\" T1 WITH (NOLOCK) ON T0.\"DocEntry\"= T1.\"DocEntry\"  WHERE T0.\"U_FormAckl\" = N'" + kaliteFormAciklama + "' ";
                #endregion 
            }
            #region old
            //string sql = "Select \"U_Aciklama\" AS \"Açıklama\",\"U_Tur\" as \"Tür\",Cast('' as varchar(20)) as \"Uygun / Uygun Değil\",\"U_Deger1\" as \"Değer 1\",\"U_Deger2\" as \"Değer 2\" ,\"U_Deger3\" as \"Değer 3\" ,\"U_Deger4\" as \"Değer 4\" ,\"U_Deger5\" as \"Değer 5\" ,\"U_Deger6\" as \"Değer 6\" ,\"U_Deger7\" as \"Değer 7\" ,\"U_Deger8\" as \"Değer 8\" ,\"U_Deger9\" as \"Değer 9\" ,\"U_Deger10\" as \"Değer 10\" ,\"U_Deger11\" as \"Değer 11\" ,\"U_Deger12\" as \"Değer 12\" ,\"U_Deger13\" as \"Değer 13\" ,\"U_Deger14\" as \"Değer 14\" ,\"U_Deger15\" as \"Değer 15\" ,\"U_Deger16\" as \"Değer 16\" ,\"U_Deger17\" as \"Değer 17\" ,\"U_Deger18\" as \"Değer 18\" ,\"U_Deger19\" as \"Değer 19\" ,\"U_Deger20\" as \"Değer 20\",\"U_SaatAraligi\" as \"Saat Aralığı\"  from \"@AIF_KALITEDETAY\" "; 
            #endregion
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgKaliteGiris.DataSource = dt;

            dtgKaliteGiris.Columns["Açıklama"].ReadOnly = true;
            dtgKaliteGiris.Columns["Açıklama 2"].ReadOnly = true;
            dtgKaliteGiris.Columns["Tür"].ReadOnly = true;
            dtgKaliteGiris.Columns["Tür"].Visible = false;

            dtgKaliteGiris.Columns["İstasyon Kodu"].Visible = false;
            dtgKaliteGiris.Columns["Saat Aralığı"].Visible = false;

            dtgKaliteGiris.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgKaliteGiris.ColumnHeadersDefaultCellStyle.BackColor = Color.Bisque;
            dtgKaliteGiris.EnableHeadersVisualStyles = false;
            //dtgKaliteGiris.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            //foreach (DataGridViewColumn col in dtgPaketlemeBilgileri1.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            //}
            //        var row = dtgKaliteGiris.Rows.Cast<DataGridViewRow>()
            //.Where(x => ((DataRowView)x.DataBoundItem).Row.Field<dynamic>("Değer 9") == null)
            //.FirstOrDefault();
            //        if (row != null)
            //            row.Selected = true;

            //        var item2 = dt.AsEnumerable().Where(x => x.Field<dynamic>("Değer 9") == null).FirstOrDefault();
            //        if (item2 != null)
            //        {
            //            var row2 = dtgKaliteGiris.Rows.Cast<DataGridViewRow>()
            //                .Where(x => ((DataRowView)x.DataBoundItem).Row == item2).FirstOrDefault();
            //            if (row2 != null)
            //                row2.Selected = true;
            //}
            //List<DataGridViewRow> rows2 = new List<DataGridViewRow> (
            //    from DataGridViewRow r in dtgKaliteGiris.Rows 
            //    where r.Cells["Değer 9"].Value.ToString() == "17" 
            //    select r);
            dtgKaliteGiris.Columns["İstasyon"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgKaliteGiris.Columns["Uygun / Uygun Değil"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgKaliteGiris.Columns["Açıklama"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgKaliteGiris.Columns["Açıklama 2"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtgKaliteGiris.Columns["Kalite Personel Açıklama Girişi"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dtgKaliteGiris.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            for (int i = 0; i <= dtgKaliteGiris.RowCount - 1; i++)
            {
                //dtgKaliteGiris.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

                //if (i > 4)
                //{
                //    dtgKaliteGiris.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
                //}

                dtgKaliteGiris.Rows[i].Height = 65;

                if (i % 2 == 0)
                    dtgKaliteGiris.Rows[i].DefaultCellStyle.BackColor = Color.White;
                else
                    dtgKaliteGiris.Rows[i].DefaultCellStyle.BackColor = Color.WhiteSmoke;

                dtgKaliteGiris.Rows[i].DefaultCellStyle.ForeColor = Color.Black;


                if ((dtgKaliteGiris.Rows[i].Cells["Tür"].Value != DBNull.Value && dtgKaliteGiris.Rows[i].Cells["Tür"].Value != null))
                {
                    if (dtgKaliteGiris.Rows[i].Cells["Tür"].Value.ToString() == "2")
                    {
                        dtgKaliteGiris.Rows[i].Cells["Uygun / Uygun Değil"].ReadOnly = true;

                        if ((dtgKaliteGiris.Rows[i].Cells["Tür"].Value != DBNull.Value && dtgKaliteGiris.Rows[i].Cells["Saat Aralığı"].Value != ""))
                        {
                            var data = dtgKaliteGiris.Rows[i].Cells["Saat Aralığı"].Value.ToString();

                            var f = data.Split('-');

                            int yazma = 7;
                            int baslangic = Convert.ToInt32(f[0]);
                            int bitis = Convert.ToInt32(f[1]);

                            while (baslangic <= bitis)
                            {
                                if (baslangic.ToString().Length == 1)
                                {
                                    //if (dtgKaliteGiris.Rows[i].Cells[yazma].Value.ToString().Contains("OK"))
                                    //{
                                    //    dtgKaliteGiris.Rows[i].Cells[yazma].Value = "0" + baslangic.ToString() + ":" + "00" + " - OK";

                                    //}

                                    if (dtgKaliteGiris.Rows[i].Cells[yazma].Value.ToString() == "")
                                    {
                                        dtgKaliteGiris.Rows[i].Cells[yazma].Value = "0" + baslangic.ToString() + ":" + "00";
                                    }
                                    //else if (dtgKaliteGiris.Rows[i].Cells[yazma].Value.ToString().Contains("OK"))
                                    //{
                                    //    dtgKaliteGiris.Rows[i].Cells[yazma].Value = "0" + baslangic.ToString() + ":" + "00" + " - OK";

                                    //}

                                    if (dtgKaliteGiris.Rows[i].Cells[yazma].Value.ToString() == "")
                                    {
                                        dtgKaliteGiris.Rows[i].Cells[yazma].Value = baslangic.ToString() + ":" + "00";
                                    }
                                    //else if (dtgKaliteGiris.Rows[i].Cells[yazma].Value.ToString().Contains("NO"))
                                    //{
                                    //    dtgKaliteGiris.Rows[i].Cells[yazma].Value = baslangic.ToString() + ":" + "00" + " - NO"; 
                                    //}
                                }
                                else if (baslangic.ToString().Length == 2)
                                {
                                    if (dtgKaliteGiris.Rows[i].Cells[yazma].Value.ToString() == "")
                                    {
                                        dtgKaliteGiris.Rows[i].Cells[yazma].Value = baslangic.ToString() + ":" + "00";
                                    }
                                    //else if (dtgKaliteGiris.Rows[i].Cells[yazma].Value.ToString().Contains("OK"))
                                    //{
                                    //    dtgKaliteGiris.Rows[i].Cells[yazma].Value = baslangic.ToString() + ":" + "00" + " - OK";
                                    //}

                                    if (dtgKaliteGiris.Rows[i].Cells[yazma].Value.ToString() == "")
                                    {
                                        dtgKaliteGiris.Rows[i].Cells[yazma].Value = baslangic.ToString() + ":" + "00";

                                    }
                                    //else if (dtgKaliteGiris.Rows[i].Cells[yazma].Value.ToString().Contains("NO"))
                                    //{
                                    //    dtgKaliteGiris.Rows[i].Cells[yazma].Value = baslangic.ToString() + ":" + "00" + " - NO";
                                    //}
                                }
                                baslangic++;
                                yazma++;
                            }

                            if (yazma < dtgKaliteGiris.Columns.Count)
                            {
                                for (int x = yazma; x <= dtgKaliteGiris.Columns.Count - 1; x++)
                                {
                                    //dtgKaliteGiris.Rows[i].Cells[x].ReadOnly = true;
                                }
                            }

                            //for (int x = baslangic; x <= bitis; x++)
                            //{

                            //    //dtgKaliteGiris.Rows[i].Cells[x].ReadOnly = true;
                            //}

                            //for (int x = 4; x <= 20; x++)
                            //{
                            //    dtgKaliteGiris.Rows[i].Cells[x].ReadOnly = true;
                            //} 
                        }
                    }
                    else if (dtgKaliteGiris.Rows[i].Cells["Tür"].Value.ToString() == "1")
                    {
                        dtgKaliteGiris.Rows[i].Cells["Uygun / Uygun Değil"].ReadOnly = false;
                        for (int x = 3; x <= dtgKaliteGiris.Columns.Count - 1; x++)
                        {
                            //dtgKaliteGiris.Rows[i].Cells[x].ReadOnly = true;
                        }

                    }
                    else if (dtgKaliteGiris.Rows[i].Cells["Tür"].Value.ToString() == "3")
                    {
                        dtgKaliteGiris.Rows[i].Cells["Uygun / Uygun Değil"].ReadOnly = false;
                    }

                }
            }


            if (dtgKaliteGiris.Rows.Count > 0)
            {
                dtgKaliteGiris.Columns["İstasyon"].ReadOnly = true;
                dtgKaliteGiris.Columns["Uygun / Uygun Değil"].ReadOnly = true;
                dtgKaliteGiris.Columns["Açıklama"].ReadOnly = true;
                dtgKaliteGiris.Columns["Açıklama 2"].ReadOnly = true;
                dtgKaliteGiris.Columns["Kalite Personel Açıklama Girişi"].ReadOnly = false;
            }


            foreach (DataGridViewColumn column in dtgKaliteGiris.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            AtanmisIsler atanmisIsler = new AtanmisIsler("", null, kullaniciid, Width, Height);
            atanmisIsler.Show();
            Close();
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            #region kalite 10 numaralı şirket kullandığından ,20 numaralı şirkette bu alan kapatılır.
            UVTServiceSoapClient client = new UVTServiceSoapClient();
            KaliteListesi nesne = new KaliteListesi();

            KaliteListesiDetay kaliteListesiDetay = new KaliteListesiDetay();
            List<KaliteListesiDetay> kaliteListesiDetays = new List<KaliteListesiDetay>();

            nesne.FormAciklamasi = kaliteFormAciklama;

            DateTime raportarihi = DateTime.ParseExact(txtRaporTarihi.Text, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
            nesne.RaporTarihi = raportarihi.ToString("yyyyMMdd");
            nesne.DetayFormBelgeNo = formNo;
            foreach (DataGridViewRow dr in dtgKaliteGiris.Rows)
            {
                kaliteListesiDetay = new KaliteListesiDetay();
                kaliteListesiDetay.IstasyonKodu = dr.Cells["İstasyon Kodu"].Value == DBNull.Value ? "" : dr.Cells["İstasyon Kodu"].Value.ToString();
                kaliteListesiDetay.IstasyonAdi = dr.Cells["İstasyon"].Value == DBNull.Value ? "" : dr.Cells["İstasyon"].Value.ToString();

                if (kaliteListesiDetay.IstasyonKodu == "")
                {
                    continue;
                }

                kaliteListesiDetay.Aciklama = dr.Cells["Açıklama"].Value == DBNull.Value ? "" : dr.Cells["Açıklama"].Value.ToString();
                kaliteListesiDetay.Aciklama2 = dr.Cells["Açıklama 2"].Value == DBNull.Value ? "" : dr.Cells["Açıklama 2"].Value.ToString();
                kaliteListesiDetay.Tur = dr.Cells["Tür"].Value == DBNull.Value ? "" : dr.Cells["Tür"].Value.ToString();
                kaliteListesiDetay.UygunUygunDegil = dr.Cells["Uygun / Uygun Değil"].Value == DBNull.Value ? "" : dr.Cells["Uygun / Uygun Değil"].Value.ToString();

                kaliteListesiDetay.Deger1 = dr.Cells["Değer 1"].Value == DBNull.Value ? "" : dr.Cells["Değer 1"].Value.ToString();
                kaliteListesiDetay.Deger2 = dr.Cells["Değer 2"].Value == DBNull.Value ? "" : dr.Cells["Değer 2"].Value.ToString();
                kaliteListesiDetay.Deger3 = dr.Cells["Değer 3"].Value == DBNull.Value ? "" : dr.Cells["Değer 3"].Value.ToString();
                kaliteListesiDetay.Deger4 = dr.Cells["Değer 4"].Value == DBNull.Value ? "" : dr.Cells["Değer 4"].Value.ToString();
                kaliteListesiDetay.Deger5 = dr.Cells["Değer 5"].Value == DBNull.Value ? "" : dr.Cells["Değer 5"].Value.ToString();
                kaliteListesiDetay.Deger6 = dr.Cells["Değer 6"].Value == DBNull.Value ? "" : dr.Cells["Değer 6"].Value.ToString();
                kaliteListesiDetay.Deger7 = dr.Cells["Değer 7"].Value == DBNull.Value ? "" : dr.Cells["Değer 7"].Value.ToString();
                kaliteListesiDetay.Deger8 = dr.Cells["Değer 8"].Value == DBNull.Value ? "" : dr.Cells["Değer 8"].Value.ToString();
                kaliteListesiDetay.Deger9 = dr.Cells["Değer 9"].Value == DBNull.Value ? "" : dr.Cells["Değer 9"].Value.ToString();
                kaliteListesiDetay.Deger10 = dr.Cells["Değer 10"].Value == DBNull.Value ? "" : dr.Cells["Değer 10"].Value.ToString();
                kaliteListesiDetay.Deger11 = dr.Cells["Değer 11"].Value == DBNull.Value ? "" : dr.Cells["Değer 11"].Value.ToString();
                kaliteListesiDetay.Deger12 = dr.Cells["Değer 12"].Value == DBNull.Value ? "" : dr.Cells["Değer 12"].Value.ToString();
                kaliteListesiDetay.Deger13 = dr.Cells["Değer 13"].Value == DBNull.Value ? "" : dr.Cells["Değer 13"].Value.ToString();
                kaliteListesiDetay.Deger14 = dr.Cells["Değer 14"].Value == DBNull.Value ? "" : dr.Cells["Değer 14"].Value.ToString();
                kaliteListesiDetay.Deger15 = dr.Cells["Değer 15"].Value == DBNull.Value ? "" : dr.Cells["Değer 15"].Value.ToString();
                kaliteListesiDetay.Deger16 = dr.Cells["Değer 16"].Value == DBNull.Value ? "" : dr.Cells["Değer 16"].Value.ToString();
                kaliteListesiDetay.Deger17 = dr.Cells["Değer 17"].Value == DBNull.Value ? "" : dr.Cells["Değer 17"].Value.ToString();
                kaliteListesiDetay.Deger18 = dr.Cells["Değer 18"].Value == DBNull.Value ? "" : dr.Cells["Değer 18"].Value.ToString();
                kaliteListesiDetay.Deger19 = dr.Cells["Değer 19"].Value == DBNull.Value ? "" : dr.Cells["Değer 19"].Value.ToString();
                kaliteListesiDetay.Deger20 = dr.Cells["Değer 20"].Value == DBNull.Value ? "" : dr.Cells["Değer 20"].Value.ToString();

                kaliteListesiDetay.SaatAraligi = dr.Cells["Saat Aralığı"].Value == DBNull.Value ? "" : dr.Cells["Saat Aralığı"].Value.ToString();
                kaliteListesiDetay.KalitePersonelAciklama = dr.Cells["Kalite Personel Açıklama Girişi"].Value == DBNull.Value ? "" : dr.Cells["Kalite Personel Açıklama Girişi"].Value.ToString();

                kaliteListesiDetays.Add(kaliteListesiDetay);
            }

            nesne.kaliteListesiDetays = kaliteListesiDetays.ToArray();

            var resp = client.addOrUpdateKaliteSonuc(nesne, Giris.dbName, Giris.mKodValue);

            CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

            if (resp.Value == 0)
            {
                btnOzetEkranaDon.PerformClick();
            }
            #endregion
        }

        private void dtgKaliteGiris_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgKaliteGiris.Columns[e.ColumnIndex].Name == "Uygun / Uygun Değil")
            {
                if (e.RowIndex != -1)
                {
                    if (dtgKaliteGiris.Rows[e.RowIndex].Cells["Tür"].Value.ToString() == "1") //genel
                    {
                        string sql1 = "Select '0' as \"Kod\",'Uygun Değil' as \"Aciklama\" ";
                        sql1 += " UNION ALL ";
                        sql1 += "Select '1' as \"Kod\",'Uygun' as \"Aciklama\" ";

                        SelectList selectList = new SelectList(sql1, dtgKaliteGiris, -1, e.ColumnIndex, _autoresizerow: false);
                        selectList.ShowDialog();
                    }
                }
            }
            else if (dtgKaliteGiris.Columns[e.ColumnIndex].Name.Contains("Değer"))
            {
                try
                {
                    if (e.RowIndex != -1)
                    {
                        if (dtgKaliteGiris.Rows[e.RowIndex].Cells["Tür"].Value.ToString() == "3" || dtgKaliteGiris.Rows[e.RowIndex].Cells["Tür"].Value.ToString() == "2") //parti
                        {
                            //dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace(" - OK","") + " - OK";

                            if (dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != DBNull.Value)
                            {
                                string sql1 = "Select '0' as \"Kod\", '" + dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace(" - OK", "").Replace(" - NO", "") + " - OK' as \"Aciklama\" ";
                                sql1 += " UNION ALL ";
                                sql1 += "Select '1' as \"Kod\",'" + dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Replace(" - OK", "").Replace(" - NO", "") + " - NO' as \"Aciklama\" ";

                                //SelectList selectList = new SelectList(sql1, dtgKaliteGiris, -1, e.ColumnIndex, _autoresizerow: false);
                                //selectList.ShowDialog(); 

                                txtAciklama.Text = "";

                                string ilkdeger = dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                                if (ilkdeger.Contains("-"))
                                {
                                    var val = ilkdeger.Split('-');
                                    ilkdeger = val[0].ToString();
                                }


                                AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text.ToString(), initialWidth, initialHeight);
                                aciklama.ShowDialog();

                                if (txtAciklama.Text != "")
                                {
                                    dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ilkdeger + "- (" + txtAciklama.Text + ")";
                                }
                                else
                                {
                                    dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ilkdeger;
                                }
                                //if (dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains(")"))
                                //{
                                //    dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = txtAciklama.Text;
                                //}
                                //else
                                //{
                                //    dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = txtAciklama.Text + " )";

                                //}

                                //if (dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("OK"))
                                //{
                                //    dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.LightGreen;

                                //}
                                //if (dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString().Contains("NO"))
                                //{
                                //    dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.Tomato;

                                //}

                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            else if (dtgKaliteGiris.Columns[e.ColumnIndex].Name == "Kalite Personel Açıklama Girişi")
            {
                if (e.RowIndex != -1)
                {
                    dtgKaliteGiris.Rows[e.RowIndex].Cells[e.ColumnIndex].ReadOnly = false;
                }
            }
        }
    }
}

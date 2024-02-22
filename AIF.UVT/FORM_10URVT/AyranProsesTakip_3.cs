using AIF.UVT.DatabaseLayer;
using AIF.UVT.UVTService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class AyranProsesTakip_3 : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end

        public AyranProsesTakip_3(string _type, string _kullaniciid, string _UretimFisNo, string _istasyon, int _row, string _tarih1)
        {
            InitializeComponent();
            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = txtTarih.Font.Size;
            txtTarih.Resize += Form_Resize;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = btnOzetEkranaDon.Font.Size;
            btnOzetEkranaDon.Resize += Form_Resize;

            initialFontSize = btnOnayla.Font.Size;
            btnOnayla.Resize += Form_Resize;

            initialFontSize = btnAciklama.Font.Size;
            btnAciklama.Resize += Form_Resize;

            //font end

            UretimFisNo = _UretimFisNo;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;

            txtTarih.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
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

            txtTarih.Font = new Font(txtTarih.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtTarih.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button1.Font.Style);

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnOnayla.Font.Style);

            btnAciklama.Font = new Font(btnAciklama.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnAciklama.Font.Style);

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
        private List<int> BoyanacakSatirlar = new List<int>();

        private void AyranProsesTakip_3_Load(object sender, EventArgs e)
        {
            sabitDegerler.Add("Kontrol Eden Personel Adı");
            sabitDegerler.Add("Kontrol Saati");
            sabitDegerler.Add("Ayran Transfer Eden Pompanın Basıncı(Bar)");
            sabitDegerler.Add("Kontrol Edilen Palet No");
            sabitDegerler.Add("Kontrol Edilen Ürün Adı");
            sabitDegerler.Add("Ayranın Sıcaklığı");
            sabitDegerler.Add("Ayran Viskozite(Saniye)");
            sabitDegerler.Add("PH Değeri");
            sabitDegerler.Add("Tat,Koku ve Kıvamı");
            sabitDegerler.Add("Bosluk1");
            BoyanacakSatirlar.Add(8);
            sabitDegerler.Add("Doldurulan Ürün Adı");
            sabitDegerler.Add("Kontrol Saati");
            sabitDegerler.Add("Dolması Gereken Ürün Miktarı (G)");
            sabitDegerler.Add("Dolumdaki Gramaj Sapma Oranı(%) Eksik");
            sabitDegerler.Add("Dolumdaki Gramaj Sapma Oranı(%) Fazla");
            sabitDegerler.Add("Makine Başlık No");
            sabitDegerler.Add("1");
            sabitDegerler.Add("2");
            sabitDegerler.Add("3");
            sabitDegerler.Add("4");
            sabitDegerler.Add("5");
            sabitDegerler.Add("6");
            sabitDegerler.Add("7");
            sabitDegerler.Add("8");
            sabitDegerler.Add("9");
            sabitDegerler.Add("10");
            sabitDegerler.Add("11");
            sabitDegerler.Add("12");
            sabitDegerler.Add("Bosluk2");
            BoyanacakSatirlar.Add(26);
            sabitDegerler.Add("Doldurulan Ürün Adı");
            sabitDegerler.Add("Kontrol Saati");
            sabitDegerler.Add("Dolması Gereken Ürün Miktarı (G)");
            sabitDegerler.Add("Dolumdaki Gramaj Sapma Oranı(%) Eksik");
            sabitDegerler.Add("Dolumdaki Gramaj Sapma Oranı(%) Fazla");
            sabitDegerler.Add("Makine Başlık No");
            sabitDegerler.Add("1");
            sabitDegerler.Add("2");
            sabitDegerler.Add("3");
            sabitDegerler.Add("4");
            sabitDegerler.Add("5");
            sabitDegerler.Add("6");

            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_AYRNPKTPRSS\" AS T0 WITH (NOLOCK) where T0.\"U_Tarih\" = '" + tarih1 + "'";
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

            dtgPaketlenenAyranProsesOzellikleriLoad();
        }

        private string urunCap = "";
        private SqlCommand cmd = null;
        private DataTable tempDt = new DataTable();
        private DataTable dt = new DataTable();

        private void dtgPaketlenenAyranProsesOzellikleriLoad()
        {
            string sql = "SELECT T1.\"U_KontrolNo\" as \"Kontrol No\",\"U_1\" as \"1\",\"U_2\" as \"2\",\"U_3\" as \"3\",\"U_4\" as \"4\",\"U_5\" as \"5\",\"U_6\" as \"6\",\"U_7\" as \"7\",\"U_8\" as \"8\",\"U_9\" as \"9\",\"U_10\" as \"10\",\"U_11\" as \"11\",\"U_12\" as \"12\",\"U_13\" as \"13\",\"U_14\" as \"14\",\"U_15\" as \"15\",\"U_16\" as \"16\" FROM \"@AIF_AYRNPKTPRSS\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRNPKTPRSS1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Tarih\" = '" + tarih1 + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dttemp = new DataTable();
            dt = new DataTable();
            sda.Fill(dt);

            #region Daha Önce Güne Ait data girilmiş ise datatable üzerine renklenecek olan 2 satır eklenir.

            int i = 0;
            if (dt.Rows.Count > 0)
            {
                tempDt = dt.Copy();
                tempDt.Clear();
                foreach (DataRow item in dt.Rows)
                {
                    if (i == 9)
                    {
                        DataRow dr = tempDt.NewRow();
                        dr["Kontrol No"] = "Bosluk1";

                        tempDt.Rows.Add(dr);
                    }
                    else if (i == 27)
                    {
                        DataRow dr = tempDt.NewRow();
                        dr["Kontrol No"] = "Bosluk2";

                        tempDt.Rows.Add(dr);
                    }
                    tempDt.Rows.Add(item.ItemArray);
                    i++;
                }

                dt.Clear();
                dt = tempDt;
            }

            #endregion Daha Önce Güne Ait data girilmiş ise datatable üzerine renklenecek olan 2 satır eklenir.

            dtgPaketlenenAyranProsesOzellikleri.DataSource = dt;

            dtgPaketlenenAyranProsesOzellikleri.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgPaketlenenAyranProsesOzellikleri.EnableHeadersVisualStyles = false;
            dtgPaketlenenAyranProsesOzellikleri.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            foreach (DataGridViewColumn col in dtgPaketlenenAyranProsesOzellikleri.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                foreach (var item in sabitDegerler)
                {
                    DataRow dr = dt.NewRow();
                    dr["Kontrol No"] = item;

                    dt.Rows.Add(dr);
                }
            }

            foreach (DataGridViewColumn column in dtgPaketlenenAyranProsesOzellikleri.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgPaketlenenAyranProsesOzellikleri.Columns["Kontrol No"].Width = dtgPaketlenenAyranProsesOzellikleri.Columns["Kontrol No"].Width + 120;
            dtgPaketlenenAyranProsesOzellikleri.Columns["Kontrol No"].DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgPaketlenenAyranProsesOzellikleri.Columns[0].DefaultCellStyle.BackColor = Color.IndianRed;

            dtgPaketlenenAyranProsesOzellikleri.Rows[15].DefaultCellStyle.BackColor = Color.IndianRed;
            dtgPaketlenenAyranProsesOzellikleri.Rows[34].DefaultCellStyle.BackColor = Color.IndianRed;
        }

        private List<string> sabitDegerler = new List<string>();

        private void dtgPaketlenenAyranProsesOzellikleri_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {
                return;
            }
            var value = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells["Kontrol No"].Value.ToString();
            if (value == "Bosluk1" || value == "Bosluk2")
            {
                e.PaintBackground(e.ClipBounds, true);

                Rectangle r = e.CellBounds;

                Rectangle r1 = this.dtgPaketlenenAyranProsesOzellikleri.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                r.Width += r1.Width - 70;

                r.Height -= 1;

                using (SolidBrush brBk = new SolidBrush(e.CellStyle.BackColor))

                using (SolidBrush brFr = new SolidBrush(e.CellStyle.ForeColor))

                {
                    SolidBrush s1 = new SolidBrush(Color.Orange);
                    e.Graphics.FillRectangle(s1, r);

                    StringFormat sf = new StringFormat();

                    sf.Alignment = StringAlignment.Center;

                    sf.LineAlignment = StringAlignment.Center;
                    FontFamily fontFamily = new FontFamily("Microsoft Sans Serif");
                    Font font = new Font(
                       fontFamily,
                       11,
                       FontStyle.Bold,
                       GraphicsUnit.Pixel);

                    if (e.ColumnIndex == 5)
                    {
                        SolidBrush s = new SolidBrush(Color.White);

                        string tur = value == "Bosluk1" ? "75 ÇAP" : "95 ÇAP";

                        e.Graphics.DrawString(tur, font, s, r, sf);
                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height;
                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].ReadOnly = true;
                    }
                    else if (e.ColumnIndex == 6)
                    {
                        SolidBrush s = new SolidBrush(Color.White);

                        string tur = "MAKİNEDE";

                        e.Graphics.DrawString(tur, font, s, r, sf);

                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height;
                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].ReadOnly = true;
                    }
                    else if (e.ColumnIndex == 7)
                    {
                        SolidBrush s = new SolidBrush(Color.White);
                        string tur = "DOLDURULAN";

                        e.Graphics.DrawString(tur, font, s, r, sf);

                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height;
                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].ReadOnly = true;
                    }
                    else if (e.ColumnIndex == 8)
                    {
                        SolidBrush s = new SolidBrush(Color.White);
                        string tur = "ÜRÜNÜN";

                        e.Graphics.DrawString(tur, font, s, r, sf);

                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height;
                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].ReadOnly = true;
                    }
                    else if (e.ColumnIndex == 9)
                    {
                        SolidBrush s = new SolidBrush(Color.White);
                        string tur = "GRAMAJ";

                        e.Graphics.DrawString(tur, font, s, r, sf);

                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height;
                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].ReadOnly = true;
                    }
                    else if (e.ColumnIndex == 10)
                    {
                        SolidBrush s = new SolidBrush(Color.White);
                        string tur = "TARTIM";

                        e.Graphics.DrawString(tur, font, s, r, sf);

                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height;
                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].ReadOnly = true;
                    }
                    else if (e.ColumnIndex == 11)
                    {
                        SolidBrush s = new SolidBrush(Color.White);
                        string tur = "SONUÇLARI";

                        e.Graphics.DrawString(tur, font, s, r, sf);

                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Height;
                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].ReadOnly = true;
                    }

                    e.Handled = true;
                }
            }
        }

        private bool alanlariKontrolEt(string cap, int rowIndex)
        {
            if (cap == "75")
            {
                if (rowIndex >= 10)
                {
                    if (rowIndex > 27)
                    {
                        CustomMsgBtn.Show("Ürün 75 ÇAP olduğu için 95 ÇAP Girişi yapılamaz.", "UYARI", "TAMAM");
                        return false;
                    }
                }
            }
            else if (cap == "95")
            {
                if (rowIndex >= 10)
                {
                    if (rowIndex <= 29)
                    {
                        CustomMsgBtn.Show("Ürün 95 ÇAP olduğu için 75 ÇAP Girişi yapılamaz.", "UYARI", "TAMAM");
                        return false;
                    }
                }
            }
            else if (cap == "")
            {
                if (rowIndex >= 10)
                {
                    CustomMsgBtn.Show("Ürün seçimi yapılmadan alan doldurulamaz.", "UYARI", "TAMAM");
                    return false;
                }
            }
            return true;
        }

        public static string kalemKodu = "";

        private void dtgPaketlenenAyranProsesOzellikleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                if (e.ColumnIndex == 0)
                {
                    return;
                }

                var itemCode2 = dtgPaketlenenAyranProsesOzellikleri.Rows[4].Cells[e.ColumnIndex].Value;

                if (itemCode2.ToString() != "")
                {
                    int parantezBaslangic = itemCode2.ToString().IndexOf("(");
                    int parantezBitis = itemCode2.ToString().IndexOf(")");
                    int kesilecekMiktar = parantezBitis - parantezBaslangic;
                    string kalemKodu = itemCode2.ToString().Substring(parantezBaslangic + 1, kesilecekMiktar - 1);

                    string sql = "Select \"U_UrnCap\",\"ItemName\",\"IWeight1\" FROM OITM WITH (NOLOCK) where \"ItemCode\" = '" + kalemKodu + "'";
                    cmd = new SqlCommand(sql, Connection.sql);

                    if (Connection.sql.State != ConnectionState.Open)
                        Connection.sql.Open();

                    SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                    DataTable dt_Sorgu1 = new DataTable();
                    sda1.Fill(dt_Sorgu1);

                    Connection.sql.Close();
                    if (dt_Sorgu1.Rows.Count > 0)
                    {
                        if (dt_Sorgu1.Rows[0][0].ToString() == "75")
                        {
                            bool kontrol = alanlariKontrolEt("75", e.RowIndex);
                            if (!kontrol)
                            {
                                return;
                            }
                        }
                        else if (dt_Sorgu1.Rows[0][0].ToString() == "95")
                        {
                            bool kontrol = alanlariKontrolEt("95", e.RowIndex);
                            if (!kontrol)
                            {
                                return;
                            }
                        }
                    }
                }
                else if (itemCode2.ToString() == "")
                {
                    bool kontrol = alanlariKontrolEt("", e.RowIndex);
                    if (!kontrol)
                    {
                        return;
                    }
                }

                var value = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells["Kontrol No"].Value.ToString();
                if (value == "Kontrol Saati")
                {
                    string cc = dtgPaketlenenAyranProsesOzellikleri.Rows[0].Cells[e.ColumnIndex].Value.ToString();
                    string _kontrolSaati = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                    if (_kontrolSaati == "" && cc.ToString() != "")
                    {
                        SaatTarihGirisi n = new SaatTarihGirisi(dtgPaketlenenAyranProsesOzellikleri, true);
                        n.ShowDialog();


                        var itemCode = dtgPaketlenenAyranProsesOzellikleri.Rows[4].Cells[e.ColumnIndex].Value;

                        if (itemCode.ToString() != "")
                        {
                            int parantezBaslangic = itemCode.ToString().IndexOf("(");
                            int parantezBitis = itemCode.ToString().IndexOf(")");
                            int kesilecekMiktar = parantezBitis - parantezBaslangic;
                            string kalemKodu = itemCode.ToString().Substring(parantezBaslangic + 1, kesilecekMiktar - 1);
                            itemCode = kalemKodu;
                        }

                        string sql = "Select \"U_UrnCap\",\"ItemName\",\"IWeight1\" FROM OITM WITH (NOLOCK) where \"ItemCode\" = '" + itemCode + "'";
                        cmd = new SqlCommand(sql, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                        DataTable dt_Sorgu1 = new DataTable();
                        sda1.Fill(dt_Sorgu1);

                        Connection.sql.Close();
                        if (dt_Sorgu1.Rows.Count > 0)
                        {
                            if (dt_Sorgu1.Rows[0][0].ToString() == "75")
                            {
                                dtgPaketlenenAyranProsesOzellikleri.Rows[11].Cells[e.ColumnIndex].Value = _kontrolSaati;
                                urunCap = "";
                            }
                            else if (dt_Sorgu1.Rows[0][0].ToString() == "95")
                            {
                                dtgPaketlenenAyranProsesOzellikleri.Rows[30].Cells[e.ColumnIndex].Value = _kontrolSaati;
                                urunCap = "";
                            }
                        }
                        //var kalemKodu = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells["Kontrol No"].Value.ToString(); 
                    }
                }
                else if (value == "Ayran Transfer Eden Pompanın Basıncı(Bar)" || value == "Ayranın Sıcaklığı" || value == "Ayran Viskozite(Saniye)" || value == "PH Değeri" || value == "Dolması Gereken Ürün Miktarı (G)" || value == "1" || value == "2" || value == "3" || value == "4" || value == "5" || value == "6" || value == "7" || value == "8" || value == "9" || value == "10" || value == "11" || value == "12" || value == "13" || value == "14" || value == "15" || value == "16" || value == "Kontrol Edilen Palet No" || value == "Dolumdaki Gramaj Sapma Oranı(%) Eksik" || value == "Dolumdaki Gramaj Sapma Oranı(%) Fazla")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgPaketlenenAyranProsesOzellikleri);
                    n.ShowDialog();

                    #region AYRAN GRAMAJ HESAPLAMASI
                    //dtgPaketlenenAyranProsesOzellikleri.Columns["1"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    //dtgPaketlenenAyranProsesOzellikleri.Columns["Toplam Süt Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; 
                    var itemCode = dtgPaketlenenAyranProsesOzellikleri.Rows[4].Cells[e.ColumnIndex].Value;
                    string kalemKodu = "";
                    if (itemCode.ToString() != "" && itemCode != DBNull.Value && itemCode != null)
                    {
                        int parantezBaslangic = itemCode.ToString().IndexOf("(");
                        int parantezBitis = itemCode.ToString().IndexOf(")");
                        int kesilecekMiktar = parantezBitis - parantezBaslangic;
                        kalemKodu = itemCode.ToString().Substring(parantezBaslangic + 1, kesilecekMiktar - 1);
                        itemCode = kalemKodu;
                    }
                    else
                    {
                        dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
                        CustomMsgBtn.Show("Öncelikle ürün seçimi yapılmalıdır.", "UYARI", "TAMAM");
                        return;
                    }

                    //int parantezBaslangic = itemCode2.ToString().IndexOf("(");
                    //int parantezBitis = itemCode2.ToString().IndexOf(")");
                    //int kesilecekMiktar = parantezBitis - parantezBaslangic;
                    //string kalemKodu = itemCode2.ToString().Substring(parantezBaslangic + 1, kesilecekMiktar - 1);


                    string sql = "Select \"U_UrnCap\",\"ItemName\",\"IWeight1\" FROM OITM WITH (NOLOCK) where \"ItemCode\" = '" + kalemKodu + "'";
                    cmd = new SqlCommand(sql, Connection.sql);

                    if (Connection.sql.State != ConnectionState.Open)
                        Connection.sql.Open();

                    SqlDataAdapter sda2 = new SqlDataAdapter(cmd);
                    DataTable dt_Sorgu2 = new DataTable();
                    sda2.Fill(dt_Sorgu2);

                    Connection.sql.Close();
                    double gelenGramajMik = 0;
                    double girilenGramajMik = 0;
                    double toplamEksikGramajMik = 0;
                    double toplamFazlaGramajMik = 0;
                    double sonuc = 0;

                    if (dt_Sorgu2.Rows.Count > 0)
                    {
                        gelenGramajMik = parseNumber.parservalues<double>(dt_Sorgu2.Rows[0][2].ToString());
                        //gelenGramajMik = Convert.ToDouble(dt_Sorgu2.Rows[0][2].ToString());//old
                    }

                    girilenGramajMik = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());

                    /* girilenGramajMik = Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value);*/ //old

                    if (dt_Sorgu2.Rows[0][0].ToString() == "75")
                    {
                        if (gelenGramajMik == 175)
                        {
                            if (girilenGramajMik == 175)
                            {
                                dtgPaketlenenAyranProsesOzellikleri.Rows[13].Cells[e.ColumnIndex].Value = 0.ToString("#,##0.00");
                                dtgPaketlenenAyranProsesOzellikleri.Rows[14].Cells[e.ColumnIndex].Value = 0.ToString("#,##0.00");

                            }
                            else
                            {
                                if (value == "Dolumdaki Gramaj Sapma Oranı(%) Eksik")
                                {
                                    if (girilenGramajMik < gelenGramajMik)
                                    {
                                        toplamEksikGramajMik = gelenGramajMik - girilenGramajMik;

                                        sonuc = parseNumber.parservalues<double>(toplamEksikGramajMik.ToString()) / (175 * 12) * 100;
                                        //sonuc = Convert.ToDouble(toplamEksikGramajMik / (175 * 12)) * 100;//old
                                        dtgPaketlenenAyranProsesOzellikleri.Rows[13].Cells[e.ColumnIndex].Value = sonuc.ToString("#,##0.00");

                                        dtgPaketlenenAyranProsesOzellikleri.Rows[14].Cells[e.ColumnIndex].Value = 0.ToString("#,##0.00");
                                    }
                                }

                                if (value == "Dolumdaki Gramaj Sapma Oranı(%) Fazla")
                                {
                                    if (girilenGramajMik > gelenGramajMik)
                                    {
                                        toplamFazlaGramajMik = girilenGramajMik - gelenGramajMik;

                                        sonuc = parseNumber.parservalues<double>(toplamFazlaGramajMik.ToString()) / (175 * 12) * 100;
                                        //sonuc = Convert.ToDouble(toplamFazlaGramajMik / (175 * 12)) * 100;//old
                                        dtgPaketlenenAyranProsesOzellikleri.Rows[14].Cells[e.ColumnIndex].Value = sonuc.ToString("#,##0.00");

                                        dtgPaketlenenAyranProsesOzellikleri.Rows[13].Cells[e.ColumnIndex].Value = 0.ToString("#,##0.00");
                                    }
                                }
                            }
                        }



                        if (gelenGramajMik == 200)
                        {
                            if (girilenGramajMik == 200)
                            {
                                dtgPaketlenenAyranProsesOzellikleri.Rows[13].Cells[e.ColumnIndex].Value = 0.ToString("#,##0.00");
                                dtgPaketlenenAyranProsesOzellikleri.Rows[14].Cells[e.ColumnIndex].Value = 0.ToString("#,##0.00");
                            }
                            else
                            {
                                if (value == "Dolumdaki Gramaj Sapma Oranı(%) Eksik")
                                {
                                    if (girilenGramajMik < gelenGramajMik)
                                    {
                                        toplamEksikGramajMik = gelenGramajMik - girilenGramajMik;

                                        sonuc = parseNumber.parservalues<double>(toplamEksikGramajMik.ToString()) / (200 * 12) * 100;
                                        //sonuc = Convert.ToDouble(toplamEksikGramajMik / (200 * 12)) * 100; //old
                                        dtgPaketlenenAyranProsesOzellikleri.Rows[13].Cells[e.ColumnIndex].Value = sonuc.ToString("#,##0.00");

                                        dtgPaketlenenAyranProsesOzellikleri.Rows[14].Cells[e.ColumnIndex].Value = 0.ToString("#,##0.00");
                                    }
                                }

                                if (value == "Dolumdaki Gramaj Sapma Oranı(%) Fazla")
                                {
                                    if (girilenGramajMik > gelenGramajMik)
                                    {
                                        toplamFazlaGramajMik = girilenGramajMik - gelenGramajMik;

                                        sonuc = parseNumber.parservalues<double>(toplamFazlaGramajMik.ToString()) / (200 * 12) * 100;
                                        //sonuc = Convert.ToDouble(toplamFazlaGramajMik / (200 * 12)) * 100; //old
                                        dtgPaketlenenAyranProsesOzellikleri.Rows[14].Cells[e.ColumnIndex].Value = sonuc.ToString("#,##0.00");

                                        dtgPaketlenenAyranProsesOzellikleri.Rows[13].Cells[e.ColumnIndex].Value = 0.ToString("#,##0.00");
                                    }
                                }
                            }
                        }

                    }

                    if (dt_Sorgu2.Rows[0][0].ToString() == "95")
                    {
                        if (gelenGramajMik == 285)
                        {

                            if (girilenGramajMik == 285)
                            {
                                dtgPaketlenenAyranProsesOzellikleri.Rows[32].Cells[e.ColumnIndex].Value = "0".ToString() + ".00";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[33].Cells[e.ColumnIndex].Value = "0".ToString() + ".00";
                            }
                            else
                            {
                                if (value == "Dolumdaki Gramaj Sapma Oranı(%) Eksik")
                                {
                                    if (girilenGramajMik < gelenGramajMik)
                                    {
                                        toplamEksikGramajMik = gelenGramajMik - girilenGramajMik;

                                        sonuc = parseNumber.parservalues<double>(toplamEksikGramajMik.ToString()) / (285 * 6) * 100;
                                        sonuc = Convert.ToDouble(toplamEksikGramajMik / (285 * 6)) * 100;//old
                                        dtgPaketlenenAyranProsesOzellikleri.Rows[32].Cells[e.ColumnIndex].Value = sonuc.ToString("#,##0.00");

                                        dtgPaketlenenAyranProsesOzellikleri.Rows[33].Cells[e.ColumnIndex].Value = "0".ToString() + ".00";
                                    }
                                }

                                if (value == "Dolumdaki Gramaj Sapma Oranı(%) Fazla")
                                {
                                    if (girilenGramajMik > gelenGramajMik)
                                    {
                                        toplamFazlaGramajMik = girilenGramajMik - gelenGramajMik;

                                        sonuc = parseNumber.parservalues<double>(toplamFazlaGramajMik.ToString()) / (285 * 6) * 100;
                                        //sonuc = Convert.ToDouble(toplamFazlaGramajMik / (285 * 6)) * 100;//old
                                        dtgPaketlenenAyranProsesOzellikleri.Rows[33].Cells[e.ColumnIndex].Value = sonuc.ToString("#,##0.00");

                                        dtgPaketlenenAyranProsesOzellikleri.Rows[32].Cells[e.ColumnIndex].Value = "0".ToString() + ".00";
                                    }
                                }
                            }

                        }

                        if (gelenGramajMik == 300)
                        {
                            if (girilenGramajMik == 300)
                            {
                                dtgPaketlenenAyranProsesOzellikleri.Rows[32].Cells[e.ColumnIndex].Value = "0".ToString() + ".00";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[33].Cells[e.ColumnIndex].Value = "0".ToString() + ".00";
                            }
                            else
                            {
                                if (value == "Dolumdaki Gramaj Sapma Oranı(%) Eksik")
                                {
                                    if (girilenGramajMik < gelenGramajMik)
                                    {
                                        toplamEksikGramajMik = gelenGramajMik - girilenGramajMik;

                                        sonuc = parseNumber.parservalues<double>(toplamEksikGramajMik.ToString()) / (300 * 6) * 100;
                                        //sonuc = Convert.ToDouble(toplamEksikGramajMik / (300 * 6)) * 100; //old
                                        dtgPaketlenenAyranProsesOzellikleri.Rows[32].Cells[e.ColumnIndex].Value = sonuc.ToString("#,##0.00");

                                        dtgPaketlenenAyranProsesOzellikleri.Rows[33].Cells[e.ColumnIndex].Value = "0".ToString() + ".00";
                                    }
                                }

                                if (value == "Dolumdaki Gramaj Sapma Oranı(%) Fazla")
                                {
                                    if (girilenGramajMik > gelenGramajMik)
                                    {
                                        toplamFazlaGramajMik = girilenGramajMik - gelenGramajMik;

                                        sonuc = parseNumber.parservalues<double>(toplamFazlaGramajMik.ToString()) / (300 * 6) * 100;
                                        //sonuc = Convert.ToDouble(toplamFazlaGramajMik / (300 * 6)) * 100;//old
                                        dtgPaketlenenAyranProsesOzellikleri.Rows[33].Cells[e.ColumnIndex].Value = sonuc.ToString("#,##0.00");

                                        dtgPaketlenenAyranProsesOzellikleri.Rows[32].Cells[e.ColumnIndex].Value = "0".ToString() + ".00";
                                    }
                                }
                            }

                        }
                    }

                    #endregion AYRAN GRAMAJ HESAPLAMASI

                    if (value != "Kontrol Edilen Palet No")
                    {
                        var girilenDeger = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                        if (girilenDeger != "")
                        {
                            if (!girilenDeger.Contains(".") && !girilenDeger.Contains(","))
                            {
                                dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString() + ".00";
                            }
                        }

                        OrtalamaYaz(e.RowIndex, e.ColumnIndex);
                    }
                }
                else if (value == "Tat,Koku ve Kıvamı")
                {
                    string sql = "Select '0' as \"Kod\",'İyi' as \"Aciklama\" ";
                    sql += " UNION ALL ";
                    sql += "Select '1' as \"Kod\",'Kötü' as \"Aciklama\" ";

                    SelectList selectList = new SelectList(sql, dtgPaketlenenAyranProsesOzellikleri, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();
                }
                else if (value == "Doldurulan Ürün Adı" || value == "Kontrol Edilen Ürün Adı")
                {
                    string sql = "Select \"U_Deger1\",\"U_Deger2\" from \"@AIF_GNLKANLZPRM\" WITH (NOLOCK) where \"U_Kod\" ='1'";
                    cmd = new SqlCommand(sql, Connection.sql);

                    if (Connection.sql.State != ConnectionState.Open)
                        Connection.sql.Open();

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt_Sorgu = new DataTable();
                    sda.Fill(dt_Sorgu);

                    //dtgSecim.DataSource = dt;
                    //dtSecim = dt; 

                    Connection.sql.Close();

                    if (dt_Sorgu.Rows.Count > 0)
                    {


                        var itemCode = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                        string sql1 = "Select TOP 1 '' as \"Kalem Kodu\",'' as \"Kalem Adı\" FROM OITM WITH (NOLOCK) ";
                        sql1 += " UNION ALL ";
                        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM WITH (NOLOCK) where \"U_ItemGroup2\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][1].ToString() + "'";

                        SelectList selectList = new SelectList(sql1, dtgPaketlenenAyranProsesOzellikleri, -1, e.ColumnIndex, _autoresizerow: false);
                        selectList.ShowDialog();

                        if (itemCode.ToString() != "")
                        {
                            int parantezBaslangic = itemCode.ToString().IndexOf("(");
                            int parantezBitis = itemCode.ToString().IndexOf(")");
                            int kesilecekMiktar = parantezBitis - parantezBaslangic;
                            string kalemKodu = itemCode.ToString().Substring(parantezBaslangic + 1, kesilecekMiktar - 1);
                            if (kalemKodu.ToString() != SelectList.kalemKodu)
                            {
                                dtgPaketlenenAyranProsesOzellikleri.Rows[9].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[10].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[11].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[12].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[13].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[14].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[15].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[15].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[16].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[17].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[18].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[19].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[20].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[21].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[22].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[23].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[24].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[25].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[26].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[27].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[28].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[29].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[30].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[31].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[32].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[33].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[35].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[36].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[37].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[38].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[39].Cells[e.ColumnIndex].Value = "";
                                dtgPaketlenenAyranProsesOzellikleri.Rows[40].Cells[e.ColumnIndex].Value = "";
                            }
                        }


                        if (SelectList.kalemKodu != "")
                        {

                            sql = "Select \"U_UrnCap\",\"ItemName\",\"IWeight1\" FROM OITM WITH (NOLOCK) where \"ItemCode\" = '" + SelectList.kalemKodu + "'";

                            cmd = new SqlCommand(sql, Connection.sql);

                            if (Connection.sql.State != ConnectionState.Open)
                                Connection.sql.Open();

                            sda = new SqlDataAdapter(cmd);
                            dt_Sorgu = new DataTable();
                            sda.Fill(dt_Sorgu);

                            //dtgSecim.DataSource = dt;
                            //dtSecim = dt; 

                            Connection.sql.Close();

                            if (dt_Sorgu.Rows.Count > 0)
                            {
                                dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells[e.ColumnIndex].Value + "(" + SelectList.kalemKodu + ")";
                                //dtgPaketlenenAyranProsesOzellikleri.Rows[e.RowIndex].Cells["ItemCode"].Value = SelectList.kalemKodu.ToString();
                                string _kontrolSaati = dtgPaketlenenAyranProsesOzellikleri.Rows[1].Cells[e.ColumnIndex].Value.ToString();
                                double gramajMik = Convert.ToDouble(dt_Sorgu.Rows[0][2]);

                                if (dt_Sorgu.Rows[0][0].ToString() == "75")
                                {
                                    urunCap = "75";
                                    dtgPaketlenenAyranProsesOzellikleri.Rows[10].Cells[e.ColumnIndex].Value = dt_Sorgu.Rows[0][1].ToString() + "(" + SelectList.kalemKodu + ")";
                                    dtgPaketlenenAyranProsesOzellikleri.Rows[12].Cells[e.ColumnIndex].Value = Convert.ToDouble(dt_Sorgu.Rows[0][2]).ToString();

                                    #region AYRAN GRAMAJ HESAPLAMASI
                                    dtgPaketlenenAyranProsesOzellikleri.Columns[1].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                                    //dtgPaketlenenAyranProsesOzellikleri.Columns["Toplam Süt Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                    dtgPaketlenenAyranProsesOzellikleri.Columns[1].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                                    //dtgPaketlenenAyranProsesOzellikleri.Columns["Toplam Su Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                                    dtgPaketlenenAyranProsesOzellikleri.Columns[1].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                                    //dtgPaketlenenAyranProsesOzellikleri.Columns["Tuz Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;



                                    if (gramajMik == 175 || gramajMik == 200)
                                    {
                                        dtgPaketlenenAyranProsesOzellikleri.Rows[13].Cells[e.ColumnIndex].Value = "0".ToString() + ".00";

                                        dtgPaketlenenAyranProsesOzellikleri.Rows[14].Cells[e.ColumnIndex].Value = "0".ToString() + ".00";

                                    }
                                    #endregion AYRAN GRAMAJ HESAPLAMASI

                                    if (_kontrolSaati != "")
                                    {
                                        dtgPaketlenenAyranProsesOzellikleri.Rows[11].Cells[e.ColumnIndex].Value = _kontrolSaati;
                                    }
                                    //foreach (DataRow dr in dt.Rows)
                                    //{
                                    //    if (dr["Kontrol No"].ToString() == "Doldurulan Ürün Adı")
                                    //    {
                                    //        dr["Doldurulan Ürün Adı"] = dt.Rows[0][1].ToString();
                                    //        return;
                                    //    }
                                    //} 


                                }
                                else if (dt_Sorgu.Rows[0][0].ToString() == "95")
                                {
                                    urunCap = "95";
                                    dtgPaketlenenAyranProsesOzellikleri.Rows[29].Cells[e.ColumnIndex].Value = dt_Sorgu.Rows[0][1].ToString();
                                    dtgPaketlenenAyranProsesOzellikleri.Rows[31].Cells[e.ColumnIndex].Value = Convert.ToDouble(dt_Sorgu.Rows[0][2]).ToString();
                                    if (_kontrolSaati != "")
                                    {
                                        dtgPaketlenenAyranProsesOzellikleri.Rows[30].Cells[e.ColumnIndex].Value = _kontrolSaati;
                                    }

                                    if (gramajMik == 285 || gramajMik == 300)
                                    {
                                        dtgPaketlenenAyranProsesOzellikleri.Rows[32].Cells[e.ColumnIndex].Value = "0".ToString() + ".00";

                                        dtgPaketlenenAyranProsesOzellikleri.Rows[33].Cells[e.ColumnIndex].Value = "0".ToString() + ".00";

                                    }
                                    //int i = 0;
                                    //foreach (DataRow dr in dt.Rows)
                                    //{
                                    //    if (dr["Kontrol No"].ToString() == "Doldurulan Ürün Adı")
                                    //    {
                                    //        i++;
                                    //        if (i == 2)
                                    //        {
                                    //            dr["Kontrol No"] = dt.Rows[0][1].ToString();
                                    //            return;
                                    //        }
                                    //    }
                                    //} 
                                }

                            }
                            OrtalamaYaz(e.RowIndex, e.ColumnIndex);

                        }

                    }
                }
                else if (value == "Kontrol Eden Personel Adı")
                {
                    DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                    string gunfield = "U_Gun" + dtTarih.Day;

                    string sql1 = "";

                    #region Günlük Personel Planlama 4 ekranı
                    sql1 = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

                    if (AtanmisIsler.Joker)
                    {
                        sql1 += " UNION ALL ";

                        sql1 += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                    }
                    #endregion Günlük Personel Planlama 4 ekranı

                    #region Günlük Personel Planlama 3 ekranı

                    //sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                    //sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'IST001' or T1.\"U_Bolum2\" = 'IST001' or T1.\"U_Bolum3\" = 'IST001') and \"U_Durum\" = 'X'";

                    //if (AtanmisIsler.Joker)
                    //{
                    //    sql += " UNION ALL ";

                    //    sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                    //    sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') and \"U_Durum\" = 'X'";
                    //}

                    #endregion Günlük Personel Planlama 3 ekranı

                    #region Günlük Personel Planama 2 ekranı

                    //sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'IST001' or T1.\"U_Bolum2\" = 'IST001' or T1.\"U_Bolum3\" = 'IST001') and " + gunfield + " = 'X' ";

                    //if (AtanmisIsler.Joker)
                    //{
                    //    sql += " UNION ALL ";

                    //    sql += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                    //}

                    #endregion Günlük Personel Planama 2 ekranı

                    //string sql = "Select \"U_PersonelNo\" as \"Personel No\",\"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"" + field + "\" = 'Y'";

                    SelectList selectList = new SelectList(sql1, dtgPaketlenenAyranProsesOzellikleri, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();
                }
            }
        }

        private void OrtalamaYaz(int rowindex, int columnIndex)
        {

            try
            {
                var itemCode = dtgPaketlenenAyranProsesOzellikleri.Rows[4].Cells[columnIndex].Value;

                if (itemCode.ToString() != "")
                {
                    int parantezBaslangic = itemCode.ToString().IndexOf("(");
                    int parantezBitis = itemCode.ToString().IndexOf(")");
                    int kesilecekMiktar = parantezBitis - parantezBaslangic;
                    string kalemKodu = itemCode.ToString().Substring(parantezBaslangic + 1, kesilecekMiktar - 1);
                    itemCode = kalemKodu;
                }

                string sql = "Select \"U_UrnCap\",\"ItemName\",\"IWeight1\" FROM OITM WITH (NOLOCK) where \"ItemCode\" = '" + itemCode + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda1 = new SqlDataAdapter(cmd);
                DataTable dt_Sorgu1 = new DataTable();
                sda1.Fill(dt_Sorgu1);

                Connection.sql.Close();

                string cap = "";

                if (dt_Sorgu1.Rows.Count > 0)
                {
                    if (dt_Sorgu1.Rows[0][0].ToString() == "75")
                    {
                        cap = "75";
                    }
                    else if (dt_Sorgu1.Rows[0][0].ToString() == "95")
                    {
                        cap = "95";
                    }
                }
                var girilenSayi = 0;

                double deger1 = 0;
                double deger2 = 0;
                double deger3 = 0;
                double deger4 = 0;
                double deger5 = 0;
                double deger6 = 0;
                double deger7 = 0;
                double deger8 = 0;
                double deger9 = 0;
                double deger10 = 0;
                double deger11 = 0;
                double deger12 = 0;


                if (cap == "75")
                {
                    deger1 = dtgPaketlenenAyranProsesOzellikleri.Rows[16].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[16].Cells[columnIndex].Value.ToString());
                    deger2 = dtgPaketlenenAyranProsesOzellikleri.Rows[17].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[17].Cells[columnIndex].Value.ToString());
                    deger3 = dtgPaketlenenAyranProsesOzellikleri.Rows[18].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[18].Cells[columnIndex].Value.ToString());
                    deger4 = dtgPaketlenenAyranProsesOzellikleri.Rows[19].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[19].Cells[columnIndex].Value.ToString());
                    deger5 = dtgPaketlenenAyranProsesOzellikleri.Rows[20].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[20].Cells[columnIndex].Value.ToString());
                    deger6 = dtgPaketlenenAyranProsesOzellikleri.Rows[21].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[21].Cells[columnIndex].Value.ToString());
                    deger7 = dtgPaketlenenAyranProsesOzellikleri.Rows[22].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[22].Cells[columnIndex].Value.ToString());
                    deger8 = dtgPaketlenenAyranProsesOzellikleri.Rows[23].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[23].Cells[columnIndex].Value.ToString());
                    deger9 = dtgPaketlenenAyranProsesOzellikleri.Rows[24].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[24].Cells[columnIndex].Value.ToString());
                    deger10 = dtgPaketlenenAyranProsesOzellikleri.Rows[25].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[25].Cells[columnIndex].Value.ToString());
                    deger11 = dtgPaketlenenAyranProsesOzellikleri.Rows[26].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[26].Cells[columnIndex].Value.ToString());
                    deger12 = dtgPaketlenenAyranProsesOzellikleri.Rows[27].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[27].Cells[columnIndex].Value.ToString());
                    //deger1 = dtgPaketlenenAyranProsesOzellikleri.Rows[16].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[16].Cells[columnIndex].Value);
                    //deger2 = dtgPaketlenenAyranProsesOzellikleri.Rows[17].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[17].Cells[columnIndex].Value);
                    //deger3 = dtgPaketlenenAyranProsesOzellikleri.Rows[18].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[18].Cells[columnIndex].Value);
                    //deger4 = dtgPaketlenenAyranProsesOzellikleri.Rows[19].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[19].Cells[columnIndex].Value);
                    //deger5 = dtgPaketlenenAyranProsesOzellikleri.Rows[20].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[20].Cells[columnIndex].Value);
                    //deger6 = dtgPaketlenenAyranProsesOzellikleri.Rows[21].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[21].Cells[columnIndex].Value);
                    //deger7 = dtgPaketlenenAyranProsesOzellikleri.Rows[22].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[22].Cells[columnIndex].Value);
                    //deger8 = dtgPaketlenenAyranProsesOzellikleri.Rows[23].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[23].Cells[columnIndex].Value);
                    //deger9 = dtgPaketlenenAyranProsesOzellikleri.Rows[24].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[24].Cells[columnIndex].Value);
                    //deger10 = dtgPaketlenenAyranProsesOzellikleri.Rows[25].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[25].Cells[columnIndex].Value);
                    //deger11 = dtgPaketlenenAyranProsesOzellikleri.Rows[26].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[26].Cells[columnIndex].Value);
                    //deger12 = dtgPaketlenenAyranProsesOzellikleri.Rows[27].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[27].Cells[columnIndex].Value);
                }
                else if (cap == "95")
                {
                    deger1 = dtgPaketlenenAyranProsesOzellikleri.Rows[35].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[35].Cells[columnIndex].Value.ToString());
                    deger2 = dtgPaketlenenAyranProsesOzellikleri.Rows[36].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[36].Cells[columnIndex].Value.ToString());
                    deger3 = dtgPaketlenenAyranProsesOzellikleri.Rows[37].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[37].Cells[columnIndex].Value.ToString());
                    deger4 = dtgPaketlenenAyranProsesOzellikleri.Rows[38].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[38].Cells[columnIndex].Value.ToString());
                    deger5 = dtgPaketlenenAyranProsesOzellikleri.Rows[39].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[39].Cells[columnIndex].Value.ToString());
                    deger6 = dtgPaketlenenAyranProsesOzellikleri.Rows[40].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[40].Cells[columnIndex].Value.ToString());
                    //deger1 = dtgPaketlenenAyranProsesOzellikleri.Rows[35].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[35].Cells[columnIndex].Value);
                    //deger2 = dtgPaketlenenAyranProsesOzellikleri.Rows[36].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[36].Cells[columnIndex].Value);
                    //deger3 = dtgPaketlenenAyranProsesOzellikleri.Rows[37].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[37].Cells[columnIndex].Value);
                    //deger4 = dtgPaketlenenAyranProsesOzellikleri.Rows[38].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[38].Cells[columnIndex].Value);
                    //deger5 = dtgPaketlenenAyranProsesOzellikleri.Rows[39].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[39].Cells[columnIndex].Value);
                    //deger6 = dtgPaketlenenAyranProsesOzellikleri.Rows[40].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[40].Cells[columnIndex].Value);
                }

                double toplam = 0;

                toplam = deger1 + deger2 + deger3 + deger4 + deger5 + deger6 + deger7 + deger8 + deger9 + deger10 + deger11 + deger12;

                double IWeight = parseNumber.parservalues<double>(dt_Sorgu1.Rows[0][2].ToString());
                //double gramajchn = Convert.ToDouble(IWeight);
                //double fazlaeksik = 0;
                //string degerbir = deger1.ToString("N" + Giris.OndalikMiktar);
                //double deger1c = Convert.ToDouble(degerbir);
                //fazlaeksik = Convert.ToDouble(deger1c) - Convert.ToDouble(gramajchn);
                //toplam = (IWeight - deger1) + (IWeight - deger2) + (IWeight - deger3) + (IWeight - deger4) + (IWeight - deger5) + (IWeight - deger6) + (IWeight - deger7) + (IWeight - deger8) + (IWeight - deger9) + (IWeight - deger10) + (IWeight - deger11) + (IWeight - deger12);

                double gramaj = 0;

                if (cap == "75")
                {
                    gramaj = dtgPaketlenenAyranProsesOzellikleri.Rows[12].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[12].Cells[columnIndex].Value.ToString());
                    //gramaj = dtgPaketlenenAyranProsesOzellikleri.Rows[12].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[12].Cells[columnIndex].Value);
                }
                else if (cap == "95")
                {
                    gramaj = dtgPaketlenenAyranProsesOzellikleri.Rows[31].Cells[columnIndex].Value.ToString() == "" ? 0 : parseNumber.parservalues<double>(dtgPaketlenenAyranProsesOzellikleri.Rows[31].Cells[columnIndex].Value.ToString());
                    //gramaj = dtgPaketlenenAyranProsesOzellikleri.Rows[31].Cells[columnIndex].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgPaketlenenAyranProsesOzellikleri.Rows[31].Cells[columnIndex].Value);
                }
                double final = 0;
                if (toplam != 0 && gramaj != 0)
                {

                    if (cap == "75")
                    {
                        if (deger1 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger2 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger3 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger4 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger5 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger6 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger7 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger8 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger9 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger10 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger11 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger12 != 0)
                        {
                            girilenSayi++;
                        }
                    }
                    else if (cap == "95")
                    {
                        if (deger1 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger2 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger3 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger4 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger5 != 0)
                        {
                            girilenSayi++;
                        }
                        if (deger6 != 0)
                        {
                            girilenSayi++;
                        }
                    }

                    final = Math.Round(Convert.ToDouble((((toplam / girilenSayi)) - gramaj) / gramaj) * 100, Giris.OndalikMiktar); //old
                    //final = Math.Round(Convert.ToDouble((toplam / girilenSayi) / gramaj, System.Globalization.CultureInfo.InvariantCulture), 2);

                    double girilenfazla = 0;
                    double girileneksik = 0;

                    if (deger1 > 0)
                    {
                        if (deger1 > IWeight)
                        {
                            deger1 = deger1 - IWeight;

                            girilenfazla = girilenfazla + deger1;
                        }
                        else if (deger1 < IWeight)
                        {
                            deger1 = IWeight - deger1;

                            girileneksik = girileneksik + deger1;
                        }
                    }

                    if (deger2 > 0)
                    {
                        if (deger2 > IWeight)
                        {
                            deger2 = deger2 - IWeight;

                            girilenfazla = girilenfazla + deger2;
                        }
                        else if (deger2 < IWeight)
                        {
                            deger2 = IWeight - deger2;

                            girileneksik = girileneksik + deger2;
                        }
                    }

                    if (deger3 > 0)
                    {
                        if (deger3 > IWeight)
                        {
                            deger3 = deger3 - IWeight;

                            girilenfazla = girilenfazla + deger3;
                        }
                        else if (deger3 < IWeight)
                        {
                            deger3 = IWeight - deger3;

                            girileneksik = girileneksik + deger3;
                        }
                    }

                    if (deger4 > 0)
                    {
                        if (deger4 > IWeight)
                        {
                            deger4 = deger4 - IWeight;

                            girilenfazla = girilenfazla + deger4;
                        }
                        else if (deger4 < IWeight)
                        {
                            deger4 = IWeight - deger4;

                            girileneksik = girileneksik + deger4;
                        }
                    }

                    if (deger5 > 0)
                    {
                        if (deger5 > IWeight)
                        {
                            deger5 = deger5 - IWeight;

                            girilenfazla = girilenfazla + deger5;
                        }
                        else if (deger5 < IWeight)
                        {
                            deger5 = IWeight - deger5;

                            girileneksik = girileneksik + deger5;
                        }
                    }

                    if (deger6 > 0)
                    {
                        if (deger6 > IWeight)
                        {
                            deger6 = deger6 - IWeight;

                            girilenfazla = girilenfazla + deger6;
                        }
                        else if (deger6 < IWeight)
                        {
                            deger6 = IWeight - deger6;

                            girileneksik = girileneksik + deger6;
                        }
                    }

                    if (deger7 > 0)
                    {
                        if (deger7 > IWeight)
                        {
                            deger7 = deger7 - IWeight;

                            girilenfazla = girilenfazla + deger7;
                        }
                        else if (deger7 < IWeight)
                        {
                            deger7 = IWeight - deger7;

                            girileneksik = girileneksik + deger7;
                        }
                    }

                    if (deger8 > 0)
                    {
                        if (deger8 > IWeight)
                        {
                            deger8 = deger8 - IWeight;

                            girilenfazla = girilenfazla + deger8;
                        }
                        else if (deger8 < IWeight)
                        {
                            deger8 = IWeight - deger8;

                            girileneksik = girileneksik + deger8;
                        }
                    }

                    if (deger9 > 0)
                    {
                        if (deger9 > IWeight)
                        {
                            deger9 = deger9 - IWeight;

                            girilenfazla = girilenfazla + deger9;
                        }
                        else if (deger9 < IWeight)
                        {
                            deger9 = IWeight - deger9;

                            girileneksik = girileneksik + deger9;
                        }
                    }

                    if (deger10 > 0)
                    {
                        if (deger10 > IWeight)
                        {
                            deger10 = deger10 - IWeight;

                            girilenfazla = girilenfazla + deger10;
                        }
                        else if (deger10 < IWeight)
                        {
                            deger10 = IWeight - deger10;

                            girileneksik = girileneksik + deger10;
                        }
                    }

                    if (deger11 > 0)
                    {
                        if (deger11 > IWeight)
                        {
                            deger11 = deger11 - IWeight;

                            girilenfazla = girilenfazla + deger11;
                        }
                        else if (deger11 < IWeight)
                        {
                            deger11 = IWeight - deger11;

                            girileneksik = girileneksik + deger11;
                        }
                    }

                    if (deger12 > 0)
                    {
                        if (deger12 > IWeight)
                        {
                            deger12 = deger12 - IWeight;

                            girilenfazla = girilenfazla + deger12;
                        }
                        else if (deger12 < IWeight)
                        {
                            deger12 = IWeight - deger12;

                            girileneksik = girileneksik + deger12;
                        }
                    }
                    //toplam = deger1 + deger2 + deger3 + deger4 + deger5 + deger6 + deger7 + deger8 + deger9 + deger10 + deger11 + deger12;
                    final = Math.Round(Convert.ToDouble(IWeight / toplam) * 100, Giris.OndalikMiktar);

                    girilenfazla = Math.Round(parseNumber.parservalues<double>((girilenfazla / toplam).ToString()) * 100, Giris.OndalikMiktar);
                    girileneksik = Math.Round(parseNumber.parservalues<double>((girileneksik / toplam).ToString()) * 100, Giris.OndalikMiktar);

                    if (cap == "75")
                    {
                        #region old
                        //if (final > 0)
                        //{
                        //    dtgPaketlenenAyranProsesOzellikleri.Rows[13].Cells[columnIndex].Value = "";
                        //    dtgPaketlenenAyranProsesOzellikleri.Rows[14].Cells[columnIndex].Value = final.ToString();
                        //}
                        //else
                        //{
                        //    dtgPaketlenenAyranProsesOzellikleri.Rows[14].Cells[columnIndex].Value = "";
                        //    final = final * -1;
                        //    dtgPaketlenenAyranProsesOzellikleri.Rows[13].Cells[columnIndex].Value = final.ToString();
                        //}
                        #endregion

                        dtgPaketlenenAyranProsesOzellikleri.Rows[13].Cells[columnIndex].Value = girileneksik;
                        dtgPaketlenenAyranProsesOzellikleri.Rows[14].Cells[columnIndex].Value = girilenfazla;
                    }
                    else if (cap == "95")
                    {
                        #region old
                        //if (final > 0)
                        //{
                        //    dtgPaketlenenAyranProsesOzellikleri.Rows[32].Cells[columnIndex].Value = "";
                        //    dtgPaketlenenAyranProsesOzellikleri.Rows[33].Cells[columnIndex].Value = final.ToString();
                        //}
                        //else
                        //{
                        //    dtgPaketlenenAyranProsesOzellikleri.Rows[33].Cells[columnIndex].Value = "";
                        //    final = final * -1;
                        //    dtgPaketlenenAyranProsesOzellikleri.Rows[32].Cells[columnIndex].Value = final.ToString();
                        //}
                        #endregion

                        dtgPaketlenenAyranProsesOzellikleri.Rows[32].Cells[columnIndex].Value = girileneksik;
                        dtgPaketlenenAyranProsesOzellikleri.Rows[33].Cells[columnIndex].Value = girilenfazla;
                    }


                }
            }
            catch (Exception)
            {
            }

        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            UVTServiceSoapClient client = new UVTServiceSoapClient();
            PaketlenenAyranProsesOzellikleri nesne = new PaketlenenAyranProsesOzellikleri();
            PaketlenenAyranProsesOzellikleri1 paketlenenAyranProsesOzellikleri1 = new PaketlenenAyranProsesOzellikleri1();
            List<PaketlenenAyranProsesOzellikleri1> paketlenenAyranProsesOzellikleri1s = new List<PaketlenenAyranProsesOzellikleri1>();
            nesne.Tarih = txtTarih.Text.Substring(6, 4) + txtTarih.Text.Substring(3, 2) + txtTarih.Text.Substring(0, 2);
            nesne.Aciklama = txtAciklama.Text;

            foreach (DataGridViewRow dr in dtgPaketlenenAyranProsesOzellikleri.Rows)
            {
                paketlenenAyranProsesOzellikleri1 = new PaketlenenAyranProsesOzellikleri1();
                paketlenenAyranProsesOzellikleri1.KontrolNo = dr.Cells["Kontrol No"].Value == DBNull.Value ? "" : dr.Cells["Kontrol No"].Value.ToString();

                if (paketlenenAyranProsesOzellikleri1.KontrolNo == "Bosluk1" || paketlenenAyranProsesOzellikleri1.KontrolNo == "Bosluk2")
                {
                    continue;
                }

                paketlenenAyranProsesOzellikleri1.bir = dr.Cells["1"].Value == DBNull.Value ? "" : dr.Cells["1"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.iki = dr.Cells["2"].Value == DBNull.Value ? "" : dr.Cells["2"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.uc = dr.Cells["3"].Value == DBNull.Value ? "" : dr.Cells["3"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.dort = dr.Cells["4"].Value == DBNull.Value ? "" : dr.Cells["4"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.bes = dr.Cells["5"].Value == DBNull.Value ? "" : dr.Cells["5"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.alti = dr.Cells["6"].Value == DBNull.Value ? "" : dr.Cells["6"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.yedi = dr.Cells["7"].Value == DBNull.Value ? "" : dr.Cells["7"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.sekiz = dr.Cells["8"].Value == DBNull.Value ? "" : dr.Cells["8"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.dokuz = dr.Cells["9"].Value == DBNull.Value ? "" : dr.Cells["9"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.on = dr.Cells["10"].Value == DBNull.Value ? "" : dr.Cells["10"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.onbir = dr.Cells["11"].Value == DBNull.Value ? "" : dr.Cells["11"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.oniki = dr.Cells["12"].Value == DBNull.Value ? "" : dr.Cells["12"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.onuc = dr.Cells["13"].Value == DBNull.Value ? "" : dr.Cells["13"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.ondort = dr.Cells["14"].Value == DBNull.Value ? "" : dr.Cells["14"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.onbes = dr.Cells["15"].Value == DBNull.Value ? "" : dr.Cells["15"].Value.ToString();
                paketlenenAyranProsesOzellikleri1.onalti = dr.Cells["16"].Value == DBNull.Value ? "" : dr.Cells["16"].Value.ToString();

                paketlenenAyranProsesOzellikleri1s.Add(paketlenenAyranProsesOzellikleri1);
            }

            nesne.paketlenenAyranProsesOzellikleri1s = paketlenenAyranProsesOzellikleri1s.ToArray();

            var resp = client.AddOrUpdatePakelenenAyranProsesOzellikleri(nesne, Giris.dbName, Giris.mKodValue);

            CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

            if (resp.Value == 0)
            {
                btnOzetEkranaDon.PerformClick();
            }
        }

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }

        private void btnAciklama_Click(object sender, EventArgs e)
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();
        }
    }
}
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
    public partial class AyranGunlukOzet_1 : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end

        private string UretimFisNo = "";
        private string partiNo = "";
        private string istasyon = "";
        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private int row = 0;
        private string tarih1 = "";

        public AyranGunlukOzet_1(string _type, string _kullaniciid, string _UretimFisNo, string _istasyon, int _row, string _tarih1)
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

            initialFontSize = txtUretimTarihi.Font.Size;
            txtUretimTarihi.Resize += Form_Resize;

            initialFontSize = txtUretimVardiyasi.Font.Size;
            txtUretimVardiyasi.Resize += Form_Resize;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;

            initialFontSize = button3.Font.Size;
            button3.Resize += Form_Resize;

            initialFontSize = button4.Font.Size;
            button4.Resize += Form_Resize;

            initialFontSize = button5.Font.Size;
            button5.Resize += Form_Resize;

            initialFontSize = button6.Font.Size;
            button6.Resize += Form_Resize;

            initialFontSize = btnYarimYagliAyran.Font.Size;
            btnYarimYagliAyran.Resize += Form_Resize;

            initialFontSize = btnYardimciMalzeme.Font.Size;
            btnYardimciMalzeme.Resize += Form_Resize;

            initialFontSize = btnOzetEkranaDon.Font.Size;
            btnOzetEkranaDon.Resize += Form_Resize;

            initialFontSize = btnOnayla.Font.Size;
            btnOnayla.Resize += Form_Resize;

            initialFontSize = button11.Font.Size;
            button11.Resize += Form_Resize;

            initialFontSize = richtxtBoxAciklama.Font.Size;
            richtxtBoxAciklama.Resize += Form_Resize;
            //font end

            UretimFisNo = _UretimFisNo;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;

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

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimTarihi.Font.Style);

            txtUretimVardiyasi.Font = new Font(txtUretimVardiyasi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimVardiyasi.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button1.Font.Style);

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button2.Font.Style);

            button3.Font = new Font(button3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button3.Font.Style);

            button4.Font = new Font(button4.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button4.Font.Style);

            button5.Font = new Font(button5.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button5.Font.Style);

            button6.Font = new Font(button6.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button6.Font.Style);

            btnYarimYagliAyran.Font = new Font(btnYarimYagliAyran.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnYarimYagliAyran.Font.Style);

            btnYardimciMalzeme.Font = new Font(btnYardimciMalzeme.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnYardimciMalzeme.Font.Style);

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnOzetEkranaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnOnayla.Font.Style);

            button11.Font = new Font(button11.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button11.Font.Style);

            richtxtBoxAciklama.Font = new Font(richtxtBoxAciklama.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                richtxtBoxAciklama.Font.Style);
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

        private void AyranGunlukOzet_1_Load(object sender, EventArgs e)
        {
            dtgPaketlemeBilgileri1Load();
            dtgPaketlemeBilgileri2Load();
            dtgGunSonuOzetLoad();

            AyranGunlukOzet1Formu = this;
        }

        private SqlCommand cmd = null;
        private DataTable dtPaketlemeBilgileri = new DataTable();

        private void dtgPaketlemeBilgileri1Load()
        {
            string sql = "SELECT \"U_UrunKodu\" as \"Ürün Kodu\",\"U_UrunAdi\" as \"Ürün Adı\", T1.\"U_PaketAyranMikAd\" as \"Paketlenen Ayran Miktarı(Adet)\", T1.\"U_PaketAyranMikLt\" as \"Paketlenen Ayran Miktarı(LT)\" FROM \"@AIF_AYRNOZTTMYGL\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRNOZTTMYGL1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_UretimTarihi\" = '" + tarih1 + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgPaketlemeBilgileri1.DataSource = dt;
            dtPaketlemeBilgileri = dt;

            dtgPaketlemeBilgileri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgPaketlemeBilgileri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgPaketlemeBilgileri1.EnableHeadersVisualStyles = false;
            dtgPaketlemeBilgileri1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            foreach (DataGridViewColumn col in dtgPaketlemeBilgileri1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Paketlenen Ayran Miktarı(Adet)"] = Convert.ToString("0", cultureTR);
                dr["Paketlenen Ayran Miktarı(LT)"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }

            dtgPaketlemeBilgileri1.Columns["Paketlenen Ayran Miktarı(Adet)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgPaketlemeBilgileri1.Columns["Paketlenen Ayran Miktarı(Adet)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgPaketlemeBilgileri1.Columns["Paketlenen Ayran Miktarı(LT)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgPaketlemeBilgileri1.Columns["Paketlenen Ayran Miktarı(LT)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgPaketlemeBilgileri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgPaketlemeBilgileri1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOz.Rows[0].Height = dtgMamulOz.Height - dtgMamulOz.ColumnHeadersHeight;
            //dtgMamulOz.AutoResizeColumns();
        }

        private void dtgPaketlemeBilgileri2Load()
        {
            string sql = "SELECT \"U_ToplamSutMik\" as \"Toplam Süt Miktarı\", T1.\"U_ToplamSuMik\" as \"Toplam Su Miktarı\", T1.\"U_TuzMiktari\" as \"Tuz Miktarı\", T1.\"U_AyranTuzOrani\" as \"Ayran Tuz Oranı\", T1.\"U_ToplamAyranMik\" as \"Toplam Ayran Miktarı\" FROM \"@AIF_AYRNOZTTMYGL\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRNOZTTMYGL2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_UretimTarihi\" = '" + tarih1 + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgPaketlemeBilgileri2.DataSource = dt;

            dtgPaketlemeBilgileri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgPaketlemeBilgileri2.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgPaketlemeBilgileri2.EnableHeadersVisualStyles = false;
            dtgPaketlemeBilgileri2.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            foreach (DataGridViewColumn col in dtgPaketlemeBilgileri2.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Toplam Süt Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Toplam Su Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Tuz Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Ayran Tuz Oranı"] = Convert.ToString("0", cultureTR);
                dr["Toplam Ayran Miktarı"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }

            dtgPaketlemeBilgileri2.Columns["Toplam Süt Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgPaketlemeBilgileri2.Columns["Toplam Süt Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgPaketlemeBilgileri2.Columns["Toplam Su Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgPaketlemeBilgileri2.Columns["Toplam Su Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgPaketlemeBilgileri2.Columns["Tuz Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgPaketlemeBilgileri2.Columns["Tuz Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgPaketlemeBilgileri2.Columns["Ayran Tuz Oranı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgPaketlemeBilgileri2.Columns["Ayran Tuz Oranı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgPaketlemeBilgileri2.Columns["Toplam Ayran Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgPaketlemeBilgileri2.Columns["Toplam Ayran Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgPaketlemeBilgileri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgPaketlemeBilgileri2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOz.Rows[0].Height = dtgMamulOz.Height - dtgMamulOz.ColumnHeadersHeight;
            //dtgMamulOz.AutoResizeColumns();
        }

        private void dtgGunSonuOzetLoad()
        {
            string sql = "SELECT \"U_MayalananAyranMik\" as \"Mayalanan Ayran Miktarı\", T1.\"U_OncekiGundenDevMik\" as \"Önceki Günden Devreden Ayran Miktarı\", T1.\"U_TanktakiToplamMik\" as \"Tanktaki Toplam Ayran Miktarı\", T1.\"U_PaketTankFarki\" as \"Paketlenen - Tanktaki Miktar Farkı\", T1.\"U_SonrakiGuneDevMik\" as \"Sonraki Güne Devreden Ayran Miktarı\",T1.\"U_GunSonuAyranFarki\" as \"Gün Sonu Ayran Farkı\",T1.\"U_StandartRandiman\" as \"Standart Randıman Değeri\",T1.\"U_GerceklesenRandiman\" as \"Gerçekleşen Randıman Değeri\" FROM \"@AIF_AYRNOZTTMYGL\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRNOZTTMYGL3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_UretimTarihi\" = '" + tarih1 + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgGunSonuOzet.DataSource = dt;

            dtgGunSonuOzet.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgGunSonuOzet.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgGunSonuOzet.EnableHeadersVisualStyles = false;
            dtgGunSonuOzet.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            foreach (DataGridViewColumn col in dtgGunSonuOzet.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Mayalanan Ayran Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Önceki Günden Devreden Ayran Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Tanktaki Toplam Ayran Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Paketlenen - Tanktaki Miktar Farkı"] = Convert.ToString("0", cultureTR);
                dr["Sonraki Güne Devreden Ayran Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Gün Sonu Ayran Farkı"] = Convert.ToString("0", cultureTR);
                dr["Standart Randıman Değeri"] = Convert.ToString("0", cultureTR);
                dr["Gerçekleşen Randıman Değeri"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }

            dtgGunSonuOzet.Columns["Mayalanan Ayran Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGunSonuOzet.Columns["Mayalanan Ayran Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgGunSonuOzet.Columns["Önceki Günden Devreden Ayran Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGunSonuOzet.Columns["Önceki Günden Devreden Ayran Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgGunSonuOzet.Columns["Tanktaki Toplam Ayran Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGunSonuOzet.Columns["Tanktaki Toplam Ayran Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgGunSonuOzet.Columns["Paketlenen - Tanktaki Miktar Farkı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGunSonuOzet.Columns["Paketlenen - Tanktaki Miktar Farkı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgGunSonuOzet.Columns["Sonraki Güne Devreden Ayran Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGunSonuOzet.Columns["Sonraki Güne Devreden Ayran Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgGunSonuOzet.Columns["Gün Sonu Ayran Farkı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGunSonuOzet.Columns["Gün Sonu Ayran Farkı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgGunSonuOzet.Columns["Standart Randıman Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGunSonuOzet.Columns["Standart Randıman Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgGunSonuOzet.Columns["Gerçekleşen Randıman Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgGunSonuOzet.Columns["Gerçekleşen Randıman Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgGunSonuOzet.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgGunSonuOzet.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOz.Rows[0].Height = dtgMamulOz.Height - dtgMamulOz.ColumnHeadersHeight;
            //dtgMamulOz.AutoResizeColumns();
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            UVTServiceSoapClient client = new UVTServiceSoapClient();
            TamYagliAyranGunlukOzet nesne = new TamYagliAyranGunlukOzet();

            TamYagliPaketlemeBilgileri1 tamYagliPaketlemeBilgileri1 = new TamYagliPaketlemeBilgileri1();
            List<TamYagliPaketlemeBilgileri1> tamYagliPaketlemeBilgileri1s = new List<TamYagliPaketlemeBilgileri1>();
            TamYagliPaketlemeBilgileri2 tamYagliPaketlemeBilgileri2 = new TamYagliPaketlemeBilgileri2();
            List<TamYagliPaketlemeBilgileri2> tamYagliPaketlemeBilgileri2s = new List<TamYagliPaketlemeBilgileri2>();
            TamYagliGunlukOzet tamYagliGunlukOzet = new TamYagliGunlukOzet();
            List<TamYagliGunlukOzet> tamYagliGunlukOzets = new List<TamYagliGunlukOzet>();

            nesne.UretimTarihi = tarih1;
            nesne.UretimVardiyasi = "";
            nesne.Aciklama = richtxtBoxAciklama.Text;
            foreach (DataGridViewRow dr in dtgPaketlemeBilgileri1.Rows)
            {
                tamYagliPaketlemeBilgileri1 = new TamYagliPaketlemeBilgileri1();
                tamYagliPaketlemeBilgileri1.UrunKodu = dr.Cells["Ürün Kodu"].Value == DBNull.Value ? "" : dr.Cells["Ürün Kodu"].Value.ToString();

                if (tamYagliPaketlemeBilgileri1.UrunKodu == "")
                {
                    continue;
                }

                tamYagliPaketlemeBilgileri1.UrunAdi = dr.Cells["Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Ürün Adı"].Value.ToString();
                tamYagliPaketlemeBilgileri1.PaketlenenAyranMiktariAdet = dr.Cells["Paketlenen Ayran Miktarı(Adet)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Paketlenen Ayran Miktarı(Adet)"].Value);
                tamYagliPaketlemeBilgileri1.PaketlenenAyranMiktariLitre = dr.Cells["Paketlenen Ayran Miktarı(LT)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Paketlenen Ayran Miktarı(LT)"].Value);

                tamYagliPaketlemeBilgileri1s.Add(tamYagliPaketlemeBilgileri1);
            }

            nesne.tamYagliPaketlemeBilgileri1s = tamYagliPaketlemeBilgileri1s.ToArray();

            foreach (DataGridViewRow dr in dtgPaketlemeBilgileri2.Rows)
            {
                tamYagliPaketlemeBilgileri2 = new TamYagliPaketlemeBilgileri2();
                tamYagliPaketlemeBilgileri2.ToplamSutMiktari = dr.Cells["Toplam Süt Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Süt Miktarı"].Value);
                tamYagliPaketlemeBilgileri2.ToplamSuMiktari = dr.Cells["Toplam Su Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Su Miktarı"].Value);
                tamYagliPaketlemeBilgileri2.TuzMiktari = dr.Cells["Tuz Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tuz Miktarı"].Value);
                tamYagliPaketlemeBilgileri2.AyranTuzOrani = dr.Cells["Ayran Tuz Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Ayran Tuz Oranı"].Value);
                tamYagliPaketlemeBilgileri2.AyranTuzOrani = dr.Cells["Toplam Ayran Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Ayran Miktarı"].Value);

                tamYagliPaketlemeBilgileri2s.Add(tamYagliPaketlemeBilgileri2);
            }

            nesne.tamYagliPaketlemeBilgileri2s = tamYagliPaketlemeBilgileri2s.ToArray();

            foreach (DataGridViewRow dr in dtgGunSonuOzet.Rows)
            {
                tamYagliGunlukOzet = new TamYagliGunlukOzet();
                tamYagliGunlukOzet.MayalananAyranMiktari = dr.Cells["Mayalanan Ayran Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Mayalanan Ayran Miktarı"].Value);
                tamYagliGunlukOzet.OncekiGundenDevredenAyranMiktari = dr.Cells["Önceki Günden Devreden Ayran Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Önceki Günden Devreden Ayran Miktarı"].Value);
                tamYagliGunlukOzet.TanktakiToplamAyranMiktari = dr.Cells["Tanktaki Toplam Ayran Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tanktaki Toplam Ayran Miktarı"].Value);
                tamYagliGunlukOzet.PaketlenenVeTanktakiAyranFarki = dr.Cells["Paketlenen - Tanktaki Miktar Farkı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Paketlenen - Tanktaki Miktar Farkı"].Value);
                tamYagliGunlukOzet.SonrakiGuneDevredenAyranMiktari = dr.Cells["Sonraki Güne Devreden Ayran Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Sonraki Güne Devreden Ayran Miktarı"].Value);
                tamYagliGunlukOzet.GunSonuAyranFarki = dr.Cells["Gün Sonu Ayran Farkı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Gün Sonu Ayran Farkı"].Value);
                tamYagliGunlukOzet.StandartRandimanDegeri = dr.Cells["Standart Randıman Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Standart Randıman Değeri"].Value);
                tamYagliGunlukOzet.GerceklesenRandimanDegeri = dr.Cells["Gerçekleşen Randıman Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Gerçekleşen Randıman Değeri"].Value);

                tamYagliGunlukOzets.Add(tamYagliGunlukOzet);
            }

            nesne.tamYagliGunlukOzets = tamYagliGunlukOzets.ToArray();

            var resp = client.AddOrUpdateTamYagliAyranOzet(nesne, Giris.dbName, Giris.mKodValue);

            CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

            if (resp.Value == 0)
            {
                //btnOzetEkranaDon.PerformClick();
            }
        }

        private void dtgPaketlemeBilgileri1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgPaketlemeBilgileri1.Columns[e.ColumnIndex].Name == "Paketlenen Ayran Miktarı(Adet)" || dtgPaketlemeBilgileri1.Columns[e.ColumnIndex].Name == "Paketlenen Ayran Miktarı(LT)")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgPaketlemeBilgileri1, false);
                n.ShowDialog();
            }
            else if (dtgPaketlemeBilgileri1.Columns[e.ColumnIndex].Name == "Ürün Adı")
            {
                string sql1 = "Select TOP 1 '' as \"Kalem Kodu\",'' as \"Kalem Adı\" FROM OITM WITH (NOLOCK) ";
                sql1 += " UNION ALL ";
                sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM WITH (NOLOCK) ";

                SelectList selectList = new SelectList(sql1, dtgPaketlemeBilgileri1, 0, 1, _autoresizerow: true);
                selectList.ShowDialog();

                var sonSatir = dtgPaketlemeBilgileri1.Rows[dtgPaketlemeBilgileri1.RowCount - 1].Cells[e.ColumnIndex].Value.ToString();

                if (sonSatir != "")
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dtPaketlemeBilgileri.NewRow();
                    dr["Ürün Kodu"] = "";
                    dr["Ürün Adı"] = "";
                    dr["Paketlenen Ayran Miktarı(Adet)"] = Convert.ToString("0", cultureTR);
                    dr["Paketlenen Ayran Miktarı(LT)"] = Convert.ToString("0", cultureTR);

                    dtPaketlemeBilgileri.Rows.Add(dr);
                }
            }
        }

        private void dtgPaketlemeBilgileri2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgPaketlemeBilgileri2.Columns[e.ColumnIndex].Name == "Toplam Süt Miktarı" || dtgPaketlemeBilgileri2.Columns[e.ColumnIndex].Name == "Toplam Su Miktarı" || dtgPaketlemeBilgileri2.Columns[e.ColumnIndex].Name == "Tuz Miktarı" || dtgPaketlemeBilgileri2.Columns[e.ColumnIndex].Name == "Ayran Tuz Oranı" || dtgPaketlemeBilgileri2.Columns[e.ColumnIndex].Name == "Toplam Ayran Miktarı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgPaketlemeBilgileri2, false);
                n.ShowDialog();
            }
        }

        private void dtgGunSonuOzet_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgGunSonuOzet.Columns[e.ColumnIndex].Name == "Mayalanan Ayran Miktarı" || dtgGunSonuOzet.Columns[e.ColumnIndex].Name == "Önceki Günden Devreden Ayran Miktarı" || dtgGunSonuOzet.Columns[e.ColumnIndex].Name == "Tanktaki Toplam Ayran Miktarı" || dtgGunSonuOzet.Columns[e.ColumnIndex].Name == "Paketlenen - Tanktaki Miktar Farkı" || dtgGunSonuOzet.Columns[e.ColumnIndex].Name == "Sonraki Güne Devreden Ayran Miktarı" || dtgGunSonuOzet.Columns[e.ColumnIndex].Name == "Gün Sonu Ayran Farkı" || dtgGunSonuOzet.Columns[e.ColumnIndex].Name == "Standart Randıman Değeri" || dtgGunSonuOzet.Columns[e.ColumnIndex].Name == "Gerçekleşen Randıman Değeri")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgGunSonuOzet, false);
                n.ShowDialog();
            }
        }

        public static Form AyranGunlukOzet1Formu = null;

        private void btnYarimYagliAyran_Click(object sender, EventArgs e)
        {
            if (AyranGunlukOzet_2.AyranGunlukOzet2Formu == null)
            {
                AyranGunlukOzet_2 n2 = new AyranGunlukOzet_2(type, kullaniciid, "", "", 0, tarih1);
                n2.Show();
            }
            else
            {
                AyranGunlukOzet_2.AyranGunlukOzet2Formu.Activate();
            }
        }

        private void btnYardimciMalzeme_Click(object sender, EventArgs e)
        {
            if (AyranGunlukOzet_3.AyranGunlukOzet3Formu == null)
            {
                AyranGunlukOzet_3 n2 = new AyranGunlukOzet_3(type, kullaniciid, "", "", 0, tarih1);
                n2.Show();
            }
            else
            {
                AyranGunlukOzet_3.AyranGunlukOzet3Formu.Activate();
            }
        }

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }
    }
}
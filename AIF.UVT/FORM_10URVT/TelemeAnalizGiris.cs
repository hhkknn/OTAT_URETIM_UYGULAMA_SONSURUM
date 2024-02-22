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
    public partial class TelemeAnalizGiris : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //font end
        public TelemeAnalizGiris(string _type, string _kullaniciid, string _uretimSiparisNo, string _partiNo, string _urunTanimi, string _urunKodu, string _istasyon, int _row, int _width, int _height, string _tarih1)
        {
            kullaniciid = _kullaniciid;
            type = _type;
            uretimFisNo = _uretimSiparisNo;
            partiNo = _partiNo;
            urunTanimi = _urunTanimi;
            urunKodu = _urunKodu;
            istasyon = _istasyon;
            row = _row;
            tarih1 = _tarih1;
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            // Değişkenlerin başlangıç boyutunu ayarlar
            initialWidth = _width;
            initialHeight = _height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            initialFontSize = label3.Font.Size;
            label3.Resize += Form_Resize;

            initialFontSize = textBox1.Font.Size;
            textBox1.Resize += Form_Resize;

            initialFontSize = textBox2.Font.Size;
            textBox2.Resize += Form_Resize;

            initialFontSize = textBox3.Font.Size;
            textBox3.Resize += Form_Resize;

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

            initialFontSize = button7.Font.Size;
            button7.Resize += Form_Resize;

            initialFontSize = dtSutOz.Font.Size;
            dtSutOz.Resize += Form_Resize;

            initialFontSize = dtProses.Font.Size;
            dtProses.Resize += Form_Resize;

            initialFontSize = dtSonUrunOz.Font.Size;
            dtSonUrunOz.Resize += Form_Resize;

            initialFontSize = dtKullanilanMalz.Font.Size;
            dtKullanilanMalz.Resize += Form_Resize;
            //font end
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            // Yeniden boyutlandırma oranını alır
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            // Geçerli yazı tipi boyutunu hesaplar
            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label3.Font.Style);

            textBox1.Font = new Font(textBox1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox1.Font.Style);

            textBox2.Font = new Font(textBox2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox2.Font.Style);

            textBox3.Font = new Font(textBox3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox3.Font.Style);

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

            button7.Font = new Font(button7.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button7.Font.Style);

            dtSutOz.Font = new Font(dtSutOz.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               dtSutOz.Font.Style);

            dtProses.Font = new Font(dtProses.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               dtProses.Font.Style);

            dtSonUrunOz.Font = new Font(dtSonUrunOz.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               dtSonUrunOz.Font.Style);

            dtKullanilanMalz.Font = new Font(dtKullanilanMalz.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               dtKullanilanMalz.Font.Style);

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              label4.Font.Style);

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimTarihi.Font.Style);
            ResumeLayout();
            //font end
        }

        private string type = "";
        private string kullaniciid = "";
        private string urunTanimi = "";
        private string uretimFisNo = "";
        private string partiNo = "";
        private string urunKodu = "";
        private string istasyon = "";
        private int row = 0;
        private string tarih1 = "";

        private void TelemeAnalizGiris_Load(object sender, EventArgs e)
        {
            //commit test.
            textBox1.Text = uretimFisNo;
            textBox2.Text = partiNo;
            textBox3.Text = urunTanimi;
            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);

            SutUrunOzellikleriGetir();
            ProsesOzellikleriGetir();
            SonUrunOzellikleriGetir();
            KullanilanMalzemeleriGetir();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }

        private SqlCommand cmd = null;

        private void SutUrunOzellikleriGetir()
        {
            try
            {
                string sql = "Select (select T1.Descr from CUFD as T0 WITH (NOLOCK) INNER JOIN UFD1 as T1 WITH (NOLOCK) ON T0.TableID = T1.TableID and T0.FieldID=T1.FieldID where T0.AliasID = 'TelemeTuru' and T1.\"FldValue\" = \"U_TelemeTuru\") as \"Teleme Türü\",\"U_TelemeTuru\" as \"Teleme Türü Kodu\",(Select firstName + ' ' + lastName from OHEM WITH (NOLOCK) where \"empID\" = \"U_GorevliOperator\") as \"Görevli Operatör\",\"U_GorevliOperator\" as \"Görevli Operatör Kodu\",\"U_NetSutMiktar\" as \"Net Süt Miktar\",\"U_SutKaynagi\" as \"Sütün Kaynağı\",\"U_SutBicSevFark\" as \"Bıçak Seviyesinden Farkı\",\"U_PastorSicakligi\" as \"Pastör Sıcaklığı (C)\",\"U_KuruMadde\" as \"Kuru Madde (Etüv)(%)\",\"U_Yag\" as \"Yağ\",\"U_PH\" as \"PH\",\"U_SH\" as \"SH\",\"U_Protein\" as \"Protein (%)\" from \"@AIF_TLM_ANALIZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_TLM_ANALIZ1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                //Commit
                dtSutOz.DataSource = dt;

                DataGridViewButtonColumn RemoveLineButton = new DataGridViewButtonColumn();
                if (dtSutOz.Columns.Contains("Sil") != true)
                {
                    RemoveLineButton.Name = "Sil";
                    RemoveLineButton.Text = "Sil";
                    if (dtSutOz.Columns["removeButton"] == null)
                    {
                        dtSutOz.Columns.Insert(dtSutOz.Columns.Count, RemoveLineButton);
                    }
                }

                if (dtSutOz.Rows.Count > 0)
                {
                    dtSutOz.Columns["Net Süt Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSutOz.Columns["Net Süt Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSutOz.Columns["Bıçak Seviyesinden Farkı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSutOz.Columns["Bıçak Seviyesinden Farkı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSutOz.Columns["Pastör Sıcaklığı (C)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSutOz.Columns["Pastör Sıcaklığı (C)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSutOz.Columns["Kuru Madde (Etüv)(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSutOz.Columns["Kuru Madde (Etüv)(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSutOz.Columns["Yağ"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSutOz.Columns["Yağ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSutOz.Columns["PH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSutOz.Columns["PH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSutOz.Columns["SH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSutOz.Columns["SH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSutOz.Columns["Protein (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSutOz.Columns["Protein (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                //dtSutOz.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
                dtSutOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtSutOz.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dtSutOz.EnableHeadersVisualStyles = false;
                dtSutOz.DefaultCellStyle.BackColor = Color.LightGray;
                foreach (DataGridViewColumn col in dtSutOz.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Bahnschrift", dtSutOz.Font.Size, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                for (int ix = 0; ix <= dtSutOz.Columns.Count - 1; ix++)
                {
                    dtSutOz.Columns[ix].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                sql = "Select \"U_Aciklama\" from \"@AIF_TLM_ANALIZ\" WITH (NOLOCK) where \"U_PartiNo\" = '" + partiNo + "'";

                cmd = new SqlCommand(sql, Connection.sql);

                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                sda.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    textBox4.Text = dt.Rows[0][0].ToString();
                }

                dtSutOz.Columns["Teleme Türü Kodu"].Visible = false;
                dtSutOz.Columns["Görevli Operatör Kodu"].Visible = false;

                foreach (DataGridViewColumn column in dtSutOz.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Süt Özellikleri yüklenirken hata oluştu. Hata Kodu: TLMSUTOZANLZ001 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void ProsesOzellikleriGetir()
        {
            try
            {
                string sql = "Select \"U_MayalamaSicakligi\" as \"Mayalama Sıcaklığı\",\"U_MayalamaSuresi\" as \"Mayalama Süresi\",\"U_CedarlamaSicakligi\" as \"Çedarlama Sıcaklığı\",\"U_CedarlamaSuresi\" as \"Çedarlama Süresi\",\"U_TelemeIndPH\" as \"Teleme İndirildiğinde PH\" from \"@AIF_TLM_ANALIZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_TLM_ANALIZ2\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                //Commit
                dtProses.DataSource = dt;

                DataGridViewButtonColumn RemoveLineButton = new DataGridViewButtonColumn();
                if (dtProses.Columns.Contains("Sil") != true)
                {
                    RemoveLineButton.Name = "Sil";
                    RemoveLineButton.Text = "Sil";
                    if (dtProses.Columns["removeButton"] == null)
                    {
                        dtProses.Columns.Insert(dtProses.Columns.Count, RemoveLineButton);
                    }
                }

                if (dtProses.Rows.Count > 0)
                {
                    dtProses.Columns["Mayalama Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtProses.Columns["Mayalama Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProses.Columns["Mayalama Süresi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtProses.Columns["Mayalama Süresi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProses.Columns["Çedarlama Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtProses.Columns["Çedarlama Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProses.Columns["Çedarlama Süresi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtProses.Columns["Çedarlama Süresi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtProses.Columns["Teleme İndirildiğinde PH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtProses.Columns["Teleme İndirildiğinde PH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                //dtProses.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
                dtProses.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtProses.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dtProses.EnableHeadersVisualStyles = false;
                dtProses.DefaultCellStyle.BackColor = Color.LightGray;
                foreach (DataGridViewColumn col in dtProses.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Bahnschrift", dtProses.Font.Size, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                for (int ix = 0; ix <= dtProses.Columns.Count - 1; ix++)
                {
                    dtProses.Columns[ix].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                foreach (DataGridViewColumn column in dtProses.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                 CustomMsgBtn.Show("Proses Özellikleri yüklenirken hata oluştu. Hata Kodu: TLMPRSOZANLZ001 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void SonUrunOzellikleriGetir()
        {
            try
            {
                string sql = "Select \"U_KuruMadde\" as \"Kuru Madde (Etüv)(%)\", \"U_Yag\" as \"Yağ (%)\", \"U_PH\" as \"PH\", \"U_SH\" as \"SH\", \"U_PasBrix\" as \"Pas Brix Değeri\",\"U_TelemeMiktari\" as \"Üretilen Teleme Miktarı (KG)\", \"U_RandimanDegeri\" as \"Randıman Değeri (%)\" from \"@AIF_TLM_ANALIZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_TLM_ANALIZ3\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                //Commit
                dtSonUrunOz.DataSource = dt;

                DataGridViewButtonColumn RemoveLineButton = new DataGridViewButtonColumn();
                if (dtSonUrunOz.Columns.Contains("Sil") != true)
                {
                    RemoveLineButton.Name = "Sil";
                    RemoveLineButton.Text = "Sil";
                    if (dtSonUrunOz.Columns["removeButton"] == null)
                    {
                        dtSonUrunOz.Columns.Insert(dtSonUrunOz.Columns.Count, RemoveLineButton);
                    }
                }

                if (dtSonUrunOz.Rows.Count > 0)
                {
                    dtSonUrunOz.Columns["Kuru Madde (Etüv)(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSonUrunOz.Columns["Kuru Madde (Etüv)(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSonUrunOz.Columns["Yağ (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSonUrunOz.Columns["Yağ (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSonUrunOz.Columns["PH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSonUrunOz.Columns["PH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSonUrunOz.Columns["SH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSonUrunOz.Columns["SH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSonUrunOz.Columns["Pas Brix Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSonUrunOz.Columns["Pas Brix Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSonUrunOz.Columns["Üretilen Teleme Miktarı (KG)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSonUrunOz.Columns["Üretilen Teleme Miktarı (KG)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dtSonUrunOz.Columns["Randıman Değeri (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dtSonUrunOz.Columns["Randıman Değeri (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }

                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                //dtSonUrunOz.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
                dtSonUrunOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtSonUrunOz.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dtSonUrunOz.EnableHeadersVisualStyles = false;
                dtSonUrunOz.DefaultCellStyle.BackColor = Color.LightGray;
                foreach (DataGridViewColumn col in dtSonUrunOz.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Bahnschrift", dtSonUrunOz.Font.Size, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                for (int ix = 0; ix <= dtSonUrunOz.Columns.Count - 1; ix++)
                {
                    dtSonUrunOz.Columns[ix].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                foreach (DataGridViewColumn column in dtSonUrunOz.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Son Ürün Özellikleri yüklenirken hata oluştu. Hata Kodu: TLMSONURNOZANLZ001 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void KullanilanMalzemeleriGetir()
        {
            try
            {
                string sql = "SELECT T0.[ItemCode] as \"Malzeme Kodu\", T0.[ItemName] as \"Malzeme Tanımı\", T0.[BatchNum] as \"Parti\", T0.[Quantity] as \"Miktar\" FROM IBT1 T0 WITH (NOLOCK) left join OIGE T1 WITH (NOLOCK) on T0.[BaseEntry] = T1.[DocNum] WHERE T0.[BaseType] = 60 and  T1.[U_BatchNumber] ='" + partiNo + "'";

                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                //Commit
                dtKullanilanMalz.DataSource = dt;
                //dtSonUrunOz.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                //dtSonUrunOz.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                //dtKullanilanMalz.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
                dtKullanilanMalz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dtKullanilanMalz.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dtKullanilanMalz.EnableHeadersVisualStyles = false;
                dtKullanilanMalz.DefaultCellStyle.BackColor = Color.LightGray;
                foreach (DataGridViewColumn col in dtKullanilanMalz.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Bahnschrift", dtKullanilanMalz.Font.Size, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                for (int ix = 0; ix <= dtKullanilanMalz.Columns.Count - 1; ix++)
                {
                    dtKullanilanMalz.Columns[ix].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                foreach (DataGridViewColumn column in dtKullanilanMalz.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Kullanılan malzeme yüklenirken hata oluştu. Hata Kodu: TLMKULMALZ001 " + ex.Message, "UYARI", "TAMAM");
            }
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

        private void dtSutOz_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                try
                {
                    var senderGrid = (DataGridView)sender;

                    if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                        e.RowIndex >= 0)
                    {
                        dtSutOz.Rows.RemoveAt(e.RowIndex);
                    }
                }
                catch (Exception)
                {
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu(dtSutOz_CellContentClick). Hata Kodu: TLMANLZ004 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtSutOz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var columnType = dtSutOz.Columns[e.ColumnIndex].ValueType;
                if (e.RowIndex != -1)
                {
                    if (columnType != null)
                    {
                        if (columnType.FullName == "System.Decimal")
                        {
                            SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtSutOz);
                            n.ShowDialog();
                        }
                        else if (dtSutOz.Columns[e.ColumnIndex].Name == "Teleme Türü")
                        {
                            string sql = "select T1.FldValue as 'Kod',T1.Descr 'Açıklama' from CUFD as T0 WITH (NOLOCK) INNER JOIN UFD1 as T1 WITH (NOLOCK) ON T0.TableID = T1.TableID and T0.FieldID=T1.FieldID where T0.AliasID = 'TelemeTuru'";

                            SelectList selectList = new SelectList(sql, dtSutOz, 1, 0);
                            selectList.ShowDialog();
                        }
                        else if (dtSutOz.Columns[e.ColumnIndex].Name == "Görevli Operatör")
                        {
                            if (istasyon.StartsWith("IST"))
                            {
                                //string sql = "Select \"empID\" as \"Kullanıcı Kodu\", (\"firstName\" + ' ' + \"lastName\") as 'Ad Soyad' from OHEM where \"Active\" = 'Y'";

                                string field = "U_" + istasyon;
                                string sql = "Select \"U_PersonelNo\" as \"Personel No\",\"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"" + field + "\" = 'Y'";

                                SelectList selectList = new SelectList(sql, dtSutOz, 3, 2);
                                selectList.ShowDialog();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu(dtSutOz_CellClick). Hata Kodu: TLMANLZ002 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                TelemeAnalizTakibi nesne = new TelemeAnalizTakibi();
                SutOzellikleri sutOzellikleri = new SutOzellikleri();
                List<SutOzellikleri> sutOzellikleris = new List<SutOzellikleri>();
                ProsesOzellikleri prosesOzellikleri = new ProsesOzellikleri();
                List<ProsesOzellikleri> prosesOzellikleris = new List<ProsesOzellikleri>();
                SonUrunOzellikleri sonUrunOzellikleri = new SonUrunOzellikleri();
                List<SonUrunOzellikleri> sonUrunOzellikleris = new List<SonUrunOzellikleri>();

                nesne.PartiNo = textBox2.Text;
                nesne.UrunKodu = urunKodu;
                nesne.UrunTanimi = urunTanimi;
                nesne.Tarih = tarih1;
                nesne.Aciklama = textBox4.Text;

                foreach (DataGridViewRow dr in dtSutOz.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["Teleme Türü"].Value != null))
                {
                    sutOzellikleri.TelemeTuru = dr.Cells["Teleme Türü Kodu"].Value.ToString().NothingToString();
                    sutOzellikleri.GorevliOperator = dr.Cells["Görevli Operatör Kodu"].Value.ToString().NothingToString();
                    sutOzellikleri.GorevliOperatorAdi = dr.Cells["Görevli Operatör"].Value.ToString().NothingToString();
                    sutOzellikleri.NetSutMiktari = dr.Cells["Net Süt Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Net Süt Miktar"].Value);
                    sutOzellikleri.SutunKaynagi = dr.Cells["Sütün Kaynağı"].Value.ToString().NothingToString();
                    sutOzellikleri.SutunBicakSeviyesindenFarki = dr.Cells["Bıçak Seviyesinden Farkı"].Value == null ? 0 : Convert.ToDouble(dr.Cells["Bıçak Seviyesinden Farkı"].Value);
                    sutOzellikleri.PastorSicakligi = dr.Cells["Pastör Sıcaklığı (C)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastör Sıcaklığı (C)"].Value);
                    sutOzellikleri.KuruMadde = dr.Cells["Kuru Madde (Etüv)(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde (Etüv)(%)"].Value);
                    sutOzellikleri.Yag = dr.Cells["Yağ"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ"].Value);
                    sutOzellikleri.PH = dr.Cells["PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH"].Value);
                    sutOzellikleri.SH = dr.Cells["SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH"].Value);
                    sutOzellikleri.Protein = dr.Cells["Protein (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Protein (%)"].Value);

                    sutOzellikleris.Add(sutOzellikleri);
                    sutOzellikleri = new SutOzellikleri();
                }

                nesne.SutOzellikleri = sutOzellikleris.ToArray();

                foreach (DataGridViewRow dr in dtProses.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["Mayalama Sıcaklığı"].Value != null))
                {
                    prosesOzellikleri.MayalamaSicakigi = dr.Cells["Mayalama Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Mayalama Sıcaklığı"].Value);
                    prosesOzellikleri.MayalamaSuresi = dr.Cells["Mayalama Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Mayalama Süresi"].Value);
                    prosesOzellikleri.CedarlamaSicakligi = dr.Cells["Çedarlama Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çedarlama Sıcaklığı"].Value);
                    prosesOzellikleri.CedarlamaSuresi = dr.Cells["Çedarlama Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çedarlama Süresi"].Value);
                    prosesOzellikleri.TelemeIndirildigindekiPH = dr.Cells["Teleme İndirildiğinde PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Teleme İndirildiğinde PH"].Value);

                    prosesOzellikleris.Add(prosesOzellikleri);
                    prosesOzellikleri = new ProsesOzellikleri();
                }

                nesne.ProsesOzellikleri = prosesOzellikleris.ToArray();
                 
                foreach (DataGridViewRow dr in dtSonUrunOz.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["Kuru Madde (Etüv)(%)"].Value != null))
                {
                    sonUrunOzellikleri.KuruMadde = dr.Cells["Kuru Madde (Etüv)(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde (Etüv)(%)"].Value);
                    sonUrunOzellikleri.Yag = dr.Cells["Yağ (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ (%)"].Value);
                    sonUrunOzellikleri.PH = dr.Cells["PH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH"].Value);
                    sonUrunOzellikleri.SH = dr.Cells["SH"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH"].Value);
                    sonUrunOzellikleri.PasBrix = dr.Cells["Pas Brix Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pas Brix Değeri"].Value);
                    sonUrunOzellikleri.UretilenTLMMiktari = dr.Cells["Üretilen Teleme Miktarı (KG)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretilen Teleme Miktarı (KG)"].Value);
                    sonUrunOzellikleri.RandimanDegeri = dr.Cells["Randıman Değeri (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Randıman Değeri (%)"].Value);

                    sonUrunOzellikleris.Add(sonUrunOzellikleri);
                    sonUrunOzellikleri = new SonUrunOzellikleri();
                }

                nesne.SonUrunOzellikleri = sonUrunOzellikleris.ToArray();

                var resp = client.AddOrUpdateTelemeAnalizTakibi(nesne, Giris.dbName, Giris.mKodValue);

                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                if (resp.Value == 0)
                {
                    button1.PerformClick();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Onaylama işlemi yapılırken hata oluştu. Hata Kodu: TLMANLZ005 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(textBox4, textBox4.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();
        }

        private void dtProses_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var columnType = dtProses.Columns[e.ColumnIndex].ValueType;
                if (e.RowIndex != -1)
                {
                    if (columnType != null)
                    {
                        if (columnType.FullName == "System.Decimal")
                        {
                            SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtProses);
                            n.ShowDialog();
                            //var value = dtProses.Rows[dtProses.Rows.Count - 1].Cells[e.ColumnIndex].Value;
                            ////dtProses.Refresh();
                            //if (value != "")
                            //{
                            //    dtProses.Rows.Insert(dtProses.Rows.Count + 1);
                            //}
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu.(dtProses_CellClick) Hata Kodu: TLMANLZ007 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtSonUrunOz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var columnType = dtSonUrunOz.Columns[e.ColumnIndex].ValueType;
                if (e.RowIndex != -1)
                {
                    if (columnType != null)
                    {
                        if (columnType.FullName == "System.Decimal")
                        {
                            SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtSonUrunOz);
                            n.ShowDialog();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu.(dtSonUrunOz_CellClick) Hata Kodu: TLMANLZ009 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtProses_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    dtProses.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu.(dtProses_CellContentClick) Hata Kodu: TLMANLZ027 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtSonUrunOz_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    dtSonUrunOz.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu.(dtSonUrunOz_CellContentClick) Hata Kodu: TLMANLZ028 " + ex.Message, "UYARI", "TAMAM");
            }
        }
    }
}
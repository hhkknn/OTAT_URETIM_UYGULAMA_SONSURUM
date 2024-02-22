using AIF.UVT.DatabaseLayer;
using AIF.UVT.Library;
using AIF.UVT.UVTService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AIF.UVT
{
    public partial class TostPeynirProsesTakip_1 : Form
    {
        //font start.tasarım
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //font end
        public TostPeynirProsesTakip_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, int _width, int _height, string _tarih1, string _urunKodu)
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

            txtUretimSiparisNo.Font = new Font(txtUretimSiparisNo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimSiparisNo.Font.Style);

            txtPartyNo.Font = new Font(txtPartyNo.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtPartyNo.Font.Style);

            txtUrunTanimi.Font = new Font(txtUrunTanimi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUrunTanimi.Font.Style);

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

            btnOzetEkraniDon.Font = new Font(btnOzetEkraniDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkraniDon.Font.Style);

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
        private string urunKodu = "";
        private int row = 0;
        private SqlCommand cmd = null;
        private string tarih1 = "";


        public List<kontrolListesi> kontrolListesis = new List<kontrolListesi>();
        public class kontrolListesi
        {
            public string aktifKolon { get; set; }
            public string kontroledilmesigerekenKolon { get; set; }
        }

        public bool Kontrol(string _kontroledilmesigerekenKolon, DataGridView dtg, DataGridView dtg2)
        {

            string temelkolon = kontrolListesis.Where(x => x.aktifKolon == _kontroledilmesigerekenKolon).Select(y => y.kontroledilmesigerekenKolon).FirstOrDefault();


            if (temelkolon != null)
            {
                string val = "";

                if (dtg2 != null)
                {
                    val = dtg2.Rows[dtg2.Rows.Count - 1].Cells[temelkolon].Value.ToString();
                }
                else
                {
                    val = dtg.Rows[dtg.CurrentCell.RowIndex].Cells[temelkolon].Value.ToString();
                }

                if (val == "")
                {
                    CustomMsgBtn.Show(temelkolon + " doldurulmadan " + _kontroledilmesigerekenKolon + " kolon doldurulamaz.", "UYARI", "TAMAM");
                    return false;
                }
                else
                {
                    try
                    {
                        double val2 = 0;

                        if (dtg2 != null)
                        {
                            val2 = Convert.ToDouble(dtg2.Rows[dtg2.Rows.Count - 1].Cells[temelkolon].Value);
                        }
                        else
                        {
                            val2 = Convert.ToDouble(dtg.Rows[dtg.CurrentCell.RowIndex].Cells[temelkolon].Value);
                        }
                        if (val2 == 0)
                        {
                            CustomMsgBtn.Show(temelkolon + " doldurulmadan " + _kontroledilmesigerekenKolon + " kolon doldurulamaz.", "UYARI", "TAMAM");
                            return false;
                        }
                    }
                    catch (Exception)
                    {
                    }
                }
            }



            return true;
        }
        private void TostPeynirProsesTakip_1_Load(object sender, EventArgs e)
        {

            //Stopwatch watch = new Stopwatch();     //  Ölçmek istediğimiz işlemin başlangıcına ekliyoruz.

            //watch.Start(); //  Ölçmek istediğimiz işlemin başlangıcına ekliyoruz.
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_TSTPRSS_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
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

            dtgProsesOzellikleri1Load();
            dtgProsesOzellikleri2Load();




            dtgHammamaddeMiktarVeOzellik(); 

            dtgSarfMalzemeKullanim();

            dtgMamulOzellikleri();

            DataGridViewColumn dataGridViewColumn = dtgHammaddeMiktar.Columns["Kuru Madde (%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgHammaddeMiktar.Columns["Kuru Madde (%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgHammaddeMiktar.Columns["Yağ Oranı (%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgHammaddeMiktar.Columns["PH Değeri"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgHammaddeMiktar.Columns["SH Değeri"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["Hammmade ve Sarf Malzeme Toplamı"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtgMamulOz.Columns["Kuru Madde(%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["Hamur Yağ Oranı(%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["Hamur PH Değeri"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgMamulOz.Columns["Kuru Madde Yağ Oranı(%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtgMamulOz.Columns["Üretilen Hamur"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;




            //watch.Stop();  //  Ölçmek istediğimiz işlemin sonuna ekliyoruz.

            //MessageBox.Show("Load Süresi : " + watch.Elapsed.Seconds);
        }

        private DataTable dtSarfMalzemeKullanim = new DataTable();
        private DataTable dtHammaddeMiktarveOzellik = new DataTable();
        private DataTable dtMamulOz = new DataTable();

        private void dtgProsesOzellikleri1Load()
        {
            string sql = "SELECT T1.\"U_PartiNo\" as \"Parti No\", T1.\"U_HamurTuru\" as \"Hamur Türü\", T1.\"U_GorevliOperator\" as \"Görevli Operatör\", T1.\"U_GorevliOperatorAdi\" as \"Görevli Operatör Adı\", T1.\"U_HammaddeYukBasSaat\" as \"Hammadde Yükleme Baş. Saat\", T1.\"U_HammaddeYukBitSaat\" as \"Hammadde Yükleme Bit. Saat\", T1.\"U_HamurPastorSicakligi\" as \"Hamur Pastor. Sıcaklığı\", T1.\"U_VakumSuresi\" as \"Vakum Süresi (DK)\", T1.\"U_PisirmeMakIndSaati\" as \"Pişirme Mak. Indirilme Saati\", T1.\"U_HamurGramajlamaBitSaat\" as \"Hamurun Gramajlama Bitiş Saati\" FROM \"@AIF_TSTPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TSTPRSS_ANLZ1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgProsesOzellikleri1.DataSource = dt;

            dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgProsesOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgProsesOzellikleri1.EnableHeadersVisualStyles = false;
            dtgProsesOzellikleri1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Parti No"] = partiNo;
                dr["Hamur Türü"] = txtUrunTanimi.Text;
                dr["Hamur Pastor. Sıcaklığı"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }

            dtgProsesOzellikleri1.Columns["Hamur Pastor. Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri1.Columns["Hamur Pastor. Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgProsesOzellikleri1.AutoResizeRows();

            dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgProsesOzellikleri1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgProsesOzellikleri1.Rows[0].Height = dtgProsesOzellikleri1.Height - dtgProsesOzellikleri1.ColumnHeadersHeight;
            dtgProsesOzellikleri1.AutoResizeColumns();

            #region Kontrol listesi oluşturma 

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Görevli Operatör Adı",
                kontroledilmesigerekenKolon = "Hamur Türü"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Hammadde Yükleme Baş. Saat",
                kontroledilmesigerekenKolon = "Görevli Operatör Adı"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Hammadde Yükleme Bit. Saat",
                kontroledilmesigerekenKolon = "Hammadde Yükleme Baş. Saat"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Hamur Pastor. Sıcaklığı",
                kontroledilmesigerekenKolon = "Hammadde Yükleme Bit. Saat"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Vakum Süresi (DK)",
                kontroledilmesigerekenKolon = "Hamur Pastor. Sıcaklığı"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pişirme Mak. Indirilme Saati",
                kontroledilmesigerekenKolon = "Vakum Süresi (DK)"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Hamurun Gramajlama Bitiş Saati",
                kontroledilmesigerekenKolon = "Pişirme Mak. Indirilme Saati"
            });


            #endregion
        }

        private void dtgProsesOzellikleri2Load()
        {
            string sql = "SELECT T1.\"U_HammaddeYukSureDk\" as \"Hammadde Yükleme Süresi (DK)\", T1.\"U_HamurPismeSuresiDk\" as \"Hamur Pişme Süresi (DK)\", T1.\"U_HamurGramajSureDk\" as \"Hamurun Gramajlanma Süresi (DK)\", T1.\"U_VakumSuresiDk\" as \"Vakum Süresi (DK)\", T1.\"U_ToplamGecenSureDk\" as \"Toplam Geçen Süre (DK)\" FROM \"@AIF_TSTPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TSTPRSS_ANLZ2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgProsesOzellikleri2.DataSource = dt;

            dtgProsesOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgProsesOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dtgProsesOzellikleri2.EnableHeadersVisualStyles = false;
            dtgProsesOzellikleri2.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add();
            }

            dtgProsesOzellikleri2.Columns["Hammadde Yükleme Süresi (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Hammadde Yükleme Süresi (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Hamur Pişme Süresi (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Hamur Pişme Süresi (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Hamurun Gramajlanma Süresi (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Hamurun Gramajlanma Süresi (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Vakum Süresi (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Vakum Süresi (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Toplam Geçen Süre (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Toplam Geçen Süre (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgProsesOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgProsesOzellikleri2.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgProsesOzellikleri2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgProsesOzellikleri2.Columns["Hamurun Gramajlanma Süresi (DK)"].HeaderText = "Hamurun Gramaj Süresi (DK)";

            dtgProsesOzellikleri2.Rows[0].Height = dtgProsesOzellikleri2.Height - dtgProsesOzellikleri2.ColumnHeadersHeight;
            dtgProsesOzellikleri2.AutoResizeColumns();
        }

        private void dtgHammamaddeMiktarVeOzellik()
        {
          
            string sql = "SELECT T1.\"U_MalzemeAdi\" as \"Malzeme Adı\", T1.\"U_KuruMadde\" as \"Kuru Madde (%)\", T1.\"U_YagOrani\" as \"Yağ Oranı (%)\", T1.\"U_PH\" as \"PH Değeri\", T1.\"U_SH\" as \"SH Değeri\",T1.\"U_HammaddePartiNo\" as \"Hammade Parti No\", T1.\"U_Miktar\" as \"Miktar\", T1.\"U_Birim\" as \"Birim\" FROM \"@AIF_TSTPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TSTPRSS_ANLZ3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgHammaddeMiktar.DataSource = dt;

            dtgHammaddeMiktar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgHammaddeMiktar.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgHammaddeMiktar.EnableHeadersVisualStyles = false;
            dtgHammaddeMiktar.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            if (dt.Rows.Count == 0)
            {
                sql = "select T0.ItemName as \"Malzeme Adı\",CardName as \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1 T0 WITH (NOLOCK) inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo + "') and ISNULL(T1.\"QryGroup1\",'')<>'Y'";
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
                    dr["Kuru Madde (%)"] = Convert.ToString("0", cultureTR);
                    dr["Yağ Oranı (%)"] = Convert.ToString("0", cultureTR);
                    dr["PH Değeri"] = Convert.ToString("0", cultureTR);
                    dr["SH Değeri"] = Convert.ToString("0", cultureTR);
                    dr["Miktar"] = Convert.ToString("0", cultureTR);
                    dr["Malzeme Adı"] = dr1["Malzeme Adı"].ToString();
                    dr["Hammade Parti No"] = dr1["Sarf Malzemesi Parti No"].ToString();
                    dr["Miktar"] = dr1["Miktar"].ToString();
                    dr["Birim"] = dr1["Birim"].ToString();

                    dt.Rows.Add(dr);
                }
            }

            dtHammaddeMiktarveOzellik = dt;

            dtgHammaddeMiktar.Columns["Kuru Madde (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgHammaddeMiktar.Columns["Kuru Madde (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgHammaddeMiktar.Columns["Yağ Oranı (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgHammaddeMiktar.Columns["Yağ Oranı (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgHammaddeMiktar.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgHammaddeMiktar.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgHammaddeMiktar.Columns["SH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgHammaddeMiktar.Columns["SH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgHammaddeMiktar.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgHammaddeMiktar.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgHammaddeMiktar.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgHammaddeMiktar.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgHammaddeMiktar.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
             

        }

        private void dtgSarfMalzemeKullanim()
        {
            string sql = "SELECT T1.\"U_MalzemeAdi\" as \"Malzeme Adı\",T1.\"U_MalMarkaTedarikci\" as \"Malzemenin Markası ve Tedarikçisi\",T1.\"U_SarfMalzemePartiNo\" as \"Sarf Malzemesi Parti No\",Convert(float,T1.\"U_Miktar\") as \"Miktar\",T1.\"U_Birim\" as \"Birim\" FROM \"@AIF_TSTPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TSTPRSS_ANLZ4\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

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

            dtgSarfMalzeme.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgSarfMalzeme.EnableHeadersVisualStyles = false;
            dtgSarfMalzeme.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            if (dt.Rows.Count == 0)
            {
                sql = "select T0.ItemName as \"Malzeme Adı\",CardName as \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1 T0 WITH (NOLOCK) inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo + "') and ISNULL(T1.\"QryGroup1\",'')='Y'";

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
                    dr["Malzemenin Markası ve Tedarikçisi"] = dr1["Malzemenin Markası ve Tedarikçisi"].ToString();
                    dr["Sarf Malzemesi Parti No"] = dr1["Sarf Malzemesi Parti No"].ToString();
                    dr["Miktar"] = Convert.ToDouble(dr1["Miktar"].ToString());
                    dr["Birim"] = dr1["Birim"].ToString();

                    dt.Rows.Add(dr);
                }
            }

            dtSarfMalzemeKullanim = dt;

            dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSarfMalzeme.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgSarfMalzeme.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgSarfMalzeme.AutoResizeRows();

            foreach (DataGridViewColumn column in dtgSarfMalzeme.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void dtgMamulOzellikleri()
        {
            string sql = "SELECT \"U_HammaddeSarfMalzTop\" as \"Hammmade ve Sarf Malzeme Toplamı\", ISNULL(T1.\"U_UretilenHamur\",0) as \"Üretilen Hamur\",  T1.\"U_UretilenUrunMik\" as \"Üretilen Ürün Miktarı (Adet)\", T1.\"U_UretilenUrunAdi\" as \"Üretilen Ürün Adı\", T1.\"U_KuruMadde\" as \"Kuru Madde(%)\", T1.\"U_HamurYagOrani\" as \"Hamur Yağ Oranı(%)\",ISNULL(T1.\"U_KuruMadYagOrn\",0) as \"Kuru Madde Yağ Oranı(%)\", T1.\"U_HamurPH\" as \"Hamur PH Değeri\" FROM \"@AIF_TSTPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TSTPRSS_ANLZ5\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dtMamulOz);

            //Commit
            dtgMamulOz.DataSource = dtMamulOz;

            dtgMamulOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgMamulOz.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgMamulOz.EnableHeadersVisualStyles = false;
            dtgMamulOz.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            if (dtMamulOz.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtMamulOz.NewRow();
                dr["Hammmade ve Sarf Malzeme Toplamı"] = Convert.ToString("0", cultureTR);
                dr["Üretilen Ürün Miktarı (Adet)"] = Convert.ToString("0", cultureTR);
                dr["Kuru Madde(%)"] = Convert.ToString("0", cultureTR);
                dr["Hamur Yağ Oranı(%)"] = Convert.ToString("0", cultureTR);
                dr["Hamur PH Değeri"] = Convert.ToString("0", cultureTR);
                dr["Kuru Madde Yağ Oranı(%)"] = Convert.ToString("0", cultureTR);
                dr["Üretilen Hamur"] = Convert.ToString("0", cultureTR);

                dtMamulOz.Rows.Add(dr);
            }

            dtgMamulOz.Columns["Hammmade ve Sarf Malzeme Toplamı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Hammmade ve Sarf Malzeme Toplamı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOz.Columns["Üretilen Ürün Miktarı (Adet)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Üretilen Ürün Miktarı (Adet)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOz.Columns["Kuru Madde(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Kuru Madde(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOz.Columns["Hamur Yağ Oranı(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Hamur Yağ Oranı(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOz.Columns["Hamur PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Hamur PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgMamulOz.Columns["Kuru Madde Yağ Oranı(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Kuru Madde Yağ Oranı(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgMamulOz.Columns["Üretilen Hamur"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOz.Columns["Üretilen Hamur"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgMamulOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgMamulOz.AutoResizeRows();

            foreach (DataGridViewColumn column in dtgMamulOz.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgMamulOz.Rows[0].Height = dtgMamulOz.Height - dtgMamulOz.ColumnHeadersHeight;
            dtgMamulOz.AutoResizeColumns();

            double dtHammaddeMiktar = Math.Round(Convert.ToDouble(dtHammaddeMiktarveOzellik.AsEnumerable().Sum(x => x.Field<decimal>("Miktar"))), Giris.OndalikMiktar);
            double dtSarfMalzemeKullanimMiktar = Math.Round(Convert.ToDouble(dtSarfMalzemeKullanim.AsEnumerable().Sum(x => x.Field<double>("Miktar"))), Giris.OndalikMiktar);
            var sonuc = dtHammaddeMiktar + dtSarfMalzemeKullanimMiktar;

            dtgMamulOz.Rows[0].Cells["Hammmade ve Sarf Malzeme Toplamı"].Value = sonuc.ToString();


            double kurumadde = Math.Round(Convert.ToDouble(dtMamulOz.AsEnumerable().Sum(x => x.Field<decimal>("Kuru Madde(%)"))), Giris.OndalikMiktar);
            double hamuryagorani = Math.Round(Convert.ToDouble(dtMamulOz.AsEnumerable().Sum(x => x.Field<decimal>("Hamur Yağ Oranı(%)"))), Giris.OndalikMiktar);

            if (kurumadde > 0)
            {
                double sonuc2 = (hamuryagorani / kurumadde) * 100;

                dtgMamulOz.Rows[0].Cells["Kuru Madde Yağ Oranı(%)"].Value = sonuc2.ToString("N" + Giris.OndalikMiktar);
            }



            #region Kontrol listesi oluşturma 

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Üretilen Ürün Miktarı (Adet)",
                kontroledilmesigerekenKolon = "Hamurun Gramajlama Bitiş Saati"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Üretilen Ürün Adı",
                kontroledilmesigerekenKolon = "Üretilen Ürün Miktarı (Adet)"
            });

            #endregion

            dtgMamulOz.Columns["Hammmade ve Sarf Malzeme Toplamı"].ReadOnly = true;
            dtgMamulOz.Columns["Kuru Madde Yağ Oranı(%)"].ReadOnly = true;
            dtgMamulOz.Columns["Üretilen Hamur"].ReadOnly = true;
            dtgMamulOz.Columns["Üretilen Ürün Adı"].ReadOnly = true;
        }

        private void dtgProsesOzellikleri2ToplamGecenSure()
        {
            var HammaddeYukSureDk = dtgProsesOzellikleri2.Rows[0].Cells["Hammadde Yükleme Süresi (DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2.Rows[0].Cells["Hammadde Yükleme Süresi (DK)"].Value);
            var HamurPismeSuresiDk = dtgProsesOzellikleri2.Rows[0].Cells["Hamur Pişme Süresi (DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2.Rows[0].Cells["Hamur Pişme Süresi (DK)"].Value);
            var HamurGramajSureDk = dtgProsesOzellikleri2.Rows[0].Cells["Hamurun Gramajlanma Süresi (DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2.Rows[0].Cells["Hamurun Gramajlanma Süresi (DK)"].Value);
            var VakumSuresiDk = dtgProsesOzellikleri2.Rows[0].Cells["Vakum Süresi (DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2.Rows[0].Cells["Vakum Süresi (DK)"].Value);

            var sonuc = HammaddeYukSureDk + HamurPismeSuresiDk + HamurGramajSureDk + VakumSuresiDk;
            dtgProsesOzellikleri2.Rows[0].Cells["Toplam Geçen Süre (DK)"].Value = sonuc.ToString();
        }

        private void dtgProsesOzellikleri1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool cvp = true;

                cvp = Kontrol(dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name, dtgProsesOzellikleri1, null);

                if (!cvp)
                {
                    return;
                }

                Tuple<DateTime, DateTime> resp = null;
                Helper help = new Helper();
                if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Hamur Pastor. Sıcaklığı" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Vakum Süresi (DK)")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1);
                    n.ShowDialog();

                    if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Vakum Süresi (DK)")
                    {
                        var Dakika = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Vakum Süresi (DK)"].Value.ToString();

                        if (Dakika != "")
                        {
                            if (Convert.ToDouble(Dakika) != 0)
                            {
                                dtgProsesOzellikleri2.Rows[0].Cells["Vakum Süresi (DK)"].Value = Dakika.ToString();
                            }
                        }
                    }

                    dtgProsesOzellikleri2ToplamGecenSure();
                }
                else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Hammadde Yükleme Baş. Saat" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Hammadde Yükleme Bit. Saat" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pişirme Mak. Indirilme Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Yıkama Bitiş Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Hamurun Gramajlama Bitiş Saati")
                {
                    SaatTarihGirisi n = new SaatTarihGirisi(dtgProsesOzellikleri1);
                    n.ShowDialog();

                    #region Hammadde Yükleme başlangıç bitiş

                    if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Hammadde Yükleme Baş. Saat" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Hammadde Yükleme Bit. Saat")
                    {
                        var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Hammadde Yükleme Baş. Saat"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Hammadde Yükleme Bit. Saat"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2.Rows[0].Cells["Hammadde Yükleme Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2.Rows[0].Cells["Hammadde Yükleme Süresi (DK)"].Value = "0";
                        }

                        dtgProsesOzellikleri2ToplamGecenSure();
                    }
                    else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pişirme Mak. Indirilme Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Hammadde Yükleme Bit. Saat")
                    {
                        var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Hammadde Yükleme Bit. Saat"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Pişirme Mak. Indirilme Saati"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2.Rows[0].Cells["Hamur Pişme Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2.Rows[0].Cells["Hamur Pişme Süresi (DK)"].Value = "0";
                        }

                        dtgProsesOzellikleri2ToplamGecenSure();
                    }
                    else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pişirme Mak. Indirilme Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Hammadde Yükleme Bit. Saat")
                    {
                        var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Hammadde Yükleme Bit. Saat"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Pişirme Mak. Indirilme Saati"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2.Rows[0].Cells["Hamur Pişme Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2.Rows[0].Cells["Hamur Pişme Süresi (DK)"].Value = "0";
                        }

                        dtgProsesOzellikleri2ToplamGecenSure();
                    }
                    else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pişirme Mak. Indirilme Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Hamurun Gramajlama Bitiş Saati")
                    {
                        var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Pişirme Mak. Indirilme Saati"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Hamurun Gramajlama Bitiş Saati"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2.Rows[0].Cells["Hamurun Gramajlanma Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2.Rows[0].Cells["Hamurun Gramajlanma Süresi (DK)"].Value = "0";
                        }
                        dtgProsesOzellikleri2ToplamGecenSure();
                    }

                    //else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Hammadde Yükleme Baş. Saat" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Hamurun Gramajlama Bitiş Saati")
                    //{
                    //    var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Hammadde Yükleme Baş. Saat"].Value.ToString();
                    //    var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Hamurun Gramajlama Bitiş Saati"].Value.ToString();

                    //    if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                    //    {
                    //        resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                    //        TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                    //        dtgProsesOzellikleri2.Rows[0].Cells["Toplam Geçen Süre (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                    //    }
                    //    else
                    //    {
                    //        dtgProsesOzellikleri2.Rows[0].Cells["Toplam Geçen Süre (DK)"].Value = "0";
                    //    }

                    //}

                    #endregion Hammadde Yükleme başlangıç bitiş
                }
                else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Görevli Operatör Adı")
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

                        SelectList selectList = new SelectList(sql, dtgProsesOzellikleri1, 2, 3, _autoresizerow: false);
                        selectList.ShowDialog();

                        //dtgProsesOzellikleri1.AutoResizeRows();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtgHammaddeMiktar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtgHammaddeMiktar.Columns[e.ColumnIndex].Name == "Kuru Madde (%)" || dtgHammaddeMiktar.Columns[e.ColumnIndex].Name == "Yağ Oranı (%)" || dtgHammaddeMiktar.Columns[e.ColumnIndex].Name == "PH Değeri" || dtgHammaddeMiktar.Columns[e.ColumnIndex].Name == "SH Değeri")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgHammaddeMiktar);
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
            }
            catch (Exception)
            {
            }
        }

        private void dtgMamulOz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                bool cvp = true;

                if (dtgMamulOz.Columns[e.ColumnIndex].Name == "Üretilen Ürün Miktarı (Adet)")
                {
                    cvp = Kontrol(dtgMamulOz.Columns[e.ColumnIndex].Name, dtgMamulOz, dtgProsesOzellikleri1);
                }
                else
                {
                    cvp = Kontrol(dtgMamulOz.Columns[e.ColumnIndex].Name, dtgMamulOz, null);
                }
                if (!cvp)
                {
                    return;
                }



                if (dtgMamulOz.Columns[e.ColumnIndex].Name == "Üretilen Ürün Miktarı (Adet)" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Kuru Madde(%)" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Hamur Yağ Oranı(%)" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Hamur PH Değeri")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOz);
                    n.ShowDialog();

                    if (dtgMamulOz.Columns[e.ColumnIndex].Name == "Kuru Madde(%)" || dtgMamulOz.Columns[e.ColumnIndex].Name == "Hamur Yağ Oranı(%)")
                    {
                        double kurumadde = parseNumber.parservalues<double>(dtgMamulOz.Rows[e.RowIndex].Cells["Kuru Madde(%)"].Value.ToString());
                        double hamuryagorani = parseNumber.parservalues<double>(dtgMamulOz.Rows[e.RowIndex].Cells["Hamur Yağ Oranı(%)"].Value.ToString());

                        if (kurumadde > 0)
                        {
                            double sonuc = (hamuryagorani / kurumadde) * 100;

                            dtgMamulOz.Rows[e.RowIndex].Cells["Kuru Madde Yağ Oranı(%)"].Value = sonuc.ToString("N" + Giris.OndalikMiktar);
                        }
                    }

                    #region üretilen hamur
                    if (dtgMamulOz.Columns[e.ColumnIndex].Name == "Üretilen Ürün Miktarı (Adet)")
                    {
                        string sqlBrut = "Select \"U_BrutAgirlik\" from \"OITM\" WITH (NOLOCK) where \"ItemCode\" = '" + SelectList.kalemKodu + "' ";
                        cmd = new SqlCommand(sqlBrut, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt_Brut = new DataTable();
                        sda.Fill(dt_Brut);

                        Connection.sql.Close();
                        if (dt_Brut.Rows[0][0] == DBNull.Value)
                        {
                            dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Hamur"].Value = 0.ToString("N" + Giris.OndalikMiktar);

                        }
                        if (dt_Brut.Rows.Count > 0)
                        {
                            double brut = Math.Round(Convert.ToDouble(dt_Brut.AsEnumerable().Sum(x => x.Field<decimal>("U_BrutAgirlik"))), Giris.OndalikMiktar);
                            double miktar = Math.Round(Convert.ToDouble(dtMamulOz.AsEnumerable().Sum(x => x.Field<decimal>("Üretilen Ürün Miktarı (Adet)"))), Giris.OndalikMiktar);


                            //double brut = parseNumber.parservalues<double>(dt_Brut.Rows[0][0].ToString());
                            //double miktar = parseNumber.parservalues<double>(dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Ürün Miktarı (Adet)"].Value.ToString());

                            double sonuc2 = brut * miktar;

                            dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Hamur"].Value = sonuc2;
                        }
                        else
                        {
                            dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Hamur"].Value = 0.ToString("N" + Giris.OndalikMiktar);

                        }
                    }
                    #endregion

                }
                else if (dtgMamulOz.Columns[e.ColumnIndex].Name == "Üretilen Ürün Adı")
                {
                    string sql_AnalizParam = "Select \"U_Deger1\",\"U_Deger2\" from \"@AIF_GNLKANLZPRM\" WITH (NOLOCK) where \"U_Kod\" ='7'";
                    cmd = new SqlCommand(sql_AnalizParam, Connection.sql);

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
                        string sql1 = "Select TOP 1 '' as \"Kalem Kodu\",'' as \"Kalem Adı\" FROM OITM WITH (NOLOCK) where \"U_ItemGroup2\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][1].ToString() + "' ";
                        sql1 += " UNION ALL ";
                        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM WITH (NOLOCK) where \"U_ItemGroup2\" = '" + dt_Sorgu.Rows[0][0].ToString() + "' and \"ItmsGrpCod\" = '" + dt_Sorgu.Rows[0][1].ToString() + "'";

                        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, e.ColumnIndex, _autoresizerow: false);
                        selectList.ShowDialog();

                        #region üretilen hamur 
                            string sqlBrut = "Select \"U_BrutAgirlik\" from \"OITM\" WITH (NOLOCK) where \"ItemCode\" = '" + SelectList.kalemKodu + "' ";
                            cmd = new SqlCommand(sqlBrut, Connection.sql);

                            if (Connection.sql.State != ConnectionState.Open)
                                Connection.sql.Open();

                            sda = new SqlDataAdapter(cmd);
                            DataTable dt_Brut = new DataTable();
                            sda.Fill(dt_Brut);

                            Connection.sql.Close();

                        if (dt_Brut.Rows[0][0] == DBNull.Value)
                        {
                            dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Hamur"].Value = 0.ToString("N" + Giris.OndalikMiktar);

                        }

                        if (dt_Brut.Rows.Count > 0)
                        {
                            double brut = Math.Round(Convert.ToDouble(dt_Brut.AsEnumerable().Sum(x => x.Field<decimal>("U_BrutAgirlik"))), Giris.OndalikMiktar);
                            double miktar = Math.Round(Convert.ToDouble(dtMamulOz.AsEnumerable().Sum(x => x.Field<decimal>("Üretilen Ürün Miktarı (Adet)"))), Giris.OndalikMiktar);


                            //double brut = parseNumber.parservalues<double>(dt_Brut.Rows[0][0].ToString());
                            //double miktar = parseNumber.parservalues<double>(dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Ürün Miktarı (Adet)"].Value.ToString());

                            double sonuc2 = brut * miktar;

                            dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Hamur"].Value = sonuc2;
                        }
                        else
                        {
                            dtgMamulOz.Rows[e.RowIndex].Cells["Üretilen Hamur"].Value = 0.ToString("N" + Giris.OndalikMiktar);
                        }
                        #endregion
                    }
                    else
                    {
                        CustomMsgBtn.Show("Üretilen Ürünler için parametre tablosu doldurulmamıştır.", "UYARI", "TAMAM");
                    }
                }

                #region eski listeleme sorguları 01.06.2022 tarihinde değiştirildi
                //else if (dtgMamulOz.Columns[e.ColumnIndex].Name == "Üretilen Ürün Adı")
                //{



                //    string sql1 = "Select TOP 1 '' as \"Kalem Kodu\",'' as \"Kalem Adı\" FROM OITM ";
                //    sql1 += " UNION ALL ";
                //    if (urunKodu == "YRM-40000")
                //    {
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-25000'";
                //        sql1 += " UNION ALL ";
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-25001'";

                //        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, e.ColumnIndex, _autoresizerow: false);
                //        selectList.ShowDialog();
                //    }
                //    else if (urunKodu == "YRM-40001")
                //    {
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-15004'";

                //        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, e.ColumnIndex, _autoresizerow: false);
                //        selectList.ShowDialog();
                //    }
                //    else if (urunKodu == "YRM-40002")
                //    {
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-15002'";

                //        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, e.ColumnIndex, _autoresizerow: false);
                //        selectList.ShowDialog();
                //    }
                //    else if (urunKodu == "YRM-40003")
                //    {
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-15000'";
                //        sql1 += " UNION ALL ";
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-15001'";
                //        sql1 += " UNION ALL ";
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-15003'";

                //        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, e.ColumnIndex, _autoresizerow: false);
                //        selectList.ShowDialog();
                //    }
                //    else if (urunKodu == "YRM-40004")
                //    {
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-35000'";

                //        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, e.ColumnIndex, _autoresizerow: false);
                //        selectList.ShowDialog();
                //    }
                //    else if (urunKodu == "YRM-40005")
                //    {
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-45003'";

                //        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, e.ColumnIndex, _autoresizerow: false);
                //        selectList.ShowDialog();
                //    }
                //    else if (urunKodu == "YRM-40006")
                //    {
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-45010'";
                //        sql1 += " UNION ALL ";
                //        sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM where \"ItemCode\" = 'MAM-45007'";

                //        SelectList selectList = new SelectList(sql1, dtgMamulOz, -1, e.ColumnIndex, _autoresizerow: false);
                //        selectList.ShowDialog();
                //    }
                //} 
                #endregion
            }
            catch (Exception ex)
            {
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                TostPeynirProsesTakipAnaliz nesne = new TostPeynirProsesTakipAnaliz();
                TostPeynirProssesOzellikleri1 tostPeynirProssesOzellikleri1 = new TostPeynirProssesOzellikleri1();
                List<TostPeynirProssesOzellikleri1> tostPeynirProssesOzellikleri1s = new List<TostPeynirProssesOzellikleri1>();
                TostPeynirProssesOzellikleri2 tostPeynirProssesOzellikleri2 = new TostPeynirProssesOzellikleri2();
                List<TostPeynirProssesOzellikleri2> tostPeynirProssesOzellikleri2s = new List<TostPeynirProssesOzellikleri2>();
                TostPeynirHammaddeMiktarVeOzellik tostPeynirHammaddeMiktarVeOzellik = new TostPeynirHammaddeMiktarVeOzellik();
                List<TostPeynirHammaddeMiktarVeOzellik> tostPeynirHammaddeMiktarVeOzelliks = new List<TostPeynirHammaddeMiktarVeOzellik>();
                TostPeynirSarfMalzemeKullanim tostPeynirSarfMalzemeKullanim = new TostPeynirSarfMalzemeKullanim();
                List<TostPeynirSarfMalzemeKullanim> tostPeynirSarfMalzemeKullanims = new List<TostPeynirSarfMalzemeKullanim>();
                TostPeynirMamulOzellikleri tostPeynirMamulOzellikleri = new TostPeynirMamulOzellikleri();
                List<TostPeynirMamulOzellikleri> tostPeynirMamulOzellikleris = new List<TostPeynirMamulOzellikleri>();

                nesne.PartiNo = txtPartyNo.Text;
                nesne.Aciklama = txtAciklama.Text;
                nesne.KalemKodu = "";
                nesne.KalemTanimi = txtUrunTanimi.Text;
                nesne.UretimTarihi = tarih1;

                foreach (DataGridViewRow dr in dtgProsesOzellikleri1.Rows)
                {
                    tostPeynirProssesOzellikleri1 = new TostPeynirProssesOzellikleri1();
                    tostPeynirProssesOzellikleri1.PartiNo = dr.Cells["Parti No"].Value == DBNull.Value ? "" : dr.Cells["Parti No"].Value.ToString();
                    tostPeynirProssesOzellikleri1.HamurTuru = dr.Cells["Hamur türü"].Value == DBNull.Value ? "" : dr.Cells["Hamur türü"].Value.ToString();
                    tostPeynirProssesOzellikleri1.GorevliOperator = dr.Cells["Görevli Operatör"].Value == DBNull.Value ? "" : dr.Cells["Görevli Operatör"].Value.ToString();
                    tostPeynirProssesOzellikleri1.GorevliOperatorAdi = dr.Cells["Görevli Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Görevli Operatör Adı"].Value.ToString();

                    tostPeynirProssesOzellikleri1.PisirmeMakinesindeHammaddeYuklemeBaslangicSaati = dr.Cells["Hammadde Yükleme Baş. Saat"].Value == DBNull.Value ? "" : dr.Cells["Hammadde Yükleme Baş. Saat"].Value.ToString();

                    tostPeynirProssesOzellikleri1.HamurunPisirmeMakinesindenIndirilmeSaati = dr.Cells["Pişirme Mak. Indirilme Saati"].Value == DBNull.Value ? "" : dr.Cells["Pişirme Mak. Indirilme Saati"].Value.ToString();

                    tostPeynirProssesOzellikleri1.HamurPastorizasyonSicakligi = dr.Cells["Hamur Pastor. Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Hamur Pastor. Sıcaklığı"].Value);

                    tostPeynirProssesOzellikleri1.VakumSuresi = dr.Cells["Vakum Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Vakum Süresi (DK)"].Value);

                    tostPeynirProssesOzellikleri1.PisirmeMakinesindeHammaddeYuklemeBitisSaati = dr.Cells["Hammadde Yükleme Bit. Saat"].Value == DBNull.Value ? "" : dr.Cells["Hammadde Yükleme Bit. Saat"].Value.ToString();

                    tostPeynirProssesOzellikleri1.HamurunGramajlamaBitisSaati = dr.Cells["Hamurun Gramajlama Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Hamurun Gramajlama Bitiş Saati"].Value.ToString();

                    tostPeynirProssesOzellikleri1s.Add(tostPeynirProssesOzellikleri1);
                }

                nesne.tostPeynirProssesOzellikleri1_Detay = tostPeynirProssesOzellikleri1s.ToArray();

                foreach (DataGridViewRow dr in dtgProsesOzellikleri2.Rows)
                {
                    tostPeynirProssesOzellikleri2 = new TostPeynirProssesOzellikleri2();

                    tostPeynirProssesOzellikleri2.HammaddeYuklemeSuresiDk = dr.Cells["Hammadde Yükleme Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Hammadde Yükleme Süresi (DK)"].Value);

                    tostPeynirProssesOzellikleri2.HamurunPismeSuresiDk = dr.Cells["Hamur Pişme Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Hamur Pişme Süresi (DK)"].Value);

                    tostPeynirProssesOzellikleri2.VakumSuresi = dr.Cells["Vakum Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Vakum Süresi (DK)"].Value);

                    tostPeynirProssesOzellikleri2.HamurunGramajlamaSuresiDk = dr.Cells["Hamurun Gramajlanma Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Hamurun Gramajlanma Süresi (DK)"].Value);

                    tostPeynirProssesOzellikleri2.ToplamGecenSureDk = dr.Cells["Toplam Geçen Süre (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Geçen Süre (DK)"].Value);

                    tostPeynirProssesOzellikleri2s.Add(tostPeynirProssesOzellikleri2);
                }

                nesne.tostPeynirProssesOzellikleri2_Detay = tostPeynirProssesOzellikleri2s.ToArray();

                foreach (DataGridViewRow dr in dtgHammaddeMiktar.Rows)
                {
                    tostPeynirHammaddeMiktarVeOzellik = new TostPeynirHammaddeMiktarVeOzellik();

                    tostPeynirHammaddeMiktarVeOzellik.MalzemeAdi = dr.Cells["Malzeme Adı"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Adı"].Value.ToString();
                    tostPeynirHammaddeMiktarVeOzellik.KuruMadde = dr.Cells["Kuru Madde (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde (%)"].Value);
                    tostPeynirHammaddeMiktarVeOzellik.YagOrani = dr.Cells["Yağ Oranı (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ Oranı (%)"].Value);
                    tostPeynirHammaddeMiktarVeOzellik.PH = dr.Cells["PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH Değeri"].Value);
                    tostPeynirHammaddeMiktarVeOzellik.SH = dr.Cells["SH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH Değeri"].Value);
                    tostPeynirHammaddeMiktarVeOzellik.HammaddePartiNo = dr.Cells["Hammade Parti No"].Value == DBNull.Value ? "" : dr.Cells["Hammade Parti No"].Value.ToString();
                    tostPeynirHammaddeMiktarVeOzellik.Miktar = dr.Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Miktar"].Value);
                    tostPeynirHammaddeMiktarVeOzellik.Birim = dr.Cells["Birim"].Value == DBNull.Value ? "" : dr.Cells["Birim"].Value.ToString();

                    tostPeynirHammaddeMiktarVeOzelliks.Add(tostPeynirHammaddeMiktarVeOzellik);
                }

                nesne.tostPeynirHammaddeMiktarVeOzellik_Detay = tostPeynirHammaddeMiktarVeOzelliks.ToArray();

                foreach (DataGridViewRow dr in dtgSarfMalzeme.Rows)
                {
                    tostPeynirSarfMalzemeKullanim = new TostPeynirSarfMalzemeKullanim();
                    tostPeynirSarfMalzemeKullanim.MalzemeAdi = dr.Cells["Malzeme Adı"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Adı"].Value.ToString();
                    tostPeynirSarfMalzemeKullanim.SarfMalzemePartiNo = dr.Cells["Sarf Malzemesi Parti No"].Value == DBNull.Value ? "" : dr.Cells["Sarf Malzemesi Parti No"].Value.ToString();
                    tostPeynirSarfMalzemeKullanim.MalzemeMarkaTedarikcisi = dr.Cells["Malzemenin Markası ve Tedarikçisi"].Value == DBNull.Value ? "" : dr.Cells["Malzemenin Markası ve Tedarikçisi"].Value.ToString();
                    tostPeynirSarfMalzemeKullanim.Miktar = dr.Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Miktar"].Value);
                    tostPeynirSarfMalzemeKullanim.Birim = dr.Cells["Birim"].Value == DBNull.Value ? "" : dr.Cells["Birim"].Value.ToString();

                    tostPeynirSarfMalzemeKullanims.Add(tostPeynirSarfMalzemeKullanim);
                }

                nesne.tostPeynirSarfMalzemeKullanim_Detay = tostPeynirSarfMalzemeKullanims.ToArray();

                foreach (DataGridViewRow dr in dtgMamulOz.Rows)
                {
                    tostPeynirMamulOzellikleri = new TostPeynirMamulOzellikleri();

                    tostPeynirMamulOzellikleri.HammaddeVeSarfMalzemeToplami = dr.Cells["Hammmade ve Sarf Malzeme Toplamı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Hammmade ve Sarf Malzeme Toplamı"].Value);
                    tostPeynirMamulOzellikleri.UretilenUrunMiktariKg = dr.Cells["Üretilen Ürün Miktarı (Adet)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretilen Ürün Miktarı (Adet)"].Value);
                    tostPeynirMamulOzellikleri.UretilenUrunAdi = dr.Cells["Üretilen Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Üretilen Ürün Adı"].Value.ToString();
                    tostPeynirMamulOzellikleri.KuruMadde = dr.Cells["Kuru Madde(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde(%)"].Value);
                    tostPeynirMamulOzellikleri.HamurYagOrani = dr.Cells["Hamur Yağ Oranı(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Hamur Yağ Oranı(%)"].Value);
                    tostPeynirMamulOzellikleri.HamurunPHDegeri = dr.Cells["Hamur PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Hamur PH Değeri"].Value);

                    tostPeynirMamulOzellikleri.KuruMaddeYagOrani = dr.Cells["Kuru Madde Yağ Oranı(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde Yağ Oranı(%)"].Value);
                    tostPeynirMamulOzellikleri.UretilenHamur = dr.Cells["Üretilen Hamur"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretilen Hamur"].Value);

                    tostPeynirMamulOzellikleris.Add(tostPeynirMamulOzellikleri);
                }

                nesne.tostPeynirMamulOzellikleri_Detay = tostPeynirMamulOzellikleris.ToArray();

                var resp = client.AddOrUpdateTostPeynirProsesAnalizTakip(nesne, Giris.dbName, Giris.mKodValue);

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

        private void button6_Click(object sender, EventArgs e)
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();
        }

        private void dtgProsesOzellikleri2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                return;
                string sql = "SELECT T1.\"U_HammaddeYukSureDk\" as \"Hammadde Yükleme Süresi (DK)\", T1.\"U_HamurPismeSuresiDk\" as \"Hamur Pişme Süresi (DK)\", T1.\"U_HamurGramajSureDk\" as \"Hamurun Gramajlanma Süresi (DK)\", T1.\"U_VakumSuresiDk\" as \"Vakum Süresi (DK)\", T1.\"U_ToplamGecenSureDk\" as \"Toplam Geçen Süre (DK)\" FROM \"@AIF_TSTPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TSTPRSS_ANLZ2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

                if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Hammadde Yükleme Süresi (DK)" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Hamur Pişme Süresi (DK)" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Hamurun Gramajlanma Süresi (DK)" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Vakum Süresi (DK)" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Hamur PH Değeri")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri2);
                    n.ShowDialog();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
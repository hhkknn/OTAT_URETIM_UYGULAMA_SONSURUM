using AIF.UVT.DatabaseLayer;
using AIF.UVT.Library;
using AIF.UVT.UVTService;
using SAPbobsCOM;
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
    public partial class LorProsesTakip : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end.

        public LorProsesTakip(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1)
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

            initialFontSize = txtUrunTanimi.Font.Size;
            txtUrunTanimi.Resize += Form_Resize;

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

            initialFontSize = btnOzetEkranaDon.Font.Size;
            btnOzetEkranaDon.Resize += Form_Resize;

            initialFontSize = btnOnayla.Font.Size;
            btnOnayla.Resize += Form_Resize;

            initialFontSize = button8.Font.Size;
            button8.Resize += Form_Resize;

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

            button3.Font = new Font(button3.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              button3.Font.Style);

            button4.Font = new Font(button4.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button4.Font.Style);

            button5.Font = new Font(button5.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button5.Font.Style);

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOnayla.Font.Style);

            button8.Font = new Font(button8.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button8.Font.Style);

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
        private string UrunGrubu = "";
        private SqlCommand cmd = null;

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

        private void LorProsesTakip_Load(object sender, EventArgs e)
        {
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_LORPRSS_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
            dtgSarfMalzemeKullanimLoad();
            dtgMamulOzellikleri1Load();
            dtgMamulOzellikleri2Load();
        }

        private void dtgProsesOzellikleri1Load()
        {
            string sql = "Select T1.\"U_PartiNo\" as \"Parti No\",T1.\"U_LorTuru\" as \"Lor Türü\",\"U_PasGonderimBasSaat\" as \"Pas Gönderim Başlangıç Saati\",T1.\"U_PasGonderimBitSaat\" as \"Pas Gönderim Bitiş Saati\",T1.\"U_NetPasMiktari\" as \"Net Pas Miktarı\",T1.\"U_PasPastSicak\" as \"Pas Pastörizasyon Sıcaklığı\",T1.\"U_EsanjorTankFiltre\" as \"Eşanjör ve Tank Filtre Kontrol\",T1.\"U_PasTankGelSicak\" as \"Pasın Tanka Geliş Sıcaklığı\",T1.\"U_PasPH\" as \"Pasın PH Değeri\",T1.\"U_PasinSeksenDereceSaati\" as \"Pasın 80 Dereceye Gelme Saati\",T1.\"U_PasSeksenSekizDerece\" as \"Pasın 88 Dereceye Gelme Saati\",T1.\"U_PasinBosaltmaBasSaat\" as \"Pasın Tanktan Boşaltılma Başlangıç Saati\",T1.\"U_PasinBosaltmaBitSaat\" as \"Pasın Tanktan Boşaltılma Bitiş Saati\",T1.\"U_BaskiBasSaat\" as \"Baskı Başlangıç Saati\", T1.\"U_BaskiBitSaat\" as \"Baskı Bitiş Saati\" from \"@AIF_LORPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_LORPRSS_ANLZ1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgProsesOzellikleri1.DataSource = dt;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgProsesOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgProsesOzellikleri1.EnableHeadersVisualStyles = false;
            dtgProsesOzellikleri1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgProsesOzellikleri1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Parti No"] = partiNo;
                dr["Net Pas Miktarı"] = Convert.ToString("0", cultureTR);
                dr["Pas Pastörizasyon Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Pasın Tanka Geliş Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Pasın PH Değeri"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }
            //dt.Rows.Add();

            dtgProsesOzellikleri1.Columns["Net Pas Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri1.Columns["Net Pas Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri1.Columns["Pas Pastörizasyon Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri1.Columns["Pas Pastörizasyon Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri1.Columns["Pasın Tanka Geliş Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri1.Columns["Pasın Tanka Geliş Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri1.Columns["Pasın PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri1.Columns["Pasın PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgProsesOzellikleri1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgProsesOzellikleri1.Columns["Parti No"].Width = dtgProsesOzellikleri1.Columns["Parti No"].Width + 20;
            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;

            #region Kontrol listesi oluşturma 

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pas Gönderim Başlangıç Saati",
                kontroledilmesigerekenKolon = "Lor Türü"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pas Gönderim Bitiş Saati",
                kontroledilmesigerekenKolon = "Pas Gönderim Başlangıç Saati"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Net Pas Miktarı",
                kontroledilmesigerekenKolon = "Pas Gönderim Bitiş Saati"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pas Pastörizasyon Sıcaklığı",
                kontroledilmesigerekenKolon = "Net Pas Miktarı"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Eşanjör ve Tank Filtre Kontrol",
                kontroledilmesigerekenKolon = "Pas Pastörizasyon Sıcaklığı"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pasın Tanka Geliş Sıcaklığı",
                kontroledilmesigerekenKolon = "Eşanjör ve Tank Filtre Kontrol"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pasın PH Değeri",
                kontroledilmesigerekenKolon = "Pasın Tanka Geliş Sıcaklığı"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pasın 80 Dereceye Gelme Saati",
                kontroledilmesigerekenKolon = "Pasın PH Değeri"
            });



            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pasın 88 Dereceye Gelme Saati",
                kontroledilmesigerekenKolon = "Pasın 80 Dereceye Gelme Saati"
            });



            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pasın Tanktan Boşaltılma Başlangıç Saati",
                kontroledilmesigerekenKolon = "Pasın 88 Dereceye Gelme Saati"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Pasın Tanktan Boşaltılma Bitiş Saati",
                kontroledilmesigerekenKolon = "Pasın Tanktan Boşaltılma Başlangıç Saati"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Baskı Başlangıç Saati",
                kontroledilmesigerekenKolon = "Pasın Tanktan Boşaltılma Başlangıç Saati"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Baskı Bitiş Saati",
                kontroledilmesigerekenKolon = "Baskı Başlangıç Saati"
            });


            #endregion
        }

        private void dtgProsesOzellikleri2Load()
        {
            string sql = "Select T1.\"U_PasGonderimSuresi\" as \"Pas Gönderim Süresi\",T1.\"U_PasSeksenSekizDerece\" as \"Pasın 88 Dereceye Gelme Süresi\",T1.\"U_PeynirIndirilmeSuresi\" as \"Peynir İndirme Süresi\",T1.\"U_BaskiSuresi\" as \"Baskı Süresi\",T1.\"U_ToplamGecenSure\" as \"Toplam Geçen Süre\" from \"@AIF_LORPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_LORPRSS_ANLZ2\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgProsesOzellikleri2.DataSource = dt;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgProsesOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgProsesOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dtgProsesOzellikleri2.EnableHeadersVisualStyles = false;
            dtgProsesOzellikleri2.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgProsesOzellikleri2.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Pas Gönderim Süresi"] = Convert.ToString("0", cultureTR);
                dr["Pasın 88 Dereceye Gelme Süresi"] = Convert.ToString("0", cultureTR);
                dr["Peynir İndirme Süresi"] = Convert.ToString("0", cultureTR);
                dr["Baskı Süresi"] = Convert.ToString("0", cultureTR);
                dr["Toplam Geçen Süre"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }
            //dt.Rows.Add();

            dtgProsesOzellikleri2.Columns["Pas Gönderim Süresi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Pas Gönderim Süresi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Pasın 88 Dereceye Gelme Süresi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Pasın 88 Dereceye Gelme Süresi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Peynir İndirme Süresi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Peynir İndirme Süresi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Baskı Süresi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Baskı Süresi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Toplam Geçen Süre"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Toplam Geçen Süre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgProsesOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgProsesOzellikleri2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;
        }

        private void dtgSarfMalzemeKullanimLoad()
        {
            string sql = "SELECT T1.\"U_MalzemeAdi\" as \"Malzeme Adı\",T1.\"U_MalMarkaTedarikci\" as \"Malzemenin Markası ve Tedarikçisi\",T1.\"U_PartiNo\" as \"Sarf Malzemesi Parti No\",Convert(float,T1.\"U_Miktar\") as \"Miktar\",T1.\"U_Birim\" as \"Birim\" FROM \"@AIF_LORPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_LORPRSS_ANLZ3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

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

            foreach (DataGridViewColumn col in dtgSarfMalzeme.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            if (dt.Rows.Count == 0)
            {
                sql = "select T0.ItemName as \"Malzeme Adı\",CardName as \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1 T0 WITH (NOLOCK) inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo + "') and T1.\"ItmsGrpCod\" NOT IN('105','106','107') ";

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

        private void dtgMamulOzellikleri1Load()
        {
            string sql = "SELECT \"U_UretilenMik\" as \"Üretilen Miktar\", T1.\"U_UretimRandimani\" as \"Üretim Randımanı\", T1.\"U_KontrolEdenPers\" as \"Kontrol Eden Personel\" FROM \"@AIF_LORPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_LORPRSS_ANLZ4\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgMamulOzellikleri1.DataSource = dt;

            dtgMamulOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgMamulOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgMamulOzellikleri1.EnableHeadersVisualStyles = false;
            dtgMamulOzellikleri1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            foreach (DataGridViewColumn col in dtgMamulOzellikleri1.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Üretilen Miktar"] = Convert.ToString("0", cultureTR);
                dr["Üretim Randımanı"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }

            dtgMamulOzellikleri1.Columns["Üretilen Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri1.Columns["Üretilen Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri1.Columns["Üretim Randımanı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri1.Columns["Üretim Randımanı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgMamulOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgMamulOzellikleri1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOz.Rows[0].Height = dtgMamulOz.Height - dtgMamulOz.ColumnHeadersHeight;
            //dtgMamulOz.AutoResizeColumns();

            #region Kontrol listesi oluşturma 

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Üretilen Miktar",
                kontroledilmesigerekenKolon = "Baskı Bitiş Saati"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Kontrol Eden Personel",
                kontroledilmesigerekenKolon = "Üretilen Miktar"
            });

            #endregion
        }

        private void dtgMamulOzellikleri2Load()
        {
            string sql = "SELECT \"U_KuruMadde\" as \"Kuru Madde\", T1.\"U_YagOrani\" as \"Yağ Oranı\", T1.\"U_PH\" as \"PH Değeri\", T1.\"U_SH\" as \"SH Değeri\", T1.\"U_TuzOrani\" as \"Tuz Oranı\" FROM \"@AIF_LORPRSS_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_LORPRSS_ANLZ5\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgMamulOzellikleri2.DataSource = dt;

            dtgMamulOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgMamulOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dtgMamulOzellikleri2.EnableHeadersVisualStyles = false;
            dtgMamulOzellikleri2.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            foreach (DataGridViewColumn col in dtgMamulOzellikleri2.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Kuru Madde"] = Convert.ToString("0", cultureTR);
                dr["Yağ Oranı"] = Convert.ToString("0", cultureTR);
                dr["PH Değeri"] = Convert.ToString("0", cultureTR);
                dr["SH Değeri"] = Convert.ToString("0", cultureTR);
                dr["Tuz Oranı"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }

            dtgMamulOzellikleri2.Columns["Kuru Madde"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["Kuru Madde"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri2.Columns["Yağ Oranı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["Yağ Oranı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri2.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri2.Columns["SH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["SH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgMamulOzellikleri2.Columns["Tuz Oranı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMamulOzellikleri2.Columns["Tuz Oranı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgMamulOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgMamulOzellikleri2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOz.Rows[0].Height = dtgMamulOz.Height - dtgMamulOz.ColumnHeadersHeight;
            //dtgMamulOz.AutoResizeColumns();
        }

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();
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
                if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pas Gönderim Başlangıç Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pas Gönderim Bitiş Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pasın 80 Dereceye Gelme Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pasın 88 Dereceye Gelme Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pasın Tanktan Boşaltılma Başlangıç Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pasın Tanktan Boşaltılma Bitiş Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Baskı Başlangıç Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Baskı Bitiş Saati")
                {
                    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, true);
                    //n.ShowDialog();

                    SaatTarihGirisi n = new SaatTarihGirisi(dtgProsesOzellikleri1);
                    n.ShowDialog();

                    #region Saat Hesaplamaları

                    if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pas Gönderim Başlangıç Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pas Gönderim Bitiş Saati")
                    {
                        var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Pas Gönderim Başlangıç Saati"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Pas Gönderim Bitiş Saati"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2.Rows[0].Cells["Pas Gönderim Süresi"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2.Rows[0].Cells["Pas Gönderim Süresi"].Value = "0";
                        }

                        //ProsesOzellikleri2ToplamSureHesapla();
                        //ProsesOzellikleri1Topla();
                    }
                    else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pasın Tanktan Boşaltılma Başlangıç Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pasın Tanktan Boşaltılma Bitiş Saati")
                    {
                        var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Pasın Tanktan Boşaltılma Başlangıç Saati"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Pasın Tanktan Boşaltılma Bitiş Saati"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2.Rows[0].Cells["Peynir İndirme Süresi"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2.Rows[0].Cells["Peynir İndirme Süresi"].Value = "0";
                        }

                        //ProsesOzellikleri2ToplamSureHesapla();
                    }
                    else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Baskı Başlangıç Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Baskı Bitiş Saati")
                    {
                        var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Baskı Başlangıç Saati"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Baskı Bitiş Saati"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;
                            dtgProsesOzellikleri2.Rows[0].Cells["Baskı Süresi"].Value = girisCikisFarki.TotalMinutes.ToString();

                            var SutGonderimBaslangcSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Pas Gönderim Başlangıç Saati"].Value.ToString();

                            if (SutGonderimBaslangcSaati.ToString() != "" && bitisSaati.ToString() != "")
                            {
                                resp = help.SaatDuzenle(SutGonderimBaslangcSaati, bitisSaati);

                                girisCikisFarki = resp.Item2 - resp.Item1;

                                dtgProsesOzellikleri2.Rows[0].Cells["Toplam Geçen Süre"].Value = girisCikisFarki.TotalMinutes.ToString();
                            }
                        }
                        else
                        {
                            dtgProsesOzellikleri2.Rows[0].Cells["Baskı Süresi"].Value = "0";
                        }

                        //ProsesOzellikleri2ToplamSureHesapla();
                    }
                    else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pasın 88 Dereceye Gelme Saati")
                    {
                        var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Pas Gönderim Bitiş Saati"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Pasın 88 Dereceye Gelme Saati"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;
                            dtgProsesOzellikleri2.Rows[0].Cells["Pasın 88 Dereceye Gelme Süresi"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2.Rows[0].Cells["Pasın 88 Dereceye Gelme Süresi"].Value = "0";
                        }
                    }

                    #endregion Saat Hesaplamaları
                }
                else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Net Pas Miktarı" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pas Pastörizasyon Sıcaklığı" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pasın Tanka Geliş Sıcaklığı" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pasın PH Değeri" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pasın PH Değeri")
                {
                    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                    n.ShowDialog();

                    //if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Net Süt Miktarı LT")
                    //{
                    //var netSutMiktari = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value);
                    //var birgunSonraTartilan = dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                    //if (netSutMiktari > 0 && birgunSonraTartilan > 0)
                    //{
                    //    var sonuc = netSutMiktari / birgunSonraTartilan;
                    //    dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc.ToString();

                    //}
                    //}

                    if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Net Pas Miktarı")
                    {
                        MamulOzellikleri1UretimRandimaniHesapla();
                    }
                }
                else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Eşanjör ve Tank Filtre Kontrol")
                {
                    string sql1 = "Select '0' as \"Kod\",'Uygun Değil' as \"Aciklama\" ";
                    sql1 += " UNION ALL ";
                    sql1 += "Select '1' as \"Kod\",'Uygun' as \"Aciklama\" ";

                    SelectList selectList = new SelectList(sql1, dtgProsesOzellikleri1, -1, 6, _autoresizerow: false);
                    selectList.ShowDialog();
                }
                else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Lor Türü")
                {
                    string sql1 = "Select '0' as \"Kod\",'Yağlı' as \"Aciklama\" ";
                    sql1 += " UNION ALL ";
                    sql1 += "Select '1' as \"Kod\",'Yağsız' as \"Aciklama\" ";

                    SelectList selectList = new SelectList(sql1, dtgProsesOzellikleri1, -1, 1, _autoresizerow: false);
                    selectList.ShowDialog();
                }
            }
            catch (Exception)
            {
            }
        }

        private void MamulOzellikleri1UretimRandimaniHesapla()
        {
            var netPasMiktari = dtgProsesOzellikleri1.Rows[0].Cells["Net Pas Miktarı"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Net Pas Miktarı"].Value);
            var UretimMiktari = dtgMamulOzellikleri1.Rows[0].Cells["Üretilen Miktar"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["Üretilen Miktar"].Value);

            if (netPasMiktari > 0 && UretimMiktari > 0)
            {
                var sonuc = netPasMiktari / UretimMiktari;
                dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc.ToString();
            }
        }

        private void ProsesOzellikleri2ToplamSureHesapla()
        {
            var PasGonderimSuresi = dtgProsesOzellikleri2.Rows[0].Cells["Pas Gönderim Süresi"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2.Rows[0].Cells["Pas Gönderim Süresi"].Value);
            var PasSeksenSekizDerece = dtgProsesOzellikleri2.Rows[0].Cells["Pasın 88 Dereceye Gelme Süresi"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2.Rows[0].Cells["Pasın 88 Dereceye Gelme Süresi"].Value);
            var PeynirIndirilmeSuresi = dtgProsesOzellikleri2.Rows[0].Cells["Peynir İndirme Süresi"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2.Rows[0].Cells["Peynir İndirme Süresi"].Value);
            var BaskiSuresi = dtgProsesOzellikleri2.Rows[0].Cells["Baskı Süresi"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2.Rows[0].Cells["Baskı Süresi"].Value);

            var sonuc = PasGonderimSuresi + PasSeksenSekizDerece + PeynirIndirilmeSuresi + BaskiSuresi;
            dtgProsesOzellikleri2.Rows[0].Cells["Toplam Geçen Süre"].Value = sonuc.ToString();
        }

        private void dtgProsesOzellikleri2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
            string sql = "Select T1.\"U_PasGonderimSuresi\" as \"Pas Gönderim Süresi\",T1.\"U_PasSeksenSekizDerece\" as \"Pasın 88 Dereceye Gelme Süresi\",T1.\"U_PeynirIndirilmeSuresi\" as \"Peynir İndirme Süresi\",T1.\"U_BaskiSuresi\" as \"Baskı Süresi\",T1.\"U_ToplamGecenSure\" as \"Toplam Geçen Süre\" from \"@AIF_LORPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_LORPRSS_ANLZ2\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

            if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Pas Gönderim Süresi" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Pasın 88 Dereceye Gelme Süresi" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Peynir İndirme Süresi" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Baskı Süresi")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri2, false);
                n.ShowDialog();

                //if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Net Süt Miktarı LT")
                //{
                //var netSutMiktari = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value);
                //var birgunSonraTartilan = dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                //if (netSutMiktari > 0 && birgunSonraTartilan > 0)
                //{
                //    var sonuc = netSutMiktari / birgunSonraTartilan;
                //    dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc.ToString();

                //}
                //}
            }
        }

        private void dtgMamulOzellikleri1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                bool cvp = true;

                if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Üretilen Miktar")
                {
                    cvp = Kontrol(dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name, dtgMamulOzellikleri1, dtgProsesOzellikleri1);
                }
                else
                {
                    cvp = Kontrol(dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name, dtgMamulOzellikleri1, null);
                }
                if (!cvp)
                {
                    return;
                }

                if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Üretilen Miktar")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOzellikleri1, false);
                    n.ShowDialog();

                    if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Üretilen Miktar")
                    {
                        MamulOzellikleri1UretimRandimaniHesapla();
                    }
                }
                else if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Kontrol Eden Personel")
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

                        SelectList selectList = new SelectList(sql, dtgMamulOzellikleri1, -1, 2, _autoresizerow: false);
                        selectList.ShowDialog();

                        //dtgProsesOzellikleri1.AutoResizeRows();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtgMamulOzellikleri2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "Kuru Madde" || dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "Yağ Oranı" || dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "PH Değeri" || dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "SH Değeri" || dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "Tuz Oranı")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOzellikleri2, false);
                n.ShowDialog();

                //if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Net Süt Miktarı LT")
                //{
                //var netSutMiktari = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value);
                //var birgunSonraTartilan = dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                //if (netSutMiktari > 0 && birgunSonraTartilan > 0)
                //{
                //    var sonuc = netSutMiktari / birgunSonraTartilan;
                //    dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc.ToString();

                //}
                //}
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                LorProsesTakipAnaliz nesne = new LorProsesTakipAnaliz();

                LorProsesOzellikleri1 LorProsesOzellikleri1 = new LorProsesOzellikleri1();
                List<LorProsesOzellikleri1> LorProsesOzellikleri1s = new List<LorProsesOzellikleri1>();
                LorProsesOzellikleri2 LorProsesOzellikleri2 = new LorProsesOzellikleri2();
                List<LorProsesOzellikleri2> LorProsesOzellikleri2s = new List<LorProsesOzellikleri2>();
                LorSarfMalzemeKullanim LorSarfMalzemeKullanim = new LorSarfMalzemeKullanim();
                List<LorSarfMalzemeKullanim> LorSarfMalzemeKullanims = new List<LorSarfMalzemeKullanim>();
                LorMamulOzellikleri1 LorMamulOzellikleri1 = new LorMamulOzellikleri1();
                List<LorMamulOzellikleri1> LorMamulOzellikleri1s = new List<LorMamulOzellikleri1>();
                LorMamulOzellikleri2 LorMamulOzellikleri2 = new LorMamulOzellikleri2();
                List<LorMamulOzellikleri2> LorMamulOzellikleri2s = new List<LorMamulOzellikleri2>();

                nesne.PartiNo = txtPartiNo.Text;
                nesne.Aciklama = txtAciklama.Text;
                nesne.UrunKodu = "";
                nesne.UrunTanimi = txtUrunTanimi.Text;

                foreach (DataGridViewRow dr in dtgProsesOzellikleri1.Rows)
                {
                    LorProsesOzellikleri1 = new LorProsesOzellikleri1();
                    LorProsesOzellikleri1.PartiNo = dr.Cells["Parti No"].Value == DBNull.Value ? "" : dr.Cells["Parti No"].Value.ToString();
                    LorProsesOzellikleri1.LorTuru = dr.Cells["Lor türü"].Value == DBNull.Value ? "" : dr.Cells["Lor türü"].Value.ToString();
                    LorProsesOzellikleri1.PasGonderimBaslangicSaati = dr.Cells["Pas Gönderim Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Pas Gönderim Başlangıç Saati"].Value.ToString();
                    LorProsesOzellikleri1.PasGonderimBitisSaati = dr.Cells["Pas Gönderim Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Pas Gönderim Bitiş Saati"].Value.ToString();
                    LorProsesOzellikleri1.NetPasMiktari = dr.Cells["Net Pas Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Net Pas Miktarı"].Value);
                    LorProsesOzellikleri1.PasPastorizasyonSicakligi = dr.Cells["Pas Pastörizasyon Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pas Pastörizasyon Sıcaklığı"].Value);
                    LorProsesOzellikleri1.EsanjorTankFiltreVeKontrol = dr.Cells["Eşanjör ve Tank Filtre Kontrol"].Value == DBNull.Value ? "" : dr.Cells["Eşanjör ve Tank Filtre Kontrol"].Value.ToString();
                    LorProsesOzellikleri1.PasinTankaGelisSicakligi = dr.Cells["Pasın Tanka Geliş Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pasın Tanka Geliş Sıcaklığı"].Value);
                    LorProsesOzellikleri1.PasinPHDegeri = dr.Cells["Pasın PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToInt32(dr.Cells["Pasın PH Değeri"].Value);
                    LorProsesOzellikleri1.PasinSeksenDereceyeGelmeSaati = dr.Cells["Pasın 80 Dereceye Gelme Saati"].Value == DBNull.Value ? "" : dr.Cells["Pasın 80 Dereceye Gelme Saati"].Value.ToString();
                    LorProsesOzellikleri1.PasinSeksenSekizDereceyeGelmeSaati = dr.Cells["Pasın 88 Dereceye Gelme Saati"].Value == DBNull.Value ? "" : dr.Cells["Pasın 88 Dereceye Gelme Saati"].Value.ToString();
                    LorProsesOzellikleri1.PasinTanktanBosaltilmaBaslangicSaati = dr.Cells["Pasın Tanktan Boşaltılma Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Pasın Tanktan Boşaltılma Başlangıç Saati"].Value.ToString();
                    LorProsesOzellikleri1.PasinTanktanBosaltilmaBitisSaati = dr.Cells["Pasın Tanktan Boşaltılma Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Pasın Tanktan Boşaltılma Bitiş Saati"].Value.ToString();
                    LorProsesOzellikleri1.BaskiBaslangicSaati = dr.Cells["Baskı Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Baskı Başlangıç Saati"].Value.ToString();
                    LorProsesOzellikleri1.BaskiBitisSaati = dr.Cells["Baskı Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Baskı Bitiş Saati"].Value.ToString();

                    LorProsesOzellikleri1s.Add(LorProsesOzellikleri1);
                }

                nesne.LorProsesOzellikleri1s = LorProsesOzellikleri1s.ToArray();

                foreach (DataGridViewRow dr in dtgProsesOzellikleri2.Rows)
                { 
                    LorProsesOzellikleri2 = new LorProsesOzellikleri2();

                    LorProsesOzellikleri2.PasinGonderimSuresi = dr.Cells["Pas Gönderim Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pas Gönderim Süresi"].Value);

                    LorProsesOzellikleri2.PasinSeksenSekizDereceyeGelmeSuresi = dr.Cells["Pasın 88 Dereceye Gelme Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pasın 88 Dereceye Gelme Süresi"].Value);

                    LorProsesOzellikleri2.PeynirinIndirilmeSuresi = dr.Cells["Peynir İndirme Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Peynir İndirme Süresi"].Value);

                    LorProsesOzellikleri2.BaskiSuresi = dr.Cells["Baskı Süresi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Baskı Süresi"].Value);

                    LorProsesOzellikleri2.ToplamGecenSure = dr.Cells["Toplam Geçen Süre"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Geçen Süre"].Value);

                    LorProsesOzellikleri2s.Add(LorProsesOzellikleri2);
                }

                nesne.LorProsesOzellikleri2s = LorProsesOzellikleri2s.ToArray();

                foreach (DataGridViewRow dr in dtgSarfMalzeme.Rows)
                {
                    LorSarfMalzemeKullanim = new LorSarfMalzemeKullanim();
                    LorSarfMalzemeKullanim.MalzemeAdi = dr.Cells["Malzeme Adı"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Adı"].Value.ToString();
                    LorSarfMalzemeKullanim.PartiNo = dr.Cells["Sarf Malzemesi Parti No"].Value == DBNull.Value ? "" : dr.Cells["Sarf Malzemesi Parti No"].Value.ToString();
                    LorSarfMalzemeKullanim.MalzemeMarkaTedarikcisi = dr.Cells["Malzemenin Markası ve Tedarikçisi"].Value == DBNull.Value ? "" : dr.Cells["Malzemenin Markası ve Tedarikçisi"].Value.ToString();
                    LorSarfMalzemeKullanim.Miktar = dr.Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Miktar"].Value);
                    LorSarfMalzemeKullanim.Birim = dr.Cells["Birim"].Value == DBNull.Value ? "" : dr.Cells["Birim"].Value.ToString();

                    LorSarfMalzemeKullanims.Add(LorSarfMalzemeKullanim);
                }

                nesne.LorSarfMalzemeKullanims = LorSarfMalzemeKullanims.ToArray();

                foreach (DataGridViewRow dr in dtgMamulOzellikleri1.Rows)
                {
                    LorMamulOzellikleri1 = new LorMamulOzellikleri1();
                    LorMamulOzellikleri1.LorPeynirMiktari = dr.Cells["Üretilen Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretilen Miktar"].Value);
                    LorMamulOzellikleri1.LorUretimRandimani = dr.Cells["Üretim Randımanı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretim Randımanı"].Value);
                    LorMamulOzellikleri1.KontrolEdenPersonel = dr.Cells["Kontrol Eden Personel"].Value == DBNull.Value ? "" : dr.Cells["Kontrol Eden Personel"].Value.ToString();

                    LorMamulOzellikleri1s.Add(LorMamulOzellikleri1);
                }

                nesne.LorMamulOzellikleri1s = LorMamulOzellikleri1s.ToArray();

                foreach (DataGridViewRow dr in dtgMamulOzellikleri2.Rows)
                { 

                    LorMamulOzellikleri2 = new LorMamulOzellikleri2();
                    LorMamulOzellikleri2.KuruMadde = dr.Cells["Kuru Madde"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde"].Value);
                    LorMamulOzellikleri2.YagOrani = dr.Cells["Yağ Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ Oranı"].Value);
                    LorMamulOzellikleri2.PH = dr.Cells["PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH Değeri"].Value);
                    LorMamulOzellikleri2.SH = dr.Cells["SH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH Değeri"].Value);
                    LorMamulOzellikleri2.TuzOrani = dr.Cells["Tuz Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tuz Oranı"].Value);

                    LorMamulOzellikleri2s.Add(LorMamulOzellikleri2);
                }

                nesne.LorMamulOzellikleri2s = LorMamulOzellikleri2s.ToArray();

                var resp = client.AddOrUpdateLorProsesTakipAnaliz(nesne, Giris.dbName, Giris.mKodValue);

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
    }
}
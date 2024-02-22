using AIF.UVT.DatabaseLayer;
using AIF.UVT.Library;
using AIF.UVT.UVTService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class TelemeProsesTakip : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end

        private string tarih1 = "";

        public TelemeProsesTakip(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, int _width, int _height, string _tarih1)
        {
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = btnOzetEkraniDon.Font.Size;
            btnOzetEkraniDon.Resize += Form_Resize;

            initialFontSize = button9.Font.Size;
            button9.Resize += Form_Resize;

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

            initialFontSize = btnProsesOzellik1.Font.Size;
            btnProsesOzellik1.Resize += Form_Resize;

            initialFontSize = btnSutunOzellikleri.Font.Size;
            btnSutunOzellikleri.Resize += Form_Resize;

            initialFontSize = btnProsesOzellikleri2.Font.Size;
            btnProsesOzellikleri2.Resize += Form_Resize;

            initialFontSize = btnProsesOzellikleri2_1.Font.Size;
            btnProsesOzellikleri2_1.Resize += Form_Resize;

            initialFontSize = btnSarfMalzeme.Font.Size;
            btnSarfMalzeme.Resize += Form_Resize;

            //initialFontSize = btnMamulOzellikleri.Font.Size;
            //btnMamulOzellikleri.Resize += Form_Resize;

            //initialFontSize = btnMamulOzellikleri2.Font.Size;
            //btnMamulOzellikleri2.Resize += Form_Resize;

            initialFontSize = btnAciklama.Font.Size;
            btnAciklama.Resize += Form_Resize;

            //initialFontSize = dtgProsesOzellikleri1.Font.Size;
            //dtgProsesOzellikleri1.Resize += Form_Resize;

            UretimFisNo = _UretimFisNo;
            partiNo1 = _PartiNo;
            partiNo = _PartiNo;
            UrunTanimi = _UrunTanimi;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            tarih1 = _tarih1;

            txtUretimFisNo.Text = UretimFisNo;
            txtPartiNo.Text = partiNo1;
            txtUrunTanimi.Text = UrunTanimi;
            istasyon = _istasyon;
            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            button9.Font = new Font(button9.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button9.Font.Style);

            btnOzetEkraniDon.Font = new Font(btnOzetEkraniDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkraniDon.Font.Style);

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

            btnProsesOzellik1.Font = new Font(btnProsesOzellik1.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnProsesOzellik1.Font.Style);

            btnSutunOzellikleri.Font = new Font(btnSutunOzellikleri.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSutunOzellikleri.Font.Style);

            btnProsesOzellikleri2.Font = new Font(btnProsesOzellikleri2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnProsesOzellikleri2.Font.Style);

            btnProsesOzellikleri2_1.Font = new Font(btnProsesOzellikleri2_1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnProsesOzellikleri2_1.Font.Style);

            btnSarfMalzeme.Font = new Font(btnSarfMalzeme.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnSarfMalzeme.Font.Style);

            //btnMamulOzellikleri.Font = new Font(btnMamulOzellikleri.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   btnMamulOzellikleri.Font.Style);

            //btnMamulOzellikleri2.Font = new Font(btnMamulOzellikleri2.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   btnMamulOzellikleri2.Font.Style);

            btnAciklama.Font = new Font(btnAciklama.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnAciklama.Font.Style);

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              label4.Font.Style);

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimTarihi.Font.Style);

            //dtgProsesOzellikleri1.Font = new Font(dtgProsesOzellikleri1.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   dtgProsesOzellikleri1.Font.Style);

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label4.Font.Style);

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               txtUretimTarihi.Font.Style);

            ResumeLayout();
            //font end
        }

        private string UretimFisNo = "";
        private string partiNo1 = "";
        private string istasyon = "";
        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private int row = 0;

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

        private void TelemeProsesTakip_Load(object sender, EventArgs e)
        {
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_TLMPRSS_ANALIZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
            dtgSutunOzellikleri1Load();
            dtgProsesOzellikleri2Load();
            dtgProsesOzellikleri2_1Load();
            dtgSarfMalzemeKullanimLoad();
            //dtgMamulOzellikleri1Load();
            //dtgMamulOzellikleri2Load();

            btnProsesOzellik1.BackColor = Color.IndianRed;
            btnProsesOzellik1.ForeColor = Color.White;

            btnSutunOzellikleri.BackColor = Color.RoyalBlue;
            btnSutunOzellikleri.ForeColor = Color.White;

            btnProsesOzellikleri2.BackColor = Color.IndianRed;
            btnProsesOzellikleri2.ForeColor = Color.White;

            btnSarfMalzeme.BackColor = Color.IndianRed;
            btnSarfMalzeme.ForeColor = Color.White;

            //btnMamulOzellikleri.BackColor = Color.IndianRed;
            //btnMamulOzellikleri.ForeColor = Color.White;

            //btnMamulOzellikleri2.BackColor = Color.RoyalBlue;
            //btnMamulOzellikleri2.ForeColor = Color.White;

            btnProsesOzellikleri2_1.BackColor = Color.DarkSeaGreen;
            btnProsesOzellikleri2_1.ForeColor = Color.White;

            btnAciklama.BackColor = Color.IndianRed;
            btnAciklama.ForeColor = Color.White;
        }

        private string partiNo = "";
        private SqlCommand cmd = null;

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

        private void dtgProsesOzellikleri1Load()
        {
            //string sql = "SELECT T1.\"U_PartiNo\" as \"Parti No\",T1.\"U_TelemeTuru\" as \"Teleme Türü\",T1.\"U_GorevliOperator\" as \"Görevli Operatör\",T1.\"U_GorevliOperatorAdi\" as \"Görevli Operatör Adı\",Convert(varchar(5),T1.\"U_SutGonBaslangicSaati\") as \"Süt Gönd. Baş. Saati\",Convert(varchar(5),T1.\"U_SutGonBitisSaati\") as \"Süt Gönd. Bit. Saati\",Convert(float,ISNULL(T1.\"U_NetSutMiktari\",0)) as \"Net Süt Miktarı LT\",Convert(float,ISNULL(T1.\"U_SutPastSicakligi\",0)) as \"Sütün Past. Sicak\",T1.\"U_EsanjorTankFiltre\" as \"Eşan. ve Tank Filt. Kont.\",Convert(float,ISNULL(T1.\"U_TanktakiSuSeviyesi\",0)) as \"Tanktaki Su Seviyesi\" FROM \"@AIF_TLMPRSS_ANALIZ\" AS T0 INNER JOIN \"@AIF_TLMPRSS_ANALIZ1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

            string sql = "SELECT T1.\"U_PartiNo\" as \"Parti No\",T1.\"U_TelemeTuru\" as \"Teleme Türü\",T1.\"U_GorevliOperator\" as \"Görevli Operatör\",T1.\"U_GorevliOperatorAdi\" as \"Görevli Operatör Adı\",Convert(varchar(5),T1.\"U_SutGonBaslangicSaati\") as \"Süt Gönderim Başlangıç Saati\",Convert(varchar(5),T1.\"U_SutGonBitisSaati\") as \"Süt Gönderim Bitiş Saati\",Convert(float,ISNULL(T1.\"U_NetSutMiktari\",0)) as \"Net Süt Miktarı LT\",Convert(float,ISNULL(T1.\"U_SutPastSicakligi\",0)) as \"Sütün Pastorizasyon Sicak\",T1.\"U_EsanjorTankFiltre\" as \"Esanjör ve Tank Filtre Kont.\",Convert(float,ISNULL(T1.\"U_TanktakiSuSeviyesi\",0)) as \"Tanktaki Su Seviyesi\" FROM \"@AIF_TLMPRSS_ANALIZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TLMPRSS_ANALIZ1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgProsesOzellikleri1.DataSource = dt;

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgProsesOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgProsesOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgProsesOzellikleri1.EnableHeadersVisualStyles = false;
            dtgProsesOzellikleri1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            //foreach (DataGridViewColumn col in dtgProsesOzellikleri1.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Bahnschrift", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            //}

            //SilButonuEkle(dtgProsesOzellikleri1);

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Parti No"] = partiNo1;
                dr["Teleme Türü"] = txtUrunTanimi.Text;
                dr["Net Süt Miktarı LT"] = Convert.ToString("0", cultureTR);
                dr["Sütün Pastorizasyon Sicak"] = Convert.ToString("0", cultureTR);
                dr["Tanktaki Su Seviyesi"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }

            dtgProsesOzellikleri1.Columns["Net Süt Miktarı LT"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri1.Columns["Net Süt Miktarı LT"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri1.Columns["Sütün Pastorizasyon Sicak"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri1.Columns["Sütün Pastorizasyon Sicak"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri1.Columns["Tanktaki Su Seviyesi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri1.Columns["Tanktaki Su Seviyesi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgProsesOzellikleri1.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgProsesOzellikleri1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgProsesOzellikleri1.Rows[0].Height = dtgProsesOzellikleri1.Height - dtgProsesOzellikleri1.ColumnHeadersHeight;
            dtgProsesOzellikleri1.AutoResizeColumns();

            dtgProsesOzellikleri1.Columns["Sütün Pastorizasyon Sicak"].HeaderText = "Sütün Past. Sicak";
            dtgProsesOzellikleri1.Columns["Süt Gönderim Başlangıç Saati"].HeaderText = "Süt Gönd. Baş.Saati";
            dtgProsesOzellikleri1.Columns["Süt Gönderim Bitiş Saati"].HeaderText = "Süt Gönd. Bit.Saati";
            dtgProsesOzellikleri1.Columns["Esanjör ve Tank Filtre Kont."].HeaderText = "Eşan.ve Tank Filt.Kont.";
            dtgProsesOzellikleri1.Columns["Tanktaki Su Seviyesi"].HeaderText = "Tanktaki Süt Seviyesi";


            #region Kontrol listesi oluşturma 

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Görevli Operatör",
                kontroledilmesigerekenKolon = "Teleme Türü"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Süt Gönderim Başlangıç Saati",
                kontroledilmesigerekenKolon = "Görevli Operatör"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Süt Gönderim Bitiş Saati",
                kontroledilmesigerekenKolon = "Süt Gönderim Başlangıç Saati"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Net Süt Miktarı LT",
                kontroledilmesigerekenKolon = "Süt Gönderim Bitiş Saati"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Sütün Pastorizasyon Sicak",
                kontroledilmesigerekenKolon = "Net Süt Miktarı LT"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Esanjör ve Tank Filtre Kont.",
                kontroledilmesigerekenKolon = "Sütün Pastorizasyon Sicak"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Tanktaki Su Seviyesi",
                kontroledilmesigerekenKolon = "Esanjör ve Tank Filtre Kont."
            });

            #endregion
        }


        private void dtgSutunOzellikleri1Load()
        {
            string sql = "SELECT Convert(float,T1.\"U_KuruMadde\") as \"Kuru Madde (%)\", Convert(float,T1.\"U_YagOrani\") as \"Yağ Oranı (%)\",Convert(float,\"U_PH\") as \"PH Değeri\", Convert(float,T1.\"U_SH\") as \"SH Değeri\", Convert(float,T1.\"U_SuOrani\") as \"Su Oranı\", Convert(float,T1.\"U_ProteinOrani\") as \"Protein Oranı\" FROM \"@AIF_TLMPRSS_ANALIZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TLMPRSS_ANALIZ2\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgSutunOzellikleri.DataSource = dt;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgSutunOzellikleri.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgSutunOzellikleri.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgSutunOzellikleri.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dtgSutunOzellikleri.EnableHeadersVisualStyles = false;
            dtgSutunOzellikleri.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            //foreach (DataGridViewColumn col in dtgSutunOzellikleri.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Bahnschrift", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            //}

            //SilButonuEkle(dtgSutunOzellikleri);

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Kuru Madde (%)"] = Convert.ToString("0", cultureTR);
                dr["Yağ Oranı (%)"] = Convert.ToString("0", cultureTR);
                dr["PH Değeri"] = Convert.ToString("0", cultureTR);
                dr["SH Değeri"] = Convert.ToString("0", cultureTR);
                dr["Su Oranı"] = Convert.ToString("0", cultureTR);
                dr["Protein Oranı"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }

            dtgSutunOzellikleri.Columns["Kuru Madde (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutunOzellikleri.Columns["Kuru Madde (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgSutunOzellikleri.Columns["Yağ Oranı (%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutunOzellikleri.Columns["Yağ Oranı (%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgSutunOzellikleri.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutunOzellikleri.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgSutunOzellikleri.Columns["SH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutunOzellikleri.Columns["SH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgSutunOzellikleri.Columns["Su Oranı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutunOzellikleri.Columns["Su Oranı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgSutunOzellikleri.Columns["Protein Oranı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutunOzellikleri.Columns["Protein Oranı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgSutunOzellikleri.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgSutunOzellikleri.AutoResizeRows();

            foreach (DataGridViewColumn column in dtgSutunOzellikleri.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgSutunOzellikleri.Rows[0].Height = dtgSutunOzellikleri.Height - dtgSutunOzellikleri.ColumnHeadersHeight;
        }

        private void dtgProsesOzellikleri2Load()
        {
            string sql = "SELECT Convert(varchar(5),T1.\"U_MayalamaSaati\") as \"Mayalama Saati\",Convert(float,T1.\"U_MayalamaSicakligi\") as \"Mayalama Sıcaklığı\",Convert(varchar(5),T1.\"U_KirimVeCedarBasSaat\") as \"Kırım ve Çedarlama Başlangıç Saati\",Convert(float,T1.\"U_CedarlamaSicakligi\") as \"Çedarlama Sıcaklığı\",Convert(varchar(5),T1.\"U_KirimVeCedarBitSaat\") as \"Kırım ve Çedarlama Bitiş Saati\",Convert(varchar(5),T1.\"U_IndirmeBitisSaati\") as \"İndirme Bitiş Saati\",Convert(varchar(5),T1.\"U_BaskiBaslangicSaati\") as \"Baskı Başlangıç Saati\", Convert(varchar(5),T1.\"U_BaskiBitisSaati\") as \"Baskı Bitiş Saati\", Convert(float,T1.\"U_UretimDepoSicakligi\") as \"Üretim Depo Sıcaklığı\" FROM \"@AIF_TLMPRSS_ANALIZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TLMPRSS_ANALIZ3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgProsesOzellikleri2.DataSource = dt;

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgProsesOzellikleri2.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgProsesOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgProsesOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgProsesOzellikleri2.EnableHeadersVisualStyles = false;
            dtgProsesOzellikleri2.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            //foreach (DataGridViewColumn col in dtgProsesOzellikleri2.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Bahnschrift", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            //}

            //SilButonuEkle(dtgProsesOzellikleri2);

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Mayalama Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Çedarlama Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Üretim Depo Sıcaklığı"] = Convert.ToString("0", cultureTR);

                dt.Rows.Add(dr);
            }
            //dt.Rows.Add();

            dtgProsesOzellikleri2.Columns["Mayalama Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Mayalama Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Çedarlama Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Çedarlama Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2.Columns["Üretim Depo Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2.Columns["Üretim Depo Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgProsesOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgProsesOzellikleri2.AutoResizeRows();

            foreach (DataGridViewColumn column in dtgProsesOzellikleri2.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgProsesOzellikleri2.Rows[0].Height = dtgProsesOzellikleri2.Height - dtgProsesOzellikleri2.ColumnHeadersHeight;


            #region Kontrol listesi oluşturma 

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Mayalama Saati",
                kontroledilmesigerekenKolon = "Tanktaki Su Seviyesi"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Mayalama Sıcaklığı",
                kontroledilmesigerekenKolon = "Mayalama Saati"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Kırım ve Çedarlama Başlangıç Saati",
                kontroledilmesigerekenKolon = "Mayalama Sıcaklığı"
            });

            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Çedarlama Sıcaklığı",
                kontroledilmesigerekenKolon = "Kırım ve Çedarlama Başlangıç Saati"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Kırım ve Çedarlama Bitiş Saati",
                kontroledilmesigerekenKolon = "Çedarlama Sıcaklığı"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "İndirme Bitiş Saati",
                kontroledilmesigerekenKolon = "Kırım ve Çedarlama Bitiş Saati"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Baskı Başlangıç Saati",
                kontroledilmesigerekenKolon = "İndirme Bitiş Saati"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Baskı Bitiş Saati",
                kontroledilmesigerekenKolon = "Baskı Başlangıç Saati"
            });


            kontrolListesis.Add(new kontrolListesi
            {
                aktifKolon = "Üretim Depo Sıcaklığı",
                kontroledilmesigerekenKolon = "Baskı Bitiş Saati"
            });

            #endregion
        }

        private void dtgProsesOzellikleri2_1Load()
        {
            string sql = "SELECT Convert(float,t1.\"U_SutGonderimSuresiDk\") AS \"Süt Gönderim Süresi (DK)\",Convert(float,T1.\"U_MayalamaSuresiDk\") as \"Mayalama Süresi (DK)\",Convert(float,T1.\"U_KirimVeCedarSure\") as \"Kırım ve Çedarlama Suresi(DK)\",Convert(float,T1.\"U_IndirmeSuresi\") as \"Indirme Süresi (DK)\",Convert(float,T1.\"U_BaskiSuresi\") as \"Baskı Süresi (DK)\",Convert(float,T1.\"U_ToplamGecenSure\") as \"Toplam Geçen Süre (DK)\" FROM \"@AIF_TLMPRSS_ANALIZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TLMPRSS_ANALIZ4\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgProsesOzellikleri2_1.DataSource = dt;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgProsesOzellikleri2_1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgProsesOzellikleri2_1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgProsesOzellikleri2_1.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
            dtgProsesOzellikleri2_1.EnableHeadersVisualStyles = false;
            dtgProsesOzellikleri2_1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            //foreach (DataGridViewColumn col in dtgProsesOzellikleri2_1.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Bahnschrift", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            //}

            //for (int ix = 0; ix <= dtgProsesOzellikleri1.Columns.Count - 1; ix++)
            //{
            //    dtgProsesOzellikleri1.Columns[ix].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            //}

            //SilButonuEkle(dtgProsesOzellikleri2_1);

            if (dt.Rows.Count == 0)
            {
                dt.Rows.Add();
            }

            dtgProsesOzellikleri2_1.Columns["Süt Gönderim Süresi (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2_1.Columns["Süt Gönderim Süresi (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2_1.Columns["Mayalama Süresi (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2_1.Columns["Mayalama Süresi (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2_1.Columns["Kırım ve Çedarlama Suresi(DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2_1.Columns["Kırım ve Çedarlama Suresi(DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2_1.Columns["Indirme Süresi (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2_1.Columns["Indirme Süresi (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2_1.Columns["Baskı Süresi (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2_1.Columns["Baskı Süresi (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgProsesOzellikleri2_1.Columns["Toplam Geçen Süre (DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgProsesOzellikleri2_1.Columns["Toplam Geçen Süre (DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgProsesOzellikleri2_1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgProsesOzellikleri2_1.AutoResizeRows();

            foreach (DataGridViewColumn column in dtgProsesOzellikleri2_1.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgProsesOzellikleri2_1.Rows[0].Height = dtgProsesOzellikleri2_1.Height - dtgProsesOzellikleri2_1.ColumnHeadersHeight;
        }

        private void dtgSarfMalzemeKullanimLoad()
        {
            string sql = "SELECT T1.\"U_MalzemeAdi\" as \"Malzeme Adı\",T1.\"U_MalMarkaTedarikci\" as \"Malzemenin Markası ve Tedarikçisi\",T1.\"U_PartiNo\" as \"Sarf Malzemesi Parti No\",Convert(float,T1.\"U_Miktar\") as \"Miktar\",T1.\"U_Birim\" as \"Birim\" FROM \"@AIF_TLMPRSS_ANALIZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TLMPRSS_ANALIZ5\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgSarfMalzemeKullanim.DataSource = dt;

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dtgSarfMalzemeKullanim.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //SilButonuEkle(dtgSarfMalzemeKullanim);

            if (dt.Rows.Count == 0)
            {
                sql = "select T0.ItemName as \"Malzeme Adı\",CardName as \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1 T0 inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo1 + "')";

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
                    dr["Miktar"] = Convert.ToDouble(dr1["Miktar"]);
                    dr["Birim"] = dr1["Birim"].ToString();

                    dt.Rows.Add(dr);
                }
            }

            //if (dt.Rows.Count == 0)
            //{
            //    DataRow dr = dt.NewRow();
            //    dr["Malzeme Adı"] = "MAYA";
            //    dr["Miktar"] = "0";

            //    dt.Rows.Add(dr);

            //    dr = dt.NewRow();
            //    dr["Malzeme Adı"] = "KALSİYUM KLORÜR";
            //    dr["Miktar"] = "0";

            //    dt.Rows.Add(dr);

            //    dr = dt.NewRow();
            //    dr["Malzeme Adı"] = "KÜLTÜR";
            //    dr["Miktar"] = "0";

            //    dt.Rows.Add(dr);

            //    dr = dt.NewRow();
            //    dr["Malzeme Adı"] = "TELEME POŞETİ";
            //    dr["Miktar"] = "0";

            //    dt.Rows.Add(dr);

            //    dr = dt.NewRow();
            //    dr["Malzeme Adı"] = "KASA";
            //    dr["Miktar"] = "0";

            //    dt.Rows.Add(dr);

            //    dr = dt.NewRow();
            //    dr["Malzeme Adı"] = "DİĞER";
            //    dr["Miktar"] = "0";

            //    dt.Rows.Add(dr);
            //}

            //dtgSarfMalzemeKullanim.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgSarfMalzemeKullanim.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgSarfMalzemeKullanim.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgSarfMalzemeKullanim.EnableHeadersVisualStyles = false;
            dtgSarfMalzemeKullanim.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            //foreach (DataGridViewColumn col in dtgSarfMalzemeKullanim.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Bahnschrift", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            //}

            //dtgSarfMalzemeKullanim.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgSarfMalzemeKullanim.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            //dtgSarfMalzemeKullanim.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dtgSarfMalzemeKullanim.AutoResizeRows();

            foreach (DataGridViewColumn column in dtgSarfMalzemeKullanim.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //DataRow drRow = dt.NewRow();
            //drRow["Malzeme Adı"] = "";
            //drRow["Malzeme Marka ve Tedarikçi"] = "";
            //drRow["Parti No"] = "";
            //drRow["Miktar"] = Convert.ToDouble("0");
            //drRow["Birim"] = "";

            //dt.Rows.Add(drRow);

            //dtgSarfMalzemeKullanim.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgSarfMalzemeKullanim.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            //dtgSarfMalzemeKullanim.RowTemplate.Height = 65;
            //dtgSarfMalzemeKullanim.Rows[0].Height = 65;

            //dtgSarfMalzemeKullanim.Rows[0].Height = dtgSarfMalzemeKullanim.Height - dtgSarfMalzemeKullanim.ColumnHeadersHeight;
        }

        #region Mamul Özellikleri datagridviewleri ayrı ekran oldu.

        //private void dtgMamulOzellikleri1Load()
        //{
        //    //string sql = "Select T1.\"ItemCode\" as \"Malzeme Kodu\",T1.\"Dscription\" as \"Malzeme Tanımı\", SUM(T1.\"Quantity\") as \"Miktar\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' group by T1.\"ItemCode\",T1.\"Dscription\"";

        //    string sql = "SELECT Convert(float,T1.\"U_UrtmSonrasiTelemeMik\") as \"Üretim Sonrası Teleme Miktarı(KG)\",Convert(float,T1.\"U_UrtmSonrasiTelemeMik1\") as \"1 Gün Sonra Teleme Miktarı(KG)\",Convert(float,T1.\"U_UretimRandimani\") as \"Üretim Randımanı\",T1.\"U_PersonelKodu\" as \"Personel Kodu\",T1.\"U_PersonelAdi\" as \"Personel Adı\" FROM \"@AIF_TLMPRSS_ANALIZ\" AS T0 INNER JOIN \"@AIF_TLMPRSS_ANALIZ6\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
        //    cmd = new SqlCommand(sql, Connection.sql);

        //    if (Connection.sql.State != ConnectionState.Open)
        //        Connection.sql.Open();

        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    DataTable dttemp = new DataTable();
        //    sda.Fill(dt);

        //    //Commit
        //    dtgMamulOzellikleri1.DataSource = dt;

        //    //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        //    //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
        //    dtgMamulOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        //    dtgMamulOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
        //    dtgMamulOzellikleri1.EnableHeadersVisualStyles = false;
        //    dtgMamulOzellikleri1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
        //    foreach (DataGridViewColumn col in dtgMamulOzellikleri1.Columns)
        //    {
        //        col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        col.HeaderCell.Style.Font = new Font("Bahnschrift", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        //    }

        //    //SilButonuEkle(dtgMamulOzellikleri1);

        //    if (dt.Rows.Count == 0)
        //    {
        //        System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

        //        DataRow dr = dt.NewRow();
        //        dr["Üretim Sonrası Teleme Miktarı(KG)"] = Convert.ToString("0", cultureTR);
        //        dr["1 Gün Sonra Teleme Miktarı(KG)"] = Convert.ToString("0", cultureTR);
        //        dr["Üretim Randımanı"] = Convert.ToString("0", cultureTR);

        //        dt.Rows.Add(dr);
        //    }
        //    //dt.Rows.Add();

        //    dtgMamulOzellikleri1.Columns["Üretim Sonrası Teleme Miktarı(KG)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
        //    dtgMamulOzellikleri1.Columns["Üretim Sonrası Teleme Miktarı(KG)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    dtgMamulOzellikleri1.Columns["1 Gün Sonra Teleme Miktarı(KG)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
        //    dtgMamulOzellikleri1.Columns["1 Gün Sonra Teleme Miktarı(KG)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    dtgMamulOzellikleri1.Columns["Üretim Randımanı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
        //    dtgMamulOzellikleri1.Columns["Üretim Randımanı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        //    dtgMamulOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //    //dtgMamulOzellikleri1.AutoResizeRows();

        //    dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

        //    foreach (DataGridViewColumn column in dtgMamulOzellikleri1.Columns)
        //    {
        //        column.SortMode = DataGridViewColumnSortMode.NotSortable;
        //        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    }

        //    dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;

        //}

        //private void dtgMamulOzellikleri2Load()
        //{
        //    string sql = "SELECT Convert(float,T1.\"U_KuruMadde\") as \"Kuru Madde(%)\",Convert(float,T1.\"U_YagOrani\") as \"Yağ Oranı(%)\",Convert(float,T1.\"U_PH\") as \"PH Değeri\",Convert(float,T1.\"U_SH\") as \"SH Değeri\",Convert(float,T1.\"U_TuzOrani\") as \"Tuz Oranı\" FROM \"@AIF_TLMPRSS_ANALIZ\" AS T0 INNER JOIN \"@AIF_TLMPRSS_ANALIZ7\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
        //    cmd = new SqlCommand(sql, Connection.sql);

        //    if (Connection.sql.State != ConnectionState.Open)
        //        Connection.sql.Open();

        //    SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //    DataTable dt = new DataTable();
        //    DataTable dttemp = new DataTable();
        //    sda.Fill(dt);

        //    //Commit
        //    dtgMamulOzellikleri2.DataSource = dt;

        //    //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
        //    //dtgMamulOzellikleri2.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
        //    dtgMamulOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

        //    dtgMamulOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
        //    dtgMamulOzellikleri2.EnableHeadersVisualStyles = false;
        //    dtgMamulOzellikleri2.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
        //    //foreach (DataGridViewColumn col in dtgMamulOzellikleri2.Columns)
        //    //{
        //    //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    //    col.HeaderCell.Style.Font = new Font("Bahnschrift", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
        //    //}

        //    //SilButonuEkle(dtgMamulOzellikleri2);

        //    if (dt.Rows.Count == 0)
        //    {
        //        System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

        //        DataRow dr = dt.NewRow();
        //        dr["Kuru Madde(%)"] = Convert.ToString("0", cultureTR);
        //        dr["Yağ Oranı(%)"] = Convert.ToString("0", cultureTR);
        //        dr["PH Değeri"] = Convert.ToString("0", cultureTR);
        //        dr["SH Değeri"] = Convert.ToString("0", cultureTR);
        //        dr["Tuz Oranı"] = Convert.ToString("0", cultureTR);

        //        dt.Rows.Add(dr);
        //    }
        //    //dt.Rows.Add();

        //    dtgMamulOzellikleri2.Columns["Kuru Madde(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
        //    dtgMamulOzellikleri2.Columns["Kuru Madde(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    dtgMamulOzellikleri2.Columns["Yağ Oranı(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
        //    dtgMamulOzellikleri2.Columns["Yağ Oranı(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    dtgMamulOzellikleri2.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
        //    dtgMamulOzellikleri2.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    dtgMamulOzellikleri2.Columns["SH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
        //    dtgMamulOzellikleri2.Columns["SH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        //    dtgMamulOzellikleri2.Columns["Tuz Oranı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
        //    dtgMamulOzellikleri2.Columns["Tuz Oranı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

        //    dtgMamulOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
        //    //dtgMamulOzellikleri2.AutoResizeRows();

        //    foreach (DataGridViewColumn column in dtgMamulOzellikleri2.Columns)
        //    {
        //        column.SortMode = DataGridViewColumnSortMode.NotSortable;
        //        column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //    }

        //    dtgMamulOzellikleri2.Rows[0].Height = dtgMamulOzellikleri2.Height - dtgMamulOzellikleri2.ColumnHeadersHeight;

        //}

        #endregion Mamul Özellikleri datagridviewleri ayrı ekran oldu.

        private void SilButonuEkle(DataGridView dtParam)
        {
            DataGridViewButtonColumn RemoveLineButton = new DataGridViewButtonColumn();
            if (dtParam.Columns.Contains("Sil") != true)
            {
                RemoveLineButton.Name = "Sil";
                RemoveLineButton.Text = "Sil";
                if (dtParam.Columns["removeButton"] == null)
                {
                    dtParam.Columns.Insert(dtParam.Columns.Count, RemoveLineButton);
                }
            }
        }

        private void dtgProsesOzellikleri1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Sil")
                //{
                //    dtgProsesOzellikleri1[0, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri1[1, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri1[2, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri1[3, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri1[4, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri1[5, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri1[6, e.RowIndex].Value = "0";
                //    dtgProsesOzellikleri1[7, e.RowIndex].Value = "0";
                //    dtgProsesOzellikleri1[8, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri1[9, e.RowIndex].Value = "0";
                //    return;
                //}

                bool cvp = true;

                cvp = Kontrol(dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name, dtgProsesOzellikleri1, null);

                if (!cvp)
                {
                    return;
                }


                Tuple<DateTime, DateTime> resp = null;
                Helper help = new Helper();

                if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Süt Gönderim Başlangıç Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Süt Gönderim Bitiş Saati")
                {
                    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, true);
                    //n.ShowDialog();

                    SaatTarihGirisi n = new SaatTarihGirisi(dtgProsesOzellikleri1);
                    n.ShowDialog();

                    #region Süt Gönderim Saat Kontrolleri

                    var baslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Süt Gönderim Başlangıç Saati"].Value.ToString();
                    var bitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Süt Gönderim Bitiş Saati"].Value.ToString();

                    if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                    {
                        resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                        TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                        dtgProsesOzellikleri2_1.Rows[0].Cells["Süt Gönderim Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();

                        var BaskibitisSaati = dtgProsesOzellikleri2.Rows[e.RowIndex].Cells["Baskı Bitiş Saati"].Value.ToString();

                        if (BaskibitisSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, BaskibitisSaati);

                            girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2_1.Rows[0].Cells["Baskı Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                    }
                    else
                    {
                        dtgProsesOzellikleri2_1.Rows[0].Cells["Süt Gönderim Süresi (DK)"].Value = "0";
                    }

                    //ProsesOzellikleri1Topla();

                    #endregion Süt Gönderim Saat Kontrolleri
                }
                else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Net Süt Miktarı LT" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Sütün Pastorizasyon Sicak" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Tanktaki Su Seviyesi")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1, false);
                    n.ShowDialog();

                    if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Net Süt Miktarı LT")
                    {
                        //var netSutMiktari = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value);
                        //var birgunSonraTartilan = dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                        //if (netSutMiktari > 0 && birgunSonraTartilan > 0)
                        //{
                        //    var sonuc = netSutMiktari / birgunSonraTartilan;
                        //    dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc.ToString();

                        //}
                    }
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
                else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Esanjör ve Tank Filtre Kont.")
                {
                    string sql = "Select '0' as \"Kod\",'Uygun Değil' as \"Aciklama\" ";
                    sql += " UNION ALL ";
                    sql += "Select '1' as \"Kod\",'Uygun' as \"Aciklama\" ";

                    SelectList selectList = new SelectList(sql, dtgProsesOzellikleri1, -1, 8, _autoresizerow: false);
                    selectList.ShowDialog();

                    //dtgProsesOzellikleri1.AutoResizeRows();
                }
                //else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Teleme Türü")
                //{
                //    string sql = "select T1.FldValue as 'Kod',T1.Descr 'Açıklama' from CUFD as T0 INNER JOIN UFD1 as T1 ON T0.TableID = T1.TableID and T0.FieldID=T1.FieldID where T0.AliasID = 'TelemeTuru' and T0.TableID = '@AIF_TLMPRSS_ANALIZ1'";

                //    SelectList selectList = new SelectList(sql, dtgProsesOzellikleri1, 2, 1);
                //    selectList.ShowDialog();
                //}
            }
        }

        private void dtgProsesOzellikleri2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Sil")
                //{
                //    dtgProsesOzellikleri2[0, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri2[1, e.RowIndex].Value = "0";
                //    dtgProsesOzellikleri2[2, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri2[3, e.RowIndex].Value = "0";
                //    dtgProsesOzellikleri2[4, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri2[5, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri2[6, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri2[7, e.RowIndex].Value = "";
                //    dtgProsesOzellikleri2[8, e.RowIndex].Value = "0";
                //    return;
                //}

                bool cvp = true;

                if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Mayalama Saati")
                {
                    cvp = Kontrol(dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name, dtgProsesOzellikleri2, dtgProsesOzellikleri1);
                }
                else
                {
                    cvp = Kontrol(dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name, dtgProsesOzellikleri2, null);
                }

                if (!cvp)
                {
                    return;
                }

                Tuple<DateTime, DateTime> resp = null;
                Helper help = new Helper();

                if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Mayalama Saati" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Kırım ve Çedarlama Başlangıç Saati" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Kırım ve Çedarlama Bitiş Saati" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "İndirme Bitiş Saati" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Baskı Başlangıç Saati" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Baskı Bitiş Saati")
                {
                    //SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri2, true);
                    //n.ShowDialog();

                    SaatTarihGirisi n = new SaatTarihGirisi(dtgProsesOzellikleri2);
                    n.ShowDialog();

                    #region Mayalama Süresi ve Kırım Çedarlama Saat Kontrolleri

                    if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Mayalama Saati" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Kırım ve Çedarlama Başlangıç Saati")
                    {
                        var baslangicSaati = dtgProsesOzellikleri2.Rows[e.RowIndex].Cells["Mayalama Saati"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri2.Rows[e.RowIndex].Cells["Kırım ve Çedarlama Başlangıç Saati"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2_1.Rows[0].Cells["Mayalama Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2_1.Rows[0].Cells["Mayalama Süresi (DK)"].Value = "0";
                        }
                    }
                    else if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Kırım ve Çedarlama Başlangıç Saati" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Kırım ve Çedarlama Bitiş Saati")
                    {
                        var baslangicSaati = dtgProsesOzellikleri2.Rows[e.RowIndex].Cells["Kırım ve Çedarlama Başlangıç Saati"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri2.Rows[e.RowIndex].Cells["Kırım ve Çedarlama Bitiş Saati"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2_1.Rows[0].Cells["Kırım ve Çedarlama Suresi(DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2_1.Rows[0].Cells["Kırım ve Çedarlama Suresi(DK)"].Value = "0";
                        }
                    }
                    else if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Kırım ve Çedarlama Bitiş Saati" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "İndirme Bitiş Saati")
                    {
                        var baslangicSaati = dtgProsesOzellikleri2.Rows[e.RowIndex].Cells["Kırım ve Çedarlama Bitiş Saati"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri2.Rows[e.RowIndex].Cells["İndirme Bitiş Saati"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2_1.Rows[0].Cells["Indirme Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2_1.Rows[0].Cells["Indirme Süresi (DK)"].Value = "0";
                        }
                    }
                    else if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Baskı Başlangıç Saati" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Baskı Bitiş Saati")
                    {
                        var baslangicSaati = dtgProsesOzellikleri2.Rows[e.RowIndex].Cells["Baskı Başlangıç Saati"].Value.ToString();
                        var bitisSaati = dtgProsesOzellikleri2.Rows[e.RowIndex].Cells["Baskı Bitiş Saati"].Value.ToString();

                        if (baslangicSaati.ToString() != "" && bitisSaati.ToString() != "")
                        {
                            resp = help.SaatDuzenle(baslangicSaati, bitisSaati);

                            TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2_1.Rows[0].Cells["Baskı Süresi (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();

                            var SutGonderimBaslangic = dtgProsesOzellikleri1.Rows[0].Cells["Süt Gönderim Başlangıç Saati"].Value.ToString();

                            resp = help.SaatDuzenle(SutGonderimBaslangic, bitisSaati);

                            girisCikisFarki = resp.Item2 - resp.Item1;

                            dtgProsesOzellikleri2_1.Rows[0].Cells["Toplam Geçen Süre (DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                        }
                        else
                        {
                            dtgProsesOzellikleri2_1.Rows[0].Cells["Baskı Süresi (DK)"].Value = "0";
                        }
                    }

                    //ProsesOzellikleri1Topla();

                    #endregion Mayalama Süresi ve Kırım Çedarlama Saat Kontrolleri
                }
                else if (dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Mayalama Sıcaklığı" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Çedarlama Sıcaklığı" || dtgProsesOzellikleri2.Columns[e.ColumnIndex].Name == "Üretim Depo Sıcaklığı")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri2, false);
                    n.ShowDialog();
                }
            }
        }

        private void ProsesOzellikleri1Topla()
        {
            var SutGonderimSuresi = dtgProsesOzellikleri2_1.Rows[0].Cells["Süt Gönderim Süresi (DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2_1.Rows[0].Cells["Süt Gönderim Süresi (DK)"].Value);

            var MayalamaSuresi = dtgProsesOzellikleri2_1.Rows[0].Cells["Mayalama Süresi (DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2_1.Rows[0].Cells["Mayalama Süresi (DK)"].Value);

            var KirimVeCedarlamaSuresi = dtgProsesOzellikleri2_1.Rows[0].Cells["Kırım ve Çedarlama Suresi(DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2_1.Rows[0].Cells["Kırım ve Çedarlama Suresi(DK)"].Value);

            var IndirmeSuresi = dtgProsesOzellikleri2_1.Rows[0].Cells["Indirme Süresi (DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2_1.Rows[0].Cells["Indirme Süresi (DK)"].Value);

            var BaskiSuresi = dtgProsesOzellikleri2_1.Rows[0].Cells["Baskı Süresi (DK)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri2_1.Rows[0].Cells["Baskı Süresi (DK)"].Value);

            var sonuc = SutGonderimSuresi + MayalamaSuresi + KirimVeCedarlamaSuresi + IndirmeSuresi + BaskiSuresi;

            dtgProsesOzellikleri2_1.Rows[0].Cells["Toplam Geçen Süre (DK)"].Value = sonuc.ToString();

            dtgProsesOzellikleri2_1.AutoResizeRows();
        }

        private void dtgSutunOzellikleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                //if (dtgSutunOzellikleri.Columns[e.ColumnIndex].Name == "Sil")
                //{
                //    dtgSutunOzellikleri[0, e.RowIndex].Value = "0";
                //    dtgSutunOzellikleri[1, e.RowIndex].Value = "0";
                //    dtgSutunOzellikleri[2, e.RowIndex].Value = "0";
                //    dtgSutunOzellikleri[3, e.RowIndex].Value = "0";
                //    dtgSutunOzellikleri[4, e.RowIndex].Value = "0";
                //    dtgSutunOzellikleri[5, e.RowIndex].Value = "0";
                //    return;
                //}
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgSutunOzellikleri, false);
                n.ShowDialog();
            }
        }

        private void dtgProsesOzellikleri2_1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            return;
            try
            {
                if (dtgProsesOzellikleri2_1.Columns[e.ColumnIndex].Name == "Süt Gönderim Süresi (DK)" || dtgProsesOzellikleri2_1.Columns[e.ColumnIndex].Name == "Mayalama Süresi (DK)" || dtgProsesOzellikleri2_1.Columns[e.ColumnIndex].Name == "Kırım ve Çedarlama Suresi(DK)" || dtgProsesOzellikleri2_1.Columns[e.ColumnIndex].Name == "Indirme Süresi (DK)" || dtgProsesOzellikleri2_1.Columns[e.ColumnIndex].Name == "Baskı Süresi (DK)")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri2_1);
                    n.ShowDialog();
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtgSarfMalzemeKullanim_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.RowIndex != -1)
            //{
            //    if (dtgSarfMalzemeKullanim.Columns[e.ColumnIndex].Name == "Sil")
            //    {
            //        dtgSarfMalzemeKullanim[1, e.RowIndex].Value = "";
            //        dtgSarfMalzemeKullanim[2, e.RowIndex].Value = "";
            //        dtgSarfMalzemeKullanim[3, e.RowIndex].Value = "0";
            //        dtgSarfMalzemeKullanim[4, e.RowIndex].Value = "";
            //        return;
            //    }
            //    if (dtgSarfMalzemeKullanim.Columns[e.ColumnIndex].Name == "Miktar")
            //    {
            //        SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgSarfMalzemeKullanim);
            //        n.ShowDialog();
            //    }
            //}
        }

        #region Mamul Özellikleri datagridviewleri ayrı ekran oldu.

        //private void dtgMamulOzellikleri1_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex != -1)
        //    {
        //        //if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Sil")
        //        //{
        //        //    dtgMamulOzellikleri1[0, e.RowIndex].Value = "0";
        //        //    dtgMamulOzellikleri1[1, e.RowIndex].Value = "0";
        //        //    dtgMamulOzellikleri1[2, e.RowIndex].Value = "0";
        //        //    dtgMamulOzellikleri1[3, e.RowIndex].Value = "";
        //        //    dtgMamulOzellikleri1[4, e.RowIndex].Value = "";
        //        //    return;
        //        //}
        //        if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "1 Gün Sonra Teleme Miktarı(KG)")
        //        {
        //            SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOzellikleri1);
        //            n.ShowDialog();
        //            var netSutMiktari = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Net Süt Miktarı LT"].Value);
        //            var birgunSonraTartilan = dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgMamulOzellikleri1.Rows[0].Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

        //            if (netSutMiktari > 0 && birgunSonraTartilan > 0)
        //            {
        //                var sonuc = netSutMiktari / birgunSonraTartilan;
        //                dtgMamulOzellikleri1.Rows[0].Cells["Üretim Randımanı"].Value = sonuc.ToString();

        //            }
        //        }
        //        else if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Personel Kodu" || dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name == "Personel Adı")
        //        {
        //            if (istasyon.StartsWith("IST"))
        //            {
        //                //string sql = "Select \"empID\" as \"Kullanıcı Kodu\", (\"firstName\" + ' ' + \"lastName\") as 'Ad Soyad' from OHEM where \"Active\" = 'Y'";

        //                string field = "U_" + istasyon;

        //                DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
        //                string gunfield = "U_Gun" + dtTarih.Day;

        //                string sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

        //                //string sql = "Select \"U_PersonelNo\" as \"Personel No\",\"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"" + field + "\" = 'Y'";

        //                SelectList selectList = new SelectList(sql, dtgMamulOzellikleri1, 3, 4);
        //                selectList.ShowDialog();

        //                dtgMamulOzellikleri1.AutoResizeRows();
        //            }
        //            //UVTServiceSoapClient UVTServiceSoapClient = new UVTServiceSoapClient();
        //            //var resp = UVTServiceSoapClient.GetEmployess();

        //            //SelectList nesne = new SelectList("", dtgMamulOzellikleri1, 3, 4, _dtparams: resp.List);
        //            //nesne.ShowDialog();

        //        }
        //        else if (dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name != "Personel Kodu" && dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name != "Personel Adı" /*&& dtgMamulOzellikleri1.Columns[e.ColumnIndex].Name != "Sil"*/)
        //        {
        //            SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOzellikleri1);
        //            n.ShowDialog();
        //        }

        //    }
        //}

        //private void dtgMamulOzellikleri2_CellClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    if (e.RowIndex != -1)
        //    {
        //        //if (dtgMamulOzellikleri2.Columns[e.ColumnIndex].Name == "Sil")
        //        //{
        //        //    dtgMamulOzellikleri2[0, e.RowIndex].Value = "0";
        //        //    dtgMamulOzellikleri2[1, e.RowIndex].Value = "0";
        //        //    dtgMamulOzellikleri2[2, e.RowIndex].Value = "0";
        //        //    dtgMamulOzellikleri2[3, e.RowIndex].Value = "0";
        //        //    return;
        //        //}
        //        SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgMamulOzellikleri2, false);
        //        n.ShowDialog();
        //    }
        //}

        #endregion Mamul Özellikleri datagridviewleri ayrı ekran oldu.

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                TelemeProsesTakipAnaliz nesne = new TelemeProsesTakipAnaliz();
                ProsesOzellikleri1 prosesOzellikleri = new ProsesOzellikleri1();
                List<ProsesOzellikleri1> prosesOzellikleris = new List<ProsesOzellikleri1>();
                SutunOzellikleri1 sutunOzellikleri1 = new SutunOzellikleri1();
                List<SutunOzellikleri1> sutunOzellikleri1s = new List<SutunOzellikleri1>();
                ProsesOzellikleri2 prosesOzellikleri2 = new ProsesOzellikleri2();
                List<ProsesOzellikleri2> prosesOzellikleri2s = new List<ProsesOzellikleri2>();
                ProsesOzellikleri2_1 prosesOzellikleri2_1 = new ProsesOzellikleri2_1();
                List<ProsesOzellikleri2_1> prosesOzellikleri2_1s = new List<ProsesOzellikleri2_1>();
                SarfMalzemeKullanim sarfMalzemeKullanim = new SarfMalzemeKullanim();
                List<SarfMalzemeKullanim> sarfMalzemeKullanims = new List<SarfMalzemeKullanim>();
                MamulOzellikleri mamulOzellikleri = new MamulOzellikleri();
                List<MamulOzellikleri> mamulOzellikleris = new List<MamulOzellikleri>();
                MamulOzellikleri1 mamulOzellikleri1 = new MamulOzellikleri1();
                List<MamulOzellikleri1> mamulOzellikleri1s = new List<MamulOzellikleri1>();

                nesne.PartiNo = txtPartiNo.Text;
                nesne.Aciklama = txtAciklama.Text;
                nesne.UretimTarihi = tarih1;

                foreach (DataGridViewRow dr in dtgProsesOzellikleri1.Rows)
                {
                    prosesOzellikleri = new ProsesOzellikleri1();
                    prosesOzellikleri.PartiNo = dr.Cells["Parti No"].Value == DBNull.Value ? "" : dr.Cells["Parti No"].Value.ToString();
                    prosesOzellikleri.TelemeTuru = dr.Cells["Teleme türü"].Value == DBNull.Value ? "" : dr.Cells["Teleme türü"].Value.ToString();
                    prosesOzellikleri.GorevliOperator = dr.Cells["Görevli Operatör"].Value == DBNull.Value ? "" : dr.Cells["Görevli Operatör"].Value.ToString();
                    prosesOzellikleri.GorevliOperatorAdi = dr.Cells["Görevli Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Görevli Operatör Adı"].Value.ToString();

                    prosesOzellikleri.SutGondermeBaslangicSaati = dr.Cells["Süt Gönderim Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Süt Gönderim Başlangıç Saati"].Value.ToString();
                    prosesOzellikleri.SutGondermeBitisSaati = dr.Cells["Süt Gönderim Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Süt Gönderim Bitiş Saati"].Value.ToString();
                    prosesOzellikleri.NetSutMiktari = dr.Cells["Net Süt Miktarı LT"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Net Süt Miktarı LT"].Value);
                    prosesOzellikleri.SutPastorizasyonSicakligi = dr.Cells["Sütün Pastorizasyon Sicak"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Sütün Pastorizasyon Sicak"].Value);
                    prosesOzellikleri.EsanjorTankFiltreKontrolu = dr.Cells["Esanjör ve Tank Filtre Kont."].Value == DBNull.Value ? "" : dr.Cells["Esanjör ve Tank Filtre Kont."].Value.ToString();
                    prosesOzellikleri.TanktakiSuSeviyesi = dr.Cells["Tanktaki Su Seviyesi"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tanktaki Su Seviyesi"].Value);

                    prosesOzellikleris.Add(prosesOzellikleri);
                }

                nesne.prosessOzellikleri1Detay = prosesOzellikleris.ToArray();

                foreach (DataGridViewRow dr in dtgSutunOzellikleri.Rows)
                {
                    sutunOzellikleri1 = new SutunOzellikleri1();
                    sutunOzellikleri1.KuruMadde = dr.Cells["Kuru Madde (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde (%)"].Value);
                    sutunOzellikleri1.YagOrani = dr.Cells["Yağ Oranı (%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ Oranı (%)"].Value);
                    sutunOzellikleri1.PH = dr.Cells["PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH Değeri"].Value);
                    sutunOzellikleri1.SH = dr.Cells["SH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH Değeri"].Value);
                    sutunOzellikleri1.SuOrani = dr.Cells["Su Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Su Oranı"].Value);
                    sutunOzellikleri1.ProteinOrani = dr.Cells["Protein Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Protein Oranı"].Value);

                    sutunOzellikleri1s.Add(sutunOzellikleri1);
                }

                nesne.SutOzellikleriDetay = sutunOzellikleri1s.ToArray();

                foreach (DataGridViewRow dr in dtgProsesOzellikleri2.Rows)
                {
                    prosesOzellikleri2 = new ProsesOzellikleri2();

                    prosesOzellikleri2.MayalamaSaati = dr.Cells["Mayalama Saati"].Value == DBNull.Value ? "" : dr.Cells["Mayalama Saati"].Value.ToString();
                    prosesOzellikleri2.MayalamaSicakligi = dr.Cells["Mayalama Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Mayalama Sıcaklığı"].Value);
                    prosesOzellikleri2.KirimVeCedarlamaBaslangicSaati = dr.Cells["Kırım ve Çedarlama Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Kırım ve Çedarlama Başlangıç Saati"].Value.ToString();
                    prosesOzellikleri2.CedarlamaSicakligi = dr.Cells["Çedarlama Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Çedarlama Sıcaklığı"].Value);
                    prosesOzellikleri2.KirimVeCedarlamaBitisSaati = dr.Cells["Kırım ve Çedarlama Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Kırım ve Çedarlama Bitiş Saati"].Value.ToString();
                    prosesOzellikleri2.IndirmeBitisSaati = dr.Cells["İndirme Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["İndirme Bitiş Saati"].Value.ToString();
                    prosesOzellikleri2.BaskiBaslangicSaati = dr.Cells["Baskı Başlangıç Saati"].Value == DBNull.Value ? "" : dr.Cells["Baskı Başlangıç Saati"].Value.ToString();
                    prosesOzellikleri2.BaskiBitisSaati = dr.Cells["Baskı Bitiş Saati"].Value == DBNull.Value ? "" : dr.Cells["Baskı Bitiş Saati"].Value.ToString();

                    prosesOzellikleri2.UretimDepoSicakligi = dr.Cells["Üretim Depo Sıcaklığı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretim Depo Sıcaklığı"].Value);

                    prosesOzellikleri2s.Add(prosesOzellikleri2);
                }

                nesne.prosesOzellikleri2Detay = prosesOzellikleri2s.ToArray();

                foreach (DataGridViewRow dr in dtgProsesOzellikleri2_1.Rows)
                {
                    prosesOzellikleri2_1 = new ProsesOzellikleri2_1();

                    prosesOzellikleri2_1.SutGonderimSuresiDakika = dr.Cells["Süt Gönderim Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Süt Gönderim Süresi (DK)"].Value);
                    prosesOzellikleri2_1.MayalamaSuresiDakika = dr.Cells["Mayalama Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Mayalama Süresi (DK)"].Value);
                    prosesOzellikleri2_1.KirimVeCedarlamaSuresiDakika = dr.Cells["Kırım ve Çedarlama Suresi(DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kırım ve Çedarlama Suresi(DK)"].Value);
                    prosesOzellikleri2_1.IndirimSuresiDakika = dr.Cells["Indirme Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Indirme Süresi (DK)"].Value);
                    prosesOzellikleri2_1.BaskiSuresiDakika = dr.Cells["Baskı Süresi (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Baskı Süresi (DK)"].Value);
                    prosesOzellikleri2_1.ToplamGecenSureDakika = dr.Cells["Toplam Geçen Süre (DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Geçen Süre (DK)"].Value);

                    prosesOzellikleri2_1s.Add(prosesOzellikleri2_1);
                }

                nesne.prosesOzellikleri2_1_Detay = prosesOzellikleri2_1s.ToArray();

                foreach (DataGridViewRow dr in dtgSarfMalzemeKullanim.Rows)
                {
                    sarfMalzemeKullanim = new SarfMalzemeKullanim();

                    sarfMalzemeKullanim.MalzemeAdi = dr.Cells["Malzeme Adı"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Adı"].Value.ToString();
                    sarfMalzemeKullanim.MalzemeMarkasiVeTedarikcisi = dr.Cells["Malzemenin Markası ve Tedarikçisi"].Value == DBNull.Value ? "" : dr.Cells["Malzemenin Markası ve Tedarikçisi"].Value.ToString();
                    sarfMalzemeKullanim.PartiNo = dr.Cells["Sarf Malzemesi Parti No"].Value == DBNull.Value ? "" : dr.Cells["Sarf Malzemesi Parti No"].Value.ToString();
                    sarfMalzemeKullanim.Miktar = dr.Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Miktar"].Value);
                    sarfMalzemeKullanim.Birim = dr.Cells["Birim"].Value == DBNull.Value ? "" : dr.Cells["Birim"].Value.ToString();

                    sarfMalzemeKullanims.Add(sarfMalzemeKullanim);
                }

                nesne.sarfMalzemeKullanimDetay = sarfMalzemeKullanims.ToArray();

                #region Mamul Özellikleri datagridviewleri ayrı ekran oldu.

                //foreach (DataGridViewRow dr in dtgMamulOzellikleri1.Rows)
                //{
                //    mamulOzellikleri = new MamulOzellikleri();

                //    mamulOzellikleri.UretimSonrasiTelemeMiktari = dr.Cells["Üretim Sonrası Teleme Miktarı(KG)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretim Sonrası Teleme Miktarı(KG)"].Value);

                //    mamulOzellikleri.BirGunSonraTelemeMiktari = dr.Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["1 Gün Sonra Teleme Miktarı(KG)"].Value);

                //    mamulOzellikleri.UretimRandimani = dr.Cells["Üretim Randımanı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Üretim Randımanı"].Value);

                //    mamulOzellikleri.PersonelKodu = dr.Cells["Personel Kodu"].Value == DBNull.Value ? "" : dr.Cells["Personel Kodu"].Value.ToString();
                //    mamulOzellikleri.PersonelAdi = dr.Cells["Personel Adı"].Value == DBNull.Value ? "" : dr.Cells["Personel Adı"].Value.ToString();

                //    mamulOzellikleris.Add(mamulOzellikleri);
                //}

                //nesne.mamulOzellikleriDetay = mamulOzellikleris.ToArray();

                //foreach (DataGridViewRow dr in dtgMamulOzellikleri2.Rows)
                //{
                //    mamulOzellikleri1 = new MamulOzellikleri1();

                //    string sql = "SELECT Convert(float,T1.\"U_KuruMadde\") as \"Kuru Madde(%)\",Convert(float,T1.\"U_YagOrani\") as \"Yağ Oranı(%)\",Convert(float,T1.\"U_PH\") as \"PH Değeri\",Convert(float,T1.\"U_SH\") as \"SH Değeri\",Convert(float,T1.\"U_TuzOrani\") as \"Tuz Oranı\" FROM \"@AIF_TLMPRSS_ANALIZ\" AS T0 INNER JOIN \"@AIF_TLMPRSS_ANALIZ7\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

                //    mamulOzellikleri1.KuruMadde = dr.Cells["Kuru Madde(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde(%)"].Value);
                //    mamulOzellikleri1.YagOrani = dr.Cells["Yağ Oranı(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Yağ Oranı(%)"].Value);
                //    mamulOzellikleri1.PH = dr.Cells["PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH Değeri"].Value);
                //    mamulOzellikleri1.SH = dr.Cells["SH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["SH Değeri"].Value);
                //    mamulOzellikleri1.TuzOrani = dr.Cells["Tuz Oranı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Tuz Oranı"].Value);

                //    mamulOzellikleri1s.Add(mamulOzellikleri1);
                //}

                //nesne.mamulOzellikleri1Detay = mamulOzellikleri1s.ToArray();

                #endregion Mamul Özellikleri datagridviewleri ayrı ekran oldu.

                var resp = client.AddOrUpdateTelemeProsesAnalizTakip(nesne, Giris.dbName, Giris.mKodValue);

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

        private void btnSutunOzellikleri_Click(object sender, EventArgs e)
        {
        }

        private void btnProsesOzellikleri2_1_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
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
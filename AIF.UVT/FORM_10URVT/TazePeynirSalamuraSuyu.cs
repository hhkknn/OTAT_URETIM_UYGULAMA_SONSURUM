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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT.FORM_10URVT
{
    public partial class TazePeynirSalamuraSuyu : Form
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
        private string UrunKodu = "";
        private SqlCommand cmd = null;

        public List<kontrolListesi> kontrolListesis = new List<kontrolListesi>();
        public class kontrolListesi
        {
            public string aktifKolon { get; set; }
            public string kontroledilmesigerekenKolon { get; set; }
        }
        public TazePeynirSalamuraSuyu(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, int _width, int _height, string _tarih1, string _urunKodu)
        {
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;
            //initialFontSize = txtUretimTarihi.Font.Size;
            //txtUretimTarihi.Resize += Form_Resize;
            //font end

            UretimFisNo = _UretimFisNo;
            partiNo = _PartiNo;
            UrunTanimi = _UrunTanimi;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;
            UrunKodu = _urunKodu;

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

            label4.Font = new Font(label4.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label4.Font.Style);

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

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOnayla.Font.Style);

            btnAciklama.Font = new Font(btnAciklama.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnAciklama.Font.Style);

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
        private void TazePeynirSalamuraSuyu_Load(object sender, EventArgs e)
        {
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_TAZEPEYSALSUYU\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
            dtgSalamuraOzellikleriLoad();
            dtgSalamuraMalzemeLoad();

            dtgProsesOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgProsesOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;

            DataGridViewColumn dataGridViewColumn = dtgSalamuraOzellikleri.Columns["Hammadde ve Sarf Toplam(KG)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtgSalamuraOzellikleri.Columns["Bome Değeri"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgSalamuraOzellikleri.Columns["PH Değeri"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;
            dtgSalamuraMalzeme.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
        }
        private void dtgProsesOzellikleri1Load()
        {
            try
            {
                string sql = "Select T1.\"U_SalHazSrmlu\" as \"Salamura Hazırlayan Sorumlu\",T1.\"U_OprsynBasSaat\" as \"Operasyon Baş.Saati\",T1.\"U_PastSicaklik\" as \"Past. Sıcaklığı(C)\",T1.\"U_PastBasSaat\" as \"Past. Baş.Saati\",T1.\"U_PastBitSaat\" as \"Past. Bit.Saati\",T1.\"U_SalTnkFiltKnt\" as \"Salamura Tank Filtre Kont(KKN4)\",T1.\"U_HazSalMiktar\" as \"Haz. Salamura Miktar(LT)\",T1.\"U_OprsynBitSaat\" as \"Operasyon Bit.Saati\"  from \"@AIF_TAZEPEYSALSUYU\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_TAZEPEYSALSUYU1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                //SilButonuEkle(dtgMamulOzellikleri1);

                if (dt.Rows.Count == 0)
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dt.NewRow();
                    //dr["Parti No"] = partiNo;
                    dr["Past. Sıcaklığı(C)"] = Convert.ToString("0", cultureTR);
                    dr["Salamura Tank Filtre Kont(KKN4)"] = "";
                    dr["Haz. Salamura Miktar(LT)"] = Convert.ToString("0", cultureTR);

                    dt.Rows.Add(dr);
                }
                //dt.Rows.Add();

                dtgProsesOzellikleri1.Columns["Past. Sıcaklığı(C)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgProsesOzellikleri1.Columns["Past. Sıcaklığı(C)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgProsesOzellikleri1.Columns["Salamura Tank Filtre Kont(KKN4)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgProsesOzellikleri1.Columns["Salamura Tank Filtre Kont(KKN4)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgProsesOzellikleri1.Columns["Haz. Salamura Miktar(LT)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgProsesOzellikleri1.Columns["Haz. Salamura Miktar(LT)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgMamulOzellikleri1.AutoResizeRows();
                //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;
                dtgProsesOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                dtgProsesOzellikleri1.EnableHeadersVisualStyles = false;
                dtgProsesOzellikleri1.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

                foreach (DataGridViewColumn column in dtgProsesOzellikleri1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                //dtgProsesOzellikleri1.Columns["Parti No"].Width = dtgProsesOzellikleri1.Columns["Parti No"].Width + 20;
                //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;

                #region Kontrol listesi oluşturma 

                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Operasyon Baş.Saati",
                    kontroledilmesigerekenKolon = "Salamura Hazırlayan Sorumlu"
                });
                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Past. Sıcaklığı(C)",
                    kontroledilmesigerekenKolon = "Operasyon Baş.Saati"
                });
                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Past. Baş.Saati",
                    kontroledilmesigerekenKolon = "Past. Sıcaklığı(C)"
                });
                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Past. Bit.Saati",
                    kontroledilmesigerekenKolon = "Past. Baş.Saati"
                });
                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Salamura Tank Filtre Kont(KKN4)",
                    kontroledilmesigerekenKolon = "Past. Bit.Saati"
                });
                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Haz. Salamura Miktar(LT)",
                    kontroledilmesigerekenKolon = "Salamura Tank Filtre Kont(KKN4)"
                });
                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Operasyon Bit.Saati",
                    kontroledilmesigerekenKolon = "Haz. Salamura Miktar(LT)"
                });
                #endregion
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
        }
        private void dtgProsesOzellikleri2Load()
        {
            try
            {
                string sql = "Select T1.\"U_PastSuresi\" as \"Pastörizasyon Süresi(DK)\",T1.\"U_ToplamGecenSure\" as \"Toplam Geçen Süre(DK)\" from \"@AIF_TAZEPEYSALSUYU\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_TAZEPEYSALSUYU2\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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

                //SilButonuEkle(dtgMamulOzellikleri1);

                if (dt.Rows.Count == 0)
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dt.NewRow();
                    dr["Pastörizasyon Süresi(DK)"] = Convert.ToString("0", cultureTR);
                    dr["Toplam Geçen Süre(DK)"] = Convert.ToString("0", cultureTR);

                    dt.Rows.Add(dr);
                }
                //dt.Rows.Add();

                dtgProsesOzellikleri2.Columns["Pastörizasyon Süresi(DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgProsesOzellikleri2.Columns["Pastörizasyon Süresi(DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgProsesOzellikleri2.Columns["Toplam Geçen Süre(DK)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgProsesOzellikleri2.Columns["Toplam Geçen Süre(DK)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dtgProsesOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgMamulOzellikleri1.AutoResizeRows(); 
                //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

                dtgProsesOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
                dtgProsesOzellikleri2.EnableHeadersVisualStyles = false;
                dtgProsesOzellikleri2.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                foreach (DataGridViewColumn column in dtgProsesOzellikleri2.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
        }
        private void dtgSalamuraOzellikleriLoad()
        {
            try
            {
                string sql = "SELECT \"U_HamSarfTopKg\" as \"Hammadde ve Sarf Toplam(KG)\", T1.\"U_BomeDegeri\" as \"Bome Değeri\", T1.\"U_PhDegeri\" as \"PH Değeri\" FROM \"@AIF_TAZEPEYSALSUYU\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TAZEPEYSALSUYU3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                //Commit
                dtgSalamuraOzellikleri.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    sql = "SELECT SUM(T1.\"IssuedQty\") as \"Miktar\" FROM OWOR T0  INNER JOIN WOR1 T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" WHERE T0.\"DocNum\" = '" + UretimFisNo + "' and T1.\"U_SarfaDahilEt\" = 'E' ";

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
                        dr["Hammadde ve Sarf Toplam(KG)"] = dr1["Miktar"];
                        dr["Bome Değeri"] = Convert.ToString("0", cultureTR);
                        dr["PH Değeri"] = Convert.ToString("0", cultureTR);

                        dt.Rows.Add(dr); 
                    }
                }

                dtgSalamuraOzellikleri.Columns["Hammadde ve Sarf Toplam(KG)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgSalamuraOzellikleri.Columns["Hammadde ve Sarf Toplam(KG)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgSalamuraOzellikleri.Columns["Bome Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgSalamuraOzellikleri.Columns["Bome Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgSalamuraOzellikleri.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgSalamuraOzellikleri.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dtgSalamuraOzellikleri.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgMamulOzellikleri1.AutoResizeRows();
                //dtgProsesOzellikleri1.AutoResizeColumns();

                //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;
                dtgSalamuraOzellikleri.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
                dtgSalamuraOzellikleri.EnableHeadersVisualStyles = false;
                dtgSalamuraOzellikleri.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                foreach (DataGridViewColumn column in dtgSalamuraOzellikleri.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                //dtgMamulOz.Rows[0].Height = dtgMamulOz.Height - dtgMamulOz.ColumnHeadersHeight;
                //dtgMamulOz.AutoResizeColumns();

                #region Kontrol listesi oluşturma 

                //kontrolListesis.Add(new kontrolListesi
                //{
                //    aktifKolon = "Üretilen Miktar",
                //    kontroledilmesigerekenKolon = "Baskı Bitiş Saati"
                //}); 
                //kontrolListesis.Add(new kontrolListesi
                //{
                //    aktifKolon = "Kontrol Eden Personel",
                //    kontroledilmesigerekenKolon = "Üretilen Miktar"
                //});

                #endregion


                //int n = Convert.ToInt32(dtgSalamuraMalzeme.Rows.Count.ToString());
                //for (int i = 0; i < n; i++)
                //{
                dtgSalamuraOzellikleri.Rows[0].Cells[0].ReadOnly = true;
                //}
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
        }
        private void dtgSalamuraMalzemeLoad()
        {
            try
            {
                string sql = "SELECT T1.\"U_MalzemeAdi\" as \"Malzeme Adı\",T1.\"U_MalMarkaTedarikci\" as \"Malzemenin Markası ve Tedarikçisi\",T1.\"U_PartiNo\" as \"Sarf Malzemesi Parti No\",Convert(float,T1.\"U_Miktar\") as \"Miktar\",T1.\"U_Birim\" as \"Birim\" FROM \"@AIF_TAZEPEYSALSUYU\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TAZEPEYSALSUYU4\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                //Commit
                dtgSalamuraMalzeme.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    #region old
                    //sql = "select T0.ItemName as \"Malzeme Adı\",CardName as \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1 T0 WITH (NOLOCK) inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo + "') and T1.\"ItmsGrpCod\" NOT IN('105','106','107') "; 
                    #endregion
                    sql = "select T0.ItemName as \"Malzeme Adı\",ISNULL((SELECT TOP 1 TT.CardName FROM IBT1_LINK AS TT INNER JOIN OCRD T09 ON TT.CardCode = T09.CardCode WHERE TT.ItemCode = T0.ItemCode AND TT.BatchNum = T0.BatchNum ORDER BY TT.DocDate DESC ),'') AS \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1_LINK T0 WITH (NOLOCK) inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo + "') and T1.\"ItmsGrpCod\" NOT IN('105','106','107')  Order By T0.ItemName ";


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

                dtgSalamuraMalzeme.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgSalamuraMalzeme.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dtgSalamuraMalzeme.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgSalamuraMalzeme.AutoResizeRows();

                dtgSalamuraMalzeme.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
                dtgSalamuraMalzeme.EnableHeadersVisualStyles = false;
                dtgSalamuraMalzeme.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                foreach (DataGridViewColumn column in dtgSalamuraMalzeme.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
                }

            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
        }
        private void dtgProsesOzellikleri1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex != -1)
                {
                    bool cvp = true;

                    cvp = Kontrol(dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name, dtgProsesOzellikleri1, null);

                    if (!cvp)
                    {
                        return;
                    }

                    if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Salamura Hazırlayan Sorumlu")
                    {
                        if (istasyon.StartsWith("IST"))
                        {
                            //string sql = "Select \"empID\" as \"Kullanıcı Kodu\", (\"firstName\" + ' ' + \"lastName\") as 'Ad Soyad' from OHEM where \"Active\" = 'Y'";

                            string field = "U_" + istasyon;

                            DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                            string gunfield = "U_Gun" + dtTarih.Day;

                            string sql1 = "";

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
                            sql1 = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

                            if (AtanmisIsler.Joker)
                            {
                                sql1 += " UNION ALL ";

                                sql1 += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                            }
                            #endregion Günlük Personel Planlama 4 ekranı

                            SelectList selectList = new SelectList(sql1, dtgProsesOzellikleri1, -1, e.ColumnIndex, _autoresizerow: false);
                            selectList.ShowDialog();

                            //dtgProsesOzellikleri1.AutoResizeRows();
                        }
                    }
                    else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Operasyon Baş.Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Past. Baş.Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Past. Bit.Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Operasyon Bit.Saati")
                    {
                        SaatTarihGirisi n = new SaatTarihGirisi(dtgProsesOzellikleri1);
                        n.ShowDialog();

                        #region süre hesaplama 
                        Tuple<DateTime, DateTime> resp = null;
                        Helper help = new Helper();

                        if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Past. Baş.Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Past. Bit.Saati")
                        {
                            //ProsesOzellikleri2PastorizasyonSuresi();

                            var pastBaslangicSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Past. Baş.Saati"].Value.ToString();
                            var pastBitisSaati = dtgProsesOzellikleri1.Rows[e.RowIndex].Cells["Past. Bit.Saati"].Value.ToString();

                            if (pastBaslangicSaati.ToString() != "" && pastBitisSaati.ToString() != "")
                            {
                                resp = help.SaatDuzenle(pastBaslangicSaati, pastBitisSaati);

                                TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;
                                dtgProsesOzellikleri2.Rows[0].Cells["Pastörizasyon Süresi(DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                            }
                            else
                            {
                                dtgProsesOzellikleri2.Rows[0].Cells["Pastörizasyon Süresi(DK)"].Value = "0";
                            }
                        }

                        if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Operasyon Bit.Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Operasyon Baş.Saati")
                        {
                            //ProsesOzellikleri2ToplanGecenSure();

                            //ProsesOzellikleri2ToplanGecenSure();

                            var operasyonBitSaat = dtgProsesOzellikleri1.Rows[0].Cells["Operasyon Bit.Saati"].Value.ToString();
                            var operasyonBasSaat = dtgProsesOzellikleri1.Rows[0].Cells["Operasyon Baş.Saati"].Value.ToString();

                            if (operasyonBitSaat.ToString() != "" && operasyonBasSaat.ToString() != "")
                            {
                                resp = help.SaatDuzenle(operasyonBasSaat, operasyonBitSaat);

                                TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;
                                dtgProsesOzellikleri2.Rows[0].Cells["Toplam Geçen Süre(DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                            }
                            else
                            {
                                dtgProsesOzellikleri2.Rows[0].Cells["Toplam Geçen Süre(DK)"].Value = "0";
                            }
                        }
                        #endregion
                    }
                    else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Past. Sıcaklığı(C)" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Haz. Salamura Miktar(LT)")
                    {
                        SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1);
                        n.ShowDialog();
                    }
                    else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Salamura Tank Filtre Kont(KKN4)")
                    {
                        //yapıldı yapılmadı

                        string sql = "";

                        sql += " Select '' as \"Kontrol\",'' as \"Kontrol1\" ";
                        sql += " UNION ALL ";
                        sql += " Select 'Yapıldı' as \"Kontrol\",'Yapıldı' as \"Kontrol1\" ";
                        sql += " UNION ALL ";
                        sql += " Select 'Yapılmadı' as \"Kontrol\",'Yapılmadı' as \"Kontrol1\" ";

                        SelectList selectList = new SelectList(sql, dtgProsesOzellikleri1, -1, e.ColumnIndex, _autoresizerow: false);
                        selectList.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
        }
        private void ProsesOzellikleri2PastorizasyonSuresi()
        {
            var pastbitis = dtgProsesOzellikleri1.Rows[0].Cells["Pastörizasyon Bit.Saati"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Pastörizasyon Bit.Saati"].Value);
            var pastBaslangic = dtgProsesOzellikleri1.Rows[0].Cells["Pastörizasyon Baş.Saati"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Pastörizasyon Baş.Saati"].Value);

            var sonuc = pastbitis - pastBaslangic;

            dtgProsesOzellikleri2.Rows[0].Cells["Pastörizasyon Süresi(DK)"].Value = sonuc.ToString();
        }
        private void ProsesOzellikleri2ToplanGecenSure()
        {
            var operasyonBitSaat = dtgProsesOzellikleri1.Rows[0].Cells["Operasyon Bit.Saati"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Operasyon Bit.Saati"].Value);
            var operasyonBasSaat = dtgProsesOzellikleri1.Rows[0].Cells["Operasyon Bit.Saati"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Operasyon Bit.Saati"].Value);

            var sonuc = operasyonBitSaat - operasyonBasSaat;

            dtgProsesOzellikleri2.Rows[0].Cells["Toplam Geçen Süre(DK)"].Value = sonuc.ToString();
        }
        private void dtgProsesOzellikleri2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region otomatik hesaplanıyor, elle girilmek istenirse diye eklendi
                //if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pastörizasyon Süresi(DK)" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Toplam Geçen Süre(DK)")
                //{
                //    SaatTarihGirisi n = new SaatTarihGirisi(dtgProsesOzellikleri2);
                //    n.ShowDialog();
                //} 
                #endregion
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dtgSalamuraOzellikleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {

                if (e.RowIndex != -1)
                {
                    if (dtgSalamuraOzellikleri.Columns[e.ColumnIndex].Name == "Bome Değeri" || dtgSalamuraOzellikleri.Columns[e.ColumnIndex].Name == "PH Değeri")
                    {
                        SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgSalamuraOzellikleri);
                        n.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");

            }
        }

        private void dtgSalamuraMalzeme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //hiçbir ekranda yapılmamıştı bende yapmadım.
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
        private void btnOnayla_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();

                TazePeynirSalamuraSu nesne = new TazePeynirSalamuraSu();

                SalamuraProsesOzellikleri1 salamuraProsesOzellikleri1 = new SalamuraProsesOzellikleri1();
                List<SalamuraProsesOzellikleri1> salamuraProsesOzellikleri1s = new List<SalamuraProsesOzellikleri1>();

                SalamuraProsesOzellikleri2 salamuraProsesOzellikleri2 = new SalamuraProsesOzellikleri2();
                List<SalamuraProsesOzellikleri2> salamuraProsesOzellikleri2s = new List<SalamuraProsesOzellikleri2>();

                SalamuraOzellikleri salamuraOzellikleri = new SalamuraOzellikleri();
                List<SalamuraOzellikleri> salamuraOzellikleris = new List<SalamuraOzellikleri>();

                SalamuraSarfMalzemeKullanim salamuraSarfMalzemeKullanim = new SalamuraSarfMalzemeKullanim();
                List<SalamuraSarfMalzemeKullanim> salamuraSarfMalzemeKullanims = new List<SalamuraSarfMalzemeKullanim>();

                nesne.PartiNo = txtPartiNo.Text;
                nesne.Aciklama = txtAciklama.Text;
                nesne.UretimTarihi = tarih1;
                nesne.UrunKodu = UrunKodu; //bulamadım
                nesne.UrunTanimi = txtUrunTanimi.Text;

                foreach (DataGridViewRow dr in dtgProsesOzellikleri1.Rows)
                {
                    salamuraProsesOzellikleri1 = new SalamuraProsesOzellikleri1();
                    salamuraProsesOzellikleri1.SalamuraHazirlayanSorumlu = dr.Cells["Salamura Hazırlayan Sorumlu"].Value == DBNull.Value ? "" : dr.Cells["Salamura Hazırlayan Sorumlu"].Value.ToString();
                    salamuraProsesOzellikleri1.OperasyonBaslangicSaati = dr.Cells["Operasyon Baş.Saati"].Value == DBNull.Value ? "" : dr.Cells["Operasyon Baş.Saati"].Value.ToString();
                    salamuraProsesOzellikleri1.PastorizasyonSicakligi = dr.Cells["Past. Sıcaklığı(C)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Past. Sıcaklığı(C)"].Value);
                    salamuraProsesOzellikleri1.PastorizasyonBaslangicSaati = dr.Cells["Past. Baş.Saati"].Value == DBNull.Value ? "" : dr.Cells["Past. Baş.Saati"].Value.ToString();
                    salamuraProsesOzellikleri1.PastorizasyonBitisSaati = dr.Cells["Past. Bit.Saati"].Value == DBNull.Value ? "" : dr.Cells["Past. Bit.Saati"].Value.ToString();
                    salamuraProsesOzellikleri1.SalamuraTankFiltreKontrol = dr.Cells["Salamura Tank Filtre Kont(KKN4)"].Value == DBNull.Value ? "" : dr.Cells["Salamura Tank Filtre Kont(KKN4)"].Value.ToString();
                    salamuraProsesOzellikleri1.HazirlananSalamuraMiktari = dr.Cells["Haz. Salamura Miktar(LT)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Haz. Salamura Miktar(LT)"].Value);
                    salamuraProsesOzellikleri1.OperasyonBitisSaati = dr.Cells["Operasyon Bit.Saati"].Value == DBNull.Value ? "" : dr.Cells["Operasyon Bit.Saati"].Value.ToString();

                    salamuraProsesOzellikleri1s.Add(salamuraProsesOzellikleri1);
                }

                nesne.salamuraProsesOzellikleri1s = salamuraProsesOzellikleri1s.ToArray();

                foreach (DataGridViewRow dr in dtgProsesOzellikleri2.Rows)
                {
                    salamuraProsesOzellikleri2 = new SalamuraProsesOzellikleri2();

                    salamuraProsesOzellikleri2.PastorizasyonSuresi = dr.Cells["Pastörizasyon Süresi(DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastörizasyon Süresi(DK)"].Value);
                    salamuraProsesOzellikleri2.ToplamGecenSure = dr.Cells["Toplam Geçen Süre(DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Geçen Süre(DK)"].Value);

                    salamuraProsesOzellikleri2s.Add(salamuraProsesOzellikleri2);
                }

                nesne.salamuraProsesOzellikleri2s = salamuraProsesOzellikleri2s.ToArray();

                foreach (DataGridViewRow dr in dtgSalamuraOzellikleri.Rows)
                {
                    string sql = "SELECT \"U_HamSarfTopKg\" as \"Hammadde ve Sarf Toplam(KG)\", T1.\"U_BomeDegeri\" as \"Bome Değeri\", T1.\"U_PhDegeri\" as \"PH Değeri\" FROM \"@AIF_TAZEPEYSALSUYU\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_TAZEPEYSALSUYU3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";

                    salamuraOzellikleri = new SalamuraOzellikleri();

                    salamuraOzellikleri.KullanilanHammeddeToplam = dr.Cells["Hammadde ve Sarf Toplam(KG)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Hammadde ve Sarf Toplam(KG)"].Value);
                    salamuraOzellikleri.BomeDegeri = dr.Cells["Bome Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Bome Değeri"].Value);
                    salamuraOzellikleri.PhDegeri = dr.Cells["PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH Değeri"].Value);

                    salamuraOzellikleris.Add(salamuraOzellikleri);
                }

                nesne.salamuraOzellikleris = salamuraOzellikleris.ToArray();

                foreach (DataGridViewRow dr in dtgSalamuraMalzeme.Rows)
                {
                    salamuraSarfMalzemeKullanim = new SalamuraSarfMalzemeKullanim();

                    salamuraSarfMalzemeKullanim.MalzemeAdi = dr.Cells["Malzeme Adı"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Adı"].Value.ToString();
                    salamuraSarfMalzemeKullanim.MalzemeMarkaTedarikcisi = dr.Cells["Malzemenin Markası ve Tedarikçisi"].Value == DBNull.Value ? "" : dr.Cells["Malzemenin Markası ve Tedarikçisi"].Value.ToString();
                    salamuraSarfMalzemeKullanim.SarfMalzemePartiNo = dr.Cells["Sarf Malzemesi Parti No"].Value == DBNull.Value ? "" : dr.Cells["Sarf Malzemesi Parti No"].Value.ToString();
                    salamuraSarfMalzemeKullanim.Miktar = dr.Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Miktar"].Value);
                    salamuraSarfMalzemeKullanim.Birim = dr.Cells["Birim"].Value == DBNull.Value ? "" : dr.Cells["Birim"].Value.ToString();

                    salamuraSarfMalzemeKullanims.Add(salamuraSarfMalzemeKullanim);
                }

                nesne.salamuraSarfMalzemeKullanims = salamuraSarfMalzemeKullanims.ToArray();

                var resp = client.AddOrUpdateTazePeynirSalamuraSu(nesne, Giris.dbName, Giris.mKodValue);

                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                if (resp.Value == 0)
                {
                    btnOzetEkranaDon.PerformClick();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
        }
    }
}

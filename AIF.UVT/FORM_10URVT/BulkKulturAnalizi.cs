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
    public partial class BulkKulturAnalizi : Form
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
        public BulkKulturAnalizi(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, int _width, int _height, string _tarih1, string _urunKodu)
        {
            InitializeComponent();
            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = txtUretimTarihi.Font.Size;
            txtUretimTarihi.Resize += Form_Resize;
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
        private void BulkKulturAnalizi_Load(object sender, EventArgs e)
        {
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_BULKKLTR_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
            dtgBulkKulturOzellikleriLoad();
            dtgSarfMalzemeKullanimLoad();

            dtgProsesOzellikleri1.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgProsesOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;

            DataGridViewColumn dataGridViewColumn = dtgBulkKulturOzellikleri.Columns["Hammadde ve Sarf Toplam(KG)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.LimeGreen;

            dataGridViewColumn = dtgBulkKulturOzellikleri.Columns["Kuru Madde(%)"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dataGridViewColumn = dtgBulkKulturOzellikleri.Columns["PH Değeri"];
            dataGridViewColumn.HeaderCell.Style.BackColor = Color.RoyalBlue;

            dtgSarfMalzeme.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;


        }
        private void dtgProsesOzellikleri1Load()
        {
            try
            {
                string sql = "Select T1.\"U_OperatorAdi\" as \"Operatör Adı\",T1.\"U_OprsynBasSaat\" as \"Operasyon Baş.Saati\",T1.\"U_PastSicaklik\" as \"Past. Sıcaklığı(C)\",T1.\"U_PastBasSaat\" as \"Past. Baş.Saati\",T1.\"U_PastBitSaat\" as \"Past. Bit.Saati\",T1.\"U_MayaSicaklik\" as \"Mayalama Sıcaklığı(C)\",T1.\"U_MayalamaSaat\" as \"Mayalama Saati\",T1.\"U_InkSonSaat\" as \"İnkübasyon Son. Saati\",T1.\"U_InkSonPhDeger\" as \"İnkübasyon Son. PH Değeri\",T1.\"U_KulturMiktari\" as \"Kültür Miktarı\",T1.\"U_OprsynBitSaat\" as \"Operasyon Bit.Saati\" from \"@AIF_BULKKLTR_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_BULKKLTR_ANLZ1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                    dr["Mayalama Sıcaklığı(C)"] = Convert.ToString("0", cultureTR);
                    dr["İnkübasyon Son. PH Değeri"] = Convert.ToString("0", cultureTR);
                    dr["Kültür Miktarı"] = Convert.ToString("0", cultureTR);

                    dt.Rows.Add(dr);
                }
                //dt.Rows.Add();

                dtgProsesOzellikleri1.Columns["Past. Sıcaklığı(C)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgProsesOzellikleri1.Columns["Past. Sıcaklığı(C)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgProsesOzellikleri1.Columns["Mayalama Sıcaklığı(C)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgProsesOzellikleri1.Columns["Mayalama Sıcaklığı(C)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgProsesOzellikleri1.Columns["İnkübasyon Son. PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgProsesOzellikleri1.Columns["İnkübasyon Son. PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgProsesOzellikleri1.Columns["Kültür Miktarı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgProsesOzellikleri1.Columns["Kültür Miktarı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dtgProsesOzellikleri1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgMamulOzellikleri1.AutoResizeRows();

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
                    kontroledilmesigerekenKolon = "Operatör Adı"
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
                    aktifKolon = "Mayalama Sıcaklığı(C)",
                    kontroledilmesigerekenKolon = "Past. Bit.Saati"
                });
                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Mayalama Saati",
                    kontroledilmesigerekenKolon = "Mayalama Sıcaklığı(C)"
                });
                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "İnkübasyon Son. Saati",
                    kontroledilmesigerekenKolon = "Mayalama Saati"
                });
                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "İnkübasyon Son. PH Değeri",
                    kontroledilmesigerekenKolon = "İnkübasyon Son. Saati"
                });
                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Kültür Miktarı",
                    kontroledilmesigerekenKolon = "İnkübasyon Son. PH Değeri"
                });
                kontrolListesis.Add(new kontrolListesi
                {
                    aktifKolon = "Operasyon Bit.Saati",
                    kontroledilmesigerekenKolon = "Kültür Miktarı"
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
                string sql = "Select T1.\"U_PastSuresi\" as \"Pastörizasyon Süresi(DK)\",T1.\"U_InkSuresi\" as \"İnkübasyon Süresi(DK)\",T1.\"U_ToplamGecenSure\" as \"Toplam Geçen Süre(DK)\" from \"@AIF_BULKKLTR_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_BULKKLTR_ANLZ2\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
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
                    dr["İnkübasyon Süresi(DK)"] = Convert.ToString("0", cultureTR);
                    dr["Toplam Geçen Süre(DK)"] = Convert.ToString("0", cultureTR);

                    dt.Rows.Add(dr);
                }
                //dt.Rows.Add(); 

                dtgProsesOzellikleri2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtgProsesOzellikleri2.AutoResizeRows();
                dtgProsesOzellikleri2.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
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
        private void dtgBulkKulturOzellikleriLoad()
        {
            try
            {
                string sql = "SELECT \"U_HamSarfTopKg\" as \"Hammadde ve Sarf Toplam(KG)\", T1.\"U_KuruMadde\" as \"Kuru Madde(%)\", T1.\"U_PhDegeri\" as \"PH Değeri\" FROM \"@AIF_BULKKLTR_ANLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_BULKKLTR_ANLZ3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                //Commit
                dtgBulkKulturOzellikleri.DataSource = dt;

                if (dt.Rows.Count == 0)
                {
                    //sql = "SELECT SUM(T0.Quantity) AS \"Miktar\" FROM IBT1_LINK T0 WITH(NOLOCK) INNER JOIN OITM T1 WITH(NOLOCK) ON T0.ItemCode = T1.ItemCode INNER JOIN  WOR1 T2 WITH(NOLOCK) ON T0.ItemCode = T2.ItemCode WHERE BaseType = 60   AND BaseEntry in (SELECT T2.DocEntry FROM OIGE T2 WITH(NOLOCK) WHERE T2.U_BatchNumber = '" + partiNo + "') AND T1.\"ItmsGrpCod\" NOT IN('105','106','107') and T2.U_SarfaDahilEt = 'E' ";

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
                        dr["Kuru Madde(%)"] = Convert.ToString("0", cultureTR);
                        dr["PH Değeri"] = Convert.ToString("0", cultureTR);

                        dt.Rows.Add(dr);
                    }
                }

                dtgBulkKulturOzellikleri.Columns["Hammadde ve Sarf Toplam(KG)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgBulkKulturOzellikleri.Columns["Hammadde ve Sarf Toplam(KG)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgBulkKulturOzellikleri.Columns["Kuru Madde(%)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgBulkKulturOzellikleri.Columns["Kuru Madde(%)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                dtgBulkKulturOzellikleri.Columns["PH Değeri"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dtgBulkKulturOzellikleri.Columns["PH Değeri"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

                dtgBulkKulturOzellikleri.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                dtgBulkKulturOzellikleri.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
                dtgBulkKulturOzellikleri.EnableHeadersVisualStyles = false;
                dtgBulkKulturOzellikleri.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

                foreach (DataGridViewColumn column in dtgBulkKulturOzellikleri.Columns)
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
                dtgBulkKulturOzellikleri.Rows[0].Cells[0].ReadOnly = true;
                //}
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
        }
        private void dtgSarfMalzemeKullanimLoad()
        {
            try
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

                if (dt.Rows.Count == 0)
                {
                    #region old
                    //sql = "select T0.ItemName as \"Malzeme Adı\",CardName as \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1 T0 WITH (NOLOCK) inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo + "') and T1.\"ItmsGrpCod\" NOT IN('105','106','107') ";
                    #endregion
                    sql = "select T0.ItemName as \"Malzeme Adı\",ISNULL((SELECT TOP 1 TT.CardName FROM IBT1_LINK AS TT INNER JOIN OCRD T09 ON TT.CardCode = T09.CardCode WHERE TT.ItemCode = T0.ItemCode AND TT.BatchNum = T0.BatchNum ORDER BY TT.DocDate DESC ),'') AS \"Malzemenin Markası ve Tedarikçisi\",BatchNum as \"Sarf Malzemesi Parti No\",Quantity as \"Miktar\",T1.InvntryUom as \"Birim\" from IBT1_LINK T0 WITH (NOLOCK) inner join OITM T1 WITH (NOLOCK) ON T0.ItemCode = T1.ItemCode where BaseType = 60 and BaseEntry in (select DocEntry from OIGE WITH (NOLOCK) where U_BatchNumber = '" + partiNo + "') and T1.\"ItmsGrpCod\" NOT IN('105','106','107') Order By T1.ItemName ";
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

                dtgSarfMalzeme.ColumnHeadersDefaultCellStyle.BackColor = Color.LimeGreen;
                dtgSarfMalzeme.EnableHeadersVisualStyles = false;
                dtgSarfMalzeme.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

                foreach (DataGridViewColumn column in dtgSarfMalzeme.Columns)
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
                    if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Operatör Adı")
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
                    else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Operasyon Baş.Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Past. Baş.Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Past. Bit.Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "İnkübasyon Son. Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Mayalama Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Operasyon Bit.Saati")
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

                        if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "İnkübasyon Son. Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Mayalama Saati")
                        {
                            //ProsesOzellikleri2InkubasyonSuresi();
                            var inkSonlandirmaSaati = dtgProsesOzellikleri1.Rows[0].Cells["İnkübasyon Son. Saati"].Value.ToString();
                            var mayalamaSaati = dtgProsesOzellikleri1.Rows[0].Cells["Mayalama Saati"].Value.ToString();

                            if (inkSonlandirmaSaati.ToString() != "" && mayalamaSaati.ToString() != "")
                            {
                                resp = help.SaatDuzenle(mayalamaSaati, inkSonlandirmaSaati);

                                TimeSpan girisCikisFarki = resp.Item2 - resp.Item1;
                                dtgProsesOzellikleri2.Rows[0].Cells["İnkübasyon Süresi(DK)"].Value = girisCikisFarki.TotalMinutes.ToString();
                            }
                            else
                            {
                                dtgProsesOzellikleri2.Rows[0].Cells["İnkübasyon Süresi(DK)"].Value = "0";
                            }
                        }

                        if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Operasyon Bit.Saati" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Operasyon Baş.Saati")
                        {
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
                    else if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Past. Sıcaklığı(C)" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Mayalama Sıcaklığı(C)" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "İnkübasyon Son. PH Değeri" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Kültür Miktarı")
                    {
                        SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgProsesOzellikleri1);
                        n.ShowDialog();
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
            //var pastbitis = dtgProsesOzellikleri1.Rows[0].Cells["Pastörizasyon Bit.Saati"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Pastörizasyon Bit.Saati"].Value);
            //var pastBaslangic = dtgProsesOzellikleri1.Rows[0].Cells["Pastörizasyon Baş.Saati"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Pastörizasyon Baş.Saati"].Value);

            //var sonuc = pastbitis - pastBaslangic;

            //dtgProsesOzellikleri2.Rows[0].Cells["Pastörizasyon Süresi(DK)"].Value = sonuc.ToString();
        }
        private void ProsesOzellikleri2InkubasyonSuresi()
        {
            //var inkSonlandirmaSaati = dtgProsesOzellikleri1.Rows[0].Cells["İnkübasyon Sonlandırma Saati"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["İnkübasyon Sonlandırma Saati"].Value);
            //var mayalamaSaati = dtgProsesOzellikleri1.Rows[0].Cells["Mayalama Saati"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Mayalama Saati"].Value);

            //var sonuc = inkSonlandirmaSaati - mayalamaSaati;

            //dtgProsesOzellikleri2.Rows[0].Cells["İnkübasyon Süresi(DK)"].Value = sonuc.ToString();
        }
        private void ProsesOzellikleri2ToplanGecenSure()
        {
            //var operasyonBitSaat = dtgProsesOzellikleri1.Rows[0].Cells["Operasyon Bit.Saati"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Operasyon Bit.Saati"].Value);
            //var operasyonBasSaat = dtgProsesOzellikleri1.Rows[0].Cells["Operasyon Bit.Saati"].Value.ToString() == "" ? 0 : Convert.ToDouble(dtgProsesOzellikleri1.Rows[0].Cells["Operasyon Bit.Saati"].Value);

            //var sonuc = operasyonBitSaat - operasyonBasSaat;

            //dtgProsesOzellikleri2.Rows[0].Cells["Toplam Geçen Süre(DK)"].Value = sonuc.ToString();
        }
        private void dtgProsesOzellikleri2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                #region hesaplama yapıldığı içn kullanılmıyor
                //if (dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Pastörizasyon Süresi(DK)" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "İnkübasyon Süresi(DK)" || dtgProsesOzellikleri1.Columns[e.ColumnIndex].Name == "Toplam Geçen Süre(DK)")
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

        private void dtgBulkKulturOzellikleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex != -1)
                {
                    if (dtgBulkKulturOzellikleri.Columns[e.ColumnIndex].Name == "Kuru Madde(%)" || dtgBulkKulturOzellikleri.Columns[e.ColumnIndex].Name == "PH Değeri")
                    {
                        SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgBulkKulturOzellikleri);
                        n.ShowDialog();

                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu" + ex.Message, "UYARI", "TAMAM");

            }
        }

        private void dtgSarfMalzeme_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //hiçbir ekranda yapılmamıştı bende yapmadım.
        }

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();

            if (YogurtProsesTakip_1_1.geriDonme == "OzeteDon")
            {
                btnOzetEkranaDon.PerformClick();
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

                BulkKulturAnaliz nesne = new BulkKulturAnaliz();

                BulkProsesOzellikleri1 bulkProsesOzellikleri1 = new BulkProsesOzellikleri1();
                List<BulkProsesOzellikleri1> bulkProsesOzellikleri1s = new List<BulkProsesOzellikleri1>();

                BulkProsesOzellikleri2 bulkProsesOzellikleri2 = new BulkProsesOzellikleri2();
                List<BulkProsesOzellikleri2> bulkProsesOzellikleri2s = new List<BulkProsesOzellikleri2>();

                BulkKulturOzellikleri bulkKulturOzellikleri = new BulkKulturOzellikleri();
                List<BulkKulturOzellikleri> bulkKulturOzellikleris = new List<BulkKulturOzellikleri>();

                BulkSarfMalzemeKullanim bulkSarfMalzemeKullanim = new BulkSarfMalzemeKullanim();
                List<BulkSarfMalzemeKullanim> bulkSarfMalzemeKullanims = new List<BulkSarfMalzemeKullanim>();

                nesne.PartiNo = txtPartiNo.Text;
                nesne.Aciklama = txtAciklama.Text;
                nesne.UretimTarihi = tarih1;
                nesne.UrunKodu = UrunKodu;
                nesne.UrunTanimi = txtUrunTanimi.Text;

                foreach (DataGridViewRow dr in dtgProsesOzellikleri1.Rows)
                {
                    bulkProsesOzellikleri1 = new BulkProsesOzellikleri1();
                    bulkProsesOzellikleri1.OperatorAdi = dr.Cells["Operatör Adı"].Value == DBNull.Value ? "" : dr.Cells["Operatör Adı"].Value.ToString();
                    bulkProsesOzellikleri1.OperasyonBaslangicSaati = dr.Cells["Operasyon Baş.Saati"].Value == DBNull.Value ? "" : dr.Cells["Operasyon Baş.Saati"].Value.ToString();
                    bulkProsesOzellikleri1.PastorizasyonSicakligi = dr.Cells["Past. Sıcaklığı(C)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Past. Sıcaklığı(C)"].Value);
                    bulkProsesOzellikleri1.PastorizasyonBaslangicSaati = dr.Cells["Past. Baş.Saati"].Value == DBNull.Value ? "" : dr.Cells["Past. Baş.Saati"].Value.ToString();
                    bulkProsesOzellikleri1.PastorizasyonBitisSaati = dr.Cells["Past. Bit.Saati"].Value == DBNull.Value ? "" : dr.Cells["Past. Bit.Saati"].Value.ToString();
                    bulkProsesOzellikleri1.MayalamaSicakligi = dr.Cells["Mayalama Sıcaklığı(C)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Mayalama Sıcaklığı(C)"].Value);
                    bulkProsesOzellikleri1.MayalamaSaati = dr.Cells["Mayalama Saati"].Value == DBNull.Value ? "" : dr.Cells["Mayalama Saati"].Value.ToString();
                    bulkProsesOzellikleri1.InkubasyonSonlandirmaSaati = dr.Cells["İnkübasyon Son. Saati"].Value == DBNull.Value ? "" : dr.Cells["İnkübasyon Son. Saati"].Value.ToString();
                    bulkProsesOzellikleri1.InkubasyonSonlandirmaPh = dr.Cells["İnkübasyon Son. PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["İnkübasyon Son. PH Değeri"].Value);
                    bulkProsesOzellikleri1.HazirlananKulturMiktari = dr.Cells["Kültür Miktarı"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kültür Miktarı"].Value);
                    bulkProsesOzellikleri1.OperasyonBitisSaati = dr.Cells["Operasyon Bit.Saati"].Value == DBNull.Value ? "" : dr.Cells["Operasyon Bit.Saati"].Value.ToString();

                    bulkProsesOzellikleri1s.Add(bulkProsesOzellikleri1);
                }

                nesne.bulkProsesOzellikleri1s = bulkProsesOzellikleri1s.ToArray();

                foreach (DataGridViewRow dr in dtgProsesOzellikleri2.Rows)
                {
                    bulkProsesOzellikleri2 = new BulkProsesOzellikleri2();

                    bulkProsesOzellikleri2.PastorizasyonSuresi = dr.Cells["Pastörizasyon Süresi(DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Pastörizasyon Süresi(DK)"].Value);
                    bulkProsesOzellikleri2.InkubasyonSuresi = dr.Cells["İnkübasyon Süresi(DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["İnkübasyon Süresi(DK)"].Value);
                    bulkProsesOzellikleri2.ToplamGecenSure = dr.Cells["Toplam Geçen Süre(DK)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Toplam Geçen Süre(DK)"].Value);

                    bulkProsesOzellikleri2s.Add(bulkProsesOzellikleri2);
                }

                nesne.bulkProsesOzellikleri2s = bulkProsesOzellikleri2s.ToArray();

                foreach (DataGridViewRow dr in dtgBulkKulturOzellikleri.Rows)
                {
                    bulkKulturOzellikleri = new BulkKulturOzellikleri();

                    bulkKulturOzellikleri.KullanilanHammeddeToplam = dr.Cells["Hammadde ve Sarf Toplam(KG)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Hammadde ve Sarf Toplam(KG)"].Value);
                    bulkKulturOzellikleri.KuruMadde = dr.Cells["Kuru Madde(%)"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Kuru Madde(%)"].Value);
                    bulkKulturOzellikleri.PhDegeri = dr.Cells["PH Değeri"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["PH Değeri"].Value);

                    bulkKulturOzellikleris.Add(bulkKulturOzellikleri);
                }

                nesne.bulkKulturOzellikleris = bulkKulturOzellikleris.ToArray();

                foreach (DataGridViewRow dr in dtgSarfMalzeme.Rows)
                {
                    bulkSarfMalzemeKullanim = new BulkSarfMalzemeKullanim();

                    bulkSarfMalzemeKullanim.MalzemeAdi = dr.Cells["Malzeme Adı"].Value == DBNull.Value ? "" : dr.Cells["Malzeme Adı"].Value.ToString();
                    bulkSarfMalzemeKullanim.MalzemeMarkaTedarikcisi = dr.Cells["Malzemenin Markası ve Tedarikçisi"].Value == DBNull.Value ? "" : dr.Cells["Malzemenin Markası ve Tedarikçisi"].Value.ToString();
                    bulkSarfMalzemeKullanim.SarfMalzemePartiNo = dr.Cells["Sarf Malzemesi Parti No"].Value == DBNull.Value ? "" : dr.Cells["Sarf Malzemesi Parti No"].Value.ToString();
                    bulkSarfMalzemeKullanim.Miktar = dr.Cells["Miktar"].Value == DBNull.Value ? 0 : Convert.ToDouble(dr.Cells["Miktar"].Value);
                    bulkSarfMalzemeKullanim.Birim = dr.Cells["Birim"].Value == DBNull.Value ? "" : dr.Cells["Birim"].Value.ToString();

                    bulkSarfMalzemeKullanims.Add(bulkSarfMalzemeKullanim);
                }

                nesne.bulkSarfMalzemeKullanims = bulkSarfMalzemeKullanims.ToArray();

                var resp = client.AddOrUpdateBulkKulturAnaliz(nesne, Giris.dbName, Giris.mKodValue);

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

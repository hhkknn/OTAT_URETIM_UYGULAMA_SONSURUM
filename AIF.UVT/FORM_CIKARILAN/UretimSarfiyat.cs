using AIF.UVT.DatabaseLayer;
using AIF.UVT.Models;
using AIF.UVT.UVTService;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class UretimSarfiyat : Form
    {
        //font start.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end

        public UretimSarfiyat(string _stageid, string _uretimFisNo, string _type, string _kullaniciid, double _partiKatSayi, string _partiNo, string _rotaKodu, string _urunGrubu, string _urunTanimi, int _row, int _width, int _height)
        {
            stageid = _stageid;
            UretimFisNo = _uretimFisNo;
            type = _type;
            kullaniciid = _kullaniciid;
            partikatsayi = _partiKatSayi;
            partiNo = _partiNo;
            rotaKodu = _rotaKodu;
            urunGrubu = _urunGrubu;
            urunTanimi = _urunTanimi;
            row = _row;

            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = _width;
            initialHeight = _height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

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

            label8.Font = new Font(label8.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label8.Font.Style);

            textBox1.Font = new Font(textBox1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox1.Font.Style);

            textBox3.Font = new Font(textBox3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox3.Font.Style);

            textBox4.Font = new Font(textBox4.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox4.Font.Style);

            textBox5.Font = new Font(textBox5.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox5.Font.Style);

            textBox6.Font = new Font(textBox6.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox6.Font.Style);

            textBox7.Font = new Font(textBox7.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox7.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button1.Font.Style);

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button2.Font.Style);
            ResumeLayout();
            //font end
        }

        private string stageid = "";
        private string UretimFisNo = "";
        private string type = "";
        private string kullaniciid = "";
        private double partikatsayi = 0;
        private string partiNo = "";
        private string rotaKodu = "";
        private string urunGrubu = "";
        private string urunTanimi = "";
        private int row = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            BanaAitİsler n = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight);
            n.Show();
            type = "";
            Close();
        }

        private DataTable SarfEdilecekMalzemeleriGetir()
        {
            double partikatsayisi = Convert.ToDouble(partikatsayi.ToString("N" + Giris.OndalikMiktar));
            string sql = "Select ItemCode as [Ürün Kodu],(Select ItemName from OITM as T1 where T1.ItemCode = T0.ItemCode) as [Ürün Tanımı],ROUND((T0.PlannedQty / " + partikatsayisi.ToString().Replace(",", ".") + "),2) as [Planlanan Miktar],ROUND((T0.PlannedQty / " + partikatsayisi.ToString().Replace(",", ".") + "),2) as [Gerçekleşen Miktar],'0,00' as Fark,T0.LineNum as SiraNo from WOR1 as T0 where T0.StageId='" + stageid + "' and ItemType = '4' and T0.DocEntry = '" + UretimFisNo + "'";

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
            {
                Connection.sql.Open();
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Connection.sql.Close();

            return dt;
        }

        private DataTable SarfEdilmisMalzemeleriGetir()
        {
            string sql = "Select ItemCode as [Ürün Kodu],T1.\"Dscription\" as [Ürün Tanımı],SUM(T1.Quantity) as Miktar,T0.\"DocEntry\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_RotaCode\" = '" + rotaKodu + "' and \"U_BatchNumber\" = '" + partiNo + "' group by \"U_BatchNumber\",\"U_RotaCode\",\"ItemCode\",T1.\"Dscription\",T0.\"DocEntry\"";

            sql += " UNION ALL ";

            sql += "Select ItemCode as [Ürün Kodu],T1.\"Dscription\" as [Ürün Tanımı],SUM(T1.Quantity) * -1 as Miktar,T0.\"DocEntry\" from OIGN as T0 INNER JOIN IGN1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_RotaCode\" = '" + rotaKodu + "' and \"U_BatchNumber\" = '" + partiNo + "' group by \"U_BatchNumber\",\"U_RotaCode\",\"ItemCode\",T1.\"Dscription\",T0.\"DocEntry\"";

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
            {
                Connection.sql.Open();
            }
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            Connection.sql.Close();

            return dt;
        }

        public static List<OlustulacakPartiler> olustulacakPartilers = new List<OlustulacakPartiler>();

        private DataGridViewCheckBoxColumn checkColumn = null;

        private void Checkboxolustur()
        {
            checkColumn = new DataGridViewCheckBoxColumn();

            checkColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkColumn.CellTemplate = new DataGridViewCheckBoxCell();
            checkColumn.FalseValue = true;
            checkColumn.HeaderText = "Seçim";
            checkColumn.Name = "ScmCheck";
            checkColumn.TrueValue = true;
            checkColumn.FalseValue = false;
            dataGridView2.Columns.Add(checkColumn);

            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Columns["ScmCheck"].DisplayIndex = 0;
            //dataGridView2.Columns["Personel No"].DisplayIndex = 1;
            //dataGridView2.Columns["Personel Adı"].DisplayIndex = 2;
            //dataGridView2.Columns["Saat"].DisplayIndex = 3;
            //dataGridView2.Columns["Dakika"].DisplayIndex = 4;
            //dataGridView2.Columns["AktiviteNo"].DisplayIndex = 5;
        }

        private void Checkboxolusturdatagridview1()
        {
            checkColumn = new DataGridViewCheckBoxColumn();

            checkColumn.AutoSizeMode =
                DataGridViewAutoSizeColumnMode.DisplayedCells;
            checkColumn.CellTemplate = new DataGridViewCheckBoxCell();
            checkColumn.FalseValue = true;
            checkColumn.HeaderText = "Seçim";
            checkColumn.Name = "ScmCheck";
            checkColumn.TrueValue = true;
            checkColumn.FalseValue = false;
            dataGridView1.Columns.Add(checkColumn);

            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Columns["ScmCheck"].DisplayIndex = 0;
            //dataGridView2.Columns["Personel No"].DisplayIndex = 1;
            //dataGridView2.Columns["Personel Adı"].DisplayIndex = 2;
            //dataGridView2.Columns["Saat"].DisplayIndex = 3;
            //dataGridView2.Columns["Dakika"].DisplayIndex = 4;
            //dataGridView2.Columns["AktiviteNo"].DisplayIndex = 5;
        }

        private DataTable dtSarfEdiecekMalzemeler = null;
        private DataTable dtBekleyenler = null;
        private DataTable dtSarfEdilmisMalzemeler = null;
        private SqlCommand cmd = null;

        private void UretimSarfiyat_Load(object sender, EventArgs e)
        {
            try
            {
                olustulacakPartilers = new List<OlustulacakPartiler>();
                dtSarfEdiecekMalzemeler = SarfEdilecekMalzemeleriGetir();
                dataGridView2.DataSource = dtSarfEdiecekMalzemeler;

                dtSarfEdilmisMalzemeler = dtSarfEdiecekMalzemeler.Copy();
                dtSarfEdilmisMalzemeler.Rows.Clear();
                dtBekleyenler = dtSarfEdiecekMalzemeler.Copy();
                dtBekleyenler.Rows.Clear();

                dtSarfEdilmisMalzemeler.Columns.Add("DocEntry", typeof(int));

                dtBekleyenler = SarfEdilmisMalzemeleriGetir();

                foreach (DataRow dr in dtBekleyenler.Rows)
                {
                    DataRow drSarfEdilmis = dtSarfEdilmisMalzemeler.NewRow();
                    drSarfEdilmis["Ürün Kodu"] = dr["Ürün Kodu"];
                    drSarfEdilmis["Ürün Tanımı"] = dr["Ürün Tanımı"];
                    drSarfEdilmis["Gerçekleşen Miktar"] = dr["Miktar"];
                    drSarfEdilmis["DocEntry"] = dr["DocEntry"];

                    dtSarfEdilmisMalzemeler.Rows.Add(drSarfEdilmis);
                }

                //dtBekleyenler.AsEnumerable().Where(x=>x.Field<int>("row"))

                dataGridView1.DataSource = dtSarfEdilmisMalzemeler;

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    string ItemCode = dataGridView2.Rows[i].Cells["Ürün Kodu"].Value.ToString();
                    double gerceklesen = Convert.ToDouble(dataGridView2.Rows[i].Cells["Gerçekleşen Miktar"].Value);
                    var cekilengerceklesmislist = dtSarfEdilmisMalzemeler.AsEnumerable().Where(x => x.Field<string>("Ürün Kodu") == ItemCode);

                    if (cekilengerceklesmislist.Count() > 0)
                    {
                        double d2 = cekilengerceklesmislist.Select(x => x.ItemArray[3]).Count() > 0 ? Convert.ToDouble(cekilengerceklesmislist.Select(x => x.ItemArray[3]).FirstOrDefault()) : 0;
                        var d1 = d2 - gerceklesen;
                        dataGridView2.Rows[i].Cells["Gerçekleşen Miktar"].Value = d2;

                        d1 = Convert.ToDouble(dataGridView2.Rows[i].Cells["Gerçekleşen Miktar"].Value);
                        d2 = Convert.ToDouble(dataGridView2.Rows[i].Cells["Planlanan Miktar"].Value);

                        var sonuc = d2 - d1;
                        dataGridView2.Rows[i].Cells["Fark"].Value = sonuc;
                    }
                }

                double gerceklesen1 = 0;
                for (int x = 0; x < dataGridView2.Rows.Count; x++)
                {
                    gerceklesen1 = 0;
                    string ItemCode1 = dataGridView2.Rows[x].Cells["Ürün Kodu"].Value.ToString();

                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        string ItemCode = dataGridView1.Rows[i].Cells["Ürün Kodu"].Value.ToString();
                        double gerceklesen = Convert.ToDouble(dataGridView1.Rows[i].Cells["Gerçekleşen Miktar"].Value);
                        if (ItemCode == ItemCode1)
                        {
                            gerceklesen1 += Convert.ToDouble(dataGridView1.Rows[i].Cells["Gerçekleşen Miktar"].Value);
                        }
                    }

                    if (gerceklesen1 != 0)
                    {
                        dataGridView2.Rows[x].Cells["Gerçekleşen Miktar"].Value = gerceklesen1;
                    }
                }
                setFormatGrid(dataGridView2);

                setFormatGrid(dataGridView1);

                dataGridView2.Columns["Planlanan Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dataGridView2.Columns["Planlanan Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns["Gerçekleşen Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dataGridView2.Columns["Gerçekleşen Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.Columns["Fark"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dataGridView2.Columns["Fark"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView2.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

                dataGridView1.Columns["Planlanan Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dataGridView1.Columns["Planlanan Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Gerçekleşen Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dataGridView1.Columns["Gerçekleşen Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Fark"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dataGridView1.Columns["Fark"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                Library.Helper n = new Library.Helper();
                n.SetAllControlsFont(Controls);

                dataGridView1.Columns["Planlanan Miktar"].Visible = false;
                dataGridView1.Columns["Fark"].Visible = false;
                dataGridView1.Columns["DocEntry"].Visible = false;

                Checkboxolustur();

                dataGridView2.AutoResizeColumns();

                for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
                {
                    string colName = dataGridView2.Columns[i].Name;

                    if (colName != "Gerçekleşen Miktar")
                    {
                        dataGridView2.Columns[i].ReadOnly = true;
                    }
                }

                dataGridView1.AutoResizeColumns();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string colName = dataGridView1.Columns[i].Name;

                    if (colName != "Gerçekleşen Miktar")
                    {
                        dataGridView1.Columns[i].ReadOnly = true;
                    }
                }

                dataGridView1.Columns["SiraNo"].Visible = false;
                dataGridView2.Columns["SiraNo"].Visible = false;

                Checkboxolusturdatagridview1();

                for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                for (int i = 0; i <= dataGridView2.Columns.Count - 1; i++)
                {
                    dataGridView2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }

                textBox1.Text = urunGrubu;
                textBox5.Text = UretimFisNo;
                textBox6.Text = partiNo;
                textBox4.Text = urunTanimi;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Üretim sarfiyat ekranı açılırken hata oluştu. Hata Kodu: URTSRF001 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void setFormatGrid(DataGridView dtg)
        {
            dtg.RowHeadersVisible = false;

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dtg.Font = new System.Drawing.Font("Bahnschrift", 11.20F, FontStyle.Bold);

            int width = dtg.Width / dtg.Columns.Count;
            foreach (DataGridViewColumn col in dtg.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
                col.Width = width - 8;
            }

            for (int i = 0; i <= dtg.Rows.Count - 1; i++)
            {
                dtg.Rows[i].Height = 40;

                if (i % 2 == 0)
                    dtg.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                else
                    dtg.Rows[i].DefaultCellStyle.BackColor = Color.DimGray;

                dtg.Rows[i].DefaultCellStyle.ForeColor = Color.White;
            }
        }

        private void dataGridView2_Sorted(object sender, EventArgs e)
        {
            setFormatGrid(dataGridView2);
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

        private void dataGridView2_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var grid = (sender as DataGridView);
                if (e.RowIndex != -1 && e.ColumnIndex == 3)
                {
                    double PlanlananMiktar = (grid.Rows[e.RowIndex]).Cells["Planlanan Miktar"].Value == "" ? 0 : Convert.ToDouble((grid.Rows[e.RowIndex]).Cells["Planlanan Miktar"].Value);
                    double GerceklesenMiktar = (grid.Rows[e.RowIndex]).Cells["Gerçekleşen Miktar"].Value == "" ? 0 : Convert.ToDouble((grid.Rows[e.RowIndex]).Cells["Gerçekleşen Miktar"].Value);
                    double sonuc = Math.Round(PlanlananMiktar - GerceklesenMiktar, Giris.OndalikMiktar);

                    (grid.Rows[e.RowIndex]).Cells["Fark"].Value = sonuc.ToString("N" + Giris.OndalikMiktar);
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: URTSRF002 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                //List<Tuple<string, double, double, int>> PartiBekleyenler = new List<Tuple<string, double, double, int>>();
                for (int rows = 0; rows < dataGridView2.Rows.Count; rows++)
                {
                    string check = dataGridView2.Rows[rows].Cells["ScmCheck"].Value != null ? dataGridView2.Rows[rows].Cells["ScmCheck"].Value.ToString() : "False";
                    if (check == "True")
                    {
                        string UrunKodu = dataGridView2.Rows[rows].Cells["Ürün Kodu"].Value.ToString();
                        string UrunAdi = dataGridView2.Rows[rows].Cells["Ürün Tanımı"].Value.ToString();
                        double PlanlananMiktar = Convert.ToDouble(dataGridView2.Rows[rows].Cells["Planlanan Miktar"].Value);
                        double GerceklesenMiktar = Convert.ToDouble(dataGridView2.Rows[rows].Cells["Gerçekleşen Miktar"].Value);
                        double Fark = Convert.ToDouble(dataGridView2.Rows[rows].Cells["Fark"].Value);
                        int SatirNo = Convert.ToInt32(dataGridView2.Rows[rows].Cells["SiraNo"].Value);

                        if (GerceklesenMiktar > 0)
                        {
                            Models.PartiSecimi parti = new Models.PartiSecimi();
                            parti.UrunKodu = UrunKodu;
                            parti.TuketilecekMiktar = GerceklesenMiktar;
                            parti.UretimSiparisNo = UretimFisNo;
                            parti.SatirNo = SatirNo;

                            PartiSecimi f = new PartiSecimi(parti, initialWidth, initialHeight);
                            f.ShowDialog();

                            if (PartiSecimi.dialogResult == "Ok")
                            {
                                DataRow drBekleyenler = dtSarfEdilmisMalzemeler.NewRow();
                                drBekleyenler["Ürün Kodu"] = UrunKodu;
                                drBekleyenler["Ürün Tanımı"] = UrunAdi;
                                drBekleyenler["Planlanan Miktar"] = PlanlananMiktar;
                                drBekleyenler["Gerçekleşen Miktar"] = GerceklesenMiktar;
                                drBekleyenler["Fark"] = Fark;
                                drBekleyenler["SiraNo"] = SatirNo;

                                dtSarfEdilmisMalzemeler.Rows.Add(drBekleyenler);

                                DataRow[] drr = dtSarfEdiecekMalzemeler.Select("[Ürün Kodu]='" + UrunKodu + "' and SiraNo='" + SatirNo + "'");
                                drr[0].Delete();

                                setFormatGrid(dataGridView1);
                                dataGridView1.AutoResizeColumns();

                                dtSarfEdiecekMalzemeler.AcceptChanges();
                                dataGridView1.DataSource = dtSarfEdilmisMalzemeler;

                                dataGridView2.DataSource = dtSarfEdiecekMalzemeler;

                                setFormatGrid(dataGridView2);
                                dataGridView2.AutoResizeColumns();
                                PartiSecimi.dialogResult = "";
                            }
                            else
                            {
                                olustulacakPartilers.RemoveAll(x => x.UretimSiparisNo == UretimFisNo && x.SatirNo == SatirNo);
                            }
                        }
                        else
                        {
                            //string parti = DateTime.Now.ToString("ddMMyyyy") + "-" + UretimFisNo + "-" + SatirNo;
                            //olustulacakPartilers.Add(new OlustulacakPartiler { Parti = parti, PartiMiktari = GerceklesenMiktar, SatirNo = SatirNo, UretimSiparisNo = UretimFisNo });
                            DataRow drBekleyenler = dtSarfEdilmisMalzemeler.NewRow();
                            drBekleyenler["Ürün Kodu"] = UrunKodu;
                            drBekleyenler["Ürün Tanımı"] = UrunAdi;
                            drBekleyenler["Planlanan Miktar"] = PlanlananMiktar;
                            drBekleyenler["Gerçekleşen Miktar"] = GerceklesenMiktar;
                            drBekleyenler["Fark"] = Fark;
                            drBekleyenler["SiraNo"] = SatirNo;

                            dtSarfEdilmisMalzemeler.Rows.Add(drBekleyenler);

                            DataRow[] drr = dtSarfEdiecekMalzemeler.Select("[Ürün Kodu]='" + UrunKodu + "' and SiraNo='" + SatirNo + "'");
                            drr[0].Delete();

                            setFormatGrid(dataGridView1);
                            dataGridView1.AutoResizeColumns();

                            dtSarfEdiecekMalzemeler.AcceptChanges();
                            dataGridView1.DataSource = dtSarfEdilmisMalzemeler;

                            dataGridView2.DataSource = dtSarfEdiecekMalzemeler;

                            setFormatGrid(dataGridView2);
                            dataGridView2.AutoResizeColumns();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: URTSRF003 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                bool belgeOlusacakMi = false;
                bool isOk = false;
                List<InventoryGenExist> inventoryGenExist = new List<InventoryGenExist>();
                List<Parti> parti = new List<Parti>();
                foreach (DataRow dr in dtSarfEdilmisMalzemeler.AsEnumerable().Where(x => x.Field<decimal>("Gerçekleşen Miktar") > 0))
                {
                    if (dr["DocEntry"] != DBNull.Value) //Daah önce yaratılmış olan çıkışların satır numarası gelmediğinden bu kontrol yazıldı.
                    {
                        continue;
                    }
                    int uretimSiparisNo = Convert.ToInt32(UretimFisNo);
                    string KalemKodu = dr["Ürün Kodu"].ToString();
                    int SatirNo = Convert.ToInt32(dr["SiraNo"]);
                    var partino = olustulacakPartilers.Where(x => x.UretimSiparisNo == UretimFisNo && x.SatirNo == SatirNo).ToList();
                    double miktar = Convert.ToDouble(dr["Gerçekleşen Miktar"]);

                    if (miktar < 0)
                    {
                        continue;
                    }

                    foreach (var item in partino)
                    {
                        parti.Add(new Parti { PartiNo = item.Parti, PartikMiktar = item.PartiMiktari });
                    }

                    inventoryGenExist.Add(new InventoryGenExist
                    {
                        UretimSiparisi = uretimSiparisNo,
                        SatirNumarasi = SatirNo,
                        Miktar = miktar,
                        Parti = parti.ToArray(),
                        PartiNo = partiNo,
                        RotaKodu = rotaKodu
                    });

                    parti = new List<Parti>();
                }

                if (inventoryGenExist.Count > 0)
                {
                    belgeOlusacakMi = true;
                    var resp = client.AddInventoryGenExist(inventoryGenExist.ToArray(), Giris.dbName, Giris.mKodValue);
                    if (resp.Value == 0)
                    {
                        isOk = true;
                    }
                    CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");
                }
                List<InventoryGenEntry> inventoryGenEntries = new List<InventoryGenEntry>();
                foreach (DataRow dr in dtSarfEdilmisMalzemeler.AsEnumerable().Where(x => x.Field<decimal>("Gerçekleşen Miktar") < 0))
                {
                    if (dr["DocEntry"] != DBNull.Value) //Daah önce yaratılmış olan çıkışların satır numarası gelmediğinden bu kontrol yazıldı.
                    {
                        continue;
                    }

                    int uretimSiparisNo = Convert.ToInt32(UretimFisNo);
                    string KalemKodu = dr["Ürün Kodu"].ToString();
                    int SatirNo = Convert.ToInt32(dr["SiraNo"]);
                    var partino = olustulacakPartilers.Where(x => x.UretimSiparisNo == UretimFisNo && x.SatirNo == SatirNo).ToList();
                    double miktar = Convert.ToDouble(dr["Gerçekleşen Miktar"]);

                    if (miktar >= 0)
                    {
                        continue;
                    }

                    inventoryGenEntries.Add(new InventoryGenEntry
                    {
                        Parti = DateTime.Now.ToString("yyyyMMdd") + "-" + uretimSiparisNo + "-" + SatirNo,
                        PartiMiktar = miktar,
                        Miktar = miktar,
                        UretimSiparisi = uretimSiparisNo,
                        SiraNo = SatirNo.ToString(),
                        RotaKodu = rotaKodu,
                    });

                    if (inventoryGenEntries.Count > 0)
                    {
                        belgeOlusacakMi = true;
                        var resp = client.AddInventoryGenEntry(inventoryGenEntries.ToArray(), Giris.dbName, Giris.mKodValue);

                        if (resp.Value != 0 && isOk)
                        {
                            isOk = false;
                        }
                        else if (resp.Value == 0)
                        {
                            isOk = true;
                        }
                        CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");
                    }
                }

                if (isOk)
                {
                    button2.PerformClick();
                }

                if (!belgeOlusacakMi)
                {
                    CustomMsgBtn.Show("Aktarılacak ürün bulunamadı", "UYARI", "TAMAM");
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: URTSRF004 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox1);
            //nesne.ShowDialog();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var columnType = dataGridView2.Columns[e.ColumnIndex].ValueType;
            if (e.RowIndex != -1)
            {
                if (dataGridView2.Columns[e.ColumnIndex].Name == "Gerçekleşen Miktar")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dataGridView2);
                    n.ShowDialog();
                }
            }
        }

        private void dataGridView2_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            //if (e.ColumnIndex == 1 && e.RowIndex >= 0)
            //{
            //    try
            //    {
            //        e.PaintBackground(e.CellBounds, true);
            //        ControlPaint.DrawCheckBox(e.Graphics, e.CellBounds.X + 1, e.CellBounds.Y + 1,
            //            e.CellBounds.Width - 2, e.CellBounds.Height - 2,
            //            (bool)e.FormattedValue ? ButtonState.Checked : ButtonState.Normal);
            //        e.Handled = true;
            //    }
            //    catch (Exception)
            //    {
            //    }
            //}
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
        }

        private void dataGridView1_Sorted(object sender, EventArgs e)
        {
            setFormatGrid(dataGridView1);
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
}
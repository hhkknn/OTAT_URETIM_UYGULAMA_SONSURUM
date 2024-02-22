using AIF.UVT.DatabaseLayer;
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
    public partial class PartiSecimi : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end.

        public PartiSecimi(Models.PartiSecimi _partiSecimi, int _width, int _height)
        {
            partiSecimi = _partiSecimi;

            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = _width;
            initialHeight = _height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            initialFontSize = label3.Font.Size;
            label3.Resize += Form_Resize;

            initialFontSize = label4.Font.Size;
            label4.Resize += Form_Resize;

            initialFontSize = label5.Font.Size;
            label5.Resize += Form_Resize;

            initialFontSize = textBox1.Font.Size;
            textBox1.Resize += Form_Resize;

            initialFontSize = textBox2.Font.Size;
            textBox2.Resize += Form_Resize;

            initialFontSize = textBox3.Font.Size;
            textBox3.Resize += Form_Resize;

            initialFontSize = textBox4.Font.Size;
            textBox4.Resize += Form_Resize;

            initialFontSize = textBox5.Font.Size;
            textBox5.Resize += Form_Resize;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;
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

            textBox1.Font = new Font(textBox1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox1.Font.Style);

            textBox2.Font = new Font(textBox2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox2.Font.Style);

            textBox3.Font = new Font(textBox3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox3.Font.Style);

            textBox4.Font = new Font(textBox4.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox4.Font.Style);

            textBox5.Font = new Font(textBox5.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox5.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button1.Font.Style);

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button2.Font.Style);
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

        public static string dialogResult = "";
        private Models.PartiSecimi partiSecimi = new Models.PartiSecimi();
        private DataTable dataTable = new DataTable();
        private DataTable dtTemp = new DataTable();

        private void PartiSecimi_Load(object sender, EventArgs e)
        {
            try
            {
                dataTable.Columns.Add("UrunKodu", typeof(string));
                //dataTable.Columns.Add("PlanlananMiktar", typeof(double));
                //dataTable.Columns.Add("GerceklesenMiktar", typeof(double));
                dataTable.Columns.Add("Miktar", typeof(double));
                dataTable.Columns.Add("PartiNo", typeof(string));
                dataTable.Columns.Add("KulMiktar", typeof(double));

                DataRow drs = dataTable.NewRow();
                drs["UrunKodu"] = partiSecimi.UrunKodu;

                dataTable.Rows.Add(drs);

                textBox1.Text = partiSecimi.TuketilecekMiktar.ToString("N" + Giris.OndalikMiktar);
                textBox2.Text = "0.00";
                textBox3.Text = "0.00";
                textBox4.Text = partiSecimi.UretimSiparisNo;
                textBox5.Text = partiSecimi.SatirNo.ToString();

                double tuketilenMiktar = 0;
                double kalanMiktar = partiSecimi.TuketilecekMiktar;
                double sonuc = 0;

                dtTemp = dataTable.Copy();
                dtTemp.Rows.Clear();

                foreach (DataRow item in dataTable.Rows)
                {
                    string ItemCode = item["UrunKodu"].ToString();
                    string sql = "Select \"DistNumber\",(\"Quantity\" - \"QuantOut\") as \"KulMiktar\" from OBTN as T0 where T0.\"ItemCode\" = '" + ItemCode + "' and \"Quantity\" - \"QuantOut\" > 0 order by \"InDate\"";

                    SqlCommand cmd = null;
                    cmd = new SqlCommand(sql, Connection.sql);

                    if (Connection.sql.State != ConnectionState.Open)
                        Connection.sql.Open();

                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    foreach (DataRow dr in dt.Rows)
                    {
                        DataRow dr2 = dtTemp.NewRow();
                        dr2["UrunKodu"] = item["UrunKodu"];

                        if (kalanMiktar > 0)
                        {
                            sonuc = kalanMiktar - Convert.ToDouble(dr["KulMiktar"]);

                            if (sonuc >= 0)
                            {
                                dr2["Miktar"] = Convert.ToDouble(dr["KulMiktar"]);
                                kalanMiktar = kalanMiktar - Convert.ToDouble(dr["KulMiktar"]);
                                tuketilenMiktar = tuketilenMiktar + Convert.ToDouble(dr2["Miktar"]);
                            }
                            else
                            {
                                dr2["Miktar"] = kalanMiktar;

                                tuketilenMiktar = tuketilenMiktar + Convert.ToDouble(dr2["Miktar"]);
                                kalanMiktar = 0;
                            }
                        }
                        else
                        {
                            dr2["Miktar"] = 0;
                        }
                        dr2["KulMiktar"] = dr["KulMiktar"];
                        dr2["PartiNo"] = dr["DistNumber"];

                        dtTemp.Rows.Add(dr2);
                    }
                }

                textBox2.Text = tuketilenMiktar.ToString("N" + Giris.OndalikMiktar);
                textBox3.Text = kalanMiktar.ToString("N" + Giris.OndalikMiktar);

                dataGridView1.DataSource = dtTemp;
                dataGridView1.Columns["KulMiktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dataGridView1.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;

                dataGridView1.AutoResizeColumns();

                //for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                //{
                //    string colName = dataGridView1.Columns[i].Name;

                //    if (colName != "Miktar")
                //    {
                //        dataGridView1.Columns[i].ReadOnly = true;
                //    }
                //}

                setFormatGrid(dataGridView1);

                for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Parti seçim ekranı açılırken hata oluştu. Hata kodu: PRT001 " + ex.Message, "UYARI", "TAMAM");
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

        private List<string> PartileriGetir(string itemcode)
        {
            string sql = "Select \"DistNumber\" from OBTN as T0 where T0.\"ItemCode\" = '" + itemcode + "' and \"Quantity\" - \"QuantOut\" > 0 order by \"InDate\"";

            SqlCommand cmd = null;
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            List<string> resp = new List<string>();
            foreach (DataRow item in dt.Rows)
            {
                resp.Add(item["DistNumber"].ToString());
            }

            return resp;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var tuketilecekmiktar = Convert.ToDouble(textBox1.Text);
                var tuketilenkmiktar = Convert.ToDouble(textBox2.Text);

                if (tuketilecekmiktar - tuketilenkmiktar != 0)
                {
                    CustomMsgBtn.Show("Kalan miktar kapanmadığından işleme devam edilemez.", "UYARI", "TAMAM");
                    return;
                }

                foreach (DataRow dr in dtTemp.Rows)
                {
                    if (Convert.ToDouble(dr["Miktar"]) > 0)
                    {
                        UretimSarfiyat.olustulacakPartilers.Add(new Models.OlustulacakPartiler
                        {
                            PartiMiktari = Convert.ToDouble(dr["Miktar"]),
                            UretimSiparisNo = textBox4.Text,
                            Parti = dr["PartiNo"].ToString(),
                            SatirNo = Convert.ToInt32(textBox5.Text)
                        });
                    }
                }

                dialogResult = "Ok";
                Close();
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Tamamlama işlemi sırasında hata oluştu. PRT002 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var grid = (sender as DataGridView);
                if (e.RowIndex != -1 && e.ColumnIndex == 1)
                {
                    var miktar = (grid.Rows[e.RowIndex]).Cells["Miktar"].Value == "" ? 0 : Convert.ToDouble((grid.Rows[e.RowIndex]).Cells["Miktar"].Value);
                    var kullanilanMiktar = (grid.Rows[e.RowIndex]).Cells["KulMiktar"].Value == "" ? 0 : Convert.ToDouble((grid.Rows[e.RowIndex]).Cells["KulMiktar"].Value);

                    if (miktar > kullanilanMiktar)
                    {
                        CustomMsgBtn.Show("Kullanılan miktardan daha fazla miktar girilemez.", "UYARI", "TAMAM");
                        grid.Rows[e.RowIndex].Cells["Miktar"].Value = kullanilanMiktar;
                        return;
                    }
                    hesapla();

                    //double PlanlananMiktar = (grid.Rows[e.RowIndex]).Cells["Planlanan Miktar"].Value == "" ? 0 : Convert.ToDouble((grid.Rows[e.RowIndex]).Cells["Planlanan Miktar"].Value);
                    //double GerceklesenMiktar = (grid.Rows[e.RowIndex]).Cells["Gerçekleşen Miktar"].Value == "" ? 0 : Convert.ToDouble((grid.Rows[e.RowIndex]).Cells["Gerçekleşen Miktar"].Value);
                    //double sonuc = Math.Round(PlanlananMiktar - GerceklesenMiktar, 2);

                    //(grid.Rows[e.RowIndex]).Cells["Fark"].Value = sonuc.ToString("N" + Giris.OndalikMiktar);
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: PRT003 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private bool hesapla()
        {
            try
            {
                double sum = 0;
                double tuketilecekmiktar = Convert.ToDouble(textBox1.Text);
                double tuketilenMiktar = 0;
                double sonuc = 0;
                double kalan = 0;
                foreach (DataRow dr in dtTemp.Rows)
                {
                    sum += Convert.ToDouble(dr["Miktar"]);
                }

                if (sum > tuketilecekmiktar)
                {
                }
                else
                {
                    //sonuc = tuketilecekmiktar - sum;
                    textBox2.Text = sum.ToString("N" + Giris.OndalikMiktar);
                    tuketilenMiktar = Convert.ToDouble(textBox2.Text);

                    kalan = tuketilecekmiktar - tuketilenMiktar;

                    textBox3.Text = kalan.ToString("N" + Giris.OndalikMiktar);
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Parti ekranında hesaplama yapılırken hata oluştu. Hata kodu: PRT004 " + ex.Message, "UYARI", "TAMAM");
            }

            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
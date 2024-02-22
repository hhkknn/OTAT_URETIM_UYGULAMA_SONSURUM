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
    public partial class AyranGunlukOzet_3 : Form
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

        public AyranGunlukOzet_3(string _type, string _kullaniciid, string _UretimFisNo, string _istasyon, int _row, string _tarih1)
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

            initialFontSize = btnTamYagliAyran.Font.Size;
            btnTamYagliAyran.Resize += Form_Resize;

            initialFontSize = btnYarimYagliAyran.Font.Size;
            btnYarimYagliAyran.Resize += Form_Resize;

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

            btnTamYagliAyran.Font = new Font(btnTamYagliAyran.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnTamYagliAyran.Font.Style);

            btnYarimYagliAyran.Font = new Font(btnYarimYagliAyran.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnYarimYagliAyran.Font.Style);

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

        public static Form AyranGunlukOzet3Formu = null;

        private void AyranGunlukOzet_3_Load(object sender, EventArgs e)
        {
            dtgYardimciMalzemeBilgileriLoad();
            AyranGunlukOzet3Formu = this;
        }

        private SqlCommand cmd = null;
        private DataTable dtYardimciMalzemeKontrolu = new DataTable();

        private void dtgYardimciMalzemeBilgileriLoad()
        {
            string sql = "SELECT \"U_UrunKodu\" as \"Ürün Kodu\",\"U_UrunAdi\" as \"Ürün Adı\", T1.\"U_BardakTedAdi\" as \"Bardak Tedarikçi Adı\", T1.\"U_BardakPartiNo\" as \"Bardak Parti No\",T1.\"U_FolyoTedAdi\" as \"Folyo Tedarikçi Adı\", T1.\"U_FolyoPartiNo\" as \"Folyo Parti No\",T1.\"U_ViyolTedAdi\" as \"Viyol Tedarikçi Adı\", T1.\"U_ViyolPartiNo\" as \"Viyol Parti No\" FROM \"@AIF_AYRNOZTYRDMLZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRNOZTYRDMLZ1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_UretimTarihi\" = '" + tarih1 + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgYardimciMalzemeKontrolu.DataSource = dt;
            dtYardimciMalzemeKontrolu = dt;

            dtgYardimciMalzemeKontrolu.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgYardimciMalzemeKontrolu.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgYardimciMalzemeKontrolu.EnableHeadersVisualStyles = false;
            dtgYardimciMalzemeKontrolu.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;

            foreach (DataGridViewColumn col in dtgYardimciMalzemeKontrolu.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            if (dt.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dt.NewRow();
                dr["Ürün Adı"] = "";
                dr["Bardak Tedarikçi Adı"] = "";
                dr["Bardak Parti No"] = "";
                dr["Folyo Tedarikçi Adı"] = "";
                dr["Folyo Parti No"] = "";
                dr["Viyol Tedarikçi Adı"] = "";
                dr["Viyol Parti No"] = "";

                dt.Rows.Add(dr);
            }

            //dtgYardimciMalzemeKontrolu.Columns["Paketlenen Ayran Miktarı(Adet)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgYardimciMalzemeKontrolu.Columns["Paketlenen Ayran Miktarı(Adet)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dtgYardimciMalzemeKontrolu.Columns["Paketlenen Ayran Miktarı(LT)"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgYardimciMalzemeKontrolu.Columns["Paketlenen Ayran Miktarı(LT)"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgYardimciMalzemeKontrolu.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();
            //dtgProsesOzellikleri1.AutoResizeColumns();

            //dtgProsesOzellikleri1.Columns["Görevli Operatör"].Visible = false;

            foreach (DataGridViewColumn column in dtgYardimciMalzemeKontrolu.Columns)
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
            AyranYardimciMalzemeGunlukOzet nesne = new AyranYardimciMalzemeGunlukOzet();

            AyranYardimciMalzemeGunlukOzet1 ayranYardimciMalzemeGunlukOzet1 = new AyranYardimciMalzemeGunlukOzet1();
            List<AyranYardimciMalzemeGunlukOzet1> ayranYardimciMalzemeGunlukOzet1s = new List<AyranYardimciMalzemeGunlukOzet1>();

            nesne.UretimTarihi = tarih1;
            nesne.UretimVardiyasi = "";
            //nesne.Aciklama = "Hakan";
            foreach (DataGridViewRow dr in dtgYardimciMalzemeKontrolu.Rows)
            {
                ayranYardimciMalzemeGunlukOzet1 = new AyranYardimciMalzemeGunlukOzet1();
                ayranYardimciMalzemeGunlukOzet1.UrunKodu = dr.Cells["Ürün Kodu"].Value == DBNull.Value ? "" : dr.Cells["Ürün Kodu"].Value.ToString();

                if (ayranYardimciMalzemeGunlukOzet1.UrunKodu == "")
                {
                    continue;
                }

                ayranYardimciMalzemeGunlukOzet1.UrunAdi = dr.Cells["Ürün Adı"].Value == DBNull.Value ? "" : dr.Cells["Ürün Adı"].Value.ToString();
                ayranYardimciMalzemeGunlukOzet1.BardakTedarikciAdi = dr.Cells["Bardak Tedarikçi Adı"].Value == DBNull.Value ? "" : dr.Cells["Bardak Tedarikçi Adı"].Value.ToString();
                ayranYardimciMalzemeGunlukOzet1.BardakPartiNo = dr.Cells["Bardak Parti No"].Value == DBNull.Value ? "" : dr.Cells["Bardak Parti No"].Value.ToString();
                ayranYardimciMalzemeGunlukOzet1.FolyoTedarikciAdi = dr.Cells["Folyo Tedarikçi Adı"].Value == DBNull.Value ? "" : dr.Cells["Folyo Tedarikçi Adı"].Value.ToString();
                ayranYardimciMalzemeGunlukOzet1.FolyoPartiNo = dr.Cells["Folyo Parti No"].Value == DBNull.Value ? "" : dr.Cells["Folyo Parti No"].Value.ToString();
                ayranYardimciMalzemeGunlukOzet1.ViyolTedarikciAdi = dr.Cells["Viyol Tedarikçi Adı"].Value == DBNull.Value ? "" : dr.Cells["Viyol Tedarikçi Adı"].Value.ToString();
                ayranYardimciMalzemeGunlukOzet1.ViyolPartiNo = dr.Cells["Viyol Tedarikçi Adı"].Value == DBNull.Value ? "" : dr.Cells["Viyol Tedarikçi Adı"].Value.ToString();

                ayranYardimciMalzemeGunlukOzet1s.Add(ayranYardimciMalzemeGunlukOzet1);
            }

            nesne.ayranYardimciMalzemeGunlukOzet1s = ayranYardimciMalzemeGunlukOzet1s.ToArray();

            var resp = client.AddOrUpdateAyranOzetYardimciMalzeme(nesne, Giris.dbName, Giris.mKodValue);

            CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

            if (resp.Value == 0)
            {
                //btnOzetEkranaDon.PerformClick();
            }
        }

        private void dtgYardimciMalzemeKontrolu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgYardimciMalzemeKontrolu.Columns[e.ColumnIndex].Name == "Ürün Adı")
            {
                string sql1 = "Select TOP 1 '' as \"Kalem Kodu\",'' as \"Kalem Adı\" FROM OITM WITH (NOLOCK) ";
                sql1 += " UNION ALL ";
                sql1 += "Select ItemCode as \"Kalem Kodu\",ItemName as \"Kalem Adı\" FROM OITM WITH (NOLOCK) ";

                SelectList selectList = new SelectList(sql1, dtgYardimciMalzemeKontrolu, 0, 1, _autoresizerow: false);
                selectList.ShowDialog();

                var sonSatir = dtgYardimciMalzemeKontrolu.Rows[dtgYardimciMalzemeKontrolu.RowCount - 1].Cells[e.ColumnIndex].Value.ToString();

                if (sonSatir != "")
                {
                    System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                    DataRow dr = dtYardimciMalzemeKontrolu.NewRow();
                    dr["Ürün Kodu"] = "";
                    dr["Ürün Adı"] = "";
                    dr["Bardak Tedarikçi Adı"] = "";
                    dr["Bardak Parti No"] = "";
                    dr["Folyo Tedarikçi Adı"] = "";
                    dr["Folyo Parti No"] = "";
                    dr["Viyol Tedarikçi Adı"] = "";
                    dr["Viyol Parti No"] = "";

                    dtYardimciMalzemeKontrolu.Rows.Add(dr);
                }
            }
            else if (dtgYardimciMalzemeKontrolu.Columns[e.ColumnIndex].Name == "Bardak Tedarikçi Adı" || dtgYardimciMalzemeKontrolu.Columns[e.ColumnIndex].Name == "Folyo Tedarikçi Adı" || dtgYardimciMalzemeKontrolu.Columns[e.ColumnIndex].Name == "Viyol Tedarikçi Adı")
            {
                string sql1 = "Select TOP 1 '' as \"Müşteri Kodu\",'' as \"Müşteri Adı\" FROM OCRD WITH (NOLOCK) where \"CardType\" = 'S'";
                sql1 += " UNION ALL ";
                sql1 += "Select CardCode as \"Müşteri Kodu\",CardName as \"Müşteri Adı\" FROM OCRD WITH (NOLOCK) where \"CardType\" = 'S'";

                SelectList selectList = new SelectList(sql1, dtgYardimciMalzemeKontrolu, -1, e.ColumnIndex, _autoresizerow: false);
                selectList.ShowDialog();
            }
        }

        private void btnTamYagliAyran_Click(object sender, EventArgs e)
        {
            if (AyranGunlukOzet_1.AyranGunlukOzet1Formu == null)
            {
                AyranGunlukOzet_1 n2 = new AyranGunlukOzet_1(type, kullaniciid, "", "", 0, tarih1);
                n2.Show();
            }
            else
            {
                AyranGunlukOzet_1.AyranGunlukOzet1Formu.Activate();
            }
        }

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

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }
    }
}
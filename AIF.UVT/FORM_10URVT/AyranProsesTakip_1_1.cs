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
    public partial class AyranProsesTakip_1_1 : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end. 
        public AyranProsesTakip_1_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunGrubu, DataTable _dtgMamulOzellikleri1_DataTable, DataTable _dtgMamulOzellikleri2_DataTable, DataTable _dtgPihtiKirim_DataTable, DataTable _dtgBirinciKultur_DataTable, DataTable _dtgIkinciKultur_DataTable, DataTable _dtgTuzOzellikleri_DataTable, DataTable _dtgSutunOzellikleri_DataTable, DataTable _dtgYariMamulKaliteOzellikleri_DataTable, DataTable _dtgInkubasyonTakip_DataTable, TextBox _txtAciklama)
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

            initialFontSize = btnOzetEkranaDon.Font.Size;
            btnOzetEkranaDon.Resize += Form_Resize;

            initialFontSize = btnOnayla.Font.Size;
            btnOnayla.Resize += Form_Resize;

            initialFontSize = btnAciklama.Font.Size;
            btnAciklama.Resize += Form_Resize;

            //font end

            UretimFisNo = _UretimFisNo;
            partiNo = _PartiNo;
            UrunTanimi = _UrunTanimi;
            type = _type;
            kullaniciid = _kullaniciid;
            row = _row;
            istasyon = _istasyon;
            tarih1 = _tarih1;
            UrunGrubu = _urunGrubu;

            dtgMamulOzellikleri1_DataTable = _dtgMamulOzellikleri1_DataTable;
            dtgMamulOzellikleri2_DataTable = _dtgMamulOzellikleri2_DataTable;
            dtgPihtiKirim_DataTable = _dtgPihtiKirim_DataTable;
            dtgBirinciKultur_DataTable = _dtgBirinciKultur_DataTable;
            dtgIkinciKultur_DataTable = _dtgIkinciKultur_DataTable;
            dtgTuzOzellikleri_DataTable = _dtgTuzOzellikleri_DataTable;
            dtgSutunOzellikleri_DataTable = _dtgSutunOzellikleri_DataTable;
            dtgYariMamulKaliteOzellikleri_DataTable = _dtgYariMamulKaliteOzellikleri_DataTable;
            dtgInkubasyonTakip_DataTable = _dtgInkubasyonTakip_DataTable;
            txtAciklama_IlkEkran = _txtAciklama;


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

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              btnOnayla.Font.Style);

            btnAciklama.Font = new Font(btnAciklama.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnAciklama.Font.Style);

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

        DataTable dataTable1 = new DataTable();
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

        private static UVTServiceSoapClient client = new UVTServiceSoapClient();
        DataTable dtgMamulOzellikleri1_DataTable = new DataTable();
        DataTable dtgMamulOzellikleri2_DataTable = new DataTable();
        DataTable dtgPihtiKirim_DataTable = new DataTable();
        DataTable dtgBirinciKultur_DataTable = new DataTable();
        DataTable dtgIkinciKultur_DataTable = new DataTable();
        DataTable dtgTuzOzellikleri_DataTable = new DataTable();
        DataTable dtgSutunOzellikleri_DataTable = new DataTable();
        DataTable dtgYariMamulKaliteOzellikleri_DataTable = new DataTable();
        DataTable dtgInkubasyonTakip_DataTable = new DataTable();
        TextBox txtAciklama_IlkEkran;
        private void AyranProsesTakip_1_1_Load(object sender, EventArgs e)
        {
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_AYRPRSS_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            sda.Fill(dataTable1);

            if (dataTable1.Rows.Count > 0)
            {
                txtAciklama.Text = dataTable1.Rows[0].ItemArray[0].ToString();
            }

            dtgSutunOzellikleriLoad();
            dtgYariMamulKaliteOzellikleriLoad();
            dtgInkubasyonTakipOzellikleriLoad();

            txtAciklama.Text = txtAciklama_IlkEkran.Text;
        }

        private void dtgSutunOzellikleriLoad()
        {
            dtgSutunOzellikleri.DataSource = dtgSutunOzellikleri_DataTable;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgSutunOzellikleri.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgSutunOzellikleri.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dtgSutunOzellikleri.EnableHeadersVisualStyles = false;
            dtgSutunOzellikleri.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgSutunOzellikleri.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);

            if (dtgSutunOzellikleri_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgSutunOzellikleri_DataTable.NewRow();
                dr["Süt Türü"] = Convert.ToString("Yağlı", cultureTR);
                dr["Brix"] = Convert.ToString("0", cultureTR);
                dr["PH"] = Convert.ToString("0", cultureTR);
                dr["SH"] = Convert.ToString("0", cultureTR);
                dr["Yağ"] = Convert.ToString("0", cultureTR);

                dtgSutunOzellikleri_DataTable.Rows.Add(dr);

                dr = dtgSutunOzellikleri_DataTable.NewRow();
                dr["Süt Türü"] = Convert.ToString("Yağsız", cultureTR);
                dr["Brix"] = Convert.ToString("0", cultureTR);
                dr["PH"] = Convert.ToString("0", cultureTR);
                dr["SH"] = Convert.ToString("0", cultureTR);
                dr["Yağ"] = Convert.ToString("0", cultureTR);

                dtgSutunOzellikleri_DataTable.Rows.Add(dr);
            }
            //dt.Rows.Add();
            dtgSutunOzellikleri.Columns["Brix"].ReadOnly = true;
            dtgSutunOzellikleri.Columns["Brix"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutunOzellikleri.Columns["Brix"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgSutunOzellikleri.Columns["PH"].ReadOnly = true;
            dtgSutunOzellikleri.Columns["PH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutunOzellikleri.Columns["PH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgSutunOzellikleri.Columns["SH"].ReadOnly = true;
            dtgSutunOzellikleri.Columns["SH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutunOzellikleri.Columns["SH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgSutunOzellikleri.Columns["Yağ"].ReadOnly = true;
            dtgSutunOzellikleri.Columns["Yağ"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutunOzellikleri.Columns["Yağ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgSutunOzellikleri.Columns["Süt Türü"].ReadOnly = true;
            dtgSutunOzellikleri.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgSutunOzellikleri.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;
        }

        private void dtgYariMamulKaliteOzellikleriLoad()
        {
            dtgYariMamulKaliteOzellikleri.DataSource = dtgYariMamulKaliteOzellikleri_DataTable;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgYariMamulKaliteOzellikleri.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgYariMamulKaliteOzellikleri.ColumnHeadersDefaultCellStyle.BackColor = Color.RoyalBlue;
            dtgYariMamulKaliteOzellikleri.EnableHeadersVisualStyles = false;
            dtgYariMamulKaliteOzellikleri.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgYariMamulKaliteOzellikleri.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);

            if (dtgYariMamulKaliteOzellikleri_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgYariMamulKaliteOzellikleri_DataTable.NewRow();
                //dr["Parti No"] = partiNo;
                dr["TKM"] = Convert.ToString("0", cultureTR);
                //dr["Protein"] = Convert.ToString("0", cultureTR);
                //dr["Tuz"] = Convert.ToString("0", cultureTR);
                dr["Brix"] = Convert.ToString("0", cultureTR);
                dr["PH"] = Convert.ToString("0", cultureTR);
                dr["SH"] = Convert.ToString("0", cultureTR);
                dr["Yağ"] = Convert.ToString("0", cultureTR);

                dtgYariMamulKaliteOzellikleri_DataTable.Rows.Add(dr);
            }
            //dt.Rows.Add();

            dtgYariMamulKaliteOzellikleri.Rows[0].Cells["Parti No"].Value = partiNo;
            dtgYariMamulKaliteOzellikleri.Columns["Parti No"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["TKM"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["TKM"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgYariMamulKaliteOzellikleri.Columns["TKM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dtgYariMamulKaliteOzellikleri.Columns["Protein"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgYariMamulKaliteOzellikleri.Columns["Protein"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            //dtgYariMamulKaliteOzellikleri.Columns["Tuz"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgYariMamulKaliteOzellikleri.Columns["Tuz"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgYariMamulKaliteOzellikleri.Columns["Brix"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["Brix"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgYariMamulKaliteOzellikleri.Columns["Brix"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgYariMamulKaliteOzellikleri.Columns["PH"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["PH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgYariMamulKaliteOzellikleri.Columns["PH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgYariMamulKaliteOzellikleri.Columns["SH"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["SH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgYariMamulKaliteOzellikleri.Columns["SH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgYariMamulKaliteOzellikleri.Columns["Yağ"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["Yağ"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgYariMamulKaliteOzellikleri.Columns["Yağ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgYariMamulKaliteOzellikleri.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgYariMamulKaliteOzellikleri.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;
        }

        private void dtgInkubasyonTakipOzellikleriLoad()
        {
            dtgInkubasyonTakip.DataSource = dtgInkubasyonTakip_DataTable;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgMamulOzellikleri1.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgInkubasyonTakip.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgInkubasyonTakip.ColumnHeadersDefaultCellStyle.BackColor = Color.IndianRed;
            dtgInkubasyonTakip.EnableHeadersVisualStyles = false;
            dtgInkubasyonTakip.DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
            foreach (DataGridViewColumn col in dtgInkubasyonTakip.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 20F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //SilButonuEkle(dtgMamulOzellikleri1);

            if (dtgInkubasyonTakip_DataTable.Rows.Count == 0)
            {
                System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                DataRow dr = dtgInkubasyonTakip_DataTable.NewRow();
                dr["Kontrol No"] = Convert.ToString("1", cultureTR);
                //dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                dr["Ürün Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["Oda Sıcaklığı"] = Convert.ToString("0", cultureTR);
                dr["PH"] = Convert.ToString("0", cultureTR);

                dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("2", cultureTR);
                ////dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["Ürün Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["Oda Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("3", cultureTR);
                ////dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["Ürün Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["Oda Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("4", cultureTR);
                ////dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["Ürün Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["Oda Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("5", cultureTR);
                ////dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["Ürün Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["Oda Sıcaklığı"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);
            }
            //dt.Rows.Add();

            //dtgInkubasyonTakip.Columns["Sıcaklık"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            //dtgInkubasyonTakip.Columns["Sıcaklık"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgInkubasyonTakip.Columns["Ürün Sıcaklığı"].ReadOnly = true;
            dtgInkubasyonTakip.Columns["Ürün Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgInkubasyonTakip.Columns["Ürün Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgInkubasyonTakip.Columns["Oda Sıcaklığı"].ReadOnly = true;
            dtgInkubasyonTakip.Columns["Oda Sıcaklığı"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgInkubasyonTakip.Columns["Oda Sıcaklığı"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgInkubasyonTakip.Columns["PH"].ReadOnly = true;
            dtgInkubasyonTakip.Columns["PH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgInkubasyonTakip.Columns["PH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            dtgInkubasyonTakip.Columns["Kontrol No"].ReadOnly = true;
            dtgInkubasyonTakip.Columns["Saat"].ReadOnly = true;
            dtgInkubasyonTakip.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();

            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgInkubasyonTakip.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            dtgInkubasyonTakip.Columns["Oda Sıcaklığı"].Visible = false; //21.05.21 tarihinde oda sıcaklığı kaldırıldı.

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;
        }

        private void button4_Click(object sender, EventArgs e) //sola git
        {
            geriDonme = "SolaGit";
            Close();
        }

        private void button5_Click(object sender, EventArgs e) //özet ekrana dön
        {
            geriDonme = "OzeteDon";
            Close();
        }

        private void dtgSutunOzellikleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (type == "IST001") //Bu ekrana veri yalnızca pastorizasyon istasyonunda girilir. Ayran istasyonunda değil.
            {
                return;
            }

            if (dtgSutunOzellikleri.Columns[e.ColumnIndex].Name == "Brix" || dtgSutunOzellikleri.Columns[e.ColumnIndex].Name == "PH" || dtgSutunOzellikleri.Columns[e.ColumnIndex].Name == "SH" || dtgSutunOzellikleri.Columns[e.ColumnIndex].Name == "Yağ")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgSutunOzellikleri, false);
                n.ShowDialog();
            }
            //else if (dtgPihtiKirim.Columns[e.ColumnIndex].Name == "Başlama Saati" || dtgPihtiKirim.Columns[e.ColumnIndex].Name == "Bitiş Saati")
            //{
            //    SaatTarihGirisi n = new SaatTarihGirisi(dtgPihtiKirim);
            //    n.ShowDialog();
            //}
        }

        private void dtgYariMamulKaliteOzellikleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            if (type == "IST001") //Bu ekrana veri yalnızca pastorizasyon istasyonunda girilir. Ayran istasyonunda değil.
            {
                return;
            }

            if (dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "TKM" || dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "Protein" || dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "Tuz" || dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "Brix" || dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "PH" || dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "SH" || dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "Yağ")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgYariMamulKaliteOzellikleri, false);
                n.ShowDialog();
            }
            //else if (dtgPihtiKirim.Columns[e.ColumnIndex].Name == "Başlama Saati" || dtgPihtiKirim.Columns[e.ColumnIndex].Name == "Bitiş Saati")
            //{
            //    SaatTarihGirisi n = new SaatTarihGirisi(dtgPihtiKirim);
            //    n.ShowDialog();
            //}
        }

        private void dtgInkubasyonTakip_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (type == "IST001") //Bu ekrana veri yalnızca pastorizasyon istasyonunda girilir. Ayran istasyonunda değil.
            {
                return;
            }

            bool cvp = true;

            if (dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "Saat")
            {
                cvp = AyranProsesTakip_1.Kontrol(dtgInkubasyonTakip.Columns[e.ColumnIndex].Name, dtgInkubasyonTakip, null, dtgPihtiKirim_DataTable);
            }
            else
            {
                cvp = AyranProsesTakip_1.Kontrol(dtgInkubasyonTakip.Columns[e.ColumnIndex].Name, dtgInkubasyonTakip, null, null);
            }

            if (!cvp)
            {
                return;
            }

            //if (dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "Sıcaklık" || dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "PH")
            if (dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "Ürün Sıcaklığı" || dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "Oda Sıcaklığı" || dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "PH")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgInkubasyonTakip, false);
                n.ShowDialog();
            }
            else if (dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "Saat")
            {
                SaatTarihGirisi n = new SaatTarihGirisi(dtgInkubasyonTakip);
                n.ShowDialog();
            }
            else if (dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "Kontrol Eden Personel")
            {
                if (istasyon.StartsWith("IST"))
                {
                    //string sql = "Select \"empID\" as \"Kullanıcı Kodu\", (\"firstName\" + ' ' + \"lastName\") as 'Ad Soyad' from OHEM where \"Active\" = 'Y'";

                    string field = "U_" + istasyon;

                    DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                    string gunfield = "U_Gun" + dtTarih.Day;
                    string sql1 = "";

                    #region Günlük Personel Planlama 2 ekranı

                    //sql1 = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";

                    //if (AtanmisIsler.Joker)
                    //{
                    //    sql1 += " UNION ALL ";

                    //    sql1 += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                    //}

                    #endregion Günlük Personel Planlama 2 ekranı

                    //string sql = "Select \"U_PersonelNo\" as \"Personel No\",\"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"" + field + "\" = 'Y'";

                    #region Günlük Personel Planlama 3 ekranı

                    //sql1 = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                    //sql1 += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and \"U_Durum\" = 'X'";

                    //#endregion Günlük Personel Planlama 3 ekranı

                    //if (AtanmisIsler.Joker)
                    //{
                    //    sql1 += " UNION ALL ";

                    //    #region Günlük Personel Planlama 2 ekranı

                    //    //sql1 += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";

                    //    #endregion Günlük Personel Planlama 2 ekranı

                    //    #region Günlük Personel Planlama 3 ekranı

                    //    sql1 = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                    //    sql1 += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') and \"U_Durum\" = 'X'";

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



                    SelectList selectList = new SelectList(sql1, dtgInkubasyonTakip, -1, e.ColumnIndex, _autoresizerow: false);
                    selectList.ShowDialog();

                    if (dtgInkubasyonTakip.Rows[dtgInkubasyonTakip.Rows.Count - 1].Cells["Kontrol Eden Personel"].Value != DBNull.Value && dtgInkubasyonTakip.Rows[dtgInkubasyonTakip.Rows.Count - 1].Cells["Kontrol Eden Personel"].Value != "")
                    {
                        System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");
                        DataRow dr = dtgInkubasyonTakip_DataTable.NewRow();
                        dr["Kontrol No"] = Convert.ToString(dtgInkubasyonTakip.Rows.Count + 1, cultureTR);
                        dr["Ürün Sıcaklığı"] = Convert.ToString("0", cultureTR);
                        dr["Oda Sıcaklığı"] = Convert.ToString("0", cultureTR);
                        dr["PH"] = Convert.ToString("0", cultureTR);

                        dtgInkubasyonTakip_DataTable.Rows.Add(dr);
                    }

                    //dtgProsesOzellikleri1.AutoResizeRows();
                }
            }
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            //AyranProsesTakip_1.dtgSutunOzellikleriStatic = dtgSutunOzellikleri;
            //AyranProsesTakip_1.dtgYariMamulKaliteOzellikleriStatic = dtgYariMamulKaliteOzellikleri;
            //AyranProsesTakip_1.dtgInkubasyonTakipStatic = dtgInkubasyonTakip;
            //AyranProsesTakip_1.UretimAciklamasi = txtAciklama.Text;
            //AyranProsesTakip_1.TabloyaKaydet();
            //Close();
            tabloyaKaydetmeIslemleri();
        }

        public static string geriDonme = "";

        private void btnAciklama_Click(object sender, EventArgs e)
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();

            //AyranProsesTakip_1.UretimAciklamasi = txtAciklama.Text;

            txtAciklama_IlkEkran.Text = txtAciklama.Text;
        }

        public void tabloyaKaydetmeIslemleri()
        {
            try
            {
                AyranProsesTakipAnaliz nesne = new AyranProsesTakipAnaliz();

                AyranProsesOzellikleri1 AyranProsesOzellikleri1 = new AyranProsesOzellikleri1();
                List<AyranProsesOzellikleri1> ayranProsesOzellikleri1s = new List<AyranProsesOzellikleri1>();

                AyranProsesOzellikleri2 AyranProsesOzellikleri2 = new AyranProsesOzellikleri2();
                List<AyranProsesOzellikleri2> ayranProsesOzellikleri2s = new List<AyranProsesOzellikleri2>();

                AyranPihtiKirim AyranPihtiKirim = new AyranPihtiKirim();
                List<AyranPihtiKirim> ayranPihtiKirims = new List<AyranPihtiKirim>();

                AyranBirinciKultur AyranBirinciKultur = new AyranBirinciKultur();
                List<AyranBirinciKultur> ayranBirinciKulturs = new List<AyranBirinciKultur>();

                AyranIkinciKultur AyranIkinciKultur = new AyranIkinciKultur();
                List<AyranIkinciKultur> ayranIkinciKulturs = new List<AyranIkinciKultur>();

                AyranTuzOzellikleri AyranTuzOzellikleri = new AyranTuzOzellikleri();
                List<AyranTuzOzellikleri> ayranTuzOzellikleris = new List<AyranTuzOzellikleri>();

                AyranSutOzellikleri AyranSutOzellikleri = new AyranSutOzellikleri();
                List<AyranSutOzellikleri> ayranSutOzellikleris = new List<AyranSutOzellikleri>();

                AyranYariMamulKaliteOzellikleri AyranYariMamulKaliteOzellikleri = new AyranYariMamulKaliteOzellikleri();
                List<AyranYariMamulKaliteOzellikleri> ayranYariMamulKaliteOzellikleris = new List<AyranYariMamulKaliteOzellikleri>();

                AyranInkubasyonOzellikleri AyranInkubasyonOzellikleri = new AyranInkubasyonOzellikleri();
                List<AyranInkubasyonOzellikleri> ayranInkubasyonOzellikleris = new List<AyranInkubasyonOzellikleri>();


                #region eski-tablo kaydetme
                //ayranProsesOzellikleri1s = new List<AyranProsesOzellikleri1>();
                //ayranProsesOzellikleri2s = new List<AyranProsesOzellikleri2>();
                //ayranPihtiKirims = new List<AyranPihtiKirim>();
                //ayranBirinciKulturs = new List<AyranBirinciKultur>();
                //ayranIkinciKulturs = new List<AyranIkinciKultur>();
                //ayranTuzOzellikleris = new List<AyranTuzOzellikleri>();
                //ayranSutOzellikleris = new List<AyranSutOzellikleri>();
                //ayranYariMamulKaliteOzellikleris = new List<AyranYariMamulKaliteOzellikleri>();
                //ayranInkubasyonOzellikleris = new List<AyranInkubasyonOzellikleri>(); 
                #endregion

                nesne.PartiNo = partiNo;
                nesne.Aciklama = txtAciklama.Text;
                nesne.UrunKodu = "";
                nesne.UrunTanimi = UrunTanimi;
                nesne.UretimTarihi = tarih1;

                foreach (DataRow dr in dtgMamulOzellikleri1_DataTable.Rows)
                {
                    AyranProsesOzellikleri1 = new AyranProsesOzellikleri1();
                    AyranProsesOzellikleri1.UrunGrubu = dr["Ürün Grubu"] == DBNull.Value ? "" : dr["Ürün Grubu"].ToString();
                    AyranProsesOzellikleri1.ProsesBaslangicSaati = dr["Proses Başlangıç Saati"] == DBNull.Value ? "" : dr["Proses Başlangıç Saati"].ToString();
                    AyranProsesOzellikleri1.YagliSutMiktari = dr["Yağlı Süt Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağlı Süt Miktarı"]);
                    AyranProsesOzellikleri1.YagsizSutMiktari = dr["Yağsız Süt Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağsız Süt Miktarı"]);
                    AyranProsesOzellikleri1.ToplamSuMiktari = dr["Toplam Su Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Toplam Su Miktarı"]);
                    AyranProsesOzellikleri1.TuzMiktari = dr["Tuz Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Tuz Miktarı"]);
                    AyranProsesOzellikleri1.AyranTuzOrani = dr["Ayran Tuz Oranı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Ayran Tuz Oranı"]);
                    AyranProsesOzellikleri1.ToplamAyranYariMamulMiktari = dr["Toplam Ayran Yarı Mamül Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Toplam Ayran Yarı Mamül Miktarı"]);

                    ayranProsesOzellikleri1s.Add(AyranProsesOzellikleri1);
                }

                nesne.ayranProsesOzellikleri1s = ayranProsesOzellikleri1s.ToArray();

                foreach (DataRow dr in dtgMamulOzellikleri2_DataTable.Rows)
                {
                    AyranProsesOzellikleri2 = new AyranProsesOzellikleri2();
                    AyranProsesOzellikleri2.PastorizasyonSicakligi = dr["Pastörizasyon Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastörizasyon Sıcaklığı"]);
                    AyranProsesOzellikleri2.PastorizasyonSuresi = dr["Pastörizasyon Süresi"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastörizasyon Süresi"]);
                    AyranProsesOzellikleri2.SutVakum = dr["Süt Vakum"] == DBNull.Value ? "" : dr["Süt Vakum"].ToString();
                    AyranProsesOzellikleri2.MayalamaSaati = dr["Mayalama Saati"] == DBNull.Value ? "" : dr["Mayalama Saati"].ToString();
                    AyranProsesOzellikleri2.MayalamaSicakligi = dr["Mayalama Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Mayalama Sıcaklığı"]);
                    AyranProsesOzellikleri2.SorumluPersonel = dr["Sorumlu Personel"] == DBNull.Value ? "" : dr["Sorumlu Personel"].ToString();

                    ayranProsesOzellikleri2s.Add(AyranProsesOzellikleri2);
                }

                nesne.ayranProsesOzellikleri2s = ayranProsesOzellikleri2s.ToArray();

                foreach (DataRow dr in dtgPihtiKirim_DataTable.Rows)
                {
                    AyranPihtiKirim = new AyranPihtiKirim();
                    AyranPihtiKirim.PompaBasinci = dr["Pompa Basıncı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pompa Basıncı"]);
                    AyranPihtiKirim.BaslamaSaati = dr["Başlama Saati"] == DBNull.Value ? "" : dr["Başlama Saati"].ToString();
                    AyranPihtiKirim.BitisSaati = dr["Bitiş Saati"] == DBNull.Value ? "" : dr["Bitiş Saati"].ToString();
                    AyranPihtiKirim.ToplamGecenSure = dr["Toplam Geçen Süre"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Toplam Geçen Süre"]);

                    ayranPihtiKirims.Add(AyranPihtiKirim);
                }

                nesne.ayranPihtiKirims = ayranPihtiKirims.ToArray();

                foreach (DataRow dr in dtgBirinciKultur_DataTable.Rows)
                {
                    AyranBirinciKultur = new AyranBirinciKultur();

                    AyranBirinciKultur.KullanilanMiktar = dr["Kullanılan Miktar"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kullanılan Miktar"]);
                    AyranBirinciKultur.TedarikciAdiveKulturKodu = dr["Tedarikçi Adı ve Kültür Kodu"] == DBNull.Value ? "" : dr["Tedarikçi Adı ve Kültür Kodu"].ToString();
                    AyranBirinciKultur.LotNo = dr["Lot No"] == DBNull.Value ? "" : dr["Lot No"].ToString();

                    ayranBirinciKulturs.Add(AyranBirinciKultur);
                }

                nesne.ayranBirinciKulturs = ayranBirinciKulturs.ToArray();

                foreach (DataRow dr in dtgIkinciKultur_DataTable.Rows)
                {
                    AyranIkinciKultur = new AyranIkinciKultur();

                    AyranIkinciKultur.KullanilanMiktar = dr["Kullanılan Miktar"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kullanılan Miktar"]);
                    AyranIkinciKultur.TedarikciAdiveKulturKodu = dr["Tedarikçi Adı ve Kültür Kodu"] == DBNull.Value ? "" : dr["Tedarikçi Adı ve Kültür Kodu"].ToString();
                    AyranIkinciKultur.LotNo = dr["Lot No"] == DBNull.Value ? "" : dr["Lot No"].ToString();

                    ayranIkinciKulturs.Add(AyranIkinciKultur);
                }

                nesne.ayranIkinciKulturs = ayranIkinciKulturs.ToArray();

                foreach (DataRow dr in dtgTuzOzellikleri_DataTable.Rows)
                {
                    AyranTuzOzellikleri = new AyranTuzOzellikleri();

                    AyranTuzOzellikleri.PartiNo = dr["Parti No"] == DBNull.Value ? "" : dr["Parti No"].ToString();
                    AyranTuzOzellikleri.TedarikciAdi = dr["Tedarikçi Adı"] == DBNull.Value ? "" : dr["Tedarikçi Adı"].ToString();

                    ayranTuzOzellikleris.Add(AyranTuzOzellikleri);
                }

                nesne.ayranTuzOzellikleris = ayranTuzOzellikleris.ToArray();

                foreach (DataRow dr in dtgSutunOzellikleri_DataTable.Rows)
                {
                    AyranSutOzellikleri = new AyranSutOzellikleri();

                    AyranSutOzellikleri.SutTuru = dr["Süt Türü"] == DBNull.Value ? "" : dr["Süt Türü"].ToString();
                    AyranSutOzellikleri.SutunKaynagi = dr["Sütün Kaynağı"] == DBNull.Value ? "" : dr["Sütün Kaynağı"].ToString();
                    AyranSutOzellikleri.Brix = dr["Brix"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Brix"]);
                    AyranSutOzellikleri.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    AyranSutOzellikleri.SH = dr["SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SH"]);
                    AyranSutOzellikleri.Yag = dr["Yağ"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağ"]);

                    ayranSutOzellikleris.Add(AyranSutOzellikleri);
                }

                nesne.ayranSutOzellikleris = ayranSutOzellikleris.ToArray();

                foreach (DataRow dr in dtgYariMamulKaliteOzellikleri_DataTable.Rows)
                {
                    AyranYariMamulKaliteOzellikleri = new AyranYariMamulKaliteOzellikleri();
                    AyranYariMamulKaliteOzellikleri.PartiNo = dr["Parti No"] == DBNull.Value ? "" : dr["Parti No"].ToString();
                    AyranYariMamulKaliteOzellikleri.TKM = dr["TKM"] == DBNull.Value ? 0 : Convert.ToDouble(dr["TKM"]);
                    //AyranYariMamulKaliteOzellikleri.Protein = dr["Protein"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Protein"]);
                    //AyranYariMamulKaliteOzellikleri.Tuz = dr["Tuz"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Tuz"]);
                    AyranYariMamulKaliteOzellikleri.Brix = dr["Brix"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Brix"]);
                    AyranYariMamulKaliteOzellikleri.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    AyranYariMamulKaliteOzellikleri.SH = dr["SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SH"]);
                    AyranYariMamulKaliteOzellikleri.Yag = dr["Yağ"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağ"]);
                    //AyranYariMamulKaliteOzellikleri.TatKokuKivam = dr["Tat Koku ve Kıvamı"] == DBNull.Value ? "" : dr["Tat Koku ve Kıvamı"].ToString();

                    ayranYariMamulKaliteOzellikleris.Add(AyranYariMamulKaliteOzellikleri);
                }

                nesne.ayranYariMamulKaliteOzellikleris = ayranYariMamulKaliteOzellikleris.ToArray();

                foreach (DataRow dr in dtgInkubasyonTakip_DataTable.Rows)
                {
                    AyranInkubasyonOzellikleri = new AyranInkubasyonOzellikleri();
                    AyranInkubasyonOzellikleri.KontrolNo = dr["Kontrol No"] == DBNull.Value ? "" : dr["Kontrol No"].ToString();
                    AyranInkubasyonOzellikleri.Saat = dr["Saat"] == DBNull.Value ? "" : dr["Saat"].ToString();
                    //AyranInkubasyonOzellikleri.Sicaklik = dr["Sıcaklık"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Sıcaklık"]);
                    AyranInkubasyonOzellikleri.UrunSicakligi = dr["Ürün Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Ürün Sıcaklığı"]);
                    AyranInkubasyonOzellikleri.OdaSicakligi = dr["Oda Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Oda Sıcaklığı"]);
                    AyranInkubasyonOzellikleri.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    AyranInkubasyonOzellikleri.KontrolEdenPersonel = dr["Kontrol Eden Personel"] == DBNull.Value ? "" : dr["Kontrol Eden Personel"].ToString();

                    if (AyranInkubasyonOzellikleri.KontrolEdenPersonel != "")
                    {
                        ayranInkubasyonOzellikleris.Add(AyranInkubasyonOzellikleri);
                    }
                }

                nesne.ayranInkubasyonOzellikleris = ayranInkubasyonOzellikleris.ToArray();

                var resp = client.AddOrUpdateAyranProsesTakipAnaliz(nesne, Giris.dbName, Giris.mKodValue);

                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                if (resp.Value == 0)
                {
                    btnOzetEkranaDon.PerformClick();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Hata oluştu." + ex.Message, "UYARI", "TAMAM");

            }
        }
    }
}
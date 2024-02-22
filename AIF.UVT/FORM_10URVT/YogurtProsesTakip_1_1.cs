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
    public partial class YogurtProsesTakip_1_1 : Form
    {
        //font start
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //font end 
        public YogurtProsesTakip_1_1(string _type, string _kullaniciid, string _UretimFisNo, string _PartiNo, string _UrunTanimi, string _istasyon, int _row, string _tarih1, string _urunGrubu, DataTable _dtgProsesOzellikleri1_DataTable, DataTable _dtgProsesOzellikleri2_DataTable, DataTable _dtgBirinciKultur_DataTable, DataTable _dtgProsesOzellikleri3_DataTable, DataTable _dtgIkinciKultur_DataTable, DataTable _dtgSutunOzellikleri_DataTable, DataTable _dtgYariMamulKaliteOzellikleri_DataTable, DataTable _dtgInkubasyonTakip_DataTable, TextBox _txtAciklama)
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

            initialFontSize = btnOzetEkranaDon.Font.Size;
            btnOzetEkranaDon.Resize += Form_Resize;

            initialFontSize = btnOnayla.Font.Size;
            btnOnayla.Resize += Form_Resize;

            initialFontSize = button6.Font.Size;
            button6.Resize += Form_Resize;

            initialFontSize = button7.Font.Size;
            button7.Resize += Form_Resize;

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

            dtgProsesOzellikleri1_DataTable = _dtgProsesOzellikleri1_DataTable;
            dtgProsesOzellikleri2_DataTable = _dtgProsesOzellikleri2_DataTable;
            dtgBirinciKultur_DataTable = _dtgBirinciKultur_DataTable;
            dtgProsesOzellikleri3_DataTable = _dtgProsesOzellikleri3_DataTable;
            dtgIkinciKultur_DataTable = _dtgIkinciKultur_DataTable;
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

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOzetEkranaDon.Font.Style);

            btnOnayla.Font = new Font(btnOnayla.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               btnOnayla.Font.Style);

            button6.Font = new Font(button6.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              button6.Font.Style);

            button7.Font = new Font(button7.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button7.Font.Style);

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
        string UretimFisNo = "";
        string partiNo = "";
        string istasyon = "";
        string UrunTanimi = "";
        string type = "";
        string kullaniciid = "";
        int row = 0;
        string tarih1 = "";
        string UrunGrubu = "";
        private SqlCommand cmd = null;

        private static UVTServiceSoapClient client = new UVTServiceSoapClient();

        DataTable dtgProsesOzellikleri1_DataTable = new DataTable();
        DataTable dtgProsesOzellikleri2_DataTable = new DataTable();
        DataTable dtgBirinciKultur_DataTable = new DataTable();
        DataTable dtgProsesOzellikleri3_DataTable = new DataTable();
        DataTable dtgIkinciKultur_DataTable = new DataTable();
        DataTable dtgSutunOzellikleri_DataTable = new DataTable();
        DataTable dtgYariMamulKaliteOzellikleri_DataTable = new DataTable();
        DataTable dtgInkubasyonTakip_DataTable = new DataTable();
        TextBox txtAciklama_IlkEkran;

        private void YogurtProsesTakip_1_1_Load(object sender, EventArgs e)
        {
            string sql = "SELECT T0.\"U_Aciklama\" as \"Açıklama\" FROM \"@AIF_YGRPRSS_ANLZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
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

            dtgSutunOzellikleriLoad();
            dtgYariMamulKaliteOzellikleriLoad();
            //dtgInkubasyonTakipOzellikleriLoad(); //20220802 chnkapatıldı

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
                dr["TKM"] = Convert.ToString("0", cultureTR);
                dr["Protein"] = Convert.ToString("0", cultureTR);
                dr["Tuz"] = Convert.ToString("0", cultureTR);
                dr["Brix"] = Convert.ToString("0", cultureTR);
                dr["PH"] = Convert.ToString("0", cultureTR);
                dr["SH"] = Convert.ToString("0", cultureTR);
                dr["Yağ"] = Convert.ToString("0", cultureTR);

                dtgYariMamulKaliteOzellikleri_DataTable.Rows.Add(dr);
            }
            //dt.Rows.Add();
            dtgYariMamulKaliteOzellikleri.Columns["Parti No"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Rows[0].Cells["Parti No"].Value = partiNo;
            dtgYariMamulKaliteOzellikleri.Columns["TKM"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["TKM"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgYariMamulKaliteOzellikleri.Columns["TKM"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgYariMamulKaliteOzellikleri.Columns["Tuz"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["Tuz"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgYariMamulKaliteOzellikleri.Columns["Tuz"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgYariMamulKaliteOzellikleri.Columns["PH"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["PH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgYariMamulKaliteOzellikleri.Columns["PH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgYariMamulKaliteOzellikleri.Columns["SH"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["SH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgYariMamulKaliteOzellikleri.Columns["SH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgYariMamulKaliteOzellikleri.Columns["Yağ"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["Yağ"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgYariMamulKaliteOzellikleri.Columns["Yağ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgYariMamulKaliteOzellikleri.Columns["Protein"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["Protein"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgYariMamulKaliteOzellikleri.Columns["Protein"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgYariMamulKaliteOzellikleri.Columns["Brix"].ReadOnly = true;
            dtgYariMamulKaliteOzellikleri.Columns["Brix"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgYariMamulKaliteOzellikleri.Columns["Brix"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgYariMamulKaliteOzellikleri.Columns["Tat Koku ve Kıvamı"].ReadOnly = true;

            dtgYariMamulKaliteOzellikleri.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();


            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgYariMamulKaliteOzellikleri.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;
            dtgYariMamulKaliteOzellikleri.Columns["Tuz"].Visible = false;

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
                dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                dr["PH"] = Convert.ToString("0", cultureTR);

                dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("2", cultureTR);
                //dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("3", cultureTR);
                //dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("4", cultureTR);
                //dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);

                //dr = dtgInkubasyonTakip_DataTable.NewRow();
                //dr["Kontrol No"] = Convert.ToString("5", cultureTR);
                //dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                //dr["PH"] = Convert.ToString("0", cultureTR);

                //dtgInkubasyonTakip_DataTable.Rows.Add(dr);
            }
            //dt.Rows.Add();

            dtgInkubasyonTakip.Columns["Kontrol No"].ReadOnly = true;
            dtgInkubasyonTakip.Columns["Sıcaklık"].ReadOnly = true;
            dtgInkubasyonTakip.Columns["Sıcaklık"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgInkubasyonTakip.Columns["Sıcaklık"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgInkubasyonTakip.Columns["PH"].ReadOnly = true;
            dtgInkubasyonTakip.Columns["PH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgInkubasyonTakip.Columns["PH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dtgInkubasyonTakip.Columns["Kontrol Eden Personel"].ReadOnly = true;

            dtgInkubasyonTakip.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            //dtgMamulOzellikleri1.AutoResizeRows();


            //dtgMamulOzellikleri1.Columns["Personel Kodu"].Visible = false;

            foreach (DataGridViewColumn column in dtgInkubasyonTakip.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }

            //dtgMamulOzellikleri1.Rows[0].Height = dtgMamulOzellikleri1.Height - dtgMamulOzellikleri1.ColumnHeadersHeight;

        }

        private void button7_Click(object sender, EventArgs e) //sola git
        {
            geriDonme = "SolaGit";
            Close();
        }

        private void dtgSutunOzellikleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgSutunOzellikleri.Columns[e.ColumnIndex].Name == "Brix" || dtgSutunOzellikleri.Columns[e.ColumnIndex].Name == "PH" || dtgSutunOzellikleri.Columns[e.ColumnIndex].Name == "SH" || dtgSutunOzellikleri.Columns[e.ColumnIndex].Name == "Yağ")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgSutunOzellikleri, false);
                n.ShowDialog();
            }
        }

        private void dtgYariMamulKaliteOzellikleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "TKM" || dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "Protein" || dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "Tuz" || dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "Brix" || dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "PH" || dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "SH" || dtgYariMamulKaliteOzellikleri.Columns[e.ColumnIndex].Name == "Yağ")
            {
                SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgYariMamulKaliteOzellikleri, false);
                n.ShowDialog();
            }
        }

        private void dtgInkubasyonTakip_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            bool cvp = true;

            if (dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "Saat")
            { 
                cvp = YogurtProsesTakip_1.Kontrol(dtgInkubasyonTakip.Columns[e.ColumnIndex].Name, dtgInkubasyonTakip, null, dtgProsesOzellikleri3_DataTable);

            }
            else
            {
                cvp = YogurtProsesTakip_1.Kontrol(dtgInkubasyonTakip.Columns[e.ColumnIndex].Name, dtgInkubasyonTakip, null, null);
            }

            if (!cvp)
            {
                return;
            }

            if (dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "Sıcaklık" || dtgInkubasyonTakip.Columns[e.ColumnIndex].Name == "PH")
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
                    //sql = "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and " + gunfield + " = 'X' ";


                    //if (AtanmisIsler.Joker)
                    //{
                    //    sql += " UNION ALL ";

                    //    sql += "Select \"U_PersonelNo\" as \"Personel No\", \"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNLUKPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNLUKPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_Aylar\" = '" + dtTarih.Month.ToString().PadLeft(2, '0') + "' and T0.\"U_Yil\" = '" + dtTarih.Year.ToString() + "' and (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') ";
                    //}
                    #endregion

                    #region Günlük Personel Planlama 1 ekranı
                    //string sql = "Select \"U_PersonelNo\" as \"Personel No\",\"U_PersonelAdi\" as \"Personel Adı\" from \"@AIF_GUNPERSPLAN\" as T0 INNER JOIN \"@AIF_GUNPERSPLAN1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_Tarih\" = '" + DateTime.Now.ToString("yyyyMMdd") + "' and \"" + field + "\" = 'Y'"; 
                    #endregion

                    #region Günlük Personel Planlama 3 ekranı

                    //sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                    //sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = '" + type + "' or T1.\"U_Bolum2\" = '" + type + "' or T1.\"U_Bolum3\" = '" + type + "') and \"U_Durum\" = 'X'";

                    //if (AtanmisIsler.Joker)
                    //{
                    //    sql += " UNION ALL ";

                    //    sql = "SELECT \"U_PersonelNo\" AS \"Personel No\",\"U_PersonelAdi\" AS \"Personel Adı\" FROM \"@AIF_GUNLUKPLAN\" AS T0 INNER JOIN \"@AIF_GUNLUKPLAN1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" ";
                    //    sql += "WHERE Convert(varchar,T0.U_Tarih,112) = '" + dtTarih.ToString("yyyyMMdd") + "' AND (T1.\"U_Bolum1\" = 'JOKER' or T1.\"U_Bolum2\" = 'JOKER' or T1.\"U_Bolum3\" = 'JOKER') and \"U_Durum\" = 'X'";
                    //} 
                    #endregion

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
                        dr["Sıcaklık"] = Convert.ToString("0", cultureTR);
                        dr["PH"] = Convert.ToString("0", cultureTR);

                        dtgInkubasyonTakip_DataTable.Rows.Add(dr);
                    }

                    //dtgProsesOzellikleri1.AutoResizeRows();
                }
            }
        }
        public static string geriDonme = "";

        private void button6_Click(object sender, EventArgs e) //açıklama btn
        {
            AciklamaGirisi aciklama = new AciklamaGirisi(txtAciklama, txtAciklama.Text, initialWidth, initialHeight);
            aciklama.ShowDialog();

            txtAciklama_IlkEkran.Text = txtAciklama.Text;

        }

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            geriDonme = "OzeteDon";
            Close();
        }

        private void btnOnayla_Click(object sender, EventArgs e)
        {
            //YogurtProsesTakip_1.dtgSutunOzellikleriStatic = dtgSutunOzellikleri;
            //YogurtProsesTakip_1.dtgYariMamulKaliteOzellikleriStatic = dtgYariMamulKaliteOzellikleri;
            //YogurtProsesTakip_1.dtgInkubasyonTakipStatic = dtgInkubasyonTakip;
            //YogurtProsesTakip_1.UretimAciklamasi = txtAciklama.Text;
            //YogurtProsesTakip_1.TabloyaKaydet();
            //Close();
            tabloyaKaydetmeIslemleri();
        }
        public void tabloyaKaydetmeIslemleri()
        {
            try
            {
                YogurtProsesTakipAnaliz nesne = new YogurtProsesTakipAnaliz();
                YogurtProsesOzellikleri1 YogurtProsesOzellikleri1 = new YogurtProsesOzellikleri1();
                List<YogurtProsesOzellikleri1> YogurtProsesOzellikleri1s = new List<YogurtProsesOzellikleri1>();
                YogurtProsesOzellikleri2 YogurtProsesOzellikleri2 = new YogurtProsesOzellikleri2();
                List<YogurtProsesOzellikleri2> YogurtProsesOzellikleri2s = new List<YogurtProsesOzellikleri2>();
                YogurtProsesOzellikleri3 YogurtProsesOzellikleri3 = new YogurtProsesOzellikleri3();
                List<YogurtProsesOzellikleri3> yogurtProsesOzellikleri3s = new List<YogurtProsesOzellikleri3>();
                YogurtBirinciKultur YogurtBirinciKultur = new YogurtBirinciKultur();
                List<YogurtBirinciKultur> YogurtBirinciKulturs = new List<YogurtBirinciKultur>();
                YogurtIkinciKultur YogurtIkinciKultur = new YogurtIkinciKultur();
                List<YogurtIkinciKultur> YogurtIkinciKulturs = new List<YogurtIkinciKultur>();
                YogurtTuzOzellikleri YogurtTuzOzellikleri = new YogurtTuzOzellikleri();
                List<YogurtTuzOzellikleri> YogurtTuzOzellikleris = new List<YogurtTuzOzellikleri>();
                YogurtSutOzellikleri YogurtSutOzellikleri = new YogurtSutOzellikleri();
                List<YogurtSutOzellikleri> YogurtSutOzellikleris = new List<YogurtSutOzellikleri>();
                YogurtYariMamulKaliteOzellikleri YogurtYariMamulKaliteOzellikleri = new YogurtYariMamulKaliteOzellikleri();
                List<YogurtYariMamulKaliteOzellikleri> YogurtYariMamulKaliteOzellikleris = new List<YogurtYariMamulKaliteOzellikleri>();
                YogurtInkubasyonOzellikleri YogurtInkubasyonOzellikleri = new YogurtInkubasyonOzellikleri();
                List<YogurtInkubasyonOzellikleri> YogurtInkubasyonOzellikleris = new List<YogurtInkubasyonOzellikleri>();

                nesne.PartiNo = partiNo;
                nesne.Aciklama = txtAciklama.Text;
                nesne.UrunKodu = "";
                nesne.UrunTanimi = UrunTanimi;
                nesne.UretimTarihi = tarih1;

                foreach (DataRow dr in dtgProsesOzellikleri1_DataTable.Rows)
                {
                    YogurtProsesOzellikleri1 = new YogurtProsesOzellikleri1();
                    YogurtProsesOzellikleri1.UrunGrubu = dr["Ürün Grubu"] == DBNull.Value ? "" : dr["Ürün Grubu"].ToString();
                    YogurtProsesOzellikleri1.InkubasyonNo = dr["Inkübasyon Oda No"] == DBNull.Value ? "" : dr["Inkübasyon Oda No"].ToString();
                    YogurtProsesOzellikleri1.ProsesBaslangicSaati = dr["Proses Başlangıç Saati"] == DBNull.Value ? "" : dr["Proses Başlangıç Saati"].ToString();
                    YogurtProsesOzellikleri1.YagliSutMiktari = dr["Yağlı Süt Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağlı Süt Miktarı"]);
                    YogurtProsesOzellikleri1.YagsizSutMiktari = dr["Yağsız Süt Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağsız Süt Miktarı"]);
                    YogurtProsesOzellikleri1.KullanilanKremaMiktari = dr["Kullanılan Krema Miktarı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kullanılan Krema Miktarı"]);

                    YogurtProsesOzellikleri1s.Add(YogurtProsesOzellikleri1);
                }

                nesne.YogurtProsesOzellikleri1s = YogurtProsesOzellikleri1s.ToArray();

                foreach (DataRow dr in dtgProsesOzellikleri2_DataTable.Rows)
                {
                    YogurtProsesOzellikleri2 = new YogurtProsesOzellikleri2();
                    YogurtProsesOzellikleri2.VakumBaslangicSaati = dr["Vakum Başlangıç Saati"] == DBNull.Value ? "" : dr["Vakum Başlangıç Saati"].ToString();
                    YogurtProsesOzellikleri2.VakumBitisSaati = dr["Vakum Bitiş Saati"] == DBNull.Value ? "" : dr["Vakum Bitiş Saati"].ToString();
                    YogurtProsesOzellikleri2.VakumSonuSutBrixDegeri = dr["Vakum Sonu Brix Değeri"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Vakum Sonu Brix Değeri"]);
                    YogurtProsesOzellikleri2.PastorizasyonSicakligi = dr["Pastörizasyon Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastörizasyon Sıcaklığı"]);
                    YogurtProsesOzellikleri2.PastorizasyonSuresi = dr["Pastörizasyon Süresi"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Pastörizasyon Süresi"]);
                    YogurtProsesOzellikleri2.MayalamaSaati = dr["Mayalama Saati"] == DBNull.Value ? "" : dr["Mayalama Saati"].ToString();
                    YogurtProsesOzellikleri2.MayalamaPHDegeri = dr["Mayalama PH Değeri"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Mayalama PH Değeri"]);
                    YogurtProsesOzellikleri2.MayalamaSicakligi = dr["Mayalama Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Mayalama Sıcaklığı"]);

                    YogurtProsesOzellikleri2s.Add(YogurtProsesOzellikleri2);
                }

                nesne.YogurtProsesOzellikleri2s = YogurtProsesOzellikleri2s.ToArray();

                foreach (DataRow dr in dtgProsesOzellikleri3_DataTable.Rows)
                {
                    YogurtProsesOzellikleri3 = new YogurtProsesOzellikleri3();
                    YogurtProsesOzellikleri3.DolumBaslangicSaati = dr["Dolum Başlangıç Saati"] == DBNull.Value ? "" : dr["Dolum Başlangıç Saati"].ToString();
                    YogurtProsesOzellikleri3.DolumBaslangicindakiPHDegeri = dr["Dolum Başlangıcındaki PH Değeri"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Başlangıcındaki PH Değeri"]);
                    YogurtProsesOzellikleri3.DolumBaslangicindakiSutSicakligi = dr["Dolum Başlangıcındaki Süt Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Başlangıcındaki Süt Sıcaklığı"]);
                    YogurtProsesOzellikleri3.DolumBitisSaati = dr["Dolum Bitiş Saati"] == DBNull.Value ? "" : dr["Dolum Bitiş Saati"].ToString();
                    YogurtProsesOzellikleri3.DolumBittigindekiPHDegeri = dr["Dolum Bittiğindeki PH Değeri"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Bittiğindeki PH Değeri"]);
                    YogurtProsesOzellikleri3.DolumBittigindekiSutSicakligi = dr["Dolum Bittiğindeki Süt Sıcaklığı"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Dolum Bittiğindeki Süt Sıcaklığı"]);
                    YogurtProsesOzellikleri3.SorumluPersonel = dr["Sorumlu Personel"] == DBNull.Value ? "" : dr["Sorumlu Personel"].ToString();
                    YogurtProsesOzellikleri3.DolumBittigindekiSutSicakligi = dr["Toplam Geçen Süre"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Toplam Geçen Süre"]);

                    yogurtProsesOzellikleri3s.Add(YogurtProsesOzellikleri3);
                }

                nesne.YogurtProsesOzellikleri3s = yogurtProsesOzellikleri3s.ToArray();

                foreach (DataRow dr in dtgBirinciKultur_DataTable.Rows)
                {
                    YogurtBirinciKultur = new YogurtBirinciKultur();

                    YogurtBirinciKultur.KullanilanMiktar = dr["Kullanılan Miktar"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kullanılan Miktar"]);
                    YogurtBirinciKultur.TedarikciAdiveKulturKodu = dr["Tedarikçi Adı ve Kültür Kodu"] == DBNull.Value ? "" : dr["Tedarikçi Adı ve Kültür Kodu"].ToString();
                    YogurtBirinciKultur.LotNo = dr["Lot No"] == DBNull.Value ? "" : dr["Lot No"].ToString();

                    YogurtBirinciKulturs.Add(YogurtBirinciKultur);
                }

                nesne.YogurtBirinciKulturs = YogurtBirinciKulturs.ToArray();

                foreach (DataRow dr in dtgIkinciKultur_DataTable.Rows)
                {
                    YogurtIkinciKultur = new YogurtIkinciKultur();

                    YogurtIkinciKultur.KullanilanMiktar = dr["Kullanılan Miktar"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Kullanılan Miktar"]);
                    YogurtIkinciKultur.TedarikciAdiveKulturKodu = dr["Tedarikçi Adı ve Kültür Kodu"] == DBNull.Value ? "" : dr["Tedarikçi Adı ve Kültür Kodu"].ToString();
                    YogurtIkinciKultur.LotNo = dr["Lot No"] == DBNull.Value ? "" : dr["Lot No"].ToString();

                    YogurtIkinciKulturs.Add(YogurtIkinciKultur);
                }

                nesne.YogurtIkinciKulturs = YogurtIkinciKulturs.ToArray();

                foreach (DataRow dr in dtgSutunOzellikleri_DataTable.Rows)
                {
                    YogurtSutOzellikleri = new YogurtSutOzellikleri();

                    YogurtSutOzellikleri.SutTuru = dr["Süt Türü"] == DBNull.Value ? "" : dr["Süt Türü"].ToString();
                    YogurtSutOzellikleri.SutunKaynagi = dr["Sütün Kaynağı"] == DBNull.Value ? "" : dr["Sütün Kaynağı"].ToString();
                    YogurtSutOzellikleri.Brix = dr["Brix"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Brix"]);
                    YogurtSutOzellikleri.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    YogurtSutOzellikleri.SH = dr["SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SH"]);
                    YogurtSutOzellikleri.Yag = dr["Yağ"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağ"]);

                    YogurtSutOzellikleris.Add(YogurtSutOzellikleri);
                }

                nesne.YogurtSutOzellikleris = YogurtSutOzellikleris.ToArray();

                foreach (DataRow dr in dtgYariMamulKaliteOzellikleri_DataTable.Rows)
                {
                    YogurtYariMamulKaliteOzellikleri = new YogurtYariMamulKaliteOzellikleri();
                    YogurtYariMamulKaliteOzellikleri.PartiNo = dr["Parti No"] == DBNull.Value ? "" : dr["Parti No"].ToString();
                    YogurtYariMamulKaliteOzellikleri.TKM = dr["TKM"] == DBNull.Value ? 0 : Convert.ToDouble(dr["TKM"]);
                    YogurtYariMamulKaliteOzellikleri.Protein = dr["Protein"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Protein"]);
                    YogurtYariMamulKaliteOzellikleri.Tuz = dr["Tuz"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Tuz"]);
                    YogurtYariMamulKaliteOzellikleri.Brix = dr["Brix"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Brix"]);
                    YogurtYariMamulKaliteOzellikleri.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                    YogurtYariMamulKaliteOzellikleri.SH = dr["SH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["SH"]);
                    YogurtYariMamulKaliteOzellikleri.Yag = dr["Yağ"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Yağ"]);
                    YogurtYariMamulKaliteOzellikleri.TatKokuKivam = dr["Tat Koku ve Kıvamı"] == DBNull.Value ? "" : dr["Tat Koku ve Kıvamı"].ToString();

                    YogurtYariMamulKaliteOzellikleris.Add(YogurtYariMamulKaliteOzellikleri);
                }

                nesne.YogurtYariMamulKaliteOzellikleris = YogurtYariMamulKaliteOzellikleris.ToArray();

                //foreach (DataRow dr in dtgInkubasyonTakip_DataTable.Rows)
                //{
                //    YogurtInkubasyonOzellikleri = new YogurtInkubasyonOzellikleri();
                //    YogurtInkubasyonOzellikleri.KontrolNo = dr["Kontrol No"] == DBNull.Value ? "" : dr["Kontrol No"].ToString();
                //    YogurtInkubasyonOzellikleri.Saat = dr["Saat"] == DBNull.Value ? "" : dr["Saat"].ToString();
                //    YogurtInkubasyonOzellikleri.Sicaklik = dr["Sıcaklık"] == DBNull.Value ? 0 : Convert.ToDouble(dr["Sıcaklık"]);
                //    YogurtInkubasyonOzellikleri.PH = dr["PH"] == DBNull.Value ? 0 : Convert.ToDouble(dr["PH"]);
                //    YogurtInkubasyonOzellikleri.KontrolEdenPersonel = dr["Kontrol Eden Personel"] == DBNull.Value ? "" : dr["Kontrol Eden Personel"].ToString();

                //    if (YogurtInkubasyonOzellikleri.KontrolEdenPersonel != "")
                //    {
                //        YogurtInkubasyonOzellikleris.Add(YogurtInkubasyonOzellikleri);
                //    }
                //}

                //nesne.YogurtInkubasyonOzellikleris = YogurtInkubasyonOzellikleris.ToArray();

                var resp = client.AddOrUpdateYogurtProsesTakipAnaliz(nesne, Giris.dbName, Giris.mKodValue);

                MessageBox.Show(resp.Description);

                if (resp.Value == 0)
                {
                    btnOzetEkranaDon.PerformClick();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hata oluştu." + ex.Message);
            }
        }
    }
}
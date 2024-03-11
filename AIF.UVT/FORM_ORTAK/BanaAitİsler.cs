using AIF.UVT.DatabaseLayer;
using AIF.UVT.FORM_010OTATURVT;
using AIF.UVT.FORM_10URVT;
using AIF.UVT.FORM_ORTAK;
using AIF.UVT.UVTService;
using SAPbobsCOM;
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
using System.Windows.Forms.VisualStyles;

namespace AIF.UVT
{
    public partial class BanaAitİsler : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end

        private string tarih1 = "";

        public BanaAitİsler(string type, string _kullaniciid, int _rowid = 0, int _width = 0, int _height = 0, string _tarih1 = "", string _istasyonAdi = "")
        {
            _type = type;
            kullanciid = _kullaniciid;
            rowid = _rowid;
            tarih1 = _tarih1;
            istasyonAdi = _istasyonAdi;
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;

            initialFontSize = button3.Font.Size;
            button3.Resize += Form_Resize;

            initialFontSize = button4.Font.Size;
            button4.Resize += Form_Resize;

            initialFontSize = dataGridView1.Font.Size;
            dataGridView1.Resize += Form_Resize;

            initialFontSize = dataGridView3.Font.Size;
            dataGridView3.Resize += Form_Resize;
            //font end
        }
        string istasyonAdi = "";
        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

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

            btnGunlukTemizlik.Font = new Font(btnGunlukTemizlik.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnGunlukTemizlik.Font.Style);

            btnGunlukAnaliz.Font = new Font(btnGunlukAnaliz.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnGunlukAnaliz.Font.Style);

            btnGunlukSarf.Font = new Font(btnGunlukSarf.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnGunlukSarf.Font.Style);

            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               dataGridView1.Font.Style);

            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               FontStyle.Bold);

            dataGridView3.Font = new Font(dataGridView3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dataGridView3.Font.Style);

            dataGridView3.Font = new Font(dataGridView3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                FontStyle.Bold);

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

        private void Center_Text()
        {
            Graphics g = this.CreateGraphics();
            Double startingPoint = (this.Width / 2) - (g.MeasureString(this.Text.Trim(), this.Font).Width / 2);
            Double widthOfASpace = g.MeasureString(" ", this.Font).Width;
            String tmp = " ";
            Double tmpWidth = 0;
            while ((tmpWidth + widthOfASpace) < startingPoint)
            {
                tmp += " ";
                tmpWidth += widthOfASpace;
            }
            this.Text = tmp + this.Text.Trim();
        }

        private DataTable dtAnalysisData = new DataTable();
        private string _type = "";
        private string kullanciid = "";
        private int rowid = 0;
        private List<string> emptyrow = new List<string>();
        private List<Tuple<string, string>> parametresbuttonlist = new List<Tuple<string, string>>();
        private SqlCommand cmd = null;
        private DateTime siparisTarihi;

        private void BanaAitİsler_Load(object sender, EventArgs e)
        {
            #region MKOD İle Background Değişimi

            var lastOpenedForm = Application.OpenForms.Cast<Form>().Last();

            if (Giris.mKodValue == "010OTATURVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.OTAT_UVT_ArkaPlanV3;

                if (Giris.UretimCalisaniMi == "Hayır")
                {
                    button2.Visible = false;
                    btnGunlukSarf.Visible = false;
                }
            }
            else if (Giris.mKodValue == "20URVT")
            {
                btnGunlukSarf.Visible = false;
                lastOpenedForm.BackgroundImage = Properties.Resources.YORUK_UVT_ArkaPlanv2;
            }

            #endregion MKOD İle Background Değişimi
            try
            {
                string val = _type;

                if (Giris.mKodValue == "010OTATURVT")
                {
                    if (val != "IST001" && val != "IST004" && val != "IST002" && val != "IST007" && val != "IST005")
                    {
                        btnGunlukAnaliz.Visible = false;
                    }
                }
                else if (Giris.mKodValue == "20URVT")
                {

                }

                //Center_Text();

                filtrelemeDurumlariOlustur();
                string sql = "";

                if (Giris.UretimPartilendirmeSekli == "")
                {
                    CustomMsgBtn.Show("Lütfen Üretim Partilendirme Şekli seçimi yapınız.", "UYARI", "TAMAM");
                    return;
                }

                if (Giris.UretimPartilendirmeSekli == "1")
                {
                    sql = "SELECT DISTINCT T3.DocEntry as [Üretim Fiş No],T3.ItemCode as [Ürün Kodu],T3.ProdName as [Ürün Tanımı],T3.PlannedQty as [Miktar],T3.\"CmpltQty\" as [Gerçekleşen Miktar],convert(varchar, T3.StartDate , 104) as Tarih,T3.[U_Istasyon] as \"Istasyon\",T5.\"CodeBars\" as \"Barkod\",T5.\"U_UVTVarsayilanDepo\",convert(varchar,T3.\"PostDate\",104) as \"PostDate\" FROM OWOR as T3 WITH (NOLOCK) INNER JOIN WOR4 T4 WITH (NOLOCK) ON T3.DocEntry = T4.DocEntry INNER JOIN OITM as T5 WITH (NOLOCK) ON T5.ItemCode = T3.ItemCode WHERE T3.DueDate = '" + tarih1 + "' and T3.Status = 'R' ";

                    if (_type != "")
                    {
                        sql += " and T3.[U_Istasyon]= '" + _type + "'";
                    }

                    sql += "order by T3.DocEntry";
                }
                else if (Giris.UretimPartilendirmeSekli == "2")
                {
                    if (Giris.mKodValue == "20URVT")
                    {
                        #region 20220804 öncesi 
                        sql = "SELECT T3.ItemCode AS[Ürün Kodu],T3.ProdName AS[Ürün Tanımı],SUM(T3.PlannedQty) AS[Miktar],sum(T3.\"CmpltQty\") AS[Gerçekleşen Miktar],convert(varchar, T3.StartDate, 104) AS Tarih, T3.[U_Istasyon] AS \"Istasyon\",T5.\"CodeBars\" AS \"Barkod\",T5.\"U_UVTVarsayilanDepo\",convert(varchar,T3.\"PostDate\",104) as \"PostDate\" FROM OWOR AS T3 WITH (NOLOCK) INNER JOIN WOR4 T4 WITH (NOLOCK) ON T3.DocEntry = T4.DocEntry INNER JOIN OITM AS T5 WITH (NOLOCK) ON T5.ItemCode = T3.ItemCode WHERE T3.DueDate = '" + tarih1 + "' AND (T3.Status = 'R' OR T3.Status = 'L') ";

                        if (_type != "")
                        {
                            sql += "  AND T3.\"U_Istasyon\"= '" + _type + "' ";

                        }

                        sql += " GROUP BY T3.\"ItemCode\", T3.\"ProdName\", convert(varchar, T3.\"StartDate\", 104), T3.\"U_Istasyon\", T5.\"CodeBars\", T5.\"U_UVTVarsayilanDepo\",convert(varchar,T3.\"PostDate\",104) as \"PostDate\" ";
                        #endregion
                    }

                    if (Giris.mKodValue == "010OTATURVT")
                    {
                        sql = "SELECT T3.\"ItemCode\" AS \"Ürün Kodu\", T3.\"ProdName\" AS \"Ürün Tanımı\", T5.\"InvntryUom\" AS \"Birim\", SUM(T3.\"PlannedQty\") AS \"Miktar\", sum(T3.\"CmpltQty\") AS \"Gerçekleşen Miktar\",  CASE WHEN T5.\"InvntryUom\" = 'Adet' THEN (SUM(T3.\"PlannedQty\" * T5.\"IWeight1\")/1000) ELSE SUM(T3.\"PlannedQty\") END AS \"Planlanan KG\",CASE WHEN T5.\"InvntryUom\" = 'Adet' THEN (SUM(T3.\"CmpltQty\" * T5.\"IWeight1\")/1000) ELSE SUM(T3.\"CmpltQty\") END AS \"Gerçekleşen KG\", convert(varchar, T3.\"StartDate\", 104) AS \"Tarih\", T3.\"U_Istasyon\" AS \"Istasyon\", T5.\"CodeBars\" AS \"Barkod\", T5.\"U_UVTVarsayilanDepo\",T5.\"ItmsGrpCod\",convert(varchar,T3.\"PostDate\",104) as \"PostDate\"  FROM OWOR AS T3 WITH (NOLOCK) INNER JOIN WOR4 T4 WITH (NOLOCK) ON T3.\"DocEntry\" = T4.\"DocEntry\" INNER JOIN OITM AS T5 WITH (NOLOCK) ON T5.\"ItemCode\" = T3.\"ItemCode\" WHERE T3.\"DueDate\" = '" + tarih1 + "' AND(T3.\"Status\" = 'R' OR T3.\"Status\" = 'L') ";

                        if (_type != "")
                        {
                            sql += "  AND T3.\"U_Istasyon\"= '" + _type + "' ";

                        }

                        sql += " GROUP BY T3.\"ItemCode\", T3.\"ProdName\", convert(varchar, T3.\"StartDate\", 104), T3.\"U_Istasyon\", T5.\"CodeBars\", T5.\"U_UVTVarsayilanDepo\", T5.\"InvntryUom\", T5.\"ItmsGrpCod\",convert(varchar,T3.\"PostDate\",104) ";
                    }


                }
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                #region sql connection chn 
                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
                #endregion

                dataGridView1.DataSource = dt;
                dataGridView1.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Miktar"].DefaultCellStyle.Format = "N1";
                //dataGridView1.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;

                dataGridView1.Columns["Gerçekleşen Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Gerçekleşen Miktar"].DefaultCellStyle.Format = "N1";
                //dataGridView1.Columns["Gerçekleşen Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;

                dataGridView1.Columns["Tarih"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //dataGridView1.Columns["Tarih"].Visible = false;
                dataGridView1.Columns["Istasyon"].Visible = false;
                dataGridView1.Columns["Barkod"].Visible = false;
                dataGridView1.Columns["U_UVTVarsayilanDepo"].Visible = false;
                dataGridView1.Columns["PostDate"].Visible = false;


                if (Giris.mKodValue == "010OTATURVT")
                {
                    dataGridView1.Columns["Planlanan KG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns["Planlanan KG"].DefaultCellStyle.Format = "N1";
                    //dataGridView1.Columns["Planlanan KG"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dataGridView1.Columns["Gerçekleşen KG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns["Gerçekleşen KG"].DefaultCellStyle.Format = "N1";
                    //dataGridView1.Columns["Gerçekleşen KG"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dataGridView1.Columns["ItmsGrpCod"].Visible = false;
                    dataGridView1.Columns["Birim"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                }
                dataGridView3.AutoResizeRows();
                for (int i = 0; i <= dataGridView1.Columns.Count - 1; i++)
                {
                    dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                    dataGridView1.Columns["Ürün Kodu"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                    dataGridView1.Columns["Ürün Tanımı"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    if (Giris.mKodValue == "010OTATURVT")
                    {
                        dataGridView1.Columns["Birim"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    }
                }
                DataGridViewButtonColumn Select = new DataGridViewButtonColumn();
                Select.Name = "Sec";
                Select.Text = "Seç";
                Select.UseColumnTextForButtonValue = true;
                if (dataGridView1.Columns["Sec"] == null)
                {
                    dataGridView1.Columns.Insert(dataGridView1.Columns.Count, Select);
                }

                foreach (DataGridViewColumn col in dataGridView3.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Bahnschrift", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                setFormatGrid(dataGridView1, 15);

                sda = new SqlDataAdapter(cmd);
                dt = new DataTable();
                dttemp = new DataTable();
                sda.Fill(dt);

                sql = "Select \"U_StationCode\" as IstasyonKodu,\"U_RotaCode\" as RotaKodu,\"U_AnalysisCode\" as AnalizKodu from \"@AIF_ANALYSISPARAM\"  WITH (NOLOCK) where \"U_Active\" = 'Y'";
                cmd = new SqlCommand(sql, Connection.sql);
                sda = new SqlDataAdapter();
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dtAnalysisData);

                #region sql connection chn 
                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
                #endregion

                var arg = new DataGridViewCellEventArgs(dataGridView1.Rows.Count, rowid);
                dataGridView1_CellClick(dataGridView1, arg);
                if (rowid != 0)
                {
                    dataGridView1.Rows[0].Cells[0].Selected = false;
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView1.Rows[rowid].Cells[0].Selected = true;
                }
                if (dataGridView1.Rows.Count > 0)
                {
                    dataGridView3.Rows[0].Cells[0].Selected = false;
                }

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                foreach (DataGridViewColumn column in dataGridView3.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                }

                vScrollBar2.Maximum = dataGridView1.RowCount + 5;
                vScrollBar1.Maximum = dataGridView3.RowCount + 5;

                if (Giris.mKodValue == "010OTATURVT")
                {
                    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.GhostWhite;
                    dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

                }
                if (Giris.mKodValue == "20URVT")
                {
                    dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGoldenrodYellow;
                    dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                SatirRenkle(rowid, dataGridView1);
            }
            catch (Exception ex)
            {
            }
            try
            {
                if (dataGridView1.RowCount > 0)
                {
                    dataGridView1.Columns["Miktar"].HeaderText = "Planlanan Miktar";
                    dataGridView1.Columns["U_UVTVarsayilanDepo"].Visible = false;
                }

            }
            catch (Exception)
            {
            }
        }

        private void setFormatGrid(DataGridView dtg, int value)
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

            foreach (DataGridViewColumn col in dtg.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            //for (int i = 0; i <= dtg.Rows.Count - 1; i++)
            //{
            //    //var aa = dtg.RowTemplate.Height;
            //    //dtg.Rows[i].Height = aa + value;
            //    if (i % 2 == 0)
            //        dtg.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
            //    else
            //        dtg.Rows[i].DefaultCellStyle.BackColor = Color.DimGray;

            //    dtg.Rows[i].DefaultCellStyle.ForeColor = Color.White;
            //}
        }

        private void addButton(DataGridView dt)
        {
            parametresbuttonlist = new List<Tuple<string, string>>();
            parametresbuttonlist.Add(Tuple.Create("Baslat", "Başlat"));
            parametresbuttonlist.Add(Tuple.Create("Duraklat", "Duraklat"));
            //parametresbuttonlist.Add(Tuple.Create("DevamEt", "DevamEt"));
            parametresbuttonlist.Add(Tuple.Create("Tamamla", "Tamamla"));
            parametresbuttonlist.Add(Tuple.Create("PaletBarkodu", "Palet Barkodu"));
            parametresbuttonlist.Add(Tuple.Create("Analiz", "Analiz"));
            parametresbuttonlist.Add(Tuple.Create("SarfEt", "SarfEt"));

            DataGridViewButtonColumn btn = new DataGridViewButtonColumn();

            foreach (var item in parametresbuttonlist)
            {
                btn = new DataGridViewButtonColumn();
                dt.Columns.Add(btn);
                btn.HeaderText = "";
                btn.Text = item.Item2;
                btn.Name = "btn" + item.Item1;
                if (item.Item1 != "Tamamla")
                {
                    btn.UseColumnTextForButtonValue = true;
                }

                if (Giris.KaliteCalisaniMi == "E" && Giris.UretimCalisaniMi == "Evet" && (item.Item1 == "Baslat" || item.Item1 == "Duraklat" || item.Item1 == "Tamamla" || item.Item1 == "SarfEt"))
                {
                    btn.Visible = true;
                }
                else if (Giris.KaliteCalisaniMi == "E" && Giris.UretimCalisaniMi == "Hayır" && (item.Item1 == "Baslat" || item.Item1 == "Duraklat" || item.Item1 == "Tamamla" || item.Item1 == "SarfEt"))
                {
                    btn.Visible = false;
                }

                if (item.Item1 == "Duraklat")
                {

                }
            }

            dt.RowHeadersVisible = false;

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                dt.Columns[i].Width = 90;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var BtnCell = (DataGridViewButtonCell)dataGridView3.Rows[i].Cells["btnTamamla"];
                BtnCell.Value = "Tamamla";
            }

            //dt.ScrollBars = ScrollBars.None;
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Hide();
            AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type, kullanciid, dataGridView1.CurrentCell.RowIndex, initialWidth, initialHeight);
            n.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AtanmisIsler atanmisIsler = new AtanmisIsler("", null, kullanciid, Width, Height);
            atanmisIsler.Show();
            Close();
        }

        private void dataGridView3_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            return;
            if (emptyrow.Contains(e.RowIndex.ToString()))
            {
                e.PaintBackground(e.ClipBounds, true);

                Rectangle r = e.CellBounds;

                Rectangle r1 = this.dataGridView3.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);

                r.Width += r1.Width - 90;

                r.Height -= 1;

                using (SolidBrush brBk = new SolidBrush(e.CellStyle.BackColor))

                using (SolidBrush brFr = new SolidBrush(e.CellStyle.ForeColor))

                {
                    SolidBrush s1 = new SolidBrush(Color.Orange);
                    e.Graphics.FillRectangle(s1, r);

                    StringFormat sf = new StringFormat();

                    sf.Alignment = StringAlignment.Center;

                    sf.LineAlignment = StringAlignment.Center;
                    //e.CellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    //e.CellStyle.WrapMode = DataGridViewTriState.True;

                    if (e.ColumnIndex == 5)
                    {
                        FontFamily fontFamily = new FontFamily("Arial");
                        Font font = new Font(
                           fontFamily,
                           14,
                           FontStyle.Bold,
                           GraphicsUnit.Pixel);

                        SolidBrush s = new SolidBrush(Color.White);
                        string tur = dataGridView3.Rows[e.RowIndex + 1].Cells[0].Value.ToString();

                        e.Graphics.DrawString(tur, font, s, r, sf);
                        dataGridView3.Rows[e.RowIndex].Height = dataGridView3.Rows[e.RowIndex + 1].Height;
                        dataGridView3.Rows[e.RowIndex].ReadOnly = true;
                    }

                    e.Handled = true;
                }
            }

            return;
        }

        private string tarih = "";
        System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.RowIndex >= 0)
            {
                var Barkod = dataGridView3.CurrentCell.Value;

                if (Barkod.ToString() == "Barkod")
                {
                    string UretimFisNo = dataGridView3.Rows[e.RowIndex].Cells["Üretim Fiş No"].Value.ToString();
                    string PartiNo = dataGridView3.Rows[e.RowIndex].Cells["Parti No"].Value.ToString();
                    string UrunTanimi = dataGridView3.Rows[e.RowIndex].Cells["Ürün Tanımı"].Value.ToString();
                    string BarkodNumarasi = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Barkod"].Value.ToString();
                    string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                    double GerceklesenMik = Convert.ToDouble(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["GerceklesenMiktar"].Value);
                    string gerceklesen = Convert.ToString(GerceklesenMik.ToString("N" + Giris.OndalikMiktar), cultureTR);

                    if (Giris.mKodValue == "010OTATURVT")
                    {
                        Barkod n = new Barkod(UretimFisNo, PartiNo, UrunTanimi, tarih, initialWidth, initialHeight, BarkodNumarasi, UrunKodu, gerceklesen, _type);
                        n.Show();
                    }
                    if (Giris.mKodValue == "20URVT")
                    {
                        Barkod n = new Barkod(UretimFisNo, PartiNo, UrunTanimi, tarih, initialWidth, initialHeight, BarkodNumarasi, UrunKodu, gerceklesen, _type);
                        n.Show();
                    }

                    return;
                }

                if (dataGridView3.CurrentCell.Value.ToString() == "Palet Barkodu")
                {
                    string val = dataGridView3.Rows[e.RowIndex].Cells["Istasyon"].Value.ToString();
                    string UretimFisNo = dataGridView3.Rows[e.RowIndex].Cells["Üretim Fiş No"].Value.ToString();
                    string PartiNo = dataGridView3.Rows[e.RowIndex].Cells["Parti No"].Value.ToString();
                    string UrunTanimi = dataGridView3.Rows[e.RowIndex].Cells["Ürün Tanımı"].Value.ToString();
                    string BarkodNumarasi = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Barkod"].Value.ToString();
                    string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                    double GerceklesenMik = Convert.ToDouble(dataGridView3.Rows[dataGridView3.CurrentCell.RowIndex].Cells["GerceklesenMiktar"].Value);
                    string gerceklesen = Convert.ToString(GerceklesenMik.ToString("N" + Giris.OndalikMiktar), cultureTR);

                    if (Giris.mKodValue == "010OTATURVT")
                    {
                        PaletBarkoduOlustur paletBarkoduOlustur = new PaletBarkoduOlustur(PartiNo, UretimFisNo, val, kullanciid, dataGridView1.CurrentCell.RowIndex, tarih1, initialWidth, initialHeight, _type);
                        paletBarkoduOlustur.Show();
                    }
                    if (Giris.mKodValue == "20URVT")
                    {
                        //PaletBarkoduOlustur paletBarkoduOlustur = new PaletBarkoduOlustur(PartiNo, initialWidth, initialHeight, _type);
                        //paletBarkoduOlustur.Show();
                    }

                    return;
                }

                if (senderGrid.Columns[e.ColumnIndex].Name == "btnAnaliz")
                {
                    string val = dataGridView3.Rows[e.RowIndex].Cells["Istasyon"].Value.ToString();
                    string PartiNo = dataGridView3.Rows[e.RowIndex].Cells["Parti No"].Value.ToString();
                    string RotaKodu = dataGridView3.Rows[e.RowIndex].Cells["RotaKodu"].Value.ToString();
                    string UretimFisNo = dataGridView3.Rows[e.RowIndex].Cells["Üretim Fiş No"].Value.ToString();
                    string UrunTanimi = dataGridView3.Rows[e.RowIndex].Cells["Ürün Tanımı"].Value.ToString();
                    string rotaAdi = dataGridView3.Rows[e.RowIndex].Cells["Rota"].Value.ToString();

                    string Durum = dataGridView3.Rows[e.RowIndex].Cells["Durum"].Value.ToString();

                    if (Durum == "Başlanmadı")
                    {
                        CustomMsgBtn.Show("Başlanmamış rota üzerinde analiz işlemi gerçekleştiremezsiniz.", "UYARI", "TAMAM");
                        return;
                    }

                    //if (satirDurumlaris.Where(x => x.PartiNo == PartiNo && x.rotaKodu == RotaKodu).Select(y => y.Durum).FirstOrDefault() == "3")
                    //{
                    //    MessageBox.Show("Tamamlanmış rota üzerinde işlem gerçekleştiremezsiniz.");
                    //    return;
                    //}

                    //if (!butonAktif(PartiNo, RotaKodu))
                    //{
                    //    string RotaAdi = satirDurumlaris.Where(x => x.PartiNo == PartiNo && x.aktif == true).Select(y => y.rotaAdi).FirstOrDefault();
                    //    MessageBox.Show(string.Format("{0} parti numaralı {1} aşaması bitirilmeden {2} aşamasına geçilemez.", PartiNo, RotaAdi, rotaAdi));
                    //    return;
                    //}

                    //DataRow[] dtrw = dtAnalysisData.Select("IstasyonKodu = '" + val + "' and RotaKodu='" + rota + "'");
                    DataRow[] dtrw = dtAnalysisData.Select("IstasyonKodu = '" + val + "' and RotaKodu = '" + RotaKodu + "'");
                    string analizEkranid = dtrw.Count() > 0 ? dtrw[0]["AnalizKodu"].ToString() : "-1";

                    if (analizEkranid == "-1")
                    {
                        CustomMsgBtn.Show("Analiz ekranı yapılandırması için yönetici ile irtibata geçiniz.", "UYARI", "TAMAM");
                        return;
                    }

                    string partiNo = dataGridView3.Rows[e.RowIndex].Cells["Parti No"].Value.ToString();
                    string uretimFisNo = dataGridView3.Rows[e.RowIndex].Cells["Üretim Fiş No"].Value.ToString();
                    if (Giris.mKodValue == "010OTATURVT")
                    {
                        if (analizEkranid == "1")
                        {
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            AyranProsesTakip_1 n = new AyranProsesTakip_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunGrubu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "2")
                        {
                            TazePeynirProsesTakip_1 n = new TazePeynirProsesTakip_1(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, dataGridView1.CurrentCell.RowIndex, Width, Height, tarih1, urunKodu);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "3")
                        {
                            string Urunkodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();

                            if (urunKodu != "")
                            {
                                TazePeynirProsesTakip_2 n = new TazePeynirProsesTakip_2(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, dataGridView1.CurrentCell.RowIndex, Width, Height, tarih1, urunKodu);
                                n.Show();
                                Close();
                            }

                            //string partiNo = dataGridView3.Rows[e.RowIndex].Cells["Parti No"].Value.ToString();
                            //string uretimFisNo = dataGridView3.Rows[e.RowIndex].Cells["Üretim Fiş No"].Value.ToString();
                            //TelemeAnalizGiris n = new TelemeAnalizGiris(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, Width, Height, urunKodu, val, dataGridView1.CurrentCell.RowIndex);
                            //n.Show();
                            //TelemeProsesTakip n = new TelemeProsesTakip(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1);
                            //n.Show();
                            //Close();
                        }
                        else if (analizEkranid == "4")
                        {
                            TelemeAnalizGiris n = new TelemeAnalizGiris(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, urunKodu, val, dataGridView1.CurrentCell.RowIndex, Width, Height, tarih1);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "5")
                        {
                            TelemeProsesTakip n = new TelemeProsesTakip(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, Width, Height, tarih1);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "6")
                        {
                            //string partiNo = dataGridView3.Rows[e.RowIndex].Cells["Parti No"].Value.ToString();
                            //string uretimFisNo = dataGridView3.Rows[e.RowIndex].Cells["Üretim Fiş No"].Value.ToString();
                            TereyagProsesTakip_1 n = new TereyagProsesTakip_1(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, dataGridView1.CurrentCell.RowIndex, Width, Height, tarih1, urunKodu);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "7")
                        {
                            TereyagProsesTakip_2 n = new TereyagProsesTakip_2(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, dataGridView1.CurrentCell.RowIndex, Width, Height, tarih1, urunKodu);
                            n.Show();
                            Close();

                            //string partiNo = dataGridView3.Rows[e.RowIndex].Cells["Parti No"].Value.ToString();
                            //string uretimFisNo = dataGridView3.Rows[e.RowIndex].Cells["Üretim Fiş No"].Value.ToString();

                            //TereyagProsesTakip_1 n = new TereyagProsesTakip_1(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, Width, Height, dataGridView1.CurrentCell.RowIndex);

                            //TostPeynirProsesTakip_1 n = new TostPeynirProsesTakip_1(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, Width, Height, dataGridView1.CurrentCell.RowIndex);
                            //n.Show();
                            //Close();

                            //TereyagProsesTakip_2 n = new TereyagProsesTakip_2(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, Width, Height, dataGridView1.CurrentCell.RowIndex);
                            //n.Show();
                            //Close();

                            //TostPeynirProsesTakip_2 n = new TostPeynirProsesTakip_2(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, Width, Height, dataGridView1.CurrentCell.RowIndex);
                            //n.Show();
                            //Close();

                            //TazePeynirProsesTakip_2 n = new TazePeynirProsesTakip_2(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, dataGridView1.CurrentCell.RowIndex, initialWidth, initialHeight, tarih1);
                            //n.Show();
                            //Close();

                            //TereyagAnalizGiris n = new TereyagAnalizGiris(_type, kullanciid, dataGridView1.CurrentCell.RowIndex);
                            //n.Show();
                            //Close();
                        }
                        else if (analizEkranid == "8")
                        {
                            //Close();
                            //TereyagAnalizGiris n = new TereyagAnalizGiris(_type);
                            //n.Show();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();

                            AyranProsesTakip_1 n = new AyranProsesTakip_1(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunGrubu);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "9")
                        {
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type, kullanciid, dataGridView1.CurrentCell.RowIndex, initialWidth, initialHeight);
                            //n.Show();
                            //Close();

                            TostPeynirProsesTakip_1 n = new TostPeynirProsesTakip_1(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, dataGridView1.CurrentCell.RowIndex, Width, Height, tarih1, urunKodu);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "10")
                        {
                            TostPeynirProsesTakip_2 n = new TostPeynirProsesTakip_2(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, dataGridView1.CurrentCell.RowIndex, Width, Height, tarih1);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "11")
                        {
                            TelemeProsesTakip_2 n = new TelemeProsesTakip_2(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "12")
                        {
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            YogurtProsesTakip_1 n = new YogurtProsesTakip_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunGrubu);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "13")
                        {
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            LorProsesTakip n = new LorProsesTakip(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "14")
                        {
                            string Urunkodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();

                            if (urunKodu != "")
                            {
                                #region sadece yağsız termize şartı kaldırıldı 20220929
                                //string sql = "select \"U_AnalizGrubu\" from OITM WITH (NOLOCK) where \"ItemCode\" = '" + urunKodu + "' and (\"U_AnalizGrubu\" = '07' OR  \"U_AnalizGrubu\" ='10')";

                                //cmd = new SqlCommand(sql, Connection.sql);

                                //if (Connection.sql.State != ConnectionState.Open)
                                //    Connection.sql.Open();

                                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                                //DataTable dt = new DataTable();
                                //DataTable dttemp = new DataTable();
                                //sda.Fill(dt);

                                //if (dt.Rows.Count > 0)
                                //{
                                //    PastorizasyonProsesTakip_1 n = new PastorizasyonProsesTakip_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, urunKodu);
                                //    n.Show();
                                //    Close();
                                //}
                                //else
                                //{
                                //    CustomMsgBtn.Show("SADECE YAĞSIZ TERMİZE SÜT VE KOVA KREMA ANALİZ GİRİŞİ YAPILMAKTADIR.", "UYARI", "TAMAM");
                                //} 
                                #endregion

                                PastorizasyonProsesTakip_1 n = new PastorizasyonProsesTakip_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, urunKodu);
                                n.Show();
                                Close();

                            }

                        }
                        else if (analizEkranid == "15")
                        {
                            TostPeynirProsesTakipSatir n = new TostPeynirProsesTakipSatir(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, dataGridView1.CurrentCell.RowIndex, Width, Height, tarih1, urunKodu);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "16")
                        {
                            string Urunkodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();

                            BulkKulturAnalizi n = new BulkKulturAnalizi(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, Width, Height, tarih1, urunKodu);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "17")
                        {
                            string Urunkodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            if (urunKodu != "")
                            {
                                TazePeynirSalamuraSuyu n = new TazePeynirSalamuraSuyu(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, dataGridView1.CurrentCell.RowIndex, Width, Height, tarih1, urunKodu);
                                n.Show();
                                Close();
                            }
                        }
                        else if (analizEkranid == "18")
                        {
                            string Urunkodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            if (urunKodu != "")
                            {
                                YogurtMamulAnalizGiris n = new YogurtMamulAnalizGiris(_type, kullanciid, uretimFisNo, partiNo, UrunTanimi, val, dataGridView1.CurrentCell.RowIndex, Width, Height, tarih1, urunKodu);
                                n.Show();
                                Close();
                            }
                        }
                    }
                    else if (Giris.mKodValue == "20URVT")
                    {
                        if (analizEkranid == "1") //Ayran Sütü Hazırlık
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_007_1 n = new _20_FSAPKY_007_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "2") //Ayran Pastörizasyon Hazırlık 1 
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_007_2_1 n = new _20_FSAPKY_007_2_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "3") //Homojen Yoðurt Sütü
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_007_3 n = new _20_FSAPKY_007_3(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "4") //Pastörizasyon Analiz
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_001 n = new _20_FSAPKY_001(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "5") //Kaşar Teleme
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_002_1 n = new _20_FSAPKY_002_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "6") //Kaşar Haşlama
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_002_2 n = new _20_FSAPKY_002_2(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "7") //Kaşar Paketleme
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_002_3 n = new _20_FSAPKY_002_3(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "8") //Konsantre Ürün UF Analiz - 1 //Konsantre Ürün UF Analiz - 2
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_004_1_1 n = new _20_FSAPKY_004_1_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "9") //UF Proses Ür.
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_004_2 n = new _20_FSAPKY_004_2(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "10") //Lor Pisirim
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_008_1 n = new _20_FSAPKY_008_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "11") //Tereyagi Ürün Analizi
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_010_1 n = new _20_FSAPKY_010_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "12") //Kaymak Ürün Analiz
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_011_1 n = new _20_FSAPKY_011_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "13") //Krem Peynir Üretim Analizi
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_009_1 n = new _20_FSAPKY_009_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "14") //Krema Ürün Analizi
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_012_1 n = new _20_FSAPKY_012_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "15") //Beyaz Peynir Paketleme 
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_003_2 n = new _20_FSAPKY_003_2(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "16") //Beyaz Teleme --
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_003_1 n = new _20_FSAPKY_003_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);;
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "17") //Homojen Yoðurt Sütü --
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_005_2 n = new _20_FSAPKY_005_2(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "18") //Homojenize Yoðurt Dolum İnkübasyon 1 --
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_005_3_1 n = new _20_FSAPKY_005_3_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "19") //Stand.Kaymaklı Yoðurt Analiz 1 --
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_006_1_1 n = new _20_FSAPKY_006_1_1(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                        else if (analizEkranid == "20") //Krema Ürün Paketleme --
                        {
                            string UrunKodu = dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells["Ürün Kodu"].Value.ToString();
                            string UrunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                            _20_FSAPKY_012_2 n = new _20_FSAPKY_012_2(_type, kullanciid, uretimFisNo, partiNo, urunTanimi, val, dataGridView1.CurrentCell.RowIndex, tarih1, UrunKodu);
                            //AyranPaketlemeAnalizi n = new AyranPaketlemeAnalizi(_type);
                            n.Show();
                            Close();
                        }
                    }
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "btnSarfEt")
                {
                    string PartiNo = dataGridView3.Rows[e.RowIndex].Cells["Parti No"].Value.ToString();
                    string RotaKodu = dataGridView3.Rows[e.RowIndex].Cells["RotaKodu"].Value.ToString();
                    string rotaAdi = dataGridView3.Rows[e.RowIndex].Cells["Rota"].Value.ToString();
                    string Durum = dataGridView3.Rows[e.RowIndex].Cells["Durum"].Value.ToString();

                    siparisTarihi = Convert.ToDateTime(dataGridView3.Rows[e.RowIndex].Cells["PostDate"].Value.ToString());


                    if (Durum == "Başlanmadı")
                    {
                        CustomMsgBtn.Show("Başlanmamış rota üzerinde sarfiyat işlemi gerçekleştiremezsiniz.", "UYARI", "TAMAM");
                        return;
                    }

                    #region Tamamlanmış rota olsa bile okuma modunda ekranı açmak için bu kontrol kaldırıldı. Hakan. 
                    //if (satirDurumlaris.Where(x => x.PartiNo == PartiNo && x.rotaKodu == RotaKodu).Select(y => y.Durum).FirstOrDefault() == "3")
                    //{
                    //    CustomMsgBtn.Show("Tamamlanmış rota üzerinde işlem gerçekleştiremezsiniz.", "UYARI", "TAMAM");
                    //    return;
                    //} 
                    #endregion

                    int mod = 0;
                    if (satirDurumlaris.Where(x => x.PartiNo == PartiNo && x.rotaKodu == RotaKodu).Select(y => y.Durum).FirstOrDefault() == "3")
                    {
                        mod = 1; //Okuma modu anlamına gelir.
                    }

                    //if (!butonAktif(PartiNo, RotaKodu))
                    //{
                    //    string RotaAdi = satirDurumlaris.Where(x => x.PartiNo == PartiNo && x.aktif == true).Select(y => y.rotaAdi).FirstOrDefault();
                    //    MessageBox.Show(string.Format("{0} parti numaralı {1} aşaması bitirilmeden {2} aşamasına geçilemez.", PartiNo, RotaAdi, rotaAdi));
                    //    return;
                    //}

                    string val = _type;
                    string stageid = dataGridView3.Rows[e.RowIndex].Cells["StageID"].Value.ToString();
                    string DocNum = dataGridView3.Rows[e.RowIndex].Cells["Üretim Fiş No"].Value.ToString();
                    double partiKatSayi = Convert.ToDouble(dataGridView3.Rows[e.RowIndex].Cells["KatSayi"].Value);
                    string urunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                    string urunTanimi = dataGridView3.Rows[e.RowIndex].Cells["Ürün Tanımı"].Value.ToString();
                    if (DocNum != "")
                    {
                        UretimSarfiyat_2 n = new UretimSarfiyat_2(stageid, DocNum, val, kullanciid, partiKatSayi, PartiNo, RotaKodu, urunGrubu, urunTanimi, dataGridView1.CurrentCell.RowIndex, initialWidth, initialHeight, tarih1, mod, urunKodu);
                        //UretimSarfiyat n = new UretimSarfiyat(stageid, DocNum, val, kullanciid, partiKatSayi, PartiNo, RotaKodu, urunGrubu, urunTanimi, dataGridView1.CurrentCell.RowIndex);
                        n.ShowDialog();
                        //Close();
                    }
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "btnBaslat")
                {
                    string partiNo = dataGridView3.Rows[e.RowIndex].Cells["Parti No"].Value.ToString();
                    string rota = dataGridView3.Rows[e.RowIndex].Cells["RotaKodu"].Value.ToString();
                    string rotaAdi = dataGridView3.Rows[e.RowIndex].Cells["Rota"].Value.ToString();

                    if (satirDurumlaris.Where(x => x.PartiNo == partiNo && x.rotaKodu == rota).Select(y => y.Durum).FirstOrDefault() == "3")
                    {
                        CustomMsgBtn.Show("Tamamlanmış rota üzerinde işlem gerçekleştiremezsiniz.", "UYARI", "TAMAM");
                        return;
                    }

                    if (!butonAktif(partiNo, rota))
                    {
                        string RotaAdi = satirDurumlaris.Where(x => x.PartiNo == partiNo && x.aktif == true).Select(y => y.rotaAdi).FirstOrDefault();
                        CustomMsgBtn.Show(string.Format("{0} parti numaralı {1} aşaması bitirilmeden {2} aşamasına geçilemez.", partiNo, RotaAdi, rotaAdi), "UYARI", "TAMAM");
                        return;
                    }

                    if (satirDurumlaris.Where(x => x.PartiNo == partiNo).Select(y => y.Durum).FirstOrDefault() == "3")
                    {
                        CustomMsgBtn.Show("Tamamlanmış rota üzerinde işlem gerçekleştiremezsiniz.", "UYARI", "TAMAM");
                        return;
                    }

                    if (!butonAktif_SatirKarsilastirma(dataGridView3.CurrentCell.RowIndex))
                    {
                        DialogResult answer = CustomMsgBox.Show("Daha önce başlanmamış partiler mevcuttur. Devam etmek istiyor musunuz?", "Uyarı", "Evet", "Hayır");

                        if (!CustomMsgBox.Value)
                        {
                            return;
                        }

                        //string RotaAdi = satirDurumlaris.Where(x => x.PartiNo == partiNo && x.aktif == true).Select(y => y.rotaAdi).FirstOrDefault();
                        //MessageBox.Show(string.Format("{0} parti numaralı {1} aşaması bitirilmeden {2} aşamasına geçilemez.", partiNo, RotaAdi, rotaAdi));
                        //return;
                    }

                    string stageid = dataGridView3.Rows[e.RowIndex].Cells["StageID"].Value.ToString();
                    string uretimFisNo = dataGridView3.Rows[e.RowIndex].Cells["Üretim Fiş No"].Value.ToString();
                    double planlananMiktar = Convert.ToDouble(dataGridView3.Rows[e.RowIndex].Cells["Miktar"].Value);
                    //AkviteIslemleri n = new AkviteIslemleri(_type, kullanciid, rota, stageid, uretimFisNo, "1", partiNo, urunKodu, "", Width, Height, dataGridView1.CurrentCell.RowIndex);
                    dataGridView1.Refresh();
                    AktiviteIslemleri_2 n = new AktiviteIslemleri_2(_type, kullanciid, rota, stageid, uretimFisNo, "1", partiNo, urunKodu, "", dataGridView1.CurrentCell.RowIndex, planlananMiktar, initialWidth, initialHeight, tarih1, "", siparisTarihi);
                    n.Show();
                    Close();
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "btnDuraklat")
                {
                    string rota = dataGridView3.Rows[e.RowIndex].Cells["RotaKodu"].Value.ToString();
                    string partiNo = dataGridView3.Rows[e.RowIndex].Cells["Parti No"].Value.ToString();
                    string rotaAdi = dataGridView3.Rows[e.RowIndex].Cells["Rota"].Value.ToString();
                    string Durum = dataGridView3.Rows[e.RowIndex].Cells["Durum"].Value.ToString();

                    if (Durum == "Başlanmadı")
                    {
                        CustomMsgBtn.Show("Başlanmamış rota üzerinde duraklatma işlemi gerçekleştiremezsiniz.", "UYARI", "TAMAM");
                        return;
                    }

                    if (satirDurumlaris.Where(x => x.PartiNo == partiNo && x.rotaKodu == rota).Select(y => y.Durum).FirstOrDefault() == "3")
                    {
                        CustomMsgBtn.Show("Tamamlanmış rota üzerinde işlem gerçekleştiremezsiniz.", "UYARI", "TAMAM");
                        return;
                    }

                    if (!butonAktif(partiNo, rota))
                    {
                        string RotaAdi = satirDurumlaris.Where(x => x.PartiNo == partiNo && x.aktif == true).Select(y => y.rotaAdi).FirstOrDefault();
                        CustomMsgBtn.Show(string.Format("{0} parti numaralı {1} aşaması bitirilmeden {2} aşamasına geçilemez.", partiNo, RotaAdi, rotaAdi), "UYARI", "TAMAM");
                        return;
                    }

                    string stageid = dataGridView3.Rows[e.RowIndex].Cells["StageID"].Value.ToString();
                    string uretimFisNo = dataGridView3.Rows[e.RowIndex].Cells["Üretim Fiş No"].Value.ToString();
                    double planlananMiktar = Convert.ToDouble(dataGridView3.Rows[e.RowIndex].Cells["Miktar"].Value);
                    //AkviteIslemleri n = new AkviteIslemleri(_type, kullanciid, rota, stageid, uretimFisNo, "2", partiNo, urunKodu, "", Width, Height, dataGridView1.CurrentCell.RowIndex);
                    AktiviteIslemleri_2 n = new AktiviteIslemleri_2(_type, kullanciid, rota, stageid, uretimFisNo, "2", partiNo, urunKodu, "", dataGridView1.CurrentCell.RowIndex, planlananMiktar, initialWidth, initialHeight, tarih1, "", siparisTarihi, _txtParam: txtAktiviteDurum);
                    n.Show();

                    //dataGridView3.Rows[e.RowIndex].Cells["Durum"].Value = txtAktiviteDurum.Text;
                    Close();

                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "btnDevamEt")
                {
                    string rota = dataGridView3.Rows[e.RowIndex].Cells["RotaKodu"].Value.ToString();
                    string partiNo = dataGridView3.Rows[e.RowIndex].Cells["Parti No"].Value.ToString();
                    string rotaAdi = dataGridView3.Rows[e.RowIndex].Cells["Rota"].Value.ToString();

                    if (satirDurumlaris.Where(x => x.PartiNo == partiNo && x.rotaKodu == rota).Select(y => y.Durum).FirstOrDefault() == "3")
                    {
                        CustomMsgBtn.Show("Tamamlanmış rota üzerinde işlem gerçekleştiremezsiniz.", "UYARI", "TAMAM");
                        return;
                    }

                    if (!butonAktif(partiNo, rota))
                    {
                        string RotaAdi = satirDurumlaris.Where(x => x.PartiNo == partiNo && x.aktif == true).Select(y => y.rotaAdi).FirstOrDefault();
                        CustomMsgBtn.Show(string.Format("{0} parti numaralı {1} aşaması bitirilmeden {2} aşamasına geçilemez.", partiNo, RotaAdi, rotaAdi), "UYARI", "TAMAM");
                        return;
                    }

                    string stageid = dataGridView3.Rows[e.RowIndex].Cells["StageID"].Value.ToString();
                    string uretimFisNo = dataGridView3.Rows[e.RowIndex].Cells["Üretim Fiş No"].Value.ToString();
                    double planlananMiktar = Convert.ToDouble(dataGridView3.Rows[e.RowIndex].Cells["Miktar"].Value);

                    //AkviteIslemleri n = new AkviteIslemleri(_type, kullanciid, rota, stageid, uretimFisNo, "3", partiNo, urunKodu, "", dataGridView1.CurrentCell.RowIndex, initialWidth, initialHeight);
                    AktiviteIslemleri_2 n = new AktiviteIslemleri_2(_type, kullanciid, rota, stageid, uretimFisNo, "3", partiNo, urunKodu, "", dataGridView1.CurrentCell.RowIndex, planlananMiktar, initialWidth, initialHeight, tarih1, "", siparisTarihi, _txtParam: txtAktiviteDurum);
                    n.Show();
                    Close();
                }
                else if (senderGrid.Columns[e.ColumnIndex].Name == "btnTamamla")
                {
                    string rota = dataGridView3.Rows[e.RowIndex].Cells["RotaKodu"].Value.ToString();
                    string partiNo = dataGridView3.Rows[e.RowIndex].Cells["Parti No"].Value.ToString();
                    string val1 = dataGridView3.Rows[e.RowIndex].Cells["Istasyon"].Value.ToString();
                    string sql = "";

                    siparisTarihi = Convert.ToDateTime(dataGridView3.Rows[e.RowIndex].Cells["PostDate"].Value.ToString());

                    //if (siparisTarihiGrid.Contains("."))
                    //{
                    //    siparisTarihiGrid = siparisTarihiGrid.Replace(".","");
                    //}
                    //else if (siparisTarihiGrid.Contains("-"))
                    //{
                    //    siparisTarihiGrid = siparisTarihiGrid.Replace("-", "");
                    //}
                    //else if (siparisTarihiGrid.Contains("/"))
                    //{
                    //    siparisTarihiGrid = siparisTarihiGrid.Replace("/", "");
                    //}
                    //siparisTarihiGrid = siparisTarihiGrid.Substring(0, 4) + siparisTarihiGrid.Substring(4, 2) + siparisTarihiGrid.Substring(6, 2);

                    if (val1 == "IST003" && rota == "RT007")
                    {

                        sql = "SELECT \"U_BaskiBitisSaati\"  FROM \"@AIF_TLMPRSS_ANALIZ\" T0 WITH (NOLOCK) INNER JOIN \"@AIF_TLMPRSS_ANALIZ3\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "' ";

                        cmd = new SqlCommand(sql, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        sda.Fill(dt);

                        #region sql connection chn 
                        Connection.sql.Close();
                        Connection.sql.Dispose();
                        if (Connection.sql.State == ConnectionState.Open)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["U_BaskiBitisSaati"].ToString() == "")
                            {
                                CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                                return;
                            }
                        }
                        else if (dt.Rows.Count == 0)
                        {
                            CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                            return;
                        }
                    }
                    else if (val1 == "IST003" && rota == "RT017")
                    {

                        sql = "SELECT \"U_KullanimTuru\" FROM \"OITM\" WITH (NOLOCK) WHERE \"ItemCode\" = '" + urunKodu + "' ";

                        cmd = new SqlCommand(sql, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        sda.Fill(dt);

                        #region sql connection chn 
                        Connection.sql.Close();
                        Connection.sql.Dispose();
                        if (Connection.sql.State == ConnectionState.Open)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        string kullanimTipi = dt.Rows[0][0].ToString();
                        if (kullanimTipi == "1")
                        {
                            sql = "SELECT \"U_PersonelAdi\" FROM \"@AIF_TLMMML_ANALIZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_TLMMML_ANALIZ1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "' ";
                        }
                        else if (kullanimTipi == "2")
                        {
                            sql = "SELECT \"U_PersonelAdi\",ISNULL(\"U_UrtmSonrasiTelemeMik1\",0) as  \"U_UrtmSonrasiTelemeMik1\" FROM \"@AIF_TLMMML_ANALIZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_TLMMML_ANALIZ1\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "' ";
                        }

                        cmd = new SqlCommand(sql, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        sda = new SqlDataAdapter(cmd);
                        dt = new DataTable();

                        sda.Fill(dt);

                        #region sql connection chn 
                        Connection.sql.Close();
                        Connection.sql.Dispose();
                        if (Connection.sql.State == ConnectionState.Open)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        if (kullanimTipi == "1")
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["U_PersonelAdi"].ToString() == "")
                                {
                                    CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                                    return;
                                }
                            }
                            else if (dt.Rows.Count == 0)
                            {
                                CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                                return;
                            }
                        }
                        else if (kullanimTipi == "2")
                        {
                            if (dt.Rows.Count > 0)
                            {
                                if (dt.Rows[0]["U_PersonelAdi"].ToString() == "" && (dt.Rows[0]["U_UrtmSonrasiTelemeMik1"] == DBNull.Value || Convert.ToDouble(dt.Rows[0]["U_UrtmSonrasiTelemeMik1"]) == 0))
                                {
                                    CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                                    return;
                                }
                            }
                            else if (dt.Rows.Count == 0)
                            {
                                CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                                return;
                            }
                        }
                    }
                    else if (val1 == "IST004" && rota == "RT009")
                    {
                        sql = "SELECT \"U_UretilenUrunAdi\" FROM \"@AIF_TSTPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_TSTPRSS_ANLZ5\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "' ";

                        cmd = new SqlCommand(sql, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        sda.Fill(dt);

                        #region sql connection chn 
                        Connection.sql.Close();
                        Connection.sql.Dispose();
                        if (Connection.sql.State == ConnectionState.Open)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["U_UretilenUrunAdi"].ToString() == "")
                            {
                                CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                                return;
                            }
                        }
                        else if (dt.Rows.Count == 0)
                        {
                            CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                            return;
                        }
                    }
                    else if (val1 == "IST005" && rota == "RT011")
                    {
                        sql = "SELECT \"U_UretilenUrunAdi\"  FROM \"@AIF_TZPPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_TZPPRSS_ANLZ5\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "' ";

                        cmd = new SqlCommand(sql, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        sda.Fill(dt);

                        #region sql connection chn 
                        Connection.sql.Close();
                        Connection.sql.Dispose();
                        if (Connection.sql.State == ConnectionState.Open)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["U_UretilenUrunAdi"].ToString() == "")
                            {
                                CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                                return;
                            }
                        }
                        else if (dt.Rows.Count == 0)
                        {
                            CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                            return;
                        }
                    }
                    else if (val1 == "IST006" && rota == "RT008")
                    {
                        sql = "SELECT \"U_KontrolEdenPers\",ISNULL(\"U_UretimRandimani\",0) AS \"U_UretimRandimani\"  FROM \"@AIF_LORPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_LORPRSS_ANLZ4\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "' ";

                        cmd = new SqlCommand(sql, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        sda.Fill(dt);

                        #region sql connection chn 
                        Connection.sql.Close();
                        Connection.sql.Dispose();
                        if (Connection.sql.State == ConnectionState.Open)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["U_KontrolEdenPers"].ToString() == "" || dt.Rows[0]["U_UretimRandimani"].ToString() == "")
                            {
                                CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                                return;
                            }
                        }
                        else if (dt.Rows.Count == 0)
                        {
                            CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                            return;
                        }
                    }
                    else if (val1 == "IST009" && rota == "RT003")
                    {
                        sql = "SELECT \"U_KontrolEdenPers\" FROM \"@AIF_AYRPRSS_ANLZ\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYRPRSS_ANLZ9\" AS T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "' order by T1.\"LineId\" desc ";


                        cmd = new SqlCommand(sql, Connection.sql);

                        if (Connection.sql.State != ConnectionState.Open)
                            Connection.sql.Open();

                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();

                        sda.Fill(dt);

                        #region sql connection chn 
                        Connection.sql.Close();
                        Connection.sql.Dispose();
                        if (Connection.sql.State == ConnectionState.Open)
                        {
                            cmd.ExecuteNonQuery();
                        }
                        #endregion

                        if (dt.Rows.Count > 0)
                        {
                            if (dt.Rows[0]["U_KontrolEdenPers"].ToString() == "")
                            {
                                CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                                return;
                            }
                        }
                        else if (dt.Rows.Count < 5)
                        {
                            CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz. En az 5 adet inkübasyon verisi girilmesi gerekmektedir.", "UYARI", "TAMAM");
                            return;
                        }
                        else if (dt.Rows.Count == 0)
                        {
                            CustomMsgBtn.Show("Analiz girişi tamamlanmamış olan satır için tamamlama yapılamaz.", "UYARI", "TAMAM");
                            return;
                        }
                    }

                    string rotaAdi = dataGridView3.Rows[e.RowIndex].Cells["Rota"].Value.ToString();
                    string varsayilanDepo = dataGridView3.Rows[e.RowIndex].Cells["U_UVTVarsayilanDepo"].Value.ToString();

                    string Durum = dataGridView3.Rows[e.RowIndex].Cells["Durum"].Value.ToString();

                    if (Durum == "Başlanmadı")
                    {
                        CustomMsgBtn.Show("Başlanmamış rota üzerinde tamamlama işlemi gerçekleştiremezsiniz.", "UYARI", "TAMAM");
                        return;
                    }

                    if (satirDurumlaris.Where(x => x.PartiNo == partiNo && x.rotaKodu == rota).Select(y => y.Durum).FirstOrDefault() == "3")
                    {
                        CustomMsgBtn.Show("Tamamlanmış rota üzerinde işlem gerçekleştiremezsiniz.", "UYARI", "TAMAM");
                        return;
                    }
                    string uretimFisNo = dataGridView3.Rows[e.RowIndex].Cells["Üretim Fiş No"].Value.ToString();

                    #region sarf edilmeden tmaamla butonuna basılmaması içn kontrol eklendi. 1 ise belge eklensin.deðilse eklenmesin.

                    SqlDataAdapter sda_SarfEdilen = new SqlDataAdapter(cmd);
                    DataTable dt_SarfEdilen = new DataTable();
                    string sarfEdilenSql = "";

                    //sarfEdilenSql = "SELECT * from OIGE T0 where T0.\"U_BatchNumber\"= '" + partiNo + "' ";

                    #region old
                    //sarfEdilenSql = "SELECT ISNULL(CASE when T2.TreeType ='P' and COUNT(T0.DocEntry)>0 then 1 when T2.TreeType<>'P' then 1 else 0 end,0) as \"Geç 1\" from OIGE T0 inner join IGE1 T1 on T1.DocEntry = T0.DocEntry inner join OITM T2 on T2.ItemCode = T1.ItemCode ";

                    //sarfEdilenSql += " where T0.U_BatchNumber = '" + partiNo + "' group by T2.TreeType"; 
                    #endregion

                    sarfEdilenSql = "SELECT ISNULL(CASE when T1.ItemType ='4' and COUNT(T0.DocEntry)>0 then 1 when  T1.ItemType<>'4' then 1 else 0 end,0) as \"Geç 1\" from OIGE T0 WITH (NOLOCK) ";
                    sarfEdilenSql += " inner join IGE1 T1 WITH (NOLOCK) on T1.DocEntry = T0.DocEntry ";
                    sarfEdilenSql += " inner join OITM T2 WITH (NOLOCK) on T2.ItemCode = T1.ItemCode ";
                    sarfEdilenSql += " inner join WOR1 T3 WITH (NOLOCK) on T3.DocEntry = T1.BaseEntry and T3.LineNum = T1.BaseLine and T3.ItemCode = T1.ItemCode ";
                    sarfEdilenSql += " where T3.DocEntry = '" + uretimFisNo + "'  group by T1.ItemType";

                    cmd = new SqlCommand(sarfEdilenSql, Connection.sql);

                    if (Connection.sql.State != ConnectionState.Open)
                    {
                        Connection.sql.Open();
                    }
                    sda_SarfEdilen = new SqlDataAdapter(cmd);
                    sda_SarfEdilen.Fill(dt_SarfEdilen);

                    if (dt_SarfEdilen.Rows.Count == 0)
                    {
                        CustomMsgBtn.Show("Sarf edilme işlemi yapılmadan tamamlama işlemi gerçekleştiremezsiniz.", "UYARI", "TAMAM");
                        return;
                    }

                    #endregion

                    if (!butonAktif(partiNo, rota))
                    {
                        string RotaAdi = satirDurumlaris.Where(x => x.PartiNo == partiNo && x.aktif == true).Select(y => y.rotaAdi).FirstOrDefault();
                        CustomMsgBtn.Show(string.Format("{0} parti numaralı {1} aşaması bitirilmeden {2} aşamasına geçilemez.", partiNo, RotaAdi, rotaAdi), "UYARI", "TAMAM");
                        return;
                    }

                    string stageid = dataGridView3.Rows[e.RowIndex].Cells["StageID"].Value.ToString();
                    double planlananMiktar = Convert.ToDouble(dataGridView3.Rows[e.RowIndex].Cells["Miktar"].Value);
                    string uretimdengirisyap = "";

                    if (stageid == maxStageId.ToString())
                    {
                        uretimdengirisyap = "Y";
                    }

                    #region Sarf etme ekranı gelmemesi lazım sarf etme işlemi yalnızca sarf etme ekranında olacak dendi.
                    //#region NE OLURSA OLSUN TAMAMLARKEN SARF EKRANINA GıTMESı ıÇıN KOYULDU
                    //string val = _type;
                    //double partiKatSayi = Convert.ToDouble(dataGridView3.Rows[e.RowIndex].Cells["KatSayi"].Value);
                    //string urunGrubu = dataGridView3.Rows[e.RowIndex].Cells["Ürün Grubu"].Value.ToString();
                    //string urunTanimi = dataGridView3.Rows[e.RowIndex].Cells["Ürün Tanımı"].Value.ToString();
                    //var aktifCell = dataGridView1.CurrentCell;
                    //if (uretimFisNo != "")
                    //{
                    //    UretimSarfiyat_2 n2 = new UretimSarfiyat_2(stageid, uretimFisNo, val, kullanciid, partiKatSayi, partiNo, rota, urunGrubu, urunTanimi, aktifCell.RowIndex, initialWidth, initialHeight, tarih1, 0, urunKodu);
                    //    //UretimSarfiyat n = new UretimSarfiyat(stageid, DocNum, val, kullanciid, partiKatSayi, PartiNo, RotaKodu, urunGrubu, urunTanimi, dataGridView1.CurrentCell.RowIndex);
                    //    n2.ShowDialog();
                    //    //Close();
                    //}
                    //#endregion

                    ////if (!sarfagoturuldu)
                    ////{

                    //if (UretimSarfiyat_2.aktiviteEkraninaGit == "Ok")
                    //{
                    //    AktiviteIslemleri_2 n = new AktiviteIslemleri_2(_type, kullanciid, rota, stageid, uretimFisNo, "4", partiNo, urunKodu, uretimdengirisyap, aktifCell.RowIndex, planlananMiktar, initialWidth, initialHeight, tarih1, varsayilanDepo);
                    //    //AkviteIslemleri n = new AkviteIslemleri(_type, kullanciid, rota, stageid, uretimFisNo, "4", partiNo, urunKodu, uretimdengirisyap, Width, Height, dataGridView1.CurrentCell.RowIndex);
                    //    n.ShowDialog();
                    //    Close();
                    //}
                    ////UretimSarfiyat_2.aktiviteEkraninaGit = "";
                    ////} 
                    #endregion

                    AktiviteIslemleri_2 n = new AktiviteIslemleri_2(_type, kullanciid, rota, stageid, uretimFisNo, "4", partiNo, urunKodu, uretimdengirisyap, dataGridView1.CurrentCell.RowIndex, planlananMiktar, initialWidth, initialHeight, tarih1, varsayilanDepo, siparisTarihi, _txtParam: txtAktiviteDurum);
                    //AkviteIslemleri n = new AkviteIslemleri(_type, kullanciid, rota, stageid, uretimFisNo, "4", partiNo, urunKodu, uretimdengirisyap, Width, Height, dataGridView1.CurrentCell.RowIndex);
                    n.ShowDialog();
                    Close();
                }

            }
        }

        private bool butonAktif(string partiNo, string rota)
        {
            //var edit = satirDurumlaris.Where(x => x.PartiNo == partiNo && x.rotaKodu == rota).FirstOrDefault();
            var edit = satirDurumlaris.Where(x => x.PartiNo == partiNo).FirstOrDefault();

            return edit.aktif;
        }

        private bool butonAktif_SatirKarsilastirma(int row)
        {
            var edit = satirDurumlaris.Where(x => x.Row < row && x.Durum == "1").ToList();

            if (edit.Count > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private int maxStageId = 0;
        private string urunKodu = "";
        private string urunTanimi = "";
        private int PartiNoKolonWidth = 0;

        //type = 1 --> Tümünü Listele
        private void Listele(int row, string type)
        {

            //Stopwatch watch = new Stopwatch();     //  Ölçmek istediğimiz işlemin başlangıcına ekliyoruz.

            //watch.Start(); //  Ölçmek istediğimiz işlemin başlangıcına ekliyoruz.

            //  Bu kısımda işlem olacak

            dataGridView1.CurrentCell = dataGridView1.Rows[row].Cells[0];
            tarih = dataGridView1.Rows[row].Cells["Tarih"].Value.ToString();
            var docentry = "";

            if (Giris.UretimPartilendirmeSekli == "1")
            {
                docentry = dataGridView1.Rows[row].Cells["Üretim Fiş No"].Value.ToString();
            }
            urunKodu = dataGridView1.Rows[row].Cells["Ürün Kodu"].Value.ToString();
            urunTanimi = dataGridView1.Rows[row].Cells["Ürün Tanımı"].Value.ToString();

            string sql = "";
            #region temizlik durumuna göre listeleme

            DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
            //dtTarih = dtTarih.AddDays(-1); //old 20230724
            string tarihhh = dtTarih.ToString("yyyyMMdd");
            //sql = "Select \"U_YoneticiOnay\" from \"@AIF_TEMIZLIK\" WITH (NOLOCK) where Convert(varchar,\"U_Tarih\",112) = '" + tarihhh + "' and \"U_IstasyonKodu\"='" + _type + "'"; //old 20230724

            sql = "select MAX(Convert(varchar,T0.\"StartDate\",112)) as  'StartDate' from OWOR T0 where Convert(varchar,T0.\"StartDate\",112) < '" + tarihhh + "' and T0.\"U_ISTASYON\"='" + _type + "' ";
            //sql = "Select \"U_YoneticiOnay\" from \"@AIF_TEMIZLIK\" WITH (NOLOCK) where Convert(varchar,\"U_Tarih\",112) = '20230721' and \"U_IstasyonKodu\"='" + _type + "'"; //hız test
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dtTemizlik = new DataTable();
            try
            {
                sda.Fill(dtTemizlik);

                if (dtTemizlik != null && dtTemizlik.Rows.Count > 0)
                {
                    string sonuretimtarihi = dtTemizlik.Rows[0]["StartDate"].ToString();

                    dtTarih = new DateTime(Convert.ToInt32(sonuretimtarihi.Substring(0, 4)), Convert.ToInt32(sonuretimtarihi.Substring(4, 2)), Convert.ToInt32(sonuretimtarihi.Substring(6, 2)));

                    sql = "Select \"U_YoneticiOnay\" from \"@AIF_TEMIZLIK\" WITH (NOLOCK) where Convert(varchar,\"U_Tarih\",112) = '" + sonuretimtarihi + "' and \"U_IstasyonKodu\"='" + _type + "'";

                    cmd = new SqlCommand(sql, Connection.sql);

                    if (Connection.sql.State != ConnectionState.Open)
                        Connection.sql.Open();

                    sda = new SqlDataAdapter(cmd);
                    dtTemizlik = new DataTable();
                    sda.Fill(dtTemizlik);
                    if (dtTemizlik != null)
                    {
                        //string trh = dtTarih.ToShortDateString(); //old 20230724

                        if (dtTemizlik.Rows.Count > 0)
                        {
                            string temizlikDurumu = dtTemizlik.Rows[0]["U_YoneticiOnay"].ToString();
                            if (temizlikDurumu != "E")
                            {
                                if (istasyonAdi == "")
                                {
                                    CustomMsgBtn.Show(_type + " BÖLÜMÜNDE ÜRETİME DEVAM EDEBİLMEK İÇİN YÖNETİCİ TARAFINDAN " + dtTarih.ToShortDateString() + " TARİHLİ TEMİZLİK ONAYI YAPILMALIDIR.", "UYARI", "TAMAM");
                                }
                                else
                                {
                                    CustomMsgBtn.Show(istasyonAdi + " BÖLÜMÜNDE ÜRETİME DEVAM EDEBİLMEK İÇİN YÖNETİCİ TARAFINDAN " + dtTarih.ToShortDateString() + " TARİHLİ TEMİZLİK ONAYI YAPILMALIDIR.", "UYARI", "TAMAM");
                                }

                                return;
                            }
                        }
                        else
                        {
                            CustomMsgBtn.Show(istasyonAdi + " BÖLÜMÜNDE ÜRETİME DEVAM EDEBİLMEK İÇİN YÖNETİCİ TARAFINDAN " + dtTarih.ToShortDateString() + " TARİHLİ TEMİZLİK ONAYI YAPILMALIDIR.", "UYARI", "TAMAM");
                            return;

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show(ex.Message, "UYARI", "TAMAM");
                return;
            }

            Connection.sql.Close();
            Connection.sql.Dispose();
            if (Connection.sql.State == ConnectionState.Open)
            {
                cmd.ExecuteNonQuery();
            }
            #endregion

            if (Giris.UretimPartilendirmeSekli == "1")
            {
                sql = " Select T1.\"U_PartiNo\",\"U_Miktar\",\"U_PartiKatSayi\" from  \"@AIF_URT_PART\" as T0 WITH (NOLOCK) INNER JOIN \"@AIF_URT_PART1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_UretimSipNo\" = '" + docentry + "' order by \"LineId\"";
            }
            //else if (Giris.UretimPartilendirmeSekli == "2")
            //{
            //    sql = "SELECT T1.\"U_PartiNo\",\"U_Miktar\",\"U_PartiKatSayi\",\"U_UretimSipNo\" FROM \"@AIF_URT_PART\" AS T0 INNER JOIN \"@AIF_URT_PART1\" AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" LEFT JOIN OWOR as T2 on T0.U_UretimSipNo = t2.DocEntry WHERE T2.U_GrupSipNo = '" + docentry + "' ORDER BY \"LineId\" ";
            //}

            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            if (Giris.UretimPartilendirmeSekli == "1")
            {
                sda.Fill(dt);

                #region sql connection chn 
                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
                #endregion
            }

            if (Giris.UretimPartilendirmeSekli == "1")
            {
                sql = "SELECT DISTINCT (select T1.Descr from CUFD as T0 WITH (NOLOCK) INNER JOIN UFD1 as T1 WITH (NOLOCK) ON T0.FieldID = T1.FieldID where T0.TableID = 'OWOR' and T1.TableID = 'OWOR' and T1.FldValue = T3.[U_Istasyon]) as  [Ürün Grubu], T4.Name as Rota, T3.DocEntry as [Üretim Fiş No],' ' as [Parti No],' ' as KatSayi, T3.ItemCode as [Ürün Kodu],T3.ProdName as [Ürün Tanımı],T3.PlannedQty as [Miktar],T3.PlannedQty as [GerceklesenMiktar], '' as Durum,'' as DurumKodu, T3.[U_Istasyon] as Istasyon,T4.SeqNum as StageID, (Select \"Code\" from ORST WITH (NOLOCK) where AbsEntry = T4.StgEntry) as RotaKodu,T6.\"U_UVTVarsayilanDepo\",convert(varchar, T3.\"PostDate\", 104) as \"PostDate\" FROM OWOR as T3 WITH (NOLOCK) INNER JOIN WOR1 as T5 WITH (NOLOCK) ON T3.DocEntry = T5.DocEntry INNER JOIN WOR4 as T4 WITH (NOLOCK) ON T5.DocEntry = T4.DocEntry and T5.StageId = T4.StageId INNER JOIN OITM as T6 WITH (NOLOCK) ON T6.ItemCode = T3.ItemCode WHERE T5.DocEntry = '" + docentry + "'";
            }
            else if (Giris.UretimPartilendirmeSekli == "2")
            {
                #region ÜRETıM SıPARışı GRUPLANDIRILMIş PARTı 
                if (Giris.mKodValue == "010OTATURVT")
                {
                    sql = "exec BanaAitIsleriGetir_20 '" + urunKodu + "', '" + _type + "','" + tarih1 + "'";
                    //sql = "SELECT DISTINCT (select T1.Descr from CUFD as T0 WITH (NOLOCK) INNER JOIN UFD1 as T1 WITH (NOLOCK) ON T0.FieldID = T1.FieldID where T0.TableID = 'OWOR' and T1.TableID = 'OWOR' and T1.FldValue = T3.[U_Istasyon]) as  [Ürün Grubu], T4.Name as Rota, T3.DocEntry as [Üretim Fiş No],T3.\"U_GrupPartiNo\" as [Parti No],' ' as KatSayi, T3.ItemCode as [Ürün Kodu],T3.ProdName as [Ürün Tanımı],T3.PlannedQty as [Miktar],T3.PlannedQty as [GerceklesenMiktar],T3.PlannedQty AS[PlanSarfMik],T3.PlannedQty AS[GercekSarfMik], '' as Durum,'' as DurumKodu, T3.[U_Istasyon] as Istasyon,T4.SeqNum as StageID, (Select \"Code\" from ORST WITH (NOLOCK) where AbsEntry = T4.StgEntry) as RotaKodu,T6.\"U_UVTVarsayilanDepo\" FROM OWOR as T3 WITH (NOLOCK) INNER JOIN WOR1 as T5 WITH (NOLOCK) ON T3.DocEntry = T5.DocEntry INNER JOIN WOR4 T4 WITH (NOLOCK) ON T5.DocEntry = T4.DocEntry and T5.StageId = T4.StageId INNER JOIN OITM as T6 WITH (NOLOCK) ON T6.ItemCode = T3.ItemCode WHERE  T3.StartDate = '" + tarih1 + "' and T3.U_ISTASYON = '" + _type + "' AND T3.ItemCode = '" + urunKodu + "' AND T3.\"Status\" != 'C'";
                }
                #endregion

                #region üretim sparişi tek parti oldugu sorgu.parti gruplandırma öncesi
                if (Giris.mKodValue == "20URVT")
                {
                    sql = "SELECT DISTINCT (select T1.Descr from CUFD as T0 WITH (NOLOCK) INNER JOIN UFD1 as T1 WITH (NOLOCK) ON T0.FieldID = T1.FieldID where T0.TableID = 'OWOR' and T1.TableID = 'OWOR' and T1.FldValue = T3.[U_Istasyon]) as  [Ürün Grubu], T4.Name as Rota, T3.DocEntry as [Üretim Fiş No],' ' as [Parti No],' ' as KatSayi, T3.ItemCode as [Ürün Kodu],T3.ProdName as [Ürün Tanımı],T3.PlannedQty as [Miktar],T3.PlannedQty as [GerceklesenMiktar], '' as Durum,'' as DurumKodu, T3.[U_Istasyon] as Istasyon,T4.SeqNum as StageID, (Select \"Code\" from ORST WITH (NOLOCK) where AbsEntry = T4.StgEntry) as RotaKodu,T6.\"U_UVTVarsayilanDepo\",convert(varchar, T3.\"PostDate\", 104) as \"PostDate\" FROM OWOR as T3 WITH (NOLOCK) INNER JOIN WOR1 as T5 WITH (NOLOCK) ON T3.DocEntry = T5.DocEntry INNER JOIN WOR4 T4 WITH (NOLOCK) ON T5.DocEntry = T4.DocEntry and T5.StageId = T4.StageId INNER JOIN OITM as T6 WITH (NOLOCK) ON T6.ItemCode = T3.ItemCode WHERE  T3.StartDate = '" + tarih1 + "' and T3.U_ISTASYON = '" + _type + "' AND T3.ItemCode = '" + urunKodu + "' AND T3.\"Status\" != 'C'";
                }
                #endregion 
            }

            cmd = new SqlCommand(sql, Connection.sql);

            sda = new SqlDataAdapter(cmd);
            DataTable dt2 = new DataTable();
            DataTable dt3 = new DataTable();
            dttemp = new DataTable();
            sda.Fill(dt2);

            #region sql connection chn 
            Connection.sql.Close();
            Connection.sql.Dispose();
            if (Connection.sql.State == ConnectionState.Open)
            {
                cmd.ExecuteNonQuery();
            }
            #endregion

            if (Giris.UretimPartilendirmeSekli == "1")
            {
                dttemp = dt2.Copy();
                dttemp.Rows.Clear();
                foreach (DataRow dr in dt2.Rows)
                {
                    foreach (DataRow dr2 in dt.Rows)
                    {
                        dr["Parti No"] = dr2["U_PartiNo"];
                        dr["Miktar"] = dr2["U_Miktar"];
                        dr["KatSayi"] = dr2["U_PartiKatSayi"];
                        dttemp.Rows.Add(dr.ItemArray);
                    }
                }
            }
            else if (Giris.UretimPartilendirmeSekli == "2")
            {
                //foreach (DataRow dr in dt2.Rows)
                //{
                //    //if (birSatirDonsun > 0)
                //    //{
                //    //    break;
                //    //}
                //    foreach (DataRow dr2 in dt.AsEnumerable().Where(x => x.Field<string>("U_UretimSipNo") == dr["Üretim Fiş No"].ToString()))
                //    {
                //        dr["Parti No"] = dr2["U_PartiNo"];
                //        dr["Miktar"] = dr2["U_Miktar"];
                //        dr["KatSayi"] = dr2["U_PartiKatSayi"];
                //        dttemp.Rows.Add(dr.ItemArray);

                //        //birSatirDonsun++;
                //    }
                //}

                //foreach (DataRow dr in dt2.Rows)
                //{
                //    dr["Parti No"] = dr2["U_PartiNo"];
                //    dr["Miktar"] = dr2["U_Miktar"];
                //    dr["KatSayi"] = dr2["U_PartiKatSayi"];
                //    dttemp.Rows.Add(dr.ItemArray);
                //}
            }

            sda = new SqlDataAdapter(cmd);
            string query2 = "";
            if (Giris.UretimPartilendirmeSekli == "1")
            {
                #region Bana ait işler prosedürü içerisinde yapıldı.
                //foreach (DataRow item in dttemp.Rows)
                //{
                //    dt3 = new DataTable();
                //    //query2 = "SELECT T0.\"Quantity\" FROM IBT1 T0 WHERE T0.[BaseType] = '59' and  T0.[BatchNum] = '" + item["Parti No"] + "' and T0.\"ItemCode\" = '" + urunKodu + "'";

                //    query2 = "select TOP 1 T1.Quantity from OIGN as T0 WITH (NOLOCK) INNER JOIN IGN1 AS T1 WITH (NOLOCK) ON T0.DocEntry=T1.DocEntry where U_BatchNumber = '" + item["Parti No"] + "' and T1.\"ItemCode\" = '" + urunKodu + "'";

                //    cmd = new SqlCommand(query2, Connection.sql);
                //    sda = new SqlDataAdapter(cmd);

                //    sda.Fill(dt3);

                //    #region sql connection chn 
                //    Connection.sql.Close();
                //    Connection.sql.Dispose();
                //    if (Connection.sql.State == ConnectionState.Open)
                //    {
                //        cmd.ExecuteNonQuery();
                //    }
                //    #endregion

                //    if (dt3.Rows.Count > 0)
                //    {
                //        item["GerceklesenMiktar"] = dt3.Rows[0][0].ToString();
                //    }
                //    else
                //    {
                //        item["GerceklesenMiktar"] = "0";

                //    } 
                //}
                #endregion
            }
            else if (Giris.UretimPartilendirmeSekli == "2")
            {
                foreach (DataRow item in dt2.Rows)
                {
                    #region Gerçekleşen Miktar Hesaplamaları
                    if (Giris.mKodValue == "20URVT")
                    {
                        item["Parti No"] = tarih1 + "-" + item["Üretim Fiş No"] + "-1"; //parti no hep sonu 1 olması için eklendi.gruplama partilendirmeden önce çalışıyordu 
                    }
                    if (Giris.mKodValue == "010OTATURVT")
                    {
                        item["Parti No"] = item["Parti No"].ToString();  //gruplandırılmış partileri getirir
                    }
                    item["KatSayi"] = "1";
                    dt3 = new DataTable();
                    //query2 = "SELECT T0.\"Quantity\" FROM IBT1 T0 WHERE T0.[BaseType] = '59' and  T0.[BatchNum] = '" + item["Parti No"] + "' and T0.\"ItemCode\" = '" + urunKodu + "'";

                    #region Bana ait işler getir prosedürü içerisinde yapılmaya başlandı.

                    //query2 = "select TOP 1 T1.Quantity from OIGN as T0 WITH (NOLOCK) INNER JOIN IGN1 AS T1 WITH (NOLOCK) ON T0.DocEntry=T1.DocEntry where U_BatchNumber = '" + item["Parti No"] + "' and T1.\"ItemCode\" = '" + urunKodu + "'";

                    //cmd = new SqlCommand(query2, Connection.sql);
                    //sda = new SqlDataAdapter(cmd);

                    //sda.Fill(dt3);

                    //#region sql connection chn 
                    //Connection.sql.Close();
                    //Connection.sql.Dispose();
                    //if (Connection.sql.State == ConnectionState.Open)
                    //{
                    //    cmd.ExecuteNonQuery();
                    //}
                    //#endregion

                    //if (dt3.Rows.Count > 0)
                    //{
                    //    item["GerceklesenMiktar"] = dt3.Rows[0][0].ToString();
                    //}
                    //else
                    //{
                    //    item["GerceklesenMiktar"] = "0";
                    //} 
                    #endregion

                    #endregion


                }

                #region Sarf Miktar Hesaplamaları

                if (Giris.mKodValue == "010OTATURVT")
                {
                    #region Bana ait işler prosedürü içerisinde yapılmaya başlandı.


                    //foreach (DataRow item in dt2.Rows)
                    //{
                    //    sql = "SELECT  SUM(tbl.\"PlanlananSarf\") as \"PlanlananSarf\",SUM(tbl.\"GerçekleşenSarf\") as \"Gerçekleşen Sarf\",(SUM(tbl.\"PlanlananSarf\") - SUM(tbl.\"GerçekleşenSarf\")) AS Fark FROM (SELECT ItemCode AS[Ürün Kodu], (SELECT ItemName FROM OITM AS T1 WITH (NOLOCK) WHERE T1.ItemCode = T0.ItemCode) AS[Ürün Tanımı], ROUND((T0.PlannedQty / 1), 6) AS[PlanlananSarf], CASE WHEN ROUND((T0.PlannedQty / 1), 6) > 0 THEN ISNULL((SELECT SUM(T3.\"Quantity\") FROM OIGE AS T2 WITH (NOLOCK) INNER JOIN IGE1 AS T3 WITH (NOLOCK) ON T2.\"DocEntry\" = T3.\"DocEntry\" WHERE T2.\"U_BatchNumber\" = '" + item["Parti No"] + "' AND T3.\"ItemCode\" = T0.\"ItemCode\" GROUP BY T3.\"ItemCode\"),0) ELSE ISNULL((SELECT SUM(T3.\"Quantity\") *-1 FROM OIGN AS T2 WITH (NOLOCK) INNER JOIN IGN1 AS T3 WITH (NOLOCK) ON T2.\"DocEntry\" = T3.\"DocEntry\" WHERE T2.\"U_BatchNumber\" = '" + item["Parti No"] + "' AND T3.\"ItemCode\" = T0.\"ItemCode\" GROUP BY T3.\"ItemCode\"),0) END AS [GerçekleşenSarf], T0.\"DocEntry\" FROM WOR1 AS T0 WITH (NOLOCK) WHERE T0.DocEntry = '" + item["Üretim Fiş No"] + "' AND ISNULL(T0.U_SarfaDahilEt,'') = 'E') AS tbl GROUP BY tbl.\"DocEntry\"";


                    //    dt = new DataTable();


                    //    cmd = new SqlCommand(sql, Connection.sql);
                    //    sda = new SqlDataAdapter(cmd);

                    //    sda.Fill(dt);

                    //    #region sql connection chn 
                    //    //Connection.sql.Close();
                    //    //Connection.sql.Dispose();
                    //    //if (Connection.sql.State == ConnectionState.Open)
                    //    //{
                    //    //    cmd.ExecuteNonQuery();
                    //    //}
                    //    #endregion

                    //    item["PlanSarfMik"] = 0;
                    //    item["GercekSarfMik"] = 0;
                    //    if (dt.Rows.Count > 0)
                    //    {
                    //        if (dt.Rows[0]["PlanlananSarf"] != DBNull.Value)
                    //        {
                    //            item["PlanSarfMik"] = Convert.ToDouble(dt.Rows[0]["PlanlananSarf"]);

                    //        }

                    //        if (dt.Rows[0]["Gerçekleşen Sarf"] != DBNull.Value)
                    //        {
                    //            item["GercekSarfMik"] = Convert.ToDouble(dt.Rows[0]["Gerçekleşen Sarf"]);
                    //        }
                    //    }

                    //} 
                    #endregion
                }



                #endregion
                dttemp = dt2.Copy();
            }
            DataTable newDataTable = dttemp.Copy();
            //newDataTable.Rows.Clear();

            //if (dttemp.Rows.Count > 0)
            //{
            //    //DataView dv = new DataView(dttemp);
            //    //dv.Sort = "Parti No, StageId ASC";
            //    //dttemp = dt.DefaultView.ToTable();

            //    newDataTable = dttemp.AsEnumerable()
            //           .OrderBy(r => r.Field<string>("Parti No"))
            //           .ThenBy(r => r.Field<int>("StageId"))
            //           .CopyToDataTable();
            //}
            satirDurumlaris = new List<SatirDurumlari>();
            int ix = 0;

            foreach (DataRow itm in newDataTable.Rows)
            {
                if (itm["DurumKodu"].ToString() == "3")
                    satirDurumlaris.Add(new SatirDurumlari { PartiNo = itm["Parti No"].ToString(), Row = ix, Durum = itm["DurumKodu"].ToString(), aktif = false, rotaKodu = itm["RotaKodu"].ToString(), rotaAdi = itm["Rota"].ToString() });
                else
                    satirDurumlaris.Add(new SatirDurumlari { PartiNo = itm["Parti No"].ToString(), Row = ix, Durum = itm["DurumKodu"].ToString(), aktif = true, rotaKodu = itm["RotaKodu"].ToString(), rotaAdi = itm["Rota"].ToString() });

                if (filterelemeDurumlaris.Where(x => x.Tip == "3").First().Durum == "1"
                    && itm["DurumKodu"].ToString() == "3")
                {
                    satirDurumlaris[satirDurumlaris.Count - 1].SatiriSil = "Y";
                }
                else if (filterelemeDurumlaris.Where(x => x.Tip == "2").First().Durum == "1"
                    && itm["DurumKodu"].ToString() == "2")
                {
                    satirDurumlaris[satirDurumlaris.Count - 1].SatiriSil = "Y";
                }
                else if (filterelemeDurumlaris.Where(x => x.Tip == "1").First().Durum == "1"
                    && itm["DurumKodu"].ToString() == "1")
                {
                    satirDurumlaris[satirDurumlaris.Count - 1].SatiriSil = "Y";
                }



            }

            #region Bana Ait İşler Prosedürü içerisinde çözüldü
            //foreach (DataRow itm in newDataTable.Rows)
            //{
            //    string partiNo = itm["Parti No"].ToString();
            //    string uretimFisNo = itm["Üretim Fiş No"].ToString();
            //    string rotaKodu = itm["RotaKodu"].ToString();
            //    string rotaAdiDg = itm["Rota"].ToString();

            //    #region ÜRETıM GıRış-ÇIKIş YAPILMADAN ÜRETıM SıPARışı TAMAMLANDI YAPILDI ıSE SATIR DURUMU TAMAMLANDI OLARAK ALINIR
            //    dt = new DataTable();
            //    sql = "SELECT * FROM OWOR AS T88 WITH (NOLOCK) WHERE T88.\"DocEntry\" = '" + uretimFisNo + "' AND T88.\"Status\" = 'L' AND ISNULL(T88.\"CmpltQty\",0) = 0 ";
            //    cmd = new SqlCommand(sql, Connection.sql);

            //    sda = new SqlDataAdapter(cmd);
            //    sda.Fill(dt);

            //    #region sql connection chn 
            //    Connection.sql.Close();
            //    Connection.sql.Dispose();
            //    if (Connection.sql.State == ConnectionState.Open)
            //    {
            //        cmd.ExecuteNonQuery();
            //    }
            //    #endregion

            //    if (dt.Rows.Count > 0)
            //    {
            //        dt = new DataTable();
            //        sql = "Select \"U_DurunAciklama\",\"U_DurumKodu\" from \"@AIF_ROTA_DURUM\" WITH (NOLOCK) where \"U_UretimFisNo\" = '" + uretimFisNo + "' and \"U_RotaKodu\" = '" + rotaKodu + "' and \"U_PartiNo\" = '" + partiNo + "'";

            //        cmd = new SqlCommand(sql, Connection.sql);

            //        sda = new SqlDataAdapter(cmd);
            //        sda.Fill(dt);

            //        #region sql connection chn 
            //        Connection.sql.Close();
            //        Connection.sql.Dispose();
            //        if (Connection.sql.State == ConnectionState.Open)
            //        {
            //            cmd.ExecuteNonQuery();
            //        }
            //        #endregion

            //        if (dt.Rows.Count > 0)
            //        {
            //            dt.Rows[0][0] = "Tamamlandı";
            //            dt.Rows[0][1] = "3";
            //            itm["Durum"] = dt.Rows[0][0].ToString();
            //            itm["DurumKodu"] = dt.Rows[0][1].ToString();
            //            if (dt.Rows[0][1].ToString() == "3")
            //                satirDurumlaris.Add(new SatirDurumlari { PartiNo = partiNo, Row = ix, Durum = dt.Rows[0][1].ToString(), aktif = false, rotaKodu = rotaKodu, rotaAdi = rotaAdiDg });
            //            else
            //                satirDurumlaris.Add(new SatirDurumlari { PartiNo = partiNo, Row = ix, Durum = dt.Rows[0][1].ToString(), aktif = true, rotaKodu = rotaKodu, rotaAdi = rotaAdiDg });

            //            if (filterelemeDurumlaris.Where(x => x.Tip == "3").First().Durum == "1"
            //                && dt.Rows[0][1].ToString() == "3")
            //            {
            //                satirDurumlaris[satirDurumlaris.Count - 1].SatiriSil = "Y";
            //            }
            //            else if (filterelemeDurumlaris.Where(x => x.Tip == "2").First().Durum == "1"
            //                && dt.Rows[0][1].ToString() == "2")
            //            {
            //                satirDurumlaris[satirDurumlaris.Count - 1].SatiriSil = "Y";
            //            }

            //            ix++;
            //        }
            //        else
            //        {
            //            itm["Durum"] = "Başlanmadı";
            //            itm["DurumKodu"] = "1";
            //            if (satirDurumlaris.Where(x => x.PartiNo == partiNo && x.Durum != "3").Count() > 0)
            //                satirDurumlaris.Add(new SatirDurumlari { PartiNo = partiNo, Row = ix, Durum = "1", aktif = false, rotaKodu = rotaKodu, rotaAdi = rotaAdiDg });
            //            else
            //                satirDurumlaris.Add(new SatirDurumlari { PartiNo = partiNo, Row = ix, Durum = "1", aktif = true, rotaKodu = rotaKodu, rotaAdi = rotaAdiDg });

            //            if (filterelemeDurumlaris.Where(x => x.Tip == "1").First().Durum == "1")
            //            {
            //                satirDurumlaris[satirDurumlaris.Count - 1].SatiriSil = "Y";
            //            }

            //            ix++;
            //        }
            //    }
            //    else
            //    {
            //        #region ÜRETıM GıRış-ÇIKIş YAPILMADAN ÜRETıM SıPARışı BU şEKıLDE LıSTELENıYORDU.YUKARIDA ÖNCELıK GETıRıLDı.O şARTA UYMADIÐINDA NORMAL ışLEMLER DEVAM EDECEK
            //        dt = new DataTable();
            //        sql = "Select \"U_DurunAciklama\",\"U_DurumKodu\" from \"@AIF_ROTA_DURUM\" WITH (NOLOCK) where \"U_UretimFisNo\" = '" + uretimFisNo + "' and \"U_RotaKodu\" = '" + rotaKodu + "' and \"U_PartiNo\" = '" + partiNo + "'";

            //        cmd = new SqlCommand(sql, Connection.sql);

            //        sda = new SqlDataAdapter(cmd);
            //        sda.Fill(dt);

            //        #region sql connection chn 
            //        Connection.sql.Close();
            //        Connection.sql.Dispose();
            //        if (Connection.sql.State == ConnectionState.Open)
            //        {
            //            cmd.ExecuteNonQuery();
            //        }
            //        #endregion

            //        if (dt.Rows.Count > 0)
            //        {
            //            itm["Durum"] = dt.Rows[0][0].ToString();
            //            itm["DurumKodu"] = dt.Rows[0][1].ToString();
            //            if (dt.Rows[0][1].ToString() == "3")
            //                satirDurumlaris.Add(new SatirDurumlari { PartiNo = partiNo, Row = ix, Durum = dt.Rows[0][1].ToString(), aktif = false, rotaKodu = rotaKodu, rotaAdi = rotaAdiDg });
            //            else
            //                satirDurumlaris.Add(new SatirDurumlari { PartiNo = partiNo, Row = ix, Durum = dt.Rows[0][1].ToString(), aktif = true, rotaKodu = rotaKodu, rotaAdi = rotaAdiDg });

            //            if (filterelemeDurumlaris.Where(x => x.Tip == "3").First().Durum == "1"
            //                && dt.Rows[0][1].ToString() == "3")
            //            {
            //                satirDurumlaris[satirDurumlaris.Count - 1].SatiriSil = "Y";
            //            }
            //            else if (filterelemeDurumlaris.Where(x => x.Tip == "2").First().Durum == "1"
            //                && dt.Rows[0][1].ToString() == "2")
            //            {
            //                satirDurumlaris[satirDurumlaris.Count - 1].SatiriSil = "Y";
            //            }

            //            ix++;
            //        }
            //        else
            //        {
            //            itm["Durum"] = "Başlanmadı";
            //            itm["DurumKodu"] = "1";
            //            if (satirDurumlaris.Where(x => x.PartiNo == partiNo && x.Durum != "3").Count() > 0)
            //                satirDurumlaris.Add(new SatirDurumlari { PartiNo = partiNo, Row = ix, Durum = "1", aktif = false, rotaKodu = rotaKodu, rotaAdi = rotaAdiDg });
            //            else
            //                satirDurumlaris.Add(new SatirDurumlari { PartiNo = partiNo, Row = ix, Durum = "1", aktif = true, rotaKodu = rotaKodu, rotaAdi = rotaAdiDg });

            //            if (filterelemeDurumlaris.Where(x => x.Tip == "1").First().Durum == "1")
            //            {
            //                satirDurumlaris[satirDurumlaris.Count - 1].SatiriSil = "Y";
            //            }

            //            ix++;
            //        }
            //        #endregion
            //    }
            //    #endregion

            //} 
            #endregion


            dataGridView1.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            bool sirala = false;
            if (filterelemeDurumlaris.Where(x => x.Tip == "3").First().Durum == "1")
            {
                var query = newDataTable.AsEnumerable().Where(r => r.Field<string>("DurumKodu") == "3");

                foreach (var row1 in query.ToList())
                    row1.Delete();

                newDataTable.AcceptChanges();

                satirDurumlaris.RemoveAll(x => x.SatiriSil == "Y" && x.Durum == "3");
            }

            if (filterelemeDurumlaris.Where(x => x.Tip == "2").First().Durum == "1")
            {
                var query = newDataTable.AsEnumerable().Where(r => r.Field<string>("DurumKodu") == "2");

                foreach (var row1 in query.ToList())
                    row1.Delete();

                newDataTable.AcceptChanges();

                //satirDurumlaris.RemoveAll(x => x.SatiriSil == "Y" && x.Durum == "2");
            }

            if (filterelemeDurumlaris.Where(x => x.Tip == "1").First().Durum == "1")
            {
                var query = newDataTable.AsEnumerable().Where(r => r.Field<string>("DurumKodu") == "1");

                foreach (var row1 in query.ToList())
                    row1.Delete();

                newDataTable.AcceptChanges();

                satirDurumlaris.RemoveAll(x => x.SatiriSil == "Y" && x.Durum == "1");
            }

            if (!sirala)
            {
                int z = 0;

                foreach (var item in satirDurumlaris.Where(x => x.SatiriSil != "Y"))
                {
                    item.Row = z;
                    z++;
                }
            }

            dataGridView3.DataSource = newDataTable;

            dataGridView3.Columns["Ürün Kodu"].Visible = false;
            dataGridView3.Columns["Istasyon"].Visible = false;
            dataGridView3.Columns["StageID"].Visible = false;
            dataGridView3.Columns["KatSayi"].Visible = false;
            dataGridView3.Columns["RotaKodu"].Visible = false;
            dataGridView3.Columns["DurumKodu"].Visible = false;
            dataGridView3.Columns["U_UVTVarsayilanDepo"].Visible = false;
            dataGridView3.Columns["Ürün Grubu"].Visible = false;
            dataGridView3.Columns["PostDate"].Visible = false;
            try
            {
                dataGridView3.Columns["DuraklamaSebebi"].Visible = false;
            }
            catch (Exception)
            {
            }

            if (dataGridView3.Columns.Contains("btnBaslat") != true)
            {
                addButton(dataGridView3);
            }

            dataGridView3.AutoResizeRows();
            for (int i = 0; i <= dataGridView3.Columns.Count - 1; i++)
            {
                dataGridView3.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            dataGridView3.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
            dataGridView3.AutoResizeRows();
            //foreach (DataGridViewColumn col in dataGridView3.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Bahnschrift", 11F, FontStyle.Bold, GraphicsUnit.Pixel);
            //}

            //dataGridView3.Columns["Parti No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;

            dataGridView3.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dataGridView3.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridView3.Columns["GerceklesenMiktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dataGridView3.Columns["GerceklesenMiktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            if (Giris.mKodValue == "010OTATURVT")
            {
                dataGridView3.Columns["PlanSarfMik"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dataGridView3.Columns["PlanSarfMik"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView3.Columns["GercekSarfMik"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                dataGridView3.Columns["GercekSarfMik"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGridView3.Columns["KatSayi"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dataGridView3.Columns["KatSayi"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
            setFormatGrid(dataGridView3, 35);

            if (newDataTable.Rows.Count > 0)
            {
                List<int> stageids = newDataTable.AsEnumerable().Select(al => al.Field<int>("StageId")).Distinct().ToList();
                int max = stageids.Max();
                maxStageId = max;

                foreach (var item in satirDurumlaris.Where(x => x.SatiriSil != "Y"))
                {
                    if (item.Durum == "2")
                    {
                        dataGridView3.Rows[item.Row].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                        dataGridView3.Rows[item.Row].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (item.Durum == "1")
                    {
                        dataGridView3.Rows[item.Row].DefaultCellStyle.BackColor = Color.IndianRed;
                    }
                    else if (item.Durum == "3")
                    {
                        dataGridView3.Rows[item.Row].DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                    }
                }

                // vScrollBar1.Maximum = dataGridView3.Rows.Count + 1;
                vScrollBar1.Maximum = dataGridView3.RowCount + 5;

                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    var BtnCell = (DataGridViewButtonCell)dataGridView3.Rows[i].Cells["btnTamamla"];
                    BtnCell.Value = "Tamamla";
                    if (dataGridView3.Rows[i].Height < 60)
                    {
                        dataGridView3.Rows[i].Height = 60;
                    }
                }

                var aaa11 = satirDurumlaris.GroupBy(c => new
                {
                    c.PartiNo,
                    c.Durum
                });

                foreach (var item in aaa11)
                {
                    for (int i = 0; i < dataGridView3.Rows.Count; i++)
                    {
                        string parti = dataGridView3.Rows[i].Cells["Parti No"].Value.ToString();

                        if (aaa11.Where(x => x.Key.PartiNo == parti).Count() == 1 && aaa11.Where(x => x.Key.PartiNo == parti).First().Key.Durum == "3")
                        {
                            var BtnCell = (DataGridViewButtonCell)dataGridView3.Rows[i].Cells["btnTamamla"];
                            BtnCell.Value = "Barkod";
                        }
                    }
                }
            }

            if (PartiNoKolonWidth == 0)
            {
                PartiNoKolonWidth = dataGridView3.Columns["Parti No"].Width;
            }

            //dataGridView3.Columns["Parti No"].Width = PartiNoKolonWidth + 20;
            dataGridView3.Columns["Miktar"].HeaderText = "Plan Mik";
            dataGridView3.Columns["GerceklesenMiktar"].HeaderText = "Gerçek Mik";
            if (Giris.mKodValue == "010OTATURVT")
            {
                dataGridView3.Columns["PlanSarfMik"].HeaderText = "Plan. Sarf";
                dataGridView3.Columns["GercekSarfMik"].HeaderText = "Gerçek. Sarf";
            }
            dataGridView3.Columns["Parti No"].AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            //dataGridView3.Columns["Üretim Fiş No"].Visible = false;


            #region üretim siparişi duraklama durumu

            try
            {
                string duraklamaSebep = "";
                for (int i = 0; i < dataGridView3.Rows.Count; i++)
                {
                    duraklamaSebep = dataGridView3.Rows[i].Cells["DuraklamaSebebi"].Value == null ? "" : dataGridView3.Rows[i].Cells["DuraklamaSebebi"].Value.ToString();

                    if (duraklamaSebep != "")
                    {
                        dataGridView3.EnableHeadersVisualStyles = false;
                        var BtnCell = (DataGridViewButtonCell)dataGridView3.Rows[i].Cells["btnDuraklat"];
                        BtnCell.Style.BackColor = Color.Red;
                        dataGridView3.Rows[i].Cells["Durum"].Style.BackColor = Color.Red;
                    }
                }
                #region Bana ait işler prosedürüne kolon getirildi sorgu atmak yerine o kolon kontrol ediliyor.
                //for (int i = 0; i < dataGridView3.Rows.Count; i++)
                //{
                //    docentry = dataGridView3.Rows[i].Cells["Üretim Fiş No"].Value.ToString();

                //    if (docentry != "")
                //    {
                //        sql = "SELECT T88.\"U_DuraklamaSebep\" FROM OWOR T88 WITH (NOLOCK) WHERE T88.\"DocEntry\" = '" + docentry + "'";

                //        SqlDataAdapter sqlData = new SqlDataAdapter();
                //        DataTable dtDurum = new DataTable();
                //        cmd = new SqlCommand(sql, Connection.sql);
                //        sqlData = new SqlDataAdapter(cmd);

                //        sqlData.Fill(dtDurum);

                //        #region sql connection chn 
                //        Connection.sql.Close();
                //        Connection.sql.Dispose();
                //        if (Connection.sql.State == ConnectionState.Open)
                //        {
                //            cmd.ExecuteNonQuery();
                //        }
                //        #endregion

                //        if (dtDurum != null)
                //        {
                //            if (dtDurum.Rows.Count > 0)
                //            {
                //                string durum = dtDurum.Rows[0]["U_DuraklamaSebep"].ToString();

                //                if (durum != "")
                //                {
                //                    dataGridView3.EnableHeadersVisualStyles = false;
                //                    var BtnCell = (DataGridViewButtonCell)dataGridView3.Rows[i].Cells["btnDuraklat"];
                //                    BtnCell.Style.BackColor = Color.Red;
                //                    dataGridView3.Rows[i].Cells["Durum"].Style.BackColor = Color.Red;
                //                }
                //            }
                //        }

                //    }
                //} 
                #endregion
            }
            catch (Exception ex)
            {
            }
            #endregion



            //watch.Stop();  //  Ölçmek istediğimiz işlemin sonuna ekliyoruz.  

            //MessageBox.Show("İşlem Süresi " + watch.Elapsed.Seconds + " saniye");

            vScrollBar1.Maximum = dataGridView3.RowCount + 5;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (_type == "")
                {
                    _type = dataGridView1.Rows[e.RowIndex].Cells["Istasyon"].Value.ToString();
                }

                if (dataGridView1.Rows.Count > 0)
                {
                    SatirRenkle(dataGridView1.CurrentCell.RowIndex, dataGridView1);
                }
                Listele(e.RowIndex, "1");
            }
            catch (Exception ex)
            {
            }
        }

        private void SatirRenkle(int index, DataGridView dtg)
        {
            try
            {

                for (int i = 0; i < dtg.Rows.Count; i++)
                {
                    if (Giris.mKodValue == "010OTATURVT")
                    {
                        if (i == index)
                        {

                            dtg.Rows[i].DefaultCellStyle.BackColor = Color.GhostWhite;
                            dtg.Rows[i].DefaultCellStyle.SelectionForeColor = Color.Black;
                            dtg.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                            continue;
                        }

                        int kod = Convert.ToInt32(dataGridView1.Rows[i].Cells["ItmsGrpCod"].Value);

                        if (kod == 106) //MAMÜL
                        {
                            dtg.Rows[i].DefaultCellStyle.BackColor = Color.Bisque;
                        }
                        else if (kod == 105) //YRM
                        {
                            dtg.Rows[i].DefaultCellStyle.BackColor = Color.MediumAquamarine;
                        }
                        else if (kod == 107) //ENDÜSTRYEL
                        {
                            dtg.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                        }
                    }

                    if (Giris.mKodValue == "20URVT")
                    {

                        if (i == index)
                        {
                            dtg.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                            dtg.Rows[i].DefaultCellStyle.BackColor = Color.LightGoldenrodYellow;
                            continue;
                        }

                        if (i % 2 == 0)
                            dtg.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                        else
                            dtg.Rows[i].DefaultCellStyle.BackColor = Color.DimGray;

                        dtg.Rows[i].DefaultCellStyle.ForeColor = Color.White;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private List<SatirDurumlari> satirDurumlaris = new List<SatirDurumlari>();

        public class SatirDurumlari
        {
            public string PartiNo { get; set; }

            public int Row { get; set; }

            public string Durum { get; set; }

            public bool aktif { get; set; }

            public string rotaKodu { get; set; }

            public string rotaAdi { get; set; }

            public string SatiriSil { get; set; }
        }

        private List<FilterelemeDurumlari> filterelemeDurumlaris = new List<FilterelemeDurumlari>();

        public class FilterelemeDurumlari
        {
            public string Tip { get; set; }

            public string Durum { get; set; }

            public string TipAdi { get; set; }
        }

        private void filtrelemeDurumlariOlustur()
        {
            filterelemeDurumlaris.Add(new FilterelemeDurumlari { Tip = "1", Durum = "0", TipAdi = "BAŞLANMAYAN İŞLERİ GİZLE" });
            filterelemeDurumlaris.Add(new FilterelemeDurumlari { Tip = "2", Durum = "0", TipAdi = "DEVAM EDENLERİ GİZLE" });
            filterelemeDurumlaris.Add(new FilterelemeDurumlari { Tip = "3", Durum = "0", TipAdi = "TAMAMLANANLARI GİZLE" });
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (button4.Text == "TAMAMLANANLARI GİZLE")
            {
                filterelemeDurumlaris.Where(x => x.Tip == "3").First().Durum = "1";
                button4.Text = "TAMAMLANANLARI GÖSTER";
                Listele(dataGridView1.CurrentCell.RowIndex, "3");
            }
            else
            {
                filterelemeDurumlaris.Where(x => x.Tip == "3").First().Durum = "0";
                button4.Text = "TAMAMLANANLARI GİZLE";
                Listele(dataGridView1.CurrentCell.RowIndex, "4");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (button3.Text == "BAŞLANMAYAN İŞLERİ GİZLE")
            {
                filterelemeDurumlaris.Where(x => x.Tip == "1").First().Durum = "1";
                button3.Text = "BAŞLANMAYAN İŞLERİ GÖSTER";
                Listele(dataGridView1.CurrentCell.RowIndex, "2");
            }
            else
            {
                filterelemeDurumlaris.Where(x => x.Tip == "1").First().Durum = "0";
                button3.Text = "BAŞLANMAYAN İŞLERİ GİZLE";
                Listele(dataGridView1.CurrentCell.RowIndex, "1");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "DEVAM EDENLERİ GİZLE")
            {
                filterelemeDurumlaris.Where(x => x.Tip == "2").First().Durum = "1";
                button2.Text = "DEVAM EDENLERİ GÖSTER";
                Listele(dataGridView1.CurrentCell.RowIndex, "2");
            }
            else
            {
                filterelemeDurumlaris.Where(x => x.Tip == "2").First().Durum = "0";
                button2.Text = "DEVAM EDENLERİ GİZLE";
                Listele(dataGridView1.CurrentCell.RowIndex, "2");
            }
        }

        //SCROLLBAR START
        private void dataGridView3_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        //SCROLLBAR END
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dataGridView3.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception ex)
            {
            }
        }

        private void vScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                dataGridView1.FirstDisplayedScrollingRowIndex = e.NewValue;
            }
            catch (Exception ex)
            {
            }
        }

        private void dataGridView1_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar2.Value = e.NewValue;
        }

        private void btnGunlukTemizlik_Click(object sender, EventArgs e)
        {
            //YogurtProsesTakip_1 n2 = new YogurtProsesTakip_1(_type, kullanciid, "", "", urunTanimi, "", 0, tarih1, "");
            //n2.Show();
            //Close();

            //LorProsesTakip n2 = new LorProsesTakip(_type, kullanciid, "", "", urunTanimi, "", 0, tarih1);
            //n2.Show();
            //Close();

            //PastorizasyonProsesTakip_1 n2 = new PastorizasyonProsesTakip_1(_type, kullanciid, "", "", urunTanimi, "", 0, tarih1);
            //n2.Show();

            //AyranProsesTakip_3 n2 = new AyranProsesTakip_3(_type, kullanciid, "", "", 0, tarih1);
            //n2.Show();

            //YogurtProsesTakip_2 n2 = new YogurtProsesTakip_2(_type, kullanciid, 0, tarih1);
            //n2.Show();

            int row = dataGridView1.CurrentCell == null ? 0 : dataGridView1.CurrentCell.RowIndex;
            TemizlikTakip n = new TemizlikTakip(_type, istasyonAdi, kullanciid, row, initialWidth, initialHeight, tarih1);
            n.Show();
            Close();
        }

        private void btnGunlukAnaliz_Click(object sender, EventArgs e)
        {
            string val = _type;

            int row = dataGridView1.CurrentCell == null ? 0 : dataGridView1.CurrentCell.RowIndex;

            if (val == "IST005")
            {
                //TazePeynirProsesTakip_2 n = new TazePeynirProsesTakip_2(_type, kullanciid, "", "", "", val, row, Width, Height, tarih1);
                TazePeynirGunlukAnalizGiris n = new TazePeynirGunlukAnalizGiris(_type, kullanciid, "", "", "", val, row, Width, Height, tarih1);
                n.Show();
                Close();
            }
            else if (val == "IST007")
            {
                //TereyagProsesTakip_2 n = new TereyagProsesTakip_2(_type, kullanciid, "", "", "", val, row, Width, Height, tarih1);
                TereyagGunlukAnalizGiris n = new TereyagGunlukAnalizGiris(_type, kullanciid, "", "", "", val, row, Width, Height, tarih1);
                n.Show();
                Close();
            }
            else if (val == "IST002")
            {
                YogurtProsesTakip_2 n = new YogurtProsesTakip_2(_type, kullanciid, row, tarih1);
                n.Show();
                Close();
            }
            else if (val == "IST004")
            {
                TostPeynirProsesTakip_2 n = new TostPeynirProsesTakip_2(_type, kullanciid, "", "", "", val, row, Width, Height, tarih1);
                n.Show();
                Close();
            }
            else if (val == "IST001")
            {
                AyranProsesTakip_3 n = new AyranProsesTakip_3(_type, kullanciid, "", "", row, tarih1);
                n.Show();
                Close();
            }
            //AyranGunlukOzet_1 n2 = new AyranGunlukOzet_1(_type, kullanciid, "", "", 0, tarih1);
            //n2.Show();
        }

        private void btnGunlukSarf_Click(object sender, EventArgs e)
        {
            string istasyonadi = dataGridView3.Rows[0].Cells["Ürün Grubu"].Value.ToString();
            UretimRaporu uretimRaporu = new UretimRaporu(_type, kullanciid, urunTanimi, istasyonadi, Width, Height, tarih1, dataGridView1);
            uretimRaporu.Show();
            Close();
        }
    }
}
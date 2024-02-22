using AIF.UVT.DatabaseLayer;
using BrightIdeasSoftware;
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

namespace AIF.UVT.FORM_ORTAK
{
    public partial class UretimRaporu : Form
    {
        //font start 
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //font end
        public UretimRaporu(string _type, string _kullaniciid, string _UrunTanimi, string _istasyon, int _width, int _height, string _tarih1, DataGridView _dataGridView)
        {
            InitializeComponent();
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = btnGenislet.Font.Size;
            btnGenislet.Resize += Form_Resize;

            type = _type;
            kullaniciid = _kullaniciid;
            UrunTanimi = _UrunTanimi;
            txtIstasyon.Text = _istasyon;
            tarih1 = _tarih1;
            txtUretimTarihi.Text = tarih1.Substring(6, 2) + "/" + tarih1.Substring(4, 2) + "/" + tarih1.Substring(0, 4);
            dataGridView1.DataSource = _dataGridView.DataSource;


            //AddTree();

        }

        private string UrunTanimi = "";
        private string type = "";
        private string kullaniciid = "";
        private string tarih1 = "";
        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();

            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            btnOzetEkranaDon.Font = new Font(btnOzetEkranaDon.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnOzetEkranaDon.Font.Style);

            btnGenislet.Font = new Font(btnGenislet.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnGenislet.Font.Style);

            btnDaralt.Font = new Font(btnDaralt.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnDaralt.Font.Style);

            treeListView.Font = new Font(treeListView.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               FontStyle.Bold);

            treeListView.Font = new Font(treeListView.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                treeListView.Font.Style);

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            txtIstasyon.Font = new Font(txtIstasyon.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtIstasyon.Font.Style);

            txtUretimTarihi.Font = new Font(txtUretimTarihi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtUretimTarihi.Font.Style);

            btnUretimSarfRapor.Font = new Font(btnUretimSarfRapor.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnUretimSarfRapor.Font.Style);

            btnTamamlananUrunler.Font = new Font(btnTamamlananUrunler.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnTamamlananUrunler.Font.Style);

            dataGridView1.Font = new Font(dataGridView1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dataGridView1.Font.Style);

            ResumeLayout();
            //font end
        }
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams cp = base.CreateParams;

        //        cp.ClassStyle |= 0x20000;

        //        cp.ExStyle |= 0x02000000;

        //        return cp;
        //    }
        //} 

        class Node
        {
            public string KalemKodu { get; private set; }
            public string KalemTanimi { get; private set; }

            [OLVColumn(TextAlign = HorizontalAlignment.Right)] //DisplayIndex = 5, Width = 75, 
            public string PlananMiktar { get; private set; }

            //[OLVColumn(IsVisible = false)] //işe yaramadı
            public string Istasyon { get; private set; }
            public string GerceklesenMiktar { get; private set; }
            public string Fark { get; private set; }
            public string GerceklesmeOrani { get; private set; }
            public List<Node> Children { get; private set; }
            public Node(string kalemKodu, string kalemTanimi, string planlananmiktar, string istasyon, string gerceklesenMiktar, string fark, string gerceklesmeOrani)
            {
                this.KalemKodu = kalemKodu;
                this.KalemTanimi = kalemTanimi;
                this.PlananMiktar = planlananmiktar;
                this.Istasyon = istasyon;
                this.GerceklesenMiktar = gerceklesenMiktar;
                this.Fark = fark;
                this.GerceklesmeOrani = gerceklesmeOrani;
                this.Children = new List<Node>();
            }
        }
        private List<Node> data;
        //private BrightIdeasSoftware.TreeListView treeListView;

        // private methods
        //ProgressBar pBar = new ProgressBar();
        private int rowid = 0;

        private void UretimRaporu_Load(object sender, EventArgs e)
        {

            //tableLayoutPanel1.SendToBack();
            #region progress
            //circularProgressBar1.Visible = true;
            //circularProgressBar1.Style = ProgressBarStyle.Marquee; 
            #endregion

            //LoadingForm loadingForm = new LoadingForm();
            //loadingForm.ShowDialog();

            #region MKOD İle Background Değişimi

            var lastOpenedForm = Application.OpenForms.Cast<Form>().Last();

            if (Giris.mKodValue == "010OTATURVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.OTAT_UVT_ArkaPlanV3;
            }
            else if (Giris.mKodValue == "20URVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.YORUK_UVT_ArkaPlanv2;
            }

            #endregion MKOD İle Background Değişimi


            InitializeData();
            FillTree();

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;

                dataGridView1.Columns["Gerçekleşen Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dataGridView1.Columns["Gerçekleşen Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;

                dataGridView1.Columns["Tarih"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                //dataGridView1.Columns["Tarih"].Visible = false;
                dataGridView1.Columns["Istasyon"].Visible = false;
                dataGridView1.Columns["Barkod"].Visible = false;
                dataGridView1.Columns["U_UVTVarsayilanDepo"].Visible = false;
                if (Giris.mKodValue == "010OTATURVT")
                {
                    dataGridView1.Columns["Planlanan KG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns["Planlanan KG"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dataGridView1.Columns["Birim"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns["Gerçekleşen KG"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dataGridView1.Columns["Gerçekleşen KG"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
                    dataGridView1.Columns["ItmsGrpCod"].Visible = false;
                }
                dataGridView1.AutoResizeRows();

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
                #region tsaarım  
                dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
                dataGridView1.ColumnHeadersHeight = 40;

                //dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.AliceBlue;
                //dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(220, 230, 241);

                dataGridView1.EnableHeadersVisualStyles = false;
                dataGridView1.RowHeadersVisible = false;

                //dataGridView1.RowTemplate.Height = 40;

                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 15F, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                setFormatGrid(dataGridView1, 15);

                vScrollBar2.Maximum = dataGridView1.RowCount + 5;

                dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightGoldenrodYellow;
                dataGridView1.DefaultCellStyle.SelectionForeColor = Color.Black;

                SatirRenkle(rowid, dataGridView1);

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    dataGridView1.Rows[i].Height = 35;
                    //if (dataGridView1.Rows[i].Height < 60)
                    //{
                    //    dataGridView1.Rows[i].Height = 60;
                    //}
                }
                #endregion  
            }
            ////treeView1.DrawMode = TreeViewDrawMode.OwnerDrawText;
            //string sql = "SELECT TOP 10 T0.[ItemCode],T0.[Dscription],SUM(T0.[Quantity]) as Miktar,T2.[U_ISTASYON],T3.BatchNum FROM IGE1 T0 INNER JOIN OIGE T1 ON T0.[DocEntry] = T1.[DocEntry] AND T0.[BaseType] = '202' LEFT JOIN OWOR T2 ON T2.DocNum = T0.\"BaseEntry\" LEFT JOIN WOR1 T4 ON T2.DocEntry = T4.DocEntry LEFT JOIN IBT1 T3 ON T0.ItemCode = T3.ItemCode and T3.BaseType = 60 and T3.BaseEntry = T1.DocEntry LEFT JOIN OITM T5 ON T5.ItemCode = T0.ItemCode WHERE T1.[DocDate] = '20220720'  and ISNULL(T5.ItemCode,'')<> '' group by T0.ItemCode,T0.Dscription,T2.U_ISTASYON,T3.BatchNum,T5.ItemCode";


            //Giris.dbName = "OTAT";
            //Giris.mKodValue = "010OTATURVT";
            //SqlCommand cmd = null;
            //cmd = new SqlCommand(sql, Connection.sql);

            //if (Connection.sql.State != ConnectionState.Open)
            //    Connection.sql.Open();

            //SqlDataAdapter sda = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sda.Fill(dt);


            //foreach (DataRow dr in dt.Rows)
            //{
            //    //DataRow dr2 = dtPartiTemp.NewRow();
            //    //dr2["UrunKodu"] = item["UrunKodu"];

            //    TreeNode treeNode = new TreeNode(dr["ItemCode"].ToString() + " | " + dr["Dscription"].ToString());

            //    //treeNode.BackColor = BackColor.
            //    treeView1.Nodes.Add(treeNode);

            //    treeView1.SelectedNode = treeNode;

            //    treeView1.SelectedNode.Nodes.Add(dr["BatchNum"].ToString() + " | " + Convert.ToDouble(dr["Miktar"]).ToString("N" + Giris.OndalikMiktar));
            //}

            //pictureBox1.SendToBack();
            //pictureBox1.Dispose();
            //tableLayoutPanel1.BringToFront();

            //loadingForm.Close();
            //loadingForm.Dispose();

            //tableLayoutPanel1.BringToFront();


        }
        int count = 0;

        private void setFormatGrid(DataGridView dtg, int value)
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

            foreach (DataGridViewColumn col in dtg.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }
        }
        private void SatirRenkle(int index, DataGridView dtg)
        {
            try
            {
                for (int i = 0; i < dtg.Rows.Count; i++)
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
            catch (Exception)
            {
            }
        }
        private void FillTree()
        {

            //this.Controls.Add(pBar);
            //treeListView.ShowHeaderInAllViews = false;
            // set the delegate that the tree uses to know if a node is expandable
            this.treeListView.CanExpandGetter = x => (x as Node).Children.Count > 0;
            // set the delegate that the tree uses to know the children of a node
            this.treeListView.ChildrenGetter = x => (x as Node).Children;

            // create the tree columns and set the delegates to print the desired object proerty
            var oLVKalemKodu = new BrightIdeasSoftware.OLVColumn("Kalem Kodu", "KalemKodu");
            oLVKalemKodu.AspectGetter = x => (x as Node).KalemKodu;
            oLVKalemKodu.HeaderTextAlign = HorizontalAlignment.Center;

            var oLVKalemTanimi = new BrightIdeasSoftware.OLVColumn("Kalem Tanımı", "KalemTanimi");
            oLVKalemTanimi.AspectGetter = x => (x as Node).KalemTanimi;
            oLVKalemTanimi.HeaderTextAlign = HorizontalAlignment.Center;

            var oLVPlananMiktar = new BrightIdeasSoftware.OLVColumn("Planlanan Miktar", "PlanlananMiktar");
            oLVPlananMiktar.AspectGetter = x => (x as Node).PlananMiktar;
            oLVPlananMiktar.HeaderTextAlign = HorizontalAlignment.Center;
            oLVPlananMiktar.TextAlign = HorizontalAlignment.Right;

            var oLVGerceklesenMiktar = new BrightIdeasSoftware.OLVColumn("Gerçekleşen Miktar", "GerceklesenMiktar");
            oLVGerceklesenMiktar.AspectGetter = x => (x as Node).GerceklesenMiktar;
            oLVGerceklesenMiktar.HeaderTextAlign = HorizontalAlignment.Center;
            oLVGerceklesenMiktar.TextAlign = HorizontalAlignment.Right;

            var oLVFark = new BrightIdeasSoftware.OLVColumn("Fark", "Fark");
            oLVFark.AspectGetter = x => (x as Node).Fark;
            oLVFark.HeaderTextAlign = HorizontalAlignment.Center;
            oLVFark.TextAlign = HorizontalAlignment.Right;

            var oLVGerceklesmeOrani = new BrightIdeasSoftware.OLVColumn("Gerçekleşme Oranı(%)", "GerceklesmeOrani");
            oLVGerceklesmeOrani.AspectGetter = x => (x as Node).GerceklesmeOrani;
            oLVGerceklesmeOrani.HeaderTextAlign = HorizontalAlignment.Center;
            oLVGerceklesmeOrani.TextAlign = HorizontalAlignment.Right;


            //var oLVIstasyon = new BrightIdeasSoftware.OLVColumn("İstasyon", "Istasyon");
            //oLVIstasyon.AspectGetter = x => (x as Node).Istasyon;
            //oLVIstasyon.IsVisible = false;

            this.treeListView.Columns.Add(oLVKalemKodu);
            this.treeListView.Columns.Add(oLVKalemTanimi);
            this.treeListView.Columns.Add(oLVPlananMiktar);
            this.treeListView.Columns.Add(oLVGerceklesenMiktar);
            this.treeListView.Columns.Add(oLVFark);
            this.treeListView.Columns.Add(oLVGerceklesmeOrani);
            //this.treeListView.Columns.Add(oLVIstasyon);
            // set the tree roots
            this.treeListView.Roots = data;
            //treeListView.RebuildColumns();
            //treeListView.AutoSizeColumns();  

            //nameCol.AutoCompleteEditor = true;
            //nameCol.AutoCompleteEditorMode = AutoCompleteMode.Suggest;
            oLVKalemKodu.FillsFreeSpace = true;
            oLVKalemTanimi.FillsFreeSpace = true;
            oLVPlananMiktar.FillsFreeSpace = true;
            oLVGerceklesenMiktar.FillsFreeSpace = true;
            oLVFark.FillsFreeSpace = true;
            oLVGerceklesmeOrani.FillsFreeSpace = true;

            //col1.UseInitialLetterForGroup = true;

            //treeListView.UseAlternatingBackColors = true;
            //treeListView.AlternateRowBackColor = Color.LightGray;

            treeListView.UseCustomSelectionColors = true;
            treeListView.SelectedBackColor = Color.LightGreen;

            treeListView.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold);

            treeListView.HeaderUsesThemes = true;
            //treeListView.HeaderStyle = ColumnHeaderStyle.Clickable;

            treeListView.FullRowSelect = true;
            treeListView.RowHeight = 35;
            treeListView.HeaderMinimumHeight = 40;
            //treeListView.HeaderMaximumHeight = 50;

            treeListView.HeaderUsesThemes = false;
            foreach (OLVColumn item in treeListView.Columns)
            {
                var headerstyle = new HeaderFormatStyle();
                headerstyle.SetBackColor(Color.AliceBlue);
                //headerstyle.SetForeColor(Color.SlateGray);
                item.HeaderFormatStyle = headerstyle;
            }



            treeListView.GridLines = true;

            //this.treeListView.EmptyListMsg = "This database has no rows";
            //this.treeListView.EmptyListMsgFont = new Font("Tahoma", 24);

            //TextOverlay textOverlay = this.treeListView.EmptyListMsgOverlay as TextOverlay;
            //textOverlay.TextColor = Color.Firebrick;
            //textOverlay.BackColor = Color.AntiqueWhite;
            //textOverlay.BorderColor = Color.DarkRed;
            //textOverlay.BorderWidth = 4.0f;
            //textOverlay.Font = new Font("Chiller", 36);
            //textOverlay.Rotation = -5;

            //treeListView.OverlayText.BorderColor = Color.DarkRed;
            //treeListView.OverlayText.BorderWidth = 4.0f;


            //treeListView.HeaderControl.MaximumHeight = 30; 
            //treeListView.AlternateRowBackColorOrDefault.BackColor = Color.LightGray;

            //foreach (DataGridViewColumn col in dtGunlukTemizlik.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
            //} 

            //for (int i = 0; i < treeListView.Columns.Count; i++)
            //{
            //    if (i == 0)
            //        treeListView.Columns[i].Width = 35;
            //    else
            //        treeListView.Columns[i].Width = 300;
            //}

            //treeListView.Roots.Columns["Miktar"].TextAlign = HorizontalAlignment.Right;
            treeListView.ExpandAll();

        }
        private void InitializeData()
        {
            //progressBar1.Visible = true; //chn
            data = new List<Node>();
            string sql = "";

            #region hakan
            // sql = "SELECT  T0.[ItemCode],T0.[Dscription],SUM(T0.[Quantity]) as Miktar,T2.[U_ISTASYON] FROM IGE1 T0 INNER JOIN OIGE T1 ON T0.[DocEntry] = T1.[DocEntry] AND T0.[BaseType] = '202' LEFT JOIN OWOR T2 ON T2.DocNum = T0.\"BaseEntry\" LEFT JOIN WOR1 T4 ON T2.DocEntry = T4.DocEntry LEFT JOIN IBT1 T3 ON T0.ItemCode = T3.ItemCode and T3.BaseType = 60 and T3.BaseEntry = T1.DocEntry LEFT JOIN OITM T5 ON T5.ItemCode = T0.ItemCode WHERE T1.[DocDate] = '20220120'  and ISNULL(T5.ItemCode,'')<> '' group by T0.ItemCode,T0.Dscription,T2.U_ISTASYON,T5.ItemCode order by T5.\"ItemCode\""; 
            #endregion

            #region fatih
            //sql = "SELECT T4.\"ItemCode\", T4.\"ItemName\", sum(T0.\"Quantity\") AS \"Miktar\", T0.\"DocDate\", T2.\"U_ISTASYON\" FROM IBT1 T0 INNER JOIN WOR1 T1 ON T0.\"BsDocEntry\" = T1.\"DocEntry\" AND T0.\"BsDocLine\" = T1.\"LineNum\" AND T0.\"ItemCode\" = T1.\"ItemCode\" INNER JOIN OWOR T2 ON T2.\"DocEntry\" = T1.\"DocEntry\" INNER JOIN OITM T4 ON T4.\"ItemCode\" = T0.\"ItemCode\" WHERE T0.\"BsDocType\" = 202 AND T0.\"DocDate\" = '" + tarih1 + "' and T2.\"U_ISTASYON\" = '" + type + "' group by T4.\"ItemCode\",T4.\"ItemName\",T0.\"DocDate\", T2.\"U_ISTASYON\" order by T4.\"ItemCode\" ";
            #endregion

            #region Hakan Murat chn 20220804
            //sql = "Select * from(Select T1.ItemCode,T1.ItemName,SUM(T1.PlannedQty) as 'Planlanan',SUM(T1.IssuedQty) as 'Gerçekleşen',SUM(T1.PlannedQty) / case when SUM(T1.IssuedQty) = 0 then 1 else SUM(T1.IssuedQty) end as Randıman,case when T2.ItmsGrpCod = 105 and ISNULL(T2.U_ItemGroup2,0) <> 110  then 1 when T2.ItmsGrpCod = 105 and ISNULL(T2.U_ItemGroup2,0) = 110 then 2 WHEN SUBSTRING(T2.ItemCode,0,4) = 'END' then 3 WHEN SUBSTRING(T2.ItemCode,0,4) = 'ISM' then 4 WHEN SUBSTRING(T2.ItemCode,0,4) = 'ABM' then 5 ELSE  6 end Oncelik from OWOR AS T0 INNER JOIN WOR1 AS T1 ON T0.DocEntry = T1.DocEntry INNER JOIN OITM AS T2 ON T1.ItemCode = T2.ItemCode where T0.DueDate = '" + tarih1 + "' AND T0.U_ISTASYON = '" + type + "' AND T0.\"Status\" <> 'C' and (T1.ItemCode NOT LIKE '%LBR%' AND  T1.ItemCode NOT LIKE '%RES%'  AND  T1.ItemCode NOT LIKE '%WHS%')  group by T1.ItemCode,T1.ItemName,T2.ItmsGrpCod,T2.U_ItemGroup2,T2.ItemCode) as tbl order by tbl.Oncelik";
            #endregion

            #region Murat chn 20220804
            sql = "Select * from(Select T1.ItemCode,T1.ItemName,SUM(T1.PlannedQty) as 'Planlanan',SUM(T1.IssuedQty) as 'Gerçekleşen', SUM(T1.PlannedQty) - SUM(T1.IssuedQty) AS Fark,100 - (SUM(T1.PlannedQty - T1.IssuedQty) / SUM(T1.PlannedQty) * 100) AS \"Gerçekleşme Oranı(%)\",case when T2.ItmsGrpCod = 105 and ISNULL(T2.U_ItemGroup2,0) <> 110  then 1 when T2.ItmsGrpCod = 105 and ISNULL(T2.U_ItemGroup2,0) = 110 then 2 WHEN SUBSTRING(T2.ItemCode,0,4) = 'END' then 3 WHEN SUBSTRING(T2.ItemCode,0,4) = 'ISM' then 4 WHEN SUBSTRING(T2.ItemCode,0,4) = 'ABM' then 5 ELSE  6 end Oncelik from OWOR AS T0 WITH (NOLOCK) INNER JOIN WOR1 AS T1 WITH (NOLOCK) ON T0.DocEntry = T1.DocEntry INNER JOIN OITM AS T2 WITH (NOLOCK) ON T1.ItemCode = T2.ItemCode where T0.DueDate = '" + tarih1 + "' AND T0.U_ISTASYON = '" + type + "' AND T0.\"Status\" <> 'C' and (T1.ItemCode NOT LIKE '%LBR%' AND  T1.ItemCode NOT LIKE '%RES%'  AND  T1.ItemCode NOT LIKE '%WHS%')  group by T1.ItemCode,T1.ItemName,T2.ItmsGrpCod,T2.U_ItemGroup2,T2.ItemCode) as tbl order by tbl.Oncelik";
            #endregion

            //Giris.dbName = "OTAT";
            //Giris.mKodValue = "010OTATURVT";
            SqlCommand cmd = null;
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

            DataTable dt_row = new DataTable();
            string sss = "";

            foreach (DataRow dr in dt.Rows)
            {
                //progressBar1.Value = dt_row.Rows.Count;
                //circularProgressBar1.Value = dt_row.Rows.Count;
                //circularProgressBar1.Text = dt_row.Rows.Count.ToString() + "%";
                //circularProgressBar1.Update();

                //DataRow dr2 = dtPartiTemp.NewRow();
                //dr2["UrunKodu"] = item["UrunKodu"];

                var parent1 = new Node(dr["ItemCode"].ToString(), dr["ItemName"].ToString(), Convert.ToDouble(dr["Planlanan"]).ToString("N" + Giris.OndalikMiktar), "", Convert.ToDouble(dr["Gerçekleşen"]).ToString("N" + Giris.OndalikMiktar), Convert.ToDouble(dr["Fark"]).ToString("N" + Giris.OndalikMiktar), Convert.ToDouble(dr["Gerçekleşme Oranı(%)"]).ToString("N" + Giris.OndalikMiktar));

                #region hakan
                //sss = "SELECT  SUM(T0.[Quantity]) as Miktar, T3.BatchNum FROM IGE1 T0 INNER JOIN OIGE T1 ON T0.[DocEntry] = T1.[DocEntry] AND T0.[BaseType] = '202' LEFT JOIN OWOR T2 ON T2.DocNum = T0.\"BaseEntry\" LEFT JOIN IBT1 T3 ON T0.ItemCode = T3.ItemCode and T3.BaseType = 60 and T3.BaseEntry = T1.DocEntry WHERE T1.[DocDate] = '20220120' and T3.ItemCode = '" + dr["ItemCode"].ToString() + "' group by T0.ItemCode,T0.Dscription,T2.U_ISTASYON,T3.BatchNum "; 
                #endregion

                #region fatih
                //sss = "SELECT T4.\"ItemCode\", T4.\"ItemName\", sum(T0.\"Quantity\") AS \"Miktar\", T0.\"BatchNum\", T0.\"DocDate\", T2.\"U_ISTASYON\" FROM IBT1 T0 INNER JOIN WOR1 T1 ON T0.\"BsDocEntry\" = T1.\"DocEntry\" AND T0.\"BsDocLine\" = T1.\"LineNum\" AND T0.\"ItemCode\" = T1.\"ItemCode\" INNER JOIN OWOR T2 ON T2.\"DocEntry\" = T1.\"DocEntry\" INNER JOIN OITM T4 ON T4.\"ItemCode\" = T0.\"ItemCode\" WHERE T0.\"BsDocType\" = 202 and T0.\"DocDate\" = '" + tarih1 + "' and T4.\"ItemCode\" = '" + dr["ItemCode"].ToString() + "' and T2.\"U_ISTASYON\" = '" + type + "' group by T4.\"ItemCode\",T4.\"ItemName\",T2.\"U_ISTASYON\",T0.\"BatchNum\",T0.\"DocDate\" ";
                #endregion

                #region Hakan Murat
                sss = "Select T1.ItemCode,T1.ItemName ,sum(T2.Quantity) as Miktar,T2.BatchNum from OWOR AS T0 WITH (NOLOCK) INNER JOIN WOR1 AS T1 WITH (NOLOCK) ON T0.DocEntry = T1.DocEntry INNER JOIN IBT1 AS T2 WITH (NOLOCK) ON T2.\"BsDocEntry\" = T1.\"DocEntry\" AND T2.\"BsDocLine\" = T1.\"LineNum\" AND T2.\"ItemCode\" = T1.\"ItemCode\" where T0.DueDate = '" + tarih1 + "' AND T0.\"U_ISTASYON\" = '" + type + "' AND T1.ItemCode = '" + dr["ItemCode"].ToString() + "' AND T2.\"BsDocType\" = 202 group by T1.ItemCode,T1.ItemName,T2.BatchNum";
                #endregion

                cmd = new SqlCommand(sss, Connection.sql);
                sda = new SqlDataAdapter(cmd);
                sda.Fill(dt_row);

                #region sql connection chn 
                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
                #endregion

                foreach (DataRow dr_2 in dt_row.Rows)
                {
                    parent1.Children.Add(new Node("", dr_2["BatchNum"].ToString(), "", "", Convert.ToDouble(dr_2["Miktar"]).ToString("N" + Giris.OndalikMiktar), "", ""));
                }


                count += dt_row.Rows.Count;
                //progressBar1.Value = dt_row.Rows.Count; //chn
                dt_row.Clear();
                //parent1.Children.Add(new Node("CHILD_1_2", "A", "Y", "2"));
                //parent1.Children.Add(new Node("CHILD_1_3", "A", "Z", "3"));

                //TreeNode treeNode = new TreeNode(dr["ItemCode"].ToString() + " | " + dr["Dscription"].ToString());

                ////treeNode.BackColor = BackColor.
                //treeView1.Nodes.Add(treeNode);

                //treeView1.SelectedNode = treeNode;

                //treeView1.SelectedNode.Nodes.Add(dr["BatchNum"].ToString() + " | " + Convert.ToDouble(dr["Miktar"]).ToString("N" + Giris.OndalikMiktar));

                data.Add(parent1);
            } 
            //int count = treeListView.GetItemCount();
            vScrollBar1.Maximum = count + 5;
            // create fake nodes
            //progressBar1.Visible = false;

            //var parent2 = new Node("PARENT2", "-", "-", "-");
            //parent2.Children.Add(new Node("CHILD_2_1", "B", "W", "7"));
            //parent2.Children.Add(new Node("CHILD_2_2", "B", "Z", "8"));
            //parent2.Children.Add(new Node("CHILD_2_3", "B", "J", "9"));

            //var parent3 = new Node("PARENT3", "-", "-", "-");
            //parent3.Children.Add(new Node("CHILD_3_1", "C", "R", "10"));
            //parent3.Children.Add(new Node("CHILD_3_2", "C", "T", "12"));
            //parent3.Children.Add(new Node("CHILD_3_3", "C", "H", "14"));

            //data = new List<Node> { parent1, parent2, parent3 };
            //circularProgressBar1.Visible = false;
            //progressBar1.Visible = false;//chn
            //yukleniyor.Close();
        }

        private void AddTree()
        {
            //treeListView = new BrightIdeasSoftware.TreeListView();
            //treeListView.Dock = DockStyle.Fill;
            //this.Controls.Add(treeListView);
        }
        private CellBorderDecoration standardDecoration = new CellBorderDecoration();

        public TreeNode previousSelectedNode = null;

        private void treeListView_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            Node data = (Node)e.Model;
            //if (treeListView.Columns["Column2"].Text == "Kalem Kodu")
            //    e.Item.BackColor = Color.LightGray;

            if (data.KalemKodu == "")
            {
                e.Item.BackColor = Color.WhiteSmoke;
            }
            else
            {
                e.Item.BackColor = Color.LightGray;
            }

            //e.Item.CellVerticalAlignment = StringAlignment.Center;//saıırı sağa yaslamıyor
            //if (treeListView.Columns["Miktar"].TextAlign.)
            //{
            //    e.Item.Decoration.ListItem.CellVerticalAlignment = StringAlignment.Far;
            //}
            //for (int i = 0; i < treeListView.Roots.le.Control..Count; i++)
            //{
            //    if (treeListView.DataBindings.Count % 2== 0)
            //    {
            //        e.Item.BackColor = Color.Red;
            //    }
            //}

            //e.Item.Decoration = standardDecoration; 
        }

        private void btnGenislet_Click(object sender, EventArgs e)
        {
            treeListView.ExpandAll();
        }

        private void btnDaralt_Click(object sender, EventArgs e)
        {
            treeListView.CollapseAll();
        }

        private void btnOzetEkranaDon_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, 0, initialWidth, initialHeight, tarih1);
            banaAitİsler.Show();
            Close();
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            try
            {
                //treeListView.FirstDisplayedScrollingRowIndex = e.NewValue;
                treeListView.TopItemIndex = e.NewValue;
            }
            catch (Exception ex)
            {
            }
        }

        private void treeListView_Scroll(object sender, ScrollEventArgs e)
        {
            vScrollBar1.Value = e.NewValue;
        }

        private void btnYukle_Click(object sender, EventArgs e)
        {

            //progressBar1.Location = new System.Drawing.Point(20, 20);
            //progressBar1.Name = "progressBar1";
            //progressBar1.Width = 200;
            //progressBar1.Height = 30; 
            //progressBar1.Minimum = 0;
            //progressBar1.Maximum = 100;

        }

        private void btnUretimSarfRapor_Click(object sender, EventArgs e)
        {
            //InitializeData();
            //FillTree(); 
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SatirRenkle(dataGridView1.CurrentCell.RowIndex, dataGridView1);
        }
    }
}

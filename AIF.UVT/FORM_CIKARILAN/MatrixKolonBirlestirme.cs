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
    public partial class MatrixKolonBirlestirme : Form
    {
        public MatrixKolonBirlestirme()
        {
            InitializeComponent();
        }

        private SqlCommand cmd = null;
        private void button1_Click(object sender, EventArgs e)
        {



        }


        private void MatrixKolonBirlestirme_Load(object sender, EventArgs e)
        {

            string sql = "SELECT T0.[ItemCode] as \"Malzeme Kodu\", T0.[ItemName] as \"Malzeme Tanımı\", T0.[BatchNum] as \"Parti\", T0.[Quantity] as \"Miktar\" FROM IBT1  T0 left join OIGE T1 on T0.[BaseEntry] = T1.[DocNum] WHERE T0.[BaseType] = 60 and  T1.[U_BatchNumber] ='20200605-11010101-01-1'";
            cmd = new SqlCommand(sql, Giris.sqlConnection_Uvt);

            if (Giris.sqlConnection_Uvt.State != ConnectionState.Open)
                Giris.sqlConnection_Uvt.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);


            dtgMalzemeOz.DataSource = dt;
            dtgMalzemeOz.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMalzemeOz.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            //System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            //dtgMalzemeOz.Font = new System.Drawing.Font("Bahnschrift", 12F, FontStyle.Bold);
            //dtgMalzemeOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            //dtgMalzemeOz.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            //dtgMalzemeOz.EnableHeadersVisualStyles = false;
            //dtgMalzemeOz.DefaultCellStyle.BackColor = Color.LightGray;
            //foreach (DataGridViewColumn col in dtgMalzemeOz.Columns)
            //{
            //    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            //    col.HeaderCell.Style.Font = new Font("Bahnschrift", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            //}



            //for (int j = 0; j < this.dtgMalzemeOz.ColumnCount; j++)

            //{

            //    this.dtgMalzemeOz.Columns[j].Width = 45;

            //}

            this.dtgMalzemeOz.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;

            this.dtgMalzemeOz.ColumnHeadersHeight = this.dtgMalzemeOz.ColumnHeadersHeight * 2;

            this.dtgMalzemeOz.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomCenter;

            this.dtgMalzemeOz.CellPainting += new DataGridViewCellPaintingEventHandler(dtgMalzemeOz_CellPainting);

            this.dtgMalzemeOz.Paint += new PaintEventHandler(dtgMalzemeOz_Paint);



            //this.dtgMalzemeOz.Scroll += new ScrollEventHandler(dtgMalzemeOz_Scroll);

            //this.dtgMalzemeOz.ColumnWidthChanged += new DataGridViewColumnEventHandler(dtgMalzemeOz_ColumnWidthChanged);
        }

        void dtgMalzemeOz_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)

        {

            Rectangle rtHeader = this.dtgMalzemeOz.DisplayRectangle;

            rtHeader.Height = this.dtgMalzemeOz.ColumnHeadersHeight / 2;

            this.dtgMalzemeOz.Invalidate(rtHeader);

        }



        void dtgMalzemeOz_Scroll(object sender, ScrollEventArgs e)

        {

            Rectangle rtHeader = this.dtgMalzemeOz.DisplayRectangle;

            rtHeader.Height = this.dtgMalzemeOz.ColumnHeadersHeight / 2;

            this.dtgMalzemeOz.Invalidate(rtHeader);

        }



        void dtgMalzemeOz_Paint(object sender, PaintEventArgs e)

        {

            //Offsets to adjust the position of the merged Header.
            int heightOffset = -5;
            int widthOffset = -2;
            int xOffset = 0;
            int yOffset = 4;

            //Index of Header column from where the merging will start.
            int columnIndex = 0;

            //Number of Header columns to be merged.
            int columnCount = 4;

            //Get the position of the Header Cell.
            Rectangle headerCellRectangle = dtgMalzemeOz.GetCellDisplayRectangle(columnIndex, 0, true);

            //X coordinate  of the merged Header Column.
            int xCord = headerCellRectangle.Location.X + xOffset;

            //Y coordinate  of the merged Header Column.
            int yCord = headerCellRectangle.Location.Y - headerCellRectangle.Height + yOffset;

            //Calculate Width of merged Header Column by adding the widths of all Columns to be merged.
            int mergedHeaderWidth = dtgMalzemeOz.Columns[columnIndex].Width + dtgMalzemeOz.Columns[columnIndex + columnCount - 1].Width + widthOffset;

            //Generate the merged Header Column Rectangle.
            Rectangle mergedHeaderRect = new Rectangle(xCord, yCord, mergedHeaderWidth, headerCellRectangle.Height + heightOffset);

            //Draw the merged Header Column Rectangle.
            e.Graphics.FillRectangle(new SolidBrush(Color.White), mergedHeaderRect);

            //Draw the merged Header Column Text.
            e.Graphics.DrawString("Address", dtgMalzemeOz.ColumnHeadersDefaultCellStyle.Font, Brushes.Black, xCord + 2, yCord + 3);

            //string[] monthes = { "Başlık1" };

            //for (int j = 0; j < 3;)

            //{

            //    Rectangle r1 = this.dtgMalzemeOz.GetCellDisplayRectangle(j, -1, true);

            //    int w2 = this.dtgMalzemeOz.GetCellDisplayRectangle(j + 3, -1, true).Width;

            //    r1.X += 3;

            //    r1.Y += 3;

            //    r1.Width = r1.Width + w2 - 2;

            //    r1.Height = r1.Height / 2 - 2;

            //    e.Graphics.FillRectangle(new SolidBrush(this.dtgMalzemeOz.ColumnHeadersDefaultCellStyle.BackColor), r1);

            //    StringFormat format = new StringFormat();

            //    format.Alignment = StringAlignment.Center;

            //    format.LineAlignment = StringAlignment.Center;

            //    e.Graphics.DrawString("Başlık1",

            //        this.dtgMalzemeOz.ColumnHeadersDefaultCellStyle.Font,

            //        new SolidBrush(this.dtgMalzemeOz.ColumnHeadersDefaultCellStyle.ForeColor),

            //        r1,

            //        format);

            //    j += 4;

            //}

        }



        void dtgMalzemeOz_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)

        {

            if (e.RowIndex == -1 && e.ColumnIndex > -1)

            {

                Rectangle r2 = e.CellBounds;

                r2.Y += e.CellBounds.Height / 2;

                r2.Height = e.CellBounds.Height / 2;



                e.PaintBackground(r2, true);



                e.PaintContent(r2);


                e.Handled = true;
            }

        }
    }
}

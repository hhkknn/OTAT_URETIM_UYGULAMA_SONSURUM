using AIF.UVT.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class SelectList : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end.

        public SelectList(string _sql, DataGridView _dtgridParams = null, int _kodindex = 0, int _koddescindex = 0, string _yeniSatir = "", DataTable _dtparams = null, string _type = "", bool _autoresizerow = true, TextBox _txtParam = null, RichTextBox _rchParamDesc = null, bool _enabled = true)
        {
            sql = _sql;
            dtgridParams = _dtgridParams;
            kodindex = _kodindex;
            koddescindex = _koddescindex;
            yeniSatir = _yeniSatir;
            dtparams = _dtparams;
            type = _type;
            autoresizerow = _autoresizerow;
            txtParam = _txtParam;
            enabled = _enabled;
            rchParamDesc = _rchParamDesc;
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;
            //font end

            button1.Enabled = enabled;
        }

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

            dtgSecim.Font = new Font(dtgSecim.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                dtgSecim.Font.Style);

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            txtAra.Font = new Font(txtAra.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtAra.Font.Style);

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

        private string sql = "";
        private int kodindex = 0;
        private int koddescindex = 0;
        private string yeniSatir = "";
        private bool autoresizerow = true;
        private DataTable dtparams = null;
        private DataTable dtSecim = null;
        private DataTable dtParamsOrjinalValues = new DataTable();
        private TextBox txtParam = null;
        private RichTextBox rchParamDesc = null;
        private string type = "";

        private SqlCommand cmd = null;
        private DataGridView dtgridParams = null;
        bool enabled = true;
        private void SelectList_Load(object sender, EventArgs e)
        { 
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
            if (sql != "")
            {
                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                DataTable dttemp = new DataTable();
                sda.Fill(dt);

                dtgSecim.DataSource = dt;
                dtSecim = dt;
                dtParamsOrjinalValues = dtSecim.Copy();

                #region sql connection chn 
                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
                #endregion
            }
            else
            {
                dtgSecim.DataSource = dtparams;
            }

            for (int ix = 0; ix <= dtgSecim.Columns.Count - 1; ix++)
            {
                dtgSecim.Columns[ix].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
            setFormatGrid(dtgSecim, 0);


            dtgSecim.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dtgSecim.ColumnHeadersHeight = 33;
            dtgSecim.Columns[0].Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void setFormatGrid(DataGridView dtg, int value)
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();

            foreach (DataGridViewColumn col in dtg.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", dtg.Font.Size, FontStyle.Bold, GraphicsUnit.Pixel); 
            }

            for (int i = 0; i <= dtg.Rows.Count - 1; i++)
            {
                if (i % 2 == 0)
                    dtg.Rows[i].DefaultCellStyle.BackColor = Color.Gray;
                else
                    dtg.Rows[i].DefaultCellStyle.BackColor = Color.DimGray;

                dtg.Rows[i].DefaultCellStyle.ForeColor = Color.White;
            }
             
        }

        public static string kalemKodu = "";

        //commit.
        private void button1_Click(object sender, EventArgs e)
        {
            if (dtgridParams != null)
            {
                try
                {
                    if (yeniSatir == "")
                    {
                        if (type == "DepoSec")
                        {
                            int selectedrowindex = dtgSecim.SelectedCells[0].RowIndex;
                            var val = dtgSecim[0, selectedrowindex];

                            if (val.Value.ToString() != "")
                            {
                                dtgridParams.NotifyCurrentCellDirty(true);
                                dtgridParams.Rows[dtgridParams.SelectedCells[0].RowIndex].Cells[koddescindex].Value = val.Value;
                                dtgridParams.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                                if (autoresizerow)
                                {
                                    dtgridParams.AutoResizeRows();
                                }

                                try
                                {
                                    dtgridParams.Rows[dtgridParams.SelectedCells[0].RowIndex].Cells["Miktar"].Selected = true;
                                    dtgridParams.Rows[dtgridParams.SelectedCells[0].RowIndex].Cells["Depo"].Selected = false;
                                }
                                catch (Exception)
                                {
                                }
                            }
                        }
                        else
                        {
                            int selectedrowindex = dtgSecim.SelectedCells[0].RowIndex;
                            var val = dtgSecim[0, selectedrowindex];
                            var valDesc = dtgSecim[1, selectedrowindex];
                            if (kodindex > -1)
                            {
                                dtgridParams.Rows[dtgridParams.SelectedCells[0].RowIndex].Cells[kodindex].Value = val.Value;
                            }
                            dtgridParams.NotifyCurrentCellDirty(true);
                            dtgridParams.Rows[dtgridParams.SelectedCells[0].RowIndex].Cells[koddescindex].Value = valDesc.Value;
                            dtgridParams.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                            if (autoresizerow)
                            {
                                dtgridParams.AutoResizeRows();
                            }

                            kalemKodu = val.Value.ToString();
                        }
                    }
                    else
                    {
                        if (type == "PersonelEkle")
                        {
                            int selectedrowindex = dtgSecim.SelectedCells[0].RowIndex;
                            var val = dtgSecim[0, selectedrowindex];
                            var valDesc = dtgSecim[1, selectedrowindex];

                            if (dtparams.AsEnumerable().Where(x => x.Field<string>("Personel No") == val.Value.ToString()).Count() == 0)
                            {
                                DataRow dr = dtparams.NewRow();
                                dr["Personel No"] = val.Value;
                                dr["Personel Adı"] = valDesc.Value;
                                dr["Secim"] = "Y";

                                dtparams.Rows.Add(dr);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                if (txtParam != null)
                {
                    int selectedrowindex = dtgSecim.SelectedCells[0].RowIndex;
                    var val = dtgSecim[0, selectedrowindex];
                    var valDesc = dtgSecim[1, selectedrowindex];

                    txtParam.Text = val.Value.ToString();
                    rchParamDesc.Text = valDesc.Value.ToString();
                }
            }
            Close();
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            dtSecim = dtParamsOrjinalValues.Copy();
            string column1 = dtgSecim.Columns[0].Name;

            string columnName = dtgSecim.Columns[1].Name;

            foreach (DataRow item in dtSecim.Rows)
            {
                item[columnName] = KarakterDegistir(item[columnName].ToString().ToUpper());
            }

            //dtSecim.DefaultView.RowFilter = string.Format("[{0}] LIKE '%{1}%'", columnName, txtAra.Text);

            string kelime = txtAra.Text;

            kelime = KarakterDegistir(kelime);

            var resp = dtSecim.AsEnumerable().Where(x => x.Field<string>(columnName).Contains(kelime.ToUpper())).ToList();

            if (resp.Count > 0)
            {
                DataTable dts = resp.CopyToDataTable();
                DataTable dtsOrjinalValues = dts.Copy();
                dtsOrjinalValues.Rows.Clear();

                foreach (DataRow item in dts.Rows)
                {
                    string tempKod = item[column1].ToString();

                    var dt = dtParamsOrjinalValues.AsEnumerable().Where(x => x.Field<string>(column1) == tempKod).ToList();

                    if (dt.Count > 0)
                    {
                        DataRow dr = dtsOrjinalValues.NewRow();
                        dr[column1] = dt[0][0].ToString();
                        dr[columnName] = dt[0][1].ToString();

                        dtsOrjinalValues.Rows.Add(dr);
                    }
                }
                dtgSecim.DataSource = dtsOrjinalValues;
            }
            else
            {
                dtSecim.Rows.Clear();
                dtgSecim.DataSource = dtSecim;
            }

            if (dtgSecim.Rows.Count > 0)
            {
                for (int ix = 0; ix <= dtgSecim.Columns.Count - 1; ix++)
                {
                    dtgSecim.Columns[ix].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
                }
                setFormatGrid(dtgSecim, 0);

                dtgSecim.Columns[0].Visible = false;
            }
        }

        private string KarakterDegistir(string text)
        {
            string val = text;

            val = val.Replace("i", "I");
            val = val.Replace("İ", "I");
            val = val.Replace("ç", "C");
            val = val.Replace("Ç", "C");
            val = val.Replace("ş", "S");
            val = val.Replace("Ş", "S");
            val = val.Replace("Ü", "U");
            val = val.Replace("ü", "U");
            val = val.Replace("Ö", "O");
            val = val.Replace("ö", "O");
            val = val.Replace("Ğ", "G");
            val = val.Replace("ğ", "G");

            return val;
        }

        private void dtgSecim_DoubleClick(object sender, EventArgs e)
        {
            button1.PerformClick();
        }
    }
}
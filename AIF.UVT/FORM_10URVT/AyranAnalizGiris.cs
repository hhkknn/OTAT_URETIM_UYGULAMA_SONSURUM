using AIF.UVT.DatabaseLayer;
using AIF.UVT.UVTService;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class AyranAnalizGiris : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end.

        public AyranAnalizGiris(string _type, string _kullaniciid, string _rotaKodu, string _partiNo, string _uretimFisNo, string _urunTanimi, int _row, int _width, int _height)
        {
            kullaniciid = _kullaniciid;
            type = _type;

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

            initialFontSize = label6.Font.Size;
            label6.Resize += Form_Resize;

            //initialFontSize = label7.Font.Size;
            //label7.Resize += Form_Resize;

            //initialFontSize = label8.Font.Size;
            //label8.Resize += Form_Resize;

            //initialFontSize = label9.Font.Size;
            //label9.Resize += Form_Resize;

            //initialFontSize = label10.Font.Size;
            //label10.Resize += Form_Resize;

            //initialFontSize = label11.Font.Size;
            //label11.Resize += Form_Resize;

            //initialFontSize = label12.Font.Size;
            //label12.Resize += Form_Resize;

            //initialFontSize = label13.Font.Size;
            //label13.Resize += Form_Resize;

            //initialFontSize = label14.Font.Size;
            //label14.Resize += Form_Resize;

            //initialFontSize = label15.Font.Size;
            //label15.Resize += Form_Resize;

            initialFontSize = label16.Font.Size;
            label16.Resize += Form_Resize;

            //initialFontSize = label17.Font.Size;
            //label17.Resize += Form_Resize;

            //initialFontSize = label18.Font.Size;
            //label18.Resize += Form_Resize;

            //initialFontSize = label19.Font.Size;
            //label19.Resize += Form_Resize;

            initialFontSize = label20.Font.Size;
            label20.Resize += Form_Resize;

            //initialFontSize = label21.Font.Size;
            //label21.Resize += Form_Resize;

            //initialFontSize = label22.Font.Size;
            //label22.Resize += Form_Resize;

            //initialFontSize = label23.Font.Size;
            //label23.Resize += Form_Resize;

            //initialFontSize = label24.Font.Size;
            //label24.Resize += Form_Resize;

            //initialFontSize = label25.Font.Size;
            //label25.Resize += Form_Resize;

            //initialFontSize = label26.Font.Size;
            //label26.Resize += Form_Resize;

            //initialFontSize = label27.Font.Size;
            //label27.Resize += Form_Resize;

            //initialFontSize = label27.Font.Size;
            //label27.Resize += Form_Resize;

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

            initialFontSize = textBox6.Font.Size;
            textBox6.Resize += Form_Resize;

            initialFontSize = textBox7.Font.Size;
            textBox7.Resize += Form_Resize;

            initialFontSize = textBox8.Font.Size;
            textBox8.Resize += Form_Resize;

            initialFontSize = textBox9.Font.Size;
            textBox9.Resize += Form_Resize;

            initialFontSize = textBox10.Font.Size;
            textBox10.Resize += Form_Resize;

            initialFontSize = textBox11.Font.Size;
            textBox11.Resize += Form_Resize;

            initialFontSize = textBox13.Font.Size;
            textBox13.Resize += Form_Resize;

            initialFontSize = textBox14.Font.Size;
            textBox14.Resize += Form_Resize;

            initialFontSize = textBox15.Font.Size;
            textBox15.Resize += Form_Resize;

            initialFontSize = textBox17.Font.Size;
            textBox17.Resize += Form_Resize;

            initialFontSize = textBox18.Font.Size;
            textBox18.Resize += Form_Resize;

            initialFontSize = textBox19.Font.Size;
            textBox19.Resize += Form_Resize;

            initialFontSize = textBox20.Font.Size;
            textBox20.Resize += Form_Resize;

            initialFontSize = textBox22.Font.Size;
            textBox22.Resize += Form_Resize;

            initialFontSize = textBox23.Font.Size;
            textBox23.Resize += Form_Resize;

            initialFontSize = comboBox1.Font.Size;
            comboBox1.Resize += Form_Resize;

            initialFontSize = comboBox2.Font.Size;
            comboBox2.Resize += Form_Resize;

            initialFontSize = comboBox3.Font.Size;
            comboBox3.Resize += Form_Resize;

            initialFontSize = button1.Font.Size;
            button1.Resize += Form_Resize;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;

            initialFontSize = button3.Font.Size;
            button3.Resize += Form_Resize;

            initialFontSize = button10.Font.Size;
            button10.Resize += Form_Resize;

            //initialFontSize = dtgInkubasyon.Font.Size;
            //dtgInkubasyon.Resize += Form_Resize;

            //initialFontSize = dataGridView3.Font.Size;
            //dataGridView3.Resize += Form_Resize;
            //font end

            rotaKodu = _rotaKodu;
            partiNo = _partiNo;
            uretimFisNo = _uretimFisNo;
            urunTanimi = _urunTanimi;
            row = _row;
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

            label5.Font = new Font(label5.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label5.Font.Style);

            label6.Font = new Font(label6.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label6.Font.Style);

            //label7.Font = new Font(label7.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label7.Font.Style);

            //label8.Font = new Font(label8.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label8.Font.Style);

            //label9.Font = new Font(label9.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label9.Font.Style);

            //label10.Font = new Font(label10.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label10.Font.Style);

            //label11.Font = new Font(label11.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label11.Font.Style);

            //label12.Font = new Font(label12.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label12.Font.Style);

            //label13.Font = new Font(label13.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label13.Font.Style);

            //label14.Font = new Font(label14.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label14.Font.Style);

            //label15.Font = new Font(label15.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label15.Font.Style);

            label16.Font = new Font(label16.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label16.Font.Style);

            //label17.Font = new Font(label17.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label17.Font.Style);

            //label18.Font = new Font(label18.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label18.Font.Style);

            //label19.Font = new Font(label19.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label19.Font.Style);

            label20.Font = new Font(label20.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label20.Font.Style);

            //label21.Font = new Font(label21.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label21.Font.Style);

            //label22.Font = new Font(label22.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label22.Font.Style);

            //label23.Font = new Font(label23.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label23.Font.Style);

            //label24.Font = new Font(label24.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label24.Font.Style);

            //label25.Font = new Font(label25.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label25.Font.Style);

            //label26.Font = new Font(label26.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label26.Font.Style);

            //label27.Font = new Font(label27.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label27.Font.Style);

            //label28.Font = new Font(label28.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label28.Font.Style);

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

            textBox6.Font = new Font(textBox6.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox6.Font.Style);

            textBox7.Font = new Font(textBox7.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox7.Font.Style);

            textBox8.Font = new Font(textBox8.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox8.Font.Style);

            textBox9.Font = new Font(textBox9.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox9.Font.Style);

            textBox10.Font = new Font(textBox10.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox10.Font.Style);

            textBox11.Font = new Font(textBox11.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox11.Font.Style);

            textBox13.Font = new Font(textBox13.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox13.Font.Style);

            textBox14.Font = new Font(textBox14.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox14.Font.Style);

            textBox15.Font = new Font(textBox15.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox15.Font.Style);

            textBox17.Font = new Font(textBox17.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox17.Font.Style);

            textBox18.Font = new Font(textBox18.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox18.Font.Style);

            textBox19.Font = new Font(textBox19.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox19.Font.Style);

            textBox20.Font = new Font(textBox20.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox20.Font.Style);

            textBox22.Font = new Font(textBox22.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox22.Font.Style);

            textBox23.Font = new Font(textBox23.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox23.Font.Style);

            comboBox1.Font = new Font(comboBox1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               comboBox1.Font.Style);

            comboBox2.Font = new Font(comboBox2.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               comboBox2.Font.Style);

            comboBox3.Font = new Font(comboBox3.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               comboBox3.Font.Style);

            button1.Font = new Font(button1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button1.Font.Style);

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button2.Font.Style);

            button3.Font = new Font(button3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button3.Font.Style);

            button10.Font = new Font(button10.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button10.Font.Style);

            //dtgInkubasyon.Font = new Font(dtgInkubasyon.Font.FontFamily, initialFontSize *
            //    (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //    FontStyle.Bold);

            //dataGridView3.Font = new Font(dataGridView3.Font.FontFamily, initialFontSize *
            //    (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //    FontStyle.Bold);
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

        private string type = "";
        private string kullaniciid = "";
        private string rotaKodu = "";
        private string partiNo = "";
        private string uretimFisNo = "";
        private string urunTanimi = "";
        private int row = 0;

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

        private void AyranAnalizGiris_Load(object sender, EventArgs e)
        {
            //Center_Text();
            //button2.PerformClick();
            //button3.PerformClick();
            //button10.PerformClick();

            Library.Helper n = new Library.Helper();
            n.SetAllControlsFont(Controls);

            textBox1.Text = uretimFisNo;
            textBox2.Text = partiNo;
            textBox3.Text = urunTanimi;

            DataTable dt = new DataTable();
            string sql = "Select T0.\"U_Sicaklik\",T0.\"U_SicaklikSure\",\"U_SutSicakligi\",\"U_OnAktifSure\",\"U_OnAktifPH\",\"U_SutVakum\",\"U_TankAdi\",\"U_MayalamaSicaklik\",\"U_Sorumlu\",\"U_PompaBasinci\",\"U_BaslangicSaati\",\"U_BitisSaati\",\"U_TKM\",\"U_Protein\",\"U_Tuz\",\"U_Brix\",\"U_PH\",\"U_SH\",\"U_Yag\",\"U_TatKokuKivam\" from \"@AIF_AYR_ANALIZ\" AS T0 WITH (NOLOCK) where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            Connection.sql.Close();

            if (dt.Rows.Count > 0)
            {
                textBox4.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[0]).ToString("#.##");
                textBox5.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[1]).ToString("#.##");
                textBox6.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[2]).ToString("#.##");
                textBox7.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[3]).ToString("#.##");
                textBox8.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[4]).ToString("#.##");
                comboBox1.SelectedValue = dt.Rows[0].ItemArray[5].ToString();
                textBox10.Text = dt.Rows[0].ItemArray[6].ToString();
                textBox11.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[7]).ToString("#.##");
                comboBox2.SelectedValue = dt.Rows[0].ItemArray[8].ToString() == "" ? 0 : Convert.ToInt32(dt.Rows[0].ItemArray[8]);
                textBox13.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[9]).ToString("#.##");
                textBox14.Text = dt.Rows[0].ItemArray[10].ToString();
                textBox15.Text = dt.Rows[0].ItemArray[11].ToString();
                textBox17.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[12]).ToString("#.##");
                textBox18.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[13]).ToString("#.##");
                textBox19.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[14]).ToString("#.##");
                textBox20.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[15]).ToString("#.##");
                textBox9.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[16]).ToString("#.##");
                textBox22.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[17]).ToString("#.##");
                textBox23.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[18]).ToString("#.##");
                comboBox3.SelectedValue = dt.Rows[0].ItemArray[19].ToString();
            }

            dtMalzemeOzListele();
            dtSutOzListele();
            dtInkubasyonListele();

            foreach (DataGridViewColumn dgvc in dtgMalzemeOz.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn dgvc in dtgSutOz.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            foreach (DataGridViewColumn dgvc in dtgInkubasyon.Columns)
            {
                dgvc.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            //textBox4.Text = Convert.ToDecimal(dt.Rows[0].ItemArray[5]).ToString("#.##");
        }

        private SqlCommand cmd = null;

        private void button2_Click(object sender, EventArgs e)
        {
        }

        public class VarYok
        {
            public string Text { get; set; }

            public string Value { get; set; }
        }

        public class IyiKotu
        {
            public string Text { get; set; }

            public string Value { get; set; }
        }

        private void dtMalzemeOzListele()
        {
            //string sql = "Select T1.\"ItemCode\" as \"Malzeme Kodu\",T1.\"Dscription\" as \"Malzeme Tanımı\", SUM(T1.\"Quantity\") as \"Miktar\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where \"U_BatchNumber\" = '" + partiNo + "' group by T1.\"ItemCode\",T1.\"Dscription\"";

            string sql = "SELECT T0.[ItemCode] as \"Malzeme Kodu\", T0.[ItemName] as \"Malzeme Tanımı\", T0.[BatchNum] as \"Parti\", T0.[Quantity] as \"Miktar\" FROM IBT1 T0 WITH (NOLOCK) left join OIGE T1 WITH (NOLOCK) on T0.[BaseEntry] = T1.[DocNum] WHERE T0.[BaseType] = 60 and  T1.[U_BatchNumber] ='" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            DataTable dttemp = new DataTable();
            sda.Fill(dt);

            //Commit
            dtgMalzemeOz.DataSource = dt;
            dtgMalzemeOz.Columns["Miktar"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgMalzemeOz.Columns["Miktar"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dtgMalzemeOz.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgMalzemeOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgMalzemeOz.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dtgMalzemeOz.EnableHeadersVisualStyles = false;
            dtgMalzemeOz.DefaultCellStyle.BackColor = Color.LightGray;
            foreach (DataGridViewColumn col in dtgMalzemeOz.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            for (int ix = 0; ix <= dtgMalzemeOz.Columns.Count - 1; ix++)
            {
                dtgMalzemeOz.Columns[ix].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }
        }

        private void dtSutOzListele()
        {
            DataTable dt = new DataTable();
            string sql = "Select T1.\"U_Brix\" as \"Brix\",T1.\"U_PH\" as \"PH\",T1.\"U_SH\" as \"SH\",T1.\"U_Yag\" as \"Yağ\",T1.\"U_Kaynak\" as \"KaynakNoDB\" from \"@AIF_AYR_ANALIZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYR_ANALIZ1\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dt);

            sql = "Select TOP 1 '' as \"WhsCode\", '' as \"WhsName\" from OWHS WITH (NOLOCK) where \"Inactive\" = 'N'";
            sql += " UNION ALL ";
            sql += "Select \"WhsCode\",\"WhsName\" from OWHS WITH (NOLOCK) where \"Inactive\" = 'N'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            sda = new SqlDataAdapter(cmd);
            DataTable dtOwhs = new DataTable();
            sda.Fill(dtOwhs);

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();
            if (dtgSutOz.Columns.Contains("KaynakNo") != true)
            {
                column.Name = "KaynakNo";
                column.DataSource = dtOwhs.AsEnumerable()
                 .Select(row => new
                 {
                     Text = row["WhsName"],
                     Value = row["WhsCode"]
                 })
                .ToList();
                column.DisplayMember = "Text";
                column.ValueMember = "Value";

                dtgSutOz.Columns.Add(column);
            }

            dtgSutOz.DataSource = dt;
            dtgSutOz.Columns["KaynakNoDB"].Visible = false;
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {
                dtgSutOz.Rows[i].Cells["KaynakNo"].Value = dr["KaynakNoDB"];
                i++;
            }

            //DataGridViewColumn ColumnKaynakNo = dtgSutOz.Columns[0];
            //ColumnKaynakNo.Width = 300;

            for (int x = 0; x < dtgSutOz.Columns.Count; x++)
            {
                string colName = dtgSutOz.Columns[x].Name;
                if (colName != "KaynakNo")
                {
                    dtgSutOz.Columns[x].ReadOnly = true;
                }
            }

            dtgSutOz.Columns["Brix"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutOz.Columns["Brix"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgSutOz.Columns["PH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutOz.Columns["PH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgSutOz.Columns["SH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutOz.Columns["SH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgSutOz.Columns["Yağ"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgSutOz.Columns["Yağ"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            DataGridViewButtonColumn RemoveLineButton = new DataGridViewButtonColumn();
            if (dtgSutOz.Columns.Contains("Sil") != true)
            {
                RemoveLineButton.Name = "Sil";
                RemoveLineButton.Text = "Sil";
                if (dtgSutOz.Columns["removeButton"] == null)
                {
                    dtgSutOz.Columns.Insert(dtgSutOz.Columns.Count, RemoveLineButton);
                }
            }

            for (int ix = 0; ix <= dtgSutOz.Columns.Count - 1; ix++)
            {
                dtgSutOz.Columns[ix].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dtgSutOz.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgSutOz.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgSutOz.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dtgSutOz.EnableHeadersVisualStyles = false;
            dtgSutOz.DefaultCellStyle.BackColor = Color.LightGray;
            foreach (DataGridViewColumn col in dtgSutOz.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 14F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            DataGridViewColumn ColumnKaynakNo = null;

            ColumnKaynakNo = dtgSutOz.Columns["Sil"];
            ColumnKaynakNo.Width = 50;

            ColumnKaynakNo = dtgSutOz.Columns[0];
            ColumnKaynakNo.Width = 200;
        }

        private void dtInkubasyonListele()
        {
            DataTable dt = new DataTable();
            DataTable dtMain = new DataTable();
            string sql = "Select T1.\"U_InkubasyonNo\" as \"InkubasyonNo\",T1.\"U_Saat\" as \"Saat\",T1.\"U_Sicaklik\" as \"Sicaklik\",T1.\"U_PH\" as \"PH\",\"U_KontrolEden\" as \"KontrolEdenDB\" from \"@AIF_AYR_ANALIZ\" AS T0 WITH (NOLOCK) INNER JOIN \"@AIF_AYR_ANALIZ2\" as T1 WITH (NOLOCK) ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_PartiNo\" = '" + partiNo + "'";
            cmd = new SqlCommand(sql, Connection.sql);

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            dt = new DataTable();
            sda.Fill(dtMain);

            dtgInkubasyon.DataSource = dtMain;

            sql = "SELECT TOP 1 '' as empID, '' as Name from \"OHEM\" WITH (NOLOCK)";
            sql += " UNION ALL ";
            sql += "SELECT \"empID\",(\"firstName\" + ' ' + \"LastName\") as Name from \"OHEM\" WITH (NOLOCK) where \"Active\" = 'Y'";
            cmd = new SqlCommand(sql, Connection.sql);

            if (Connection.sql.State != ConnectionState.Open)
                Connection.sql.Open();

            sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);

            DataGridViewComboBoxColumn column = new DataGridViewComboBoxColumn();

            if (dtgInkubasyon.Columns.Contains("KontrolEden") != true)
            {
                column = new DataGridViewComboBoxColumn();
                column.Name = "KontrolEden";
                column.DataSource = dt.AsEnumerable()
                 .Select(row => new
                 {
                     Text = row["Name"],
                     Value = row["empID"]
                 })
                .ToList();
                column.DisplayMember = "Text";
                column.ValueMember = "Value";
                dtgInkubasyon.Columns.Add(column);
            }

            dt.Rows.Add("0", " ");
            var dt2 = dt.AsEnumerable()
             .Select(row => new
             {
                 Text = row["Name"],
                 Value = row["empID"]
             })
            .ToList().OrderBy(x => x.Value);
            comboBox2.DataSource = dt2.ToList();

            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";

            List<VarYok> varyok = new List<VarYok>();
            varyok.Add(new VarYok { Text = "", Value = "0" });
            varyok.Add(new VarYok { Text = "Var", Value = "1" });
            varyok.Add(new VarYok { Text = "Yok", Value = "2" });

            comboBox1.DataSource = varyok;

            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            List<IyiKotu> IyiKotu = new List<IyiKotu>();
            IyiKotu.Add(new IyiKotu { Text = "", Value = "0" });
            IyiKotu.Add(new IyiKotu { Text = "İyi", Value = "1" });
            IyiKotu.Add(new IyiKotu { Text = "Kötü", Value = "2" });

            comboBox3.DataSource = IyiKotu;

            comboBox3.DisplayMember = "Text";
            comboBox3.ValueMember = "Value";

            //dtgInkubasyon.Columns.AddRange(name, money);

            DataGridViewButtonColumn RemoveLineButton = new DataGridViewButtonColumn();
            if (dtgInkubasyon.Columns.Contains("Sil") != true)
            {
                RemoveLineButton.Name = "Sil";
                RemoveLineButton.Text = "Sil";
                if (dtgInkubasyon.Columns["removeButton"] == null)
                {
                    dtgInkubasyon.Columns.Insert(dtgInkubasyon.Columns.Count, RemoveLineButton);
                }
            }
            int i = 0;
            foreach (DataRow dr in dtMain.Rows)
            {
                dtgInkubasyon.Rows[i].Cells["InkubasyonNo"].Value = (i + 1).ToString();
                dtgInkubasyon.Rows[i].Cells["KontrolEden"].Value = Convert.ToInt32(dr["KontrolEdenDB"]);
                i++;
            }

            for (int x = 0; x < dtgInkubasyon.Columns.Count; x++)
            {
                string colName = dtgInkubasyon.Columns[x].Name;
                if (colName != "KontrolEden" || colName == "Sil")
                {
                    dtgInkubasyon.Columns[x].ReadOnly = true;
                }
            }

            dtgInkubasyon.Columns["KontrolEdenDB"].Visible = false;
            dtgInkubasyon.Columns["Sicaklik"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgInkubasyon.Columns["Sicaklik"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            dtgInkubasyon.Columns["PH"].DefaultCellStyle.Format = "N" + Giris.OndalikMiktar;
            dtgInkubasyon.Columns["PH"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;

            for (int ix = 0; ix <= dtgInkubasyon.Columns.Count - 1; ix++)
            {
                dtgInkubasyon.Columns[ix].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            }

            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            dtgInkubasyon.Font = new System.Drawing.Font("Bahnschrift", Font.Size + 5, FontStyle.Bold);
            dtgInkubasyon.DefaultCellStyle.WrapMode = DataGridViewTriState.True;

            dtgInkubasyon.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dtgInkubasyon.EnableHeadersVisualStyles = false;
            dtgInkubasyon.DefaultCellStyle.BackColor = Color.LightGray;

            foreach (DataGridViewColumn col in dtgInkubasyon.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Bahnschrift", 14, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            DataGridViewColumn ColumnInkubasyonNo = dtgInkubasyon.Columns["KontrolEden"];
            ColumnInkubasyonNo.Width = 250;
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button10_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight);
            banaAitİsler.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var value = dtgInkubasyon.Rows[0].Cells["KontrolEden"].Value;

            try
            {
                UVTServiceSoapClient client = new UVTServiceSoapClient();
                AyranAnalizTakibi nesne = new AyranAnalizTakibi();
                MayalanacakSutOzellikleri mayalanacakSutOzellikleri = new MayalanacakSutOzellikleri();
                List<MayalanacakSutOzellikleri> mayalanacakSutOzellikleris = new List<MayalanacakSutOzellikleri>();
                Inkubasyon inkubasyon = new Inkubasyon();
                List<Inkubasyon> inkubasyons = new List<Inkubasyon>();

                nesne.DocEntry = textBox1.Text == "" ? 0 : Convert.ToInt32(textBox1.Text);
                nesne.PartiNo = textBox2.Text;
                nesne.PastorizasyonSicaklik = textBox4.Text == "" ? 0 : Convert.ToDouble(textBox4.Text);
                nesne.PastorizasyonSure = textBox5.Text == "" ? 0 : Convert.ToDouble(textBox5.Text);
                nesne.OnAktiflestirmeSutSicakligi = textBox6.Text == "" ? 0 : Convert.ToDouble(textBox6.Text);
                nesne.OnAktifPH = textBox7.Text == "" ? 0 : Convert.ToDouble(textBox7.Text);
                nesne.OnAktifSuresi = textBox8.Text == "" ? 0 : Convert.ToDouble(textBox8.Text);
                if (comboBox1.SelectedValue != null)
                {
                    nesne.SutVakum = comboBox1.SelectedValue.ToString();
                }
                nesne.TankAdi = textBox10.Text;
                nesne.MayalamaTankiSicaklik = textBox11.Text == "" ? 0 : Convert.ToDouble(textBox11.Text);
                if (comboBox2.SelectedValue != null)
                {
                    nesne.Sorumlu = comboBox2.SelectedValue.ToString();
                    nesne.SorumluAdi = comboBox2.GetItemText(comboBox2.SelectedItem);
                }

                nesne.PompaBasinci = textBox13.Text == "" ? 0 : Convert.ToDouble(textBox13.Text);
                nesne.BaslangicSaati = textBox14.Text == "" ? 0 : Convert.ToInt32(textBox14.Text);
                nesne.BitisSaati = textBox15.Text == "" ? 0 : Convert.ToInt32(textBox15.Text);

                nesne.TKM = textBox17.Text == "" ? 0 : Convert.ToDouble(textBox17.Text);
                nesne.Protein = textBox18.Text == "" ? 0 : Convert.ToDouble(textBox18.Text);
                nesne.Tuz = textBox19.Text == "" ? 0 : Convert.ToDouble(textBox19.Text);
                nesne.Brix = textBox20.Text == "" ? 0 : Convert.ToDouble(textBox20.Text);
                nesne.PH = textBox9.Text == "" ? 0 : Convert.ToDouble(textBox9.Text);
                nesne.SH = textBox22.Text == "" ? 0 : Convert.ToDouble(textBox22.Text);
                nesne.Yag = textBox23.Text == "" ? 0 : Convert.ToDouble(textBox23.Text);

                if (comboBox3.SelectedValue != null)
                {
                    nesne.TatKokuKivam = comboBox3.SelectedValue.ToString();
                }

                foreach (DataGridViewRow dr in dtgSutOz.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["KaynakNo"].Value != null))
                {
                    mayalanacakSutOzellikleri.Kaynak = dr.Cells["KaynakNo"].Value.ToString().NothingToString();
                    mayalanacakSutOzellikleri.KaynakAdi = "";
                    mayalanacakSutOzellikleri.PH = dr.Cells["PH"].Value == null ? 0 : Convert.ToDouble(dr.Cells["PH"].Value);
                    mayalanacakSutOzellikleri.SH = dr.Cells["SH"].Value == null ? 0 : Convert.ToDouble(dr.Cells["SH"].Value);
                    mayalanacakSutOzellikleri.Brix = dr.Cells["Brix"].Value == null ? 0 : Convert.ToDouble(dr.Cells["Brix"].Value);
                    mayalanacakSutOzellikleri.Yag = dr.Cells["Yağ"].Value == null ? 0 : Convert.ToDouble(dr.Cells["Yağ"].Value);

                    mayalanacakSutOzellikleris.Add(mayalanacakSutOzellikleri);
                    mayalanacakSutOzellikleri = new MayalanacakSutOzellikleri();
                }

                nesne.MayalanacakSutOzellikleri = mayalanacakSutOzellikleris.ToArray();

                int i = 0;
                foreach (DataGridViewRow drw in dtgInkubasyon.Rows.Cast<DataGridViewRow>().Where(x => x.Cells["InkubasyonNo"].Value != null && x.Cells["PH"].Value != null))
                {
                    inkubasyon.InkubasyonNo = drw.Cells["InkubasyonNo"].Value == null ? 0 : Convert.ToInt32(drw.Cells["InkubasyonNo"].Value);
                    inkubasyon.Saat = drw.Cells["Saat"].Value == null ? 0 : Convert.ToInt32(drw.Cells["Saat"].Value);
                    inkubasyon.PH = drw.Cells["PH"].Value == null ? 0 : Convert.ToDouble(drw.Cells["PH"].Value);
                    inkubasyon.Sicaklik = drw.Cells["Sicaklik"].Value == null ? 0 : Convert.ToDouble(drw.Cells["Sicaklik"].Value);
                    if (dtgInkubasyon.Rows[i].Cells["KontrolEden"].Value != null)
                    {
                        inkubasyon.KontrolEdenNo = dtgInkubasyon.Rows[i].Cells["KontrolEden"].Value.ToString();
                        inkubasyon.KontrolEdenAdi = Convert.ToString((dtgInkubasyon.Rows[i].Cells["KontrolEden"] as DataGridViewComboBoxCell).FormattedValue.ToString());
                    }
                    inkubasyons.Add(inkubasyon);

                    inkubasyon = new Inkubasyon();
                    i++;
                }

                nesne.Inkubasyon = inkubasyons.ToArray();

                var resp = client.AddOrUpdateAyranAnalizTakibi(nesne, Giris.dbName, Giris.mKodValue);

                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");

                if (resp.Value == 0)
                {
                    button1.PerformClick();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Onaylama işlemi yapılırken hata oluştu. Hata Kodu: AYRNANLZ001 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void textBox4_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox4);
            nesne.ShowDialog();
        }

        private void textBox5_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox5);
            nesne.ShowDialog();
        }

        private void textBox6_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox6);
            nesne.ShowDialog();
        }

        private void textBox7_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox7);
            nesne.ShowDialog();
        }

        private void textBox8_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox8);
            nesne.ShowDialog();
        }

        private void textBox11_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox11);
            nesne.ShowDialog();
        }

        private void textBox13_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox13);
            nesne.ShowDialog();
        }

        private void textBox14_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox14);
            nesne.ShowDialog();
        }

        private void textBox15_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox15);
            nesne.ShowDialog();
        }

        private void textBox17_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox17);
            nesne.ShowDialog();
        }

        private void textBox18_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox18);
            nesne.ShowDialog();
        }

        private void textBox19_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox19);
            nesne.ShowDialog();
        }

        private void textBox20_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox20);
            nesne.ShowDialog();
        }

        private void textBox9_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox9);
            nesne.ShowDialog();
        }

        private void textBox22_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox22);
            nesne.ShowDialog();
        }

        private void textBox23_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(textBox23);
            nesne.ShowDialog();
        }

        private void dtgSutOz_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dtgSutOz.Columns[e.ColumnIndex].Name != "KaynakNo" && dtgSutOz.Columns[e.ColumnIndex].Name != "Sil")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgSutOz);
                    n.ShowDialog();
                }
            }
        }

        private void dtgSutOz_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
        }

        private void dtgSutOz_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    dtgSutOz.Rows.RemoveAt(e.RowIndex);
                }
            }
            catch (Exception)
            {
            }
        }

        private void dtgInkubasyon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dtgInkubasyon.Columns[e.ColumnIndex].Name != "InkubasyonNo" && dtgInkubasyon.Columns[e.ColumnIndex].Name != "KontrolEden" && dtgInkubasyon.Columns[e.ColumnIndex].Name != "Sil")
                {
                    SayiKlavyesiNew n = new SayiKlavyesiNew(null, dtgInkubasyon);
                    n.ShowDialog();
                }
            }
        }

        private void dtgInkubasyon_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                dtgInkubasyon.Rows[dtgInkubasyon.Rows.Count - 1].Cells["InkubasyonNo"].Value = dtgInkubasyon.Rows.Count;
            }
            catch (Exception)
            {
            }
        }

        private void dtgInkubasyon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dtgInkubasyon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                    e.RowIndex >= 0)
                {
                    dtgInkubasyon.Rows.RemoveAt(e.RowIndex);

                    for (int i = 0; i < dtgInkubasyon.Rows.Count; i++)
                    {
                        dtgInkubasyon.Rows[i].Cells["InkubasyonNo"].Value = (i + 1).ToString();
                    }
                }
            }
            catch (Exception)
            {
            }
        }
    }

    public static class Extensions
    {
        public static string NothingToString(this String obj)
        {
            if (obj == null)
                return "";
            else
                return obj.ToString();
        }

        public static object intToNull(this int obj)
        {
            if (obj == 0)
                return DBNull.Value.ToString();
            else
                return obj;
        }

        public static object doubleToNull(this double obj)
        {
            if (obj == 0)
                return 0;
            else
                return obj;
        }
    }
}
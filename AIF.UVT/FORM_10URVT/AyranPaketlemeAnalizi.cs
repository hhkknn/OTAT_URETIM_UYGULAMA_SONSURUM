using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class AyranPaketlemeAnalizi : Form
    {
        //font start
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //font end.

        public AyranPaketlemeAnalizi(string _type, string _kullaniciid, int _row, int _width, int _height)
        {
            kullaniciid = _kullaniciid;
            type = _type;
            row = _row;

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

            initialFontSize = label7.Font.Size;
            label7.Resize += Form_Resize;

            initialFontSize = label8.Font.Size;
            label8.Resize += Form_Resize;

            initialFontSize = label9.Font.Size;
            label9.Resize += Form_Resize;

            initialFontSize = label10.Font.Size;
            label10.Resize += Form_Resize;

            initialFontSize = label11.Font.Size;
            label11.Resize += Form_Resize;

            //initialFontSize = label12.Font.Size;
            //label12.Resize += Form_Resize;

            //initialFontSize = label13.Font.Size;
            //label13.Resize += Form_Resize;

            initialFontSize = label14.Font.Size;
            label14.Resize += Form_Resize;

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

            //initialFontSize = textBox12.Font.Size;
            //textBox12.Resize += Form_Resize;

            //initialFontSize = textBox13.Font.Size;
            //textBox13.Resize += Form_Resize;

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

            label7.Font = new Font(label7.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label7.Font.Style);

            label8.Font = new Font(label8.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label8.Font.Style);

            label9.Font = new Font(label9.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label9.Font.Style);

            label10.Font = new Font(label10.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label10.Font.Style);

            label11.Font = new Font(label11.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label11.Font.Style);

            //label12.Font = new Font(label12.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label12.Font.Style);

            //label13.Font = new Font(label13.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   label13.Font.Style);

            label14.Font = new Font(label14.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label14.Font.Style);

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

            //textBox12.Font = new Font(textBox12.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   textBox12.Font.Style);

            //textBox13.Font = new Font(textBox13.Font.FontFamily, initialFontSize *
            //   (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
            //   textBox13.Font.Style);

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
        private string type = "";
        private string kullaniciid = "";
        private int row = 0;

        private void AyranPaketlemeAnalizi_Load(object sender, EventArgs e)
        {
            dtPaketAyran.Columns.Add("KontrolNo", "Kontrol No");
            dtPaketAyran.Columns.Add("KontPer", "Kontrol Personeli");
            dtPaketAyran.Columns.Add("KontSaat", "Kontrol Saati");
            dtPaketAyran.Columns.Add("PompaBasBar", "Pompa Basıncı (Bar)");
            dtPaketAyran.Columns.Add("KonEdPalNo", "Kont. Ed. Palet No");
            dtPaketAyran.Columns.Add("KonEdPalUrAd", "Kont. Ed. Ürün Adı");
            dtPaketAyran.Columns.Add("AyranSicakligi", "Ayran Sıcaklığı");
            dtPaketAyran.Columns.Add("AyranViskozitesi", "Ayran Viskozitesi");
            dtPaketAyran.Columns.Add("PH", "PH");
            dtPaketAyran.Columns.Add("TatKokuKivam", "Tat,Koku,Kıvam");

            dtPaketAyran.Rows.Insert(0, "1", "Nazan yyy", "9:00", "1,8", "1", "175 ML Otat Yarım Yağlı Ayran", "8", "25", "4,36", "OK");
            dtPaketAyran.Rows.Insert(1, "2", "Nazan yyy", "9:30", "1,5", "5", "175 ML Otat Yarım Yağlı Ayran", "7,7", "23", "4,3", "LİKİT");
            dtPaketAyran.Rows.Insert(2, "3", "Nazan yyy", "10:16", "1,5", "11", "175 ML Otat Yarım Yağlı Ayran", "8,3", "22", "4,34", "LİKİT");

            dtPaketAyran.RowHeadersVisible = false;
            int x = 0;
            foreach (DataGridViewRow row in dtPaketAyran.Rows)
            {
                if (row != null && x == 1)
                    row.DefaultCellStyle.BackColor = Color.DarkSeaGreen;
                else if (row != null && x == 2)
                    row.DefaultCellStyle.BackColor = Color.Red;

                x++;
            }

            dtPaketAyran.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
            dtPaketAyran.EnableHeadersVisualStyles = false;
            dtPaketAyran.DefaultCellStyle.BackColor = Color.LightGray;

            foreach (DataGridViewColumn col in dtPaketAyran.Columns)
            {
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            }

            for (int i = 0; i < dtPaketAyran.Columns.Count; i++)
            {
                if (i == 0)
                    dtPaketAyran.Columns[i].Width = 50;
                else
                    dtPaketAyran.Columns[i].Width = 130;
            }

            Library.Helper n = new Library.Helper();
            n.SetAllControlsFont(Controls);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BanaAitİsler banaAitİsler = new BanaAitİsler(type, kullaniciid, row, initialWidth, initialHeight);
            banaAitİsler.Show();
            Close();
        }
    }
}
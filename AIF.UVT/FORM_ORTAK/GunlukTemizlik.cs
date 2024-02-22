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
    public partial class GunlukTemizlik : Form
    {
        //font start
        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;
        //font end

        public GunlukTemizlik(int _width, int _height)
        {
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = _width;
            initialHeight = _height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = label12.Font.Size;
            label12.Resize += Form_Resize;

            initialFontSize = label13.Font.Size;
            label13.Resize += Form_Resize;

            initialFontSize = textBox1.Font.Size;
            textBox1.Resize += Form_Resize;

            initialFontSize = textBox12.Font.Size;
            textBox12.Resize += Form_Resize;

            initialFontSize = textBox13.Font.Size;
            textBox13.Resize += Form_Resize;

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

            label12.Font = new Font(label12.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label12.Font.Style);

            label13.Font = new Font(label13.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               label13.Font.Style);

            textBox1.Font = new Font(textBox1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox1.Font.Style);

            textBox12.Font = new Font(textBox12.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox12.Font.Style);

            textBox13.Font = new Font(textBox13.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox13.Font.Style);

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

        private void GunlukTemizlik_Load(object sender, EventArgs e)
        {
            try
            {
                dtGunlukTemizlik.Columns.Add("#", "#");
                dtGunlukTemizlik.Columns.Add("TemizAlan", "Temizlenen Alan / Makine");
                dtGunlukTemizlik.Columns.Add("Siklik", "Sıklık");
                dtGunlukTemizlik.Columns.Add("KulMalzeme", "Kullanılan Malzeme");
                dtGunlukTemizlik.Columns.Add("KulKimyasal", "Kullanılan Kimyasal");
                dtGunlukTemizlik.Columns.Add("TemizlikKont", "Temizlik Kontrolü");
                dtGunlukTemizlik.Columns.Add("TemizlikPers", "Temizlik Personeli");
                dtGunlukTemizlik.Columns.Add("KontrolPers", "Kontrol Personeli");

                dtGunlukTemizlik.Rows.Insert(0, "1", "Paslanmaz malzemeler (Teraziler, Bıçaklar, Kaşıklar ve Küçük Ekipmanlar", "Her Gün", "Sünger", "Deterjan", "OK");

                dtGunlukTemizlik.ColumnHeadersDefaultCellStyle.BackColor = Color.Gray;
                dtGunlukTemizlik.EnableHeadersVisualStyles = false;
                dtGunlukTemizlik.DefaultCellStyle.BackColor = Color.LightGray;

                foreach (DataGridViewColumn col in dtGunlukTemizlik.Columns)
                {
                    col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    col.HeaderCell.Style.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Pixel);
                }

                dtGunlukTemizlik.Rows.Insert(1, "2", "Ayran Üretim Alanı (Duvarlar, Tavanlar ve Zeminler)", "Her üretim öncesi ve sonrası", "Fırça", "Topax", "OK");
                dtGunlukTemizlik.Rows.Insert(2, "3", "Ayran Üretim Alanı Havası", "Her üretim öncesi ve sonrası", "-", "Ozonit", "OK");
                dtGunlukTemizlik.Rows.Insert(3, "4", "Ayran Cep Depo (Duvarlar ve Zeminler)", "Her üretim öncesi ve sonrası", "", "", "YAPILMADI");
                dtGunlukTemizlik.Rows.Insert(4, "5", "Ayran Cep Depo Alanı Havası", "Her üretim öncesi ve sonrası", "", "", "YAPILMADI");
                dtGunlukTemizlik.Rows.Insert(5, "6", "75 Çap Ayran Dolum Makinesi", "Hergün", "", "", "YAPILMADI");

                dtGunlukTemizlik.RowHeadersVisible = false;
                for (int i = 0; i < dtGunlukTemizlik.Columns.Count; i++)
                {
                    if (i == 0)
                        dtGunlukTemizlik.Columns[i].Width = 35;
                    else
                        dtGunlukTemizlik.Columns[i].Width = 300;
                }

                //dtGunlukTemizlik.AutoResizeRowHeadersWidth(DataGridViewRowHeadersWidthSizeMode);

                //dtGunlukTemizlik.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                //dtGunlukTemizlik.DefaultCellStyle.WrapMode = DataGridViewTriState.True;
                //dtGunlukTemizlik.AllowUserToResizeColumns = false;
                System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
                dtGunlukTemizlik.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.790F);

                //dtGunlukTemizlik.ScrollBars = ScrollBars.None;

                Library.Helper n = new Library.Helper();
                n.SetAllControlsFont(Controls);
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Günlük Temizlik Ekranı açılırken hata oluştu. Hata Kodu: GNLK001 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            AtanmisIsler atanmisIsler = new AtanmisIsler("", null, null, initialWidth, initialHeight);
            atanmisIsler.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
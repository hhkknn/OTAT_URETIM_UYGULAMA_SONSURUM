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
    public partial class SaatTarihGirisi : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end.

        public SaatTarihGirisi(DataGridView _dtgridParams = null, bool _goruntuModu = false)
        {
            //goruntumodu verisi true gönderilirse saat değiştirilemez sadece ekranda gelen saat seçilebilir olması için yazıldı.
            goruntuModu = _goruntuModu;
            dtgridParams = _dtgridParams;
            //bekleyenPersonels = _bekleyenPersonels;

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

            initialFontSize = button5.Font.Size;
            button5.Resize += Form_Resize;

            initialFontSize = button6.Font.Size;
            button6.Resize += Form_Resize;

            initialFontSize = button6.Font.Size;
            button6.Resize += Form_Resize;
            //font end
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            // Yeniden boyutlandırma oranını alır
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            // Geçerli yazı tipi boyutunu hesaplar
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

            button5.Font = new Font(button5.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button5.Font.Style);

            button6.Font = new Font(button6.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button6.Font.Style);
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

        private DataGridView dtgridParams = null;
        private bool goruntuModu = false;
        private List<Tuple<int, string, string, string, string>> bekleyenPersonels = new List<Tuple<int, string, string, string, string>>();
        private List<Tuple<string, int>> aktiveParams = new List<Tuple<string, int>>();
        private DataTable dtAktiviteParam = new DataTable();
        private DateTime sistemSaati = DateTime.Now;

        private void SaatTarihGirisi_Load(object sender, EventArgs e)
        {
            try
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

                sistemSaati = DateTime.Now;
                richTextBox1.Text = DateTime.Now.Hour.ToString().PadLeft(2, '0');
                richTextBox2.Text = DateTime.Now.Minute.ToString().PadLeft(2, '0');

                richTextBox1.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

                richTextBox2.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox2.SelectionAlignment = HorizontalAlignment.Center;

                if (goruntuModu)
                {
                    button1.Enabled = false;
                    button2.Enabled = false;
                    button3.Enabled = false;
                    button4.Enabled = false;
                }
                //aktiveParams = getTolerans();
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Saat Tarih Giriş ekranı açılırken hata oluştu. Hata Kodu: STTA001  " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int saat = Convert.ToInt32(richTextBox1.Text);
                saat = saat + 1;
                int sistemsaati = sistemSaati.Hour;
                int result = saat - sistemsaati;
                //int tolerans = aktiveParams.Where(x => x.Item1 == "Saat").Count() > 0 ? aktiveParams.Where(x => x.Item1 == "Saat").Select(y => y.Item2).FirstOrDefault() : 0;

                //if (result > tolerans)
                //{
                //    MessageBox.Show("Tolerans süreniz " + tolerans + " saat kadardır. Daha fazla yükseltilemez.");
                //    return;
                //}
                ////else if (tolerans < result)
                ////{
                ////    MessageBox.Show("Tolerans süreniz " + tolerans + " saat kadardır. Daha fazla düşürülemez.");
                ////    return;
                ////}

                //if (saat == 24)
                //{
                //    saat = 00;
                //}

                richTextBox1.Text = saat.ToString().PadLeft(2, '0');

                richTextBox1.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: STTA002 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int saat = Convert.ToInt32(richTextBox1.Text);
                saat = saat - 1;
                int sistemsaati = sistemSaati.Hour;
                int result = Math.Abs(saat - sistemsaati);
                //int tolerans = aktiveParams.Where(x => x.Item1 == "Saat").Count() > 0 ? aktiveParams.Where(x => x.Item1 == "Saat").Select(y => y.Item2).FirstOrDefault() : 0;

                //if (tolerans < result)
                //{
                //    MessageBox.Show("Tolerans süreniz " + tolerans + " saat kadardır. Daha fazla düşürülemez.");
                //    return;
                //}

                if (saat == -1)
                {
                    saat = 23;
                }

                richTextBox1.Text = saat.ToString().PadLeft(2, '0');

                richTextBox1.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: STTA03 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                int dakika = Convert.ToInt32(richTextBox2.Text);
                dakika = dakika + 1;
                int sistemdakikasi = sistemSaati.Minute;
                int result = Math.Abs(dakika - sistemdakikasi);
                //int tolerans = aktiveParams.Where(x => x.Item1 == "Dakika").Count() > 0 ? aktiveParams.Where(x => x.Item1 == "Dakika").Select(y => y.Item2).FirstOrDefault() : 0;

                //if (result > tolerans)
                //{
                //    MessageBox.Show("Tolerans süreniz " + tolerans + " dakika kadardır. Daha fazla yükseltilemez.");
                //    return;
                //}

                if (dakika == 60)
                {
                    dakika = 00;
                }

                richTextBox2.Text = dakika.ToString().PadLeft(2, '0');
                richTextBox2.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: STTA04 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int dakika = Convert.ToInt32(richTextBox2.Text);
                dakika = dakika - 1;
                int sistemdakikasi = sistemSaati.Minute;
                int result = Math.Abs(dakika - sistemdakikasi);
                //int tolerans = aktiveParams.Where(x => x.Item1 == "Dakika").Count() > 0 ? aktiveParams.Where(x => x.Item1 == "Dakika").Select(y => y.Item2).FirstOrDefault() : 0;

                //if (tolerans < result)
                //{
                //    MessageBox.Show("Tolerans süreniz " + tolerans + " dakika kadardır. Daha fazla düşürülemez.");
                //    return;
                //}

                if (dakika == -1)
                {
                    dakika = 59;
                }

                richTextBox2.Text = dakika.ToString().PadLeft(2, '0');
                richTextBox2.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox2.SelectionAlignment = HorizontalAlignment.Center;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: STTA05 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        public List<Tuple<string, int>> getTolerans()
        {
            try
            {
                string sql = "Select \"U_Hour\",\"U_Minute\" from \"@AIF_UVT_ACTPARAM\" WITH (NOLOCK)";
                SqlCommand cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dtAktiviteParam);

                var akt = dtAktiviteParam.Select().ToList();

                //int hou

                List<Tuple<string, int>> ret = new List<Tuple<string, int>>();
                ret.Add(Tuple.Create("Saat", Convert.ToInt32(akt[0].ItemArray[0])));
                ret.Add(Tuple.Create("Dakika", Convert.ToInt32(akt[0].ItemArray[1])));
                return ret;
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("İşlem sırasında hata oluştu. Hata Kodu: STTA06 " + ex.Message, "UYARI", "TAMAM");
            }

            return null;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dialogResult = "Ok";
            saat = richTextBox1.Text;
            dakika = richTextBox2.Text;
            var sonuc = saat + ":" + dakika;
            dtgridParams.CurrentCell.Value = Convert.ToString(sonuc);

            Close();
        }

        public static string dialogResult = "";

        public static string saat = "";

        public static string dakika = "";

        public class BekleyenPersonel
        {
            public int sira { get; set; }
            public string empid { get; set; }
        }
    }
}
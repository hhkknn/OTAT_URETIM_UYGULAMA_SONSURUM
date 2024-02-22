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
    public partial class TarihGirisi : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end.

        public TarihGirisi(DataGridView _dtgridParams = null, TextBox _txtTarihGirisi = null)
        {
            dtgridParams = _dtgridParams;
            txtTarihGirisi = _txtTarihGirisi;
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
        private List<Tuple<int, string, string, string, string>> bekleyenPersonels = new List<Tuple<int, string, string, string, string>>();
        private List<Tuple<string, int>> aktiveParams = new List<Tuple<string, int>>();
        private DataTable dtAktiviteParam = new DataTable();
        private DateTime sistemSaati = DateTime.Now;

        private TextBox txtTarihGirisi = null;


        private void TarihGirisi_Load(object sender, EventArgs e)
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

                richTextBox1.Text = DateTime.Now.Day.ToString().PadLeft(2, '0');
                richTextBox2.Text = DateTime.Now.Month.ToString().PadLeft(2, '0');
                richTextBox3.Text = DateTime.Now.Year.ToString().Substring(2, 2);

                

                if (dtgridParams != null)
                {
                    if (dtgridParams.CurrentCell.Value!=DBNull.Value)
                    {
                        DateTime date = Convert.ToDateTime(dtgridParams.CurrentCell.Value);

                        richTextBox1.Text = date.Day.ToString().PadLeft(2, '0');
                        richTextBox2.Text = date.Month.ToString().PadLeft(2, '0');
                        richTextBox3.Text = date.Year.ToString().Substring(2, 2); 
                    }
                }

                if (txtTarihGirisi != null)
                {
                    if (txtTarihGirisi.Text.Contains("/"))
                    {
                        DateTime date = DateTime.ParseExact(txtTarihGirisi.Text,"dd/MM/yyyy",System.Globalization.CultureInfo.InvariantCulture);

                        richTextBox1.Text = date.Day.ToString().PadLeft(2, '0');
                        richTextBox2.Text = date.Month.ToString().PadLeft(2, '0');
                        richTextBox3.Text = date.Year.ToString().Substring(2, 2);
                    }

                    if (txtTarihGirisi.Text.Contains("."))
                    {
                        DateTime date = DateTime.ParseExact(txtTarihGirisi.Text, "dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture);

                        richTextBox1.Text = date.Day.ToString().PadLeft(2, '0');
                        richTextBox2.Text = date.Month.ToString().PadLeft(2, '0');
                        richTextBox3.Text = date.Year.ToString().Substring(2, 2);
                    }
                }

                richTextBox1.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox1.SelectionAlignment = HorizontalAlignment.Center;

                richTextBox2.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox2.SelectionAlignment = HorizontalAlignment.Center;

                richTextBox3.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
                richTextBox3.SelectionAlignment = HorizontalAlignment.Center;

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
                int gun = Convert.ToInt32(richTextBox1.Text);
                gun = gun + 1;

                int ay = Convert.ToInt32(richTextBox2.Text);
                int yil = Convert.ToInt32(richTextBox3.Text);

                DateTime aysonu = new DateTime(yil, ay + 1, 1).AddDays(-1);

                if (gun > aysonu.Day)
                {
                    gun = 1;
                }

                richTextBox1.Text = gun.ToString().PadLeft(2, '0');

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
                int gun = Convert.ToInt32(richTextBox1.Text);
                gun = gun - 1;

                int ay = Convert.ToInt32(richTextBox2.Text);
                int yil = Convert.ToInt32(richTextBox3.Text);

                DateTime aysonu = new DateTime(yil, ay + 1, 1).AddDays(-1);

                if (gun == 0)
                {
                    gun = aysonu.Day;
                }

                richTextBox1.Text = gun.ToString().PadLeft(2, '0');

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

                int gun = Convert.ToInt32(richTextBox1.Text);

                int ay = Convert.ToInt32(richTextBox2.Text);
                ay = ay + 1;


                int yil = Convert.ToInt32(DateTime.Now.Year.ToString().Substring(0, 2) + richTextBox3.Text);

                DateTime aysonu = new DateTime();

                if (ay == 12)
                {
                    aysonu = new DateTime(yil + 1, 1, 1).AddDays(-1);
                }
                else if (ay == 13)
                {
                    aysonu = new DateTime(yil, 2, 1).AddDays(-1);
                }
                else
                {
                    aysonu = new DateTime(yil, ay + 1, 1).AddDays(-1);
                }



                if (gun > aysonu.Day)
                {
                    richTextBox1.Text = aysonu.Day.ToString().PadLeft(2, '0');
                }


                if (ay == 13)
                {
                    ay = 1;
                }

                richTextBox2.Text = ay.ToString().PadLeft(2, '0');
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
                int gun = Convert.ToInt32(richTextBox1.Text);

                int ay = Convert.ToInt32(richTextBox2.Text);
                ay = ay - 1;

                int yil = Convert.ToInt32(DateTime.Now.Year.ToString().Substring(0, 2) + richTextBox3.Text);

                DateTime aysonu = new DateTime();

                aysonu = new DateTime(yil, ay + 1, 1).AddDays(-1);


                if (ay == 0)
                {
                    ay = 12;
                }

                if (gun > aysonu.Day)
                {
                    richTextBox1.Text = aysonu.Day.ToString().PadLeft(2, '0');
                }


                richTextBox2.Text = ay.ToString().PadLeft(2, '0');
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
                string sql = "Select \"U_Hour\",\"U_Minute\" from \"@AIF_UVT_ACTPARAM\"";
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
            gun = richTextBox1.Text;
            ay = richTextBox2.Text;
            yil = DateTime.Now.Year.ToString().Substring(0, 2) + richTextBox3.Text;
            DateTime dt = new DateTime(Convert.ToInt32(yil), Convert.ToInt32(ay), Convert.ToInt32(gun));
            if (dtgridParams != null)
            {
                dtgridParams.CurrentCell.Value = Convert.ToString(dt); 
            }
            if (txtTarihGirisi != null &&txtTarihGirisi.Text != "")
            {
                txtTarihGirisi.Text = Convert.ToString(dt.ToString("dd/MM/yyyy"));
            }
            Close();
        }

        public static string dialogResult = "";

        public static string gun = "";

        public static string ay = "";

        public static string yil = "";

        public class BekleyenPersonel
        {
            public int sira { get; set; }
            public string empid { get; set; }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            int gun = Convert.ToInt32(richTextBox1.Text);

            int ay = Convert.ToInt32(richTextBox2.Text);


            int yil = Convert.ToInt32(DateTime.Now.Year.ToString().Substring(0, 2) + richTextBox3.Text);
            yil = yil - 1;


            DateTime aysonu = new DateTime();


            if (ay == 12)
            {
                aysonu = new DateTime(yil + 1, 1, 1).AddDays(-1);
            }
            else if (ay == 13)
            {
                aysonu = new DateTime(yil, 2, 1).AddDays(-1);
            }
            else
            {
                aysonu = new DateTime(yil, ay + 1, 1).AddDays(-1);
            }

            if (gun > aysonu.Day)
            {
                richTextBox1.Text = aysonu.Day.ToString().PadLeft(2, '0');
            }

            richTextBox3.Text = yil.ToString().Substring(2, 2);
            richTextBox3.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;

        }

        private void button8_Click(object sender, EventArgs e)
        {
            int gun = Convert.ToInt32(richTextBox1.Text);

            int ay = Convert.ToInt32(richTextBox2.Text);

            int yil = Convert.ToInt32(richTextBox3.Text);
            yil = yil + 1;

            yil = Convert.ToInt32(DateTime.Now.Year.ToString().Substring(0, 2) + yil);

            DateTime aysonu = new DateTime();


            if (ay == 12)
            {
                aysonu = new DateTime(yil + 1, 1, 1).AddDays(-1);
            }
            else if (ay == 13)
            {
                aysonu = new DateTime(yil, 2, 1).AddDays(-1);
            }
            else
            {
                aysonu = new DateTime(yil, ay + 1, 1).AddDays(-1);
            }

            if (gun > aysonu.Day)
            {
                richTextBox1.Text = aysonu.Day.ToString().PadLeft(2, '0');
            }


            richTextBox3.Text = yil.ToString().Substring(2, 2);
            richTextBox3.Font = new Font("Bahnschrift", 100F, FontStyle.Bold, GraphicsUnit.Pixel);
            richTextBox3.SelectionAlignment = HorizontalAlignment.Center;
        }
    }
}
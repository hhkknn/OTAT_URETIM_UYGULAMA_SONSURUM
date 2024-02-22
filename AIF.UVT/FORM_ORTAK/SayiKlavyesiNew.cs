using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class SayiKlavyesiNew : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end

        private DataGridView dtgridParams = null;
        private string basevalue = "";
        private bool timeField = false;
        private bool integerField = false;
        private TextBox tparam = new TextBox();

        public SayiKlavyesiNew(TextBox text, DataGridView _dtgridParams = null, bool _timeField = false, bool _integerfield = false)
        {
            tparam = text;
            dtgridParams = _dtgridParams;
            integerField = _integerfield;
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = button15.Font.Size;
            button15.Resize += Form_Resize;

            initialFontSize = textBox1.Font.Size;
            textBox1.Resize += Form_Resize;

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

            initialFontSize = button7.Font.Size;
            button7.Resize += Form_Resize;

            initialFontSize = button8.Font.Size;
            button8.Resize += Form_Resize;

            initialFontSize = button9.Font.Size;
            button9.Resize += Form_Resize;

            initialFontSize = button10.Font.Size;
            button10.Resize += Form_Resize;

            initialFontSize = button11.Font.Size;
            button11.Resize += Form_Resize;

            initialFontSize = button12.Font.Size;
            button12.Resize += Form_Resize;

            initialFontSize = button13.Font.Size;
            button13.Resize += Form_Resize;

            initialFontSize = button14.Font.Size;
            button14.Resize += Form_Resize;
            //font end

            System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

            if (text != null)
            {
                try
                {
                    textBox1.Text = Convert.ToDouble(text.Text).ToString("N" + Giris.OndalikMiktar, cultureTR);
                    textBox1.Text = parseNumber.parservalues<double>(text.Text.ToString()).ToString();
                }
                catch (Exception)
                {
                }
            }
            else
            {
                try
                {
                    if (dtgridParams.Name == "dtgSarfMalzeme")
                    {
                        //textBox1.Text = Convert.ToDouble(dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value).ToString("N" + Giris.OndalikMiktar, cultureTR);//old milyara çevirdiğinden kapattım
                        textBox1.Text = parseNumber.parservalues<double>(dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value.ToString()).ToString();
                    }
                    else
                    {
                        if (_timeField == false)
                        {
                            //textBox1.Text = Convert.ToDouble(dtgridParams.CurrentCell.Value).ToString("N" + Giris.OndalikMiktar, cultureTR); //
                            textBox1.Text = parseNumber.parservalues<double>(dtgridParams.CurrentCell.Value.ToString()).ToString();
                        }
                        else
                        {
                            var saat = dtgridParams.CurrentCell.Value.ToString();
                            textBox1.Text = saat;
                        }
                    }
                }
                catch (Exception)
                {
                }
            }
            basevalue = textBox1.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //Stopwatch watch = new Stopwatch();
            //watch.Start();
            //font start
            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            textBox1.Font = new Font(textBox1.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               textBox1.Font.Style);

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

            button7.Font = new Font(button7.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button7.Font.Style);

            button8.Font = new Font(button8.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button8.Font.Style);

            button9.Font = new Font(button9.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button9.Font.Style);

            button10.Font = new Font(button10.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button10.Font.Style);

            button11.Font = new Font(button11.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button11.Font.Style);

            button12.Font = new Font(button12.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button12.Font.Style);

            button13.Font = new Font(button13.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button13.Font.Style);

            button14.Font = new Font(button14.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button14.Font.Style);

            button15.Font = new Font(button15.Font.FontFamily, initialFontSize *
               (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
               button15.Font.Style);
            ResumeLayout();
            //font end
            //watch.Stop();
            //MessageBox.Show(string.Format("Süre: {0}", watch.Elapsed.TotalMilliseconds));
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

        private void SayiKlavyesiNewNew_Load(object sender, EventArgs e)
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
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (!textBox1.Text.Contains(","))
            {
                textBox1.Text = textBox1.Text + ",";
            }
        }

        private void textboxTemizle()
        {
            if (textBox1.Text == basevalue)
            {
                textBox1.Text = "";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            textBox1.Text = textBox1.Text + "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            textBox1.Text = textBox1.Text + "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            textBox1.Text = textBox1.Text + "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            textBox1.Text = textBox1.Text + "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            textBox1.Text = textBox1.Text + "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            textBox1.Text = textBox1.Text + "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            textBox1.Text = textBox1.Text + "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            textBox1.Text = textBox1.Text + "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            textBox1.Text = textBox1.Text + "9";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            textBox1.Text = textBox1.Text + "0";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = textBox1.Text.Remove(textBox1.Text.Length - 1, 1);
            }
            catch (Exception ex)
            {
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (timeField)
            {
                if (textBox1.Text.Length != 5 && textBox1.Text != "")
                {
                    CustomMsgBtn.Show(string.Format("{0} saat girişi saat formatına uygun değildir.", textBox1.Text), "UYARI", "TAMAM");
                    return;
                }
            }
            if (tparam != null)
            {
                tparam.Text = textBox1.Text;
            }
            else if (dtgridParams != null)
            {
                try
                {
                    if (integerField)
                    {
                        int val = 0;
                         
                        try
                        {
                            //val = (int)Convert.ToDouble(textBox1.Text);//old 20220722
                            val = (int)parseNumber.parservalues<double>(textBox1.Text.ToString());
                            dtgridParams.NotifyCurrentCellDirty(true);
                            dtgridParams.CurrentCell.Value = Convert.ToString(val);
                        }
                        catch (Exception)
                        { 
                        }

                    }
                    else if (timeField == false)
                    {
                        System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");

                        //double val = Convert.ToDouble(textBox1.Text.Replace(",", "."));
                        double val = double.Parse(textBox1.Text, cultureTR);
                        dtgridParams.NotifyCurrentCellDirty(true);

                        GirisOk = "DEG";
                        if (dtgridParams.Name == "dtgSarfMalzeme")
                        {
                            dtgridParams.Rows[dtgridParams.CurrentCell.RowIndex].Cells["Miktar"].Value = Convert.ToString(val);
                        }
                        else
                        {
                            dtgridParams.CurrentCell.Value = Convert.ToString(val);
                        }
                    }
                    else if (timeField == true)
                    {
                        //System.IFormatProvider cultureTR = new System.Globalization.CultureInfo("tr-TR");
                        //double val = double.Parse(textBox1.Text, cultureTR);
                        //string saat = val.ToString().PadRight(4, '0');

                        //saat = saat.Insert(2, ":");

                        //dtgridParams.NotifyCurrentCellDirty(true);
                        //dtgridParams.CurrentCell.Value = "";
                        dtgridParams.CurrentCell.Value = Convert.ToString(textBox1.Text);
                    }
                }
                catch (Exception ex)
                {
                }
            }
            Close();
        }

        public static string GirisOk = "";

        private void button14_Click(object sender, EventArgs e)
        {
            textboxTemizle();
            if (textBox1.Text == "")
            {
                textBox1.Text = "-";
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region sadece sayı girişi

            if (e.KeyChar.ToString() !=",")
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar); 
            }

            #endregion sadece sayı girişi

            #region sadece harf girişi

            //e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);

            #endregion sadece harf girişi
        }  
    }
}
using AIF.UVT.DatabaseLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class Barkod : Form
    {
        //font start
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;
        //font end.

        public Barkod(string _uretimFisNo, string _partiNo, string _urunTanimi, string _uretimTarihi, int _width, int _height, string _barkod, string _urunKodu,string _gerceklesenMik, string _type)
        {
            uretimFisNo = _uretimFisNo;
            partiNo = _partiNo;
            urunTanimi = StringReplace(_urunTanimi);
            uretimTarihi = _uretimTarihi;
            barkod = _barkod;
            urunKodu = _urunKodu;
            gerceklesenMik = _gerceklesenMik;
            type = _type;
            InitializeComponent();

            //font start
            AutoScaleMode = AutoScaleMode.None;

            initialWidth = _width;
            initialHeight = _height;

            initialFontSize = button2.Font.Size;
            button2.Resize += Form_Resize;

            initialFontSize = button3.Font.Size;
            button3.Resize += Form_Resize;

            initialFontSize = button4.Font.Size;
            button4.Resize += Form_Resize;

            initialFontSize = pictureBox1.Font.Size;
            pictureBox1.Resize += Form_Resize;

            initialFontSize = pictureBox2.Font.Size;
            pictureBox2.Resize += Form_Resize;
            //font end
            cmbPrinter.Font = new Font("Microsoft Sans Serif", 18, FontStyle.Regular);
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //font start
            SuspendLayout();
            // Yeniden boyutlandırma oranını alır
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            button2.Font = new Font(button2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button2.Font.Style);

            button3.Font = new Font(button3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button3.Font.Style);

            button4.Font = new Font(button4.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                button4.Font.Style);

            pictureBox1.Font = new Font(pictureBox1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                pictureBox1.Font.Style);

            pictureBox2.Font = new Font(pictureBox2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                pictureBox2.Font.Style);

            cmbPrinter.Font = new Font(cmbPrinter.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbPrinter.Font.Style);

            lblYazici.Font = new Font(lblYazici.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                lblYazici.Font.Style);

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
              (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
              label1.Font.Style);

            txtPrintMik.Font = new Font(txtPrintMik.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                txtPrintMik.Font.Style);

            btnArti.Font = new Font(btnArti.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnArti.Font.Style);

            btnEksi.Font = new Font(btnEksi.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnEksi.Font.Style);

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

        private string uretimFisNo = "";
        private string partiNo = "";
        private string urunTanimi = "";
        private string uretimTarihi = "";
        private string sonTuketimTarihi = "";
        private string paletIciAdet = "";
        private string paletKoliNo = "";
        private string barkod = "";
        private string urunKodu = "";
        private string gerceklesenMik ="";
        private string type = "";

        public string StringReplace(string text)
        {
            text = text.Replace("İ", "I");
            text = text.Replace("ı", "i");
            text = text.Replace("Ğ", "G");
            text = text.Replace("ğ", "g");
            text = text.Replace("Ö", "O");
            text = text.Replace("ö", "o");
            text = text.Replace("Ü", "U");
            text = text.Replace("ü", "u");
            text = text.Replace("Ş", "S");
            text = text.Replace("ş", "s");
            text = text.Replace("Ç", "C");
            text = text.Replace("ç", "c");
            return text;
        }

        private void PrintPageBarcode1(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox1.Image, 10, 10);
            //e.Graphics.DrawImage(pictureBox2.Image, 10, 10);
        }

        private void PrintPageBarcode2(System.Object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(pictureBox2.Image, 10, 10);
        }
        int yazdirMik = 0;

        private void button2_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image == null)
            {
                CustomMsgBtn.Show("Barkod oluşturulmadan yazdırma işlemi yapılamaz.", "Uyarı", "TAMAM");
                return;
            }

            if (txtPrintMik.Text == "")
            {
                CustomMsgBtn.Show("Lütfen yazdırılacak miktar giriniz.", "Uyarı", "TAMAM");
                txtPrintMik.Focus();
                return;
            }
            yazdirMik = Convert.ToInt32(txtPrintMik.Text);
            for (int i = 1; i <= yazdirMik; i++)
            {
                PrintDialog myPrinDialog1 = new PrintDialog();
                System.Drawing.Printing.PrintDocument prnt = new System.Drawing.Printing.PrintDocument();
                prnt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintPageBarcode1);
                prnt.Print();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PrintDialog myPrinDialog1 = new PrintDialog();
            System.Drawing.Printing.PrintDocument prnt = new System.Drawing.Printing.PrintDocument();
            prnt.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(PrintPageBarcode2);
            prnt.Print();
        }

        private SqlCommand cmd = null;
        private DataTable dtGetPaletKoli = new DataTable();

        private void GetPaletKoli()
        {
            try
            {
                string sql = "";

                sql = "SELECT \"U_PALET\" as \"Palet İçi Adet\", \"U_KoliMiktari\" as \"Koli İçi Adet\", \"U_PaletKoli\" as \"Palet İçi Koli\" FROM OITM WITH (NOLOCK) WHERE \"ItemCode\"= '" + urunKodu + "' ";

                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sda.Fill(dtGetPaletKoli);

                #region sql connection chn 
                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
                #endregion
            }
            catch (Exception ex)
            {
            }
        }

        private double paletIciKoliAdedi = 0;
        private double koliIciAdedi = 0;
        private double paletIciAdedi = 0;

        private void Barkod_Load(object sender, EventArgs e)
        {
            txtPrintMik.Text = "1";

            #region MKOD İle Background Değişimi

            var lastOpenedForm = Application.OpenForms.Cast<Form>().Last();

            if (Giris.mKodValue == "010OTATURVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.OTAT_UVT_ArkaPlanV3;
            }
            else if (Giris.mKodValue == "20URVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.YORUK_UVT_ArkaPlanv2;
                PartiNiteligiGetir();

            }

            #endregion MKOD İle Background Değişimi

            GetPaletKoli();
            listAllPrinters();

            Graphics g;
            Pen pn = new Pen(Color.Black);
            Font fnt = new Font("Calibri", 12, FontStyle.Bold);
            Brush brush = new SolidBrush(Color.Black);
            Bitmap bmp = new Bitmap(600, 600);
            g = Graphics.FromImage(bmp);

            Zen.Barcode.CodeQrBarcodeDraw barcodeQR = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            Zen.Barcode.Code128BarcodeDraw barcode = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
            Zen.Barcode.Code128BarcodeDraw barcodeV = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;

            ////dikey
            //var barkodDeger2 = barcodeV.Draw(partiNo, 50);
            //var resultImage2 = new Bitmap(barkodDeger2.Width + 470, barkodDeger2.Height + 230); //string x,y

            ////yatay
            //var barkodDeger = barcode.Draw(partiNo, 50);
            //var resultImage = new Bitmap(barkodDeger.Width + 20, barkodDeger.Height + 165);
            if (dtGetPaletKoli.Rows.Count > 0)
            {
                double _paletIciAdedi = 0;
                double _koliIciAdedi = 0;
                double _paletIciKoliAdedi = 0;

                if (dtGetPaletKoli.Rows[0]["Palet İçi Koli"].ToString() != "" || dtGetPaletKoli.Rows[0]["Palet İçi Koli"] != DBNull.Value)
                {
                    _paletIciKoliAdedi = Convert.ToDouble(dtGetPaletKoli.Rows[0]["Palet İçi Koli"]);
                }

                if (dtGetPaletKoli.Rows[0]["Palet İçi Adet"].ToString() != "" || dtGetPaletKoli.Rows[0]["Palet İçi Adet"] != DBNull.Value)
                {
                    _paletIciAdedi = Convert.ToDouble(dtGetPaletKoli.Rows[0]["Palet İçi Adet"]);
                }

                if (dtGetPaletKoli.Rows[0]["Koli İçi Adet"].ToString() != "" || dtGetPaletKoli.Rows[0]["Koli İçi Adet"] != DBNull.Value)
                {
                    _koliIciAdedi = Convert.ToDouble(dtGetPaletKoli.Rows[0]["Koli İçi Adet"]);
                }
                paletIciKoliAdedi = _paletIciKoliAdedi;
                paletIciAdedi = _paletIciAdedi;
                koliIciAdedi = _koliIciAdedi;
            }

            //label tr karakter
            string urunTanimiAdiLabel = "Ürün Adı: ";
            string koliIciAdediLabel = "Koli İçi Adet           : ";
            string paletIciKoliAdediLabel = "Palet İçi Koli Adet : ";
            string paletIciAdediLabel = "Palet İçi Adet          : ";
            string uretimTarihiAdiLabel = "Üretim Tarihi          : ";
            string sonTuketimTrhAdiLabel = "Son Tüketim Tarihi: ";
            string partiNoLabel = "Parti No                  : ";
            string barkodLabel = "Barkod No: ";
            string partiNitelikLabel = "Parti Niteliği           : ";
            string gerceklesenMikLabel = "Parti Miktarı           : ";
            //
            //barkodun içine yazılacak degerler
            string urunTanimiAdi = "Urun Adi";
            string koliIciAd = "Koli Ici Adet: ";
            string paletIciKoliAd = "Palet Ici Koli Adet: ";
            string paletIciAd = "Palet Ici Adet: ";
            string uretimTarihiAdi = "Uretim Tarihi";
            string sonTuketimTrhAdi = "Son Tuketim Tarihi";
            string paletKoliNoAdi = "Palet Koli No";
            //string partiAdi = "Parti No:";
            //string barkodDeger = "";
            string barkodDegerQR = "";

            //barkodDeger = uretimFisNoAdi + ":" + uretimFisNo + Environment.NewLine;
            //barkodDeger = partiNo;
            //barkodDeger += urunTanimiAdi + ":" + urunTanimi + Environment.NewLine;
            //barkodDeger += uretimTarihiAdi + ":" + uretimTarihi + Environment.NewLine;

            //barkodDegerQR = uretimFisNoAdi + ":" + uretimFisNo + Environment.NewLine;
            //barkodDegerQR += urunTanimiAdi + ":" + urunTanimi + Environment.NewLine;
            //barkodDegerQR += paletIciAdAdi + ":" + paletIciAdet + Environment.NewLine;
            //barkodDegerQR += uretimTarihiAdi + ":" + uretimTarihi + Environment.NewLine;
            //barkodDegerQR += sonTuketimTrhAdi + ":" + sonTuketimTarihi + Environment.NewLine;
            //barkodDegerQR += paletKoliNoAdi + ":" + paletKoliNo + Environment.NewLine;
            //barkodDegerQR += partiAdi + ":" + partiNo + Environment.NewLine;

            if (type == "IST010")
            {
                g.Clear(Color.White);

                #region otat için sağ taraftaki dikey parti no çizer

                if (Giris.mKodValue == "010OTATURVT")
                {
                    using (var format = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Far
                    })
                    {
                        g.DrawImage(barcodeV.Draw(partiNo, 50, 1), new Point(405, 280));
                        //g.DrawImage(barkodDeger2, 240, 250);//barkod x,y

                        g.DrawString(partiNo, fnt, brush, 485, 350, format);
                        bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        //g.DrawRectangle(new Pen(brush, 5), new Rectangle(0, 0, bmp.Width, bmp.Height));
                    }
                }
                #endregion

                //Etiketler
                g.DrawString(koliIciAdediLabel, fnt, brush, 5, 50);
                g.DrawString(paletIciKoliAdediLabel, fnt, brush, 5, 70);
                g.DrawString(paletIciAdediLabel, fnt, brush, 5, 90);
                g.DrawString(partiNoLabel, fnt, brush, 5, 110);
                if (barkod == "")
                {
                    g.DrawString(barkodLabel, fnt, brush, 5, 180);
                }
                //g.DrawString(partiAdi, fnt, brush, 5, 40);
                //g.DrawString(uretimFisNoAdi, fnt, brush, 5, 20);
                //Değerler
                g.DrawString(urunTanimi, fnt, brush, 5, 10);
                g.DrawString(koliIciAdedi.ToString(), fnt, brush, 140, 50);
                g.DrawString(paletIciKoliAdedi.ToString(), fnt, brush, 140, 70);
                g.DrawString(paletIciAdedi.ToString(), fnt, brush, 140, 90);
                g.DrawString(partiNo, fnt, brush, 140, 110);

                #region otat için barkod yok ise tanımsız yazar
                if (Giris.mKodValue == "010OTATURVT")
                {
                    g.DrawString(barkod == "" ? "TANIMSIZ" : barkod, fnt, brush, 100, 180);

                }
                #endregion

                //g.DrawString(uretimFisNo, fnt, brush, 100, 20);
                //g.DrawString(partiNo, fnt, brush, 100, 40);

                #region yörük için barkod boş ise tanımsız-parti numarasını yazar.
                if (Giris.mKodValue == "20URVT")
                {
                    if (barkod == "" && partiNo == "")
                    {
                        g.DrawString(barkod == "" ? "TANIMSIZ" : barkod, fnt, brush, 100, 180);
                    }

                    if (barkod == "" && partiNo != "")
                    {
                        using (var format = new StringFormat()
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Far
                        })
                        {

                            string barkodvepartino = "TANIMSIZ" + "-" + partiNo;
                            g.DrawImage(barcode.Draw(barkodvepartino, 50, 1), new Point(5, 145));
                            g.DrawString(barkodvepartino, fnt, brush, 125, 215, format);


                        }
                    }
                }
                #endregion

                if (barkod != "")
                {
                    using (var format = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Far
                    })
                    {
                        #region otat için sadece barkodu yazar
                        if (Giris.mKodValue == "010OTATURVT")
                        {
                            //g.DrawImage(barkodDeger, 10, 150);
                            //g.DrawString(barkod, fnt, brush, resultImage.Width / 2, resultImage.Height, format); 
                            g.DrawImage(barcode.Draw(barkod, 50, 2), new Point(5, 145));
                            g.DrawString(barkod, fnt, brush, 125, 215, format);
                        }
                        #endregion


                        #region yörük için parti no yok ise barkodu çizer.parti no ve barkod varsa - li şekilde ikisinide yazar
                        if (Giris.mKodValue == "20URVT")
                        {
                            if (partiNo == "")
                            {
                                #region partino yoksa sadece barkodu basar ve altına yazdırır.
                                g.DrawImage(barcode.Draw(barkod, 50, 1), new Point(5, 145));
                                g.DrawString(barkod, fnt, brush, 65, 215, format);
                                //g.DrawString(barkod, fnt, brush, 125, 215, format); //eski hali.ortaya yazar
                                #endregion
                            }
                            else
                            {
                                string barkodvepartino = barkod + "-" + partiNo;

                                g.DrawImage(barcode.Draw(barkodvepartino, 50, 1), new Point(5, 145));
                                g.DrawString(barkodvepartino, fnt, brush, 125, 215, format);
                            }
                        }
                        #endregion

                    }
                }
            }
            else
            {
                g.Clear(Color.White);

                #region otat için sağ taraftaki dikey parti no çizer

                if (Giris.mKodValue == "010OTATURVT")
                {
                    using (var format = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Far
                    })
                    {
                        g.DrawImage(barcodeV.Draw(partiNo, 50, 1), new Point(405, 280));
                        //g.DrawImage(barkodDeger2, 240, 250);//barkod x,y

                        g.DrawString(partiNo, fnt, brush, 485, 350, format);
                        bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);
                        //g.DrawRectangle(new Pen(brush, 5), new Rectangle(0, 0, bmp.Width, bmp.Height));
                    }
                }
                #endregion

                //Etiketler
                //g.DrawString(urunTanimiAdiLabel, fnt, brush, 5, 10);
                g.DrawString(paletIciAdediLabel, fnt, brush, 5, 50); //50 20220127
                g.DrawString(uretimTarihiAdiLabel, fnt, brush, 5, 67); //70 20220127
                g.DrawString(sonTuketimTrhAdiLabel, fnt, brush, 5, 84); //90 20220127

                if (Giris.mKodValue == "20URVT")
                {
                    g.DrawString(partiNitelikLabel, fnt, brush, 5, 101); //110 20220127
                    g.DrawString(gerceklesenMikLabel, fnt, brush, 5, 118); //130 20220127

                }
                //g.DrawString(paletKoliNoAdiLabel, fnt, brush, 5, 90);
                if (barkod == "")
                {
                    g.DrawString(barkodLabel, fnt, brush, 5, 180); 
                }
                //g.DrawString(partiAdi, fnt, brush, 5, 40);
                //g.DrawString(uretimFisNoAdi, fnt, brush, 5, 20);
                //Değerler
                g.DrawString(urunTanimi, fnt, brush, 5, 10);
                g.DrawString(paletIciAdedi.ToString(), fnt, brush, 145, 50); //50 20220127
                g.DrawString(uretimTarihi, fnt, brush, 145, 67); //70 20220127
                g.DrawString(sonTuketimTarihi, fnt, brush, 145, 84); //90 20220127

                if (Giris.mKodValue == "20URVT")
                {
                    g.DrawString(partiNiteligi, fnt, brush, 145, 101); //110 20220127
                    g.DrawString(gerceklesenMik, fnt, brush, 145, 118); //130 20220127

                }
                //g.DrawString(paletKoliNo, fnt, brush, 100, 90);

                #region otat için barkod yok ise tanımsız yazar
                if (Giris.mKodValue == "010OTATURVT")
                {
                    if (barkod == "")
                    {
                        g.DrawString(barkod == "" ? "TANIMSIZ" : barkod, fnt, brush, 100, 180);
                    }
                }
                #endregion


                #region yörük için barkod boş ise tanımsız-parti numarasını yazar.
                if (Giris.mKodValue == "20URVT")
                {
                    if (barkod == "" && partiNo == "")
                    {
                        g.DrawString(barkod == "" ? "TANIMSIZ" : barkod, fnt, brush, 100, 180);
                    }

                    if (barkod == "" && partiNo != "")
                    {
                        using (var format = new StringFormat()
                        {
                            Alignment = StringAlignment.Center,
                            LineAlignment = StringAlignment.Far
                        })
                        {

                            string barkodvepartino = "TANIMSIZ" + "-" + partiNo;
                            g.DrawImage(barcode.Draw(barkodvepartino, 50, 1), new Point(5, 145));
                            g.DrawString(barkodvepartino, fnt, brush, 125, 215, format);


                        }
                    }
                }
                #endregion
                //g.DrawString(uretimFisNo, fnt, brush, 100, 20);
                //g.DrawString(partiNo, fnt, brush, 100, 40);

                if (barkod != "")
                {
                    using (var format = new StringFormat()
                    {
                        Alignment = StringAlignment.Center,
                        LineAlignment = StringAlignment.Far
                    })
                    {
                        #region otat için sadece barkodu yazar
                        if (Giris.mKodValue == "010OTATURVT")
                        {
                            //g.DrawImage(barkodDeger, 10, 150);
                            //g.DrawString(barkod, fnt, brush, resultImage.Width / 2, resultImage.Height, format); 
                            g.DrawImage(barcode.Draw(barkod, 50, 2), new Point(5, 145));
                            g.DrawString(barkod, fnt, brush, 125, 215, format);
                        }
                        #endregion

                        #region yörük için parti no yok ise barkodu çizer.parti no ve barkod varsa - li şekilde ikisinide yazar
                        if (Giris.mKodValue == "20URVT")
                        {
                            if (partiNo == "")
                            {
                                #region partino yoksa sadece barkodu basar ve altına yazdırır.
                                g.DrawImage(barcode.Draw(barkod, 50, 1), new Point(5, 145));
                                g.DrawString(barkod, fnt, brush, 65, 215, format);
                                //g.DrawString(barkod, fnt, brush, 125, 215, format); 
                                #endregion

                            }
                            else
                            {
                                string barkodvepartino = barkod + "-" + partiNo;
                                g.DrawImage(barcode.Draw(barkodvepartino, 50, 1), new Point(5, 145));
                                g.DrawString(barkodvepartino, fnt, brush, 125, 215, format);

                            }
                        }
                        #endregion
                    }
                }
            }

            //g.DrawImage(barcodeV.Draw(partiNo, 60, 1), new Point(260, 40));
            //bmp.RotateFlip(RotateFlipType.Rotate270FlipNone);

            //g.DrawRectangle(new Pen(brush, 5), new Rectangle(0, 0, bmp.Width, bmp.Height));
            pictureBox1.Image = bmp;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void listAllPrinters()
        {
            cmbPrinter.Items.Clear();
            cmbPrinter.Items.Add("");

            foreach (var item in PrinterSettings.InstalledPrinters)
            {
                cmbPrinter.Items.Add(item);
            }
            //default
            PrintDocument printDocument = new PrintDocument();
            string defaultPrinter = printDocument.PrinterSettings.PrinterName;
            cmbPrinter.SelectedItem = defaultPrinter;
        }

        public static class myPrinters
        {
            [DllImport("winspool.drv", CharSet = CharSet.Auto, SetLastError = true)]
            public static extern bool SetDefaultPrinter(string Name);
        }

        private void cmbPrinter_SelectedValueChanged(object sender, EventArgs e)
        {
            string pname = this.cmbPrinter.SelectedItem.ToString();
            myPrinters.SetDefaultPrinter(pname);
        }
        private string partiNiteligi = "";
        private void PartiNiteligiGetir()
        {
            #region Parti niteliği getirir
            try
            {
                SqlDataAdapter sda_PartiNiteligi = new SqlDataAdapter(cmd);
                DataTable dt_PartiNiteligi = new DataTable();
                string partiNiteligiSql = "";

                partiNiteligiSql = "Select \"MnfSerial\" from \"OBTN\" WITH (NOLOCK) where \"DistNumber\" = '" + partiNo + "'";

                cmd = new SqlCommand(partiNiteligiSql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                {
                    Connection.sql.Open();
                }
                sda_PartiNiteligi = new SqlDataAdapter(cmd);
                sda_PartiNiteligi.Fill(dt_PartiNiteligi);

                #region sql connection chn 
                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
                #endregion

                if (dt_PartiNiteligi.Rows[0][0] != null && dt_PartiNiteligi.Rows[0][0].ToString() != "")
                {
                    partiNiteligi = dt_PartiNiteligi.Rows[0][0].ToString();
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Parti niteliği getirilirken hata oluştu" + ex.Message, "UYARI", "TAMAM");
            }
            #endregion
        }

        private void btnArti_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(txtPrintMik.Text) + 1;
            if (a == 0)
            {
                return;
            }
            txtPrintMik.Text = a.ToString();
        }

        private void btnEksi_Click(object sender, EventArgs e)
        {
            int a = Convert.ToInt32(txtPrintMik.Text) - 1;
            if (a == 0)
            {
                return;
            }
            txtPrintMik.Text = a.ToString();
        }

        private void txtPrintMik_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(txtPrintMik);
            nesne.ShowDialog();
        }

        private void txtPrintMik_KeyPress(object sender, KeyPressEventArgs e)
        {
            #region sadece sayı girişi

            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);

            #endregion sadece sayı girişi

            #region sadece harf girişi

            //e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);

            #endregion sadece harf girişi
        }
    }
}
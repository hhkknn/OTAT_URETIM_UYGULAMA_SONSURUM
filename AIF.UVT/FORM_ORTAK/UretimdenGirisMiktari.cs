using AIF.UVT.DatabaseLayer;
using AIF.UVT.UVTService;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    public partial class UretimdenGirisMiktari : Form
    {
        //font start.
        public int initialWidth;

        public int initialHeight;
        public float initialFontSize;

        //font end
        private Rectangle lblPlananMiktarRectangle;

        private Size formOriginalSize;

        public UretimdenGirisMiktari(string _belgeNo, double _belgeMiktari, string _partino, double _partiMiktar, double _planlananMiktar, int _width, int _height, string _urunKodu, string _varsayilanDepo, string _rotaKodu, string _tarih, DateTime _siparisTarihi)
        {
            belgeMiktari = _belgeMiktari;
            partiNo = _partino;
            belgeNo = _belgeNo;
            partiMiktar = _partiMiktar;
            planlananMiktar = _planlananMiktar;
            urunKodu = _urunKodu;
            varsayilanDepo = _varsayilanDepo;
            rotaKodu = _rotaKodu;
            tarih = _tarih;
            InitializeComponent();

            //initialFontSize = textBox1.Font.Size;
            //textBox1.Resize += Form_Resize;

            //initialFontSize = button1.Font.Size;
            //button1.Resize += Form_Resize;
            //font end
            txtPlanlanan.Text = planlananMiktar.ToString("N" + Giris.OndalikMiktar);
            //txtGerceklesenMiktar.Text = planlananMiktar.ToString("N" + Giris.OndalikMiktar);
            txtGerceklesenMiktar.Text = "";
            txtDepoSecimi.Text = varsayilanDepo;

            txtFireMiktari.Text = "";
            //txtFireMiktari.Text = Convert.ToDouble("0").ToString("N" + Giris.OndalikMiktar);
            txtNumuneMiktari.Text = "";
            //txtNumuneMiktari.Text = Convert.ToDouble("0").ToString("N" + Giris.OndalikMiktar);

            if (!urunKodu.StartsWith("MAM"))
            {
                txtDepoSecimi.Visible = false;
                lblDepoSecimi.Visible = false;
            }
            siparisTarihi = _siparisTarihi;

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

        public static string dialogResult = "";
        public static double Miktar = 0;
        private string belgeNo = "";
        private string partiNo = "";
        private string varsayilanDepo = "";
        private string urunKodu = "";
        private string rotaKodu = "";
        private double partiMiktar = 0;
        private double belgeMiktari = 0;
        private double planlananMiktar = 0;
        private string tarih = "";
        private DateTime siparisTarihi;

        private void UretimdenGirisMiktari_Load(object sender, EventArgs e)
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

        private SqlCommand cmd = null;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                #region Üretim sarfiyatları yapılmış mı? Kaldırıldı tekrar gelebilir 02.04.2020

                //double partiKatSayisi = 0;
                //DataTable dt_PartiKatSayisi = new DataTable();
                //DataTable dt_UretimSiparisleri = new DataTable();
                //DataTable dt_UretimdenCikisMiktari = new DataTable();
                //DataTable dt_kontrol = new DataTable();
                //string partikatsayisql = "";
                //partikatsayisql = "SELECT \"U_PartiKatSayi\" FROM  \"@AIF_URT_PART1\" where \"U_PartiNo\" = '" + partiNo + "'";

                //cmd = new SqlCommand(partikatsayisql, Connection.sql);

                //if (Connection.sql.State != ConnectionState.Open)
                //{
                //    Connection.sql.Open();
                //}
                //SqlDataAdapter sda = new SqlDataAdapter(cmd);
                //sda.Fill(dt_PartiKatSayisi);

                //if (dt_PartiKatSayisi.Rows.Count == 0)
                //{
                //    MessageBox.Show("Parti Kat Sayısı Bulunamadı");
                //    return;
                //}

                //partiKatSayisi = Convert.ToDouble(dt_PartiKatSayisi.Rows[0][0]);

                //string uretimsiparisikalemlerisql = "SELECT T1.\"PlannedQty\",T1.\"ItemCode\",T2.\"ItemName\" FROM \"OWOR\" as T0 INNER JOIN \"WOR1\" as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" INNER JOIN OITM as T2 ON T1.\"ItemCode\" = T2.\"ItemCode\" where T1.\"ItemType\" = '4' and T0.\"DocEntry\" = '" + belgeNo + "'";

                //cmd = new SqlCommand(uretimsiparisikalemlerisql, Connection.sql);

                //if (Connection.sql.State != ConnectionState.Open)
                //{
                //    Connection.sql.Open();
                //}
                //sda = new SqlDataAdapter(cmd);
                //sda.Fill(dt_UretimSiparisleri);

                //if (dt_UretimSiparisleri.Rows.Count == 0)
                //{
                //    MessageBox.Show("Ürün bulunamadı");
                //    return;
                //}
                //else
                //{
                //    string uretimdenCikisMiktarisql = "";
                //    double uretimsiparisihesaplananMiktar = 0;
                //    double uretimdenCikisMiktari = 0;
                //    double uretimsiparisihesaplananMiktarFazlasi = 0;
                //    double uretimsiparisihesaplananMiktarEksigi = 0;
                //    foreach (DataRow item in dt_UretimSiparisleri.Rows)
                //    {
                //        uretimsiparisihesaplananMiktar = Convert.ToDouble(item[0]);

                //        dt_UretimdenCikisMiktari = new DataTable();

                //        uretimdenCikisMiktarisql = "SELECT T1.\"ItemCode\" from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_BatchNumber\" = '" + partiNo + "' and T1.\"ItemCode\" = '" + item[1].ToString() + "'";

                //        cmd = new SqlCommand(uretimdenCikisMiktarisql, Connection.sql);

                //        if (Connection.sql.State != ConnectionState.Open)
                //        {
                //            Connection.sql.Open();
                //        }
                //        sda = new SqlDataAdapter(cmd);
                //        sda.Fill(dt_UretimdenCikisMiktari);

                //        if (dt_UretimdenCikisMiktari.Rows.Count == 0)
                //        {
                //            MessageBox.Show(item[2] + "için sarf yapılmamıştır.");
                //            return;
                //        }
                //        else
                //        {
                //            uretimsiparisihesaplananMiktar = Math.Round(Convert.ToDouble(uretimsiparisihesaplananMiktar / partiKatSayisi), 2);

                //            dt_UretimdenCikisMiktari.Rows.Clear();
                //            dt_UretimdenCikisMiktari.Columns.Clear();

                //            uretimdenCikisMiktarisql = "SELECT SUM(T1.\"Quantity\") from OIGE as T0 INNER JOIN IGE1 as T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"U_BatchNumber\" = '" + partiNo + "' and T1.\"ItemCode\" = '" + item[1].ToString() + "'";

                //            cmd = new SqlCommand(uretimdenCikisMiktarisql, Connection.sql);

                //            if (Connection.sql.State != ConnectionState.Open)
                //            {
                //                Connection.sql.Open();
                //            }
                //            sda = new SqlDataAdapter(cmd);
                //            sda.Fill(dt_UretimdenCikisMiktari);

                //            uretimsiparisihesaplananMiktarFazlasi = Math.Round(uretimsiparisihesaplananMiktar + ((uretimsiparisihesaplananMiktar * 10) / 100), 2);
                //            uretimsiparisihesaplananMiktarEksigi = Math.Round(uretimsiparisihesaplananMiktar - ((uretimsiparisihesaplananMiktar * 10) / 100), 2);

                //            uretimdenCikisMiktari = Convert.ToDouble(dt_UretimdenCikisMiktari.Rows[0][0]);

                //            if (uretimdenCikisMiktari > uretimsiparisihesaplananMiktarFazlasi)
                //            {
                //                MessageBox.Show(item[2] + " için fazla üretim");
                //                return;
                //            }
                //            else if (uretimdenCikisMiktari < uretimsiparisihesaplananMiktarEksigi)
                //            {
                //                MessageBox.Show(item[2] + " için eksik üretim");
                //                return;
                //            }

                //        }
                //    }
                //}

                #endregion Üretim sarfiyatları yapılmış mı? Kaldırıldı tekrar gelebilir 02.04.2020

                if (txtGerceklesenMiktar.Text == "")
                {
                    CustomMsgBtn.Show("Gerçekleşen miktar girişi yapınız.", "UYARI", "TAMAM");
                    txtGerceklesenMiktar.Focus();
                    txtGerceklesenMiktar.Select(0, txtGerceklesenMiktar.Text.Length);
                    return;
                }
                if (txtFireMiktari.Text == "")
                {
                    CustomMsgBtn.Show("Fire miktarı girişi yapınız.", "UYARI", "TAMAM");
                    txtFireMiktari.Focus();
                    txtFireMiktari.Select(0, txtFireMiktari.Text.Length);
                    return;
                }
                if (txtNumuneMiktari.Text == "")
                {
                    CustomMsgBtn.Show("Numune miktarı girişi yapınız.", "UYARI", "TAMAM");
                    txtNumuneMiktari.Focus();
                    txtNumuneMiktari.Select(0, txtNumuneMiktari.Text.Length);
                    return;
                }

                var txtGercekMik = parseNumber.parservalues<double>(txtGerceklesenMiktar.Text.ToString());// Convert.ToDouble(textBox1.Text);
                var txtfiremik = parseNumber.parservalues<double>(txtFireMiktari.Text.ToString());
                var txtnumunemik = parseNumber.parservalues<double>(txtNumuneMiktari.Text.ToString());

                #region SARF ORANI HEASAPLAMA - SATIRDAKİ GERÇEKLEŞEN MİKTAR 0 OLDUĞUNDA İŞLEMİ BİTİREBİLMESİ İÇİN SARF ORANI 100 VE ÜZERİ OLMASINA BAKILDI
                //string sarfOranHesaplamaSekli = "";

                //string sql = "Select \"U_SrfOrnHspSkl\" from \"@AIF_UVT_PARAM\" ";
                //cmd = new SqlCommand(sql, Connection.sql);

                //if (Connection.sql.State != ConnectionState.Open)
                //    Connection.sql.Open();

                //SqlDataAdapter sda3 = new SqlDataAdapter(cmd);
                //DataTable dt_Sorgu3 = new DataTable();
                //sda3.Fill(dt_Sorgu3);

                //Connection.sql.Close();

                //sarfOranHesaplamaSekli = dt_Sorgu3.Rows[0][0].ToString();

                #endregion

                #region SARF ORANI HESAPLAMA
                SqlDataAdapter sda_SarfOran = new SqlDataAdapter(cmd);
                DataTable dt_SarfOran = new DataTable();
                string sarfOranSql = "";

                //if (sarfOranHesaplamaSekli == "1")
                //{
                    sarfOranSql = "Select \"U_SarfOran\" from \"OITM\" WITH (NOLOCK) where \"ItemCode\" = '" + urunKodu + "'";

                    cmd = new SqlCommand(sarfOranSql, Connection.sql);

                    if (Connection.sql.State != ConnectionState.Open)
                    {
                        Connection.sql.Open();
                    }
                    sda_SarfOran = new SqlDataAdapter(cmd);
                    sda_SarfOran.Fill(dt_SarfOran);

                #region sql connection chn 
                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }
                #endregion


                if (dt_SarfOran.Rows[0][0] != null && dt_SarfOran.Rows[0][0].ToString() != "")
                    {
                        double toplamMiktar = txtGercekMik + txtfiremik + txtnumunemik;

                        //double minMiktar = planlananMiktar - ((toplamMiktar * Convert.ToDouble(dt_SarfOran.Rows[0][0])) / 100);
                        //double maxMiktar = planlananMiktar + ((toplamMiktar * Convert.ToDouble(dt_SarfOran.Rows[0][0])) / 100);

                        double miktarinYuzdesi = (planlananMiktar * Convert.ToDouble(dt_SarfOran.Rows[0][0])) / 100;

                        double toplamGirebilecekFazlaMiktar = planlananMiktar + miktarinYuzdesi;
                        double toplamGirebilecekEksikMiktar = planlananMiktar - miktarinYuzdesi;

                        if (Convert.ToInt32(dt_SarfOran.Rows[0][0]) == 0)
                        {
                            if (planlananMiktar != toplamMiktar)
                            {
                                CustomMsgBtn.Show("Miktar girişi uyumsuzdur. Lütfen kontrol ediniz.", "Uyarı", "Tamam");
                                return;
                            }
                        }
                        else
                        {
                            if (toplamMiktar < toplamGirebilecekEksikMiktar)
                            {
                                CustomMsgBtn.Show("Miktar girişi uyumsuzdur. Lütfen kontrol ediniz.", "Uyarı", "Tamam");
                                return;
                            }


                            if (toplamMiktar > toplamGirebilecekFazlaMiktar)
                            {
                                CustomMsgBtn.Show("Miktar girişi uyumsuzdur. Lütfen kontrol ediniz.", "Uyarı", "Tamam");
                                return;
                            }
                        }

                    }
                //}
                //else if (sarfOranHesaplamaSekli == "2")
                //{

                //    sarfOranSql = "Select T1.\"U_SarfOran\" FROM OWOR AS T0 INNER JOIN WOR1 AS T1 ON T0.\"DocEntry\" = T1.\"DocEntry\" where T0.\"DocNum\" = '" + belgeNo + "'  and T1.\"ItemCode\" = '" + urunKodu + "'";
                //    cmd = new SqlCommand(sql, Connection.sql);

                //    cmd = new SqlCommand(sarfOranSql, Connection.sql);

                //    if (Connection.sql.State != ConnectionState.Open)
                //    {
                //        Connection.sql.Open();
                //    }
                //    sda_SarfOran = new SqlDataAdapter(cmd);
                //    sda_SarfOran.Fill(dt_SarfOran);

                //    if (dt_SarfOran.Rows.Count > 0)
                //    {
                //        if (dt_SarfOran.Rows[0][0] != null && dt_SarfOran.Rows[0][0].ToString() != "")
                //        {
                //            double toplamMiktar = txtGercekMik + txtfiremik + txtnumunemik;

                //            //double minMiktar = planlananMiktar - ((toplamMiktar * Convert.ToDouble(dt_SarfOran.Rows[0][0])) / 100);
                //            //double maxMiktar = planlananMiktar + ((toplamMiktar * Convert.ToDouble(dt_SarfOran.Rows[0][0])) / 100);

                //            double miktarinYuzdesi = (planlananMiktar * Convert.ToDouble(dt_SarfOran.Rows[0][0])) / 100;

                //            double toplamGirebilecekFazlaMiktar = planlananMiktar + miktarinYuzdesi;
                //            double toplamGirebilecekEksikMiktar = planlananMiktar - miktarinYuzdesi;

                //            if (Convert.ToInt32(dt_SarfOran.Rows[0][0]) == 0)
                //            {
                //                if (planlananMiktar != toplamMiktar)
                //                {
                //                    CustomMsgBtn.Show("Miktar girişi uyumsuzdur. Lütfen kontrol ediniz.", "Uyarı", "Tamam");
                //                    return;
                //                }
                //            }
                //            else
                //            {
                //                if (toplamMiktar < toplamGirebilecekEksikMiktar)
                //                {
                //                    CustomMsgBtn.Show("Miktar girişi uyumsuzdur. Lütfen kontrol ediniz.", "Uyarı", "Tamam");
                //                    return;
                //                }


                //                if (toplamMiktar > toplamGirebilecekFazlaMiktar)
                //                {
                //                    CustomMsgBtn.Show("Miktar girişi uyumsuzdur. Lütfen kontrol ediniz.", "Uyarı", "Tamam");
                //                    return;
                //                }
                //            }

                //        }
                //    }
                //}
                #endregion SARF ORANI HESAPLAMA

                if (txtGercekMik > 0)
                {
                    Miktar = txtGercekMik;
                    Close();

                    UVTServiceSoapClient client = new UVTServiceSoapClient();
                    InventoryGenEntry inventoryGenEntry = new InventoryGenEntry();
                    List<InventoryGenEntry> inventoryGenEntries = new List<InventoryGenEntry>();

                    inventoryGenEntry.UretimSiparisi = Convert.ToInt32(belgeNo);
                    inventoryGenEntry.Miktar = txtGercekMik + parseNumber.parservalues<double>(txtFireMiktari.Text.ToString()) + parseNumber.parservalues<double>(txtNumuneMiktari.Text.ToString());
                    inventoryGenEntry.Parti = partiNo;
                    inventoryGenEntry.PartiMiktar = txtGercekMik + parseNumber.parservalues<double>(txtFireMiktari.Text.ToString()) + parseNumber.parservalues<double>(txtNumuneMiktari.Text.ToString());
                    inventoryGenEntry.UrunKodu = urunKodu;
                    inventoryGenEntry.StokNakliHedefDepo = txtDepoSecimi.Text;
                    inventoryGenEntry.RotaKodu = rotaKodu;
                    inventoryGenEntry.FireMiktar = parseNumber.parservalues<double>(txtFireMiktari.Text.ToString());
                    inventoryGenEntry.NumuneMiktar = parseNumber.parservalues<double>(txtNumuneMiktari.Text.ToString());
                    inventoryGenEntry.TamamlaniyorMu = "Evet";
                    int sktgun = 0;
                    #region Kalem Anaverisi üzerinde SKT Gün alanını üretimden giriş çıkış durumlarında geçerlilik sonu alanına basmak için kullanılır
                    SqlDataAdapter sda_SKTGun = new SqlDataAdapter(cmd);
                    DataTable dt_SKTGun = new DataTable();
                    string sKTGunSql = "";

                    sKTGunSql = "Select \"U_SKTGun\" from \"OITM\" WITH (NOLOCK) where \"ItemCode\" = '" + urunKodu + "'";

                    cmd = new SqlCommand(sKTGunSql, Connection.sql);

                    if (Connection.sql.State != ConnectionState.Open)
                    {
                        Connection.sql.Open();
                    }
                    sda_SKTGun = new SqlDataAdapter(cmd);
                    sda_SKTGun.Fill(dt_SKTGun);

                    #region sql connection chn 
                    Connection.sql.Close();
                    Connection.sql.Dispose();
                    if (Connection.sql.State == ConnectionState.Open)
                    {
                        cmd.ExecuteNonQuery();
                    }
                    #endregion

                    if (dt_SKTGun.Rows[0][0] != null && dt_SKTGun.Rows[0][0].ToString() != "")
                    {
                        sktgun = Convert.ToInt32(dt_SKTGun.Rows[0][0]);
                    }
                    #endregion
                    inventoryGenEntry.SKTGun = sktgun;
                    inventoryGenEntry.UretimBaslangicTarihi = tarih;
                    inventoryGenEntry.SiparisTarihi = siparisTarihi;

                    inventoryGenEntries.Add(inventoryGenEntry);

                    var resp = client.AddInventoryGenEntry(inventoryGenEntries.ToArray(), Giris.dbName, Giris.mKodValue);

                    if (resp.Value == 0)
                    {
                        dialogResult = "Ok";
                        SqlDataAdapter sda = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        string updatesql = "";
                        foreach (var item in inventoryGenEntries)
                        {
                            updatesql = "UPDATE \"@AIF_URT_PART1\" SET \"U_Durum\" = 'C' where \"U_PartiNo\" = '" + item.Parti + "'";

                            cmd = new SqlCommand(updatesql, Connection.sql);

                            if (Connection.sql.State != ConnectionState.Open)
                            {
                                Connection.sql.Open();
                            }
                            sda = new SqlDataAdapter(cmd);
                            sda.Fill(dt);

                            #region sql connection chn 
                            Connection.sql.Close();
                            Connection.sql.Dispose(); 
                            if (Connection.sql.State == ConnectionState.Open)
                            {
                                cmd.ExecuteNonQuery();
                                
                            }
                            #endregion
                        }
                    }

                    CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");
                }
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Üretimden giriş miktarı işleminde hata oluştu. Hata Kodu: URTGRS001 " + ex.Message, "UYARI", "TAMAM");
            }
        }
        private void txtGerceklesenMiktar_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(txtGerceklesenMiktar);
            nesne.ShowDialog();
        }
        private void txtDepoSecimi_Click(object sender, EventArgs e)
        {
            string sql1 = "Select '' as \"Kod\",'' as \"Depolar\" ";
            sql1 += " UNION ALL ";
            sql1 += "Select T1.\"WhsCode\" as \"Kod\",T1.\"WhsName\" as \"Depolar\" from OITW as T0 WITH (NOLOCK) INNER JOIN OWHS as T1 WITH (NOLOCK) ON T0.\"WhsCode\" = T1.\"WhsCode\" where T0.\"ItemCode\" = '" + urunKodu + "' ";

            SelectList selectList = new SelectList(sql1, null, -1, -1, _autoresizerow: false, _type: "txtDepoSec", _txtParam: txtDepoSecimi);
            selectList.ShowDialog();
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtFireMiktari_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(txtFireMiktari);
            nesne.ShowDialog();
        }

        private void txtNumuneMiktari_Click(object sender, EventArgs e)
        {
            SayiKlavyesiNew nesne = new SayiKlavyesiNew(txtNumuneMiktari);
            nesne.ShowDialog();
        }
    }
}
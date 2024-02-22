using AIF.UVT.DatabaseLayer;
using AIF.UVT.UVTService;
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

namespace AIF.UVT.FORM_010OTATURVT
{
    public partial class TemizlikYoneticiOnay : Form
    {
        public TemizlikYoneticiOnay(string _kullaniciid, string _istasyon, string _tarih)
        {
            InitializeComponent();
            istasyon = _istasyon;
            tarih1 = _tarih;

            //txtUser.Text = _kullaniciid;
        }
        string istasyon = "";
        string tarih1 = "";
        private void TemizlikYoneticiOnay_Load(object sender, EventArgs e)
        {
            txtUser.Select();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {

                if (txtUser.Text == "")
                {
                    CustomMsgBtn.Show("Kullanıcı Adı boş bırakılamaz.", "UYARI", "TAMAM");
                    return;
                }

                if (txtPass.Text == "")
                {
                    CustomMsgBtn.Show("Kullanıcı Parolası boş bırakılamaz.", "UYARI", "TAMAM");
                    return;
                }

                SqlCommand cmd = new SqlCommand();
                DataTable dt = new DataTable();

                string sql = "select  Cast(\"Code\" as varchar(10)) as \"Kod\",\"ExtEmpNo\" as \"Pass\", \"U_UretimYoneticisi\" as \"UretimYoneticisi\" from OHEM WITH (NOLOCK)";

                cmd = new SqlCommand(sql, Connection.sql);

                if (Connection.sql.State != ConnectionState.Open)
                    Connection.sql.Open();

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);

                #region Kullanıcı Doğrulama

                if (txtUser.Text != "" && txtPass.Text != "")
                {
                    var userExist = dt.Select("Kod = '" + txtUser.Text + "'").Count();
                    if (userExist == 0)
                    {
                        CustomMsgBtn.Show("Kullanıcı Bulunamadı.", "UYARI", "TAMAM");
                        btnOnay.Visible = false;
                        btnRed.Visible = false;
                        label3.Visible = false;
                        rchAciklama.Visible = false;
                        return;
                    }
                    else
                    {

                        var user = dt.AsEnumerable().Where(x => x.Field<string>("Kod") == txtUser.Text && x.Field<string>("Pass") == txtPass.Text).ToList();

                        if (user.Count == 0)
                        {
                            CustomMsgBtn.Show("Kullanıcı adı veya şifre yanlış.", "UYARI", "TAMAM");
                            btnOnay.Visible = false;
                            btnRed.Visible = false;
                            label3.Visible = false;
                            rchAciklama.Visible = false;
                            return;
                        }
                        else
                        {
                            var user2 = dt.AsEnumerable().Where(x => x.Field<string>("UretimYoneticisi") == "E").ToList();

                            if (user2.Count == 0)
                            {
                                CustomMsgBtn.Show("Yönetici yetkiniz bulunmamaktadır.", "UYARI", "TAMAM");
                                btnOnay.Visible = false;
                                btnRed.Visible = false;
                                label3.Visible = false;
                                rchAciklama.Visible = false;
                                return;
                            }
                            else
                            {
                                btnOnay.Visible = true;
                                btnRed.Visible = true;
                                label3.Visible = true;
                                rchAciklama.Visible = true;
                            }
                        }

                    }
                }

                #endregion Kullanıcı Doğrulama
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show(ex.Message.ToUpper(), "UYARI", "TAMAM");
            }
        }

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient UVTServiceSoapClient = new UVTServiceSoapClient();
                AnalizTemizlik nesne = new AnalizTemizlik();

                nesne.IstasyonKodu = istasyon;
                nesne.IstasyonTanimi = "";
                DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                nesne.Tarih = dtTarih.ToString("yyyyMMdd");
                nesne.YoneticiOnayi = "E";
                nesne.YoneticiOnayTarihi = DateTime.Now.ToString("yyyyMMdd");
                nesne.YoneticiOnayAciklama = rchAciklama.Text;

                var resp = UVTServiceSoapClient.AddOrUpdateTemizlik(nesne, Giris.dbName, Giris.mKodValue);

                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show(ex.Message.ToUpper(), "UYARI", "TAMAM");
            }
        }

        private void btnRed_Click(object sender, EventArgs e)
        {
            try
            {
                UVTServiceSoapClient UVTServiceSoapClient = new UVTServiceSoapClient();
                AnalizTemizlik nesne = new AnalizTemizlik();

                nesne.IstasyonKodu = istasyon;
                nesne.IstasyonTanimi = "";
                DateTime dtTarih = new DateTime(Convert.ToInt32(tarih1.Substring(0, 4)), Convert.ToInt32(tarih1.Substring(4, 2)), Convert.ToInt32(tarih1.Substring(6, 2)));
                nesne.Tarih = dtTarih.ToString("yyyyMMdd");
                nesne.YoneticiOnayi = "H";
                nesne.YoneticiOnayTarihi = DateTime.Now.ToString("yyyyMMdd");
                nesne.YoneticiOnayAciklama = rchAciklama.Text;

                var resp = UVTServiceSoapClient.AddOrUpdateTemizlik(nesne, Giris.dbName, Giris.mKodValue);

                CustomMsgBtn.Show(resp.Description, "UYARI", "TAMAM");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show(ex.Message.ToUpper(), "UYARI", "TAMAM");
            }
        }
    }
}

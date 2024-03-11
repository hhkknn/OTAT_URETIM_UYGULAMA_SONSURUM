using AIF.UVT.DatabaseLayer;
using AIF.UVT.FORM_ORTAK;
using AIF.UVT.Models;
using AIF.UVT.UVTService;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using Newtonsoft.Json;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Deployment.Application;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace AIF.UVT
{
    public partial class Giris : Form
    {
        //cOMMT i

        #region Font İşlemleri

        public int initialWidth;
        public int initialHeight;
        public float initialFontSize;

        #endregion Font İşlemleri

        public Giris()
        {
            #region Update işlemleri

            //mKodValue = "20URVT";

            //WebClient request = new WebClient();

            //string url = "ftp://ftp.tanas.com.tr/UVT/" + "version.xml";

            //try
            //{
            //    var _assembly = System.Reflection.Assembly
            //        .GetExecutingAssembly().GetName().CodeBase;

            //    var _path = System.IO.Path.GetDirectoryName(_assembly) + "\\";

            //    string configFile = System.IO.Path.Combine(_path, "AIF.UVT_AutoUpdate.exe.config");
            //    ExeConfigurationFileMap configFileMap = new ExeConfigurationFileMap();
            //    configFile = configFile.Replace("file:\\", "");
            //    configFileMap.ExeConfigFilename = configFile;
            //    System.Configuration.Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFileMap, ConfigurationUserLevel.None);

            //    config.AppSettings.Settings["MusteriKodu"].Value = mKodValue;
            //    config.Save();
            //}
            //catch (Exception)
            //{
            //}

            //request.Credentials = new NetworkCredential("aif@aifteam.com", "SJ^FB5TAKDGq");

            //try
            //{
            //    byte[] newFileData = request.DownloadData(url);
            //    string fileString = System.Text.Encoding.UTF8.GetString(newFileData);

            //    XmlDocument xmlDoc = new XmlDocument();
            //    string _byteOrderMarkUtf8 = Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble());
            //    if (fileString.StartsWith(_byteOrderMarkUtf8))
            //    {
            //        fileString = fileString.Remove(0, _byteOrderMarkUtf8.Length);
            //    }
            //    xmlDoc.LoadXml(fileString);
            //    XmlNodeList parentNode = xmlDoc.GetElementsByTagName("version");

            //    var aaa = parentNode[0].InnerText;
            //    //url = "ftp://ftp.tanas.com.tr/UVT/" + "AIF.UVT.exe";
            //    //request.DownloadFile(url, @"C:\KargoLog\" + "AIF.UVT.exe");

            //    if (exeVersion != aaa)
            //    {
            //        if (MessageBox.Show("Uygulamanın güncel versiyonu yayınlanmıştır, Yüklemek istiyor musunuz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            //        {
            //            //this.Close();
            //            //Dispose();
            //            //Application.Exit();
            //        }
            //        else
            //        {
            //            this.Close();
            //            Dispose();
            //            Application.Exit();
            //            System.Diagnostics.Process.Start(Application.StartupPath + "\\AIF.UVT_AutoUpdate.exe");
            //        }
            //        //    System.Threading.Thread t = new System.Threading.Thread(
            //        //new System.Threading.ThreadStart(updatexe)

            //        //);
            //        //    t.Start();
            //    }
            //}
            //catch (WebException ex)
            //{
            //}

            //txtUserName.Text = Properties.Settings.Default["username"].ToString();
            ////txtPassword.Text = Properties.Settings.Default["password"].ToString();
            //if (txtUserName.Text.Count() > 0)
            //    chkBeniHatirla.Checked = true;

            #endregion Update işlemleri

            InitializeComponent();

            #region Font işlemleri

            AutoScaleMode = AutoScaleMode.None;

            initialWidth = Width;
            initialHeight = Height;

            initialFontSize = label1.Font.Size;
            label1.Resize += Form_Resize;

            initialFontSize = label2.Font.Size;
            label2.Resize += Form_Resize;

            initialFontSize = textBox1.Font.Size;
            textBox1.Resize += Form_Resize;

            initialFontSize = textBox2.Font.Size;
            textBox2.Resize += Form_Resize;

            initialFontSize = btnGiris.Font.Size;
            btnGiris.Resize += Form_Resize;

            initialFontSize = btnIptal.Font.Size;
            btnIptal.Resize += Form_Resize;

            #endregion Font işlemleri
        }

        private void Form_Resize(object sender, EventArgs e)
        {
            #region Font İşlemleri

            SuspendLayout();
            float proportionalNewWidth = (float)Width / initialWidth;
            float proportionalNewHeight = (float)Height / initialHeight;

            label1.Font = new Font(label1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label1.Font.Style);

            label2.Font = new Font(label2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label2.Font.Style);

            textBox1.Font = new Font(textBox1.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                textBox1.Font.Style);

            textBox2.Font = new Font(textBox2.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                textBox2.Font.Style);

            btnGiris.Font = new Font(btnGiris.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnGiris.Font.Style);

            btnIptal.Font = new Font(btnIptal.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                btnIptal.Font.Style);

            label3.Font = new Font(label3.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                label3.Font.Style);

            cmbCompany.Font = new Font(cmbCompany.Font.FontFamily, initialFontSize *
                (proportionalNewWidth > proportionalNewHeight ? proportionalNewHeight : proportionalNewWidth),
                cmbCompany.Font.Style);

            ResumeLayout();

            #endregion Font İşlemleri
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

        //public static SAPbobsCOM.Company oCompany;

        public static string exeVersion = "1.0.0.40";
        public static string mKodValue = System.Configuration.ConfigurationManager.AppSettings["MusteriKodu"];
        private List<ComboValues> comboValues = new List<ComboValues>();
        public static string value = "";
        public static SqlConnection sqlConnection_Uvt = null;
        public static string dbName = "";
        public static string id = "";

        //Version myVersion;
        private void Giris_Load(object sender, EventArgs e)
        { 
            mKodValue = "010OTATURVT";
            //mKodValue = "20URVT";

            //if (ApplicationDeployment.IsNetworkDeployed)
            //{
            //    myVersion = ApplicationDeployment.CurrentDeployment.CurrentVersion;
            //}

            //lblVersion.Text = String.Concat("V" + myVersion);

            //lblVersion.Text = System.Reflection.Assembly.GetAssembly.myVersion.ToString();
            lblVersion.Text = "V" + exeVersion;

            textBox2.Focus();

            Library.Helper n = new Library.Helper();
            n.SetAllControlsFont(Controls);

            #region MKOD İle Background Değişimi

            var lastOpenedForm = Application.OpenForms.Cast<Form>().Last();

            if (mKodValue == "010OTATURVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.OTAT_UVT_ArkaPlanV3;
            }
            else if (mKodValue == "20URVT")
            {
                lastOpenedForm.BackgroundImage = Properties.Resources.YORUK_UVT_ArkaPlanv2;
            }

            #endregion MKOD İle Background Değişimi

            UVTService.UVTServiceSoapClient UVTServiceSoapClient = new UVTService.UVTServiceSoapClient();
            Response response = new Response();
            response = UVTServiceSoapClient.GetCompanyList("", mKodValue);
            if (response.List.Rows.Count > 0)
            {
                cmbCompany.DataSource = response.List;
                cmbCompany.DisplayMember = "cmpName";
                cmbCompany.ValueMember = "dbName";
                cmbCompany.Enabled = true;
            } 
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            try
            {
                #region cc

                try
                {
                    #region config

                    IFirebaseConfig config = new FirebaseConfig
                    {
                        BasePath = "https://mfhcdc-e278f-default-rtdb.firebaseio.com/",
                    };

                    IFirebaseClient client;

                    #endregion config

                    client = new FireSharp.FirebaseClient(config);

                    if (client == null)
                    {
                        //MessageBox.Show("Base Bağlantı hatasi.");
                    }
                    else
                    {
                        if (mKodValue == "")
                        {
                            CustomMsgBtn.Show("Müşteri kodu bulunamadı.", "UYARI", "TAMAM");
                            System.Windows.Forms.Application.Exit();
                            return;
                        }
                        FirebaseResponse response = client.Get(mKodValue);

                        if (response != null)
                        {
                            Veri result = response.ResultAs<Veri>();

                            if (result != null)
                            {
                                if (!string.IsNullOrEmpty(result.val.ToString()))
                                {
                                    DateTime dt1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
                                    DateTime dt3 = DateTime.ParseExact(result.val, "yyyyMMdd", System.Globalization.CultureInfo.InvariantCulture);
                                    //dt2 = new DateTime(dt2.Year, dt2.Month, dt2.Day);
                                    DateTime date = GetTime().Date;

                                    int d = Convert.ToInt32((dt3 - date).TotalDays);

                                    if (d <= 0)
                                    {
                                        //if (date == result.val)
                                        //{
                                        CustomMsgBtn.Show("Program kullanım süresi dolmuştur. Kullanıma devam edebilmek için AIFTEAM ile irtibata geçiniz.", "UYARI", "TAMAM");

                                        #region menu remove

                                        try
                                        {
                                            //if (muhatapmutabakat == "Y")
                                            //{
                                            //    Handler.SAPApplication.Menus.RemoveEx("mhtpMtbkt");
                                            //}
                                        }
                                        catch (Exception)
                                        {
                                        }

                                        #endregion menu remove

                                        System.Windows.Forms.Application.Exit();
                                        //System.Windows.Forms.Application.ExitThread();
                                        return;
                                        //Close();
                                        //}
                                    }

                                    if (d > 0)
                                    {
                                        if (!string.IsNullOrEmpty(result.inf.ToString()))
                                        {
                                            if (Convert.ToInt32(result.inf) != 0)
                                            {
                                                if (d <= Convert.ToInt32(result.inf))
                                                {
                                                    CustomMsgBtn.Show("Program kullanım süresinin bitimine " + d + " gün kalmıştır. Kullanıma devam edebilmek için AIFTEAM ile irtibata geçiniz.", "UYARI", "TAMAM");
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    CustomMsgBtn.Show("Base hatası oluştu.", "UYARI", "TAMAM");
                    return;
                }

                #endregion cc

                UVTServiceSoapClient UVTServiceSoapClient = new UVTServiceSoapClient();
                string db = cmbCompany.SelectedValue.ToString();

                sqlConnection_Uvt = new SqlConnection(UVTServiceSoapClient.getConnectionAsString(db, mKodValue));

                if (db == "")
                {
                    CustomMsgBtn.Show("Şirket seçimi yapmadan işleme devam edilemez.", "UYARI", "TAMAM");
                    return;
                }

                #region Databaseden Kullanıcı Okuma

                //SqlCommand cmdw = new SqlCommand("select \"U_UVTKod\" as Kod, \"U_UVTPass\" as Pass,\"firstName\" as Ad,\"lastName\" as Soyad from OHEM where ISNULL(\"U_UVTKod\",'')<>''", Giris.sqlConnection_Uvt);

                //Giris.sqlConnection_UvtStringVal = cmbCompany.SelectedValue.ToString();

                SqlCommand cmd = null;

                if (mKodValue == "010OTATURVT") //2022.03.29 chn
                {
                    cmd = new SqlCommand("select  Cast(\"Code\" as varchar(10)) as \"Kod\",\"ExtEmpNo\" as \"Pass\",\"firstName\" as Ad,\"lastName\" as Soyad,\"U_UretimCalisani\",\"U_KaliteCalisani\" from OHEM WITH (NOLOCK)", sqlConnection_Uvt);
                }
                if (mKodValue == "20URVT")
                {
                    cmd = new SqlCommand("select  Cast(\"empID\" as varchar(10)) as \"Kod\",\"ExtEmpNo\" as \"Pass\",\"firstName\" as Ad,\"lastName\" as Soyad from OHEM WITH (NOLOCK)", sqlConnection_Uvt);
                }

                if (sqlConnection_Uvt.State == ConnectionState.Closed)
                {
                    sqlConnection_Uvt.Open();
                }

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                sqlConnection_Uvt.Close();
                sqlConnection_Uvt.Dispose();

                #region sql connection chn

                if (sqlConnection_Uvt.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }

                #endregion sql connection chn

                #endregion Databaseden Kullanıcı Okuma

                string kullaniciadi = textBox2.Text;
                string kullaniciParolasi = textBox1.Text;
                if (textBox2.Text == "")
                {
                    CustomMsgBtn.Show("Kullanıcı Adı boş bırakılamaz.", "UYARI", "TAMAM");
                    return;
                }

                if (kullaniciParolasi == "")
                {
                    CustomMsgBtn.Show("Kullanıcı Parolası boş bırakılamaz.", "UYARI", "TAMAM");
                    return;
                }

                #region Kullanıcı Doğrulama

                if (textBox2.Text != "" && kullaniciParolasi != "")
                {
                    var userExist = dt.Select("Kod = '" + kullaniciadi + "'").Count();
                    if (userExist == 0)
                    {
                        CustomMsgBtn.Show("Kullanıcı Bulunamadı.", "UYARI", "TAMAM");
                        return;
                    }
                    else
                    {
                        var user = (from cst in dt.AsEnumerable()
                                    where cst.Field<string>("Kod") == kullaniciadi && cst.Field<string>("Pass") == kullaniciParolasi
                                    select new
                                    {
                                        firstNameLastName = cst.Field<string>("Ad") + " " + cst.Field<string>("Soyad"),
                                        kalite = cst.Field<string>("U_KaliteCalisani"),
                                        uretim = cst.Field<string>("U_UretimCalisani")
                                    }).ToList();

                        if (user.Count == 0)
                        {
                            CustomMsgBtn.Show("Kullanıcı adı veya şifre yanlış.", "UYARI", "TAMAM");
                            return;
                        }

                        KaliteCalisaniMi = user.Select(x => x.kalite).First();
                        UretimCalisaniMi = user.Select(X => X.uretim).First();

                        //progressbar = true;
                        //ProgressBar prgress = new ProgressBar(ListeleData);
                        //prgress.ShowDialog(this);
                        dbName = cmbCompany.SelectedValue.ToString();
                        id = textBox2.Text;
                        try
                        {
                            var connectresp = UVTServiceSoapClient.Login("", "", dbName, mKodValue);

                            if (connectresp.Value != 0)
                            {
                                CustomMsgBtn.Show(connectresp.Description, "UYARI", "TAMAM");
                                return;
                            }
                        }
                        catch (Exception ex)
                        {
                            CustomMsgBtn.Show("Hata." + ex.Message, "UYARI", "TAMAM");
                            return;
                        }

                        textBox1.Text = "";
                        textBox2.Text = "";
                        AtanmisIsler frm = new AtanmisIsler(user.Select(x => x.firstNameLastName).Count() > 0 ? user.Select(x => x.firstNameLastName).First() : "", this, kullaniciadi, Width, Height);
                        //progressbar = false;
                        //prgress.Close();
                        frm.Show();
                        Hide();
                    }
                }

                #endregion Kullanıcı Doğrulama

                cmd = new SqlCommand("select \"U_UrtPrtSekli\" as \"UrtPrtSekli\", \"U_OndalikMiktar\" from \"@AIF_UVT_PARAM\" WITH (NOLOCK)", Connection.sql);

                #region fifo
                //cmd = new SqlCommand("select \"U_UrtPrtSekli\" as \"UrtPrtSekli\", \"U_OndalikMiktar\",\"U_FifoGoreSarf\" from \"@AIF_UVT_PARAM\" WITH (NOLOCK)", Connection.sql);
                #endregion

                if (Connection.sql.State == ConnectionState.Closed)
                {
                    Connection.sql.Open();
                }

                sda = new SqlDataAdapter(cmd);
                DataTable dt2 = new DataTable();
                sda.Fill(dt2);

                if (dt2.Rows.Count > 0)
                {
                    UretimPartilendirmeSekli = dt2.Rows[0][0].ToString();
                    OndalikMiktar = Convert.ToInt32(dt2.Rows[0][1]);
                    #region fifo
                    //FifoyaGoreSarfEt = dt2.Rows[0][2].ToString();
                    #endregion
                }

                #region sql connection chn

                Connection.sql.Close();
                Connection.sql.Dispose();
                if (Connection.sql.State == ConnectionState.Open)
                {
                    cmd.ExecuteNonQuery();
                }

                #endregion sql connection chn
            }
            catch (Exception ex)
            {
                CustomMsgBtn.Show("Giriş yapılırken hata oluştu. Hata Kodu GRS001 " + ex.Message, "UYARI", "TAMAM");
            }
        }

        public static string UretimPartilendirmeSekli = "";
        public static int OndalikMiktar = 0;
        public static string KaliteCalisaniMi = "N";
        public static string UretimCalisaniMi = "N";
        public static string FifoyaGoreSarfEt = "N";

        private void btnIptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SetAllControlsFont(Control.ControlCollection ctrls)
        {
            foreach (Control ctrl in ctrls)
            {
                if (ctrl.Controls != null)
                    SetAllControlsFont(ctrl.Controls);

                if (ctrl.AccessibilityObject.Role == AccessibleRole.StaticText)
                    ctrl.Font = new Font("Bahnschrift SemiCondensed", ctrl.Font.Size - 4, FontStyle.Bold);
                else
                    ctrl.Font = new Font("Bahnschrift SemiCondensed", ctrl.Font.Size - 2, FontStyle.Bold);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //START FORM GENİŞLİK YÜKSEKLİK
            float forGen = Width;
            float forYuk = Height;

            CustomMsgBtn.Show("Genişlik" + forGen + "Yükseklik" + forYuk, "UYARI", "TAMAM");

            //END FORM GENİŞLİK YÜKSEKLİK
        }

        private void cmbCompany_DropDownClosed(object sender, EventArgs e)
        {
            textBox2.Select();
        }

        public static DateTime GetTime()
        {
            try
            {
                using (var response =
                  WebRequest.Create("http://www.google.com").GetResponse())
                    //string todaysDates =  response.Headers["date"];
                    return DateTime.ParseExact(response.Headers["date"],
                        "ddd, dd MMM yyyy HH:mm:ss 'GMT'",
                        CultureInfo.InvariantCulture.DateTimeFormat,
                        DateTimeStyles.AssumeUniversal);
            }
            catch (WebException)
            {
                return DateTime.Now; //In case something goes wrong.
            }
        }

        public class Veri
        {
            public string val { get; set; }
            public string inf { get; set; }
        }
    }
}
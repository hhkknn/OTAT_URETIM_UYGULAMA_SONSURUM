using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT_AutoUpdate
{
    public partial class frmAutoUpdate : Form
    {
        public frmAutoUpdate()
        {
            InitializeComponent();
            _worker.WorkerReportsProgress = true;
            _worker.DoWork += _worker_DoWork;
            _worker.ProgressChanged += WorkerProgressChanged;
            _worker.RunWorkerCompleted += WorkerRunWorkerCompleted;
        }
        private readonly BackgroundWorker _worker = new BackgroundWorker();
        private int prgresssize = 0;
        private void frmAutoUpdate_Load(object sender, EventArgs e)
        {


            ftpAdress = "ftp://ftp.tanas.com.tr/UVT_OTAT/";

            var dosyalar = ListFiles();
            progressBar1.Maximum = dosyalar.Count;
            _worker.RunWorkerAsync();
        }

        private string ftpAdress = "";

        private List<string> ListFiles()
        {
            try
            {
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpAdress);
                request.Method = WebRequestMethods.Ftp.ListDirectory;

                request.Credentials = new NetworkCredential("aif@aifteam.com", "SJ^FB5TAKDGq");
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                Stream responseStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(responseStream);
                string names = reader.ReadToEnd();

                reader.Close();
                response.Close();

                return names.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
            catch (Exception)
            {
                return null;

            }
        }
        private void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\UpdateLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }

        private void _worker_DoWork(object sender, DoWorkEventArgs e)
        {
            //MessageBox.Show("Test");
            var worker = sender as BackgroundWorker;
            WriteToFile(DateTime.Now + "--> Exe update etme işlemi başladı.");
            var _assembly = System.Reflection.Assembly
             .GetExecutingAssembly().GetName().CodeBase;

            var _path = System.IO.Path.GetDirectoryName(_assembly) + "\\";
            _path = _path.Replace("file:\\", "");
            //MessageBox.Show("Test1");

            WriteToFile(DateTime.Now + " Exe dosyasının çalıştığı ana klasör yolu --> " + _path);

            var dosyalar = ListFiles();
            int i = 1;
            prgresssize = dosyalar.Count;
            WriteToFile(DateTime.Now + " Yüklenecek dosya sayısı --> " + dosyalar.Count);
            WebClient request = new WebClient();
            string url = ftpAdress;
            request.Credentials = new NetworkCredential("aif@aifteam.com", "SJ^FB5TAKDGq");
            try
            {
                foreach (var item in dosyalar)
                {
                    try
                    {
                        WriteToFile(DateTime.Now + " Yüklenecek dosya adı --> " + item);
                        if (item == ".")
                        {
                            continue;
                        }

                        url = ftpAdress + item;
                        request.DownloadFile(url, _path + item);

                        WriteToFile(DateTime.Now + " Dosya yüklendi --> " + _path + item);
                    }
                    catch (Exception ex)
                    {
                        WriteToFile(DateTime.Now + " " + item + " Dosyası yüklenirken hata oluştu. --> " + ex.Message);
                    }
                    finally
                    {
                        worker.ReportProgress(i);
                        i++;
                    }
                }

                //MessageBox.Show("Güncelleme Tamamlandı");

                this.Close();
                Dispose();
                Application.Exit();
                System.Diagnostics.Process.Start(Application.StartupPath + "\\AIF.UVT.exe");
            }
            catch (Exception ex)
            {
                WriteToFile(DateTime.Now + " Genel Hata. --> " + ex.Message);
            }
        }

        private void WorkerProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }
        private void WorkerRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //progressBarControl1.EditValue = 0;
        }
    }
}

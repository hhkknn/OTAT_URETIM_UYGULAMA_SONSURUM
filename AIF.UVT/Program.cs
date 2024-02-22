using AIF.UVT.FORM_010OTATURVT;
using AIF.UVT.FORM_ORTAK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AIF.UVT
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            #region exe açık kontolü

            //int exeSayisi = 0;
            //string processName = "AIF.UVT.exe";

            //string query = "Select * from Win32_Process Where Name = \"" + processName + "\"";
            //ManagementObjectSearcher searcher = new ManagementObjectSearcher(query);
            //ManagementObjectCollection processList = searcher.Get();
            //foreach (ManagementObject obj in processList)
            //{
            //    string[] argList = new string[] { string.Empty, string.Empty };
            //    int returnVal = Convert.ToInt32(obj.InvokeMethod("GetOwner", argList));
            //    if (returnVal == 0)
            //    {
            //        string owner = argList[1] + "\\" + argList[0];

            //        if (argList[0].ToString() == System.Windows.Forms.SystemInformation.UserName.ToString() && exeSayisi >= 1)
            //        {
            //            CustomMsgBtn.Show("Bu uygulama şu an açık durumdadır. Tekrar açılamaz.", "UYARI", "TAMAM");
            //            Application.Exit();
            //            return;
            //        }
            //        else if (argList[0].ToString() == System.Windows.Forms.SystemInformation.UserName.ToString())
            //        {
            //            exeSayisi++;
            //        }
            //    }
            //}

            #endregion exe açık kontolü

            System.Net.ServicePointManager.ServerCertificateValidationCallback +=
       (se, cert, chain, sslerror) =>
       {
           return true;
       };
            //ShowSplash();
            //commit.
            Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new _20_FSAPKY_007_2_2("", "", "", "", "", "", 1, ""));
            Application.Run(new Giris());
            //Application.Run(new TelemeProsesTakip(1920, 1080));
            //Application.Run(new SaatTarihGirisi(null));
        }
    }
}
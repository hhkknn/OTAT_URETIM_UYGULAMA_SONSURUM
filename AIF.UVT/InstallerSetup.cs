using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace AIF.UVT
{
    [RunInstaller(true)]
    public partial class InstallerSetup : System.Configuration.Install.Installer
    {
        public InstallerSetup() : base()
        {
            //InitializeComponent();
             
        }
        private void InstallerSetup_Committing(object sender, InstallEventArgs e)
        {
            WriteToFile("");
            WriteToFile("Committing Event occured.");
            WriteToFile("");
        }
        // Event handler for 'Committed' event.
        private void InstallerSetup_Committed(object sender, InstallEventArgs e)
        {
            WriteToFile("");
            WriteToFile("Committed Event occured.");
            WriteToFile("");
        }

        // Override the 'Install' method.
        public override void Install(IDictionary savedState)
        {
            base.Install(savedState);
        }
        public override void Commit(IDictionary savedState)
        {
            base.Commit(savedState);

            try
            {
                AddConfigurationFileDetails();
            }
            catch (Exception ex)
            {
                WriteToFile(DateTime.Now + " " + "AddConfigurationFileDetails Metodu yüklenirken hata oluştu. --> " + ex.Message);
                base.Rollback(savedState);

            }
        }
        public override void Rollback(IDictionary savedState)
        {
            base.Rollback(savedState);
        }
        public override void Uninstall(IDictionary savedState)
        {
            base.Uninstall(savedState);
        }
        //public static void Main()
        //{
        //    Console.WriteLine("Usage : installutil.exe Installer.exe ");
        //}
        private void AddConfigurationFileDetails()
        {
            try
            {
                string MKOD = Context.Parameters["MKOD"];
                WriteToFile("MKOD: " + MKOD);

                // Get the path to the executable file that is being installed on the target computer
                string assemblypath = Context.Parameters["assemblypath"];
                string appConfigPath = assemblypath + ".config";

                // Write the path to the app.config file
                XmlDocument doc = new XmlDocument();
                doc.Load(appConfigPath);

                XmlNode configuration = null;
                foreach (XmlNode node in doc.ChildNodes)
                    if (node.Name == "configuration")
                        configuration = node;

                if (configuration != null)
                {
                    //MessageBox.Show("configuration != null");
                    // Get the ‘appSettings’ node
                    XmlNode settingNode = null;
                    foreach (XmlNode node in configuration.ChildNodes)
                    {
                        if (node.Name == "appSettings")
                            settingNode = node;
                    }

                    if (settingNode != null)
                    {
                        //MessageBox.Show("settingNode != null");
                        //Reassign values in the config file
                        foreach (XmlNode node in settingNode.ChildNodes)
                        {
                            //MessageBox.Show("node.Value = " + node.Value);
                            if (node.Attributes == null)
                                continue;
                            XmlAttribute attribute = node.Attributes["value"];
                            //MessageBox.Show("attribute != null ");
                            //MessageBox.Show("node.Attributes['value'] = " + node.Attributes["value"].Value);
                            if (node.Attributes["key"] != null)
                            {
                                //MessageBox.Show("node.Attributes['key'] != null ");
                                //MessageBox.Show("node.Attributes['key'] = " + node.Attributes["key"].Value);
                                switch (node.Attributes["key"].Value)
                                {
                                    case "MusteriKodu":
                                        attribute.Value = MKOD;
                                        break;
                                }
                                WriteToFile("attribute.Value: " + attribute.Value);
                            }
                        }
                    }
                    doc.Save(appConfigPath); 
                }
            }
            catch
            {
            }
        }

        private void WriteToFile(string Message)
        {
            string path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string filepath = AppDomain.CurrentDomain.BaseDirectory + "\\Logs\\InstallLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
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

    }
}

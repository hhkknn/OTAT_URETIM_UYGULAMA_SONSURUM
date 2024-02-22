using AIF.UVT.Console.Models;
using Newtonsoft.Json;
using SAPbobsCOM;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Contacts = AIF.UVT.Console.Models.Contacts;

namespace AIF.UVT.Console
{
    class Program
    {
        public static SAPbobsCOM.Company oCompany;
        static void Main(string[] args)
        {

            ServicePointManager
          .ServerCertificateValidationCallback +=
          (sender, cert, chain, sslPolicyErrors) => true;
            oCompany = new SAPbobsCOM.Company();

            string licenseServer = ConfigurationManager.AppSettings["LicenseServer"];
            string server = ConfigurationManager.AppSettings["Server"];
            string username = ConfigurationManager.AppSettings["UserName"];
            string password = ConfigurationManager.AppSettings["Password"];
            string companydb = ConfigurationManager.AppSettings["CompanyDB"];
            int serverType = Convert.ToInt32(ConfigurationManager.AppSettings["DbServerType"]);
            string sldServer = "";

            try
            {
                sldServer = ConfigurationManager.AppSettings["SLDServer"];
            }
            catch (Exception)
            {
            }


            oCompany.LicenseServer = licenseServer;
            if (sldServer != "")
            {
                oCompany.SLDServer = sldServer;
            }
            oCompany.Server = server;
            oCompany.UserName = username;
            oCompany.Password = password;
            oCompany.CompanyDB = companydb;
            oCompany.DbServerType = (SAPbobsCOM.BoDataServerTypes)serverType;

            int retval = oCompany.Connect();
            if (retval == 0)
            {
                AktiviteEklemeGuncellemeIslemleri();
            }
            else
            {
                var aaa = oCompany.GetLastErrorDescription();
            }
        }


        private static void AktiviteEklemeGuncellemeIslemleri()
        {
            SAPbobsCOM.Recordset oRS = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);
            SAPbobsCOM.Recordset oRS_Update = (SAPbobsCOM.Recordset)oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset);

            oRS.DoQuery("Select * from \"@AIF_UVTDATA\" where \"U_Durum\" = 'P' and \"U_Tip\" = '1' ");

            string code = "";
            string json = "";
            while (!oRS.EoF)
            {
                code = oRS.Fields.Item("Code").Value.ToString();
                json = oRS.Fields.Item("U_IstekJson").Value.ToString();


                Contacts contacts = new Contacts();

                contacts = JsonConvert.DeserializeObject<Contacts>(json);


                if (contacts.Closed != null && contacts.Closed == "Y")
                {
                    #region Aktivite Güncelleme işlemi

                    SAPbobsCOM.CompanyService companyService = null;
                    SAPbobsCOM.ActivitiesService activitiesService = null;

                    companyService = oCompany.GetCompanyService();
                    activitiesService = (SAPbobsCOM.ActivitiesService)companyService.GetBusinessService(SAPbobsCOM.ServiceTypes.ActivitiesService);

                    ActivityParams oParams = (ActivityParams)activitiesService.GetDataInterface(ActivitiesServiceDataInterfaces.asActivityParams);
                    oParams.ActivityCode = Convert.ToInt32(contacts.ClgCode);
                    Activity oGet = activitiesService.GetActivity(oParams);

                    oGet.EndTime = contacts.EndTime;
                    oGet.Status = Convert.ToInt32(contacts.Status);
                    oGet.UserFields.Item("U_KullaniciId").Value = contacts.UserId;
                    if (contacts.Closed == "Y")
                        oGet.Closed = BoYesNoEnum.tYES;

                    try
                    {
                        activitiesService.UpdateActivity(oGet);

                        string ss = "UPDATE \"@AIF_UVTDATA\" SET \"U_Durum\" = 'S' , \"U_DurumAciklama\" = 'Başarılı',\"U_OlusanNo\" = '" + contacts.ClgCode + "',\"U_SAPCevapKod\" = 0, \"U_IslemeTarihi\" = '" + DateTime.Now.ToString("yyyyMMdd") + "', \"U_IslemeSaati\" = '" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString() + "' where \"Code\" = '" + code + "' ";
                        oRS_Update.DoQuery(ss);
                    }
                    catch (Exception ex)
                    {
                        string ss = "UPDATE \"@AIF_UVTDATA\" SET \"U_Durum\" = 'E' , \"U_DurumAciklama\" = '" + oCompany.GetLastErrorDescription() + "',\"U_OlusanNo\" = '" + contacts.ClgCode + "',\"U_SAPCevapKod\" = " + oCompany.GetLastErrorCode() + ", \"U_IslemeTarihi\" = '" + DateTime.Now.ToString("yyyyMMdd") + "', \"U_IslemeSaati\" = '" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString() + "' where \"Code\" = '" + code + "'";

                        oRS_Update.DoQuery(ss); 
                    }
                    #endregion
                }
                else
                {
                    #region Aktivite ekleme işlemi
                    SAPbobsCOM.CompanyService companyService = null;
                    SAPbobsCOM.ActivitiesService activitiesService = null;
                    SAPbobsCOM.Activity activity = null;

                    companyService = oCompany.GetCompanyService();
                    activitiesService = (SAPbobsCOM.ActivitiesService)companyService.GetBusinessService(SAPbobsCOM.ServiceTypes.ActivitiesService);

                    activity = (SAPbobsCOM.Activity)activitiesService.GetDataInterface(SAPbobsCOM.ActivitiesServiceDataInterfaces.asActivity);

                    activity.HandledByEmployee = Convert.ToInt32(contacts.ContactId);
                    activity.Activity = (SAPbobsCOM.BoActivities)Convert.ToInt32(contacts.ContactType);
                    activity.ActivityType = Convert.ToInt32(contacts.ContactSubType);
                    activity.StartDate = Convert.ToDateTime(new DateTime(Convert.ToInt32(contacts.StartDate.Substring(0, 4)), Convert.ToInt32(contacts.StartDate.Substring(4, 2)), Convert.ToInt32(contacts.StartDate.Substring(6, 2))));
                    activity.StartTime = contacts.StartTime;
                    activity.Status = Convert.ToInt32(contacts.Status);
                    activity.Personalflag = SAPbobsCOM.BoYesNoEnum.tYES;
                    activity.UserFields.Item("U_RotaCode").Value = contacts.RotaKodu;
                    activity.UserFields.Item("U_PartiNo").Value = contacts.PartiNo;
                    activity.UserFields.Item("U_KullaniciId").Value = contacts.UserId;


                    var aa = activitiesService.AddActivity(activity);

                    if (aa.ActivityCode != 0)
                    {

                        string ss = "UPDATE \"@AIF_UVTDATA\" SET \"U_Durum\" = 'S' , \"U_DurumAciklama\" = 'Başarılı',\"U_OlusanNo\" = '" + aa.ActivityCode + "',\"U_SAPCevapKod\" = 0, \"U_IslemeTarihi\" = '" + DateTime.Now.ToString("yyyyMMdd") + "', \"U_IslemeSaati\" = '" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString() + "' where \"Code\" = '" + code + "'";
                        oRS_Update.DoQuery(ss);
                    }
                    else
                    {
                        string ss = "UPDATE \"@AIF_UVTDATA\" SET \"U_Durum\" = 'E' , \"U_DurumAciklama\" = '" + oCompany.GetLastErrorDescription() + "',\"U_SAPCevapKod\" = " + aa.ActivityCode + ", \"U_IslemeTarihi\" = '" + DateTime.Now.ToString("yyyyMMdd") + "', \"U_IslemeSaati\" = '" + DateTime.Now.Hour.ToString().PadLeft(2, '0') + ":" + DateTime.Now.Minute.ToString() + "' where \"Code\" = '" + code + "'";
                        oRS_Update.DoQuery(ss);
                    }
                    #endregion

                }


                oRS.MoveNext();
            }
        }
    }
}
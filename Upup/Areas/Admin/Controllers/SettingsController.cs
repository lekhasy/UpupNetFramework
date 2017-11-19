using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using Upup.Areas.Admin.ViewModels;

namespace Upup.Areas.Admin.Controllers
{
    public class SettingsController : Controller
    {
        // GET: Admin/Setting
        public ActionResult ManageSettings()
        {
            return View(new SettingModel
            {
                LogoUrl = WebConfigurationManager.AppSettings["LogoUrl"],
                FacebookLink = WebConfigurationManager.AppSettings["FacebookLink"],
                GooglePlus = WebConfigurationManager.AppSettings["GooglePlus"],
                Twitter = WebConfigurationManager.AppSettings["Twitter"],
                YoutubeLink = WebConfigurationManager.AppSettings["YoutubeLink"],
                CompanyName = WebConfigurationManager.AppSettings["CompanyName"],
                Slogan = WebConfigurationManager.AppSettings["Slogan"]
            });
        }

        [HttpPost]
        public ActionResult ManageSettings(SettingModel model)
        {
            //Helps to open the Root level web.config file.
            Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");
            //Modifying the AppKey from AppValue to AppValue1
            webConfigApp.AppSettings.Settings["LogoUrl"].Value = model.LogoUrl;
            webConfigApp.AppSettings.Settings["FacebookLink"].Value = model.FacebookLink;
            webConfigApp.AppSettings.Settings["GooglePlus"].Value = model.GooglePlus;
            webConfigApp.AppSettings.Settings["Twitter"].Value = model.Twitter;
            webConfigApp.AppSettings.Settings["YoutubeLink"].Value = model.YoutubeLink;
            webConfigApp.AppSettings.Settings["CompanyName"].Value = model.CompanyName;
            webConfigApp.AppSettings.Settings["Slogan"].Value = model.Slogan;
            //Save the Modified settings of AppSettings.
            webConfigApp.Save();
            return View();
        }
    }
}
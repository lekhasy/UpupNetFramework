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
                Slogan = WebConfigurationManager.AppSettings["Slogan"],
                Slogan_en = WebConfigurationManager.AppSettings["Slogan_en"],
                Email = WebConfigurationManager.AppSettings["Email"],
                Fax = WebConfigurationManager.AppSettings["Fax"],
                Phone = WebConfigurationManager.AppSettings["Phone"],
                WorkTime = WebConfigurationManager.AppSettings["WorkTime"],
                EventBannerUrl = WebConfigurationManager.AppSettings["EventBannerUrl"],
                EventSlogan = WebConfigurationManager.AppSettings["EventSlogan"],
                GuideBannerUrl = WebConfigurationManager.AppSettings["GuideBannerUrl"],
                GuideSlogan = WebConfigurationManager.AppSettings["GuideSlogan"],
                TechBannerUrl = WebConfigurationManager.AppSettings["TechBannerUrl"],
                TechSlogan = WebConfigurationManager.AppSettings["TechSlogan"],
                MetaDescription = WebConfigurationManager.AppSettings["MetaDescription"],
                MetaDescription_en = WebConfigurationManager.AppSettings["MetaDescription_en"],
                MetaKeyword = WebConfigurationManager.AppSettings["MetaKeyword"],
                MetaKeyword_en = WebConfigurationManager.AppSettings["MetaKeyword_en"],
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
            webConfigApp.AppSettings.Settings["Slogan_en"].Value = model.Slogan_en;
            webConfigApp.AppSettings.Settings["Email"].Value = model.Email;
            webConfigApp.AppSettings.Settings["Fax"].Value = model.Fax;
            webConfigApp.AppSettings.Settings["Phone"].Value = model.Phone;
            webConfigApp.AppSettings.Settings["WorkTime"].Value = model.WorkTime;
            webConfigApp.AppSettings.Settings["EventBannerUrl"].Value = model.EventBannerUrl;
            webConfigApp.AppSettings.Settings["EventSlogan"].Value = model.EventSlogan;
            webConfigApp.AppSettings.Settings["GuideBannerUrl"].Value = model.GuideBannerUrl;
            webConfigApp.AppSettings.Settings["GuideSlogan"].Value = model.GuideSlogan;
            webConfigApp.AppSettings.Settings["TechBannerUrl"].Value = model.TechBannerUrl;
            webConfigApp.AppSettings.Settings["TechSlogan"].Value = model.TechSlogan;
            webConfigApp.AppSettings.Settings["MetaDescription"].Value = model.MetaDescription;
            webConfigApp.AppSettings.Settings["MetaDescription_en"].Value = model.MetaDescription_en;
            webConfigApp.AppSettings.Settings["MetaKeyword"].Value = model.MetaKeyword;
            webConfigApp.AppSettings.Settings["MetaKeyword_en"].Value = model.MetaKeyword_en;
            //Save the Modified settings of AppSettings.
            webConfigApp.Save();
            return View();
        }
    }
}
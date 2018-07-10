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
    public class SettingsController : AdminControllerBase
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
                Slogan = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["Slogan"]),
                Slogan_en = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["Slogan_en"]),
                Email = WebConfigurationManager.AppSettings["Email"],
                Phone2 = WebConfigurationManager.AppSettings["Phone2"],
                Phone = WebConfigurationManager.AppSettings["Phone"],
                WorkTime = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["WorkTime"]),
                EventBannerUrl = WebConfigurationManager.AppSettings["EventBannerUrl"],
                EventSlogan = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["EventSlogan"]),
                GuideBannerUrl = WebConfigurationManager.AppSettings["GuideBannerUrl"],
                GuideSlogan = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["GuideSlogan"]),
                TechBannerUrl = WebConfigurationManager.AppSettings["TechBannerUrl"],
                TechSlogan = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["TechSlogan"]),
                MetaDescription = WebConfigurationManager.AppSettings["MetaDescription"],
                MetaDescription_en = WebConfigurationManager.AppSettings["MetaDescription_en"],
                MetaKeyword = WebConfigurationManager.AppSettings["MetaKeyword"],
                MetaKeyword_en = WebConfigurationManager.AppSettings["MetaKeyword_en"],
                MainBannerUrl1 = WebConfigurationManager.AppSettings["MainBannerUrl1"],
                MainSlogan1 = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["MainSlogan1"]),
                MainBannerUrl2 = WebConfigurationManager.AppSettings["MainBannerUrl2"],
                MainSlogan2 = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["MainSlogan2"]),
                MainBannerUrl3 = WebConfigurationManager.AppSettings["MainBannerUrl3"],
                MainSlogan3 = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["MainSlogan3"]),
                MainBannerUrl4 = WebConfigurationManager.AppSettings["MainBannerUrl4"],
                MainSlogan4 = HttpUtility.HtmlDecode(WebConfigurationManager.AppSettings["MainSlogan4"]),
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
            webConfigApp.AppSettings.Settings["Slogan"].Value = HttpUtility.HtmlEncode(model.Slogan);
            webConfigApp.AppSettings.Settings["Slogan_en"].Value = HttpUtility.HtmlEncode(model.Slogan_en);
            webConfigApp.AppSettings.Settings["Email"].Value = model.Email;
            webConfigApp.AppSettings.Settings["Phone2"].Value = model.Phone2;
            webConfigApp.AppSettings.Settings["Phone"].Value = model.Phone;
            webConfigApp.AppSettings.Settings["WorkTime"].Value = HttpUtility.HtmlEncode(model.WorkTime);
            webConfigApp.AppSettings.Settings["EventBannerUrl"].Value = model.EventBannerUrl;
            webConfigApp.AppSettings.Settings["EventSlogan"].Value = HttpUtility.HtmlEncode(model.EventSlogan);
            webConfigApp.AppSettings.Settings["GuideBannerUrl"].Value = model.GuideBannerUrl;
            webConfigApp.AppSettings.Settings["GuideSlogan"].Value = HttpUtility.HtmlEncode(model.GuideSlogan);
            webConfigApp.AppSettings.Settings["TechBannerUrl"].Value = model.TechBannerUrl;
            webConfigApp.AppSettings.Settings["TechSlogan"].Value = HttpUtility.HtmlEncode(model.TechSlogan);
            webConfigApp.AppSettings.Settings["MetaDescription"].Value = model.MetaDescription;
            webConfigApp.AppSettings.Settings["MetaDescription_en"].Value = model.MetaDescription_en;
            webConfigApp.AppSettings.Settings["MetaKeyword"].Value = model.MetaKeyword;
            webConfigApp.AppSettings.Settings["MetaKeyword_en"].Value = model.MetaKeyword_en;
            webConfigApp.AppSettings.Settings["MainBannerUrl1"].Value = model.MainBannerUrl1;
            webConfigApp.AppSettings.Settings["MainSlogan1"].Value = HttpUtility.HtmlEncode(model.MainSlogan1);
            webConfigApp.AppSettings.Settings["MainBannerUrl2"].Value = model.MainBannerUrl2;
            webConfigApp.AppSettings.Settings["MainSlogan2"].Value = HttpUtility.HtmlEncode(model.MainSlogan2);
            webConfigApp.AppSettings.Settings["MainBannerUrl3"].Value = model.MainBannerUrl3;
            webConfigApp.AppSettings.Settings["MainSlogan3"].Value = HttpUtility.HtmlEncode(model.MainSlogan3);
            webConfigApp.AppSettings.Settings["MainBannerUrl4"].Value = model.MainBannerUrl4;
            webConfigApp.AppSettings.Settings["MainSlogan4"].Value = HttpUtility.HtmlEncode(model.MainSlogan4);
            //Save the Modified settings of AppSettings.
            webConfigApp.Save();
            ModelState.AddModelError("ProgressSuccess", "Đã lưu thiết lập !");
            return View(model);
        }
    }
}
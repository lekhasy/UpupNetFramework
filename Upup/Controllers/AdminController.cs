﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Upup.Controllers {
    //[Authorize(Roles = "Admin")]
    public class AdminController : Controller {
        //
        // GET: /Admin/

        
        public ActionResult AdminConsole() {
            return View();
        }

        //#region Login Admin

        //[AllowAnonymous]
        //public ActionResult Login(string returnUrl) {
        //    ViewBag.ReturnUrl = returnUrl;
        //    return View();
        //}

        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult Login(LoginModel model, string returnUrl) {
        //    if (ModelState.IsValid && model.IsValid(model.UserName, model.Password)) {
        //        FormsAuthentication.SetAuthCookie(model.UserName, model.RememberMe);
        //        var authCookie = FormsAuthentication.GetAuthCookie(model.UserName, model.RememberMe);
        //        if (!model.RememberMe) {
        //            authCookie.Expires = DateTime.Now.AddDays(2);
        //        }
        //        Response.Cookies.Add(authCookie);
        //        return RedirectToLocal(HttpUtility.UrlDecode(returnUrl));
        //    }

        //    // If we got this far, something failed, redisplay form
        //    ModelState.AddModelError("ProgressError", "Tên đăng nhập hoặc mật khẩu bạn cung cấp không chính xác. Vui lòng thử lại.");
        //    return View(model);
        //}

        //private ActionResult RedirectToLocal(string returnUrl) {
        //    if (Url.IsLocalUrl(Server.HtmlDecode(returnUrl))) {
        //        return Redirect(returnUrl);
        //    } else {
        //        return RedirectToAction("AdminConsole", "Admin", new { id = "admin" });
        //    }
        //}

        //#endregion

        //#region Contact

        
        //public ActionResult ManageContact(int? id) {
        //    if (id == null) return View();
        //    var result = B_Contact.Find(c => c.Id == id).SingleOrDefault();
        //    var contact = new ContactModel();
        //    if (result != null) {
        //        contact.Id = result.Id;
        //        contact.IpAddress = result.IpAddress;
        //        contact.Fullname = result.Fullname;
        //        contact.Email = result.Email;
        //        contact.Title = result.Title;
        //        contact.Contents = result.Contents;
        //        contact.CreatedOn = Convert.ToDateTime(result.CreatedOn);
        //        return View(contact);
        //    }
        //    ModelState.AddModelError("ProgressError", "Thư liên hệ bạn chọn đã bị xóa hoặc không tồn tại");
        //    return View();
        //}

        //[HttpGet]
        
        //public ActionResult LoadAllContact(JQueryDataTableParamModel param) {
        //    IEnumerable<B_Contact> allContact = B_Contact.All();
        //    if (!string.IsNullOrEmpty(param.sSearch)) {
        //        allContact = B_Contact
        //                 .Find(c => c.Fullname.Contains(param.sSearch)
        //                             ||
        //                  c.Email.Contains(param.sSearch)
        //                             ||
        //                  c.Title.Contains(param.sSearch)
        //                             ||
        //                  c.Contents.Contains(param.sSearch));
        //    }
        //    var filteredContact = allContact.Skip(param.iDisplayStart)
        //                .Take(param.iDisplayLength);

        //    var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
        //    Func<B_Contact, string> orderingFunction = (n => sortColumnIndex == 0 ? n.Id.ToString(CultureInfo.InvariantCulture) :
        //                                                        sortColumnIndex == 1 ? n.IpAddress :
        //                                                        sortColumnIndex == 2 ? n.Fullname :
        //                                                        sortColumnIndex == 3 ? n.Email :
        //                                                        sortColumnIndex == 4 ? n.Title : Convert.ToDateTime(n.CreatedOn).ToString("dd/MM/yyyy HH:mm"));

        //    var sortDirection = Request["sSortDir_0"]; // asc or desc
        //    filteredContact = sortDirection == "asc" ? filteredContact.OrderBy(orderingFunction) : filteredContact.OrderByDescending(orderingFunction);

        //    var result = filteredContact.Select(news => new[]
        //    {
        //        news.Id.ToString(CultureInfo.InvariantCulture), news.IpAddress, news.Title, 
        //        news.Email, news.Title, news.CreatedOn.ToString(CultureInfo.InvariantCulture), news.Id.ToString(CultureInfo.InvariantCulture)
        //    }).ToList();

        //    return Json(new {
        //        param.sEcho,
        //        iTotalRecords = allContact.Count(),
        //        iTotalDisplayRecords = allContact.Count(),
        //        aaData = result
        //    },
        //    JsonRequestBehavior.AllowGet);
        //}

        //[HttpPost]
        
        //public ActionResult RemoveContact(int id) {
        //    var result = new AjaxSimpleResultModel();
        //    var contact = B_Contact.Find(c => c.Id == id).SingleOrDefault();
        //    if (contact != null) {
        //        try {
        //            contact.Delete();
        //            result.ResultValue = true;
        //            result.Message = "Thư liên hệ bạn chọn đã được xóa thành công !";
        //        } catch (Exception) {
        //            result.ResultValue = false;
        //            result.Message = "Đã có lỗi xảy ra trong quá trình thực thi";
        //            return Json(result);
        //        }
        //    } else {
        //        result.ResultValue = false;
        //        result.Message = "Thư liên hệ bạn chọn đã bị xóa hoặc không tồn tại";
        //    }
        //    return Json(result);
        //}

        //#endregion
        
    }
}

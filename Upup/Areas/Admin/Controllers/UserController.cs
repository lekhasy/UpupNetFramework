using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Upup.Areas.Admin.ViewModels;
using Upup.Models;
using Upup.Utils;

namespace Upup.Areas.Admin.Controllers
{
    public class UserController : AdminControllerBase
    {
        public ActionResult ManageUsers()
        {
            return View();
        }

        public async Task<ActionResult> UserList(DataTableRequest req)
        {
            var CustomerRole = Db.Roles.First(r => r.Name == "Customer");
            var dataResultQuery = Db.Users.Where(u => !u.Roles.Any(r => r.RoleId == CustomerRole.Id) && u.Email != User.Identity.Name);
            var count = dataResultQuery.Count();
            if (req.search.value != null)
            {
                dataResultQuery = dataResultQuery.Where(u => u.Email.Contains(req.search.value) ||
                                                              u.PhoneNumber.Contains(req.search.value));
            }

            if (req.order.Safe().Count() > 0)
            {
                var indexCol = req.order.First().column;
                var col = req.columns.ElementAt(indexCol);
                dataResultQuery = dataResultQuery.OrderBy<ApplicationUser>(col.data.Replace("DT_RowData.", ""), req.order.First().dir == "asc" ? true : false);
            }

            var dt = await dataResultQuery.Skip(req.start).Take(req.length).AsNoTracking()
                .Select(c => new UserDataRow
                {
                    DT_RowData = c
                }).ToListAsync();

            return Json(new DataTableResponse<UserDataRow>
            {
                draw = req.draw,
                data = dt,
                recordsTotal = count,
                recordsFiltered = dataResultQuery.Count()
            }, JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public async Task<ActionResult> AddUser(AddUserModel model)
        {
            var roleName = Db.Roles.First(r => r.Id == model.RoleId).Name;

            var user = new Customer
            {
                UserName = model.Email,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                FullName = model.FullName,
                EmailConfirmed = model.SkipEmailConfirmation
            };

            var result = await UserManager.CreateAsync(user, model.Password);

            var addRoleResult = await UserManager.AddToRoleAsync(user.Id, roleName);

            if (result.Succeeded && addRoleResult.Succeeded)
            {
                if (!model.SkipEmailConfirmation)
                {
                    // Send an email with this link
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, "#_Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>");
                }
                return Json(new AjaxSimpleResultModel { ResultValue = true, Message = "Tạo người dùng thành công" });
            }

            return Json(new AjaxSimpleResultModel { ResultValue = false, Message = "Tạo người dùng thất bại" });
        }

        public ActionResult CheckEmailAvailable(string email)
        {
            var match = Db.Users.FirstOrDefault(u => u.Email == email);
            if (match == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
        }

        public async Task<ActionResult> UpdateUser(UpdateUserModel model)
        {
            var user = Db.Users.FirstOrDefault(u => u.Id == model.Id);
            if (user == null)
            {
                return Json(new AjaxSimpleResultModel
                {
                    ResultValue = false,
                    Message = "Người dùng không tồn tại"
                });
            }

            var allroles = Db.Roles.AsNoTracking().ToList();

            await UserManager.RemoveFromRoleAsync(user.Id, "Admin");
            await UserManager.RemoveFromRoleAsync(user.Id, "Editor");
            var matchRole = allroles.First(r => r.Id == model.RoleId);

            await UserManager.AddToRoleAsync(user.Id, matchRole.Name);

            return RedirectToAction("ManageUsers");
        }

        [HttpPost]
        public async Task<ActionResult> RemoveUser(string id)
        {
            var user = Db.Users.Find(id);
            if (user != null)
            {
                Db.Users.Remove(user);
                await Db.SaveChangesAsync();
                return Json(new AjaxSimpleResultModel { ResultValue = true, Message = "Xóa thành công" });
            }

            return Json(new AjaxSimpleResultModel { ResultValue = false, Message = "Người dùng không tồn tại" });
        }

        public ActionResult GetAllRoles()
        {
            return Json(Db.Roles.AsNoTracking().ToList(), JsonRequestBehavior.AllowGet);
        }
    }
}
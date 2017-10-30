using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Upup.Areas.Admin.Models;
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

        public async Task<ActionResult> CustomerList(DataTableRequest req)
        {
            var dataResultQuery = Db.Users.AsQueryable();

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
                recordsTotal = Db.Customers.Count(),
                recordsFiltered = Db.Customers.Count()
            }, JsonRequestBehavior.AllowGet);
        }
    }
}
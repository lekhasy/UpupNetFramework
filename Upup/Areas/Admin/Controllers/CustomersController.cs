using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Upup.Models;
using Upup.Controllers;
using Upup.Utils;
using System;
using Upup.Areas.Admin.ViewModels;
using Newtonsoft.Json;

namespace Upup.Areas.Admin.Controllers
{
    public class CustomersController : AdminControllerBase
    {
        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> CustomerList(DataTableRequest req)
        {
            var CustomerRole = Db.Roles.First(r => r.Name == "Customer");
            var dataResultQuery = Db.Customers.Where(u => u.Roles.Any(r => r.RoleId == CustomerRole.Id));
            var count = dataResultQuery.Count();

            if (req.search.value != null)
            {
                dataResultQuery = dataResultQuery.Where(c => c.OrgName.Contains(req.search.value) ||
                                                              c.Email.Contains(req.search.value) ||
                                                              c.PhoneNumber.Contains(req.search.value) ||
                                                              c.Webiste.Contains(req.search.value));
            }

            if (req.order.Safe().Count() > 0)
            {
                var indexCol = req.order.First().column;
                var col = req.columns.ElementAt(indexCol);
                dataResultQuery = dataResultQuery.OrderBy<Customer>(col.data.Replace("DT_RowData.", ""), req.order.First().dir == "asc" ? true : false);
            }


            var dt = await dataResultQuery.Skip(req.start).Take(req.length).AsNoTracking()
                .Select(c => new TableDataRow<object>
                {
                    DT_RowData = new
                    {
                        AccessFailedCount = c.AccessFailedCount,
                        Address1 = c.Address1,
                        Address2 = c.Address2,
                        Address3 = c.Address3,
                        Address4 = c.Address4,
                        AutoIncrementCode = c.AutoIncrementCode,
                        DepartmentName = c.DepartmentName,
                        Email = c.Email,
                        EmailConfirmed = c.EmailConfirmed,
                        Fax = c.Fax,
                        FullName = c.FullName,
                        Id = c.Id,
                        IndustryId = c.IndustryId,
                        KnowByid = c.KnowByid,
                        LockoutEnabled = c.LockoutEnabled,
                        LockoutEndDateUtc = c.LockoutEndDateUtc,
                        NumberOfDesigner = c.NumberOfDesigner,
                        NumberOfEmployee = c.NumberOfEmployee,
                        OrgName = c.OrgName,
                        PasswordHash = c.PasswordHash,
                        PhoneNumber = c.PhoneNumber,
                        PhoneNumberConfirmed = c.PhoneNumberConfirmed,
                        PostalCode = c.PostalCode,
                        SecurityStamp = c.SecurityStamp,
                        ServiceId = c.ServiceId,
                        TwoFactorEnabled = c.TwoFactorEnabled,
                        UserName = c.UserName,
                        Webiste = c.Webiste
                    }
                }).ToListAsync();
            var returndata = new DataTableResponse<TableDataRow<object>>
            {
                draw = req.draw,
                data = dt,
                recordsTotal = count,
                recordsFiltered = dataResultQuery.Count()
            };

            //var json = JsonConvert.SerializeObject(returndata, Formatting.None, new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });

            return Json(returndata, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ManageCustomers(DataTableRequest req)
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> RemoveCustomer(string Id)
        {
            var cus = await Db.Customers.FindAsync(Id);
            if (cus == null)
            {

                return Json(new AjaxSimpleResultModel
                {
                    ResultValue = false,
                    Message = "Khách hàng không tồn tại"
                });
            }
            Db.Customers.Remove(cus);
            await Db.SaveChangesAsync();
            return Json(new AjaxSimpleResultModel
            {
                ResultValue = true
            });
        }

        // GET: Customers/Details/5
        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await Db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,OrgName,DepartmentName,Address1,Address2,Address3,Address4,PostalCode,Fax,Webiste,IndustryId,ServiceId,NumberOfDesigner,NumberOfEmployee,KnowByid")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Db.Customers.Add(customer);
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        // GET: Customers/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await Db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Email,EmailConfirmed,PasswordHash,SecurityStamp,PhoneNumber,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEndDateUtc,LockoutEnabled,AccessFailedCount,UserName,OrgName,DepartmentName,Address1,Address2,Address3,Address4,PostalCode,Fax,Webiste,IndustryId,ServiceId,NumberOfDesigner,NumberOfEmployee,KnowByid")] Customer customer)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(customer).State = EntityState.Modified;
                await Db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = await Db.Customers.FindAsync(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id)
        {
            Customer customer = await Db.Customers.FindAsync(id);
            Db.Customers.Remove(customer);
            await Db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}

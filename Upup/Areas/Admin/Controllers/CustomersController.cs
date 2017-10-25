using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Upup.Models;
using Upup.Controllers;
using Upup.Areas.Admin.Models;

namespace Upup.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomersController : UpupControllerBase
    {

        // GET: Customers
        public async Task<ActionResult> Index()
        {
            return View();
        }




        public async Task<ActionResult> CustomerList(DataTableRequest req)
        {
            return Json(new DataTableResponse<Customer>
            {
                draw = req.draw,
                 data = Db.Customers.Take(20).ToList(),
                  recordsTotal = Db.Customers.Count(),
                  recordsFiltered = Db.Customers.Count()
            }, JsonRequestBehavior.AllowGet);
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

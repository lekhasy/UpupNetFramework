﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Upup.Areas.Admin.ViewModels;
using Upup.Globalization;
using Upup.Helpers;
using Upup.Models;

namespace Upup.Areas.Admin.Controllers
{
    public class PurchaseOrdersController : AdminControllerBase
    {
        public ActionResult ManagePO()
        {
            var po = new PurchaseOrderDetailModel();


            return View(po);
        }

        [HttpGet]
        public ActionResult LoadAllPO(JQueryDataTableParamModel param)
        {
            var listPO = new List<PurchaseOrderDetailModel>();
            var purchaseOrders = Db.PurchaseOrders.ToList();
            var users = Db.Users.ToList();
            var products = Db.Products.ToList();
            foreach (var po in purchaseOrders)
            {
                var pods = po.PurchaseOrderDetails;
                listPO.Add(new PurchaseOrderDetailModel
                {
                    Id = po.Id,
                    Code = po.Code,
                    CreatedDate = po.CreatedDate,
                    Name = po.Name,
                    IsDeleted = po.IsDeleted,
                    State = po.State,
                    Customer = po.Customer,
                    TotalAmount = po.TotalAmount
                });
            }
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                listPO = listPO
                         .Where(c => c.Code.Contains(param.sSearch)
                                     ||
                                     c.CreatedDate.ToShortDateString().Contains(param.sSearch)
                          ||
                                   ((PoState)c.State).GetName().Contains(param.sSearch)
                          ||
                          c.Name.Contains(param.sSearch)
                          ||
                          c.Customer.FullName.Contains(param.sSearch)).ToList();
            }
            var filteredProducts = listPO.Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<PurchaseOrderDetailModel, string> orderingFunction = (n => sortColumnIndex == 0 ? n.Id.ToString(CultureInfo.InvariantCulture) :
                                                                sortColumnIndex == 1 ? n.Code :
                                                                sortColumnIndex == 2 ? n.Name :
                                                                sortColumnIndex == 3 ? n.Customer.FullName : n.TotalAmount.ToString("N0"));

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            filteredProducts = sortDirection == "asc" ? filteredProducts.OrderBy(orderingFunction) : filteredProducts.OrderByDescending(orderingFunction);

            var result = filteredProducts.Select(Po => new[]
            {
                Po.Id.ToString(CultureInfo.InvariantCulture), Po.Code, Po.CreatedDate.ToString("dd/MM/yyyy"), Po.Name,
                Po.State.ToString(), Po.Customer.FullName, Po.TotalAmount.ToString("N0"),
                Po.IsDeleted.ToString(CultureInfo.InvariantCulture), Po.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();

            return Json(new
            {
                param.sEcho,
                iTotalRecords = listPO.Count(),
                iTotalDisplayRecords = listPO.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }


        [HttpPost]
        public ActionResult RemovePO(int id)
        {
            var result = new AjaxSimpleResultModel();
            var po = Db.PurchaseOrders.SingleOrDefault(c => c.Id == id);
            if (po != null)
            {
                try
                {
                    if (po.IsTemp)
                    {
                        DeleteConfirmed(id);
                    }
                    else
                    {
                        po.IsDeleted = true;
                        Db.Entry(po).State = EntityState.Modified;
                        Db.SaveChanges();
                    }

                    result.ResultValue = true;
                    result.Message = Lang.Remove_PO_Success;
                }
                catch (Exception)
                {
                    result.ResultValue = false;
                    result.Message = Lang.Error;
                    return Json(result);
                }
            }
            else
            {
                result.ResultValue = false;
                result.Message = Lang.PO_Not_Found;
            }
            return Json(result);
        }

        [HttpPost]
        public ActionResult ChangePoState(string code, int state)
        {
            var result = new AjaxSimpleResultModel();
            var po = Db.PurchaseOrders.SingleOrDefault(c => c.Code == code);
            if (po != null)
            {
                try
                {
                    switch ((PoState)state)
                    {
                        case PoState.Paid:
                            {
                                foreach (var detail in po.PurchaseOrderDetails)
                                {
                                    detail.Product.OnHand -= detail.Quantity;
                                }
                                break;
                            }
                        case PoState.Canceled:
                            {
                                var poState = (PoState)po.State;
                                if (poState == PoState.Paid || poState == PoState.Shipped)
                                {
                                    foreach (var detail in po.PurchaseOrderDetails)
                                    {
                                        detail.Product.OnHand += detail.Quantity;
                                    }
                                }
                                Db.PurchaseOrderDetail.RemoveRange(po.PurchaseOrderDetails);
                                Db.PurchaseOrders.Remove(po);
                                Db.SaveChanges();
                                result.ResultValue = true;
                                result.Message = Lang.Canceled_PO_Success;
                                return Json(result);
                            }
                    }

                    if (po != null)
                    {
                        po.State = state;
                        Db.Entry(po).State = EntityState.Modified;
                        Db.SaveChanges();
                    }

                    result.ResultValue = true;
                    result.Message = Lang.Your_Selected_PO_Changed_State_Success;
                }
                catch (Exception ex)
                {
                    result.ResultValue = false;
                    result.Message = Lang.Error;
                    return Json(result);
                }
            }
            else
            {
                result.ResultValue = false;
                result.Message = Lang.PO_Not_Found;
            }
            return Json(result);
        }

        [HttpPost]
        public ActionResult ChangePoDetailState(int id, int state)
        {
            var result = new AjaxSimpleResultModel();
            var pod = Db.PurchaseOrderDetail.SingleOrDefault(c => c.Id == id);
            if (pod != null)
            {
                try
                {
                    pod.State = state;
                    Db.Entry(pod).State = EntityState.Modified;
                    Db.SaveChanges();

                    result.ResultValue = true;
                    result.Message = Lang.Your_Selected_Prod_Changed_State_Success;
                }
                catch (Exception ex)
                {
                    result.ResultValue = false;
                    result.Message = Lang.Error;
                    return Json(result);
                }
            }
            else
            {
                result.ResultValue = false;
                result.Message = Lang.Product_not_exists;
            }
            return Json(result);
        }

        // GET: Admin/PurchaseOrders
        public ActionResult Index()
        {
            return View(Db.PurchaseOrders.ToList());
        }

        // GET: Admin/PurchaseOrders/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = Db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // GET: Admin/PurchaseOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/PurchaseOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Code,Name,State")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                Db.PurchaseOrders.Add(purchaseOrder);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(purchaseOrder);
        }

        // GET: Admin/PurchaseOrders/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder po = Db.PurchaseOrders.Find(id);
            if (po == null)
            {
                return HttpNotFound();
            }
            var users = Db.Users.ToList();
            var products = Db.Products.ToList();
            var pods = po.PurchaseOrderDetails.ToList();
            var poModel = new PurchaseOrderDetailModel
            {
                Id = po.Id,
                Code = po.Code,
                CreatedDate = po.CreatedDate,
                Name = po.Name,
                IsDeleted = po.IsDeleted,
                State = po.State,
                Customer = po.Customer,
                TotalAmount = po.TotalAmount,
                Products = pods,
                PaymentCode = po.PaymentMethod
            };
            return View(poModel);
        }

        // POST: Admin/PurchaseOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Code,Name,State")] PurchaseOrder purchaseOrder)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(purchaseOrder).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(purchaseOrder);
        }

        // GET: Admin/PurchaseOrders/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchaseOrder purchaseOrder = Db.PurchaseOrders.Find(id);
            if (purchaseOrder == null)
            {
                return HttpNotFound();
            }
            return View(purchaseOrder);
        }

        // POST: Admin/PurchaseOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            PurchaseOrder purchaseOrder = Db.PurchaseOrders.Find(id);
            Db.PurchaseOrders.Remove(purchaseOrder);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

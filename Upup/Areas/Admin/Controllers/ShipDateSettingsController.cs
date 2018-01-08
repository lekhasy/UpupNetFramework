using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Upup.Areas.Admin.ViewModels;
using Upup.Models;

namespace Upup.Areas.Admin.Controllers
{
    public class ShipDateSettingsController : AdminControllerBase
    {
        [HttpGet]
        public ActionResult ManageShipDateSettings(int? id)
        {
            var allShipDateSettings = Mapper.Map<List<ShipDateSetting>, List<ShipDateSettingModel>>(Db.ShipDateSettings.ToList());
            var model = new ShipDateSettingModel
            {
                AllShipDateSetting = allShipDateSettings
            };
            if (id == null) return View(model);
            var result = Db.ShipDateSettings.Find(id);
            if (result != null)
            {
                model = Mapper.Map<ShipDateSetting, ShipDateSettingModel>(result);
                return View(model);
            }
            ModelState.AddModelError("ProgressError", "Thiết lập bạn chọn đã bị xóa hoặc không tồn tại");
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]

        public ActionResult ManageShipDateSettings(ShipDateSettingModel model)
        {
            var allShipDateSettings = Mapper.Map<List<ShipDateSetting>, List<ShipDateSettingModel>>(Db.ShipDateSettings.ToList());
            model.AllShipDateSetting = allShipDateSettings;
            var parentShipDateSetting = Db.ShipDateSettings.Find(model.Id);
            if (model.Id == 0)
            {
                var ShipDateSetting = new ShipDateSetting
                {
                    QuantityOrderMax = model.QuantityOrderMax,
                    TargetDateNumber = model.TargetDateNumber
                };
                try
                {
                    Db.ShipDateSettings.Add(ShipDateSetting);
                    Db.SaveChanges();
                }
                catch (Exception)
                {
                    ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                }
                ModelState.AddModelError("ProgressSuccess", "Đã thêm 1 Thiết lập mới !");
            }
            else
            {
                var ShipDateSetting = Db.ShipDateSettings.Find(model.Id);
                if (ShipDateSetting != null)
                {
                    ShipDateSetting.QuantityOrderMax = model.QuantityOrderMax;
                    ShipDateSetting.TargetDateNumber = model.TargetDateNumber;
                    try
                    {
                        Db.Entry(ShipDateSetting).State = EntityState.Modified;
                        Db.SaveChanges();
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError("ProgressError", "Đã có lỗi xảy ra trong quá trình thực thi");
                    }
                    ModelState.AddModelError("ProgressSuccess", "Đã cập nhật nội dung mới cho Thiết lập !");
                }
                else
                {
                    ModelState.AddModelError("ProgressError", "Thiết lập bạn chọn đã bị xóa hoặc không tồn tại");
                }
            }
            return View(model);
        }

        [HttpGet]

        public ActionResult LoadAllShipDateSettings(JQueryDataTableParamModel param)
        {
            var allShipDateSettings = Db.ShipDateSettings.ToList();
            if (!string.IsNullOrEmpty(param.sSearch))
            {
                allShipDateSettings = Db.ShipDateSettings.ToList()
                         .Where(c => c.QuantityOrderMax.ToString(CultureInfo.InvariantCulture).Contains(param.sSearch)).ToList();
            }
            var filteredShipDateSettings = allShipDateSettings.Skip(param.iDisplayStart)
                        .Take(param.iDisplayLength);

            var sortColumnIndex = Convert.ToInt32(Request["iSortCol_0"]);
            Func<ShipDateSetting, string> orderingFunction = (n => sortColumnIndex == 0 ? n.Id.ToString(CultureInfo.InvariantCulture) : n.QuantityOrderMax.ToString(CultureInfo.InvariantCulture));

            var sortDirection = Request["sSortDir_0"]; // asc or desc
            filteredShipDateSettings = sortDirection == "asc" ? filteredShipDateSettings.OrderBy(orderingFunction) : filteredShipDateSettings.OrderByDescending(orderingFunction);

            var result = filteredShipDateSettings.Select(ShipDateSetting => new[]
            {
                ShipDateSetting.Id.ToString(CultureInfo.InvariantCulture),
                ShipDateSetting.QuantityOrderMax.ToString(CultureInfo.InvariantCulture),
                ShipDateSetting.TargetDateNumber.ToString(CultureInfo.InvariantCulture),
                ShipDateSetting.Id.ToString(CultureInfo.InvariantCulture)
            }).ToList();

            return Json(new
            {
                param.sEcho,
                iTotalRecords = allShipDateSettings.Count(),
                iTotalDisplayRecords = allShipDateSettings.Count(),
                aaData = result
            },
            JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult RemoveShipDateSettings(int id)
        {
            var result = new AjaxSimpleResultModel();
            var ShipDateSetting = Db.ShipDateSettings.ToList().SingleOrDefault(c => c.Id == id);
            if (ShipDateSetting != null)
            {
                try
                {
                    DeleteConfirmed(id);
                    result.ResultValue = true;
                    result.Message = "Thiết lập bạn chọn đã được xóa thành công !";
                }
                catch (Exception)
                {
                    result.ResultValue = false;
                    result.Message = "Đã có lỗi xảy ra trong quá trình thực thi";
                    return Json(result);
                }
            }
            else
            {
                result.ResultValue = false;
                result.Message = "Thiết lập bạn chọn đã bị xóa hoặc không tồn tại";
            }
            return Json(result);
        }

        // GET: Admin/ShipDateSettings
        public ActionResult Index()
        {
            return View(Db.ShipDateSettings.ToList());
        }

        // GET: Admin/ShipDateSettings/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipDateSetting shipDateSetting = Db.ShipDateSettings.Find(id);
            if (shipDateSetting == null)
            {
                return HttpNotFound();
            }
            return View(shipDateSetting);
        }

        // GET: Admin/ShipDateSettings/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/ShipDateSettings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QuantityOrderMax,TargetDateNumber")] ShipDateSetting shipDateSetting)
        {
            if (ModelState.IsValid)
            {
                Db.ShipDateSettings.Add(shipDateSetting);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(shipDateSetting);
        }

        // GET: Admin/ShipDateSettings/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipDateSetting shipDateSetting = Db.ShipDateSettings.Find(id);
            if (shipDateSetting == null)
            {
                return HttpNotFound();
            }
            return View(shipDateSetting);
        }

        // POST: Admin/ShipDateSettings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QuantityOrderMax,TargetDateNumber")] ShipDateSetting shipDateSetting)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(shipDateSetting).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(shipDateSetting);
        }

        // GET: Admin/ShipDateSettings/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ShipDateSetting shipDateSetting = Db.ShipDateSettings.Find(id);
            if (shipDateSetting == null)
            {
                return HttpNotFound();
            }
            return View(shipDateSetting);
        }

        // POST: Admin/ShipDateSettings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            ShipDateSetting shipDateSetting = Db.ShipDateSettings.Find(id);
            Db.ShipDateSettings.Remove(shipDateSetting);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

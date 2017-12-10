﻿using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Upup.Models;
using Upup.Utils;
using System.IO;
using System;
using Upup.ViewModels;
using System.Data.Entity;
using System.Web.Http;

namespace Upup.Controllers
{
    [System.Web.Mvc.Authorize(Roles = "Customer")]
    public class PoController : UpupControllerBase
    {
        // GET: Product
        public ActionResult Index()
        {
            var allPO = GetAllPo();

            return View(allPO);
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult SavePO(string code, string name)
        {
            new CommonPoLogic(Db).CreatePO(code, name, true, User.Identity.GetUserId());
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Order(string code, string name)
        {
            new CommonPoLogic(Db).CreatePO(code, name, false, User.Identity.GetUserId());
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult RequestPrice(string code, string name)
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            //var CustomerRole = Db.Roles.First(r => r.Name == "Admin");
            //var allAdmins = Db.Users.Where(u => u.Roles.Any(r => r.RoleId == CustomerRole.Id)).ToList();
            //foreach (var admin in allAdmins)
            //{
            //    UserManager.SendEmailAsync(admin.Id, $"có khách hàng {admin.FullName} cần báo giá", $"Họ tên: {user.FullName}, Điện thoại: {user.PhoneNumber}, Email:{user.Email}. Với chi tiết như sau </br>" + CreateEmailQuoteBody()).Wait();
            //}

            UserManager.SendEmailAsync(user.Id, "Báo giá từ Upup", CreateEmailQuoteBody()).Wait();
            new CommonPoLogic(Db).CreatePO(code, name, true, User.Identity.GetUserId());
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        private string CreateEmailQuoteBody()
        {
            string body = string.Empty;
            var userId = User.Identity.GetUserId();
            var user = Db.Customers.Find(userId);
            var carts = user.ProductCarts.ToList();
            int sequence = 0;
            var cartItems = new List<ProductCartItemModel>();

            foreach (var c in carts)
            {
                cartItems.Add(new ProductCartItemModel
                {
                    Id = c.Id,
                    Sequence = ++sequence,
                    DeliveryDate = c.CalculateShipDate(),
                    Quantity = c.Quantity,
                    BrandName = c.ProductVariant.BrandName,
                    ProductCode = c.ProductVariant.Product.Code,
                    ProductName = c.ProductVariant.Product.Name,
                    ProductPrice = c.ProductVariant.Price,
                    ProductVariantCode = c.ProductVariant.VariantCode,
                    ProductVariantName = c.ProductVariant.VariantName,
                    TotalPrice = c.CalculateTotalAmount(),
                    UnitName = c.ProductVariant.ProductVariantUnit.Name
                });
            }

            var html = string.Empty;
            decimal totalPrice = 0;
            if (cartItems != null)
            {
                var countProduct = 0;
                foreach (var product in cartItems)
                {
                    countProduct++;
                    html += "<tr>";
                    html += "<td rowspan = '3' style='width:5%;text-align:center;'> " + countProduct + " </td>";
                    html += "<td style ='width:38%'>" + product.ProductName + "</td>";
                    html += "<td colspan = '2' style = 'width:57%; text-align:right'>" + product.BrandName + "</td>";
                    html += "</tr>";
                    html += "<tr>";
                    html += "<td style = 'width:38%' >" + product.ProductCode + "</td>";
                    html += "<td colspan = '2' style = 'width:57%; text-align:center' >" + product.DeliveryDate + "</td>";
                    html += "</tr>";
                    html += "<tr>";
                    html += "<td style = 'width:30%; text-align:center' > " + product.ProductPrice.ToString("N0") + " </td>";
                    html += "<td style = 'width:20%; text-align:center' > " + product.Quantity + "";
                    html += "<td style = 'width:45%; text-align:right' > " + product.TotalPrice.ToString("N0") + " </td>";
                    html += "</tr > ";
                    totalPrice += product.TotalPrice;
                }
            }
            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplates/QuotesTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("[QuoteCode]", "123456");
            body = body.Replace("[QuoteDate]", DateTime.Now.ToShortDateString());
            body = body.Replace("[Barcode]", "0987654321");
            body = body.Replace("[PORef]", "00000000");
            body = body.Replace("[CustomerCode]", user.Code);
            body = body.Replace("[CustomerName]", user.FullName);
            body = body.Replace("[CompanyPhone]", user.PhoneNumber);
            body = body.Replace("[TaxNo]", user.OrgName);
            body = body.Replace("[CompanyAddress]", user.Address2);
            body = body.Replace("[ContactName]", user.OrgName);
            body = body.Replace("[Email]", user.Email);
            body = body.Replace("[Phone]", user.PhoneNumber);
            body = body.Replace("[Address]", user.Address1);
            body = body.Replace("[PayBeforeShip]", "X");
            body = body.Replace("[PayAfterShip]", string.Empty);
            body = body.Replace("[Amount]", totalPrice.ToString("N0"));
            body = body.Replace("[VAT]", "10%");
            body = body.Replace("[DeliveryFee]", "10,000");
            body = body.Replace("[TotalAmount]", (totalPrice + (totalPrice * 10 / 100) + 10000).ToString("N0"));
            body = body.Replace("[HtmlItemInGrid]", html);
            return body;
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(long id)
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var po = user.PurchaseOrders.FirstOrDefault(p => p.Id == id);

            if (po == null || (!po.IsTemp && po.State != (int)PoState.Completed))
            {
                return RedirectToAction("Index");
            }

            //Db.PurchaseOrderDetail.RemoveRange(po.PurchaseOrderDetails);
            //user.PurchaseOrders.Remove(po);
            po.IsDeleted = true;
            Db.Entry(po).State = EntityState.Modified;
            //Db.PurchaseOrders.Remove(po);
            Db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult MakeOrderFromTemp(long id, string code, string name, int paymentMethodId)
        {
            if (paymentMethodId != (int)PaymentMethods.COD && paymentMethodId != (int)PaymentMethods.BankTransfer)
            {
                return RedirectToAction(nameof(Index));
            }

            var userId = User.Identity.GetUserId();

            var customer = Db.Customers.Find(userId);

            var po = customer.PurchaseOrders.FirstOrDefault(p => p.Id == id);

            if (po == null || po.IsDeleted || !po.IsTemp)
            {
                return RedirectToAction(nameof(Index));
            }

            foreach (var podetail in po.PurchaseOrderDetails)
            {
                podetail.Price = podetail.GetCalculatedPrice();
                podetail.ShipDate = podetail.GetCalculatedShipDate();
                podetail.TotalAmount = podetail.GetCalculatedTotalAmount();
                podetail.State = (int)PoDetailState.Ordered;
            }

            po.State = (int)PoState.Ordered;
            po.Code = code;
            po.Name = name;
            po.PaymentMethod = paymentMethodId;
            po.CustomerAddress = customer.Address1;
            po.CustomerEmail = customer.Email;
            po.CustomerPhone = customer.PhoneNumber;
            po.CustomerWebsite = customer.Webiste;

            Db.SaveChanges();

            return RedirectToAction(nameof(Detail), new { id = po.Id });
        }

        [System.Web.Mvc.HttpGet]
        public ActionResult Detail(long id)
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var po = user.PurchaseOrders.FirstOrDefault(p => p.Id == id);

            return View(po);
        }

        public IEnumerable<PoItemModel> GetAllPo()
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var allpo = user.PurchaseOrders.ToList();

            int sequence = 0;
            List<PoItemModel> poItems = new List<PoItemModel>();
            foreach (var po in allpo)
            {
                poItems.Add(
                    new PoItemModel
                    {
                        Code = po.Code,
                        Id = po.Id,
                        Name = po.Name,
                        State = po.State,
                        Sequence = ++sequence,
                        ShipingProgress = $"{po.CalculateShipping()}/{po.CalculateTotalDetail()}",
                        CompleteProgress = $"{po.CalculateCompleteShipping()}/{po.CalculateTotalDetail()}",
                        Ordered = po.State >= (int)PoState.Ordered,
                        Paid = po.State >= (int)PoState.Paid
                    }
                );
            }

            return poItems;
        }
    }

    public class PoApiController : UpupApiControllerBase
    {
        [System.Web.Http.HttpGet]
        public DataTableResponse<TableDataRow<PoItemModel>> GetAllUnOrderedPo()
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var allpo = user.PurchaseOrders.Where(p => p.IsTemp).ToList();

            int sequence = 0;
            List<PoItemModel> poItems = new List<PoItemModel>();
            foreach (var po in allpo)
            {
                poItems.Add(
                    new PoItemModel
                    {
                        Code = po.Code,
                        Id = po.Id,
                        Name = po.Name,
                        State = po.State,
                        Sequence = ++sequence,
                        ShipingProgress = $"{po.CalculateShipping()}/{po.CalculateTotalDetail()}",
                        CompleteProgress = $"{po.CalculateCompleteShipping()}/{po.CalculateTotalDetail()}",
                        Ordered = false,
                        Paid = po.State >= (int)PoState.Paid,
                        CreatedDate = po.CreatedDate
                    }
                );
            }



            var tablePoItem = poItems.Select(poi => new TableDataRow<PoItemModel>
            {
                DT_RowData = poi
            });

            return new DataTableResponse<TableDataRow<PoItemModel>>
            {
                data = tablePoItem
            };
        }

        [System.Web.Http.HttpGet]
        public DataTableResponse<TableDataRow<PoDetailItemModel>> GetPoDetails(long id)
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var PO = user.PurchaseOrders.FirstOrDefault(po => po.Id == id);

            if (PO == null)
                return new DataTableResponse<TableDataRow<PoDetailItemModel>> { error = "Không tìm thấy PO" };

            int sequence = 0;
            List<TableDataRow<PoDetailItemModel>> PoItems = new List<TableDataRow<PoDetailItemModel>>();

            foreach (var c in PO.PurchaseOrderDetails)
            {
                PoItems.Add(new TableDataRow<PoDetailItemModel>
                {
                    DT_RowData = new PoDetailItemModel
                    {
                        Id = c.Id,
                        Sequence = ++sequence,
                        DeliveryDate = c.ShipDate,
                        Quantity = c.Quantity,
                        ProductCode = c.Product.Product.Code,
                        ProductName = c.Product.Product.Name,
                        ProductPrice = c.GetCalculatedPrice(),
                        ProductVariantCode = c.Product.VariantCode,
                        ProductVariantName = c.Product.VariantName,
                        TotalPrice = c.GetCalculatedTotalAmount(),
                        UnitName = c.Product.ProductVariantUnit.Name,
                        StateString = c.GetStateString()
                    }
                });
            }

            return new DataTableResponse<TableDataRow<PoDetailItemModel>>
            {
                data = PoItems,
                recordsTotal = PoItems.Count(),
                recordsFiltered = PoItems.Count()
            };
        }

        [System.Web.Http.HttpPost]
        public AjaxSimpleResultModel RemoveFromPO([FromBody]RemovePoDetailModel model)
        {
            if (model.ids == null)
            {
                return new AjaxSimpleResultModel { ResultValue = false, Message = "Hãy chọn ít nhất một phiếu" };
            }

            var userId = User.Identity.GetUserId();

            var customer = Db.Customers.Find(userId);

            var removingPo = customer.PurchaseOrders.Where(p => p.Id == model.PoId).FirstOrDefault();

            if (removingPo == null || removingPo.IsDeleted)
            {
                return new AjaxSimpleResultModel { ResultValue = false, Message = "PO không tồn tại" };
            }

            if (!removingPo.IsTemp)
            {
                return new AjaxSimpleResultModel { ResultValue = false, Message = "Chỉ có thể xóa PO tạm" };
            }

            var removingPoDetails = removingPo.PurchaseOrderDetails.Where(p => model.ids.Contains(p.Id));

            if (removingPoDetails.Count() == removingPo.PurchaseOrderDetails.Count)
            {
                return new AjaxSimpleResultModel { ResultValue = false, Message = "Một PO cần ít nhất một phiếu, hãy thêm một phiếu khác trước khi xóa các phiếu này." };
            }

            Db.PurchaseOrderDetail.RemoveRange(removingPoDetails);

            Db.SaveChanges();

            return new AjaxSimpleResultModel
            {
                ResultValue = true,
                Message = "Xóa thành công"
            };
        }

        [System.Web.Http.HttpPost]
        public AjaxSimpleResultModel AddToPo([FromBody]AddPoDetailModel model)
        {
            var userId = User.Identity.GetUserId();

            var customer = Db.Customers.Find(userId);

            var addToCartResult = new CommonPoLogic(Db).AddToPo(customer, model.productVariantCode, model.quantity, model.PoId);
            
            if (addToCartResult.ResultValue)
                Db.SaveChanges();

            return addToCartResult;

        }

        public class AddPoDetailModel
        {
            public long PoId { get; set; }
            public string productVariantCode { get; set; }
            public long quantity { get; set; }
        }

        public class RemovePoDetailModel
        {
            public long PoId { get; set; }
            public long[] ids { get; set; }
        }
    }

    public class CommonPoLogic
    {
        ApplicationDbContext _db;
        public CommonPoLogic(ApplicationDbContext Db)
        {
            _db = Db;
        }

        public PurchaseOrder CreatePO(string code, string name, bool isTemp, string customerId)
        {
            var customer = _db.Customers.Find(customerId);

            var carts = customer.ProductCarts.ToList();

            if (!carts.Any())
            {
                return null;
            }

            PurchaseOrder po = new PurchaseOrder
            {
                Code = code,
                Name = name,
                State = isTemp ? (int)PoState.Temp : (int)PoState.Ordered,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                CustomerAddress = customer.Address1,
                CustomerEmail = customer.Email,
                CustomerPhone = customer.PhoneNumber,
                CustomerWebsite = customer.Webiste,
                PurchaseOrderDetails = carts.Select(c => new PurchaseOrderDetail
                {
                    Product = c.ProductVariant,
                    Quantity = c.Quantity,
                    ShipDate = c.CalculateShipDate(),
                    State = isTemp ? (int)PoDetailState.Temp : (int)PoDetailState.Ordered,
                    Price = c.ProductVariant.Price,
                    TotalAmount = c.ProductVariant.Price * c.Quantity
                }).ToList()
            };

            customer.PurchaseOrders.Add(po);
            customer.ProductCarts.Clear();
            _db.ProductCarts.RemoveRange(carts);
            customer.TempPoName = null;
            return po;
        }

        public AjaxSimpleResultModel AddToPo(Customer customer, string variantCode, long quantity, long PoId)
        {
            var Po = customer.PurchaseOrders.FirstOrDefault(p => p.Id == PoId);

            if (Po == null || Po.IsDeleted)
            {
                return new AjaxSimpleResultModel { ResultValue = false, Message = "PO không tồn tại" };
            }

            if (!Po.IsTemp)
            {
                return new AjaxSimpleResultModel { ResultValue = false, Message = "Chỉ có thể thêm phiếu vào PO tạm" };
            }

            var variant = _db.ProductVariants.FirstOrDefault(pv => pv.VariantCode == variantCode);
            if (variant == null) return new AjaxSimpleResultModel
            {
                Message = "Sản phẩm không tồn tại",
                ResultValue = false
            };

            var exists = Po.PurchaseOrderDetails.FirstOrDefault(c => c.Product.VariantCode == variantCode);

            if (exists == null)
            {
                Po.PurchaseOrderDetails.Add(new PurchaseOrderDetail
                {
                    Price = variant.Price,
                    Product = variant,
                    Quantity = quantity,
                    State = (int)PoDetailState.Temp
                });
            }
            else
            {
                exists.Quantity += quantity;
            }

            return new AjaxSimpleResultModel
            {
                ResultValue = true,
                Message = "Thêm sản phẩm vào giỏ hàng thành công"
            };
        }
    }
}
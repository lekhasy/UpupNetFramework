using Microsoft.AspNet.Identity;
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
using Upup.Helpers;

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
            new CommonPoLogic(Db).CreatePO(code, name, true, User.Identity.GetUserId(), null);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult Order(string code, string name)
        {
            new CommonPoLogic(Db).CreatePO(code, name, false, User.Identity.GetUserId(), null);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        [System.Web.Mvc.HttpPost]
        public ActionResult RequestPrice(string code, string name)
        {
            var userId = User.Identity.GetUserId();

            var user = Db.Customers.Find(userId);

            var CustomerRole = Db.Roles.First(r => r.Name == "Admin");
            var allAdmins = Db.Users.Where(u => u.Roles.Any(r => r.RoleId == CustomerRole.Id)).ToList();
            var quoteCode = Guid.NewGuid().ToString().Replace("-", string.Empty);
            quoteCode = quoteCode.Substring(quoteCode.Length - 10);
            foreach (var admin in allAdmins)
            {
                UserManager.SendEmailAsync(admin.Id, $"Có khách hàng cần báo giá", $"Họ tên: <b>{user.FullName}</b>, Điện thoại: <b>{user.PhoneNumber}</b>, Email:<b>{user.Email}</b>. Với chi tiết như sau: </br>" + CreateEmailQuoteBody(code, name, quoteCode)).Wait();
            }
            UserManager.SendEmailAsync(user.Id, "Báo giá từ Upup", CreateEmailQuoteBody(code, name, quoteCode)).Wait();
            new CommonPoLogic(Db).CreatePO(code, name, true, User.Identity.GetUserId(), quoteCode);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        private string CreateEmailQuoteBody(string code, string name, string quoteCode)
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
                    //DeliveryDate = c.CalculateShipDate(),
                    DateShipping = c.DateShipping(),
                    Quantity = c.Quantity,
                    BrandName = c.ProductVariant.BrandName,
                    //ProductCode = c.ProductVariant.Product.Code,
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
                    html += "<td style = 'width:38%' >" + product.ProductVariantCode + "</td>";
                    html += "<td colspan = '2' style = 'width:57%; text-align:center' >" + product.DateShipping + " ngày</td>";
                    html += "</tr>";
                    html += "<tr>";
                    html += "<td style = 'width:30%; text-align:center' > " + product.ProductPrice.ToString("N0") + " </td>";
                    html += "<td style = 'width:20%; text-align:center' > " + product.Quantity + "";
                    html += "<td style = 'width:45%; text-align:right' > " + product.TotalPrice.ToString("N0") + " </td>";
                    html += "</tr > ";
                    totalPrice += product.TotalPrice;
                }
            }
            else
            {
                throw new InvalidOperationException("Cart is empty");
            }
            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplates/QuotesTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            
            body = body.Replace("[QuoteCode]", quoteCode);
            body = body.Replace("[QuoteDate]", DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
            body = body.Replace("[Barcode]", StringHelper.CreateQrCode(code));
            body = body.Replace("[PORef]", name);
            body = body.Replace("[CustomerCode]", user.Code);
            body = body.Replace("[CustomerName]", user.FullName);
            body = body.Replace("[CompanyPhone]", user.PhoneNumber);
            body = body.Replace("[TaxNo]", user.OrgName);
            body = body.Replace("[CompanyAddress]", user.Address2);
            body = body.Replace("[ContactName]", user.OrgName);
            body = body.Replace("[Email]", user.Email);
            body = body.Replace("[Phone]", user.PhoneNumber);
            body = body.Replace("[Address]", user.Address1);
            //body = body.Replace("[PayBeforeShip]", "X");
            //body = body.Replace("[PayAfterShip]", string.Empty);
            body = body.Replace("[Amount]", totalPrice.ToString("N0"));
            body = body.Replace("[VAT]", "10%");
            body = body.Replace("[DeliveryFee]", string.Empty);
            body = body.Replace("[TotalAmount]", (totalPrice + (totalPrice * 10 / 100) + 10000).ToString("N0"));
            body = body.Replace("[HtmlItemInGrid]", html);
            return body;
        }

        private string CreateEmailPoBody(int poId)
        {
            string body = string.Empty;
            var userId = User.Identity.GetUserId();
            var user = Db.Customers.Find(userId);
            var po = user.PurchaseOrders.FirstOrDefault(p => p.Id == poId);
            var pos = po.PurchaseOrderDetails;
            var cartItems = new List<PurchaseOrderDetail>();

            foreach (var c in pos)
            {
                cartItems.Add(new PurchaseOrderDetail
                {
                    Id = c.Id,
                    Price = c.Price,
                    Quantity = c.Quantity,
                    TotalAmount = c.TotalAmount,
                    ShipDate = c.ShipDate,
                    State = c.State,
                    Product = c.Product,
                    PurchaseOrder = c.PurchaseOrder
                });
            }

            var html = string.Empty;
            decimal totalPrice = 0;
            if (cartItems != null)
            {
                var countProduct = 0;
                foreach (var poDetail in cartItems)
                {
                    countProduct++;
                    html += "<tr>";
                    html += "<td rowspan = '3' style='width:5%;text-align:center;'> " + countProduct + " </td>";
                    html += "<td style ='width:38%'>" + poDetail.Product.VariantName + "</td>";
                    html += "<td colspan = '2' style = 'width:57%; text-align:right'>" + poDetail.Product.BrandName + "</td>";
                    html += "</tr>";
                    html += "<tr>";
                    html += "<td style = 'width:38%' >" + poDetail.Product.VariantCode + "</td>";
                    html += "<td colspan = '2' style = 'width:57%; text-align:center' >" + poDetail.Product.ShipdateSettings + " ngày</td>";
                    html += "</tr>";
                    html += "<tr>";
                    html += "<td style = 'width:30%; text-align:center' > " + poDetail.Price.ToString("N0") + " </td>";
                    html += "<td style = 'width:20%; text-align:center' > " + poDetail.Quantity + "";
                    html += "<td style = 'width:45%; text-align:right' > " + poDetail.TotalAmount.ToString("N0") + " </td>";
                    html += "</tr > ";
                    totalPrice += poDetail.TotalAmount;
                }
            }
            using (StreamReader reader = new StreamReader(Server.MapPath("~/EmailTemplates/PurchaseOrderTemplate.html")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("[OrderStatus]", StringHelper.GetPoPaymentMethodByCode(po.State));
            body = body.Replace("[QuoteDate]", po.CreatedDate.ToString("dd/MM/yyyy HH:mm"));
            body = body.Replace("[Barcode]", StringHelper.CreateQrCode(DateTime.Now.ToString("yyMMddhhmmss")));
            body = body.Replace("[PORef]", DateTime.Now.ToString("yyMMddhhmmss"));
            body = body.Replace("[CustomerCode]", user.Code);
            body = body.Replace("[CustomerName]", user.FullName);
            body = body.Replace("[CompanyPhone]", user.PhoneNumber);
            body = body.Replace("[TaxNo]", user.OrgName);
            body = body.Replace("[CompanyAddress]", user.Address2);
            body = body.Replace("[ContactName]", user.OrgName);
            body = body.Replace("[Email]", user.Email);
            body = body.Replace("[Phone]", user.PhoneNumber);
            body = body.Replace("[Address]", user.Address1);
            if (po.PaymentMethod == 2)
            {
                body = body.Replace("[PayBeforeShip]", "X");
            }
            else if (po.PaymentMethod == 1)
            {
                body = body.Replace("[PayAfterShip]", string.Empty);
            }
            body = body.Replace("[Amount]", totalPrice.ToString("N0"));
            body = body.Replace("[VAT]", "10%");
            body = body.Replace("[DeliveryFee]", string.Empty);
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

            if (po.IsTemp)
            {
                Db.PurchaseOrderDetail.RemoveRange(po.PurchaseOrderDetails);
                user.PurchaseOrders.Remove(po);
                Db.PurchaseOrders.Remove(po);
                Db.SaveChanges();
                return RedirectToAction("Index");
            }

            if (po == null || po.State != (int)PoState.Completed)
            {
                return RedirectToAction("Index");
            }
            
            po.IsDeleted = true;
            Db.Entry(po).State = EntityState.Modified;
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
                        //DeliveryDate = c.CalculateShipDate(),
                        DateShipping = c.DateShipping(),
                        Quantity = c.Quantity,
                        //ProductCode = c.ProductVariant.Product.Code,
                        ProductName = c.Product.Product.Name,
                        ProductPrice = c.Product.Price,
                        ProductVariantCode = c.Product.VariantCode,
                        //ProductVariantName = c.ProductVariant.VariantName,
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

        public PurchaseOrder CreatePO(string code, string name, bool isTemp, string customerId, string quoteCode)
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
                QuotationCode = quoteCode,
                PurchaseOrderDetails = carts.Select(c => new PurchaseOrderDetail
                {
                    Product = c.ProductVariant,
                    Quantity = c.Quantity,
                    ShipDate = c.CalculateShipDate(),
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
                    Quantity = quantity
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
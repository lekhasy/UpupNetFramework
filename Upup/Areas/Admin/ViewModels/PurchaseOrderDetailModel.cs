using System;
using System.Collections.Generic;
using Upup.Models;

namespace Upup.Areas.Admin.ViewModels
{
    public class PurchaseOrderDetailModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public bool IsDeleted { get; set; }
        public Customer Customer { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
        public int PaymentCode { get; set; }
        public List<PurchaseOrderDetail> Products { get; set; }
    }
}
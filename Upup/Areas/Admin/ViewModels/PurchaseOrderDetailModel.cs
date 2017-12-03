﻿using System;

namespace Upup.Areas.Admin.ViewModels
{
    public class PurchaseOrderDetailModel
    {
        public long Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int State { get; set; }
        public bool IsDeleted { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
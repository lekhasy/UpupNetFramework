using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Upup.Models
{
    public class Customer : ApplicationUser
    {
        [NotMapped]
        public string Code => "KH" + AutoIncrementCode.ToString();
        public string OrgName { get; set; }
        public string DepartmentName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string PostalCode { get; set; }
        public string Fax { get; set; }
        public string Webiste { get; set; }
        // questions
        public int IndustryId { get; set; }
        public int ServiceId { get; set; }
        public int NumberOfDesigner { get; set; }
        public int NumberOfEmployee { get; set; }
        public int KnowByid { get; set; }

        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual ICollection<ProductCart> ProductCarts { get; set; }
    }
}
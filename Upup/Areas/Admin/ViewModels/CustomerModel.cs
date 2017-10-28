using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Upup.Models;

namespace Upup.Areas.Admin.ViewModels
{
    public class CustomerModel
    {
        [Display(Name = "Tên công ty")]
        public string OrgName { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Số điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Tên phòng ban")]
        public string DepartmentName { get; set; }

        [Display(Name = "Địa chỉ 1")]
        public string Address1 { get; set; }
        [Display(Name = "Địa chỉ 2")]
        public string Address2 { get; set; }
        [Display(Name = "Địa chỉ 3")]
        public string Address3 { get; set; }
        [Display(Name = "Địa chỉ 4")]
        public string Address4 { get; set; }
    }

    public class CustomerDataRow
    {
        public object DT_RowData { get; set; }
    }

}
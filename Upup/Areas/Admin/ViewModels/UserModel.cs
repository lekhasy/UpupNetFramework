using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Upup.Areas.Admin.ViewModels
{
    public class UserDataRow
    {
        public object DT_RowData { get; set; }
    }

    public class UpdateUserModel
    {
        public string Id { get; set; }
        public string RoleId { get; set; }
    }

    public class AddUserModel
    {
        public string RoleId { get; set; }
        public bool SkipEmailConfirmation { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
    }
}
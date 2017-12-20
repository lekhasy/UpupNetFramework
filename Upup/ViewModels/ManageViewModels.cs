using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Upup.Globalization;
using Upup.Models;

namespace Upup.ViewModels
{
    public class IndexViewModel
    {
        public bool HasPassword { get; set; }
        public IList<UserLoginInfo> Logins { get; set; }
        public string PhoneNumber { get; set; }
        public bool TwoFactor { get; set; }
        public bool BrowserRemembered { get; set; }
        // public string Email { get; internal set; }
        public Customer Customer { get; set; }
        public ApplicationUser User { get; set; }
        public bool IsCustomer { get; set; }
    }

    public class ManageLoginsViewModel
    {
        public IList<UserLoginInfo> CurrentLogins { get; set; }
        public IList<AuthenticationDescription> OtherLogins { get; set; }
    }

    public class FactorViewModel
    {
        public string Purpose { get; set; }
    }

    public class SetPasswordViewModel
    {
        [Required]
        [StringLength(100, ErrorMessageResourceName = nameof(Lang.Password_length_validate_msg), ErrorMessageResourceType = typeof(Lang), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = nameof(Lang.New_Password), ResourceType = typeof(Lang))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = nameof(Lang.Confirm_New_Password), ResourceType = typeof(Lang))]
        [Compare(nameof(NewPassword), ErrorMessageResourceName = nameof(Lang.Password_Does_Not_Match), ErrorMessageResourceType = typeof(Lang))]
        public string ConfirmPassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = nameof(Lang.Current_Password), ResourceType = typeof(Lang))]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessageResourceName = nameof(Lang.Password_length_validate_msg), ErrorMessageResourceType = typeof(Lang), MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = nameof(Lang.New_Password), ResourceType = typeof(Lang))]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = nameof(Lang.Confirm_New_Password), ResourceType = typeof(Lang))]
        [Compare(nameof(NewPassword), ErrorMessageResourceName = nameof(Lang.Password_Does_Not_Match), ErrorMessageResourceType = typeof(Lang))]
        public string ConfirmPassword { get; set; }
    }

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = nameof(Lang.Register_Phone), ResourceType = typeof(Lang))]
        public string Number { get; set; }
    }

    public class VerifyPhoneNumberViewModel
    {
        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }

        [Required]
        [Phone]
        [Display(Name = nameof(Lang.Register_Phone), ResourceType = typeof(Lang))]
        public string PhoneNumber { get; set; }
    }

    public class ConfigureTwoFactorViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
    }

    public class UpdateInfoViewModel
    {
        public string Email { get; set; }
        public string FullName { get; set; }
        public string OrgName { get; set; }
        public string Website { get; set; }
        public string DepartmentName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
    }
}
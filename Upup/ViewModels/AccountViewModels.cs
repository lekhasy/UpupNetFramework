﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Upup.Globalization;

namespace Upup.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Lang))]
        public string Password { get; set; }

        [Display(Name = "Remember_Me", ResourceType = typeof(Lang))]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        public string Email { get; set; }

        public string Password { get; set; }

        // user info
        public string FullName { get; set; }
        public string OrgName { get; set; }
        public string DepartmentName { get; set; }
        public string Website { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Address3 { get; set; }
        public string Address4 { get; set; }
        public string PostalCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        // questions
        public int IndustryId { get; set; }
        public int ServiceId { get; set; }
        public int NumberOfDesigner { get; set; }
        public int NumberOfEmployee { get; set; }
        public int KnowById { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(Lang))]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm_New_Password", ResourceType = typeof(Lang))]
        [Compare("Password", ErrorMessageResourceName = "Password_Does_Not_Match", ErrorMessageResourceType = typeof(Lang))]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}

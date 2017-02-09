using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace shanuMVCUserRoles.Models
{
    public class FacebookUserModel
    {
        public string id { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string phone { get; set; }

        public Picture picture { get; set; }
    }
    public class Picture
    {
        public PicureData data { get; set; }
    }

    public class PicureData
    {
        public string url { get; set; }
        public bool is_silhouette { get; set; }
    }

    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Registration Type :")]
        public string UserRoles { get; set; }
        
        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Name")]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Name only support Alphabets and Numbers.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress]
        [Display(Name = "Email")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        [System.Web.Mvc.Remote("IsEmailAlreadyRegistered", "Account")]

        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter Mobile No")]
        [Display(Name = "Mobile")]
        [System.Web.Mvc.Remote("IsMobileAlreadyRegistered", "Account")]
        //[StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        [RegularExpression("^[0-9]{10}", ErrorMessage = "Mobile must be 10 digits only.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Profile photo is required")]
        [Display(Name = "Profile Photo")]
        public string UserPhoto { get; set; }

        //    [Required]
        [Display(Name = "Sanghtan Name")]
        public string SanghtanId { get; set; }

        public string FacebookId { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }


    public class RegisterViewModel
    {
        [Required]
        [Display(Name = "Registration Type :")]
        public string UserRoles { get; set; }


        [Required(ErrorMessage = "Please Enter Name")]
        [Display(Name = "Name")]
        [StringLength(250, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 3)]
        [RegularExpression("^[a-zA-Z0-9 ]*$", ErrorMessage = "Name only support Alphabets and Numbers.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please Enter Email Address")]
        [EmailAddress]
        [Display(Name = "Email")]
        [RegularExpression(".+@.+\\..+", ErrorMessage = "Please Enter Correct Email Address")]
        [System.Web.Mvc.Remote("IsEmailAlreadyRegistered", "Account")]

        public string Email { get; set; }


        [Required(ErrorMessage = "Please Enter Mobile No")]
        [Display(Name = "Mobile")]
        [System.Web.Mvc.Remote("IsMobileAlreadyRegistered", "Account")]
        //[StringLength(10, ErrorMessage = "The Mobile must contains 10 characters", MinimumLength = 10)]
        [RegularExpression("^[0-9]{10}", ErrorMessage = "Mobile must be 10 digits only.")]
        public string Phone { get; set; }

        //[Required]
        //[Display(Name = "UserName")]
        //public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Profile photo is required")]
        [Display(Name = "Profile Photo")]
        public string UserPhoto { get; set; }

    //    [Required]
        [Display(Name = "Sanghtan Name")]
        public string SanghtanId { get; set; }
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
		[Display(Name = "UserName")]
		public string UserName { get; set; }

		[Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
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
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
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

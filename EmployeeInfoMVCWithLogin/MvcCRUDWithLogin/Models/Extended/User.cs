using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcCRUDWithLogin.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class User
    {
        public virtual Role Role { get; set; }
        //public string ConfirmPassword { get; set; }
    }
    public class UserMetadata
    {
        [Display(Name ="First Name")]
        [Required (AllowEmptyStrings =false,ErrorMessage ="First Name Required!!")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name Required!!")]
        public string LastName { get; set; }

        [Display(Name = "Email ID")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email ID Required!!")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode =true,DataFormatString ="{0:MM/dd/yyyy}")]
        public Nullable<System.DateTime> DateOfBirth { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Password is Required!!")]
        [DataType(DataType.Password)]
        [MinLength(6,ErrorMessage ="Minimum 6 characters required!!!")]
        public string Password { get; set; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password",ErrorMessage ="Confirm password should be same as Password!!")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "User Role")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "User Role is Required!!")]
        public int RoleID { get; set; }
    }
}
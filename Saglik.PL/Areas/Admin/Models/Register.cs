using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saglik.PL.Areas.Admin.Models
{
    public class Register
    {
        [Required]
        [Display(Name = "Adı")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Soyadı")]
        public string SurName { get; set; }

        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage ="Email Formatına Uygun Giriniz!")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Paswword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Şifre Tekrar")]
        [Compare("Password", ErrorMessage = "Şifreler aynı değil!")]
        public string ConfirmPassword { get; set; }
    }
}
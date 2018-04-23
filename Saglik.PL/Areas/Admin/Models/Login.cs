using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saglik.PL.Areas.Admin.Models
{
    public class Login
    {
        [Required]
        [Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Şifre")]
        [DataType(DataType.Password)]
        public string Paswword { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saglik.Domain.Core
{
    [Table("Musteriler")]
    public class Musteri : EntityBase
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz!")]
        [StringLength(30, ErrorMessage = "İsim {0} karakterden uzun olmamalıdır!")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Lütfen soyadınızı giriniz!")]
        [StringLength(30, ErrorMessage = "Soyisim {0} karakterden uzun olmamalıdır!")]
        public string Soyad { get; set; }
        [Required(ErrorMessage = "Lütfen email adresinizi giriniz!")]
        [EmailAddress(ErrorMessage = "Email formatına uygun giriniz!")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]
        public string Sifre { get; set; }
        [NotMapped]     //Bu property modelde kullanılabilir, ancak SQL'de kolon oluşturmaz.
        [Required]
        [DataType(DataType.Password)]
        [StringLength(20)]
        [Display(Name ="Şifre Tekrar")]
        [Compare("Sifre", ErrorMessage = "Şifreler aynı değil!")]
        public string SifreTekrar { get; set; }
        [Required]
        [DataType(DataType.DateTime, ErrorMessage = "Tarih formatına uygun giriniz!")]
        public DateTime Tarih { get; set; }
        [MaxLength(11), MinLength(11)]
        public string TCKimlikNo { get; set; }
        [StringLength(30)]
        public string Telefon { get; set; }
        public string Adres { get; set; }
        [StringLength(30)]
        public string Ilce { get; set; }
        [StringLength(30)]
        public string Il { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Silindi { get; set; }

        //Relations
        public virtual List<Satis> Satislar { get; set; }

    }
}

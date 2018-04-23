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
    [Table("SatisDetaylar")]
    public class SatisDetay : EntityBase
    {
        public int SatisID { get; set; }
        public int UrunID { get; set; }
        [Required]
        [DefaultValue(1)]
        public int Adet { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal BirimFiyat { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal Tutar { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Silindi { get; set; }

        [ForeignKey("SatisID")]
        public virtual Satis Satis { get; set; }

        [ForeignKey("UrunID")]
        public virtual Urun Urun { get; set; }
    }
}

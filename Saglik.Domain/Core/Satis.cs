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
    [Table("Satislar")]
    public class Satis : EntityBase
    {
        [Required]
        public DateTime Tarih { get; set; }
        public int MusteriID { get; set; }
        public int ToplamMiktar { get; set; }
        public decimal ToplamTutar { get; set; }
        public DateTime TeslimTarihi { get; set; }
        public byte Durumu { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Silindi { get; set; }

        [ForeignKey("MusteriID")]
        public virtual Musteri Musteri { get; set; }

        public virtual List<SatisDetay> SatisDetaylar { get; set; }


    }
}

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
    [Table("Urunler")]
    public class Urun : EntityBase
    {
        [Required]
        [StringLength(20)]
        public string UrunKodu { get; set; }
        [Required]
        [StringLength(50)]
        public string UrunAdi { get; set; }
        public int? KategoriID { get; set; }
        public int AltKategoriID { get; set; }

        [Required]
        [DefaultValue(1)]
        public int Miktar { get; set; }
        [Required]
        [DefaultValue(0)]
        public decimal UrunFiyat { get; set; }
        public string UrunBilgisi { get; set; }
        [StringLength(100)]
        public string UrunResimYolu1 { get; set; }
        [StringLength(100)]
        public string UrunResimYolu2 { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Indirim { get; set; }
        [Required]
        [DefaultValue(0)]
        public int IndirimOrani { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool Silindi { get; set; }

        [ForeignKey("KategoriID")]
        public virtual Kategori Kategori { get; set; }

        [ForeignKey("AltKategoriID")]
        public virtual AltKategori AltKategori { get; set; }
        public virtual List<SatisDetay> SatisDetaylar { get; set; }
    }
}

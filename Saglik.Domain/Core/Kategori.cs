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
    [Table("Kategoriler")]
    public class Kategori : EntityBase
    {
        [MaxLength(50)]
        [Required]
        public string KategoriAdi { get; set; }
        public string Aciklama { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Silindi { get; set; }

        public virtual List<AltKategori> AltKategoriler { get; set; }
    }
}

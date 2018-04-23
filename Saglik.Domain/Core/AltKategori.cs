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
    [Table("AltKategoriler")]
    public class AltKategori : EntityBase
    {
        [MaxLength(50)]
        [Required]
        public string AltKategoriAdi { get; set; }
        public int? KategoriID { get; set; }
        public string Aciklama { get; set; }
        [Required]
        [DefaultValue(false)]
        public bool Silindi { get; set; }

        [ForeignKey("KategoriID")]
        public virtual Kategori Kategori { get; set; }
    }
}

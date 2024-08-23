using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models
{
    public class SkuMedia
    {
        public int Id { get; set; }
        public string Image { get; set; }

        [ForeignKey("Sku")]
        public int? SkuID { get; set; }
        public virtual Skus Sku { get; set; }
    }
}

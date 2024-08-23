using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models
{
    public class AttributeOptionSku
    {
        public int Id { get; set; }

        [ForeignKey("AttributesOptions")]
        public int AttributeOptionId { get; set; }

        [ForeignKey("Sku")]
        public int SkusId { get; set; }

        public virtual AttributesOptions AttributesOptions { get; set; }
        public virtual Skus Sku { get; set; }
    }
}

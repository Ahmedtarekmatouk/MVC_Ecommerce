using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models
{
    public class Skus
    {
        public int Id { get; set; }

        [ForeignKey("Products")]
        public int ProductsId { get; set; }

        // add unique validation on view model of create and update
        public string Code { get; set; }

        [Column(TypeName = "money")]
        public decimal? Price { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public virtual Products Products { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models
{
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Slug{ get; set; }

        public string Description { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set;}

        [ForeignKey("Store")]
        public string? StoreId { get; set;}

        public DateTime? CreatedAt { get; set; }

        public DateTime? UpdatedAt { get;set; }

        public virtual Category Category { get; set; }

        public virtual ApplicationUser? Store {  get; set; }
    }
}

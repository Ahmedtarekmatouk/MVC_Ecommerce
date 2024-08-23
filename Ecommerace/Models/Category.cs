using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [ForeignKey("Parent")]    
        public int? Parent_Id { get; set; }

        public virtual Category? Parent { get; set; }

        public string? Image { get; set; }

        public DateTime Created_at { get; set; } = DateTime.Now;

        public DateTime Updated_at { get; set; } = DateTime.Now;

        public virtual ICollection<Category> SubCategories { get; set; } = new List<Category>();

        public virtual List<Products>? Products { get; set; } = new List<Products>();

    }
}

using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Ecommerace.Models
{
    public class ProductAttributes
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Attribute Name")]
        public string Name { get; set; }
    }
}

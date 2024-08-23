using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models
{
    public class AttributesOptions
    {
       
        public int Id { get; set; }
        [Required]
		[Display(Name = "Attribute Option Value")]
		public string Value { get; set; }

        [Required]
		[Display(Name = "Attribute Name")]
		[ForeignKey("Attribute")] 
        public int AttributeId { get; set; }

        public virtual ProductAttributes? Attribute { get; set; }
    }
}

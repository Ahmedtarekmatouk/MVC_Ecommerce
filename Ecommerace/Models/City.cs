using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models
{
    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("State")]
        public int StateId { get; set; }

        public virtual State State { get; set; }

        
    }
}

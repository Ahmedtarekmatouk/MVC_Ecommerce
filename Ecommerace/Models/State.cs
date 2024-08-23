using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models
{
    public class State
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Country")]
        public int CountryId { get; set; }

        public virtual Country Country { get; set; }

    }
}

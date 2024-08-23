using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models
{
    public class UserAddress
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string? UserId { get; set; }

        [ForeignKey("Country")]
        public int? CountryId { get; set; }

        [ForeignKey("State")]
        public int? StateId { get; set; }

        [ForeignKey("City")]
        public int? CityId { get; set; }

        public string Address {  get; set; }

        public virtual Country? Country { get; set; }

        public virtual State? State { get; set; }

        public virtual City? City { get; set; }

        public virtual ApplicationUser? User { get; set; }

    }
}

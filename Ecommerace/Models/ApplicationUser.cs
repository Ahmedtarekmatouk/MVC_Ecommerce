using Microsoft.AspNetCore.Identity;

namespace Ecommerace.Models
{
    public class ApplicationUser : IdentityUser
    {
        public decimal? Balance { get; set; } // for role store
        public virtual List<UserAddress>? Addresses { get; set; }
        public virtual List<Order>? ClientOrders { get; set; }
        public virtual List<Products>? StoreProducts { get; set; }
    }
}

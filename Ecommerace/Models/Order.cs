using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }


        public string? ClientId { get; set; }


        [ForeignKey("ShippingMethod")]
        public int? ShippingMethodsId { get; set; }

   
        [Range(0.01, double.MaxValue, ErrorMessage = "TotalPrice must be greater than 0")]
        public decimal TotalPrice { get; set; }

      
        [EnumDataType(typeof(OrderStatus))]
        public OrderStatus Status { get; set; }

        [StringLength(100, ErrorMessage = "ShippingAddress cannot be longer than 100 characters")]
        public string? ShippingAddress { get; set; }


        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public virtual ApplicationUser? Client { get; set; }
        public  virtual ShippingMethods? ShippingMethod { get; set; }
    }

    public enum OrderStatus
    {
        Pending,
        Shipped,
        Delivered,
        Cancelled
    }
}
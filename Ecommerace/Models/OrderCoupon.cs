using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models
{
    public class OrderCoupon
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }

        [ForeignKey("Coupon")]
        public int? CouponId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public virtual Order? Order { get; set; }
        public virtual Coupon? Coupon { get; set; }
    }
}

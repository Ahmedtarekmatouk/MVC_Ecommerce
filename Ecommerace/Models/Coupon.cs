using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models
{
    public class Coupon
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Code { get; set; }


        [ForeignKey("Products")]
        public int? ProductId { get; set; }

        public int CouponType { get; set; } //{General = 1 , product =2 }
		public int? CouponExpiration { get; set; }  //{ time = 1 , limited used = 2}

		[Required(ErrorMessage = "Discount type is required.")]
		[Range( 1, int.MaxValue, ErrorMessage = "Discount type must be a positive value ")]
        public int? DiscountType { get; set; }

		[Required(ErrorMessage = "Discount Value is required.")]
		[Range( 1, int.MaxValue, ErrorMessage = "Discount value must be a positive number ")]
        public int? DiscountValue { get; set; }

        [DataType(DataType.Date)]
        public DateTime? StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }


        [Range( 0, int.MaxValue, ErrorMessage = "Usage limit must be a non-negative integer.")]
        public int? UsageLimit { get; set; }

         
        [Range( 0, int.MaxValue, ErrorMessage = "Used count must be a non-negative integer.")]
        public int? UsedCount { get; set; }

        public DateTime? CreatedAt { get; set; }  = DateTime.Now;

        public DateTime? UpdatedAt { get; set; } = DateTime.Now;

        public virtual Products? Products { get; set; }
    }
}

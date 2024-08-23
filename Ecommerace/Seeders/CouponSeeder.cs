using Bogus;
using Ecommerace.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerace.Seeders
{
    public class CouponSeeder
    {

        public static async Task Run()
        {
            MVCECommeraceContext _context = new MVCECommeraceContext();
            var coupons = CouponSeeder.GenerateCoupons();

            await _context.Coupon.AddRangeAsync(coupons);
            await _context.SaveChangesAsync();
        }


        public static List<Coupon> GenerateCoupons()
        {
            var faker = new Faker();

            // Create a list to hold the coupons
            var coupons = new List<Coupon>();

            for (int i = 0; i < 25; i++)
            {
                // Randomly determine the coupon expiration type
                var couponExpiration = faker.Random.Int(1, 2);

                var coupon = new Coupon
                {
                    Code = faker.Commerce.Ean13(),
                    CouponType = 1, // General
                    CouponExpiration = couponExpiration,
                    DiscountType = faker.Random.Int(1, 10), // Random positive integer for discount type
                    DiscountValue = faker.Random.Int(1, 100), // Random positive integer for discount value
                    CreatedAt = faker.Date.Past(),
                    UpdatedAt = faker.Date.Recent()
                };

                if (couponExpiration == 1) // Time-based expiration
                {
                    coupon.UsageLimit = null;
                    coupon.UsedCount = null;

                    // Generate random start and end dates
                    var startDate = faker.Date.Past();
                    var endDate = faker.Date.Between(startDate, DateTime.Now.AddMonths(6)); // Ensure EndDate > StartDate
                    coupon.StartDate = startDate;
                    coupon.EndDate = endDate;
                }
                else if (couponExpiration == 2) // Limited usage
                {
                    coupon.StartDate = null;
                    coupon.EndDate = null;
                    coupon.UsageLimit = 10;
                    coupon.UsedCount = 0;
                }

                coupons.Add(coupon);
            }

            return coupons;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace Ecommerace.Models;

public class OrderItem
{
    public int Id { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }

    [ForeignKey("Order")]
    public int OrderId { get; set; }

    [ForeignKey("Skus")]
    public int SkusId { get; set; }

    [ForeignKey("Store")]
    public string StoreId { get; set; }


    public virtual Order Order { get; set; }
    public virtual Skus Skus { get; set; }
    public virtual  ApplicationUser Store { get; set; }

    public DateTime? CreatedAt { get; set; } = DateTime.Now;
    public DateTime? UpdatedAt { get; set; } = DateTime.Now;
}


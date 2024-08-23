using System.ComponentModel.DataAnnotations;

namespace Ecommerace.Models;

public class ShippingMethods
{
    public int Id { get; set; }
    [MaxLength(255)]
    public string Name { get; set; }
    public string? Description { get; set; }
    public double? Cost { get; set; }
    public int? EstimatedDeliveryTime { get; set; }
    public DateTime? CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
}

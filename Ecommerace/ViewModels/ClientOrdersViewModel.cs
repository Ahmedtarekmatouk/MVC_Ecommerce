namespace Ecommerace.ViewModels
{
    public class ClientOrdersViewModel
    {
        public int OrderId {get; set; }
        public DateTime CreatedAt { get; set; }
        public string TotalPrice { get; set; }
        public int OrderStatus { get; set; }
    }
}

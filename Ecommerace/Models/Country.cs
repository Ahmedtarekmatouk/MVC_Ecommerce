namespace Ecommerace.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
          
        public virtual List<UserAddress>? UserAddresses { get; set; }
    }
}

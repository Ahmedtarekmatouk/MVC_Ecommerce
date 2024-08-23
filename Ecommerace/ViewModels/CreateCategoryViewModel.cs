namespace Ecommerace.ViewModels
{
    public class CreateCategoryViewModel
    {
        public string Name { get; set; }
        public int? ParentId { get; set; }
        public IFormFile? Image { get; set; }
    }
}
    
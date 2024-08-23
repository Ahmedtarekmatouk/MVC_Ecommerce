namespace Ecommerace.ViewModels
{
    public class Paginator
    {
        public int totalItems { get; set; }

        public int totalPages { get; set; }

        public int currentPage { get; set; }

        public int pageSize { get; set; }

        public int startPage { get; set; }

        public int endPage { get; set; }

    }
}

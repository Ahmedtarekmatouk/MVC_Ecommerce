using Ecommerace.ViewModels;

namespace Ecommerace.Helpers;

public static class PaginatorHelper
{

public static Paginator setPagination(int totalItems, int page, int pageSize = 10)
    {
        Paginator paginator = new Paginator();
        paginator.totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
        paginator.currentPage = page;

        paginator.startPage = Math.Max(1, paginator.currentPage - 5);
        paginator.endPage = Math.Min(paginator.totalPages, paginator.currentPage + 4);

        if (paginator.endPage - paginator.startPage < 9)
        {
            if (paginator.startPage == 1)
            {
                paginator.endPage = Math.Min(10, paginator.totalPages);
            }
            else if (paginator.endPage == paginator.totalPages)
            {
                paginator.startPage = Math.Max(1, paginator.endPage - 9);
            }
        }

        paginator.totalItems = totalItems;
        paginator.pageSize = pageSize;

        return paginator;
    }

}

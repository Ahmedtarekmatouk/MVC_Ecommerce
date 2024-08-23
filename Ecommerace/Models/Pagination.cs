using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Drawing.Printing;

namespace Ecommerace.Models
{
    public class Pagination<T> : IEnumerable<T>
    {
        public List<T> Items { get; set; }
        public int TotalItems { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalPages { get; set; }

        public Pagination(List<T> items, int count, int pageIndex, int pageSize)
        {
            this.Items = items;
            this.TotalItems = count;
            this.PageIndex = pageIndex;
            this.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.PageSize = pageSize;
        }

        public bool HasPreviousPage => PageIndex > 1;
        public bool HasNextPage => PageIndex < TotalPages;

        public IEnumerator<T> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}

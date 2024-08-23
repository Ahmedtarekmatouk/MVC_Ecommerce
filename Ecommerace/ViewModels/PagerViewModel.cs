namespace Ecommerace.ViewModels
{
	public class PagerViewModel
	{
		public int totalItems { get; set; }

		public int totalPages { get; set; }

		public int currentPage { get; set; }

		public int pageSize { get; set; }

		public int startPage { get; set; }

		public int endPage { get; set; }

		public PagerViewModel() { }

		public PagerViewModel(int totalItems, int page, int pageSize = 10)
		{

			this.totalPages = (int)Math.Ceiling((decimal)totalItems / (decimal)pageSize);
			this.currentPage = page;

			this.startPage = Math.Max(1, currentPage - 5);
			this.endPage = Math.Min(totalPages, currentPage + 4);

			if (endPage - startPage < 9)
			{
				if (startPage == 1)
				{
					endPage = Math.Min(10, totalPages);
				}
				else if (endPage == totalPages)
				{
					startPage = Math.Max(1, endPage - 9);
				}
			}

			this.totalItems = totalItems;
			this.pageSize = pageSize;


		}
	}

}

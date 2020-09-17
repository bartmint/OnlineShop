using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShop.Application.Helpers
{
    public class Paginate
    {
        public int PageIndex { get;  set; }
        public int TotalPages { get;  set; }
        public string SearchString { get; set; }
        public string Error { get; set; }
        public Paginate(int total, int pageIndex, int pageSize)
        {
            TotalPages = (int)Math.Ceiling(total / (double)pageSize);
            PageIndex = pageIndex;
        }
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages);
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMangement.Models.Pagination
{
    public class Pager
    {
        public int TotalItems { get;  set; }
        public int CurrentPage { get;  set; }
        public int PageSize { get;  set; }
        public int TotalPages { get;  set; }
        public int StartPage { get;  set; }
        public int EndPage { get;  set; }
        public int MaxShowPage { get; set; }
        public Pager(int TotalItems, int CurrentPage, int PageSize)
        {
            this.CurrentPage = CurrentPage;
            this.PageSize = PageSize;
            this.TotalItems = TotalItems;

            TotalPages = (int)Math.Ceiling((decimal)TotalItems / (decimal)PageSize);
            this.CurrentPage = CurrentPage != null ? (int)CurrentPage : 1;
            this.MaxShowPage = 5;
            if (TotalPages <= MaxShowPage)
            {
                StartPage = 1;
                EndPage = TotalPages;
                     
            };
            if(TotalPages > MaxShowPage)
            {
                if (CurrentPage <= (MaxShowPage + 1)/2)
                {
                    StartPage = 1;
                    EndPage = MaxShowPage;
                };
                if(CurrentPage > (MaxShowPage + 1) / 2 &&  CurrentPage <= TotalPages - (MaxShowPage + 1) / 2)
                {
                    StartPage = CurrentPage - ((MaxShowPage -1)/2);
                    EndPage = CurrentPage + ((MaxShowPage - 1) / 2);
                }
                if(CurrentPage > TotalPages - (MaxShowPage + 1) / 2 && CurrentPage <= TotalPages)
                {
                    StartPage = TotalPages - MaxShowPage + 1;
                    EndPage = TotalPages;
                }
            }

        }
    }
}

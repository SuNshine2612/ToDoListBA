using System;
using System.Collections.Generic;

namespace ToDoList.Models.SeedWorks
{
    public class PagedList<T>
    {
        public MetaData MetaData { get; set; }

        public List<T> Datas { get; set; }

        public PagedList()
        {

        }

        public PagedList(List<T> Items, int Count, int PageNumber, int PageSize)
        {
            MetaData = new()
            {
                TotalCount = Count,
                PageSize = PageSize,
                CurrentPage = PageNumber,
                TotalPages = (int)Math.Ceiling(Count / (double)PageSize)
            };
            Datas = Items;
        }
    }
}

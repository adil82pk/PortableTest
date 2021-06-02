using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.DTO
{
    public class Response<T>
    {
        public string Status { get; set; }
        public string UserTier { get; set; }
        public int Total { get; set; }
        public int StartIndex { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int Pages { get; set; }
        public string OrderBy { get; set; }
        public List<T> Results { get; set; }
    }
}

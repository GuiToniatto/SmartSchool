using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Web_API_.NET.V1.Dtos;

namespace Web_API_.NET.Helpers
{
    public class PageParameters
    {
        public const int MaxPageSize = 50;
        public int PageNumber { get; set; } = 1;
        private int pageSize = 10;
        public int PageSize { 
            get { return pageSize; }
            set { pageSize = (value > MaxPageSize) ? MaxPageSize : value; }
        }
        public int? Registration { get; set; } = null;
        public string Name { get; set; } = string.Empty;
        public int? Active { get; set; } = null;
    }
}
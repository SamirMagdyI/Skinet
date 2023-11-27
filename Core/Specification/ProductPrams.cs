using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Core.Specification
{
    public class ProductPrams
    {
        private const int MaxPageSize = 50;
        public int? BrandId { get; set; }
        public int? TypeId { get; set; }
        public string? Sort { get; set; } 
        private string? _search;
        public string? Search
        {
            get => _search;
            set => _search = value.ToLower();
        }

        private int _pageIndex=1;
        public int PageIndex
        {
            get => _pageIndex;
            set=> _pageIndex = (value>=1)?value:1;
        }

        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }


    }
}

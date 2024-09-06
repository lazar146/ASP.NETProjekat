using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.DTO
{
    public class PagedSearch
    {
        public int? Page { get; set; } = 1;
        public int? ItemsPerPage { get; set; } = 2;
    }
}

﻿using Repository.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Models
{
    
    public class CategoryListViewModel
    {
        public CategoryViewModel Category { get; set; }
        public IEnumerable<ProductViewModel> Products;
        public ProductListing OrderBy { get; set; }
        public int Count { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
    public class CategorySearchViewModel
    {
        public CategorySearchViewModel()
        {
            Page = 1;
            Limit = 15;
        }
        public int Id { get; set; }
        public int Page { get; set; }
        public int Limit { get; set; }
    }
}

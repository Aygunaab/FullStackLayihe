using Repository.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DTO
{
    public class FilterDto
    {
        public string Name { get; set; }
        public List<ProductSpecsification> Specs { get; set; }
        public int Count { get; set; }
    }
}

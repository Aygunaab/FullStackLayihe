using Microsoft.AspNetCore.Http;
using Repository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Mioca.Areas.Admin.Models
{
    public class VmProductPost
    {
        //post
        [Required]
       
        public bool Status { get; set; }
        [Required]
        [StringLength(maximumLength: 50)]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(maximumLength: 5000)]
        public string Desc { get; set; }
        [Required]
        [StringLength(maximumLength: 500)]
        public string SubText { get; set; }
        public string Image { get; set; }
        public IFormFile MainImage{ get; set; }
       
        public IFormFile[] Images { get; set; }
        public int CategoryId { get; set; }
        public int? LabelId { get; set; }
        [Required]
        public bool IsPopularCategory { get; set; }
        [Required]
        public bool IsBestSeellers { get; set; }
        [Required]
        public byte StarCount { get; set; }
        public bool IsSingleBanner { get; set; }
        [Required]
        public decimal Quantity { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IList<string> Photos { get; set; }
        //get
        public List<Category> Categories { get; set; }
        public List<Label> Label { get; set; }
     
       
    }
}

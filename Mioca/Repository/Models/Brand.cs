using System.ComponentModel.DataAnnotations;

namespace Repository.Models
{
   public class Brand:BaseEntity
    {
        
         [Required,MaxLength(50)]
        public string Icon { get; set; }
    }
}

using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;


namespace Repository.Models
{
    public class OurMission:BaseEntity
    {
        [Required, MaxLength(150)]
        public string Image { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        [Required, MaxLength(5000)]
        public string Desc { get; set; }
        [Required, MaxLength(250)]
        public string Videolink { get; set; }
    

    }
}

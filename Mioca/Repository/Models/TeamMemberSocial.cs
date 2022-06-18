

namespace Repository.Models
{
   public class TeamMemberSocial
    {
        public int Id { get; set; }
        public int SocialId { get; set; }
        public int  TeamId { get; set; }
        public Social Social { get; set; }
        public TeamMember TeamMember { get; set; }
        public string Link { get; set; }
    }
}

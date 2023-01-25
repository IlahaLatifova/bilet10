using System.ComponentModel.DataAnnotations;

namespace Bilet10.Models
{
    public class TeamMember
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50)]
        public string FullName { get; set; }
        public string Prefession { get; set; }
        public string ImageUrl { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public bool IsDeleted { get; set; }
        

    }
}

using System.ComponentModel.DataAnnotations;

namespace Bilet10.ViewModels.TeamViewModel
{
    public class TeamPostVM
    {
        public string FullName { get; set; }
        public string Prefession { get; set; }
        public IFormFile? FormFile { get; set; }
        public string FacebookUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
    }
}

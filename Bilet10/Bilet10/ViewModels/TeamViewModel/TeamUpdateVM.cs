namespace Bilet10.ViewModels.TeamViewModel
{
    public class TeamUpdateVM
    {
        public TeamGetVM teamGet { get; set; }
        public TeamPostVM teamPost { get; set; }
        public TeamUpdateVM()
        {
            teamPost = new TeamPostVM();
        }
    }
}

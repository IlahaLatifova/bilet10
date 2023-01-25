using AutoMapper;
using Bilet10.Models;
using Bilet10.ViewModels.TeamViewModel;

namespace Bilet10.Profiles
{
    public class Mapper:Profile
    {
        public Mapper()
        {
            CreateMap<TeamMember, TeamGetVM>();
            CreateMap<TeamPostVM, TeamMember>();
        }
    }
}

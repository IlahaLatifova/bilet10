
using AutoMapper;
using Bilet10.DAL;
using Bilet10.Models;
using Bilet10.ViewModels.TeamViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace Bilet10.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            List <TeamMember> members = _context.teamMembers.ToList();
            List<TeamGetVM>  teamsGet = _mapper.Map<List<TeamGetVM>>(members);
            return View(teamsGet);
        }

        
    }
}
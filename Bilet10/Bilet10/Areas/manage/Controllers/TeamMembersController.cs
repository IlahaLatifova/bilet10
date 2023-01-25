using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bilet10.DAL;
using Bilet10.Models;
using Bilet10.ViewModels.TeamViewModel;
using AutoMapper;
using Bilet10.Migrations;
using Bilet10.Extensions.FileManageExtension;

namespace Bilet10.Areas.manage.Controllers
{
    [Area("manage")]
    public class TeamMembersController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _env;

        public TeamMembersController(AppDbContext context, IMapper mapper, IWebHostEnvironment env)
        {
            _context = context;
            _mapper = mapper;
            _env = env;
        }


        public async Task<IActionResult> Index()
        {
            List<TeamMember> members = _context.teamMembers.ToList();
            List<TeamGetVM> membersGet = _mapper.Map<List<TeamGetVM>>(members);
              return View(membersGet);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TeamPostVM teamPost)
        {

            if (!ModelState.IsValid)
            {
                return View(teamPost);
            }
            TeamMember member = _mapper.Map<TeamMember>(teamPost);
            if(teamPost.FormFile is not null)
            {
                if (!teamPost.FormFile.IsTrueContent())
                {
                    ModelState.AddModelError("FormFile", "Invalid fomat!!!");
                    return View(teamPost);
                }
                if (!teamPost.FormFile.IsValidLength())
                {
                    ModelState.AddModelError("FormFile", "Length must be less than 2mb!!!");
                    return View(teamPost);
                }
                member.ImageUrl = teamPost.FormFile.CreateUrl(_env.WebRootPath, "assets/img");
            }
            await _context.teamMembers.AddAsync(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
           
        }

        // GET: manage/TeamMembers/Edit/5
        public async Task<IActionResult> Update(int id)
        {
            TeamMember member = _context.teamMembers.Find(id);
            if (member == null)
            {
                return NotFound();
            }
            TeamUpdateVM memberUpdate = new TeamUpdateVM()
            {
                teamGet = _mapper.Map<TeamGetVM>(member)
            };

          
            return View(memberUpdate);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TeamUpdateVM teamUpdate)
        {
            TeamMember teamMember = _context.teamMembers.Find(teamUpdate.teamGet.Id);

          
            return View(teamMember);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.teamMembers == null)
            {
                return NotFound();
            }

            var teamMember = await _context.teamMembers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (teamMember == null)
            {
                return NotFound();
            }

            return View(teamMember);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.teamMembers == null)
            {
                return Problem("Entity set 'AppDbContext.teamMembers'  is null.");
            }
            var teamMember = await _context.teamMembers.FindAsync(id);
            if (teamMember != null)
            {
                _context.teamMembers.Remove(teamMember);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TeamMemberExists(int id)
        {
          return _context.teamMembers.Any(e => e.Id == id);
        }
    }
}

using Bilet10.Models;
using Microsoft.EntityFrameworkCore;

namespace Bilet10.DAL
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        public DbSet<TeamMember> teamMembers { get; set; }
    }
}

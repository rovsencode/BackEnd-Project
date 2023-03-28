using BackEndProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {

        public AppDbContext(DbContextOptions options) :base(options)
        {

        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<BoardInfo> BoardInfos { get; set; }
        public DbSet<EduHomeInfo> EduHomeInfos { get; set;}

        public DbSet<Bio> Bios { get; set; }
        public DbSet<SliderComment> SliderComments { get; set; }

    }
}

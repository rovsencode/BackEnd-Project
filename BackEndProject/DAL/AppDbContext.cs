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
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<TeacherHobbies> TeacherHobies { get; set; }
        public DbSet<Socials> TeacherSocials { get; set; }

        public DbSet<Hobbies> Hobbies { get; set; }
        public DbSet<Skills> TeacherSkills { get; set; }
        public DbSet <WelcomeEduHome>  WelcomeEduHomes{ get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<CourseTags> CourseTags { get; set; }
        public DbSet<CourseFeatures> CourseFeatures { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Speaker> Speakers { get; set; }
        public DbSet<Companie> Companies { get; set; }
        public DbSet<Blog> Blogs { get; set; }



    }
}

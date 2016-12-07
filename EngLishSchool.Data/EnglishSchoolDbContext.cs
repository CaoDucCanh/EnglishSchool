using EngLishSchool.Model.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace EngLishSchool.Data
{
    public class EnglishSchoolDbContext : IdentityDbContext<ApplicationUser>
    {
        public EnglishSchoolDbContext()
            : base("EnglishSchoolConnection")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<TypeUser> TypeUsers { set; get; }
        public DbSet<Clas> Class { set; get; }
        public DbSet<Level> Levels { set; get; }
        public DbSet<LevelSchool> LevelSchools { set; get; }
        public DbSet<School> Schools { set; get; }
        public DbSet<Tree> Trees { set; get; }
        public DbSet<Error> Errors { set; get; }


        public static EnglishSchoolDbContext Create()
        {
            return new EnglishSchoolDbContext();
        }

        //trong qúa trình làm ta phải ghi đè 1 phương thức của DBContext, nó sẽ chạy khi mà chúng ta khởi tạo entity framework
        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<IdentityUserRole>().HasKey(i => new { i.UserId, i.RoleId }).ToTable("ApplicationUserRoles");
            builder.Entity<IdentityUserLogin>().HasKey(i => i.UserId).ToTable("ApplicationUserLogins");
            builder.Entity<IdentityRole>().ToTable("ApplicationRoles");
            builder.Entity<IdentityUserClaim>().ToTable("ApplicationUserClaims");
        }
    }
}
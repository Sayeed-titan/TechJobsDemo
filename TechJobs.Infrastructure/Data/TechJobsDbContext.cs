using Microsoft.EntityFrameworkCore;
using TechJobs.Models;

namespace TechJobs.Infrastructure.Data
{
   public class TechJobsDbContext : DbContext
   {
      public TechJobsDbContext(DbContextOptions<TechJobsDbContext> options) : base(options)
      {
      }

      public DbSet<Role> Roles { get; set; }
      public DbSet<User> Users { get; set; }
      //public DbSet<Gender> Genders { get; set; }
      //public DbSet<Religion> Religions { get; set; }
      //public DbSet<Nationality> Nationalities { get; set; }
      //public DbSet<MaritalStatus> MaritalStatuses { get; set; }
      //public DbSet<Blog> Blogs { get; set; }
      //public DbSet<BlogVideo> BlogVideos { get; set; }
      //public DbSet<Review> Reviews { get; set; }
      //public DbSet<Course> Courses { get; set; }


      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
         // Role entity configuration
         modelBuilder.Entity<Role>(entity =>
         {
            entity.HasKey(r => r.RoleId);
            entity.Property(r => r.RoleName)
                     .IsRequired()
                     .HasMaxLength(50);
         });

         // User entity configuration
         modelBuilder.Entity<User>(entity =>
         {
            entity.HasKey(u => u.UserId);

            entity.Property(u => u.FullName)
                .IsRequired()
                .HasMaxLength(100);

            entity.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(255);

            entity.Property(u => u.Phone)
                .IsRequired()
                .HasMaxLength(30);

            // Set up the FK relationship (now types match)
            entity.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .HasForeignKey(u => u.RoleId)
                .HasPrincipalKey(r => r.RoleId);

            entity.Property(u => u.CreatedAt).IsRequired();
         });

         // Seed data for Roles
         modelBuilder.Entity<Role>().HasData(
             new Role { RoleId = 1, RoleName = "JobSeeker" },
             new Role { RoleId = 2, RoleName = "Employer" },
             new Role { RoleId = 3, RoleName = "Admin" }
         );

         // Seed data for Users (password hashes here are fake, replace with real hashes)
         modelBuilder.Entity<User>().HasData(
             // 1 Admin
             new User
             {
                UserId = 1,
                FullName = "Kazi Abu Sayeed",
                Email = "kaziabu.sayeed29@gmail.com",
                PasswordHash = "admin12345",
                Phone = "01681-186651",
                RoleId = 3,
                CreatedAt = DateTime.UtcNow
             },
             // 2 Job Seekers
             new User
             {
                UserId = 2,
                FullName = "Mahmudul Hasan",
                Email = "Mahmudul Hasan@gmail.com",
                PasswordHash = "mahmudul12345",
                Phone = "01711-000002",
                RoleId = 1,
                CreatedAt = DateTime.UtcNow
             },
             new User
             {
                UserId = 3,
                FullName = "Jahangir Alam",
                Email = "jahangir.seeker@jobmail.com",
                PasswordHash = "jahangir_hash",
                Phone = "01711-000003",
                RoleId = 1,
                CreatedAt = DateTime.UtcNow
             },
             // 2 Employers
             new User
             {
                UserId = 4,
                FullName = "Nasima Begum",
                Email = "nasima.employer@employer.com",
                PasswordHash = "nasima_hash",
                Phone = "01711-000004",
                RoleId = 2,
                CreatedAt = DateTime.UtcNow
             },
             new User
             {
                UserId = 5,
                FullName = "Abdur Rahman",
                Email = "abdur.employer@employer.com",
                PasswordHash = "abdur_hash",
                Phone = "01711-000005",
                RoleId = 2,
                CreatedAt = DateTime.UtcNow
             }
         );
      }
   }

}





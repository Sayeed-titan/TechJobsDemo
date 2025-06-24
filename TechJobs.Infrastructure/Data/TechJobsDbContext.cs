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
      public DbSet<Gender> Genders { get; set; }
      public DbSet<Religion> Religions { get; set; }
      public DbSet<Nationality> Nationalities { get; set; }
      public DbSet<MaritalStatus> MaritalStatuses { get; set; }
      //public DbSet<Blog> Blogs { get; set; }
      //public DbSet<BlogVideo> BlogVideos { get; set; }
      //public DbSet<Review> Reviews { get; set; }
      //public DbSet<Course> Courses { get; set; }

      protected override void OnModelCreating(ModelBuilder modelBuilder)
      {
#region EntityConfiguration
         modelBuilder.Entity<Role>(entity =>
         {
            entity.HasKey(r => r.RoleId);
            entity.Property(r => r.RoleName)
                     .IsRequired()
                     .HasMaxLength(50);
         });
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
         modelBuilder.Entity<Gender>(entity =>
         {
            entity.HasKey(g => g.GenderId);
            entity.Property(g => g.GenderName)
                  .IsRequired()
                  .HasMaxLength(50);
         });
         modelBuilder.Entity<Religion>(entity =>
         {
            entity.HasKey(r => r.ReligionId);
            entity.Property(r => r.ReligionName)
                  .IsRequired()
                  .HasMaxLength(100);
         });
         modelBuilder.Entity<Nationality>(entity =>
         {
            entity.HasKey(n => n.NationalityId);
            entity.Property(n => n.NationalityName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasData(
                new Nationality { NationalityId = 1, NationalityName = "Bangladeshi" },
                new Nationality { NationalityId = 2, NationalityName = "Indian" },
                new Nationality { NationalityId = 3, NationalityName = "Pakistani" },
                new Nationality { NationalityId = 4, NationalityName = "Nepali" },
                new Nationality { NationalityId = 5, NationalityName = "Other" }
            );
         });
         modelBuilder.Entity<MaritalStatus>(entity =>
         {
            entity.HasKey(m => m.MaritalStatusId);
            entity.Property(m => m.MaritalStatusName)
                .IsRequired()
                .HasMaxLength(50);

            entity.HasData(
                new MaritalStatus { MaritalStatusId = 1, MaritalStatusName = "Single" },
                new MaritalStatus { MaritalStatusId = 2, MaritalStatusName = "Married" },
                new MaritalStatus { MaritalStatusId = 3, MaritalStatusName = "Divorced" },
                new MaritalStatus { MaritalStatusId = 4, MaritalStatusName = "Widowed" }
            );
         });
         #endregion

         #region SeedData
         modelBuilder.Entity<Role>().HasData(
             new Role { RoleId = 1, RoleName = "JobSeeker" },
             new Role { RoleId = 2, RoleName = "Employer" },
             new Role { RoleId = 3, RoleName = "Admin" }
         );
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
         modelBuilder.Entity<Gender>().HasData(
             new Gender { GenderId = 1, GenderName = "Male" },
             new Gender { GenderId = 2, GenderName = "Female" },
             new Gender { GenderId = 3, GenderName = "Other" }
         );
         modelBuilder.Entity<Religion>().HasData(
             new Religion { ReligionId = 1, ReligionName = "Islam" },
             new Religion { ReligionId = 2, ReligionName = "Christianity" },
             new Religion { ReligionId = 3, ReligionName = "Hinduism" },
             new Religion { ReligionId = 4, ReligionName = "Buddhism" },
             new Religion { ReligionId = 5, ReligionName = "Other" }
         );


 #endregion

      }
   }

}





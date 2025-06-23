using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TechJobs.Models
{
   public class User
   {
      [Key]
      public int UserId { get; set; }

      [Required, StringLength(100)]
      public required string FullName { get; set; }

      [Required, StringLength(255)]
      [EmailAddress]
      public required string Email { get; set; }

      [Required, StringLength(255)]
      public required string PasswordHash { get; set; }

      [StringLength(30)]
      public  string Phone { get; set; } = string.Empty;

      [Required]
      [Column("RoleId")]
      public int RoleId { get; set; } 

      public virtual Role Role { get; set; } = default!;

      public DateTime CreatedAt { get; set; } = DateTime.Now;
   }
}

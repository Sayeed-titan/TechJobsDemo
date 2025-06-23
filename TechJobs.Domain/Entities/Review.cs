using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechJobs.Models
{
   public class Review
   {
      [Key]
      public int ReviewId { get; set; }

      [Required]
      public int UserId { get; set; }

      [ForeignKey("UserId")]
      public virtual User User { get; set; } = null!;

      [Required]
      public int ReviewCourseId { get; set; }

      [ForeignKey("CourseId")]
      public virtual Course Course { get; set; } = null!;

      [Required]
      [Range(1, 5)]
      public int Rating { get; set; }

      [StringLength(200)]
      public string? ReviewText { get; set; }

      public DateTime CreatedAt { get; set; } = DateTime.Now;
   }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechJobs.Models
{
   public class BlogVideo
   {
      [Key]
      public int BlogVideoId { get; set; }

      [Required]
      public int BlogId { get; set; }

      [ForeignKey("BlogId")]
      public virtual Blog Blog { get; set; } = null!;

      [Required, StringLength(500)]
      public string VideoUrl { get; set; } = string.Empty;

      [StringLength(255)]
      public string? Caption { get; set; }
   }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechJobs.Models
{
   public class Blog
   {
      [Key]
      public int BlogId { get; set; }

      [Required, StringLength(255)]
      public string Title { get; set; } = string.Empty;

      [Required, StringLength(2000)]
      public string Content { get; set; } = string.Empty;

      public int? AuthorId { get; set; }

      [ForeignKey("AuthorId")]
      public virtual User? Author { get; set; }

      public DateTime CreatedAt { get; set; } = DateTime.Now;

      public virtual ICollection<BlogVideo> BlogVideos { get; set; } = new List<BlogVideo>();
   }
}

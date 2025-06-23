using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechJobs.Models
{
   public class Religion
   {
      [Key]
      public int ReligionId { get; set; }

      [Required, StringLength(100)]
      public required string ReligionName { get; set; }
   }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechJobs.Models
{
   public class Gender
   {
      [Key]
      public int GenderId { get; set; }

      [StringLength(50)]
      public required string GenderName { get; set; }
   }
}

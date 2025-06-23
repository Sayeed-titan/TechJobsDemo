using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechJobs.Models
{
   public class Nationality
   {
      [Key]
      public int NationalityId { get; set; }

      [Required, StringLength(50)]
      public required string NationalityName { get; set; }
   }
}

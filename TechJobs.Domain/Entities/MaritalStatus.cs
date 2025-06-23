using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechJobs.Models
{
   public class MaritalStatus
   {
      [Key]
      public int MaritalStatusId { get; set; }

      [Required, StringLength(50)]
      public required string MaritalStatusName { get; set; }
   }
}

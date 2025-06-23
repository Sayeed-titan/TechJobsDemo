using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechJobs.Models
{
   public class Course
   {
      public int CourseId { get; set; }
      public required string CourseName { get; set; }
   }
}

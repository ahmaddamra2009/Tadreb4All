using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tadreb4All.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public string Position { get; set; }
        public string FbUrl { get; set; }
        public string TwUrl { get; set; }
        public string LinkedUrl { get; set; }
        public string Email { get; set; }
        public string InsImg { get; set; }
        public bool IsActive { get; set; }
    }
}

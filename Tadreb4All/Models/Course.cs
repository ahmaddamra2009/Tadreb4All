using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tadreb4All.Models
{
    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string CourseDesc { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
        public DateTime SDate { get; set; }
        public DateTime STime { get; set; }
        public string CourseImg { get; set; }
        public string Venu { get; set; }
        public bool IsActive { get; set; }
    }
}

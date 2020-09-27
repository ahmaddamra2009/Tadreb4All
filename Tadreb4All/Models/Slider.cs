using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tadreb4All.Models
{
    public class Slider
    {
        public int SliderId { get; set; }
        public string SliderTitle { get; set; }
        public string SubTitle { get; set; }
        public string Location { get; set; }
        public decimal DiscountPer { get; set; }
        public decimal Cost { get; set; }
        public string SliderImg { get; set; }
        public string SliderDesc { get; set; }
        public bool IsActive { get; set; }
    }
}

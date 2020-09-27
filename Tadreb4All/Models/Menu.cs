using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tadreb4All.Models
{
    public class Menu
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }
        public string MenuUrl { get; set; }
        public bool IsActive { get; set; }
    }
}

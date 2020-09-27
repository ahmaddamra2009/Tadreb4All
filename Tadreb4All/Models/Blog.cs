using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Tadreb4All.Models
{
    public class Blog
    {

        public int BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogDesc { get; set; }
        public string UserName { get; set; }
        public string BlogImg { get; set; }
        public DateTime PubDate { get; set; }
        public bool IsPublished { get; set; }
    }
}

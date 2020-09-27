using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Tadreb4All.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string FullName { get; set; }
        public DateTime RegDate { get; set; }
        public string UserImg { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }

    }
}

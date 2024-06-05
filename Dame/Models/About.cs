using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dame.Models
{
    public class About
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Group { get; set; }
        public string? Description { get; set; }
        public About(string name, string email, string group, string description) {
            Name = name;
            Email = email;
            Group = group;
            Description = description;
        }
    }
}

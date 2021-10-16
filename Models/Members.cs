using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Models
{
    public class Members
    {
        [Key]
        public int IdMember { get; set; }
        
        [Required]
        public string Name1 { get; set; }
        public string Name2 { get; set; }
        public string Alias { get; set; }
        public string Telephone { get; set; }
        public DateTime DateEntry { get; set; }
        public DateTime LastDateReEntry { get; set; }
        public string Description { get; set; }
        public int IdVacancie { get; set; }

    }
}

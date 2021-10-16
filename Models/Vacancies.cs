using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Models
{
    public class Vacancies
    {
        [Key]
        public int IdVacancie { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}

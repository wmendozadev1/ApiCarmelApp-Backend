using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Models
{
    public class PersonalContributions
    {
        [Key]
        public int IdContribution { get; set; }
        
        [Required]
        public int IdMember { get; set; }
        
        [Required]
        public DateTime Fecha { get; set; }

        public double ProCasaCordoba { get; set; }
        public double ProCasaDolar { get; set; }
        public double ProMejoraCordoba { get; set; }
        public double ProMejoraDolar { get; set; }
        public double ProRentaCordoba { get; set; }
        public double ProRentaDolar { get; set; }


    }
}

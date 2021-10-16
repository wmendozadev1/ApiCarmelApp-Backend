using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Models
{
    public class GeneralContributions
    {
        [Key]
        public int IdContribution { get; set; }
        
        [Required]
        public DateTime Fecha { get; set; }
        
        public double SeptCordoba { get; set; }
        public double SeptDolar { get; set; }
        public double AnivCordoba { get; set; }
        public double AnivDolar { get; set; }

    }
}

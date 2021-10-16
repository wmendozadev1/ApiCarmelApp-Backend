using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Models.Dto
{
    public class GeneralContributionDto
    {
        
        public int IdContribution { get; set; }
                
        public DateTime Fecha { get; set; }

        public double SeptCordoba { get; set; }
        public double SeptDolar { get; set; }
        public double AnivCordoba { get; set; }
        public double AnivDolar { get; set; }
    }
}

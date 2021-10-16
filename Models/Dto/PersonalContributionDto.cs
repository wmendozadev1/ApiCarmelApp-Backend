using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Models.Dto
{
    public class PersonalContributionDto
    {
        public int IdContribution { get; set; }

        public int IdMember { get; set; }

        public DateTime Fecha { get; set; }

        public double ProCasaCordoba { get; set; }
        public double ProCasaDolar { get; set; }
        public double ProMejoraCordoba { get; set; }
        public double ProMejoraDolar { get; set; }
        public double ProRentaCordoba { get; set; }
        public double ProRentaDolar { get; set; }

    }
}

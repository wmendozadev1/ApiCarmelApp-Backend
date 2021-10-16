using APICarmel.Models;
using APICarmel.Models.Dto;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<MemberDto, Members>();
                config.CreateMap<Members,MemberDto>();
                
                config.CreateMap<VacancieDto, Vacancies>();
                config.CreateMap<Vacancies, VacancieDto>();

                config.CreateMap<GeneralContributionDto, GeneralContributions>();
                config.CreateMap<GeneralContributions, GeneralContributionDto>();

                config.CreateMap<PersonalContributionDto, PersonalContributions>();
                config.CreateMap<PersonalContributions, PersonalContributionDto>();

            });

            return mappingConfig;
        }

    }
}

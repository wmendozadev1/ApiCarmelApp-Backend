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
            });

            return mappingConfig;
        }

    }
}

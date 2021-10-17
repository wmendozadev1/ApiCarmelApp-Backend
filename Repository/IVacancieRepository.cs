using APICarmel.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Repository
{
    public interface IVacancieRepository
    {
        Task<List<VacancieDto>> GetVacancies();
        Task<VacancieDto> GetVacancieById(int id);
        Task<VacancieDto> CreateUpdate(VacancieDto vacancieDto);
        Task<bool> DeleteVacancie(int id);
    }
}

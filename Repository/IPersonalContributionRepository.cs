using APICarmel.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Repository
{
    public interface IPersonalContributionRepository
    {
        Task<List<PersonalContributionDto>> GetPersonalContributions();
        Task<PersonalContributionDto> GetPersonalContributionById(int id);
        Task<PersonalContributionDto> CreateUpdate(PersonalContributionDto personalcontributionDto);
        Task<bool> DeletePersonalContribution(int id);
    }
}

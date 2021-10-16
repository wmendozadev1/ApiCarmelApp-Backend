using APICarmel.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Repository
{
    public interface IGeneralContributionRepository
    {
        Task<List<GeneralContributionDto>> GetGeneralContributions();
        Task<GeneralContributionDto> GetGeneralContributionById(int id);
        Task<GeneralContributionDto> CreateUpdate(GeneralContributionDto generalcontributionDto);
        Task<bool> DeleteGeneralContribution(int id);
    }
}

using APICarmel.Data;
using APICarmel.Models;
using APICarmel.Models.Dto;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Repository
{
    public class GeneralContributionRepository : IGeneralContributionRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public GeneralContributionRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<GeneralContributionDto> CreateUpdate(GeneralContributionDto generalcontribDto)
        {
            GeneralContributions generalcontrib = _mapper.Map<GeneralContributionDto, GeneralContributions>(generalcontribDto);
            if (generalcontrib.IdContribution > 0)
            {
                _db.GeneralContributions.Update(generalcontrib);
            }
            else
            {
                await _db.GeneralContributions.AddAsync(generalcontrib);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<GeneralContributions, GeneralContributionDto>(generalcontrib);
        }

        public async Task<bool> DeleteGeneralContribution(int id)
        {
            try
            {
                GeneralContributions generalcontrib = await _db.GeneralContributions.FindAsync(id);
                if (generalcontrib == null)
                {
                    return false;
                }
                _db.GeneralContributions.Remove(generalcontrib);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<GeneralContributionDto> GetGeneralContributionById(int id)
        {
            GeneralContributions member = await _db.GeneralContributions.FindAsync(id);
            return _mapper.Map<GeneralContributionDto>(member);
        }

        public async Task<List<GeneralContributionDto>> GetGeneralContributions()
        {
            List<GeneralContributions> lista = await _db.GeneralContributions.ToListAsync();

            return _mapper.Map<List<GeneralContributionDto>>(lista);
        }

    }
}

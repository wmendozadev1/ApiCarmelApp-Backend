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
    public class PersonalContributionRepository : IPersonalContributionRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public PersonalContributionRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<PersonalContributionDto> CreateUpdate(PersonalContributionDto personalcontribDto)
        {
            PersonalContributions personalcontrib = _mapper.Map<PersonalContributionDto, PersonalContributions>(personalcontribDto);
            if (personalcontrib.IdContribution > 0)
            {
                _db.PersonalContributions.Update(personalcontrib);
            }
            else
            {
                await _db.PersonalContributions.AddAsync(personalcontrib);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<PersonalContributions, PersonalContributionDto>(personalcontrib);
        }

        public async Task<bool> DeletePersonalContribution(int id)
        {
            try
            {
                PersonalContributions personalcontrib = await _db.PersonalContributions.FindAsync(id);
                if (personalcontrib == null)
                {
                    return false;
                }
                _db.PersonalContributions.Remove(personalcontrib);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<PersonalContributionDto> GetPersonalContributionById(int id)
        {
            PersonalContributions personalcontrib = await _db.PersonalContributions.FindAsync(id);
            return _mapper.Map<PersonalContributionDto>(personalcontrib);
        }

        public async Task<List<PersonalContributionDto>> GetPersonalContributions()
        {
            List<PersonalContributions> lista = await _db.PersonalContributions.ToListAsync();

            return _mapper.Map<List<PersonalContributionDto>>(lista);
        }

    }
}

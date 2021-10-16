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
    public class VacancieRepository : IVacancieRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public VacancieRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<VacancieDto> CreateUpdate(VacancieDto vacancieDto)
        {
            Vacancies vacancie = _mapper.Map<VacancieDto, Vacancies>(vacancieDto);
            if (vacancie.IdVacancie > 0)
            {
                _db.Vacancies.Update(vacancie);
            }
            else
            {
                await _db.Vacancies.AddAsync(vacancie);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Vacancies, VacancieDto>(vacancie);
        }

        public async Task<bool> DeleteVacancie(int id)
        {
            try
            {
                Vacancies vacancie = await _db.Vacancies.FindAsync(id);
                if (vacancie == null)
                {
                    return false;
                }
                _db.Vacancies.Remove(vacancie);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<VacancieDto> GetVacancieById(int id)
        {
            Vacancies member = await _db.Vacancies.FindAsync(id);
            return _mapper.Map<VacancieDto>(member);
        }

        public async Task<List<VacancieDto>> GetVacancies()
        {
            List<Vacancies> lista = await _db.Vacancies.ToListAsync();

            return _mapper.Map<List<VacancieDto>>(lista);
        }
    }
}

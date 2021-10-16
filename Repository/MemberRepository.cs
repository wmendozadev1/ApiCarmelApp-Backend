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
    public class MemberRepository : IMemberRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public MemberRepository(ApplicationDbContext db,IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<MemberDto> CreateUpdate(MemberDto memberDto)
        {
            Members member = _mapper.Map<MemberDto,Members>(memberDto);
            if (member.IdMember>0)
            {
                _db.Members.Update(member);
            }
            else
            {
                await _db.Members.AddAsync(member);
            }
            await _db.SaveChangesAsync();
            return _mapper.Map<Members,MemberDto>(member);
        }

        public async Task<bool> DeleteMember(int id)
        {
            try
            {
                Members member = await _db.Members.FindAsync(id);
                if (member==null)
                {
                    return false;
                }
                _db.Members.Remove(member);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<MemberDto> GetMemberById(int id)
        {
            Members member = await _db.Members.FindAsync(id);
            return _mapper.Map<MemberDto>(member);
        }

        public async Task<List<MemberDto>> GetMembers()
        {
            List<Members> lista = await _db.Members.ToListAsync();
            
            return _mapper.Map<List<MemberDto>>(lista);
        }
    }
}

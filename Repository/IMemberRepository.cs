using APICarmel.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Repository
{
    public interface IMemberRepository
    {
        Task<List<MemberDto>> GetMembers();
        Task<MemberDto> GetMemberById(int id);
        Task<MemberDto> CreateUpdate(MemberDto memberDto);
        Task<bool> DeleteMember(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APICarmel.Data;
using APICarmel.Models;
using APICarmel.Repository;
using APICarmel.Models.Dto;

namespace APICarmel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembersController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IMemberRepository _memberRepository;
        protected ResponseDto _response;

        //public MembersController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public MembersController(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
            _response = new ResponseDto();
        }

        // GET: api/Members
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Members>>> GetMembers()
        {
            try
            {
                var lista = await _memberRepository.GetMembers();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Miembros";
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString()};
            }
            return Ok(_response);
            //return await _context.Members.ToListAsync();
        }

        // GET: api/Members/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Members>> GetMembers(int id)
        {
            var member = await _memberRepository.GetMemberById(id);

            if (member == null)
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "Miembro no existe";
                return NotFound(_response);
            }
            _response.Result = member;
            _response.DisplayMessage = "Informacion del miembro";

            return Ok(_response);
        }

        // PUT: api/Members/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMembers(int id, MemberDto memberDto)
        {
            try
            {
                MemberDto model = await _memberRepository.CreateUpdate(memberDto);
                _response.Result = model;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "Error al actualizar el registro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // POST: api/Members
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Members>> PostMembers(MemberDto memberDto)
        {

            try
            {
                MemberDto model = await _memberRepository.CreateUpdate(memberDto);
                _response.Result = model;
                return CreatedAtAction("GetMember", new { id = model.IdMember }, _response);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "Error al grabar el registro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }


        // DELETE: api/Members/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMembers(int id)
        {
            try
            {
                bool isDelete = await _memberRepository.DeleteMember(id);
                if (isDelete)
                {
                    _response.Result = isDelete;
                    _response.DisplayMessage = "Miembro eliminado con exito";
                    return Ok(_response);
                }
                else
                {
                    _response.isSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el miembro";
                    return BadRequest(_response);
                }
            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            return BadRequest(_response);
            }
        }
    

        //private bool MembersExists(int id)
        //{
        //    return _context.Members.Any(e => e.IdMember == id);
        //}
    }
}

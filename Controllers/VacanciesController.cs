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
using Microsoft.AspNetCore.Authorization;

namespace APICarmel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacanciesController : ControllerBase
    {
        //private readonly ApplicationDbContext _context;
        private readonly IVacancieRepository _vacancieRepository;
        protected ResponseDto _response;

        //public VacanciesController(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        public VacanciesController(IVacancieRepository vacancieRepository)
        {
            _vacancieRepository = vacancieRepository;
            _response = new ResponseDto();
        }

        // GET: api/Vacancies
        [HttpGet]
        [Authorize]
        public async Task<ActionResult<IEnumerable<Vacancies>>> GetVacancies()
        {
            try
            {
                var lista = await _vacancieRepository.GetVacancies();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Servicios AA";
            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/Vacancies/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vacancies>> GetVacancies(int id)
        {
            var vacancie = await _vacancieRepository.GetVacancieById(id);

            if (vacancie == null)
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "El servicio no existe";
                return NotFound(_response);
            }
            _response.Result = vacancie;
            _response.DisplayMessage = "Información del servicio";

            return Ok(_response);
        }

        // PUT: api/Vacancies/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVacancies(int id, VacancieDto vacanciedto)
        {
            try
            {
                VacancieDto model = await _vacancieRepository.CreateUpdate(vacanciedto);
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

        // POST: api/Vacancies
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vacancies>> PostVacancies(VacancieDto vacanciedto)
        {
            try
            {
                VacancieDto model = await _vacancieRepository.CreateUpdate(vacanciedto);
                _response.Result = model;
                return CreatedAtAction("GetVacancies", new { id = model.IdVacancie }, _response);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "Error al grabar el registro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
        }

        // DELETE: api/Vacancies/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVacancies(int id)
        {
            try
            {
                bool isDelete = await _vacancieRepository.DeleteVacancie(id);
                if (isDelete)
                {
                    _response.Result = isDelete;
                    _response.DisplayMessage = "Servicio eliminado con éxito";
                    return Ok(_response);
                }
                else
                {
                    _response.isSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el servicio";
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

        //private bool VacanciesExists(int id)
        //{
        //    return _context.Vacancies.Any(e => e.IdVacancie == id);
        //}
    }
}

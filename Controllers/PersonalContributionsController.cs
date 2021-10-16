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
    public class PersonalContributionsController : ControllerBase
    {
        private readonly IPersonalContributionRepository _personalContributionRepository;
        protected ResponseDto _response;

        public PersonalContributionsController(IPersonalContributionRepository personalContributionRepository)
        {
            _personalContributionRepository = personalContributionRepository;
            _response = new ResponseDto();
        }

        // GET: api/PersonalContributions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonalContributions>>> GetPersonalContributions() 
        {
            try
            {
                var lista = await _personalContributionRepository.GetPersonalContributions();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Contribuciones personales";
            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/PersonalContributions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonalContributions>> GetPersonalContributions(int id)
        {
            var personalContrib = await _personalContributionRepository.GetPersonalContributionById(id);

            if (personalContrib == null)
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "La contribución personal no existe";
                return NotFound(_response);
            }
            _response.Result = personalContrib;
            _response.DisplayMessage = "Información de contribución personal";

            return Ok(_response);
        }

        // PUT: api/PersonalContributions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonalContributions(int id, PersonalContributionDto personalContributionDto)
        {
            try
            {
                PersonalContributionDto model = await _personalContributionRepository.CreateUpdate(personalContributionDto);
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

        // POST: api/PersonalContributions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonalContributions>> PostPersonalContributions(PersonalContributionDto personalContributiondto)
        {
            try
            {
                PersonalContributionDto model = await _personalContributionRepository.CreateUpdate(personalContributiondto);
                _response.Result = model;
                return CreatedAtAction("GetPersonalContributions", new { id = model.IdContribution }, _response);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "Error al grabar el registro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }
            //return CreatedAtAction("GetPersonalContributions", new { id = personalContributions.IdContribution }, personalContributions);
        }

        // DELETE: api/PersonalContributions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonalContributions(int id)
        {
            try
            {
                bool isDelete = await _personalContributionRepository.DeletePersonalContribution(id);
                if (isDelete)
                {
                    _response.Result = isDelete;
                    _response.DisplayMessage = "Contribución personal eliminado con éxito";
                    return Ok(_response);
                }
                else
                {
                    _response.isSuccess = false;
                    _response.DisplayMessage = "Error al eliminar la contribución personal";
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

        //private bool PersonalContributionsExists(int id)
        //{
        //    return _context.PersonalContributions.Any(e => e.IdContribution == id);
        //}
    }
}

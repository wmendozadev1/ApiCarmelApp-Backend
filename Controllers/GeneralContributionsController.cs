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
    public class GeneralContributionsController : ControllerBase
    {
        private readonly IGeneralContributionRepository _generalcontribRepository;
        protected ResponseDto _response;

        public GeneralContributionsController(IGeneralContributionRepository generalcontribRepository)
        {
            _generalcontribRepository = generalcontribRepository;
            _response = new ResponseDto();
        }


        // GET: api/GeneralContributions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeneralContributions>>> GetGeneralContributions()
        {
            try
            {
                var lista = await _generalcontribRepository.GetGeneralContributions();
                _response.Result = lista;
                _response.DisplayMessage = "Lista de Contribuciones generales";
            }
            catch (Exception ex)
            {

                _response.isSuccess = false;
                _response.ErrorMessages = new List<string> { ex.ToString() };
            }
            return Ok(_response);
        }

        // GET: api/GeneralContributions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GeneralContributions>> GetGeneralContributions(int id)
        {
            var generalcontrib = await _generalcontribRepository.GetGeneralContributionById(id);

            if (generalcontrib == null)
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "La contribución general no existe";
                return NotFound(_response);
            }
            _response.Result = generalcontrib;
            _response.DisplayMessage = "Información de contribución general";

            return Ok(_response);
        }

        // PUT: api/GeneralContributions/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGeneralContributions(int id, GeneralContributionDto generalContributiondto)
        {
            try
            {
                GeneralContributionDto model = await _generalcontribRepository.CreateUpdate(generalContributiondto);
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

        // POST: api/GeneralContributions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GeneralContributions>> PostGeneralContributions(GeneralContributionDto generalContributiondto)
        {
            try
            {
                GeneralContributionDto model = await _generalcontribRepository.CreateUpdate(generalContributiondto);
                _response.Result = model;
                return CreatedAtAction("GetGeneralContributions", new { id = model.IdContribution }, _response);
            }
            catch (Exception ex)
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "Error al grabar el registro";
                _response.ErrorMessages = new List<string> { ex.ToString() };
                return BadRequest(_response);
            }

            //return CreatedAtAction("GetGeneralContributions", new { id = generalContributions.IdContribution }, generalContributions);
        }

        // DELETE: api/GeneralContributions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGeneralContributions(int id)
        {
            try
            {
                bool isDelete = await _generalcontribRepository.DeleteGeneralContribution(id);
                if (isDelete)
                {
                    _response.Result = isDelete;
                    _response.DisplayMessage = "Contribución general eliminada con éxito";
                    return Ok(_response);
                }
                else
                {
                    _response.isSuccess = false;
                    _response.DisplayMessage = "Error al eliminar el Contribución general";
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

        //private bool GeneralContributionsExists(int id)
        //{
        //    return _context.GeneralContributions.Any(e => e.IdContribution == id);
        //}
    }
}

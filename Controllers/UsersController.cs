using APICarmel.Models;
using APICarmel.Models.Dto;
using APICarmel.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICarmel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserRepository _userRepository;
        protected ResponseDto _response;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _response = new ResponseDto();
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register(UserDto userDto)
        {
            var res = await _userRepository.Register(
                new User
                {
                    UserName = userDto.UserName
                }, userDto.Password);

            if (res == "existe")
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "Usuario ya existe";
                return BadRequest(_response);
            }

            if (res == "error")
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "Error al crear usuario";
                return BadRequest(_response);
            }
            _response.DisplayMessage = "Usuario creado con exito";
            //_response.Result = res;
            JwTPackage jtp = new JwTPackage();
            jtp.UserName = userDto.UserName;
            jtp.Token = res;
            _response.Result = jtp;

            return Ok(_response);

        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(UserDto user)
        {
            var respuesta = await _userRepository.Login(user.UserName, user.Password);
            if (respuesta == "nouser")
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "Usuario no existe";
                return BadRequest(_response);
            }
            if (respuesta == "wrongpassword")
            {
                _response.isSuccess = false;
                _response.DisplayMessage = "Password incorrecta";
                return BadRequest(_response);
            }

            //_response.Result = respuesta;

            JwTPackage jtp = new JwTPackage();
            jtp.UserName = user.UserName;
            jtp.Token = respuesta;
            _response.Result = jtp;
            _response.DisplayMessage = "Usuario conectado";

            return Ok(_response);

        }


    }

    public class JwTPackage
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }


}

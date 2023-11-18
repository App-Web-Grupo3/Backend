using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Data.Model;
using Domain.Service.Impl;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UniqueTrip.Request;

namespace UniqueTrip.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserDomain _userDomain;
        private IMapper _mapper;
        public UserController(IUserDomain userDomain,IMapper mapper)
        {
            _userDomain = userDomain;
            _mapper = mapper;
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] UserLoginRequest userInput)
        {
            try
            {
                var user = _mapper.Map<UserLoginRequest, UserBase>(userInput);

                var jwt = await _userDomain.Login(user);

                return Ok(jwt);
            }
            catch (Exception ex)
            {
                throw;
                return StatusCode(StatusCodes.Status500InternalServerError, "Error al procesar");
            }
        }


        // POST: api/User
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequest userInput)
        {
            
            var user = _mapper.Map<UserRegisterRequest, UserBase>(userInput);
            var id = await _userDomain.Register(user);
            
            if (id > 0)
                return Ok(id.ToString());
            else
                return BadRequest();
        }
    }
}

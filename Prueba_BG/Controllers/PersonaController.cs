using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Prueba_BG.Interfaces;
using Prueba_BG.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba_BG.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonaController : Controller
    {
        private readonly PersonaInterface _personaInterface;
        private readonly IConfiguration _configuration;
        public PersonaController(PersonaInterface personaInterface, IConfiguration configuration)
        {
            this._personaInterface = personaInterface;
            this._configuration = configuration;
        }

        [HttpGet("Get_person_list")]
        public async Task<IActionResult> Get_person_list([FromQuery] PersonaQuery parameter)
        {
            try
            {
                var change = _configuration.GetSection("ConnectionStrings").GetSection("Conexion").Value;

                return Ok(await _personaInterface.Get_person_list(change, parameter));
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("Post_person")]
        public async Task<IActionResult> Post_person([FromBody] PersonaModel parameter)
        {
            try
            {
                var change = _configuration.GetSection("ConnectionStrings").GetSection("Conexion").Value;

                return Ok(await _personaInterface.Post_person(change, parameter));
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

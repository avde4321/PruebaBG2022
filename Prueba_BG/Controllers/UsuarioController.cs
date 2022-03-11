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
    public class UsuarioController : Controller
    {
        private readonly UsurInterface _usurInterface;
        private readonly IConfiguration _configuration;
        public UsuarioController(UsurInterface usurInterface, IConfiguration configuration)
        {
            this._usurInterface = usurInterface;
            this._configuration = configuration;
        }
        [HttpGet("Get_user_list")]
        public async Task<IActionResult> Get_user_list([FromQuery] UserQuery parameter)
        {
            try
            {
                var change = _configuration.GetSection("ConnectionStrings").GetSection("Conexion").Value;
                return Ok(await _usurInterface.Get_user_list(change, parameter));
            }
            catch (Exception)
            {
                throw;
            }
            
        }
        [HttpPost("Post_usuario")]
        public async Task<IActionResult> Post_usuario([FromBody] UserModel parameter)
        {
            try
            {
                var change = _configuration.GetSection("ConnectionStrings").GetSection("Conexion").Value;
                return Ok(await _usurInterface.Post_usuario(change, parameter));
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}

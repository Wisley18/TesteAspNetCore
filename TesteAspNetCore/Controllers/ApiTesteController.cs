using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteCoreDF.Models;

namespace TesteAspNetCore.Controllers
{
    [Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class ApiTesteController : ControllerBase
    {
        public readonly AcademicoContext _contexto;

        public ApiTesteController(AcademicoContext academicoContexto)
        {
            _contexto = academicoContexto;
        }

        [HttpGet]
        public async Task<IActionResult> Teste()
        {
            try
            {
                var questoes = await _contexto.Questao.FirstOrDefaultAsync();
                return Ok(questoes);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            
        }
    }
}
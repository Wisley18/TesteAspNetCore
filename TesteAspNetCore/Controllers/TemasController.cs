using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteCoreCF.Models;
using TesteCoreCF.Models.Entities;
using TesteCoreCF.Repositories.Source;

namespace TesteAspNetCore.Controllers
{
    //[Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class TemasController : ControllerBase
    {

        private readonly Academico academico;


        public TemasController(Academico a)
        {
            academico = a;
        }

        /// <summary>
        /// Obtem todos os temas
        /// </summary>
        /// <returns>Lista de objetos TemaDto</returns>
        [HttpGet]
        [Route("", Name = "ObterTema")]
        public async Task<IActionResult> Obter()
        {
            try
            {
                var temas = await academico.ObterTema();
                var res = temas.Select(t => new TemaDto(t));
                return Ok(res);
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> CriarTema(Tema tema)
        {
            try
            {
                var _tema = await academico.CriarTema(tema);

                var res = new TemaDto(_tema);

                return Created(new Uri(Url.Link("ObterTema", null)), res);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }

        }
    }

    public class QuestaoDto
    {
        public long id;
        public string texto;

        public QuestaoDto(Questao questao)
        {
            id = questao.Id;
            texto = questao.Texto;
        }
    }

    public class TemaDto
    {
        public long id;
        public string nome;
        public string descricao;

        public TemaDto(Tema tema)
        {
            id = tema.Id;
            nome = tema.Nome;
            descricao = tema.Descricao;
        }
    }
}
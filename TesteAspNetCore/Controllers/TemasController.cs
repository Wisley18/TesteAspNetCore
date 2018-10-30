using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TesteCoreDF.Models;
using TesteCoreDF.Repositories.Source;

namespace TesteAspNetCore.Controllers
{
    //[Produces("application/json")]
    [Route("api/[Controller]")]
    [ApiController]
    public class TemasController : ControllerBase
    {

        //private readonly AbstractCoreRepository CoreRepository;

        //public TemasController(AbstractCoreRepository cr)
        //{
        //    CoreRepository = cr;
        //}

        //[HttpGet]
        //public async Task<IActionResult> Teste()
        //{
        //    try
        //    {
        //        var service = new Questao(CoreRepository);
        //        var questoes = await service.ObterTodas(0, 2);
        //        var res = questoes.Item1.Select(q => new QuestaoDto(q));
        //        return Ok(res);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
            
        //}

        //[HttpPost]
        //[Route("")]
        //public async Task<IActionResult> CriarTema(Tema tema)
        //{
        //    try
        //    {
        //        var _tema = await new Academico(CoreRepository).CriarTema(tema);

        //        var res = new TemaDto(_tema);

        //        return Created(new Uri(Url.Link("teste", null)), res);
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
            
        //}
    }

    //public class QuestaoDto
    //{
    //    public long id;
    //    public string texto;

    //    public QuestaoDto(Questao questao)
    //    {
    //        id = questao.Id;
    //        texto = questao.Texto;
    //    }
    //}

    //public class TemaDto
    //{
    //    public long id;
    //    public string nome;
    //    public string descricao;

    //    public TemaDto(Tema tema)
    //    {
    //        id = tema.Id;
    //        nome = tema.Nome;
    //        descricao = tema.Descricao;
    //    }
    //}
}
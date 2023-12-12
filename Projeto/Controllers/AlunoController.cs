using Microsoft.AspNetCore.Mvc;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Controllers;

[ApiController]
[Route("api/aluno")]
public class AlunoController : ControllerBase
{
    private readonly AppDataContext _ctx;
    public AlunoController (AppDataContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<Aluno> alunos = _ctx.Alunos.ToList();
            return Ok(alunos);

        }catch(Exception e){
            return BadRequest(e.Message);
        }
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] Aluno aluno)
    {
        try
        {
            _ctx.Alunos.Add(aluno);
            _ctx.SaveChanges();
            return Created("", aluno);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);
        }

    }

}

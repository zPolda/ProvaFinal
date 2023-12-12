using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto.Data;
using Projeto.Models;

namespace Projeto.Controllers;

[ApiController]
[Route("api/imc")]
public class ImcController : ControllerBase
{
     private readonly AppDataContext _ctx;
    public ImcController (AppDataContext ctx)
    {
        _ctx = ctx;
    }

    [HttpGet]
    [Route("listar")]
    public IActionResult Listar()
    {
        try
        {
            List<IMC> imcs =
            _ctx.IMCs
            .Include(x => x.Aluno)
            .ToList();
            return imcs.Count == 0 ? NotFound() : Ok(imcs);
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
        
    }
    [HttpPost]
    [Route("cadastrar")]
    public IActionResult Cadastrar([FromBody] IMC imc)
    {
        try
        {
            Aluno? aluno =
            _ctx.Alunos.Find(imc.AlunoId);
            if(aluno == null){
                return NotFound();
            }
            imc.Aluno = aluno;
            _ctx.IMCs.Add(imc);
            _ctx.SaveChanges();
            return Created("", imc);
        }
        catch(Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(e.Message);

        }
    }
    [HttpGet]
    [Route("buscar/{id}")]
    public IActionResult Buscar([FromRoute] int id)
    {
        try
        {
            IMC? imcCadastrado = 
            _ctx.IMCs
            .Include(x => x.Aluno)
            .FirstOrDefault(x => x.ImcId == id);
            if(imcCadastrado != null){
                return Ok(imcCadastrado);
            }
            return NotFound();
        }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

    [HttpPut]
    [Route("alterar/{id}")]
    public IActionResult Alterar([FromRoute] int id, [FromBody] IMC imc)
    {
        try
        {
            IMC? imcCadastrado =
                _ctx.IMCs.FirstOrDefault(x => x.ImcId == id);

                if(imcCadastrado != null)
                {
                    Aluno? aluno = 
                    _ctx.Alunos.Find(imc.AlunoId);

                    if(aluno == null)
                    {
                        return NotFound();
                    }
                    imcCadastrado.Aluno = aluno;
                    imcCadastrado.Peso = imc.Peso;
                    imcCadastrado.Altura = imc.Altura;
                    _ctx.IMCs.Update(imcCadastrado);
                    _ctx.SaveChanges();

                    return Ok();
                }
                return NotFound();
            }
        catch(Exception e)
        {
            return BadRequest(e.Message);
        }
    }

}

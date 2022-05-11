using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Entities;
using WebApiCursoMed.Interfaces;
using WebApiCursoMed.Models;

namespace WebApiCursoMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunosController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(AlunoPostModel model,
            [FromServices] IAlunoRepository alunoRepository)
        {
            try
            {

                if (alunoRepository.ObterPorMatricula(model.Matricula) != null)
                {
                    return UnprocessableEntity("A matricula informada já encontra-se cadastrada.");
                }
                else
                {
                    var aluno = new Aluno();

                    aluno.IdAluno = Guid.NewGuid();
                    aluno.Nome = model.Nome;
                    aluno.Matricula = model.Matricula;

                    alunoRepository.Inserir(aluno);

                    return Ok("Aluno cadastrado com sucesso!");
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(AlunoPutModel model,
            [FromServices] IAlunoRepository alunoRepository)
        {
            try
            {
                var aluno = alunoRepository.ObterPorId(model.IdAluno);

                if (aluno != null)
                {
                    aluno.Nome = model.Nome;
                    aluno.Matricula = model.Matricula;
                    

                    alunoRepository.Alterar(aluno);

                    return Ok("Aluno atualizado com sucesso!");
                }
                else
                {
                    return UnprocessableEntity("Aluno não encontrado.");
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idAluno}")]
        public IActionResult Delete(Guid idAluno,
            [FromServices] IAlunoRepository alunoRepository)
        {
            try
            {
                var aluno = alunoRepository.ObterPorId(idAluno);

                if (aluno != null)
                {                    

                    alunoRepository.Excluir(aluno);

                    return Ok("Aluno exculido com sucesso!");
                }
                else
                {
                    return UnprocessableEntity("Aluno não encontrado.");
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] IAlunoRepository alunoRepository)
        {
            try
            {
                var lista = new List<AlunoGetModel>();

                foreach (var item in alunoRepository.Consultar())
                {
                    var model = new AlunoGetModel();

                    model.IdAluno = item.IdAluno;
                    model.Nome = item.Nome;
                    model.Matricula = item.Matricula;

                    lista.Add(model);

                }                  

                    return Ok(lista);
                
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }

        }

        [HttpGet("{idAluno}")]
        public IActionResult GetById(Guid idAluno,[FromServices] IAlunoRepository alunoRepository)
        {
            try
            {
                var aluno = alunoRepository.ObterPorId(idAluno);

                if (aluno != null)
                {
                    var model = new AlunoGetModel();

                    model.IdAluno = aluno.IdAluno;
                    model.Nome = aluno.Nome;
                    model.Matricula = aluno.Matricula;

                    return Ok(model);
                }
                else
                {
                    return NoContent();
                }                

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}

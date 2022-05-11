using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Entities;
using WebApiCursoMed.Interfaces;
using WebApiCursoMed.Models;
using WebApiCursoMed.Models.TurmaMateria;

namespace WebApiCursoMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmasController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(TurmaMateriaPostModel model,
            [FromServices] ITurmaRepository turmaRepository,
            [FromServices] ITurmaMateriaRepository turmaMateriaRepository)
        {
            try
            {
                var turmaPorNome = turmaRepository.ObterPorNome(model.Nome);

                var turmaMateriaPorId = new TurmaMateria();
                var existeMateriaTurma = new TurmaMateria();

                if (turmaPorNome != null)
                {
                    turmaMateriaPorId = turmaMateriaRepository.ObterPorIdTurma(turmaPorNome.IdTurma)
                        .Where(x => x.IdMateria == model.IdMateria).FirstOrDefault();
                }          

                if (!String.IsNullOrEmpty(turmaMateriaPorId.IdTurmaMateria.ToString()))
                {
                    return UnprocessableEntity("Turma já cadastrada com a matéria informada.");
                }

                var turma = new Turma();
                var turmaMateria = new TurmaMateria();

                if (turmaPorNome == null)
                {
                    turma.IdTurma = Guid.NewGuid();
                    turma.Nome = model.Nome;

                    turmaRepository.Inserir(turma);

                    turmaMateria.IdMateria = model.IdMateria;
                    turmaMateria.IdTurma = turma.IdTurma;
                    turmaMateria.IdTurmaMateria = Guid.NewGuid();

                    turmaMateriaRepository.Inserir(turmaMateria);
                }
                else
                {
                    turmaMateria.IdMateria = model.IdMateria;
                    turmaMateria.IdTurma = turmaPorNome.IdTurma;
                    turmaMateria.IdTurmaMateria = Guid.NewGuid();

                    turmaMateriaRepository.Inserir(turmaMateria);
                }

                return Ok("Turma cadastrada com sucesso!");
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(TurmaPutModel model,
            [FromServices] ITurmaRepository turmaRepository)

        {
            try
            {
                var turma = turmaRepository.ObterPorId(model.IdTurma);
               

                if (turma != null)
                {                   

                    turma.Nome = model.Nome;

                    turmaRepository.Alterar(turma);

                    return Ok("Turma atualizada com sucesso!");

                }
                else
                {
                    return UnprocessableEntity("Turma não encontrada.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idTurma}")]
        public IActionResult Delete(Guid idTurma,
            [FromServices] ITurmaRepository turmaRepository, [FromServices] IAlunoTurmaMateriaRepository alunoTurmaMateriaRepository)
        {

            try
            {
                var turma = turmaRepository.ObterPorId(idTurma);

                if (turma != null)
                {
                    var alunoTurmaMateria = alunoTurmaMateriaRepository.ObterPorIdTurma(turma.IdTurma);

                    if (alunoTurmaMateria.Count > 0)
                    {
                        return UnprocessableEntity("Não é possível excluir a turma, pois existe aluno cadastrado.");
                    }

                    turmaRepository.Excluir(turma);

                    return Ok("Turma Excluida com sucesso!");
                }
                else
                {
                    return UnprocessableEntity("Turma não encontrada.");
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] ITurmaRepository turmaRepository)
        {
            try
            {
                var lista = new List<TurmaGetModel>();

                foreach (var item in turmaRepository.Consultar()) 
                {
                    var model = new TurmaGetModel();

                    model.IdTurma = item.IdTurma;
                    model.Nome = item.Nome;

                    lista.Add(model);
                }

                return Ok(lista);

            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{idTurma}")]
        public IActionResult GetById(Guid idTurma, [FromServices] ITurmaRepository turmaRepository)
        {
            try
            {
                var turma = turmaRepository.ObterPorId(idTurma);

                if (turma != null)
                {
                    var model = new TurmaGetModel();

                    model.IdTurma = turma.IdTurma;
                    model.Nome = turma.Nome;

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

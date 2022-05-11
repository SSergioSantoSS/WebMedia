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
    public class MateriasController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(MateriaPostModel model,
            [FromServices] IMateriaRepository materiaRepository)
        {
            try
            {

                if (materiaRepository.ObterPorNome(model.Nome) != null)
                {
                    return UnprocessableEntity("A Matéria informada já encontra-se cadastrada.");
                }
                else
                {
                    var materia = new Materia();

                    materia.IdMateria = Guid.NewGuid();
                    materia.Nome = model.Nome;


                    materiaRepository.Inserir(materia);

                    return Ok("Materia cadastrada com sucesso!");
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(MateriaPutModel model,
            [FromServices] IMateriaRepository materiaRepository)
        {
            try
            {
                var materia = materiaRepository.ObterPorId(model.IdMateria);

                if (materia != null)
                {
                    materia.Nome = model.Nome;


                    materiaRepository.Alterar(materia);

                    return Ok("Matéria atualizado com sucesso!");
                }
                else
                {
                    return UnprocessableEntity("Matéria não encontrada.");
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{idMateria}")]
        public IActionResult Delete(Guid idMateria,
            [FromServices] IMateriaRepository materiaRepository, 
            [FromServices] IAlunoTurmaMateriaRepository alunoTurmaMateriaRepository)
        {
            try
            {
                var materia = materiaRepository.ObterPorId(idMateria);

                if (materia != null)
                {
                    var alunoTurmaMateria = alunoTurmaMateriaRepository.ObterPorIdMateria(materia.IdMateria);

                    if (alunoTurmaMateria != null)
                    {
                        return UnprocessableEntity("Matéria não encontrada.");
                    }

                    materiaRepository.Excluir(materia);

                    return Ok("Matéria exculido com sucesso!");
                }
                else
                {
                    return UnprocessableEntity("Matéria não encontrada.");
                }
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetAll([FromServices] IMateriaRepository materiaRepository)
        {
            try
            {
                var lista = new List<MateriaGetModel>();

                foreach (var item in materiaRepository.Consultar())
                {
                    var model = new MateriaGetModel();

                    model.IdMateria = item.IdMateria;
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

        [HttpGet("{idMateria}")]
        public IActionResult GetById(Guid idmateria, [FromServices] IMateriaRepository materiaRepository)
        {
            try
            {
                var materia = materiaRepository.ObterPorId(idmateria);

                if (materia != null)
                {
                    var model = new MateriaGetModel();

                    model.IdMateria = materia.IdMateria;
                    model.Nome = materia.Nome;
                    

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

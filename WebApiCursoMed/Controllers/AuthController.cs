using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Interfaces;
using WebApiCursoMed.Models;
using WebApiCursoMed.Models.Auth;
using WebApiCursoMed.Security;

namespace WebApiCursoMed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(AuthPostModel model,
            [FromServices] IAlunoRepository alunoRepository,
            [FromServices] TokenService tokenService)
        {
            try
            {
                //buscar o aluno na base atraves do email e da senha..
                var aluno = alunoRepository

                .ObterPorEmailESenha(model.Email, model.Senha);

                //verificar se o aluno foi encontrado..
                if (aluno != null)
                {
                    //tempo de expiração do token em horas
                    var tempoExpiracaoToken = 24; //1 dia

                    //objeto para retornar os dados de resposta
                    //de sucesso do método..
                    var result = new

                    {
                        Mensagem = "Autenticação realizada com sucesso.",
                        AccessToken = tokenService.GenerateToken(aluno.Email, tempoExpiracaoToken),
                        ExpiraEm = DateTime.Now.AddHours(tempoExpiracaoToken),

                        Aluno = new AlunoGetModel

                        {
                            IdAluno = aluno.IdAluno,

                            Nome = aluno.Nome,
                            Email = aluno.Email,
                           

                        }
                    };
                    return Ok(result);
                }
                else
                {
                    //UNAUTHORIZED (HTTP 401)
                    return Unauthorized("Acesso negado.");

                }
            }
            catch (Exception e)
            {
                //INTERNAL SERVER ERROR (HTTP 500)
                return StatusCode(500, e.Message);
            }
        }
    }
}

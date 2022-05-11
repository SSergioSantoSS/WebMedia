using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Contexts;
using WebApiCursoMed.Entities;
using WebApiCursoMed.Interfaces;

namespace WebApiCursoMed.Repositories
{
    public class AlunoRepository : BaseRepository<Aluno>, IAlunoRepository
    {
        private readonly SqlServerContext _context;

        public AlunoRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public Aluno ObterPorMatricula(string matricula)
        {
            return _context.Aluno.FirstOrDefault(a => a.Matricula.Equals(matricula));
        }

        public Aluno ObterPorEmailESenha(string email, string senha)
        {
            return _context.Aluno.FirstOrDefault(a => a.Email.Equals(email) && a.Senha.Equals(senha));
        }
    }
}

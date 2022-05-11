using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Contexts;
using WebApiCursoMed.Interfaces;
using WebApiCursoMed.Repositories;
using WebApiCursoMed.Repositoriesi;

namespace WebApiCursoMed.Configurations
{
    public class RepositoryConfiguration
    {
        public static void Configure(IServiceCollection services, IConfiguration Configuration)
        {
            #region Repositórios

            //obtendo a string de conexão do banco de dados..
            var connectionstring = Configuration
            .GetConnectionString("WebMediaDB");
            //passar a connectionstring para
            //a classe SqlServerContext criada para o EF
            services.AddDbContext<SqlServerContext>
            (options => options.UseSqlServer(connectionstring));

            services.AddTransient<IAlunoRepository, AlunoRepository>();
            services.AddTransient<ITurmaRepository, TurmaRepository>();
            services.AddTransient<IMateriaRepository, MateriaRepository>();
            services.AddTransient<IProvaRepository, ProvaRepository>();
            services.AddTransient<ITurmaMateriaRepository, TurmaMateriaRepository>();
           


            #endregion
        }
    }
}

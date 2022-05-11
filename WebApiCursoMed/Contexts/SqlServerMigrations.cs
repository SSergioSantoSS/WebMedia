using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Contexts
{
    public class SqlServerMigrations : IDesignTimeDbContextFactory<SqlServerContext>
    {
        public SqlServerContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder();
            var path = Path.Combine(Directory.GetCurrentDirectory(),"appsettings.json");
            configurationBuilder.AddJsonFile(path, false);

            //ler a string de conexão contida no arquivo appsettings.json
            var root = configurationBuilder.Build();
            var connectionstrings = root.GetSection("ConnectionStrings").GetSection("WebCursoMed").Value;

            //gerar a conexão com o banco de dados para executar o Migrations
            var builder = new DbContextOptionsBuilder<SqlServerContext>();
            builder.UseSqlServer(connectionstrings);

            return new SqlServerContext(builder.Options);
        }
    }
}

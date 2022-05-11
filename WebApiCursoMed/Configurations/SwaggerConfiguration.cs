using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Configurations
{
    public class SwaggerConfiguration
    {
        public static void Configure(IServiceCollection services)
        {
            #region Swagger
            services.AddSwaggerGen(
                          swagger =>
                          {
                              swagger.SwaggerDoc("v1", new OpenApiInfo
                              {
                                  Title = "API - Curso (MÉDIA)",
                                  Description = "API REST desenvolvida em .NET CORE ",

                                  Version = "v1",
                                  Contact = new OpenApiContact
                                  {
                                      Name = "Sergio Santos",
                                      Url = new Uri("https://www.linkedin.com/in/ssergiosantoss/"),
                                      Email = "sergiomi87st@gmail.com"
                                  }
                              });
                          }
                          );

            #endregion
        }
    }
}

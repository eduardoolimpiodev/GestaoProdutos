using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using GP.WebApi.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GP.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<DataContext>(
                context => context.UseSqlite(Configuration.GetConnectionString("Default"))
            );

            services.AddControllers()
                    .AddNewtonsoftJson(opt => opt.SerializerSettings.ReferenceLoopHandling = 
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IRepository, Repository>();

            services.AddSwaggerGen( options => 
            {
                options.SwaggerDoc("gestaoprodutosapi", new Microsoft.OpenApi.Models.OpenApiInfo()
                {   
                    Title = "Gestão Produtos",
                    Version = "1.0",
                    TermsOfService = new Uri("https://www.eduardoolimpio.com"),
                    Description = "Descrição da WebAPI do Gestão Produtos",
                    License = new Microsoft.OpenApi.Models.OpenApiLicense
                    {
                        Name = "Gestão Produtos",
                        Url = new Uri("https://www.eduardoolimpio.com")
                    },

                    Contact = new Microsoft.OpenApi.Models.OpenApiContact
                    {
                        Name = "Eduardo Olimpio",
                        Email = "contact@eduardoolimpio.com",
                        Url = new Uri("https://www.eduardoolimpio.com")
                    }

                });

                var xmlComentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlComentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlComentsFile);

                options.IncludeXmlComments(xmlComentsFullPath);
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger()
                .UseSwaggerUI( options => {
                    options.SwaggerEndpoint("/swagger/gestaoprodutosapi/swagger.json", "gestaoprodutosapi");
                    options.RoutePrefix = "";
                });


            // teste branch1
            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Person.Business;
using Person.Business.Implementations;
using Person.Repository;
using Person.Model.Context;
using Serilog;
using System;
using System.Collections.Generic;
using Person.Repository.Generic;
using Microsoft.Net.Http.Headers;
using Person.Hypermedia.Filters;
using Person.Hypermedia.Enricher;
using Microsoft.AspNetCore.Rewrite;

namespace Calculadora
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();

            var connection = Configuration["MySQLConnection:MySQLConnectionString"];
            services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));


            var filterOptions = new HyperMediaFilterOptions();
            filterOptions.ContentResponseenricherList.Add(new PersonEnricher());
            filterOptions.ContentResponseenricherList.Add(new BookEnricher());

            // Versioning API
            services.AddApiVersioning();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Title = "REST API?s From 0 TO Azure with ASP.NET Core 5 and Docker",
                        Version = "v1",
                        Description = "API RESTful developed in course 'REST API?s From 0 TO Azure with ASP.NET Core 5 and Docker",
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact
                        {
                            Name = "Mois?s",
                            Url = new Uri("https://github.com/mpsnets")
                        }
                    });
            });

            // Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IBookBusiness, BookBusinessImplementation>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));

            services.AddMvc(option =>
            {
                option.RespectBrowserAcceptHeader = true;
                option.FormatterMappings.SetMediaTypeMappingForFormat("xml", MediaTypeHeaderValue.Parse("application/xml"));
                option.FormatterMappings.SetMediaTypeMappingForFormat("json", MediaTypeHeaderValue.Parse("application/json"));
            }).AddXmlSerializerFormatters();

            services.AddSingleton(filterOptions);

            if (Environment.IsDevelopment())
            {
                MigrateDatabase(connection);
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "REST API?s From 0 TO Azure with ASP.NET Core 5 and Docker - v1");
            });
            var option = new RewriteOptions();
            option.AddRedirect("^$", "swagger");
            app.UseRewriter(option);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapControllerRoute("DefaultApi", "{controller}/{id?}");
            });
        }
        private void MigrateDatabase(string connection)
        {
            try
            {
                var evolvConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var evolv = new Evolve.Evolve(evolvConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string>() {"db/migrations", "db/dataset" },
                    IsEraseDisabled = true,
                };
                evolv.Migrate();
                    
            }
            catch (Exception ex)
            {
                Log.Error("Migration database failed", ex);
                throw;
            }
        }
    }
}

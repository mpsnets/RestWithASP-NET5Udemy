using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Person.Business;
using Person.Business.Implementations;
using Person.Repository;
using Person.Repository.Implementations;
using Person.Model.Context;
using Serilog;
using System;
using System.Collections.Generic;

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

            // Versioning API
            services.AddApiVersioning();

            // Dependency Injection
            services.AddScoped<IPersonBusiness, PersonBusinessImplementation>();
            services.AddScoped<IPersonRepository, PersonRepositoryImplementation>();

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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
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

using FluentValidation.AspNetCore;
using GestorDocumental.Core.Filters;
using GestorDocumental.Core.Interfaces;
using GestorDocumental.Core.Services;
using GestorDocumental.Infrastucture.Data;
using GestorDocumental.Infrastucture.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace GestorDocumental.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers();

            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExeptionFilter>();
            });

            services.AddDbContext<GestorDocumentalContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("Connection"), x => x.MigrationsAssembly("GestorDocumental.Infrastructure"))
            );

            services.AddTransient<ITerceroService, TerceroService>();

            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddTransient<ICorrespondenciaService, CorrespondenciaService>();

            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddMvc()
                .AddFluentValidation(options =>
                {
                    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
                });

            AddSwagger(services);
        }

        private void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var groupName = "v1";

                options.SwaggerDoc(groupName, new OpenApiInfo
                {
                    Title = $"Gestor Documental {groupName}",
                    Version = groupName,
                    Description = "Gestor Documental API",
                    Contact = new OpenApiContact
                    {
                        Name = "Gestor Documental Company",
                        Email = string.Empty,
                        Url = new Uri("https://Inventario.com/"),
                    }
                });

                var xmlfile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlfile);

                options.IncludeXmlComments(xmlPath);
                options.EnableAnnotations();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gestor Documental API V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

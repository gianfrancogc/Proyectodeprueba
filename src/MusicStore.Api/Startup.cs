using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MusicStore.Service.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MusicStore.Service.Services;

namespace MusicStore.Api // En esta clase hacemos configuraciones GLOBALES, conf de librarias. IMPORTANTE!
{
    public class Startup
    {
        public Startup(IConfiguration configuration)// Abstrae todo los nodos del appsettings
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Agregar dependencias
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configuración de CORS: permitir cualquier origen, método y cabecera
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
            });

            services.AddDbContext<MusicDBContext>(e => e.UseSqlServer(Configuration.GetConnectionString("ConexionSql")));
            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<ISongService, SongService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Habilitar el redireccionamiento de HTTP a HTTPS
                app.UseHttpsRedirection();
            }

            app.UseRouting();

            // Habilitar CORS con la política configurada
            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

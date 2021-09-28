using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using webApi.Data;
using webApi.Core;
using webApi.Services;
using webApi.Core.Services;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.Swagger;
using webApi.Api.Validations;

namespace webApi.Api
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
            services.AddControllers();
            // Configure Database context
            services.AddDbContext<MyMusicDbContext>(options => options.UseSqlite(Configuration.GetConnectionString("Default"),x => x.MigrationsAssembly("webApi.Data")));
            // Configure dependency injection for Unit of Work
            // and Logic services.
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IMusicService, MusicService>();
            services.AddTransient<IArtistService, ArtistService>();
            // Configure autoMapper for resource-entity map
            services.AddAutoMapper(typeof(Startup));
            // Add validations for all controllers
            services.AddMvc(options => {
                options.Filters.Add(new ValidationFilter());
            }).AddFluentValidation(options =>
            {
                options.RegisterValidatorsFromAssemblyContaining<Startup>();
            });
            // Configure swagger for API UI
            services.AddSwaggerGen(options => 
                {
                    options.SwaggerDoc("v1", new OpenApiInfo {
                        Title = "Edwin API V1",
                        Version = "v1"
                    });
                });
            // Add basic health checks
            services.AddHealthChecks();
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
                endpoints.MapHealthChecks("/health");
            });
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.RoutePrefix = "";
                c.SwaggerEndpoint("/swagger/v1/swagger.json","My Music V1");
            });

        }
    }
}

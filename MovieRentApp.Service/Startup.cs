using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using System.Reflection;
using MovieRentApp.Dal.EfStructures;
using MovieRentApp.Dal.Initialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using MovieRentApp.Dal.Repos;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Mvc.NewtonsoftJson;
using Microsoft.OpenApi.Models;
using MovieRentApp.Dal.Repos.Interfaces;

namespace MovieRentApp.Service
{
    public class Startup
    {
        private readonly IHostEnvironment _env;
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            _env = env;
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers().AddNewtonsoftJson();
            services.AddMvc();
            services.AddDbContextPool<RentAppContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("MovieRentApp")));
            services.AddScoped<IMovieRepo, MovieRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IRentalRepo, RentalRepo>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "MovieRentApp Service",
                        Version = "v1",
                        Description = "Service to support the MovieRentApp sample movie renting site",
                    });
                    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                    var xmlPath = Path.Combine(AppContext.BaseDirectory,xmlFile);
                    c.IncludeXmlComments(xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                using (var serviceScope =
                    app
                        .ApplicationServices
                        .GetRequiredService<IServiceScopeFactory>()
                        .CreateScope())
                {
                    var context = 
                        serviceScope.ServiceProvider.GetRequiredService<RentAppContext>();
                    SampleDataInitializer.InitializeData(context);
                }
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MovieRentApp Service v1");

            });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

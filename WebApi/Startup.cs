using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Reflection;

namespace WebApi
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
            #region Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "NorthwindBackend Base Project Sample",
                    Version = "v1",
                    Description = "Burada REST API açýklamasý yer alacak",
                    //Contact = { Name = "Hakan Yalýtekin", Email = "hakanyalitekin@qmail.com", Url = new Uri("https://www.hakanyalitekin/wordpress.com") , Extensions ="MAY"},
                    TermsOfService = new Uri("https://opensource.org/licenses/MIT"),

                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

            });
            #endregion

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            #region Swagger

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.DocumentTitle = "NorthwindBackend API";
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "NorthwindBackend API dokümaný");
                c.RoutePrefix = "swagger"; //Buraya yardým yazarsak yardým yazdýðýmýzda açýlýr.
                c.DocExpansion(DocExpansion.None); // tüm endpoint'lerin kapalý gelmesini saðlar.
                //c.InjectStylesheet("/stil-yolu/stil.css");

            });

            #endregion
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

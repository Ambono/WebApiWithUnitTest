using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;

using System;
using System.IO;


namespace VenTest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public static string BaseDirectory { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IPrices, Prices>();
            services.AddSingleton<IItemCollection, ItemCollection>();
            services.AddSingleton<IDiscount, DiscountHelper>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddRouting();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "ven test",
                    Version = "v1",
                    Description = "ven test"
                });



                var filePath = Path.Combine($"{nameof(VenTest)}.xml");
                c.IncludeXmlComments(filePath);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            // app.UseMvc();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Price}/{action=DisplayPrice}/{id?}");
            });


            //if (env.IsDevelopment())
            //{
            //  app.UseDeveloperExceptionPage();
            //}
            app.UseStaticFiles();
            app.UseCors(options =>
                options
                    .AllowAnyHeader()
                    .AllowAnyMethod()
                    .AllowAnyOrigin()
                    .AllowCredentials());

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"{Configuration["virtual-directory"]}/swagger/v1/swagger.json", "ven test");
                c.RoutePrefix = "docs";
            });

        }
    } 
}

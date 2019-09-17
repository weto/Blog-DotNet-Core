using System;
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace modelo_2
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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo 
                { 
                    Version = "v1",
                    Title = "Meu primeiro microsservicço",
                    Description = "O primeiro exemplo da primeira API em dotnet core.",
                    TermsOfService = new Uri("http://localhost:8080/api/blogs"),
                    Contact = new OpenApiContact
                    {
                        Name = "Wellington",
                        Email = string.Empty,
                        Url = new Uri("https://twitter.com")
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = new Uri("https://teste.com/license"),
                    }
                });
            });

            services.Configure<CookiePolicyOptions> (Options => {
                Options.CheckConsentNeeded = context => true;
                Options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            var conn2 = "Host=postgres;Database=postgres;Username=postgres;Password=123456";

            services.AddEntityFrameworkNpgsql().AddDbContext<BloggingContext> (options => options.UseNpgsql(conn2));
            
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

            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Meu primeiro microsserviço V1");
                c.RoutePrefix = string.Empty;
            });
            app.UseHttpsRedirection();
            app.UseMvc();
            UpdateDatabase(app);
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices
                    .GetRequiredService<IServiceScopeFactory>()
                    .CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<BloggingContext>())
                {
                    context.Database.Migrate();
                }
            }
        }
    }
}

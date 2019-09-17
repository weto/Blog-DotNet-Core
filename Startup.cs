using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

            services.Configure<CookiePolicyOptions> (Options => {
                Options.CheckConsentNeeded = context => true;
                Options.MinimumSameSitePolicy = Microsoft.AspNetCore.Http.SameSiteMode.None;
            });

            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document => {
                    document.Info.Version = "v1";
                    document.Info.Title = "Microserviço dotnet core com swagger nswag";
                    document.Info.Description = "Primeiro Micriserviço com dotnet core";
                    document.Info.TermsOfService = "None";
                    document.Info.Contact = new NSwag.OpenApiContact {
                        Name = "Wellington",
                        Email = string.Empty,
                        Url = "http://teste.com"
                    };
                    document.Info.License = new NSwag.OpenApiLicense
                    {
                        Name = "Use under LICX",
                        Url = "http://example.com/license"
                    };
                };
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

            app.UseStaticFiles();
            app.UseOpenApi();
            app.UseSwaggerUi3();

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

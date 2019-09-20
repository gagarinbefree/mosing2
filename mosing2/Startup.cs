using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using mosing2.Models;
using System;
using Mapster;
using mosing2.ViewModels;

namespace mosing2
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

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddScoped<ITravelDataProvider, DataProvider>();
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
                app.UseExceptionHandler("/Error");
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });

            AppDomain.CurrentDomain.SetData("DataDirectory", System.IO.Path.Combine(env.ContentRootPath, "App_Data"));

            TypeAdapterConfig<Traveling, Travel>
                .NewConfig()
                .Map(d => d.Routes, s => s.route);

            TypeAdapterConfig<travelingRoute, Route>
                .NewConfig()
                .Map(d => d.Label, s => s.part)
                .Map(d => d.Options, s => s.place);

            TypeAdapterConfig<travelingRoutePlace, Place>
                .NewConfig()
                .Map(d => d.Label, s => s.name)
                .Map(d => d.Value, s => $"{s.lat};{s.@long}");
        }
    }
}

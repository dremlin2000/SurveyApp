using AutoMapper;
using Data.EFRepository.Base;
using Data.Repository.Base.Interfaces;
using Lib.Utils.Abstract;
using Lib.Utils.Concrete;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;
using Survey.AppService;
using Survey.Core.Abstract.AppService;
using Survey.Core.Abstract.Repository;
using Survey.Core.Configuration;
using Survey.Repository;
using Survey.Web.Infrastructure.ActionFilters;
using System;

namespace SurveyApp.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostingEnvironment currentEnvironment)
        {
            Configuration = configuration;
            CurrentEnvironment = currentEnvironment;
        }

        public IConfiguration Configuration { get; }
        public IHostingEnvironment CurrentEnvironment { get; }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddAutoMapper();

            // Add application services.
            services.AddScoped<IJsonSerializer, NewtonsoftJsonSerializer>();
            services.AddScoped<Lib.Utils.Abstract.IObjectMapper, ObjectMapper>();
            services.AddScoped<IAppRepository, AppEfRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IModelValidator, ModelValidator>();
            services.AddScoped<UnitOfWorkActionFilter>();
            services.AddScoped<ISurveyService, SurveyService>();

            var appSettings = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettings);

            Action<DbContextOptionsBuilder> dbCtxOptions = null;
            if (CurrentEnvironment.IsEnvironment("Testing"))
            {
                dbCtxOptions = (options) =>
                {
                    //There are two options to use in-memory database
                    options.UseInMemoryDatabase("TestingDB");
                    options.ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning));
                };
            }
            else
            {
                dbCtxOptions = (options) => options.UseSqlServer(Configuration.GetConnectionString("DbConnection"));
            }

            services.AddDbContext<AppDbContext>(dbCtxOptions);
            services.AddScoped(provider => (DbContext)provider.GetService(typeof(AppDbContext)));
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
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
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}

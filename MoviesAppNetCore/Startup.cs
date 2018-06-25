using System.IO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using MoviesAppNetCore.Data;
using MoviesAppNetCore.Filters;
using MoviesAppNetCore.Middleware;
using MoviesAppNetCore.Services;
using NLog.Extensions.Logging;
using NLog.Web;

namespace MoviesAppNetCore
{
    public class Startup
    {
        private IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
       
        public void ConfigureDevelopmentServices(IServiceCollection services)
        {
            services.AddDbContext<MovieDBContext>(options =>
                options.UseSqlServer(_configuration.GetConnectionString("Movies")));
           
            services.AddScoped<IMovieRepository,SqlMovieData>();
            services.AddMvc(options =>
            {
                options.Filters.Add(new LogFilterActionAttribute());

            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void ConfigureDevelopment(IApplicationBuilder app, IHostingEnvironment env,ILoggerFactory loggerFactory)
        {
   
            var welcomeString = "Welcome";

            var MachineDetails = _configuration.GetSection("MachineDetails").Get<MachineDetails>();


            //Add NLog Configuration
            loggerFactory.AddNLog();
            env.ConfigureNLog("NLog.config");


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(); // access files from default directory wwwroot

            //configuration to fetch files from "StaticFiles" Directory
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles"))
            });
            //middleware component as annonymous method
            app.Use((context, next) =>
            {
                if (context.Request.Path.ToString().Contains("home"))
                {
                    welcomeString += ": Home Page";
                }

                return next();
            });

            //middleware component using class
            app.UseDemoMiddleWare(env.EnvironmentName);

            app.UseMvc();

            app.Run(async (context) =>
            {
                var machineDetails =
                    $"MachineName : {MachineDetails.MachineName} OS: {MachineDetails.os} Processor: {MachineDetails.processor}";
                await context.Response.WriteAsync($"{welcomeString}:{env.EnvironmentName}, MachineDetails: {machineDetails}");
            });
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!");
            });
        }

    }
}

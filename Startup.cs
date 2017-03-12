﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnetapp.Data.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;

using aspnetapp.Data.Repository;

namespace aspnetapp
{
   public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AlbumsContext>(builder =>
            {
                var connStr = Configuration.GetConnectionString("DefaultConnection");
                builder.UseSqlServer(connStr);
            }
            );


            services.AddTransient<ArtistRepository>();

            // Add framework services.
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {

          //  if (env.IsDevelopment())
            //{
                app.UseDeveloperExceptionPage();
            //}

             var startupLogger = loggerFactory.CreateLogger<Startup>();

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

             startupLogger.LogInformation("Application startup is complete");
             
        }
    }
}

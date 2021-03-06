﻿using System.Reflection;
using CleanArchitectureTemplate.Application.Infrastructure;
using CleanArchitectureTemplate.Infrastructure.Extensions;
using CleanArchitectureTemplate.Persistence;
using CleanArchitectureTemplate.Persistence.Extensions;
using CleanArchitectureTemplate.WebUI.Extensions;
using CleanArchitectureTemplate.WebUI.Filters;
using FluentValidation.AspNetCore;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CleanArchitectureTemplate.WebUI
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
            services.AddMvc(options =>
                    {
                        // options.Filters.Add(typeof(CustomExceptionFilterAttribute)) <!-- User error filter if global error handler was not set
                    }
                ).SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                 .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<FluentValidatorMarkerClass>()); ;

            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(MediatorHandlerPlaceholderClass).GetTypeInfo().Assembly);

            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // Swagger
            services.AddSwaggerDocument(config =>
            {
                config.PostProcess = document =>
                {
                    document.Info.Version = "v1";
                    document.Info.Title = "CleanArchitectureTemplate API";
                    document.Info.Description = "CleanArchitectureTemplate ASP.NET Core web API";
                    document.Info.TermsOfService = "None";
                };
            });

            // Application modules
            services.AddInfrastructureModule();
            services.AddPersistenceModule(Configuration.GetConnectionString("Database"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
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
            loggerFactory.AddFile(Configuration.GetSection("Logging"));
            app.UseGlobalErrorHandler(loggerFactory.CreateLogger("Default")); // <-- Global error handler
            app.UseHttpsRedirection();
            app.UseSwagger();
            app.UseSwaggerUi3();
            app.UseFileServer();
            app.UseMvc();
        }
    }
}

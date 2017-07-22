﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using test_1_webapi_Domain.Repositories;
using test_1_webapi_Domain.DataModels;
using test_1_webapi_api.Repositories;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.AspNetCore.Mvc;

namespace test_1_webapi_api
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {



            // Add framework services.
            //services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc(config =>
            {
                // Add XML Content Negotiation
                config.RespectBrowserAcceptHeader = true;
                config.Filters.Add(new RequireHttpsAttribute());
                config.InputFormatters.Add(new XmlSerializerInputFormatter());
                config.OutputFormatters.Add(new XmlSerializerOutputFormatter());
            });


            services.AddSingleton<IRepository<User>, JsonplaceholderRepository<User>>(serviceProvider =>
            {
                return new JsonplaceholderRepository<User>("http://jsonplaceholder.typicode.com/users");
            });
            services.AddSingleton<IRepository<Album>, JsonplaceholderRepository<Album>>(serviceProvider =>
            {
                return new JsonplaceholderRepository<Album>("http://jsonplaceholder.typicode.com/albums");
            });
            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseApplicationInsightsRequestTelemetry();

            //app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();

            var options = new RewriteOptions()
                .AddRedirectToHttps();

            app.UseRewriter(options);
        }
    }
}

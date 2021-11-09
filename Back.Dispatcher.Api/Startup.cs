using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Back.Dispatcher.Api.AutoMapper;
using Back.Dispatcher.Api.Business;
using Back.Dispatcher.Api.Helpers;
using Back.Dispatcher.Api.Interface.Business;
using Back.Dispatcher.Api.Interface.Repository;
using Back.Dispatcher.Api.Interface.Service;
using Back.Dispatcher.Api.Repository;
using Back.Dispatcher.Api.Service;

namespace Back.Dispatcher.Api
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Run Simulados Dispatcher",
                    Description = "Serviço para envio de emails baseado em templates ou em mensagens prontas",
                });
            });
            services.AddControllers();
            services.Configure<ConfigEmail>(_configuration.GetSection("ConfigEmail"));
            services.Configure<List<TemplateEmailConfig>>(_configuration.GetSection("TemplateEmail"));

            services.AddScoped<IEmailBusiness, EmailBusiness>();
            services.AddScoped<IEmailBuilderService, EmailBuilderService>();
            services.AddScoped<IEmailSenderService, EmailSenderService>();
            services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();

            var mapper = AutoMapperConfig.Configure();
            services.AddSingleton(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Run Simulados Dispatcher");
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader());
            
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}

using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using UsuarioMrvTeste.Infra.Interfaces;
using Microsoft.Extensions.Azure;
using Azure.Storage.Queues;
using Azure.Storage.Blobs;
using Azure.Core.Extensions;
using System;

namespace UsuarioMrvTeste
{
    public class Startup
    {
        private readonly ApplicationSettings _configuracaoAplicacao;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _configuracaoAplicacao = new ApplicationSettings(Configuration);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddSingleton<IApplicationSettings>(_configuracaoAplicacao);

            services
                .AddControllers()
                .AddJsonOptions(opt =>

                {
                    opt.JsonSerializerOptions.IgnoreNullValues = true;
                });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "UsuarioMrvTeste", Version = "v1" });
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new IocModule());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseRouting();

            app.UseSwagger();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "UsuarioMrvTeste v1");
                    c.RoutePrefix = string.Empty;
                });
            }

            app.UseMvc();
        }
    }
}
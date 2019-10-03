using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Eventdlar.Common.Events;
using Eventdlar.Notification.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.vNext;

namespace Eventdlar.Notification
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
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            AddRabbitMqService(services, Configuration.GetSection("Rabbit"));
        }

        private void AddRabbitMqService(IServiceCollection services, IConfigurationSection configuration)
        {
            var options = new RawRabbitConfiguration();
            configuration.Bind(options);
            services.AddSingleton<IBusClient>(_ => BusClientFactory.CreateDefault(options));
            services.AddTransient<IEventHandler<EventCreated>, EventCreatedHandler>();
            services.AddTransient<IEventHandler<EmailSentToClient>, EmailSentToClientHandler>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            app.AddEventHandler<EventCreated>();
            app.AddEventHandler<EmailSentToClient>();
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}

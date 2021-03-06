﻿using Eventdlar.Common.Databases;
using Eventdlar.Common.Queries;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.vNext;

namespace Eventdlar.Api
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
            services.AddSingleton<IRepository<Notification, Notifications>, NotificationsInMemoryDb>();
            services.AddSingleton<IRepository<Event, Events>, EventsInMemoryDb>();
            AddRabbitMqService(services, Configuration.GetSection("Rabbit"));
        }

        private void AddRabbitMqService(IServiceCollection services, IConfigurationSection configuration)
        {
            var options = new RawRabbitConfiguration();
            configuration.Bind(options);
            services.AddSingleton<IBusClient>(_ => BusClientFactory.CreateDefault(options));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

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

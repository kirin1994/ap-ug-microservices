using Eventdlar.Common.Commands;
using Eventdlar.Common.Events;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.vNext;

namespace Eventdlar.Eventer
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
            services.AddTransient<ICommandHandler<CreateEvent>, CreateEventHandler>();
            services.AddTransient<IEventHandler<EventCreated>, EventCreatedHandler>();
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.AddEventHandler<EventCreated>();
            app.AddCommandHandler<CreateEvent>();
            app.UseCors(cors => cors.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials());
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

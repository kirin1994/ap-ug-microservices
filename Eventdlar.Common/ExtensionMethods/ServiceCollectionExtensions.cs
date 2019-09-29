using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit;
using RawRabbit.Configuration;
using RawRabbit.vNext;

namespace Eventdlar.Common.ExtensionMethods
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRabbitMqService(this IServiceCollection services, IConfigurationSection configuration)
        {
            var config = new RawRabbitConfiguration();
            configuration.Bind(config);
            services.AddSingleton<IBusClient>(a => BusClientFactory.CreateDefault(config));
        }
    }
}

using System;
using System.Threading.Tasks;
using Eventdlar.Api.Commands;
using Microsoft.AspNetCore.Builder;
using RawRabbit;

namespace Eventdlar.Api.Events
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddEventHandler<T>(this IApplicationBuilder applicationBuilder) where T : IEvent
        {
            if(!(applicationBuilder.ApplicationServices.GetService(typeof(IBusClient)) is IBusClient busClient))
            {
                throw new NullReferenceException();
            }

            if(!(applicationBuilder.ApplicationServices.GetService(typeof(IEventHandler<T>)) is IEventHandler<T> handler ))
            {
                throw new NullReferenceException();
            }

            busClient.SubscribeAsync<T>(async (msg, context) => 
            {
                await handler.HandleAsync(msg);
            });

            return applicationBuilder;
        }

            public static IApplicationBuilder AddCommandHandler<T>(this IApplicationBuilder applicationBuilder) where T : ICommand
        {
            if(!(applicationBuilder.ApplicationServices.GetService(typeof(IBusClient)) is IBusClient busClient))
            {
                throw new NullReferenceException();
            }

            if(!(applicationBuilder.ApplicationServices.GetService(typeof(ICommandHandler<T>)) is ICommandHandler<T> handler ))
            {
                throw new NullReferenceException();
            }

            busClient.SubscribeAsync<T>(async (msg, context) => 
            {
                await handler.HandleAsync(msg);
            });

            return applicationBuilder;
        }
    }


}

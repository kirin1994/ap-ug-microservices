using System;
using System.Reflection;
using System.Threading.Tasks;
using Eventdlar.Common.Commands;
using Microsoft.AspNetCore.Builder;
using RawRabbit;

namespace Eventdlar.Common.Events
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
            },configuration => {
                            configuration.WithQueue(queue => 
                                queue
                                .WithName(typeof(T).Name).WithExclusivity(false))
                                .WithSubscriberId("");
                            configuration.WithExchange(exchange => exchange.WithName("Events"));
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
            }, configuration => {
                            configuration.WithQueue(queue =>queue.WithName(typeof(T).Name)).WithSubscriberId("");
                            configuration.WithExchange(exchange => exchange.WithName("Commands")); 
                            });


            return applicationBuilder;
        }
    }
   
}   
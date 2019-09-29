using System;
using RawRabbit;
using Microsoft.AspNetCore.Builder;
using Eventdlar.Common.Domain.Command;
using Eventdlar.Common.Domain.Event;

namespace Eventdlar.Common.ExtensionMethods
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder AddCommandHandler<T>(this IApplicationBuilder application, IBusClient client)
            where T : ICommand
        {
            if (!(application.ApplicationServices.GetService(typeof(ICommandHandler<T>)) is ICommandHandler<T> handler))
            {
                throw new NullReferenceException();
            }

            client.SubscribeAsync<T>(async (command, context) =>
            {
                await handler.HandleAsync(command);
            });

            return application;
        }

        public static IApplicationBuilder AddCommandHandler<T>(this IApplicationBuilder app)
          where T : ICommand
        {
            if (!(app.ApplicationServices.GetService(typeof(IBusClient)) is IBusClient busClient))
                throw new NullReferenceException();

            return AddCommandHandler<T>(app, busClient);
        }

        public static IApplicationBuilder AddEventHandler<T>(this IApplicationBuilder application, IBusClient client)
          where T : IEvent
        {
            if (!(application.ApplicationServices.GetService(typeof(IEventHandler<T>)) is IEventHandler<T> handler))
            {
                throw new NullReferenceException();
            }

            client.SubscribeAsync<T>(async (command, context) =>
            {
                await handler.HandleAsync(command);
            });

            return application;
        }

        public static IApplicationBuilder AddEventHandler<T>(this IApplicationBuilder app)
          where T : ICommand
        {
            if (!(app.ApplicationServices.GetService(typeof(IBusClient)) is IBusClient busClient))
                throw new NullReferenceException();

            return AddEventHandler<T>(app, busClient);
        }
    }
}
using System;
using RawRabbit;

public static class ApplicationBuilderExtensions
{
    public static IApplicationBuilder AddCommandHandler<T>(this IApplicationBuilder application, IBusClient client)
        where T : ICommand
    {
        if (!(application.ApplicationServices.GetService(typeof(ICommandHandler<T>) is ICommandHandler<T> handler)))
        {
            throw new NullReferenceException();
        }

        

    }
}
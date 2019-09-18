using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace Eventdlar.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
            Task.Run(() => Thread.Sleep(Timeout.Infinite));
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}

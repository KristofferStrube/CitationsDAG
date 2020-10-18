using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CitationsDAG
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            HttpClient client = new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) };
            client.DefaultRequestHeaders.Referrer = new Uri(builder.HostEnvironment.BaseAddress);

            builder.Services.AddScoped(sp => client);

            await builder.Build().RunAsync();
        }
    }
}

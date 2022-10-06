using Pumbas.ClienteBlazor.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MudBlazor.Services;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pumbas.ClienteBlazor
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44308/api/") });

            builder.Services.AddScoped<IProductoService, ProductoService>();
            builder.Services.AddScoped<ICategoriaService, CategoriaService>();

            builder.Services.AddMudServices();

            await builder.Build().RunAsync();
        }
    }
}

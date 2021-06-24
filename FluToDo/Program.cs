using FluToDo.Services;
using MatBlazor;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FluToDo
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");
            //TODO: change this if needed
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44332/api/todo") });
            builder.Services.AddMatBlazor();
            builder.Services.AddScoped<ITodoService, TodoService>();
            await builder.Build().RunAsync();
        }
    }
}

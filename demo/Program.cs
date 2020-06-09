using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.JSInterop;
using System.Globalization;

namespace Demo
{
  public class Program
  {
    public static async Task Main(string[] args)
    {

      var builder = WebAssemblyHostBuilder.CreateDefault(args);
      builder.RootComponents.Add<App>("app");

      builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
      builder.Services.AddLocalization();

      var host = builder.Build();

      // Set the culture by using the "locale" querystring
      var jsInterop = host.Services.GetRequiredService<IJSRuntime>();
      var result = await jsInterop.InvokeAsync<string>("blazorCulture.get");
      if (result == "")
      {
        result = null;
      }

      if (result != null)
      {        
        var culture = new CultureInfo(result);
        CultureInfo.DefaultThreadCurrentCulture = culture;
        CultureInfo.DefaultThreadCurrentUICulture = culture;
      }

      await host.RunAsync();
    }
  }
}

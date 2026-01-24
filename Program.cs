using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Portfolio.UI.Shared;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register HttpClientFactory for dependency injection
builder.Services.AddHttpClient("PortfolioAPI", client => 
{
    client.BaseAddress = new Uri("https://localhost:7084/");
});

// Also register a default HttpClient for components that inject HttpClient directly
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("PortfolioAPI"));

await builder.Build().RunAsync();


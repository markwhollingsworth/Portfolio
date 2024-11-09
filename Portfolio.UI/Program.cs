using Microsoft.AspNetCore.Http.Connections;
using Portfolio.Shared.DataAccess;
using Portfolio.Shared.Interfaces;
using Portfolio.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor().AddHubOptions(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
    options.EnableDetailedErrors = true;
    options.HandshakeTimeout = TimeSpan.FromSeconds(30);
    options.KeepAliveInterval = TimeSpan.FromSeconds(10);
    options.MaximumParallelInvocationsPerClient = 4;
    options.MaximumReceiveMessageSize = 64 * 1024;
    options.StreamBufferCapacity = 10;
    if (builder.Environment.IsDevelopment())
    {
        options.EnableDetailedErrors = true;
    }

});

builder.Services.AddSingleton<IInventoryDataAccess, InventoryDataAccess>();
builder.Services.AddSingleton<IMapDataAccess, MapDataAccess>();
builder.Services.AddSingleton<IMintDataAccess, MintDataAccess>();
builder.Services.AddSingleton<IDenominationDataAccess, DenominationDataAccess>();
builder.Services.AddSingleton<ICollectibleDataAccess, CollectibleDataAccess>();
builder.Services.AddSingleton<IPortfolioService, PortfolioService>();
builder.Services.AddSingleton<HttpClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub(options =>
{
    options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
});
app.MapControllers();
app.MapFallbackToPage("/_Host");
app.Run();

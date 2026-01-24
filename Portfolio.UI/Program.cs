using Microsoft.AspNetCore.Http.Connections;
using Portfolio.UI.DataAccess;
using Portfolio.UI.Interfaces;
using Portfolio.Shared.Repository;
using Portfolio.UI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load(Strings.PortfolioDotShared)));
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents().AddHubOptions(options =>
{
    options.ClientTimeoutInterval = TimeSpan.FromSeconds(60);
    options.EnableDetailedErrors = true;
    options.HandshakeTimeout = TimeSpan.FromSeconds(30);
    options.KeepAliveInterval = TimeSpan.FromSeconds(10);
    options.MaximumParallelInvocationsPerClient = 4;
    options.MaximumReceiveMessageSize = 64 * 1024;
    options.StreamBufferCapacity = 10;
    //if (builder.Environment.IsDevelopment())
    //{
        options.EnableDetailedErrors = true;
    //}
});

//var connectionString =
//    builder.Configuration.GetConnectionString("DefaultConnection")
//        ?? throw new InvalidOperationException("Connection string"
//        + "'DefaultConnection' not found.");

//builder.Services.AddAzureSql(connectionString);//, clientBuilder =>
//{
//    clientBuilder.AddBlobServiceClient(
//        new Uri("https://<account-name>.blob.core.windows.net"));
//    clientBuilder.UseCredential(new DefaultAzureCredential());
//});

builder.Services.AddSingleton<ICoinDataAccess, CoinDataAccess>();
builder.Services.AddSingleton<ICurrencyDataAccess, CurrencyDataAccess>();
builder.Services.AddScoped<IPortfolioService, PortfolioService>();
builder.Services.AddScoped<IMapDataAccess, MapDataAccess>();
builder.Services.AddSingleton<HttpClient>();
string azureSignalrConnectionString = builder.Configuration["Azure:SignalR:ConnectionString"];
builder.Services.AddSignalR().AddAzureSignalR(options =>
{
    options.ConnectionString = azureSignalrConnectionString;
});

//builder.Services.AddAzureClients(clientBuilder =>
//{
//    clientBuilder.AddClient()
//        //new Uri("https://<account-name>.blob.core.windows.net"));
//    clientBuilder.UseCredential(new DefaultAzureCredential());
//});

//var connectionString =
//    builder.Configuration.GetConnectionString("DefaultConnection")
//        ?? throw new InvalidOperationException("Connection string"
//        + "'DefaultConnection' not found.");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//{
//    //options.UseSqlServer(connectionString);
//    options.UseAzureSql(connectionString);//.UseAzureServer(connectionString);//.UseAzureSql(connectionString).;//.UseCredential(new DefaultAzureCredential());
//});

//var tenantId = builder.Configuration.GetValue<string>("AzureAd:TenantId")!;
//var vaultUri = builder.Configuration.GetValue<string>("AzureAd:VaultUri")!;
//var secretName = builder.Configuration.GetValue<string>("AzureAd:SecretName")!;

//builder.Services.Configure<MicrosoftIdentityOptions>(
//    OpenIdConnectDefaults.AuthenticationScheme,
//    options =>
//    {
//        options.ClientSecret =
//            AzureHelper.GetKeyVaultSecret(tenantId, vaultUri, secretName);
//    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseAntiforgery();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();
app.UseAuthorization();
app.MapBlazorHub(options =>
{
    options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
});
app.MapControllers();
app.MapFallbackToPage("/_Host");

app.Run();

using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Portfolio.Shared.DataAccess;
using Portfolio.Shared.Interfaces;
using Portfolio.Shared.Repository;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.ClearProviders().AddConsole();
builder.Services.AddControllers().AddJsonOptions(options => { options.JsonSerializerOptions.PropertyNamingPolicy = null; });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection(Strings.AzureAd));

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.Load(Strings.PortfolioDotShared)));

builder.Services.AddScoped<ICoinDataAccess, CoinDataAccess>();
builder.Services.AddScoped<ICurrencyDataAccess, CurrencyDataAccess>();
builder.Services.AddScoped<IDenominationDataAccess, DenominationDataAccess>();
builder.Services.AddScoped<IInventoryDataAccess, InventoryDataAccess>();
builder.Services.AddScoped<IMapDataAccess, MapDataAccess>();
builder.Services.AddScoped<IMintDataAccess, MintDataAccess>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.Run();

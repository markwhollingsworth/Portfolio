using Portfolio.UI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
#pragma warning disable CS8604 // Possible null reference argument.
builder.Services.AddHttpClient<IPortfolioService, PortfolioService>(client =>
client.BaseAddress = new Uri(builder.Configuration.GetValue<string>("BasePortfolioApiUrl")));
#pragma warning restore CS8604 // Possible null reference argument.

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
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.Run();

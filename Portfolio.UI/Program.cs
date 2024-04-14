using AutoMapper;
using Portfolio.UI.DependencyManager;
using Serilog.Events;
using Serilog;
using Portfolio.UI.Services;

Log.Logger = new LoggerConfiguration()
	.MinimumLevel.Debug()
	.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
	.Enrich.FromLogContext()
	.WriteTo.Console()
	.WriteTo.File("log.txt", rollingInterval: RollingInterval.Hour)
	.CreateLogger();

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
builder.Services.AddControllersWithViews();
// Configuring services
builder.Services.ConfigureMyServices();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Host.UseSerilog((hostingContext, loggerConfiguration) => loggerConfiguration
	.ReadFrom.Configuration(hostingContext.Configuration)
	.WriteTo.Console());

// for client
builder.Services.AddHttpClient();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

// for serilog
app.UseSerilogRequestLogging();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

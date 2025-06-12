using eatery_manager_server.Data.Db;
using eatery_manager_server.Data.Services;
using eatery_manager_server;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace eatery_manager_server;

public static class Program
{
    public static WebApplication? AppInstance { get; private set; }
    public static async Task Main(string[] args)
    {
        await StartAsync();
    }

    public static async Task StartAsync(CancellationToken cancellationToken = default)
    {
        var builder = WebApplication.CreateBuilder();

        ConfigureServices(builder.Services);
        ConfigureAuthentication(builder.Services);

        var app = builder.Build();
        AppInstance = app;

        await InitializeDatabaseAsync(app);
        ConfigureMiddleware(app);

        _ = app.RunAsync(cancellationToken); // NIE czekamy na zakoñczenie — dzia³a w tle
    }

    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
            options.UseSqlite("Data Source=Data/database.db"));

        services.AddRazorComponents()
                .AddInteractiveServerComponents();

        services.AddScoped<LoginService>();
        services.AddScoped<MenuService>();
        services.AddScoped<ReservationsService>();
        services.AddScoped<TablesService>();
    }

    private static void ConfigureAuthentication(IServiceCollection services)
    {
        services.AddScoped<CustomAuthenticationStateProvider>();
        services.AddScoped<AuthenticationStateProvider>(sp =>
            sp.GetRequiredService<CustomAuthenticationStateProvider>());

        services.AddAuthorizationCore();

        services.AddServerSideBlazor(options =>
        {
            options.DetailedErrors = true;
        });
    }

    private static void ConfigureMiddleware(WebApplication app)
    {
        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error", createScopeForErrors: true);
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseAntiforgery();

        app.MapStaticAssets();

        app.MapRazorComponents<App>()
           .AddInteractiveServerRenderMode();
    }

    private static async Task InitializeDatabaseAsync(WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        await DatabaseInitializer.SeedAsync(dbContext);
    }
}
using eatery_manager_server.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
// Jeœli masz autoryzacjê:
// app.UseAuthentication();
// app.UseAuthorization();
app.UseAntiforgery(); // <-- TU MUSI BYÆ

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
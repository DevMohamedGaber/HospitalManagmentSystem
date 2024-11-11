using Presentation.WebUI.Components;
using Application.Extentions;
using Persistence.Extentions;
using Presentation.WebUI;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureApplication();
builder.Services.ConfigureInfrastructure(builder.Configuration);
builder.Services.ConfigureWebUI();

// Add services to the container.
builder.Services.AddRazorComponents()
                .AddInteractiveServerComponents();

builder.Services.AddHttpContextAccessor();
builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(10);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseSession();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
   .AddInteractiveServerRenderMode();

app.Run();

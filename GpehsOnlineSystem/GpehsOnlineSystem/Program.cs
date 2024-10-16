using GpehsOnlineSystem.Client.Pages;
using GpehsOnlineSystem.Components;
using Syncfusion.Licensing;
using Syncfusion.Blazor;
using GpehsOnlineSystem;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

var sfKey = builder.Configuration.GetSection("ApiKeys").Get<ApiKeys>();
SyncfusionLicenseProvider.RegisterLicense(sfKey?.SfLicense);

builder.Services.AddSyncfusionBlazor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(GpehsOnlineSystem.Client._Imports).Assembly);

app.Run();

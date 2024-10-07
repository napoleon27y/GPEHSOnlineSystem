using GPEHSOnlineSystem;
using GPEHSOnlineSystem.Components;
using Microsoft.Extensions.Options;
using Syncfusion.Licensing;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

//SyncfusionLicenseProvider.RegisterLicense("MzUxNTc3OUAzMjM3MmUzMDJlMzBLUEswUnBLbnZIZE8vb1EzZ1dQN2MzeEl4RDBtMTRwRFRZaFB1bEV1TUxFPQ==");

// Add services to the container.
builder.Services.AddRazorComponents().AddInteractiveServerComponents();
//builder.Services.Configure<ApiKeys>(builder.Configuration.GetSection("ApiKeys"));

var sfKey = builder.Configuration.GetSection("ApiKeys").Get<ApiKeys>();
Debug.WriteLine("==========================");
Debug.WriteLine(sfKey?.SfLicense);
Debug.WriteLine("==========================");

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
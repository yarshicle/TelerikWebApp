using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TelerikWebApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddTelerikBlazor();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<ThemeService>();

await builder.Build().RunAsync();

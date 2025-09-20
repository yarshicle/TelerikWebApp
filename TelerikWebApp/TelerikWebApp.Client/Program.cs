using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TelerikWebApp.Client.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddTelerikBlazor();
builder.Services.AddScoped<UserService>();

await builder.Build().RunAsync();

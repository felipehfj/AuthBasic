using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Http.Handlers;
using AuthBasic;
using Http.Clients;
using StateContainers;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<TodoStore>();
builder.Services.AddScoped<FakeApiHandler>();
builder.Services.AddHttpClient("FakeAPI", client => client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"))
    .AddHttpMessageHandler<FakeApiHandler>();
builder.Services.AddScoped<ITodoHttpClient, TodoHttpClient>();
builder.Services.AddBlazorBootstrap();


await builder.Build().RunAsync();

/**
    *   Blazor-State Blazor Hosted WebAssembly Tutorial
    *   https://timewarpengineering.github.io/blazor-state/Samples/01-StateActionsHandlers/Readme.html

    *   Fluxor
    *   https://github.com/mrpmorris/Fluxor/tree/master/Source/Tutorials/02-Blazor
*/
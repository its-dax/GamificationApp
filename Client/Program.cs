global using Blazored.LocalStorage;
using GamificationApp.Client;
using GamificationApp.Client.Auth;
using GamificationApp.Client.Services;
using GamificationApp.Client.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7216/") });
builder.Services.AddScoped<IQuestionService, QuestionService>();
builder.Services.AddScoped<IScoreService, ScoreService>();
builder.Services.AddScoped<ITestService, TestService>();
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthStateProvider>();
builder.Services.AddAuthorizationCore();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();

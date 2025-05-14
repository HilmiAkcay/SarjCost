using Microsoft.EntityFrameworkCore;
using SarjCost.Components;
using SarjCost.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("PostgresConnection"),
    o => o.CommandTimeout(60)));

//builder.Services.AddScoped<AuthenticationStateProvider, RemoteAuthenticationService<RemoteUserAccount>>();
//builder.Services.AddScoped<IAccessTokenProvider, AuthorizationMessageHandler>();
builder.Services.AddAuthorizationCore();

builder.Services.AddOidcAuthentication(options =>
{
    options.ProviderOptions.Authority = "https://accounts.google.com";
    options.ProviderOptions.ClientId = "YOUR_GOOGLE_CLIENT_ID";
    options.ProviderOptions.ResponseType = "id_token";
    options.ProviderOptions.DefaultScopes.Add("openid");
    options.ProviderOptions.DefaultScopes.Add("profile");
    options.ProviderOptions.DefaultScopes.Add("email");
    options.ProviderOptions.RedirectUri = "https://localhost:5001/authentication/login-callback";
});




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


app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    .AddInteractiveWebAssemblyRenderMode()
    .AddAdditionalAssemblies(typeof(SarjCost.Client._Imports).Assembly);

app.Run();

using SibungaAPI.Components;
using SibungaAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register local StudentService so pages/components can inject it if needed
builder.Services.AddSingleton<StudentService>();

// Register named HttpClients for external APIs
builder.Services.AddHttpClient("healthcare", c =>
{
    // switched to nationalize.io API
    c.BaseAddress = new Uri("https://api.nationalize.io/");
});
builder.Services.AddHttpClient("joke", c =>
{
    c.BaseAddress = new Uri("https://official-joke-api.appspot.com/");
});
builder.Services.AddHttpClient("fda", c =>
{
    c.BaseAddress = new Uri("https://api.fda.gov/");
});

// Register external API services
builder.Services.AddSingleton<SibungaAPI.Services.HealthcareService>();
builder.Services.AddSingleton<SibungaAPI.Services.JokeService>();
builder.Services.AddSingleton<SibungaAPI.Services.FdaService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();

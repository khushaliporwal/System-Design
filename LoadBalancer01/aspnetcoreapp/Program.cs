using aspnetcoreapp;

var builder = WebApplication.CreateBuilder(args);

// Configure the web application
builder.Services.AddRazorPages();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Use the custom middleware to capture the port number
app.UseRequestPortMiddleware();

app.MapRazorPages();

app.Run();

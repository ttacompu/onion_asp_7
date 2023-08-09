var builder = WebApplication.CreateBuilder();
builder.Host.UseContentRoot(Directory.GetCurrentDirectory()).ConfigureAppConfiguration((hostingContext, config) => {
    config.Sources.Clear();
    config.AddJsonFile("appsettings.json", optional: true);
});
builder.Services.AddRazorPages();


var app = builder.Build();
app.UseExceptionHandler("/Error");
app.UseStaticFiles();
app.UseRouting();
app.MapRazorPages();
app.Run();


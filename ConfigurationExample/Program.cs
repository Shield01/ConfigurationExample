using ConfigurationExample;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

//Suply and object of WeatherApiOptions (with "weatherapi" section as a service)
builder.Services.Configure<WeatherApiOptions>(builder.Configuration.GetSection("WeatherApi"));

// Demonstrating the use of Custom json files
builder.Host.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.AddJsonFile("MyCustomSettings.json", optional: true, reloadOnChange:true);
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.Run();

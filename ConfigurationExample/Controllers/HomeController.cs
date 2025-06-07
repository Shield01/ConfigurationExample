using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace ConfigurationExample.Controllers
{
    public class HomeController : Controller
    {
        //Private fields
        private readonly IConfiguration _configuration;

        //Demonstrating the use of WeatherApiOptions as an injected service
        private readonly WeatherApiOptions _weatherApiOptions;

        // Constructor
        public HomeController(IConfiguration configuration, IOptions<WeatherApiOptions> weatherApiOptions)
        {
            _configuration = configuration;
            _weatherApiOptions = weatherApiOptions.Value;
        }

        [Route("/")]
        public IActionResult Index()
        {
            ViewBag.MyKey = _configuration.GetValue<string>("Mykey");
            ViewBag.MyApiKey = _configuration.GetValue("MyApiKey", "The default Key");
            //ViewBag.WeatherApiClientId = _configuration.GetValue<string>("WeatherApi:Clientid");
            //ViewBag.WeatherApiClientSecret = _configuration.GetValue("WeatherApi:ClientSecret", "A dummy secret key");

            //Demonstrating the use of GetSection method
            //IConfigurationSection weatherApiSection = _configuration.GetSection("WeatherApi");
            //ViewBag.WeatherApiClientId = weatherApiSection["Clientid"];
            //ViewBag.WeatherApiClientSecret = weatherApiSection["ClientSecret"];

            //Demonstrating the use of Options pattern
            //WeatherApiOptions options = _configuration.GetSection("WeatherApi").Get<WeatherApiOptions>();
            //ViewBag.WeatherApiClientId = options.ClientId;
            //ViewBag.WeatherApiClientSecret = options.ClientSecret;

            //Demonstrating the use of bind
            _configuration.GetSection("WeatherApi").Bind(_weatherApiOptions);
            ViewBag.WeatherApiClientId = _weatherApiOptions.ClientId;
            ViewBag.WeatherApiClientSecret = _weatherApiOptions.ClientSecret;

            return View();
        }
    }
}

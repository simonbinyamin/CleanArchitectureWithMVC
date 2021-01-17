using mediatR.Business.WeatherForecasts.Queries.GetWeatherForecasts;
using mediatR.DataAccess.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    public class WeatherForecastController : ApiControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public WeatherForecastController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;

        }

        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}

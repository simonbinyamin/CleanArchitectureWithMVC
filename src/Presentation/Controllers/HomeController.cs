using mediatR.Business.WeatherForecasts.Queries.GetWeatherForecasts;
using mediatR.DataAccess.Identity;
using mediatR.DataAccess.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using System.Diagnostics;


namespace MVC.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class HomeController : ApiControllerBase
    {


        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _context;
        public HomeController(ILogger<HomeController> logger, IHttpContextAccessor httpContextAccessor, 
            SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager,
            IHttpContextAccessor _httpContextAccessor,
            ApplicationDbContext context)
        {
            this._httpContextAccessor = _httpContextAccessor;
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [Route("")]
        [Route("/")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }
        [Route("/Error")]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

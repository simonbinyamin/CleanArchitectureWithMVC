using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace MVC.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class ApiControllerBase : Controller
    {
        private ISender _mediator;

       protected ISender Mediator {
            get {
                if (_mediator == null)
                {
                    _mediator = HttpContext.RequestServices.GetService<ISender>();
                }
                return _mediator;
            }
        }


    }



}

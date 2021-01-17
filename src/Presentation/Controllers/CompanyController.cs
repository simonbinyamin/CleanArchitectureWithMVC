using mediatR.Business.CompanyItems.Commands.CreateCompany;
using mediatR.Business.CompanyItems.Commands.DeleteCompany;
using mediatR.Business.CompanyItems.Commands.UpdateCompany;
using mediatR.Business.CompanyItems.Queries.GetCompanies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class CompanyController : ApiControllerBase
    {
        [Route("Index")]
         public async Task<ActionResult<IEnumerable<CompanyDto>>> Index()
        {
            var companies = await Mediator.Send(new GetCompaniesQuery());
            return View(companies);
        }

        [Route("GetCompaniesByIdOrName")]
        public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompaniesByIdOrName([FromQuery] GetCompaniesByIdOrNameQuery query)
        {
        
            var list = await Mediator.Send(query);

            return View();
        }

        [Route("GetCompany/{id}")]
        public async Task<ActionResult<CompanyDto>> GetCompany(int id)
        {
            var company= await Mediator.Send(new GetCompanyQuery { Id = id });


            return View();
        }

        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

   
        [Route("CreatePost")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult<int>> CreatePost([FromForm]CreateCompanyCommand command)
        {
            var id = await Mediator.Send(command);
            return RedirectToAction("Index",id);
        }


        [Route("Update/{id}")]
        public IActionResult Update(int id)
        {
            return View(id);
        }


        [Route("UpdatePost/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdatePost(int id, [FromForm]UpdateCompanyCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return RedirectToAction("Index", id);
        }

        [Route("Delete/{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteCompanyCommand { Id = id });

            return RedirectToAction("Index", id);
        }
    }
}

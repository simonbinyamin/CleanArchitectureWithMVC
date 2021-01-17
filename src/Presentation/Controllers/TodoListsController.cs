using mediatR.Business.TodoLists.Commands.CreateTodoList;
using mediatR.Business.TodoLists.Commands.DeleteTodoList;
using mediatR.Business.TodoLists.Commands.UpdateTodoList;
using mediatR.Business.TodoLists.Queries.ExportTodos;
using mediatR.Business.TodoLists.Queries.GetTodos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MVC.Controllers
{
    [Authorize]
    public class TodoListsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<TodosVm>> Get()
        {
            var t = await Mediator.Send(new GetTodosQuery());
            return t;
        }

        [HttpGet("{id}")]
        public async Task<FileResult> Get(int id)
        {
            var vm = await Mediator.Send(new ExportTodosQuery { ListId = id });

            return File(vm.Content, vm.ContentType, vm.FileName);
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateTodoListCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateTodoListCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteTodoListCommand { Id = id });

            return NoContent();
        }
    }
}

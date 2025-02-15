using MediatR;
using Microsoft.AspNetCore.Mvc;
using Todo.Application.Features.Todos.CreateTodo;
using Todo.Application.Features.Todos.DeleteTodoById;
using Todo.Application.Features.Todos.GetAllTodos;
using Todo.Application.Features.Todos.UpdateTodoById;

namespace Todo.WebApimiz.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    /// primary constructor ozelliği c# 12 ile ve .net 8 il geldi
    public class TodosController(IMediator mediator) : ControllerBase
    {


        [HttpPost]
        public async Task<IActionResult> Create(CreateTodoCommand command, CancellationToken cancellationToken)
        {
            await mediator.Send(command, cancellationToken);
            return Created();
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
        {
            GetAllTodoQuery request = new();
            List<GetAllTodoQueryResponse> todos=await mediator.Send(request, cancellationToken);
            return Ok(todos);
        }
        [HttpPut]
        public async Task<IActionResult> Update(UpdateTodoCommand request, CancellationToken cancellation)
        {
            await mediator.Send(request, cancellation);
            return Ok();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteById(Guid id, CancellationToken cancellationtoken)
        {
            DeleteTodoByIdCommand request = new(id);
            await mediator.Send(request, cancellationtoken);
            return Ok();
        }
    }
}

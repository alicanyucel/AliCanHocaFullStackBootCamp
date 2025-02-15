

using MediatR;
using Todo.Domain.Models;

namespace Todo.Application.Features.Todos.GetAllTodos;
internal sealed class GetAllTodoQueryHandler(ITodoRepository todoRepository) : IRequestHandler<GetAllTodoQuery, List<GetAllTodoQueryResponse>>
{
    public async Task<List<GetAllTodoQueryResponse>> Handle(GetAllTodoQuery request, CancellationToken cancellationToken)
    {
       List<Domain.Models.Todo> todos=await todoRepository.GetAllAsync(cancellationToken);
       List<GetAllTodoQueryResponse> responses=todos.Select(s=> new GetAllTodoQueryResponse(s.Id,s.Work,s.DeadLine,s.IsCompleted,s.Work)).ToList();
        return responses;
    }
}




using MediatR;

namespace Todo.Application.Features.Todos.CreateTodo;

internal sealed class CreateTodoCommandHandler(Domain.Models.ITodoRepository todoRepository) : IRequestHandler<CreateTodoCommand>
{
    public async Task Handle(CreateTodoCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Todo todo = new()
        {
            Id = Guid.NewGuid(),
            Work = request.Work,
            DeadLine = request.DeadLine,
            Note = request.Note,
            IsCompleted=false,
        };
        await todoRepository.AddAsync(todo,cancellationToken);
    }
}


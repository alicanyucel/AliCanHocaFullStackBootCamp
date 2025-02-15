
using MediatR;
using Todo.Domain.Models;

namespace Todo.Application.Features.Todos.DeleteTodoById;

internal sealed class DeleteTodoByIdCommandHandler(ITodoRepository todoRepository) : IRequestHandler<DeleteTodoByIdCommand>
{
    public async Task Handle(DeleteTodoByIdCommand request, CancellationToken cancellationToken)
    {
        Domain.Models.Todo? todo = await todoRepository.GetByIdAsync(request.id, cancellationToken);
        if (todo is null)
        {
            throw new ArgumentNullException("todo yok");
        }
        await todoRepository.DeleteAsync(todo, cancellationToken);
    }
}
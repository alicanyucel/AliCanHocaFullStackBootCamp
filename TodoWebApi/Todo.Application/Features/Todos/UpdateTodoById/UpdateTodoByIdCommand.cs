

using MediatR;
using Todo.Domain.Models;

namespace Todo.Application.Features.Todos.UpdateTodoById;

internal sealed class UpdateTodoCommandHandler(ITodoRepository todoRepository) : IRequestHandler<UpdateTodoCommand>
{
    public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
    {
       Domain.Models.Todo? todo = await todoRepository.GetByIdAsync(request.Id, cancellationToken);
        if (todo is null)
        {
            throw new ArgumentNullException("todo kaydı yok");

        }
        todo.Work = request.Work;
        todo.DeadLine = request.DeadLine;
        todo.Note = request.Note;
        todo.IsCompleted = request.IsCompleted;
        await todoRepository.UpdateAsync(todo, cancellationToken);
    }
}
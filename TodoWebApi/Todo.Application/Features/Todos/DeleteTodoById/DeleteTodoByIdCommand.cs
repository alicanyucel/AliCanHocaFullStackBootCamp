

using MediatR;

namespace Todo.Application.Features.Todos.DeleteTodoById;
public sealed record DeleteTodoByIdCommand(Guid id) : IRequest;

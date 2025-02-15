

using MediatR;

namespace Todo.Application.Features.Todos.UpdateTodoById;

public sealed record UpdateTodoCommand(Guid Id, string Work, DateOnly DeadLine, string? Note, bool IsCompleted) : IRequest;
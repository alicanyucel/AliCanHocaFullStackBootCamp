

namespace Todo.Application.Features.Todos.GetAllTodos;

public sealed record GetAllTodoQueryResponse(Guid id, string Work, DateOnly Deadline, bool IsCompleted, string? Note);

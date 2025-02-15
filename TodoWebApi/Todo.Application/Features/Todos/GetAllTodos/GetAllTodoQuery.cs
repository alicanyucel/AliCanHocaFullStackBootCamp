
using MediatR;

namespace Todo.Application.Features.Todos.GetAllTodos;

public sealed record GetAllTodoQuery():IRequest<List<GetAllTodoQueryResponse>>;




using MediatR;

namespace Todo.Application.Features.Todos.CreateTodo;

// record oldugu için recordun classtan farkı propertyleri fieldleri parametre olaak () veriyoruz
public sealed record CreateTodoCommand(string Work, DateOnly DeadLine, string? Note) : IRequest;

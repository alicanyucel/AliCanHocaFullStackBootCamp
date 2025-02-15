using Microsoft.EntityFrameworkCore;
using Todo.Application.Features.Todos.CreateTodo;
using Todo.Domain.Models;
using Todo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// context di servis register
builder.Services.AddScoped<ITodoRepository, TodoRepository>();
// mediatr kutuphanesinide register edelin
builder.Services.AddMediatR(configuration =>
          configuration.RegisterServicesFromAssembly(typeof(CreateTodoCommand).Assembly));
builder.Services.AddDbContext<ApplicationDbContext>(action =>
{
    action.UseSqlServer("Server=DESKTOP-L6NJT48\\SQLEXPRESS;" +
        "Initial Catalog=ExamplesTodoDb;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;" +
        "Application Intent=ReadWrite;Multi Subnet Failover=False");
});
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi


builder.Services.AddSwaggerGen();
var app = builder.Build();

// Configure the HTTP request pipeline.
// burasý geliþtirme product ve test ortamý için bir yapý
if (app.Environment.IsDevelopment()) // þuan geliþtirme ortamýnda calýsýyor
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

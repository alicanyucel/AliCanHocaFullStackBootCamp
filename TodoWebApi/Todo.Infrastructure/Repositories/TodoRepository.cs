
using Microsoft.EntityFrameworkCore;
using Todo.Domain.Models;

namespace Todo.Infrastructure.Repositories;

public sealed class TodoRepository(ApplicationDbContext context) : ITodoRepository
{
    public async Task AddAsync(Domain.Models.Todo item, CancellationToken cancellationToken = default)
    {
        // BURAYA EKLEME İŞLEMİ YAPTIK
        await context.AddAsync(item, cancellationToken);
        // KAYDEDİLMESİ İÇİN
        await context.SaveChangesAsync(); // savecahnges veri tabanına kaydediyor yaptıgım ekleme işlemini
    }

    public async Task DeleteAsync(Domain.Models.Todo item, CancellationToken cancellationToken = default)
    {
        // silme işlemi
        context.Remove(item);
        await context.SaveChangesAsync();

    }

    public async Task<List<Domain.Models.Todo>> GetAllAsync(CancellationToken cancellationToken = default)
    {
        return await context.Todos.ToListAsync(cancellationToken);
       
    }

    public async Task<Domain.Models.Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await context.Todos.FindAsync(id,cancellationToken);
    }

    public async Task UpdateAsync(Domain.Models.Todo item, CancellationToken cancellationToken = default)
    {
       context.Update(item);
       await context.SaveChangesAsync(cancellationToken);
    }
}

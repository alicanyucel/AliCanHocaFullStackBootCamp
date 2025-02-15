
using Microsoft.EntityFrameworkCore;
namespace Todo.Domain.Models;
public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions opt) : base(opt)
    {
    }
   public DbSet<Todo> Todos { get; set; }
}

// DESKTOP-L6NJT48\SQLEXPRESS SQL SUNCNUN ADI
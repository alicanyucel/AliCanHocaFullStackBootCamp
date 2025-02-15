
namespace Todo.Domain.Models;
// inernal aynı namesapcae içerinden eriilebilir
//public ise her yerden erişlebilir
public interface ITodoRepository
{
    // task gördüğünüz yerde asenkron bir işlem vardor cancellationtoken işlem devam ediyor anlamında asenkron oldugu için vermem gerekşyor best practise olarak
    Task AddAsync(Todo item,CancellationToken cancellationToken=default);

    Task UpdateAsync(Todo item, CancellationToken cancellationToken = default);

    Task DeleteAsync(Todo item, CancellationToken cancellationToken = default);

    Task<List<Todo>> GetAllAsync(CancellationToken cancellationToken = default);

    Task<Todo?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

}

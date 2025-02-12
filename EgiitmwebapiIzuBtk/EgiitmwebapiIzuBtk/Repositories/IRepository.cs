namespace EgiitmwebapiIzuBtk.Repositories
{
    // interface oluşturduk Repository class içerinde dolduracaz
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync(); // listleme işlemi için asenkron donecek
        Task<TEntity> GetByIdAsync(int id); // ıd ye göre getirecek
        Task Create(TEntity entity); // async olarak ekleyecek
        void Update(TEntity entity); //bu güncelleme işlemi için
        void Delete(TEntity entity); // bu da silme işlemi için

    }
}

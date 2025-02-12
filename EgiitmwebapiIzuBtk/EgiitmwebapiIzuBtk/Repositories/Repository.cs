
using EgiitmwebapiIzuBtk.DataContext;
using Microsoft.EntityFrameworkCore;

namespace EgiitmwebapiIzuBtk.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        // DEPENCENCY INJECTİON YAPMMAIZ LAZM
        private readonly ApplicationDbContext _context;
        private readonly DbSet<TEntity> _dbset; // dbset ile istediğim tabloya ulaşmamı sağlıyor
        public Repository(ApplicationDbContext context)
        {
            // context üzerinden bütün işlemelere _context ile erişebilecem
            _context = context;
            _dbset=_context.Set<TEntity>(); // t entitye hangi entityi verirsem dbset üzerinden ona ulaşabilirim
        }
        //
        public async Task Create(TEntity entity)
        {
         await _dbset.AddAsync(entity);
         await _context.SaveChangesAsync(); // değişiklerin yansıması için bunu unutmuusz
        }

        public void Delete(TEntity entity)
        {
            _dbset.Remove(entity);
            _context.SaveChanges(); // değişikleri kaydeder
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            // bana listeyi dön yai verilerin hepsini getir liste halinde getir
           return await _dbset.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public void Update(TEntity entity)
        {
            // entiynn durumu güncellendikçe değiştikce algılıyor ve günelleme işlemi yaıyor
           _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();  // değişikleri kaydeden kod
        }
    }
}

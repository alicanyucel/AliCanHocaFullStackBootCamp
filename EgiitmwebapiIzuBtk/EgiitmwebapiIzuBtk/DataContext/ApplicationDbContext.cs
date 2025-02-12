using EgiitmwebapiIzuBtk.Models;
using Microsoft.EntityFrameworkCore;


namespace EgiitmwebapiIzuBtk.DataContext
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions opt) : base(opt) { }
        
            //   entity oluşturulacak tablo adı
           DbSet<Personel> Personels { get; set; } // get okunabilir se değiştirilebili insert update delete gibi
        // tablo isimleri best practise olaraktan coğul olarak isimlendiirlir verilir
        
    }
}

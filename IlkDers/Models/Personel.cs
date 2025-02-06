using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IlkDers.Models
{
    // veri tabanındaki tablonun içeriğini burada entity ve property olarak karşıladık
    public class Personel // bu enityudir
    {
        public int Id { get; set; } // propryilerd,r
        public string Ad { get;set; }  // propryilerd,r
        public string Soyad { get; set; }  // propryilerd,r
        public string Brans { get;set; } // propryilerd,r

    }
}



using IlkDers.Models;
using System.Data;
using System.Data.SqlClient;

namespace IlkDers.DataAccessLayer
{
    // burada crud operasyonlarını yapacağımız yer
    //brans bizi yaktı.
    public class PersonelDal
    {
        //serverin localdeki adresi                       //sunucu adresi.................... //database............. //wimdoew authanticationn 
                                                                                                                     //şifre ve paralo girmeden
        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-L6NJT48\\SQLEXPRESS;Initial Catalog=IlkDers;Integrated Security=True");
               //geriye değer dondurmezse void olur
        public   void ConnectionKontrol()
        {
                      //bağlantı kapalıysa
            if(connection.State==ConnectionState.Closed)
            {
                connection.Open(); // bağlantıyı aç
            }
        }
        // datatable aslında server side calısıyor en cok kullanılan yapı verileri dolduracak listeleyecek
        public DataTable GetAll() // Crud operasyonlarında Readin Yerine Kullanılır
        {
            // BEST PARACTİTSE OLARAK
            // ConnectionKontrol()
            // VEYA
            ConnectionKontrol(); // BAĞLANTI KAPALIYSA BAĞLANTIYI AÇAN FONKSİYON
            // SqlCommand tipinden command adı altında bir nesne oluşturdum ve ornekledim
            // SqlCommand 2 tane parametre alır 1.sorgu 2. si bağlantı
            SqlCommand command = new SqlCommand("Select * from Personel",connection);
            // verileri okumak için SqlDataReadr var 
            SqlDataReader reader = command.ExecuteReader(); // komutu çalıştırıyor okuma işlemi yapıldı
            // Datatable dan dt adında nesne ürettik okduugmuz veriler dtnin içine atılacak
            DataTable dt = new DataTable();
            dt.Load(reader); // budada reader SqlDaraReaderin readaer nesnesinden gelen verileri dt dolduruyor
            reader.Close(); // okuma işlemini sonlandırdık.
            connection.Close(); // bağlantıyı kapattık
            return dt; // datatable i donmemiz gerekiyor
        }
        public void Ekle(Personel personel)
        {
            // insert sorgusu yazıyoruz string deeğrler " bunların içine yazılır   "
            //tablo ismi // tablo sutunları
            // personel tablosunun ad soyad brans degerlerine   dısardan godnereceğim değerleri ekle
            string kayit = "Insert into Personel(Ad,Soyad,Brans) values(@ad,@soyad,@brans)"; // sql stringsel sorgu
            //bağlantının durumu kapalıysa
            if(connection.State == ConnectionState.Closed)
             {
                connection.Open(); //bağlantıyı aç
            }
            // komut calıstıracaz
            SqlCommand ekle=new SqlCommand(kayit,connection);
            // komuta parametre olarak classtan işaretlediğim yerlere veri gonderiyorum.
            ekle.Parameters.AddWithValue("@ad",personel.Ad); // ad=ali ad=personel.ad ile aynı
            ekle.Parameters.AddWithValue("@soyad", personel.Soyad);
            ekle.Parameters.AddWithValue("@brans",personel.Brans);
            // komutu calıstırmam lazım
            ekle.ExecuteNonQuery(); //komutu çalıştır ekleme işlemlerim bitti
            // bağantııyı kapatıyoruz
            connection.Close(); // İşlem bitti bağlantıyı kapat

        } // ekleme işlemi bitt ekleme işlemi Crud da C ye karşıık Gelir C=Create demek
        // silme işlemi silme işlemi Crudda Delete ye karsılık yani D ye karsılık gelir
        public void Delete(int Id) // parametre sayısal veri tiipinden Id int 32 bitlik 4 bytlik yer kaplar
        {

            //if(connection.State==ConnectionState.Closed)
            //{
            //    connection.Open();
            //}
            ConnectionKontrol();
                                              // person tablosnun id değer parametre olarak @id değerine eşitse sil 
            SqlCommand command = new SqlCommand("Delete from Personel where Id=@id",connection);
            command.Parameters.AddWithValue("@id",Id); //@id=id
            command.ExecuteNonQuery();//komutu calısıtrdım. sildim işlem bitti
            connection.Close(); //bağlantı işlem bitince yok edildi.

        }
        // güncelleme işlemi
        public void Update(Personel personel)
        {
            // bransı güncellemiyor
            ConnectionKontrol(); //bağlantıyı açan test eden metod
            //// 1.yol
            //string guncelleSorgu = "Update Person Set ad=@ad,soyad=@soyad,brans=@brans where id=@id";
            //SqlCommand cmd=new SqlCommand(guncelleSorgu,connection);
            // 2. yol şu şekilde ///                                                  bransı güncellemedi
            SqlCommand cmd = new SqlCommand("Update Personel Set Ad=@ad,Soyad=@soyad,brans=@brans where Id=@id",connection);
            // dısardan geelcek olan @ad ,@soyad @id değerlerini personel.ad pesonel soyad p.ID ile set ediyorum
            cmd.Parameters.AddWithValue("@id", personel.Id);
            cmd.Parameters.AddWithValue("@ad",personel.Ad);
            cmd.Parameters.AddWithValue("@soyad", personel.Soyad);
            cmd.Parameters.AddWithValue("@brans",personel.Brans);
            cmd.ExecuteNonQuery();// sorguyu calıstırdık güncelleme işlmi bitti
            connection.Close(); // yok ediyoruz

            // şuanda bütün Crud (ekleme silme listeleme güncelleme işlemleri bitti tasarım kısmı kaldı)
            // Crud Create(ekleme) Read(Listeleme) Update(Güncelleme) Delete(silme) işlemi anlamına gelir.
        }

    }
}

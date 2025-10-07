using Microsoft.EntityFrameworkCore;

namespace e_ticaret_proje.Models;

public class DataContext : DbContext
{
    //constructor tanımlamamız lazım
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Urun> Urunler { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Urun>().HasData(
            new List<Urun>()
            {
                new Urun(){ Id=1, UrunAdi="Apple Watch 1" , Fiyat=10000, Aktif=false,Resim="1.jpeg",Anasayfa=true,Aciklama="lorem falan filanfalan"},
                new Urun(){ Id=2, UrunAdi="Apple Watch 2" , Fiyat=20000, Aktif=true,Resim="2.jpeg",Anasayfa=true,Aciklama="lorem falan filanfalan"},
                new Urun(){ Id=3, UrunAdi="Apple Watch 3" , Fiyat=30000, Aktif=true,Resim="3.jpeg",Anasayfa=false,Aciklama="lorem falan filanfalan"},
                new Urun(){ Id=4, UrunAdi="Apple Watch 4" , Fiyat=40000, Aktif=false,Resim="4.jpeg",Anasayfa=true,Aciklama="lorem falan filanfalan"},
                new Urun(){ Id=5, UrunAdi="Apple Watch 5" , Fiyat=50000, Aktif=true,Resim="5.jpeg",Anasayfa=true,Aciklama="lorem falan filanfalan"},
                new Urun(){ Id=6, UrunAdi="Apple Watch 6" , Fiyat=60000, Aktif=true,Resim="6.jpeg",Anasayfa=false,Aciklama="lorem falan filanfalan"}

            }
        );

    }
}

//DataContext _context = new DataContext();






//migrations oluşturmak lazım veritabanına aktarılması için
//ondan önce veritabanına bağlamak için bi connection string lazım
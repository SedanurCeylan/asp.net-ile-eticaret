using Microsoft.EntityFrameworkCore;

namespace e_ticaret_proje.Models;

public class DataContext : DbContext
{
    //constructor tanımlamamız lazım
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {

    }
    public DbSet<Urun> Urunler { get; set; }

    public DbSet<Kategori> Kategoriler { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Kategori>().HasData(
            new List<Kategori>()
            {
                new Kategori(){ Id=1, KategoriAdı="Telefon", Url="telefon"},
                new Kategori(){ Id=2, KategoriAdı="Elektronik", Url="elektronik"},
                new Kategori(){ Id=3, KategoriAdı="Beyaz Eşya", Url="beyaz-esya"},
                new Kategori(){ Id=4, KategoriAdı="Kozmetik", Url="kozmetik"},
                new Kategori(){ Id=5, KategoriAdı="Giyim", Url="giyim"},
            }
        );

        modelBuilder.Entity<Urun>().HasData(
            new List<Urun>()
            {
                new Urun(){ Id=1, UrunAdi="Apple Watch 1" , Fiyat=10000, Aktif=false,Resim="1.jpeg",Anasayfa=true,Aciklama="lorem falan filanfalan", KategoriId=1},
                new Urun(){ Id=2, UrunAdi="Apple Watch 2" , Fiyat=20000, Aktif=true,Resim="2.jpeg",Anasayfa=true,Aciklama="lorem falan filanfalan",KategoriId=2},
                new Urun(){ Id=3, UrunAdi="Apple Watch 3" , Fiyat=30000, Aktif=true,Resim="3.jpeg",Anasayfa=false,Aciklama="lorem falan filanfalan",KategoriId=3},
                new Urun(){ Id=4, UrunAdi="Apple Watch 4" , Fiyat=40000, Aktif=false,Resim="4.jpeg",Anasayfa=true,Aciklama="lorem falan filanfalan",KategoriId=4},
                new Urun(){ Id=5, UrunAdi="Apple Watch 5" , Fiyat=50000, Aktif=true,Resim="5.jpeg",Anasayfa=true,Aciklama="lorem falan filanfalan",KategoriId=4},
                new Urun(){ Id=6, UrunAdi="Apple Watch 6" , Fiyat=60000, Aktif=true,Resim="6.jpeg",Anasayfa=false,Aciklama="lorem falan filanfalan",KategoriId=1}

            }
        );

    }
}

//DataContext _context = new DataContext();






//migrations oluşturmak lazım veritabanına aktarılması için
//ondan önce veritabanına bağlamak için bi connection string lazım
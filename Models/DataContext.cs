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

         modelBuilder.Entity<Slider>().HasData(
            new List<Slider>()
            {
                new Slider(){ Id=1, Baslik="Slider 1 Başlık", Aciklama="Slider 1", Resim="slider-1.jpeg", Aktif=true, Index=0},
                new Slider(){ Id=2, Baslik="Slider 2 Başlıkk", Aciklama="Slider 2", Resim="slider-2.jpeg", Aktif=true, Index=1},
                new Slider(){ Id=3, Baslik="Slider 3 Başlık", Aciklama="Slider 3", Resim="slider-3.jpeg", Aktif=true, Index=2},
                new Slider(){ Id=4, Baslik="Slider 4 Başlık", Aciklama="Slider 4", Resim="slider-1.jpeg", Aktif=true, Index=3},
                new Slider(){ Id=5, Baslik="Slider 5 Başlık", Aciklama="Slider 5", Resim="slider-2.jpeg", Aktif=true, Index=4},
                new Slider(){ Id=6, Baslik="Slider 6 Başlık", Aciklama="Slider 6", Resim="slider-3.jpeg", Aktif=true, Index=5}
            }
        );


        modelBuilder.Entity<Kategori>().HasData(
            new List<Kategori>()
            {
                new Kategori(){ Id=1, KategoriAdi="Telefon", Url="telefon"},
                new Kategori(){ Id=2, KategoriAdi="Elektronik", Url="elektronik"},
                new Kategori(){ Id=3, KategoriAdi="Beyaz Eşya", Url="beyaz-esya"},
                new Kategori(){ Id=4, KategoriAdi="Kozmetik", Url="kozmetik"},
                new Kategori(){ Id=5, KategoriAdi="Giyim", Url="giyim"},
                new Kategori(){ Id=6, KategoriAdi="Kategori 1", Url="Kategori-1"},
                new Kategori(){ Id=7, KategoriAdi="Kategori 2", Url="Kategori-2"},
                new Kategori(){ Id=8, KategoriAdi="Kategori 3", Url="Kategori-3"},
                new Kategori(){ Id=9, KategoriAdi="Kategori 4", Url="Kategori-4"},
                new Kategori(){ Id=10, KategoriAdi="Kategori 5", Url="Kategori-5"},
                new Kategori(){ Id=11, KategoriAdi="Kategori 6", Url="Kategori-6"}
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
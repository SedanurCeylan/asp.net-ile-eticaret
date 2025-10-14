using System.ComponentModel.DataAnnotations;
namespace e_ticaret_proje.Models;

//TEK VALİDE ETMEMEK İÇİN
public class UrunModel
{


    [Required(ErrorMessage = "Ürün Adı Giriniz!")]
    [StringLength(50, ErrorMessage = "Ürün adı için {2}-{1} aralığında değer girmelisiniz.", MinimumLength = 8)]
    [Display(Name = "Ürün Adı:")]
    public string UrunAdi { get; set; } = null!;


    [Required(ErrorMessage = "Ürün Fiyatı Giriniz!")]
    [Display(Name = "Ürün Fiyat:")]
    [Range(0.01, double.MaxValue, ErrorMessage = "Lütfen sadece sayısal ve pozitif bir değer giriniz!")]
    public double? Fiyat { get; set; }



    [Display(Name = "Ürün Resmi:")]
    public IFormFile? Resim { get; set; }


    
    [StringLength(3000, ErrorMessage = "Girilen geğer {0} karakterden fazla olamaz!")]
    [Display(Name = "Ürün Açıklaması:")]
    public string? Aciklama { get; set; }



    [Display(Name = "Aktif mi? :")]
    public bool Aktif { get; set; }



    [Display(Name = "Anasayfada mı? :")]
    public bool Anasayfa { get; set; }

    [Display(Name = "Kategori:")]
    [Required(ErrorMessage = "Kategori Seçiniz!")]
    public int? KategoriId { get; set; }
}
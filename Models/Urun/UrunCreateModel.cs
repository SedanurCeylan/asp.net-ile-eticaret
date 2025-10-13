using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class UrunCreateModel
{

    [Display(Name = "Ürün Adı:")]
    public string UrunAdi { get; set; } = null!;

    [Display(Name = "Ürün Fiyat:")]
    public double Fiyat { get; set; }

    [Display(Name = "Ürün Resmi:")]
    public string? Resim { get; set; }

    [Display(Name = "Ürün Açıklaması:")]
    public string? Aciklama { get; set; }

    [Display(Name = "Aktif mi? :")]
    public bool Aktif { get; set; }

    [Display(Name = "Anasayfada mı? :")]
    public bool Anasayfa { get; set; }

    public int KategoriId { get; set; }
}
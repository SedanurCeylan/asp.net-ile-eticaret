using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class KategoriCreateModel
{

    [Required(ErrorMessage = "Kategori Adı Giriniz!")]
    [StringLength(30)] //max 20 karakter
    [Display(Name = "Kategori Adı: ")]
    public string KategoriAdi { get; set; } = null!;

    [Required(ErrorMessage = "URL alanı Giriniz!")]
    [StringLength(30)]
    [Display(Name = "URL: ")]
    public string Url { get; set; } = null!;
}
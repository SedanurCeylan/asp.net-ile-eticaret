using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class KategoriCreateModel
{
    [Display(Name = "Kategori Adı: ")]
    public string KategoriAdi { get; set; } = null!;
    
    [Display(Name = "URL: ")]
    public string Url { get; set; } = null!;
}
using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class KategoriEditModel
{
    public int Id { get; set; }
    
    [Display(Name = "Kategori Adı: ")]
    public string KategoriAdi { get; set; } = null!;
    
    [Display(Name = "URL: ")]
    public string Url { get; set; } = null!;
}
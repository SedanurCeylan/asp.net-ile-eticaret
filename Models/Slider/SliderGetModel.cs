namespace e_ticaret_proje.Models;


//burası model sadece veri taşımak için dieğri entity veri tabanı tablosu
public class SliderGetModel 
{
    public int Id { get; set; }
    public string? Baslik { get; set; }
    public string Resim { get; set; } = null!;
    public int Sira { get; set; }
    public bool Aktif { get; set; }

}
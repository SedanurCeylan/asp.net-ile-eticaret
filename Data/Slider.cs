namespace e_ticaret_proje.Data;

public class Slider
{
    public int Id { get; set; }
    public string? Baslik { get; set; }
    public string? Aciklama { get; set; }
    public string Resim { get; set; } = null!;
    public int Sira { get; set; }
    public bool Aktif { get; set; }


}
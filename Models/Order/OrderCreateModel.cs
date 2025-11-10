namespace e_ticaret_proje.Models;

public class OrderCreateModel
{
    public string AdSoyad { get; set; }= null!;
    public string Sehir { get; set; } = null!;
    public string AdresSatiri { get; set; } = null!;
    public string PostaKodu { get; set; } = null!;
    public string Telefon { get; set; } = null!;
    public string? SiparisNotu { get; set; }

}
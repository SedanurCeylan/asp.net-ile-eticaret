namespace e_ticaret_proje.Models;

public class Urun
{
    public int Id { get; set; }
    public string UrunAdi { get; set; } = null!;
    public double Fiyat { get; set; }   
    public bool Aktif { get; set; }
}



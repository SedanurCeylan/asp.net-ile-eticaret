namespace e_ticaret_proje.Models;


//burası model sadece veri taşımak için dieğri entity veri tabanı tablosu
public class KategoriGetModel
{
    public int Id { get; set; }
    public string KategoriAdi { get; set; } = null!;
    public string Url { get; set; } = null!;
    //ürünlerin ismini tutması gereksiz diye sadece sayısını aldık 
    public int UrunSayisi { get; set; }
}
using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class UrunEditModel : UrunModel
{

    public int Id { get; set; }
    public string? ResimAdi { get; set; }
    
}



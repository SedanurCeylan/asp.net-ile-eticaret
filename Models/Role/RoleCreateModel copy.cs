using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class RoleCreateModel
{

    [Required(ErrorMessage = "Kategori Adı Giriniz!")]
    [StringLength(30)] 
    [Display(Name = "Role Adı: ")]
    public string RoleAdi { get; set; } = null!;
}
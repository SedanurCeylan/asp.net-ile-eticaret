using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class AccountEditUserModel
{
    [Display(Name = "Ad Soyad:")]
    public string AdSoyad { get; set; } = null!;


    [Display(Name = "E-Posta:")]
    [EmailAddress]
    public string Email { get; set; } = null!;


    


}
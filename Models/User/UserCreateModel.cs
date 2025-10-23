using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class UserCreateModel
{
    [Required(ErrorMessage = "Adınızı ve Soyadınızı Giriniz.")]
    [Display(Name = "Ad Soyad:")]
    public string AdSoyad { get; set; } = null!;


    [Required(ErrorMessage = "E-Posta girmek zorunludur.")]
    [Display(Name = "E-Posta:")]
    [EmailAddress]
    public string Email { get; set; } = null!;


    


}
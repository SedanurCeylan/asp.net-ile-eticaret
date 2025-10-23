using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class UserEditModel
{
    [Required(ErrorMessage = "Adınızı ve Soyadınızı Giriniz.")]
    [Display(Name = "Ad Soyad:")]
    public string AdSoyad { get; set; } = null!;


    [Required(ErrorMessage = "E-Posta girmek zorunludur.")]
    [Display(Name = "E-Posta:")]
    [EmailAddress]
    public string Email { get; set; } = null!;
   
    [Display(Name = "Parola:")]
    [DataType(DataType.Password)]
    public string? Password { get; set; } = null!;

    [Display(Name = "Parola(Tekrar):")]
    [DataType(DataType.Password)]
    [Compare("Password", ErrorMessage = "Parolalar eşleşmiyor")]
    public string? ConfirmPassword { get; set; } = null!;


    public IList<string>? SecilenRoller { get; set; }

}
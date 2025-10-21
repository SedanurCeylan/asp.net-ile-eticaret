using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class AccountCreateModel
{

    // [Required(ErrorMessage = "Kullanıcı Adı zorunludur.")]
    // [Display(Name = "Kullanıcı Adı:")]
    // [RegularExpression("^[a-zA-Z0-9._-]+$", ErrorMessage = "Sadece a-z / A-Z / 0-9 / . / _ / - karakterlerine izin verilir.")]
    // public string Username { get; set; } = null!;

    [Required(ErrorMessage = "Adınızı ve Soyadınızı Giriniz.")]
    [Display(Name = "Ad Soyad:")]
    public string AdSoyad { get; set; } = null!;


    [Required(ErrorMessage = "E-Posta girmek zorunludur.")]
    [Display(Name = "E-Posta:")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Parola girmek zorunludur.")]
    [Display(Name = "Parola:")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Parola girmek zorunludur.")]
    [Display(Name = "Parola(Tekrar):")]
    [DataType(DataType.Password)]
    [Compare("Password" , ErrorMessage = "Parolalar eşleşmiyor")]
    public string ConfirmPassword { get; set; } = null!;

}
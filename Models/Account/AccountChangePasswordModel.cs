using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class AccountChangePasswordModel
{
    [Required(ErrorMessage = "Parola girmek zorunludur.")]
    [Display(Name = "Mevcut Parola:")]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; } = null!;

    [Required(ErrorMessage = "Parola girmek zorunludur.")]
    [Display(Name = "Yeni Parola:")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    [Required(ErrorMessage = "Parola girmek zorunludur.")]
    [Display(Name = "Yeni Parola(Tekrar):")]
    [DataType(DataType.Password)]
    [Compare("Password" , ErrorMessage = "Parolalar eşleşmiyor")]
    public string ConfirmPassword { get; set; } = null!;

}
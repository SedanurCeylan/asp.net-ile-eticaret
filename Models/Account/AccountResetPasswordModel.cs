using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class AccountResetPasswordModel
{

    public string Token { get; set; } = null!;

    public string Email { get; set; } = null!;


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
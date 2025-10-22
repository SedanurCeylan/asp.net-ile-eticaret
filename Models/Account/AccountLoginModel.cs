using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models;

public class AccountLoginModel
{

    [Required(ErrorMessage = "E-Posta girmek zorunludur.")]
    [Display(Name = "E-Posta:")]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Required(ErrorMessage = "Parola girmek zorunludur.")]
    [Display(Name = "Parola:")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = null!;

    public bool BeniHatirla { get; set; } = true;
}
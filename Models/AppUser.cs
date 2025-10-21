using Microsoft.AspNetCore.Identity;

namespace e_ticaret_proje.Models;

public class AppUser : IdentityUser<int>
{
    public string AdSoyad { get; set; } = null!;

}

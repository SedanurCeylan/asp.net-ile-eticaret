using Microsoft.AspNetCore.Identity;

namespace e_ticaret_proje.Data;

public class AppUser : IdentityUser<int>
{
    public string AdSoyad { get; set; } = null!;

}

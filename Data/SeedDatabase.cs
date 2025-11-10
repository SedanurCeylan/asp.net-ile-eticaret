using Microsoft.AspNetCore.Identity;

namespace e_ticaret_proje.Data;


// database silindiğinde bile default bir admin kullanıcısı olsun diye
public static class SeedDatabase
{
    public static async void Initialize(IApplicationBuilder app)
    {
        var userManager = app.ApplicationServices
                            .CreateScope()
                            .ServiceProvider
                            .GetRequiredService<UserManager<AppUser>>();

        var roleManager = app.ApplicationServices
                            .CreateScope()
                            .ServiceProvider
                            .GetRequiredService<RoleManager<AppRole>>();

        if (!roleManager.Roles.Any())
        {
            var admin = new AppRole { Name = "Admin" };
            await roleManager.CreateAsync(admin);
        }

        if (!userManager.Users.Any())
        {
            var admin = new AppUser
            {
                AdSoyad = "Sedonur Ceylan",
                UserName = "sedos",
                Email = "sdnrcyln2@gmail.com"
            };


            await userManager.CreateAsync(admin, "admin32");
            await userManager.AddToRoleAsync(admin, "Admin");
        }
    }
}
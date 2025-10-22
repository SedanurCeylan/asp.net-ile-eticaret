using System.Threading.Tasks;
using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace e_ticaret_proje.Controllers;

public class AccountController : Controller
{

    private UserManager<AppUser> _userManager;
    private SignInManager<AppUser> _signInManager;


    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(AccountCreateModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                AdSoyad = model.AdSoyad
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Login()
    {
        // Sayfa ilk açıldığında boş model gönderiyoruz
        return View(new AccountLoginModel());
    }
    public async Task<ActionResult> Login(AccountLoginModel model , string? returnUrl)
    {

        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user != null)
            {
                await _signInManager.SignOutAsync();
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, model.BeniHatirla, true);

                if (result.Succeeded)
                {
                    await _userManager.ResetAccessFailedCountAsync(user);
                    await _userManager.SetLockoutEndDateAsync(user, null);
                    

                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else RedirectToAction("Index", "Home");

                }
                //hesabın kilitlenmesi durumu
                else if (result.IsLockedOut)
                {
                    var lockoutDate = await _userManager.GetLockoutEndDateAsync(user);
                    var timeleft = lockoutDate.Value - DateTime.UtcNow;
                    ModelState.AddModelError("", $"Hesabınız Kilitlendi. Lütfen {timeleft.Minutes + 1} dakika sonra tekrar deneyiniz.");
                }
                else
                {
                    ModelState.AddModelError("", "Hatalı Parola");
                }

            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Bulunamadı.");
            }
        }
        return View();
    }

    public async Task<ActionResult> Logout()
    {
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }


    //kimlik doğrulaması yapmadan giremesin
    [Authorize]
    public IActionResult Settings()
    {

        return View();
    }

} 
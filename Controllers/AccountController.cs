using System.Security.Claims;
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
    private IEmailService _emailService;


    public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IEmailService emailService)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _emailService = emailService;
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

    public async Task<ActionResult> Login(AccountLoginModel model, string? returnUrl)
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
                    else
                        return RedirectToAction("Index", "Home");

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

    [Authorize]
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

    [Authorize]
    public async Task<ActionResult> EditUser()
    {
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        var user = await _userManager.FindByIdAsync(userId!);

        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        return View(new AccountEditUserModel
        {
            AdSoyad = user.AdSoyad,
            Email = user.Email!
        });
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult> EditUser(AccountEditUserModel model)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId!);

            if (user != null)
            {
                user.Email = model.Email;
                user.AdSoyad = model.AdSoyad;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    TempData["Mesaj"] = "Bilgileriniz güncellendi";
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        return View(model);
    }

    public ActionResult AccessDenied()
    {
        return View();
    }


    [Authorize]
    public ActionResult ChangePassword()
    {
        return View();
    }


    [HttpPost]
    [Authorize]
    public async Task<ActionResult> ChangePassword(AccountChangePasswordModel model)
    {
        if (ModelState.IsValid)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.FindByIdAsync(userId!);

            if (user != null)
            {
                var result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.Password);

                if (result.Succeeded)
                {
                    TempData["Mesaj"] = "Parolanız Güncellendi";
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        return View(model);
    }


    public ActionResult ForgotPassword()
    {
        return View();
    }


    [HttpPost]
    public async Task<ActionResult> ForgotPassword(string email)
    {

        if (string.IsNullOrEmpty(email))
        {
            TempData["Mesaj"] = "E-posta adresinizi giriniz.";
            return View();
        }

        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            TempData["Mesaj"] = "Bu e-posta adresi kayıtlı değil.";
            return View();
        }

        var token = await _userManager.GeneratePasswordResetTokenAsync(user);

        var url = Url.Action("ResetPassword", "Account", new { userId = user.Id, token });

        var link = $"<a href=http://localhost:5220{url}> Şifre Yenile</a>";

        await _emailService.SendEmailAsync(user.Email!, "Parola Sıfırlama", link);
        
        TempData["Mesaj"] = "E posta Adresine şifre sıfırlama linki gönderildi";

        return RedirectToAction("Login");


    }

    public async Task<ActionResult> ResetPassword(string userId, string token)
    {
        if (userId == null || token == null)
        {
            return RedirectToAction("Login");
        }

        var user = await _userManager.FindByIdAsync(userId);

        if (user == null)
        {
            return RedirectToAction("Login");
        }

        var model = new AccountResetPasswordModel
        {
            Token = token,
            Email = user.Email!
        };
        return View(model);

    }

    [HttpPost]
    public async Task<ActionResult> ResetPassword(AccountResetPasswordModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                TempData["Mesaj"] = "Kullanıcı Bulunamadı";
                return RedirectToAction("Login");
            }

            var result = await _userManager.ResetPasswordAsync(user, model.Token, model.Password);//eposta gönder

            if (result.Succeeded)
            {
                TempData["Mesaj"] = "Şifre Güncellendi";
                return RedirectToAction("Login");

            }
            foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            

        }
        return View(model);
    }


} 
using System.Threading.Tasks;
using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using e_ticaret_proje.Data;
namespace e_ticaret_proje.Controllers;
    
    [Authorize(Roles = "Admin")]
public class UserController : Controller
{

    private UserManager<AppUser> _userManager;
    private RoleManager<AppRole> _roleManager;


    public UserController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
    {
        _userManager = userManager;
        _roleManager = roleManager;
    }
public async Task<ActionResult> Index(string role)
{
    ViewBag.Roller = new SelectList(_roleManager.Roles, "Name", "Name",role);

    if (string.IsNullOrEmpty(role))
    {
        // Rol belirtilmediyse tüm kullanıcıları getir
        return View(_userManager.Users.ToList());
    }

    // Rol belirtilmişse o roldeki kullanıcıları getir
    var usersInRole = await _userManager.GetUsersInRoleAsync(role);
    return View(usersInRole);
}

    public ActionResult Create()
    {
        return View();
    }


    [HttpPost]
    public async Task<ActionResult> Create(UserCreateModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                AdSoyad = model.AdSoyad
            };
            var result = await _userManager.CreateAsync(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error.Description);
            }
        }
        return View(model);
    }
 public async Task<ActionResult> Edit(string id)
    {
        var user = await _userManager.FindByIdAsync(id);

        if (user == null)
        {
            return RedirectToAction("Index");
        }

        ViewBag.Roles = await _roleManager.Roles.Select(i => i.Name).ToListAsync();

        return View(
            new UserEditModel
            {
                AdSoyad = user.AdSoyad,
                Email = user.Email!,
                SecilenRoller = await _userManager.GetRolesAsync(user)
            }
        );
    }

    [HttpPost]
    public async Task<ActionResult> Edit(string id, UserEditModel model)
    {
        if (ModelState.IsValid)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                user.Email = model.Email;
                user.AdSoyad = model.AdSoyad;

                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded && !string.IsNullOrEmpty(model.Password))
                {
                    // parola güncelle
                    await _userManager.RemovePasswordAsync(user);
                    await _userManager.AddPasswordAsync(user, model.Password);
                }
                TempData["Mesaj"] = $"{model.AdSoyad} Adlı Kullanıcı güncellendi";

                if (result.Succeeded)
                {
                    await _userManager.RemoveFromRolesAsync(user, await _userManager.GetRolesAsync(user));
                    if (model.SecilenRoller != null)
                    {
                        await _userManager.AddToRolesAsync(user, model.SecilenRoller);
                    }
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }

        return View(model);
    }

        public async Task<ActionResult> Delete(string id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = await _userManager.FindByIdAsync(id);
        if (entity != null)
        {
            return View(entity);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<ActionResult> DeleteConfirm(string id)
    {

        //burasyı uyarı verdirmesi için yaptık önce üstteki metot çalışoyor deleteye gönderiyor deletede evet dersek bu metod çalışıyor
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = await _userManager.FindByIdAsync(id);
        if (entity != null)
        {
            var result = await _userManager.DeleteAsync(entity);

            if (result.Succeeded)
            {
                TempData["Mesaj"] = $"{entity.AdSoyad} kullanıcısı silindi";
            }

            
        }
        return RedirectToAction("Index");
    }


}
using System.Threading.Tasks;
using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace e_ticaret_proje.Controllers;

public class UserController : Controller
{

    private UserManager<AppUser> _userManager;

    public UserController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    public ActionResult Index()
    {
        return View(_userManager.Users);
    }
}
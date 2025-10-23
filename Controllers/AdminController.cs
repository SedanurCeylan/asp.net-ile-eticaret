using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_ticaret_proje.Controllers;

public class AdminController : Controller
{
    [Authorize(Roles ="Admin")]
    public ActionResult Index()
    {
        return View();
    }
}
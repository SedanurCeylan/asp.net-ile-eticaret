using Microsoft.AspNetCore.Mvc;

namespace e_ticaret_proje.Controllers;

public class AdminController : Controller
{
    public ActionResult Index()
    {
        return View();
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_ticaret_proje.Controllers;

public class CartController : Controller
{
    [Authorize]
    public ActionResult Index()
    {
        return View();
    }
}
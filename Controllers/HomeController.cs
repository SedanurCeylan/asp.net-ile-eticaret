using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using e_ticaret_proje.Models;

namespace e_ticaret_proje.Controllers;

public class HomeController : Controller
{
    private readonly DataContext _context;
    public HomeController(DataContext context)
    {
        _context = context;
    }

    public ActionResult List()
    {
        var urunler = _context.Urunler.ToList();
        return View();
    }

    
}

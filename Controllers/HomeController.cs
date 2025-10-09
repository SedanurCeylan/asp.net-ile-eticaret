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

    public ActionResult Index()
    {

        // Aktif ve anasayfa true ise anasayfada gösterme filtresi yapıyoruz i de olur urun diye de tanımlayabiliriz
        var urunler = _context.Urunler.Where(i => i.Aktif && i.Anasayfa).ToList();
        //kategorileri menü sayfasına gönderdik bununla index.cshtml de de sayfaya gönderdik
        ViewData["Kategoriler"] = _context.Kategoriler.ToList();
        return View(urunler);
   } 
}

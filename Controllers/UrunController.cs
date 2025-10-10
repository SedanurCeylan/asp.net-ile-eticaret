using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;

namespace e_ticaret_proje.Controllers;

public class UrunController : Controller
{

    //Dependency InJection => DI yöntemi

    private readonly DataContext _context;
    public UrunController(DataContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        return View();
    }
    public ActionResult List(string url)
    {
        //aktifi true olanlar ürün kısmına gelicek
        var urunler = _context.Urunler.Where(urun => urun.Aktif && urun.Kategori.Url == url).ToList();
        return View(urunler);
    }
    
    public ActionResult Details(int id)
    {
        //id bilgisine göre ürün getir
        //var urun = _context.Urunler.FirstOrDefault(i => i.Id == id);
        //üstteki ve alttaki aynı işlevde
        var urun = _context.Urunler.Find(id);

        if (urun == null)
        {
            return RedirectToAction("List");
        }

        ViewData["BenzerUrunler"] = _context.Urunler
        .Where(i => i.Aktif && i.KategoriId == urun.KategoriId && i.Id != id)
        .Take(4)
        .ToList();

        return View(urun);
    }
}
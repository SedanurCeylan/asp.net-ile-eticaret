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
    public ActionResult List()
    {
        //aktifi true olanlar ürün kısmına gelicek
        var urunler = _context.Urunler.Where(urun => urun.Aktif).ToList();
        return View(urunler);
    }
    
    public ActionResult Details(int id)
    {
        //id bilgisine göre ürün getir
        //var urun = _context.Urunler.FirstOrDefault(i => i.Id == id);
        //üstteki ve alttaki aynı işlevde
        var urun = _context.Urunler.Find(id);

        return View(urun);
    }
}
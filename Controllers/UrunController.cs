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
        var urunler = _context.Urunler.ToList();
        return View(urunler);
    }
}
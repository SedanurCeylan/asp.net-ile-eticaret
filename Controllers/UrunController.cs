using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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

        var urunler = _context.Urunler.Select(i => new UrunGetModel
        {
            Id = i.Id,
            UrunAdi = i.UrunAdi,
            Fiyat = i.Fiyat,
            Aktif = i.Aktif,
            Anasayfa = i.Anasayfa,
            KategoriAdi = i.Kategori.KategoriAdi,
            Resim=i.Resim
        }).ToList();
        return View(urunler);
    }



    public ActionResult List(string url,string q)
{
    var query = _context.Urunler.Where(i=> i.Aktif);

    if (!string.IsNullOrEmpty(url))
    {
        query = query.Where(i =>i.Kategori.Url == url);
    }

    if (!string.IsNullOrEmpty(q)) 
    {
            query = query.Where(i => i.UrunAdi.ToLower().Contains(q.ToLower()));
            ViewData["q"] = q;
    }

    return View(query.ToList());
}

    public ActionResult Details(int id)
    {
        //id bilgisine göre ürün getir
        //var urun = _context.Urunler.FirstOrDefault(i => i.Id == id);
        //üstteki ve alttaki aynı işlevde
        var urun = _context.Urunler.Find(id);

        if (urun == null)
        {
            return RedirectToAction("Index", "Home");
        }

        ViewData["BenzerUrunler"] = _context.Urunler
                                        .Where(i => i.Aktif && i.KategoriId == urun.KategoriId && i.Id != id)
                                        .Take(4)
                                        .ToList();

        return View(urun);
    }

    [HttpGet]
    public ActionResult Create()
    {
        ViewData["Kategoriler"] = _context.Kategoriler.ToList();
        return View();
    }
    
    [HttpPost]
     public ActionResult Create(UrunCreateModel model)
    {
        var entity = new Urun()
        {
            UrunAdi = model.UrunAdi,
            Aciklama = model.Aciklama,
            Fiyat = model.Fiyat,
            Aktif = model.Aktif,
            Anasayfa = model.Anasayfa,
            KategoriId = model.KategoriId,
            Resim = "1.jpeg" ///upload
        };
        
        _context.Urunler.Add(entity);
        _context.SaveChanges();

         return RedirectToAction("Index");
    }
}
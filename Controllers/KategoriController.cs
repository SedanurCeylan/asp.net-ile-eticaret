using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_ticaret_proje.Controllers;


public class KategoriController : Controller
{


    //veritabanından veri çekmek için ekliyoruz
    private readonly DataContext _context;

    public KategoriController(DataContext context)
    {
        _context = context;
    }


    //localhost/kategori
    public ActionResult Index()
    {

        //şimdi burda her gelen model tipini alıp listeye çeviriyoruz ürün sayıyı almak için bu yani sadece ürünlerin sayısını taşıyoruz
        var kategoriler = _context.Kategoriler.Select(i => new KategoriGetModel
        {
            Id = i.Id,
            KategoriAdi = i.KategoriAdi,
            Url = i.Url,
            UrunSayisi = i.uruns.Count
        }).ToList();
        return View(kategoriler);
    }

    [HttpGet] //default 
    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    //inputların namelerini parametre veriyoruz
    public ActionResult Create(KategoriCreateModel model)
    {
        var entity = new Kategori
        {
            //burda da parametrelerle veriatabını eşitliyoruz
            KategoriAdi = model.KategoriAdi,
            Url = model.Url
        };
        _context.Kategoriler.Add(entity);
        //burda değişiklikleri kaydetme veritabanına aktarma işlemi yapıyoruz
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
    
    



}
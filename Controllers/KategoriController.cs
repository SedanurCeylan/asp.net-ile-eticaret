using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_ticaret_proje.Controllers;

[Authorize(Roles ="Admin")]
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
        if (ModelState.IsValid)
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
        return View(model);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        var entity = _context.Kategoriler.Select(i => new KategoriEditModel
        {
            Id = i.Id,
            KategoriAdi = i.KategoriAdi,
            Url = i.Url
        }).FirstOrDefault(i => i.Id == id);

        return View(entity);
    }

    [HttpPost]
    public ActionResult Edit(int id, KategoriEditModel model)
    {
        if (id != model.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            var entity = _context.Kategoriler.FirstOrDefault(i => i.Id == model.Id);
            if (entity != null)
            {
                entity.KategoriAdi = model.KategoriAdi;
                entity.Url = model.Url;

                _context.SaveChanges();

                TempData["Mesaj"] = $"{entity.KategoriAdi} kategorisi güncellendi";

                return RedirectToAction("Index");
            }
            return View(model);
        }

        return View(model);
    }


    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = _context.Kategoriler.FirstOrDefault(i => i.Id == id);
        if (entity != null)
        {
            return View(entity);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public ActionResult DeleteConfirm(int? id)
    {

        //burasyı uyarı verdirmesi için yaptık önce üstteki metot çalışoyor deleteye gönderiyor deletede evet dersek bu metod çalışıyor
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = _context.Kategoriler.FirstOrDefault(i => i.Id == id);
        if (entity != null)
        {
            _context.Kategoriler.Remove(entity);
            _context.SaveChanges();

            TempData["Mesaj"] = $"{entity.KategoriAdi} kategorisi silindi";
        }
        return RedirectToAction("Index");
    }


}
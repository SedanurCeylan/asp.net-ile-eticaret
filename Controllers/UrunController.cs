using System.Threading.Tasks;
using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.DependencyModel;
using e_ticaret_proje.Data;

namespace e_ticaret_proje.Controllers;

    [Authorize(Roles = "Admin")]
public class UrunController : Controller
{

    //Dependency InJection => DI yöntemi

    private readonly DataContext _context;
    public UrunController(DataContext context)
    {
        _context = context;
    }

    
    public ActionResult Index(int? kategori)
    {
        var query = _context.Urunler.AsQueryable();
        if (kategori != null)
        {
            query = query.Where(i => i.KategoriId == kategori);
        }

        var urunler = query.Select(i => new UrunGetModel
        {
            Id = i.Id,
            UrunAdi = i.UrunAdi,
            Fiyat = i.Fiyat,
            Aktif = i.Aktif,
            Anasayfa = i.Anasayfa,
            KategoriAdi = i.Kategori.KategoriAdi,
            Resim = i.Resim
        }).ToList();

        ViewData["Kategoriler"] = _context.Kategoriler.AsNoTracking().ToList();
        ViewBag.SeciliKategori = kategori;
        return View(urunler);
    }


    //tüm sayfa başına yazarsak bunu dışta tutuyoruz
    [AllowAnonymous]
    public ActionResult List(string url, string q)
    {
        var query = _context.Urunler.Where(i => i.Aktif);

        if (!string.IsNullOrEmpty(url))
        {
            query = query.Where(i => i.Kategori.Url == url);
        }

        if (!string.IsNullOrEmpty(q))
        {
            query = query.Where(i => i.UrunAdi.ToLower().Contains(q.ToLower()));
            ViewData["q"] = q;
        }

        return View(query.ToList());
    }

    [AllowAnonymous]
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
    public async Task<ActionResult> Create(UrunCreateModel model)
    {

        if (model.Resim == null || model.Resim.Length == 0)
        {
            ModelState.AddModelError("Resim", "Resim Seçmelisiniz!");
        }
        if (ModelState.IsValid)
        {
            //random isim üretiliyor foto içim
            var filename = Path.GetRandomFileName() + ".jpg";
            //fotolar nereye kaydedilcek onu seçicez
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", filename);


            //kullanılmayınca sil diyoruz
            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.Resim!.CopyToAsync(stream);
            }

            var entity = new Urun()
            {
                UrunAdi = model.UrunAdi,
                Aciklama = model.Aciklama,
                Fiyat = model.Fiyat ?? 0,
                Aktif = model.Aktif,
                Anasayfa = model.Anasayfa,
                KategoriId = (int)model.KategoriId!,
                Resim = filename
            };

            _context.Urunler.Add(entity);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        ViewData["Kategoriler"] = _context.Kategoriler.ToList();
        return View(model);
    }

    [HttpGet]
    public ActionResult Edit(int id)
    {
        var entity = _context.Urunler.Select(i => new UrunEditModel
        {
            Id = i.Id,
            UrunAdi = i.UrunAdi,
            Aciklama = i.Aciklama,
            Fiyat = i.Fiyat,
            Aktif = i.Aktif,
            Anasayfa = i.Anasayfa,
            KategoriId = i.KategoriId,
            ResimAdi = i.Resim
        }).FirstOrDefault(i => i.Id == id);

        ViewData["Kategoriler"] = _context.Kategoriler.AsNoTracking().ToList();
        return View(entity);
    }


    [HttpPost]
    public async Task<ActionResult> Edit(int id, UrunEditModel model)
    {
        if (ModelState.IsValid)
        {
            if (id != model.Id)
            {
                return RedirectToAction("Index");
            }

            var entity = _context.Urunler.FirstOrDefault(i => i.Id == model.Id);

            if (entity != null)
            {
                if (model.Resim != null)
                {
                    //random isim üretiliyor foto içim
                    var filename = Path.GetRandomFileName() + ".jpg";
                    //fotolar nereye kaydedilcek onu seçicez
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", filename);


                    //kullanılmayınca sil diyoruz
                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await model.Resim!.CopyToAsync(stream);
                    }
                    entity.Resim = filename;
                }
                entity.UrunAdi = model.UrunAdi;
                entity.Aciklama = model.Aciklama;
                entity.Fiyat = model.Fiyat ?? 0;
                entity.Aktif = model.Aktif;
                entity.Anasayfa = model.Anasayfa;
                entity.KategoriId = (int)model.KategoriId!;

                _context.SaveChanges();

                TempData["Mesaj"] = $"{entity.UrunAdi} ürünü güncellendi.";

                return RedirectToAction("Index");
            }
        }
        ViewData["Kategoriler"] = _context.Kategoriler.AsNoTracking().ToList();
        return View(model);
    }


    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = _context.Urunler.FirstOrDefault(i => i.Id == id);
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
        var entity = _context.Urunler.FirstOrDefault(i => i.Id == id);
        if (entity != null)
        {
            _context.Urunler.Remove(entity);
            _context.SaveChanges();

            TempData["Mesaj"] = $"{entity.UrunAdi} ürünü silindi";
        }
        return RedirectToAction("Index");
    }

    
}
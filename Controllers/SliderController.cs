using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using e_ticaret_proje.Data;

namespace e_ticaret_proje.Controllers;

[Authorize(Roles ="Admin")]
public class SliderController : Controller
{

    private readonly DataContext _context;

    public SliderController(DataContext context)
    {
        _context = context;
    }

    public ActionResult Index()
    {
        return View(_context.Sliderlar.Select(i => new SliderGetModel
        {
            Aktif = i.Aktif,
            Baslik = i.Baslik,
            Id = i.Id,
            Resim = i.Resim,
            Sira = i.Sira
        }).ToList());
    }


    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Create(SliderCreateModel model)
    {
        if (model.Resim == null || model.Resim.Length == 0)
        {
            ModelState.AddModelError("Resim", "Resim seçmelisiniz");
        }

        if (ModelState.IsValid)
        {
            var fileName = Path.GetRandomFileName() + ".jpg";
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img", fileName);

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await model.Resim!.CopyToAsync(stream);
            }

            var entity = new Slider()
            {
                Baslik = model.Baslik,
                Aciklama = model.Aciklama,
                Resim = fileName,
                Aktif = model.Aktif,
                Sira = model.Sira

            };

            _context.Sliderlar.Add(entity);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        return View(model);
    }


    [HttpGet]
    public ActionResult Edit(int id)
    {
        var entity = _context.Sliderlar.Select(i => new SliderEditModel
        {
            Id = i.Id,
            Baslik = i.Baslik,
            Aciklama = i.Aciklama,
            Aktif = i.Aktif,
            ResimAdi = i.Resim,
            Sira = i.Sira

        }).FirstOrDefault(i => i.Id == id);

        return View(entity);
    }


    [HttpPost]
    public async Task<ActionResult> Edit(int id, SliderEditModel model)
    {
        if (ModelState.IsValid)
        {
            if (id != model.Id)
            {
                return RedirectToAction("Index");
            }

            var entity = _context.Sliderlar.FirstOrDefault(i => i.Id == model.Id);

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
                entity.Baslik = model.Baslik;
                entity.Aciklama = model.Aciklama;
                entity.Aktif = model.Aktif;
                entity.Sira = model.Sira;

                _context.SaveChanges();

                TempData["Mesaj"] = $"{entity.Baslik} isimli slider güncellendi.";

                return RedirectToAction("Index");
            }
        }
        return View(model);
    }


    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return RedirectToAction("Index");
        }
        var entity = _context.Sliderlar.FirstOrDefault(i => i.Id == id);
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
        var entity = _context.Sliderlar.FirstOrDefault(i => i.Id == id);
        if (entity != null)
        {
            _context.Sliderlar.Remove(entity);
            _context.SaveChanges();

            TempData["Mesaj"] = $"{entity.Baslik} sliderı silindi";
        }
        return RedirectToAction("Index");
    }



}
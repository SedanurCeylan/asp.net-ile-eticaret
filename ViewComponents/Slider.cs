using e_ticaret_proje.Data;
using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_ticaret_proje.ViewComponents;


public class Slider : ViewComponent
{
    
    private readonly DataContext _context;

    public Slider(DataContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        return View(_context.Sliderlar.Where(i=>i.Aktif).OrderBy(i=>i.Sira).ToList());
    }

}
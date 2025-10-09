using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Mvc;

namespace e_ticaret_proje.ViewComponents;


public class Navbar : ViewComponent
{

    private readonly DataContext _context;

    public Navbar(DataContext context)
    {
        _context = context;
    }

    public IViewComponentResult Invoke()
    {
        return View(_context.Kategoriler.ToList());
    }

}
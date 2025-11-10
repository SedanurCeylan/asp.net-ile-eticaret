using System.Threading.Tasks;
using dotnet_store.Services;
using e_ticaret_proje.Data;
using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_ticaret_proje.Controllers;

[Authorize]
public class OrderController : Controller
{
    private ICartService _cartService;

    private readonly DataContext _context;

    public OrderController(ICartService cartService, DataContext context)
    {
        _cartService = cartService;
        _context = context;
    }
    public async Task<ActionResult> Checkout()
    {
        ViewBag.Cart = await _cartService.GetCart(User.Identity?.Name!);
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> Checkout(OrderCreateModel model)
    {
        var username = User.Identity?.Name!;
        var cart = await _cartService.GetCart(User.Identity?.Name!);

        if (cart.CartItems.Count == 0)
        {
            ModelState.AddModelError("", "Sepetinizde ürün yok");
        }
        if (ModelState.IsValid)
        {
            var order = new Order
            {
                AdSoyad = model.AdSoyad,
                Telefon = model.Telefon,
                AdresSatiri = model.AdresSatiri,
                PostaKodu = model.PostaKodu,
                Sehir = model.Sehir,
                SiparisNotu = model.SiparisNotu!,
                SiparisTarihi = DateTime.Now,
                ToplamFiyat = cart.Toplam(),
                Username = username,
                OrderItems = cart.CartItems.Select(ci => new OrderItem
                {
                    UrunId = ci.UrunId,
                    Fiyat = ci.Urun.Fiyat,
                    Miktar = ci.Miktar,
                }).ToList()
            };
            _context.Orders.Add(order);
            _context.Carts.Remove(cart);

            await _context.SaveChangesAsync();
            return RedirectToAction("Completed", new { orderId = order.OrderId });
        }
        ViewBag.Cart = cart;

        return View(model);
    }
    
    public ActionResult Completed(string orderId)
    {
        return View("Completed" , orderId);
    }
}
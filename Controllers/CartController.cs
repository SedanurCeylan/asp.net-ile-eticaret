using System.Threading.Tasks;
using e_ticaret_proje.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace e_ticaret_proje.Controllers;

[Authorize]
public class CartController : Controller
{
    private readonly DataContext _context;

    public CartController(DataContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> AddToCart(int urunId, int miktar=1)
    {
        var customerId = User.Identity?.Name;

        var cart = await _context.Carts.Include(i => i.CartItems)
                                        .Where(i => i.CustomerId == customerId)
                                        .FirstOrDefaultAsync();

        if (cart == null)
        {
            cart = new Cart
            {
                CustomerId = customerId!
            };
            _context.Carts.Add(cart);
        }

        var item = cart.CartItems.Where(i => i.UrunId == urunId).FirstOrDefault();

        if (item != null)
        {
            item.Miktar += 1;
            //daha önce eklenmiş
        }
        else
        {
            cart.CartItems.Add(new CartItem
            {
                UrunId= urunId,
                Miktar=miktar
            });

            //ilk defa ekleniyor
        }

        await _context.SaveChangesAsync();


        return RedirectToAction("Index","Home");
    }
}
using System.Threading.Tasks;
using dotnet_store.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_ticaret_proje.Controllers;

[Authorize]
public class OrderController : Controller
{
    private ICartService _cartService;

    public OrderController(ICartService cartService)
    {
        _cartService = cartService;
    }
    public async Task<ActionResult> Checkout()
    {
        ViewBag.Cart = await _cartService.GetCart(User.Identity?.Name!);
        return View();
    }
}
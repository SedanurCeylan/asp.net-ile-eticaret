using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using e_ticaret_proje.Data;
using e_ticaret_proje.Models;

namespace e_ticaret_proje.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly DataContext _context;

        public AdminController(DataContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new AdminDashboardViewModel
            {
                // Toplam satış
                TotalSales = await _context.Orders
                    .SumAsync(i => (decimal?)i.ToplamFiyat) ?? 0,

                // Toplam sipariş sayısı
                TotalOrders = await _context.Orders.CountAsync(),

                // Toplam ürün sayısı
                TotalProducts = await _context.Urunler.CountAsync(),

                // Kullanıcı sayısı
                TotalUsers = await _context.Users.CountAsync(),

                // ✅ Son 5 sipariş (Yeni Siparişler tablosu için)
                LastOrders = await _context.Orders
                    .OrderByDescending(i => i.SiparisTarihi)
                    .Take(5)
                    .ToListAsync()
            };

            return View(model);
        }
    }
}

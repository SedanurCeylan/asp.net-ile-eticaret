using e_ticaret_proje.Data;

namespace e_ticaret_proje.Models
{
    public class AdminDashboardViewModel
    {
        public decimal TotalSales { get; set; }          // Satış Toplamı
        public int TotalOrders { get; set; }             // Sipariş Sayısı
        public int TotalProducts { get; set; }           // Ürün Adedi
        public int TotalUsers { get; set; }              // Kullanıcı Sayısı
        public List<Order> LastOrders { get; set; } = new();

    }
}

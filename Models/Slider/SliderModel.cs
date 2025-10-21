using System.ComponentModel.DataAnnotations;

namespace e_ticaret_proje.Models
{
    public class SliderModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Başlık alanı zorunludur.")]
        [StringLength(100, ErrorMessage = "Başlık en fazla 30 karakter olabilir.")]
        [Display(Name = "Başlık:")]
        public string? Baslik { get; set; }

        [Required(ErrorMessage = "Açıklama alanı zorunludur.")]
        [Display(Name = "Açıklama:")]
        [StringLength(250, ErrorMessage = "Açıklama en fazla 250 karakter olabilir.")]
        public string? Aciklama { get; set; }


      
        [Display(Name = "Slider Resmi:")]
        public IFormFile? Resim { get; set; }


        [Display(Name = "Sıra No:")]
        [Required(ErrorMessage = "Sıra numarası girilmelidir.")]
        [Range(1, 100, ErrorMessage = "Sıra 1 ile 100 arasında olmalıdır.")]
        public int Sira { get; set; }

        [Display(Name = "Aktif mi?")]
        public bool Aktif { get; set; }
    }
}

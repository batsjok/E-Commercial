using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.web.ViewModel
{
    public class ProductViewModel
	{
        public int Id { get; set; }
        [Remote(action:"HasProductName", controller:"Product")]
        [Required(ErrorMessage = "İsim alanı boş olamaz!")]
        [StringLength(30,MinimumLength = 2,ErrorMessage ="İsim Alanı 2 değerden küçük olamaz")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "Fiyat alanı boş olamaz!")]
        [Range(1, 3000, ErrorMessage = "Fiyat değeri 1-3000 arasında olmalı!")]
        public int? Price { get; set; }
        [Required(ErrorMessage = "Stok alanı boş olamaz!")]
        [Range(1,250,ErrorMessage ="Stok sayısı 1-200 değerleri arasında olmalı!")]
        public int? Stock { get; set; }
        [Required(ErrorMessage = "Renk alanı boş olamaz!")]
        public string? Color { get; set; }
        [Required(ErrorMessage = "Yayınlanma tarihi boş olamaz!")]
        public DateTime? PublishDate { get; set; }
        public bool IsPublish { get; set; }
        [Required(ErrorMessage = "Yayınlanma süresi boş olamaz!")]
        public string? Expire { get; set; }
        [Required(ErrorMessage = "Açıklama alanı boş olamaz!")]
        [StringLength(300, MinimumLength = 2, ErrorMessage = "İsim Alanı 2 değerden küçük olamaz")]
        public string? Describtion { get; set; }
    }
}


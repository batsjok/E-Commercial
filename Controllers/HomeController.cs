using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.web.Helpers;
using WebApp.web.Models;
using WebApp.web.Models.ViewModel;
using System.Linq; // LINQ metodları için gereken using direktifi
using AutoMapper;

namespace WebApp.web.Controllers
{
    public class HomeController : Controller
    {
        Helper _helper;
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, Helper helper, AppDbContext context, IMapper mapper)
        {
            _helper = helper;
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            // Ürünleri sırala, seç ve ProductPartialViewModel'e dönüştür, ardından liste oluştur
            var products = _context.ProductTBL
                                .OrderByDescending(x => x.Id)
                                .Select(x => new ProductPartialViewModel
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    Price = x.Price,
                                    Stock = x.Stock
                                })
                                .ToList(); // Listeye dönüştür

            // Ürün listesi null değilse, ViewBag'e atama yap
            if (products != null)
            {
                ViewBag.productListPartialViewModel = new ProductListPartialViewModel
                {
                    Products = products
                };
            }
            else // Ürün listesi null ise, ViewBag'e null atama yap
            {
                ViewBag.productListPartialViewModel = null;
            }

            return View();
        }
        public IActionResult Visitor()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            // Ürünleri sırala, seç ve ProductPartialViewModel'e dönüştür, ardından liste oluştur
            var products = _context.ProductTBL
                                .OrderByDescending(x => x.Id)
                                .Select(x => new ProductPartialViewModel
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    Price = x.Price,
                                    Stock = x.Stock
                                })
                                .ToList(); // Listeye dönüştür

            // Ürün listesi null değilse, ViewBag'e atama yap
            if (products != null)
            {
                ViewBag.productListPartialViewModel = new ProductListPartialViewModel
                {
                    Products = products
                };
            }
            else // Ürün listesi null ise, ViewBag'e null atama yap
            {
                ViewBag.productListPartialViewModel = null;
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult SaveVisitorComment(VisitorViewModel visitorViewModel)
        {

            try
            {
                var visitor = _mapper.Map<Visitor>(visitorViewModel);
                _context.VisitorsTBL.Add(visitor);
                _context.SaveChanges();

                TempData["result"] = "Yorum Kaydedilmiştir";
                return RedirectToAction(nameof(visitor));
            }
            catch (Exception)
            {
                TempData["result"] = "Yorum Kaydedilirken bir hata meydana geldi";
                return RedirectToAction(nameof(HomeController.Visitor));
            }
            
        }
    }
}

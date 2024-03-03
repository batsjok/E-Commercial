using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebApp.web.Models;
using WebApp.web.ViewModel;

namespace WebApp.web.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly ProductRepository _productRepository;

        public ProductController(AppDbContext context, IMapper mapper)
        {
            _productRepository = new ProductRepository();
            

            _context = context;

            _mapper = mapper;
        }

        public IActionResult Index()
        {
           

            var products = _context.ProductTBL.ToList();

            return View(_mapper.Map<List<ProductViewModel>>(products));
        }

        public IActionResult GetById(int id)
        {
            var product = _context.ProductTBL.Find(id);

            return View(_mapper.Map<ProductViewModel>(product));
        }

        public IActionResult Remove(int id)
        {
            var product = _context.ProductTBL.Find(id);
            _context.ProductTBL.Remove(product);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.ExpireValue ="1 Ay";
            ViewBag.Expire = new Dictionary<string, int>() {
                    {"1 Ay", 1 },
                    {"3 Ay", 3 },
                    {"6 Ay", 6 },
                    {"12 Ay", 12 }
                    };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {
                new(){Data = "mavi", value = "mavi"},
                new(){Data = "kırmızı", value = "kırmızı"},
                new(){Data = "sarı", value = "sarı"},
            }, "value", "Data");


            return View();
        }

        

        [HttpPost]
        public IActionResult Add(ProductViewModel newProduct)
        {
            if (ModelState.IsValid)
            {
                _context.ProductTBL.Add(_mapper.Map<Product>(newProduct));
                _context.SaveChanges();

                TempData["status"] = "Ürün başarıyla eklendi";
                return RedirectToAction("Index");
            }
            else
            {
                if(!string.IsNullOrEmpty(newProduct.Name)&& newProduct.Name.StartsWith("A"))
                {
                    ModelState.AddModelError(string.Empty, "Ürün ismi A ile başlayamaz");
                }

                ViewBag.ExpireValue = newProduct.Expire;
                ViewBag.Expire = new Dictionary<string, int>() {
                    {"1 Ay", 1 },
                    {"3 Ay", 3 },
                    {"6 Ay", 6 },
                    {"12 Ay", 12 }
                    };

                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {
                new(){Data = "mavi", value = "mavi"},
                new(){Data = "kırmızı", value = "kırmızı"},
                new(){Data = "sarı", value = "sarı"},
            }, "value", "Data");
                return View();
            }



        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.ProductTBL.Find(id);

            // Product'ın Expire alanını alarak uygun bir şekilde ViewBag.Expire'ı ayarlayın
            ViewBag.Expire = new Dictionary<string, int>() {
        {"1 Ay", 1 },
        {"3 Ay", 3 },
        {"6 Ay", 6 },
        {"12 Ay", 12 }
    };

            // Product'ın Color alanını alarak uygun bir şekilde ViewBag.ColorSelect'ı ayarlayın
            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {
        new(){Data = "mavi", value = "mavi"},
        new(){Data = "kırmızı", value = "kırmızı"},
        new(){Data = "sarı", value = "sarı"},
    }, "value", "Data", product.Color);

            return View(_mapper.Map<ProductViewModel>(product));
        }


        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {
      
            if(!ModelState.IsValid)
            {
                ViewBag.ExpireValue = updateProduct.Expire;
                ViewBag.Expire = new Dictionary<string, int>() {
                    {"1 Ay", 1 },
                    {"3 Ay", 3 },
                    {"6 Ay", 6 },
                    {"12 Ay", 12 }
                    };
                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>() {
                new(){Data = "mavi", value = "mavi"},
                new(){Data = "kırmızı", value = "kırmızı"},
                new(){Data = "sarı", value = "sarı"},
            }, "value", "Data", updateProduct.Color);

                return View();
            }
            _context.ProductTBL.Update(_mapper.Map<Product>(updateProduct));
            _context.SaveChanges();
        
            TempData["status"] = "Ürün Başarıyla Güncellendi.";
            return RedirectToAction("Index");
        }
        [AcceptVerbs("GET","POST")]
        public IActionResult HasProductName(string Name)
        {
            var anyProduct = _context.ProductTBL.Any(x => x.Name.ToLower() == Name.ToLower());
            if(anyProduct)
            {
                return Json("kaydetmeye çalıltığınız ürün ismi veritabanında bulunmaktadır.");

            }
            else
            {
                return Json(true);
            }
        }
    }
}

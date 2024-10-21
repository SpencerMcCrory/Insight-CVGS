using InsightApp.Entities;
using Microsoft.AspNetCore.Mvc;

namespace InsightApp.Controllers
{
    public class ProductController : Controller
    {
        private InsightUpdateCvgs2Context _SVGSDbContext;
        public ProductController(InsightUpdateCvgs2Context sVGSDbContext)
        {
            _SVGSDbContext = sVGSDbContext;
        }

        [HttpGet("Portal/product-details")]
        public IActionResult details()
        {
            return View();
        }
        
        [HttpGet("Portal/products")]
        public IActionResult products()
        {
            return View();
        }

        [HttpGet("Portal/cart")]
        public IActionResult cart()
        {
            return View();
        }

        [HttpGet("Portal/cart/checkout")]
        public IActionResult checkout()
        {
            return View();
        }
    }
}

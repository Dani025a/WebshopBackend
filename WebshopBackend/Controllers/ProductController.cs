using Microsoft.AspNetCore.Mvc;

namespace WebshopBackend.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

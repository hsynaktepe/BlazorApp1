using Microsoft.AspNetCore.Mvc;

namespace BlazorApp1.Server.Controllers
{
    public class SupplierController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

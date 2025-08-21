using Microsoft.AspNetCore.Mvc;

namespace Goal_Mate.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index ()
        {
            return View ();
        }
    }
}

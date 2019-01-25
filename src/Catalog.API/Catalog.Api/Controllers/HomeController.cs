using Microsoft.AspNetCore.Mvc;


namespace Catalog.Api.Controllers
{
    public class HomeController
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return new RedirectResult("~/swagger");
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace HospitalManagement.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string userName, string password)
        {
            Console.WriteLine(userName + " " + password);
            return View("Index");
        }
    }
}

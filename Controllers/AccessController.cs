using Microsoft.AspNetCore.Mvc;
using WebAssignment.Models;

namespace WebAssignment.Controllers
{
    public class AccessController : Controller
    {
        PRN211_ProjectContext db = new PRN211_ProjectContext();

        [HttpGet]
        public IActionResult Login()
        {
            if (HttpContext.Session.GetString("UserName") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
        [HttpPost]
        public IActionResult Login(User user)
        {
            if (HttpContext.Session.GetString("Username") == null)
            {
                var u = db.Users.Where(x => x.Username.Equals(user.Username) &&
                x.Password.Equals(user.Password)).FirstOrDefault();
                if (u != null)
                {
                    HttpContext.Session.SetString("Username", u.Username.ToString());
                    ViewBag.UserName = HttpContext.Session.GetString("Username");
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login", "Login");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

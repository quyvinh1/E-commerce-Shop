using Microsoft.AspNetCore.Mvc;
using WebAssignment.Models;
using WebAssignment.Models.ViewModel;
using WebAssignment.Repository;

namespace WebAssignment.Controllers
{
    public class CartController : Controller
    {
        PRN211_ProjectContext db = new PRN211_ProjectContext();
        public IActionResult Index()
        {
            List<CartItemModel> cartItems = HttpContext.Session.GetJson<List<CartItemModel>>("Cart") 
                ?? new List<CartItemModel>();
            CartItemViewModel cartVM = new()
            {
                CartItems = cartItems,
                GrandTotal = cartItems.Sum(x => x.Quantity * x.Price)
            };
            return View(cartVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int Id)
        {
            Product product = await db.Products.FindAsync(Id);
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart")
                ?? new List<CartItemModel>();
            CartItemModel cartItems = cart.Where(c=>c.ProductId == Id).FirstOrDefault();
            if(cartItems == null)
            {
                cart.Add(new CartItemModel(product));
            } else
            {
                cartItems.Quantity += 1;
            }
            HttpContext.Session.SetJson("Cart", cart);
            return Redirect(Request.Headers["Referer"].ToString());
        }
        public async Task<IActionResult> Decrease(int Id)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
            CartItemModel cartItems = cart.Where(c => c.ProductId == Id).FirstOrDefault();
            if(cartItems.Quantity > 1) {
                --cartItems.Quantity;
            } else
            {
                cart.RemoveAll(p=>p.ProductId == Id);
            }
            if(cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Increase(int Id)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
            CartItemModel cartItems = cart.Where(c => c.ProductId == Id).FirstOrDefault();
            if (cartItems.Quantity > 1)
            {
                ++cartItems.Quantity;
            }
            else
            {
                cart.RemoveAll(p => p.ProductId == Id);
            }
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(int Id)
        {
            List<CartItemModel> cart = HttpContext.Session.GetJson<List<CartItemModel>>("Cart");
            cart.RemoveAll(p=>p.ProductId == Id);
            if (cart.Count == 0)
            {
                HttpContext.Session.Remove("Cart");
            }
            else
            {
                HttpContext.Session.SetJson("Cart", cart);
            }
            return RedirectToAction("Index");
        }
    }
}

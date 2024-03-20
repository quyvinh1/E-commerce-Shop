using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebAssignment.Models;
using X.PagedList;

namespace WebAssignment.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        PRN211_ProjectContext db = new PRN211_ProjectContext();
        
        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            
            return View();
        }
        
        [Route("productlist")]
        public IActionResult ProductList(int? page)
        {
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listProduct = db.Products.AsNoTracking().OrderBy(x => x.Id);
            PagedList<Product> lst = new PagedList<Product>(listProduct, pageNumber, pageSize);
            return View(lst);
        }
        [Route("AddProduct")]
        [HttpGet]
        public IActionResult AddProduct() {
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories.ToList
                (),"Id","CategoryName");
            ViewBag.BrandId = new SelectList(db.Brands.ToList
                (), "Bid", "Bname");
            return View();
        }
        [Route("AddProduct")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("ProductList");
            }
            return View(product);
        }
        [Route("UpdateProduct")]
        [HttpGet]
        public IActionResult UpdateProduct(int productId)
        {
            ViewBag.ProductCategoryId = new SelectList(db.ProductCategories.ToList
                (), "Id", "CategoryName");
            ViewBag.BrandId = new SelectList(db.Brands.ToList
                (), "Bid", "Bname");
            var product = db.Products.Find(productId);
            return View(product);
        }
        [Route("UpdateProduct")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("ProductList","HomeAdmin");
            }
            return View(product);
        }
        [Route("DeleteProduct")]
        [HttpGet]
        public IActionResult DeleteProduct(int productId)
        {
            TempData["Message"] = "";
            var review = db.Reviews.Where(x=>x.ProductId==productId).ToList();
            if(review.Any())
            {
                db.RemoveRange(review);
            }
            db.Remove(db.Products.Find(productId));
            db.SaveChanges();
            TempData["Message"] = "Deleted successfully!";
            return RedirectToAction("ProductList", "HomeAdmin");
        }
    }
}

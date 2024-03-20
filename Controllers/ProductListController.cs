using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Drawing.Printing;
using System.Linq;
using WebAssignment.Models;
using X.PagedList;

namespace WebAssignment.Controllers
{
	public class ProductListController : Controller
	{
		PRN211_ProjectContext db = new PRN211_ProjectContext();
		// GET: ProductListController
		public IActionResult Index(int? page)
		{
			var brands = db.Brands.ToList();
			var categories = db.ProductCategories.ToList();
			int pageSize = 9;
			int pageNumber = page==null || page<0 ?1: page.Value;
			var listProduct = db.Products.AsNoTracking().OrderBy(x => x.Id);
			PagedList<Product> lst = new PagedList<Product>(listProduct,pageNumber,pageSize);
			var viewModel = new Product.ProductViewModel
            {
				Brands = brands,
				Categories = categories,
				Products = lst
			};
			return View(viewModel);
		}
		[HttpGet]
        public IActionResult FilterPrice(int? page,int sort)
        {
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var listProduct = new List<Product>();
			if(sort == 1)
			{
                listProduct = db.Products.AsNoTracking().OrderByDescending(x => x.Price).ToList();
            } else if(sort == 2){
                listProduct = db.Products.AsNoTracking().OrderBy(x => x.Price).ToList();
            }
            PagedList<Product> lst = new PagedList<Product>(listProduct, pageNumber, pageSize);
            return View(lst);
        }
        [HttpPost]
        public IActionResult FilterPrice(int? page, int sort,int i)
        {
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var listProduct = new List<Product>();
            if (sort == 1)
            {
                listProduct = db.Products.AsNoTracking().OrderByDescending(x => x.Price).ToList();
            }
            else if (sort == 2)
            {
                listProduct = db.Products.AsNoTracking().OrderBy(x => x.Price).ToList();
            }
            PagedList<Product> lst = new PagedList<Product>(listProduct, pageNumber, pageSize);
            return View(lst);
        }
        public IActionResult ProductByCategories(int categoryId, int? page
			)
		{
			int pageSize = 9;
			int pageNumber = page == null || page < 0 ? 1 : page.Value;
			var listProduct = db.Products.AsNoTracking()
				.Where(x=>x.ProductCategoryId==categoryId)
				.OrderBy(x => x.Id);
			PagedList<Product> lst = new PagedList<Product>(listProduct, pageNumber, pageSize);
			return View(lst);
		}
		public IActionResult ProductDetail(int productId)
		{
			var product = db.Products.SingleOrDefault(x=>x.Id==productId);
			return View(product);
		}
		[HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult GetFilteredProducts(int?[] brandIds,int? page)
		{
            var brands = db.Brands.ToList();
            var categories = db.ProductCategories.ToList();
            int pageSize = 9;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;
            var products = db.Products.Where(p => brandIds.Contains(p.BrandId)).ToList();
            PagedList<Product> lst = new PagedList<Product>(products, pageNumber, pageSize);
            var viewModel = new Product.ProductViewModel
            {
                Brands = brands,
                Categories = categories,
                Products = lst
            };
            return PartialView("ProductPartial",viewModel);
		}
        // GET: ProductListController/Details/5
        public ActionResult Details(int id)
		{
			return View();
		}

		// GET: ProductListController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: ProductListController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ProductListController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: ProductListController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: ProductListController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: ProductListController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}

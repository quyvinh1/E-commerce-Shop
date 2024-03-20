//using WebAssignment.Models;
using Microsoft.AspNetCore.Mvc;
using WebAssignment.Repository;
namespace WebAssignment.ViewComponents
{
    public class ProductCategoryMenuViewComponent : ViewComponent
    {
        private readonly IProductCategory _category;
        public ProductCategoryMenuViewComponent(IProductCategory category)
        {
            _category = category;
        }
        public IViewComponentResult Invoke()
        {
            var productCategories = _category.GetAllCategory().OrderBy(x => x.CategoryName);
            return View(productCategories);
        }
    }
}

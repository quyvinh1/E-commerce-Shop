using WebAssignment.Models;
namespace WebAssignment.Repository
{
    public class ProductCategoryRepository : IProductCategory
    {
        private readonly PRN211_ProjectContext _context;
        public ProductCategoryRepository(PRN211_ProjectContext context)
        {
            _context = context;
        }
        public ProductCategory Add(ProductCategory category)
        {
            _context.ProductCategories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public ProductCategory Delete(string categoryId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductCategory> GetAllCategory()
        {
            return _context.ProductCategories;
        }

        public ProductCategory GetCategory(string categoryId)
        {
            return _context.ProductCategories.Find(categoryId);
        }

        public ProductCategory Update(ProductCategory category)
        {
            _context.Update(category);
            _context.SaveChanges();
            return category;
        }
    }
}

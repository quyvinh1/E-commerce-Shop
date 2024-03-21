using WebAssignment.Models;
namespace WebAssignment.Repository
{
	public interface IProductCategory
	{
		ProductCategory Add(ProductCategory category);
		ProductCategory Update(ProductCategory category);
		ProductCategory Delete(String categoryId);
		ProductCategory GetCategory(String categoryId);
		IEnumerable<ProductCategory> GetAllCategory();
	}
}

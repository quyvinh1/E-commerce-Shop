using System;
using System.Collections.Generic;
using X.PagedList;

namespace WebAssignment.Models
{
    public partial class Product
    {
        public Product()
        {
            Reviews = new HashSet<Review>();
            WishLists = new HashSet<WishList>();
        }

        public int Id { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public int? Quantity { get; set; }
        public int? ProductCategoryId { get; set; }
        public int? BrandId { get; set; }

        public virtual Brand? Brand { get; set; }
        public virtual ProductCategory? ProductCategory { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<WishList> WishLists { get; set; }
        public class ProductViewModel
        {
            public List<Brand> Brands { get; set; }
            public List<ProductCategory> Categories { get; set; }
            public IPagedList<Product> Products { get; set; }
        }
    }
}

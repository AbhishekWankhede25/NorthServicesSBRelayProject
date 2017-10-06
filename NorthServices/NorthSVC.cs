using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthServices
{
    public class NorthSVC : INorthService
    {
        private NorthDBContext _context;

        public NorthSVC()
        {
            _context = new NorthDBContext();
        }

        public IEnumerable<Category> GetCategories()
        {
            var result = _context.Categories;
            var count = result.Count();
            return result;
        }

        public Category GetCategory(int categoryID)
        {
            return _context.Categories.FirstOrDefault(c => c.CategoryID == categoryID);
        }

        public IEnumerable<Product> GetProducts()
        {
            return _context.Products;
        }

        public Product GetProduct(int productID)
        {
            return _context.Products.FirstOrDefault(p => p.CategoryID == productID);
        }

        public IEnumerable<Product> GetProductsByCategory(int categoryID)
        {
            return _context.Products.Where(p => p.CategoryID == categoryID);
        }
    }
}

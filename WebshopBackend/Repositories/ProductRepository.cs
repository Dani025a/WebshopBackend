using WebshopBackend.Data;
using WebshopBackend.Interfaces;
using WebshopBackend.Models;

namespace WebshopBackend.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly WebshopContext _context;

        public ProductRepository(WebshopContext context)
        {
            _context = context;
        }
        public bool CreateProduct(Product product)
        {
            _context.Add(product);
            return Save();
        }

        public bool DeleteProduct(Product product)
        {
            _context.Remove(product);
            return Save();
        }

        public Product GetProduct(int productid)
        {
            return _context.Products.Where(p => p.ProductId == productid).FirstOrDefault();
        }

        public ICollection<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public bool ProductExists(int productid)
        {
            return _context.Products.Any(p => p.ProductId == productid);
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProduct(Product product)
        {
            _context.Update(product);
            return Save();
        }
        public ICollection<Product> GetProductsFromCategory(int categoryid)
        {
            return _context.Products.Where(p => p.Category.CategoryId == categoryid).ToList();
        }
    }
}

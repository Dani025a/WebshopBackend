using WebshopBackend.Models;

namespace WebshopBackend.Interfaces
{
    public interface IProductRepository
    {
        ICollection<Product> GetProducts();
        Product GetProduct(int productid);
        ICollection<Product> GetProductsFromCategory(int categoryid);
        bool ProductExists(int productid);
        bool CreateProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(Product product);
        bool Save();
    }
}
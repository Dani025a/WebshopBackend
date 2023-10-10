using AutoMapper;
using WebshopBackend.Data;
using WebshopBackend.Interfaces;
using WebshopBackend.Models;

namespace WebshopBackend.Repository
{
    public class CategoryRepository : ICategoryRepository
                

    {
        private WebshopContext _context;
        private readonly IMapper _mapper;
        public CategoryRepository(WebshopContext context, IMapper mapper)
    {
            _context = context;
            _mapper = mapper;
    }
        public bool CategoryExists(int id)
        {
            return _context.Categories.Any(c => c.CategoryId == id);
        }

        public ICollection<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }

        public bool CreateCategory(Category category)
        {
            _context.Add(category);
            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _context.Remove(category);
            return Save();
        }

        public Category GetCategory(int categoryid)
        {
            return _context.Categories.Where(c => c.CategoryId == categoryid).FirstOrDefault();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool UpdateCategory(Category category)
        {
            _context.Update(category);
            return Save();
        }
    }
}
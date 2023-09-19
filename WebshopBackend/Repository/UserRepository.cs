using WebshopBackend.Data;
using WebshopBackend.Interfaces;
using WebshopBackend.Models;

namespace WebshopBackend.Repositoy
{
    public class UserRepository : IUserRepository
    {
        private readonly WebshopContext _context;

        public UserRepository(WebshopContext context)
        {
            _context = context;
        }

    public bool CreateUser(User user)
    {
        _context.Add(user);
        return Save();
    }

    public bool DeleteUser(User user)
    {
        _context.Remove(user);
        return Save();
    }

    public User GetUser(int userId)
    {
        return _context.Users.Where(u => u.UserId == userId).FirstOrDefault();
    }


    public ICollection<User> GetUsers()
    {
        return _context.Users.ToList();
    }


    public bool UserExists(int userId)
    {
        return _context.Users.Any(u => u.UserId == userId);
    }

    public bool Save()
    {
        var saved = _context.SaveChanges();
        return saved > 0 ? true : false;
    }

    public bool UpdateUser(User user)
    {
        _context.Update(user);
        return Save();
    }
}
}

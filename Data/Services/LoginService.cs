using eatery_manager_server.Data.Db;
using eatery_manager_server.Data.Models;

namespace eatery_manager_server.Data.Services
{
    public class LoginService
    {
        private readonly AppDbContext _context;

        public LoginService(AppDbContext context)
        {
            _context = context;
        }

        public List<Login> GetUsers()
        {
            return _context.Login.ToList();
        }

        public void Register(Login user)
        {
            _context.Login.Add(user);
            _context.SaveChanges();
        }

    }
}

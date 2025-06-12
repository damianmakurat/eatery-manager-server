using eatery_manager_server.Data.Db;
using eatery_manager_server.Data.Models;
using eatery_manager_server.Data.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;

namespace eatery_manager_server.Data.Services
{
    public class LoginService
    {
        private readonly AppDbContext _context;
        private readonly CustomAuthenticationStateProvider _authProvider;
        private readonly NavigationManager _navigationManager;

        public LoginService(AppDbContext context, CustomAuthenticationStateProvider authProvider, NavigationManager navigationManager)
        {
            _context = context;
            _authProvider = authProvider;
            _navigationManager = navigationManager;
        }

        public async Task RegisterAsync(Login user)
        {
            if (string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("Nazwa użytkownika i hasło nie mogą być puste.");

            if (_context.Login.Any(u => u.Username == user.Username || u.Email == user.Email))
                throw new InvalidOperationException("Użytkownik o tej nazwie lub e-mailu już istnieje.");

            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            _context.Login.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> LoginAsync(string usernameOrEmail, string password)
        {
            var user = await _context.Login
                .FirstOrDefaultAsync(u => u.Username == usernameOrEmail || u.Email == usernameOrEmail);

            if (user == null || !BCrypt.Net.BCrypt.Verify(password, user.Password))
                return false;

            _authProvider.MarkUserAsAuthenticated(user);

            if (user.Role == "Admin")
            {
                _authProvider.SetUserRole("Admin");
            }
            else
            {
                _authProvider.SetUserRole("User");
            }

            return true;
        }

        public void Logout()
        {
            _authProvider.MarkUserAsLoggedOut();
            _navigationManager.NavigateTo("/home");
        }

        public List<Login> GetUsers() => _context.Login.ToList();
    }
}

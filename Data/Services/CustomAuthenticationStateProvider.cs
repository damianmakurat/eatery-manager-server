using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using eatery_manager_server.Data.Models;

namespace eatery_manager_server.Data.Services
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly ClaimsPrincipal _anonymous = new(new ClaimsIdentity());
        private Login? _currentUser;

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if (_currentUser == null)
                return Task.FromResult(new AuthenticationState(_anonymous));

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, _currentUser.Username),
                new Claim(ClaimTypes.Role, _currentUser.Role)
            }, "apiauth");

            var user = new ClaimsPrincipal(identity);
            return Task.FromResult(new AuthenticationState(user));
        }

        public void MarkUserAsAuthenticated(Login user)
        {
            _currentUser = user;

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.Role)
            }, "apiauth");

            var principal = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(principal)));
        }

        public void MarkUserAsLoggedOut()
        {
            _currentUser = null;
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
        }

        public void SetUserRole(string role)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Role, role)
            }, "apiauth_type");

            var user = new ClaimsPrincipal(identity);
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(user)));
        }

    }
}

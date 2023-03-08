using System.Threading.Tasks;
using HoloHouse.Web.Data.Entities;
using HoloHouse.Web.Models;
using Microsoft.AspNetCore.Identity;


namespace HoloHouse.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email);

        Task<IdentityResult> AddUserAsync(User user, string password);
        Task<IdentityResult> UpdateUserAsync(User user);
        Task<bool> DeleteUserAsync(string email);
        Task CheckRoleAsync(string roleName);
        Task AddUserToRoleAsync(User user, string roleName);
        Task<bool> IsUserInRoleAsync(User user, string roleName);
        Task<SignInResult> LoginAsync(LoginViewModel model);
        Task LogoutAsync();
        Task<SignInResult> ValidatePasswordAsync(User user, string password);
        Task<User> AddUser(AddUserViewModel view, string role);
    }
}

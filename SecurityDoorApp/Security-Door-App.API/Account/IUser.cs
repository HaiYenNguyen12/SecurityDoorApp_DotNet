using Microsoft.AspNetCore.Mvc;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.DTOs;

namespace Security_Door_App.API.Account
{
    public interface IUser
    {
        Task<int> CreateAsync(CreateUserDTO model);
        Task<string> LoginAsync(LoginDTO model);
        Task<string> LogOutAsync();
        Task<string> GenerateConfirmationLinkAsync(User user);
        Task<bool> ConfirmEmail(string userId, string token);
    }
}

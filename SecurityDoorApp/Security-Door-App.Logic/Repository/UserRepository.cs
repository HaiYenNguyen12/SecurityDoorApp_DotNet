using Microsoft.AspNetCore.Identity;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;
using System.Data;

namespace Security_Door_App.Logic.Repository
{
    public class UserRepository : IUser
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserRepository
        (UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;

        }
        public async Task<int> CreateUser(CreateUserDTO model)
        {
            var user = new User
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                IdentificationNumber = model.IdentificationNumber,
                Comment = model.Comment,
                Email = model.Email,
                UserName = model.Username
            };

            var password = model.Password;
            var role = model.Role == null ? "employee" : model.Role.ToLower();
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
              
                if (!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
                await _userManager.AddToRoleAsync(user, role);
                return 1;
            }
            return -1;
            
        }
    }
}

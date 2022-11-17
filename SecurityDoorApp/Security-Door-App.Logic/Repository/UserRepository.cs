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
        private readonly SignInManager<User> _signInManager;
        public UserRepository
        (UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManage)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManage;

        }
        public async Task<int> CreateAsync(CreateUserDTO model)
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

        public async Task<string> LoginAsync(LoginDTO model)
        {
            model = model ?? throw new ArgumentNullException(nameof(model));
            var signInResult = await _signInManager
                    .PasswordSignInAsync(
                        model.Username,
                        model.Password,
                        model.RememberMe,
                        false);

                if (signInResult.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Username);
                    var isConfirmed = await _userManager.IsEmailConfirmedAsync(user);
                    if (!isConfirmed)
                    {
                        return("Email does not confirm. Happy Login!!!");

                    }
                        return ("Email confirmed. Shy Login!!!");
            }
                return("User login error");
        }

        
    }
}

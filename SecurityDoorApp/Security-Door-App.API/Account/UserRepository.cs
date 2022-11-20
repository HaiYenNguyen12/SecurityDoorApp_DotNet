using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Security_Door_App.API.Services;
using Security_Door_App.Data.Enums;
using Security_Door_App.Data.Models;
using Security_Door_App.Logic.DTOs;
using Security_Door_App.Logic.Interface;
using Security_Door_App.Logic.ViewModels;
using System;
using System.Data;
using System.Web;

namespace Security_Door_App.API.Account
{
    public class UserRepository : IUser
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IEmail _emailService;
        

        public UserRepository
        (UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<User> signInManage,
            IEmail emailService
            )
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManage;
            _emailService = emailService;
           
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
            var existEmail = _userManager.FindByEmailAsync(model.Email);
            if (existEmail == null)
            {
                return -1;
            }
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
                var new_user = await _userManager.FindByEmailAsync(user.Email);
                var confirmLink = await GenerateConfirmationLinkAsync(new_user);
                var res = await _emailService.SendEmailAsync(model.Email, confirmLink);
               

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
                    if (isConfirmed)
                    {
                    return ("Email confirmed. Happy Login!!!");
                    }
                    return ("Email does not confirm. Shy Login!!!");


                }
                return("User login error");
        }

        public async Task<string> LogOutAsync()
        {
            await _signInManager.SignOutAsync();
            return "Log Out successfully";
        }

        public async Task<string> GenerateConfirmationLinkAsync(User user)
        {
            var token = await _userManager.GenerateEmailConfirmationTokenAsync(user);
            string codeHtmlVersion = HttpUtility.UrlEncode(token);
            return ($"https://localhost:7123/api/User/confirm?userId={user.Id}&token={codeHtmlVersion}");
        }
        public async Task<bool> ConfirmEmail(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            var identityResult = await _userManager.ConfirmEmailAsync(user, token);
           
            var currentUser = await _userManager.FindByEmailAsync(user.Email);
            currentUser.EmailConfirmed = identityResult.Succeeded;
            return (identityResult.Succeeded);
        }

        public async Task<string> GetRolesByUser(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);
            if (roles.Count == 0) return "employee";
            return roles[0];
            
            


        }
    }
}

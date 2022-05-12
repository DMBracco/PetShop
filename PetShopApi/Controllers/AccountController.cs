using BLL.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetShopApi.ViewModels;

namespace PetShopApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpPost("/account-register-user")]
        public async Task<IActionResult> Register(UserViewModel model)
        {
            var msg = new MessageViewModel();
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Email };
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, model.RoleName);
                    // установка куки
                    await _signInManager.SignInAsync(user, false);
                    msg.message = "Добавлен новый пользователь:" + user.UserName;

                    return Ok(msg);
                }
                else
                {
                    msg.message = "Пользователь не добавлен.";

                    return Ok(msg);
                }
            }

            msg.message = "Входные данные не верны";
            return Ok(msg);
        }

        [HttpPost("/account-login-user")]
        public async Task<IActionResult> Login(UserViewModel model)
        {
            var msg = new MessageViewModel();

            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    var user = await _userManager.FindByNameAsync(model.Email);
                    IList<string> role = new List<string> { "Роль не определена" };
                    if (user != null)
                        role = await _userManager.GetRolesAsync(user);

                    msg.message = $"Выполнен вход пользователем: {model.Email}";
                    msg.roleName = role;
                    msg.user = model.Email;
                    return Ok(msg);
                }
                else
                {
                    msg.message = "Неправильный логин и (или) пароль";
                    return Ok(msg);
                }
            }

            msg.message = "Входные данные не верны";
            return Ok(msg);
        }

        [HttpGet("/account-get-role")]
        public IActionResult GetRole()
        {
            return Ok(_roleManager.Roles.Select(s => s.Name).ToList());
        }
    }
}

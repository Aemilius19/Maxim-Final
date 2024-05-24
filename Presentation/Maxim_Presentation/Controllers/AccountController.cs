using Maxim_Domain;
using Maxim_Domain.Helper;
using Maxim_Domain.ModelViews;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;

namespace Maxim_Presentation.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(RoleManager<IdentityRole> roleManager,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> CreateRole()
        {
            foreach (var item in Enum.GetValues(typeof(Role)))
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name=item.ToString(),
                });
            }
            return Ok();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            User user = new User()
            {
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Email = registerVM.Email,
                UserName = registerVM.UserName,
            };
            var result = await _userManager.CreateAsync(user, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("",item.Description);
                    return View();
                }
            }
            await _userManager.AddToRoleAsync(user,Role.Member.ToString());
            return RedirectToAction("Login");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM,string? ReturnUrl=null)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            
            if (loginVM.UserNameorEmail.Contains("@"))
            {
                var userr=await _userManager.FindByEmailAsync(loginVM.UserNameorEmail);
                if (userr == null)
                {
                    ModelState.AddModelError("", "User name or Email sehfdir");
                    return View();
                }
                var resultt=await _signInManager.CheckPasswordSignInAsync(userr, loginVM.Password,true);
                if (resultt.IsLockedOut)
                {
                    ModelState.AddModelError("", "Your accout is blocked. Try again later");
                    return View();
                }
                if (!resultt.Succeeded)
                {
                    ModelState.AddModelError("", "Password sehfdir");
                    return View();
                }
                await _signInManager.SignInAsync(userr, loginVM.RememberMe);
                if(ReturnUrl!= null)
                {
                    return Redirect(ReturnUrl);
                }
                return RedirectToAction("Index","Home");
                
            }
            var user = await _userManager.FindByNameAsync(loginVM.UserNameorEmail);
            if (user == null)
            {
                ModelState.AddModelError("", "User name or Email sehfdir");
                return View();
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, loginVM.Password, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your accout is blocked. Try again later");
                return View();
            }
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Password sehfdir");
                return View();
            }
            await _signInManager.SignInAsync(user, loginVM.RememberMe);
            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }
            return RedirectToAction("Index", "Home");

        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }


}

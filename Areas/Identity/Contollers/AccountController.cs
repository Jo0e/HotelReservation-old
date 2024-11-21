using AutoMapper;
using HotelReservation.DTO;
using HotelReservation.Models;
using HotelReservation.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages;

namespace HotelReservation.Areas.Identity.Contollers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUsers> userManager;
        private readonly SignInManager<ApplicationUsers> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IMapper mapper;

        public AccountController(UserManager<ApplicationUsers> userManager,SignInManager<ApplicationUsers> signInManager,RoleManager<IdentityRole> roleManager,IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Register()
        {
            if (roleManager.Roles.IsNullOrEmpty())
            {
                await roleManager.CreateAsync(new(SD.AdminRole));
                await roleManager.CreateAsync(new(SD.CompanyRole));
                await roleManager.CreateAsync(new(SD.CustomerRole));
            }

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(ApplicationUserDto userDto)
        {
            if (ModelState.IsValid)
            {             
                var user = mapper.Map<ApplicationUsers>(userDto);

                var result = await userManager.CreateAsync(user, userDto.Passwords);
                if (result.Succeeded)
                {
                    
                    await userManager.AddToRoleAsync(user, SD.CustomerRole);
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Login", "Account");
                }

                ModelState.AddModelError("Password", "Invalid Password");
            }

            return View();
        }
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginDTO userVm)
        {
            if (ModelState.IsValid)
            {
                var userDb = await userManager.FindByNameAsync(userVm.UserName);

                if (userDb != null)
                {
                    var finalResult = await userManager.CheckPasswordAsync(userDb, userVm.Password);

                    if (finalResult)
                    {
                        
                        await signInManager.SignInAsync(userDb, userVm.RememberMe);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                        
                        ModelState.AddModelError("Password", "invalid passwrod");
                }
                else
                    
                    ModelState.AddModelError("User", "invalid UserName");

            }
            return View(userVm);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }



    }
}

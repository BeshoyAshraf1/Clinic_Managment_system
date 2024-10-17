using DAL.Models;
using GradPro.Data;
using GradPro.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using System.Data;

namespace GradPro.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            this._userManager = userManager;
            this.signInManager = signInManager;
            _roleManager = roleManager;

        }
     
        [HttpGet]
        public IActionResult Register()
        {
            ViewBag.Roles = _roleManager.Roles.ToListAsync().Result;
            return View();
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                user.UserName = model.UserName;
                user.PasswordHash = model.Password;
                user.Age = model.Age;
                user.Address = model.Address;
                user.MedicalHistory = model.MedicalHistory;
                user.Email = model.Email;
                user.PhoneNumber = model.phoneNumber;
                IdentityResult result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    
                    var patientRole = await _roleManager.FindByIdAsync(model.RoleId.ToString());
                    await _userManager.AddToRoleAsync(user, patientRole.Name);
                    return RedirectToAction("Login", "Account");

                }
                else
                {
                    foreach (var item in result.Errors)
                    {
                        ModelState.AddModelError("msg", item.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var applicationUser = await _userManager.FindByNameAsync(model.UserName);

                if (applicationUser != null)
                {
                    bool isFound = await _userManager.CheckPasswordAsync(applicationUser, model.Password);

                    if (isFound)
                    {
                        await signInManager.SignInAsync(applicationUser, model.RememberMe);

                       // var currentUser = await _userManager.FindByNameAsync(User.Identity.Name);
                        var userRoles = await _userManager.GetRolesAsync(applicationUser);
                        foreach (var roleName in userRoles)
                        {
                            var role = await _roleManager.FindByNameAsync(roleName);
                            if (role.Id == "1")
                            {
                                return RedirectToAction("Index", "Admin" , new {Id= applicationUser.Id });
                            }
                            else if (role.Id == "2")
                            {
                                return RedirectToAction("Index", "Patient", new { Id = applicationUser.Id });
                            }
                            else if (role.Id == "3")
                            {
                                return RedirectToAction("Index", "Staff", new { Id = applicationUser.Id });
                            }
                            else
                            {
                                return RedirectToAction("Index", "Clinic", new { Id = applicationUser.Id });
                            }
                        }
                       


                    }
                }
                else
                {
                    ModelState.AddModelError("msg", "username or passord is in correct");
                }

            }
            return View(model);
        }

        public IActionResult Logout()
        {
            signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
        #region  Roles
        //Roles
        public async Task<IActionResult> Index()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return View(roles);
        }
        #endregion
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel.RoleViewModel;
using Shop_Sneaker.ViewModel.UserViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop_Sneaker.Controllers
{
    [Authorize(Roles = "system admin")]
    public class UserController : Controller
    {
        private readonly UserManager<AppIdentityUser> userManager;
        private SignInManager<AppIdentityUser> signInManager;
        private readonly RoleManager<AppIdentityRole> roleManager;

        public UserController(UserManager<AppIdentityUser> userManager,
                                SignInManager<AppIdentityUser> signInManager,
                                RoleManager<AppIdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        [Route("/User/Index", Name = "UserIndex")]
        public IActionResult Index()
        {
            var users = userManager.Users;
            if (users != null && users.Any())
            {
                var model = users.Select(u => new UserModel()
                {
                    UserId = u.Id,
                    Email = u.Email,
                    FullName = u.FullName,
                    Address = u.Address,
                    RoleName = u.UserName,

                }).ToList();
                foreach(var user in model)
                {
                    user.RoleName = GetRolesName(user.UserId);
                }
                return View(model);
            }
            return View();
 
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateUser model = new CreateUser()
            {
                Roles = roleManager.Roles.ToList()
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUser model)
        {
            model.Roles = roleManager.Roles.ToList();
            if (ModelState.IsValid)
            {
                var user = new AppIdentityUser()
                {
                    Email = model.Email,
                    FullName = model.FullName,
                    UserName = model.Email,
                    Address = model.Address
                };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.RoleId))
                    {
                        var role = await roleManager.FindByIdAsync(model.RoleId);
                        var addRoleResult = await userManager.AddToRoleAsync(user, role.Name);
                        if (addRoleResult.Succeeded)
                        {
                            return RedirectToAction("Index", "User");
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                    }
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }


        //public async Task<IActionResult> Create(CreateUser model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var user = new AppIdentityUser()
        //        {
        //            Email = model.Email,
        //            UserName = model.Email,
        //            FullName = model.FullName,
        //            Address = model.Address,

        //        };
        //        var result = await userManager.CreateAsync(user, model.Password);
        //        if (result.Succeeded)
        //        {
        //            if(!string.IsNullOrEmpty(model.RoleId))
        //            {
        //                var role = await roleManager.FindByIdAsync(model.RoleId);
        //                var addrole = await userManager.AddToRoleAsync(user, role.Name);
        //                if (addrole.Succeeded)
        //                {
        //                    return RedirectToAction(actionName: "Index", controllerName: "User");
        //                }
        //                foreach (var error in addrole.Errors)
        //                {
        //                    ModelState.AddModelError("", error.Description);
        //                }

        //            }
        //        }
        //        foreach (var error in result.Errors)
        //        {
        //            ModelState.AddModelError("", error.Description);
        //        }
        //    }
        //    return View(model);

        //}
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var result = new EditUser()
                {
                    UserId = user.Id,
                    FullName = user.FullName,
                    Address = user.Address,
                    Email = user.Email,
                    Roles = roleManager.Roles.ToList()
                };
                var rolename = await userManager.GetRolesAsync(user);
                if (rolename !=null)
                {
                    if (rolename.Any())
                    {
                        var role = await roleManager.FindByNameAsync(rolename.FirstOrDefault());
                        result.RoleId = role.Id;
                    }
                }
                return View(result);
            }
            return RedirectToAction(actionName: "Index");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditUser model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByIdAsync(model.UserId);
                if (user != null)
                {
                    user.FullName = model.FullName;
                    user.Address = model.Address;
                    user.Email = model.Email;
                    user.UserName = model.Email;
                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        var rolename = await userManager.GetRolesAsync(user);
                        var delrole = await userManager.RemoveFromRolesAsync(user, rolename);
                        if (!string.IsNullOrEmpty(model.RoleId))
                        {
                            var role = await roleManager.FindByIdAsync(model.RoleId);
                            var addrole = await userManager.AddToRoleAsync(user, role.Name);
                            if (addrole.Succeeded)
                            {
                                return RedirectToAction("index", "user");
                            }
                            foreach (var error in addrole.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                        return RedirectToAction("index", "user");
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }
        public async Task<IActionResult> Delete(string id)
        {
            var user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                var rolename = await userManager.GetRolesAsync(user);
                var deleteRole = await userManager.RemoveFromRolesAsync(user, rolename);
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction(actionName: "Index", controllerName: "User");
                }
            }
            return View();
        }







        public string GetRolesName(string userid)
        {
            var user = Task.Run(async () => await userManager.FindByIdAsync(userid)).Result;
            var roles = Task.Run(async () => await userManager.GetRolesAsync(user)).Result;
            return roles != null ? string.Join(", ", roles) : string.Empty;
        }

        public List<RoleModel> GetRoles()
        {
            var roles = roleManager.Roles;
            List<RoleModel> model = roles.Select(r => new RoleModel()
            {
                RoleId = r.Id,
                RoleName = r.Name
            }).ToList();
            return model;
        }
      
    }
}

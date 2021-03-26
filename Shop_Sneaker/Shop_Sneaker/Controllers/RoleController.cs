using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Shop_Sneaker.Entities;
using Shop_Sneaker.ViewModel;
using Shop_Sneaker.ViewModel.RoleViewModel;
using Shop_Sneaker.Views.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Shop_Sneaker.Controllers
{
    [Authorize(Roles = "system admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppIdentityRole> roleManager;

        public RoleController(RoleManager<AppIdentityRole> roleManager)
        {
            this.roleManager = roleManager;

        }
        [Route("/Role/Index", Name = "Index")]
        public IActionResult Index()
        {
            var role = roleManager.Roles;
            var model = new List<RoleModel>();
            model = role.Select(r => new RoleModel()
            {
                RoleId = r.Id,
                RoleName = r.Name
            }).ToList();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateRole model)
        {
            if (ModelState.IsValid)
            {
                var result = await roleManager.CreateAsync(new AppIdentityRole()
                {
                    Name = model.RoleName
                });
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Role");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View(model);
        }

        [HttpGet("/Employee/Delete/{Id}")]
        public async Task<IActionResult> Delete(string Id)
        {
            var del = await roleManager.FindByIdAsync(Id);
            if (del != null)
            {
                var result = await roleManager.DeleteAsync(del);
                if (result.Succeeded)
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Role");
                }

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string Id)
        {
            var role = await roleManager.FindByIdAsync(Id);
            if (role != null)
            {
                EditRole editRole = new EditRole()
                {
                    RoleId = role.Id,
                    RoleName = role.Name
                };
                return View(editRole);
             }
            return RedirectToAction(actionName: "Index", controllerName: "Role");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(EditRole model)
        {
            var role = await roleManager.FindByIdAsync(model.RoleId);
            if (role != null)
            {
                role.Name = model.RoleName;
                var result = await roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction(actionName: "Index", controllerName: "Role");

                }
            }
            return View();
             
        }
      
    }
}

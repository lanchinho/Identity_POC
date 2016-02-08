﻿using Infrastructure.Identity.Configuration;
using Infrastructure.Identity.Model;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebAppOne.Controllers
{
    public class RolesAdminController : Controller
    {
        private readonly ApplicationRoleManager _roleManager;
        private ApplicationUserManager _userManager;

        public RolesAdminController(ApplicationUserManager userManager, ApplicationRoleManager roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public ActionResult Index()
        {
            return View(_roleManager.Roles);
        }

        public async Task<ActionResult> Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await _roleManager.FindByIdAsync(id);
            // Get the list of Users in this Role
            var users = new List<ApplicationUser>();

            // Get the list of Users in this Role
            foreach (var user in _userManager.Users.ToList())
            {
                if (await _userManager.IsInRoleAsync(user.Id, role.Name))
                {
                    users.Add(user);
                }
            }

            ViewBag.Users = users;
            ViewBag.UserCount = users.Count();
            return View(role);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole(roleViewModel.Name);
                var roleresult = await _roleManager.CreateAsync(role);
                if (!roleresult.Succeeded)
                {
                    ModelState.AddModelError("", roleresult.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            var roleModel = new RoleViewModel { Id = role.Id, Name = role.Name };
            return View(roleModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Name,Id")] RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.FindByIdAsync(roleModel.Id);
                role.Name = roleModel.Name;
                await _roleManager.UpdateAsync(role);
                return RedirectToAction("Index");
            }
            return View();
        }

        public async Task<ActionResult> Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return HttpNotFound();
            }
            return View(role);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(string id, string deleteUser)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                var role = await _roleManager.FindByIdAsync(id);
                if (role == null)
                {
                    return HttpNotFound();
                }
                IdentityResult result;
                if (deleteUser != null)
                {
                    result = await _roleManager.DeleteAsync(role);
                }
                else
                {
                    result = await _roleManager.DeleteAsync(role);
                }
                if (!result.Succeeded)
                {
                    ModelState.AddModelError("", result.Errors.First());
                    return View();
                }
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
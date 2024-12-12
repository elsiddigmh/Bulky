using Bulky.DataAccess.Data;
using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]

    public class UserController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            List<ApplicationUser> users = _db.ApplicationUsers.Include(u => u.Company).ToList();

            var userRoles = _db.UserRoles.ToList(); 
            var roles = _db.Roles.ToList();

            foreach(var user in users)
            {
                var roleId = userRoles.FirstOrDefault(u => u.UserId == user.Id).RoleId;
                user.Role = roles.FirstOrDefault(u => u.Id ==  roleId).Name; 

                if(user.Company == null)
                {
                    user.Company = new() { Name = "" };
                }
            }
            return View(users);
        }

        public IActionResult RoleManagement(string userId)
        {
            string RoleID = _db.UserRoles.FirstOrDefault(u => u.UserId == userId).RoleId;

            RoleManagementVM RoleVM = new RoleManagementVM()
            {
                ApplicationUser = _db.ApplicationUsers.Include(u => u.Company).FirstOrDefault(u => u.Id == userId),
                RoleList = _db.Roles.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Name
                }),
                CompanyList = _db.Companies.Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };

            RoleVM.ApplicationUser.Role = _db.Roles.FirstOrDefault(u => u.Id == RoleID).Name;
            return View(RoleVM);
        }

        [HttpPost]
        public IActionResult RoleManagement(RoleManagementVM roleManagementVM)
        {
            string RoleID = _db.UserRoles.FirstOrDefault(u => u.UserId == roleManagementVM.ApplicationUser.Id).RoleId;
            string oldRole = _db.Roles.FirstOrDefault(u => u.Id == RoleID).Name;

            if (!(roleManagementVM.ApplicationUser.Role == oldRole))
            {
                //a role was updated
                ApplicationUser applicationUser = _db.ApplicationUsers.FirstOrDefault(u => u.Id == roleManagementVM.ApplicationUser.Id);
                if (roleManagementVM.ApplicationUser.Role == SD.Role_Company)
                {
                    applicationUser.CompanyId = roleManagementVM.ApplicationUser.CompanyId;
                }
                if (oldRole == SD.Role_Company)
                {
                    applicationUser.CompanyId = null;
                }
                _db.SaveChanges();

                _userManager.RemoveFromRoleAsync(applicationUser, oldRole).GetAwaiter().GetResult();
                _userManager.AddToRoleAsync(applicationUser, roleManagementVM.ApplicationUser.Role).GetAwaiter().GetResult();

            }

            return RedirectToAction("Index");
        }


        public IActionResult LockUnlock(string id)
        {

            var user = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                TempData["error"] = "Error while Locking/Unlocking";
                return RedirectToAction("Index");
            } 

            if(user.LockoutEnd != null && user.LockoutEnd > DateTime.Now)
            {
                // user is currently locked and we need to unlock them
                //user.LockoutEnd = DateTime.Now;
                user.LockoutEnd = null;
            }
            else
            {
                user.LockoutEnd = DateTime.Now.AddYears(1000);
            }

            _db.SaveChanges();

            TempData["success"] = "User account status has been updated";
            return RedirectToAction("Index");
        }



        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            TempData["success"] = "Company Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}

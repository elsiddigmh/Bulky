using Bulky.DataAccess.Repository.IRepository;
using Bulky.Models;
using Bulky.Models.ViewModels;
using Bulky.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize(Roles = SD.Role_Admin)]

    public class CompanyController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public CompanyController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Company> Companys = _unitOfWork.Company.GetAll().ToList();
            return View(Companys);
        }

        public IActionResult Upsert(int? id)
        {
            if(id == null || id == 0)
            {
                //Create
                return View(new Company());
            }
            else
            {
                //Update
                Company companyObj = _unitOfWork.Company.Get(u=>u.Id == id);
                return View(companyObj);
            }
        }

        [HttpPost]
        public IActionResult Upsert(Company CompanyObj)
        {
            if (ModelState.IsValid)
            {
              
                if (CompanyObj.Id == 0)
                {
                    _unitOfWork.Company.Add(CompanyObj);
                    TempData["success"] = "Company Created Successfully";
                }
                else
                {
                    _unitOfWork.Company.Update(CompanyObj);
                    TempData["success"] = "Company Updated Successfully";

                }

                _unitOfWork.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(CompanyObj);

            }


        }

        public IActionResult Delete(int? id)
        {
            if (id == null && id == 0)
            {
                return NotFound();
            }
            Company? companyObj = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyObj == null)
            {
                return NotFound();
            }
            return View(companyObj);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {

            Company companyObj = _unitOfWork.Company.Get(u => u.Id == id);
            if (companyObj == null)
            {
                return NotFound();
            }
            _unitOfWork.Company.Remove(companyObj);
            _unitOfWork.Save();
            TempData["success"] = "Company Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}

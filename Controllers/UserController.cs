using DataValidations.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataValidations.Controllers
{
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Index(UserModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        return RedirectToAction("Success");
        //    }
        //    return View(model);
        //}

        [HttpPost]
        public IActionResult Index(UserModel model)
        {
            if (model.HighestEducation == "Engineering" && string.IsNullOrEmpty(model.EngineeringBranch))
            {
                ModelState.AddModelError("EngineeringBranch", "Engineering Branch is required if Highest Education is Engineering");
            }

            if (ModelState.IsValid)
            {
                // Process the valid model
                return RedirectToAction("Success");
            }

            // Return the view with validation errors
            return View(model);
        }

        public IActionResult Success()
        {
            return View();
        }
    }
}

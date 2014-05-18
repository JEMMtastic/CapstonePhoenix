using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Capstone.Domain.Abstract;
using Capstone.Domain.Concrete;
using Capstone.Domain.Entities;

namespace Capstone.WebUI.Controllers
{
    public class AdminUserController : Controller
    { 
        UserInterface uRepo;
        BvLocationInterface lRepo;

        // The default constructor is called by the framework
        public AdminUserController()
        {
            uRepo = new UserRepository();
            lRepo = new BvLocationRepository();
        }

        // Use this for dependency injection
        public AdminUserController(UserInterface iUser, BvLocationInterface iLocation)
        {
            uRepo = iUser;
            lRepo = iLocation;
        }

        public ActionResult AdminUserIndex()
        {
            //need to get a list of all users
            var db = new CapstoneDbContext();
            List<User> users = (from u in db.Users.Include("BvLocation")
                                select u).ToList<User>();

               
            //TODO:  add functionality to get users by restaurant or city?
            return View(users);
        }

        public ActionResult EditUser(int userId)
        {
            User u = uRepo.GetUser(userId);
            return View(u);
        }
        [HttpPost]
        public ActionResult EditUser(User u)
        {
            if (ModelState.IsValid)
            {
                BvLocation l = lRepo.GetBvLocation(u.BvLocation.BvStoreNum);
                if (l != null)
                {
                    u.BvLocation = l;
                    uRepo.SaveUser(u);
                    TempData["message"] = string.Format("{0} has been saved", u.UserFName + " " + u.UserLName);
                }
                else
                {
                    TempData["message"] = string.Format("{0} is not a valid Restaurant", u.BvLocation.BvStoreNum);
                }
                return RedirectToAction("AdminUserIndex");
            }
            else
            {
                return View(u);
            }
        }
        public ViewResult CreateUser()
        {
            return View("EditUser", new User());
        }

        [HttpPost]
        public ActionResult DeleteUser(int userId)
        {
            User deletedUser = uRepo.DeleteUser(userId);
            if (deletedUser != null)
            {
                TempData["message"] = string.Format("{0} was deleted", deletedUser.UserFName + deletedUser.UserLName);
            }
            return RedirectToAction("AdminUserIndex");
        }

    }
}

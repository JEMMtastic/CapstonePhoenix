using Capstone.WebUI.Domain.Abstract;
using Capstone.WebUI.Domain.Concrete;
using Capstone.WebUI.Domain.Entities;
using Capstone.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Capstone.WebUI.Controllers
{
    public class LeaderBoardController : Controller
    {
        FormInterface fRepo;

        // The default constructor is called by the framework
        public LeaderBoardController()
        {
            fRepo = new FormRepository();
        }

        public ActionResult Index()
        {
            return View();
        }

        /* public Form GetComplete()
        {
            var db = new ApplicationDbContext();
            var leaderForms = (from f in db.Forms
                                where f.complete = true
                                select f).ToList<Form>();
        }*/
    }
}
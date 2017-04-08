using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pakizin.Helpers;
using Pakizin.Models;
using PagedList;

namespace Pakizin.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private PakizinEntities db = new PakizinEntities();
        public ActionResult Index(int? page)
        {
            DateTime date = DateTime.Now;
            int time = Convert.ToInt16(date.Hour);
            ViewBag.grreting = TimeHelper.Greeting(time);
            var profil = (from s in db.tbl_user
                          select s);
            var detail = profil.FirstOrDefault();
            ViewBag.name = detail.FullName;
            ViewBag.desc = detail.Description;

            ViewData["skills"] = from s in db.tbl_skill
                                 select s;

            ViewData["ability"] = from s in db.tbl_ability
                                  select s;

            ViewData["all"] = from s in db.tbl_portfolio
                              select s;
            ViewData["eoffice"] = from s in db.tbl_portfolio
                                  where s.Groupping.Contains("eoffice")
                                  select s;
            ViewData["idsync"] = from s in db.tbl_portfolio
                                 where s.Groupping.Contains("idsync")
                                 select s;
            var education = from s in db.tbl_education
                            select s;
            ViewData["education"] = education;
            ViewBag.minEdu = education.OrderBy(s => s.Id).Take(1).FirstOrDefault().Id.ToString();
            ViewBag.maxEdu = education.OrderByDescending(s => s.Id).Take(1).FirstOrDefault().Id.ToString();

            var experience = from s in db.tbl_experience
                             select s;
            ViewData["experience"] = experience;
            ViewBag.minExpe = experience.OrderBy(s => s.Id).Take(1).FirstOrDefault().Id.ToString();
            ViewBag.maxExpe = experience.OrderByDescending(s => s.Id).Take(1).FirstOrDefault().Id.ToString();

            var post = from s in db.tbl_post
                       orderby s.Date descending
                       select s;
            ViewData["blog"] = post;
            int pageNumber = (page ?? 1);
            int pageSize = 3;
            return PartialView(post.ToPagedList(pageNumber, pageSize));
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
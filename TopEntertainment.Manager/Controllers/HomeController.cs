using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopEntertainment.Database;
using TopEntertainment.Manager.MetaData;
using TopEntertainment.Manager.Models;
using TopEntertainment.Database;

namespace TopEntertainment.Manager.Controllers
{
    public class HomeController : Controller
    {
        private readonly TopEntertainmentContext _context;

        public HomeController(DbContext context)
        {
            _context = (TopEntertainmentContext)context;
        }

        public IActionResult Login()
        {
            var data = new AdministratorMD();

            return View(data);
        }

        [HttpPost]
        public IActionResult Login(AdministratorMD metaData)
        {
            if (string.IsNullOrEmpty(metaData.Account))
            {
                ViewBag.ErrorMessage = $"請輸入帳號";

                return View(metaData);
            }

            if (string.IsNullOrEmpty(metaData.Password))
            {
                ViewBag.ErrorMessage = $"請輸入密碼";

                return View(metaData);
            }

            var administrator = _context.Administrators.Single(x => x.Account.Equals(metaData.Account, StringComparison.CurrentCultureIgnoreCase));
            if(administrator == null)
            {
                ViewBag.ErrorMessage = $"帳號錯誤";

                return View(metaData);
            }

            if (!administrator.Password.Equals(metaData.Password))
            {
                ViewBag.ErrorMessage = $"密碼錯誤";

                return View(metaData);
            }

            return RedirectToAction("Index", "Member");
        }
    }
}

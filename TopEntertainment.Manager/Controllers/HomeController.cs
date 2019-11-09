using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopEntertainment.Database;
using TopEntertainment.Database.Enum;
using TopEntertainment.Manager.MetaData;

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
            var data = new LoginMD();

            ModelState.Clear();

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginMD metaData)
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

            if (administrator.Status != AccountStatusTypeEnum.Normal)
            {
                ViewBag.ErrorMessage = $"帳號狀態異常";

                return View(metaData);
            }

            return RedirectToAction("Index", "Member");
        }

        public IActionResult Error(string message = "")
        {
            ViewBag.ErrorMessage = message;

            return View();
        }
    }
}

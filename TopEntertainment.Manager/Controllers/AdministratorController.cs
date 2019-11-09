using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopEntertainment.Database;
using TopEntertainment.Database.Enum;
using TopEntertainment.Manager.MetaData;

namespace TopEntertainment.Manager.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly TopEntertainmentContext _context;

        public AdministratorController(DbContext context)
        {
            _context = (TopEntertainmentContext)context;
        }

        public IActionResult Index()
        {
            var data = _context.Administrators.AsNoTracking();

            return View(data);
        }

        public IActionResult Create()
        {
            var data = new AdministratorMD();

            ModelState.Clear();

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdministratorMD metaData)
        {
            _context.Administrators.Add(metaData.ToEntity());

            if (_context.SaveChanges() <= 0)
            {
                ViewBag.ErrorMessage = $"新增失敗，請聯絡系統管理員";

                return View(metaData);
            }

            return RedirectToAction("Index", "Administrator");
        }

        public IActionResult Update(int id)
        {
            var entity = _context.Administrators.Single(x => x.Id == id);

            if (entity == null)
                return RedirectToAction("Error", "Home", new { message = $"無管理者資料" });

            var metaData = AdministratorMD.ToMetaData(entity);

            return View(metaData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(AdministratorMD metaData)
        {
            var entity = metaData.ToEntity();

            _context.Entry(entity).State = EntityState.Modified;

            if (_context.SaveChanges() <= 0)
            {
                ViewBag.ErrorMessage = $"更新失敗，請聯絡系統管理員";

                return View(metaData);
            }

            return RedirectToAction("Index", "Administrator");
        }

        public IActionResult Delete(int id)
        {
            var entity = _context.Administrators.Single(x => x.Id == id);

            if (entity == null)
                return RedirectToAction("Error", "Home", new { message = $"無管理者資料" });

            var metaData = AdministratorMD.ToMetaData(entity);

            return View(metaData);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(AdministratorMD metaData)
        {
            var entity = metaData.ToEntity();

            entity.Status = AccountStatusTypeEnum.Delete;

            _context.Entry(entity).State = EntityState.Modified;

            if (_context.SaveChanges() <= 0)
            {
                ViewBag.ErrorMessage = $"刪除失敗，請聯絡系統管理員";

                return View(metaData);
            }

            return RedirectToAction("Index", "Administrator");
        }
    }
}
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopEntertainment.Database;
using TopEntertainment.Manager.MetaData;

namespace TopEntertainment.Manager.Controllers
{
    public class MemberController : Controller
    {
        private readonly TopEntertainmentContext _context;

        public MemberController(DbContext context)
        {
            _context = (TopEntertainmentContext)context;
        }

        public IActionResult Index()
        {
            var data = _context.Members.AsNoTracking();

            return View(data);
        }

        public IActionResult Create()
        {
            var data = new MemberMD();

            return View(data);
        }

        [HttpPost]
        public IActionResult Create(MemberMD metaData)
        {
            _context.Members.Add(metaData.ToEntity());

            if(_context.SaveChanges() <= 0)
            {
                ViewBag.ErrorMessage = $"新增失敗，請聯絡系統管理員";

                return View(metaData);
            }

            return RedirectToAction("Index", "Member");
        }

        public IActionResult Update(int id)
        {
            var entity = _context.Members.Single(x => x.Id == id);

            if (entity == null)
                return RedirectToAction("Error", "Home", new { message = $"無會員資料" });

            var metaData = MemberMD.ToMetaData(entity);

            return View(metaData);
        }

        [HttpPost]
        public IActionResult Update(MemberMD metaData)
        {
            var entity = metaData.ToEntity();

            _context.Entry(entity).State = EntityState.Modified;

            if (_context.SaveChanges() <= 0)
            {
                ViewBag.ErrorMessage = $"更新失敗，請聯絡系統管理員";

                return View(metaData);
            }

            return RedirectToAction("Index", "Member");
        }

        public IActionResult Delete(int id)
        {
            var entity = _context.Members.Single(x => x.Id == id);

            if (entity == null)
                return RedirectToAction("Error", "Home", new { message = $"無會員資料" });

            var metaData = MemberMD.ToMetaData(entity);

            return View(metaData);
        }

        [HttpPost]
        public IActionResult Delete(MemberMD metaData)
        {
            _context.Members.Remove(metaData.ToEntity());

            if (_context.SaveChanges() <= 0)
            {
                ViewBag.ErrorMessage = $"刪除失敗，請聯絡系統管理員";

                return View(metaData);
            }

            return RedirectToAction("Index", "Member");
        }
    }
}
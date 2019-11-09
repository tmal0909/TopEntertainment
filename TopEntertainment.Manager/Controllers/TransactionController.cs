using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TopEntertainment.Database;
using TopEntertainment.Database.Entity;
using TopEntertainment.Database.Enum;
using TopEntertainment.Manager.MetaData;

namespace TopEntertainment.Manager.Controllers
{
    public class TransactionController : Controller
    {
        private readonly TopEntertainmentContext _context;

        public TransactionController(DbContext context)
        {
            _context = (TopEntertainmentContext)context;
        }

        public IActionResult Index(int memberId = -1)
        {
            var data = _context.TransactionRecords
                .Include(x => x.Member)
                .Include(x => x.Operator)
                .AsNoTracking();

            if (memberId != -1)
                data = data.Where(x => x.MemberId == memberId);

            return View(data);
        }

        public IActionResult Recharge(int memberId)
        {
            var member = _context.Members.Single(x => x.Id == memberId);

            if (member == null)
            {
                ViewBag.ErrorMessage = $"查無會員，請聯絡系統管理員";

                return PartialView("_TransactionError");
            }

            var data = new RechargeMD
            {
                MemberId = member.Id,
                MemberName = member.Name,
                Integration = member.Integration,
                DealIntegration = 0
            };

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Recharge(RechargeMD metaData)
        {
            try
            {
                var member = _context.Members.SingleOrDefault(x => x.Id == metaData.MemberId);

                if (member == null)
                    throw new Exception($"無該會員資料");

                if (member.Status != AccountStatusTypeEnum.Normal)
                    throw new Exception($"該會員帳號狀態異常");

                if (metaData.DealIntegration <= 0)
                    throw new Exception($"提交金額錯誤");

                member.Integration += metaData.DealIntegration;

                _context.Entry(member).State = EntityState.Modified;
                _context.TransactionRecords.Add(new TransactionRecordEntity
                {
                    TransactionId = Guid.NewGuid().ToString(),
                    Type = TransactionTypeEnum.OnSite_CashRecharge,
                    Integration = metaData.DealIntegration,
                    MemberId = metaData.MemberId,
                    OperatorId = _context.Administrators.First().Id
                });

                if (_context.SaveChanges() <= 0)
                    throw new Exception($"無法新增交易紀錄");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"充值失敗，{ex.Message}，請聯絡系統管理員";

                return View(metaData);
            }

            return RedirectToAction("Index", "Transaction");
        }

        public IActionResult Exchange(int memberId)
        {
            var member = _context.Members.Single(x => x.Id == memberId);

            if (member == null)
            {
                ViewBag.ErrorMessage = $"查無會員，請聯絡系統管理員";

                return PartialView("_TransactionError");
            }

            var data = new ExchangeMD
            {
                MemberId = member.Id,
                MemberName = member.Name,
                Integration = member.Integration,
                DealIntegration = 0
            };

            return View(data);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Exchange(ExchangeMD metaData)
        {
            try
            {
                var member = _context.Members.SingleOrDefault(x => x.Id == metaData.MemberId);

                if (member == null)
                    throw new Exception($"無該會員資料");

                if (member.Status != AccountStatusTypeEnum.Normal)
                    throw new Exception($"該會員帳號狀態異常");

                if (metaData.DealIntegration <= 0)
                    throw new Exception($"提交金額錯誤");

                member.Integration -= metaData.DealIntegration;

                _context.Entry(member).State = EntityState.Modified;
                _context.TransactionRecords.Add(new TransactionRecordEntity
                {
                    TransactionId = Guid.NewGuid().ToString(),
                    Type = TransactionTypeEnum.OnSite_ChipExchange,
                    Integration = metaData.DealIntegration,
                    MemberId = metaData.MemberId,
                    OperatorId = _context.Administrators.First().Id
                });

                if (_context.SaveChanges() <= 0)
                    throw new Exception($"無法新增交易紀錄");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = $"兌換失敗，{ex.Message}，請聯絡系統管理員";

                return View(metaData);
            }

            return RedirectToAction("Index", "Transaction");
        }
    }
}
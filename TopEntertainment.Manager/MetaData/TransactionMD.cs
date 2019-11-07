using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TopEntertainment.Manager.MetaData
{
    public class TransactionMD
    {
        [HiddenInput]
        public int MemberId { get; set; }

        [Display(Name = "會員名稱", Prompt = "請輸入會員名稱")]
        public string MemberName { get; set; }

        [Display(Name = "會員餘額", Prompt = "請輸入會員餘額")]
        public decimal Integration { get; set; }

        [Display(Name = "交易積分", Prompt = "請輸入交易積分")]
        public decimal DealIntegration { get; set; }
    }
}

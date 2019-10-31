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

        public string MemberName { get; set; }

        public decimal Integration { get; set; }

        public decimal DealIntegration { get; set; }
    }
}

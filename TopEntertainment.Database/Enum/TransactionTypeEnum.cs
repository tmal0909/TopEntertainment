using System.ComponentModel.DataAnnotations;

namespace TopEntertainment.Database.Enum
{
    public enum TransactionTypeEnum
    {
        [Display(Name = "現金充值")]
        OnSite_CashRecharge,

        [Display(Name = "籌碼兌換")]
        OnSite_ChipExchange,
    }
}

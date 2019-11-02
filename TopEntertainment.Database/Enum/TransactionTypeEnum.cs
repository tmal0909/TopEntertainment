using System.ComponentModel.DataAnnotations;

namespace TopEntertainment.Database.Enum
{
    public enum TransactionTypeEnum
    {
        [Display(Name = "充值")]
        Recharge,

        [Display(Name = "兌換")]
        Exchange,

        [Display(Name = "轉入")]
        TransferIn,

        [Display(Name = "轉出")]
        TransferOut
    }
}

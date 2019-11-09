using System.ComponentModel.DataAnnotations;

namespace TopEntertainment.Database.Enum
{
    public enum AccountStatusTypeEnum
    {
        [Display(Name = "刪除")]
        Delete = -1,

        [Display(Name = "停用")]
        Forbidden = 0,

        [Display(Name = "正常")]
        Normal = 1
    }
}

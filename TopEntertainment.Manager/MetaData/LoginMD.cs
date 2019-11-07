using System.ComponentModel.DataAnnotations;

namespace TopEntertainment.Manager.MetaData
{
    public class LoginMD
    {
        [Required(ErrorMessage = "請輸入帳號")]
        [StringLength(50, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "帳號", Prompt = "請輸入帳號")]
        public string Account { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "請輸入密碼")]
        [StringLength(50, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "密碼", Prompt = "請輸入密碼")]
        public string Password { get; set; }
    }
}

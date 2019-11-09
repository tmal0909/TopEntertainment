using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TopEntertainment.Database.Entity;
using TopEntertainment.Database.Enum;
using TopEntertainment.Extension;

namespace TopEntertainment.Manager.MetaData
{
    public class AdministratorMD
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required(ErrorMessage = "請輸入帳號")]
        [StringLength(50, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "帳號", Prompt = "請輸入帳號")]
        public string Account { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "請輸入密碼")]
        [StringLength(50, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "密碼", Prompt = "請輸入密碼")]
        public string Password { get; set; }

        [Required(ErrorMessage = "請輸入身分證字號")]
        [StringLength(50, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "身分證字號", Prompt = "請輸入身分證字號")]
        public string Identity { get; set; }

        [Required(ErrorMessage = "請輸入姓名")]
        [StringLength(50, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "姓名", Prompt = "請輸入姓名")]
        public string Name { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "請輸入出生日期")]
        [Display(Name = "出生日期", Prompt = "請選擇出生日期")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "請輸入電話")]
        [StringLength(50, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "電話", Prompt = "請輸入電話")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "請輸入地址")]
        [StringLength(50, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "地址", Prompt = "請輸入地址")]
        public string Address { get; set; }

        [Required(ErrorMessage = "請選擇帳號狀態")]
        [Display(Name = "帳號狀態", Prompt = "請選擇帳號狀態")]
        public AccountStatusTypeEnum Status { get; set; }

        public List<SelectListItem> StatusOptions { get; set; }


        public AdministratorMD()
        {
            StatusOptions = GetOptions();
        }

        public AdministratorEntity ToEntity()
        {
            return new AdministratorEntity
            {
                Id = this.Id,
                Account = this.Account,
                Password = this.Password,
                Identity = this.Identity,
                Name = this.Name,
                Birthday = DateTime.UtcNow.AddHours(8),
                Phone = this.Phone,
                Address = this.Address,
                Status = this.Status
            };
        }
        
        public static AdministratorMD ToMetaData(AdministratorEntity entity)
        {
            return new AdministratorMD
            {
                Id = entity.Id,
                Account = entity.Account,
                Password = entity.Password,
                Identity = entity.Identity,
                Name = entity.Name,
                Birthday = entity.Birthday,
                Phone = entity.Phone,
                Address = entity.Address,
                Status = entity.Status,
                StatusOptions = GetOptions()
            };
        }

        public static List<SelectListItem> GetOptions()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Text = EnumHelper<AccountStatusTypeEnum>.GetDisplayValue(AccountStatusTypeEnum.Normal), Value = AccountStatusTypeEnum.Normal.ToString() },
                new SelectListItem { Text = EnumHelper<AccountStatusTypeEnum>.GetDisplayValue(AccountStatusTypeEnum.Forbidden), Value = AccountStatusTypeEnum.Forbidden.ToString() },
                new SelectListItem { Text = EnumHelper<AccountStatusTypeEnum>.GetDisplayValue(AccountStatusTypeEnum.Delete), Value = AccountStatusTypeEnum.Delete.ToString() },
            };
        }
    }
}

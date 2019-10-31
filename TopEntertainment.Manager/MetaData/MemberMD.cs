using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using TopEntertainment.Database.Entity;

namespace TopEntertainment.Manager.MetaData
{
    public class MemberMD
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

        public decimal Integration { get; set; }

        [Required(ErrorMessage = "請輸入身分證字號")]
        [StringLength(50, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "身分證字號", Prompt = "請輸入身分證字號")]
        public string Identity { get; set; }

        [Required(ErrorMessage = "請輸入姓名")]
        [StringLength(50, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "姓名", Prompt = "請輸入姓名")]
        public string Name { get; set; }

        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "請輸入電話")]
        [StringLength(50, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "電話", Prompt = "請輸入電話")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "請輸入地址")]
        [StringLength(50, ErrorMessage = "資料長度過長，請重新輸入")]
        [Display(Name = "地址", Prompt = "請輸入地址")]
        public string Address { get; set; }

        public int Role { get; set; }


        public static MemberMD ToMetaData(MemberEntity entity)
        {
            return new MemberMD
            {
                Id = entity.Id,
                Account = entity.Account,
                Password = entity.Password,
                Integration = entity.Integration,
                Identity = entity.Identity,
                Name = entity.Name,
                Birthday = entity.Birthday,
                Phone = entity.Phone,
                Address = entity.Address,
                Role = entity.Role
            };
        }

        public MemberEntity ToEntity()
        {
            return new MemberEntity
            {
                Id = this.Id,
                Account = this.Account,
                Password = this.Password,
                Integration = this.Integration,
                Identity = this.Identity,
                Name = this.Name,
                Birthday = DateTime.UtcNow.AddHours(8),
                Phone = this.Phone,
                Address = this.Address,
                Role = this.Role
            };
        }
    }
}

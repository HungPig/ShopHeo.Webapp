using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ShopHeo.ViewModels.CataLog.Users
{
    public class UserUpdateRequest
    {
        public Guid Id { get; set; }

        [Display(Name = "Tên")]
        public string FirtName { get; set; }
        [Display(Name = "Họ")]
        public string LastName { get; set; }
        [Display(Name = "Ngày Sinh")]
        public DateTime Dob { get; set; }
        [Display(Name = "Số Điện Thoại")]
        public int PhoneNumber { get; set; }
        [Display(Name = "Hòm Thư")]
        public string Email { get; set; }
    }
}

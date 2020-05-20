using System;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Models
{
    public class EmployeeModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Mời nhập tên")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Mời nhập tên đăng nhập")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu cũ")]
        [StringLength(100)]
        public string ComfirmOldPassword { get; set; }

        [Required(ErrorMessage = "Mời nhập mật khẩu mới")]
        [StringLength(100)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Xác nhận mật khẩu")]
        [StringLength(100)]
        public string ComfirmNewPassword { get; set; }

        [Required(ErrorMessage = "Giới tính")]
        public string Sex { get; set; }

        [Required(ErrorMessage = "Mời nhập địa chỉ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Mời nhập sinh nhật")]
        public DateTime? Birthday { get; set; }

        [Required(ErrorMessage = "Mời nhập số điện thoại")]
        public string Phone { get; set; }
    }
}

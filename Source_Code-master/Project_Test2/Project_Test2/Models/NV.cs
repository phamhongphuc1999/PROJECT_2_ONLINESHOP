using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Project_Test2.Models
{
    public class NV
    {
        [Key]
        [Required]
        public int MANV { get; set; }
        [Required]
        public string HOTEN { get; set; }
        public string GIOITINH { get; set; }
        [Required]
        public string SDT { get; set; }
        [Required]
        public DateTime NGAYSINH { get; set; }
        public string DIACHI { get; set; }
        [Required(ErrorMessage = "Hãy nhập username cho nhân viên mới")]
        [Remote("IsAlreadyUsername", "NVs", HttpMethod = "POST", ErrorMessage = "Username đã tồn tại")]
        public string USERNAME { get; set; }
        [Required(ErrorMessage = "Hãy nhập password cho nhân viên mới")]
        public string PASSWORD { get; set; }
        [Required(ErrorMessage = "Hãy nhập loại nhân viên")]
        public string TYPENV { get; set; }
        public virtual ICollection<HOADON> HOADONS { get; set; }
    }
}
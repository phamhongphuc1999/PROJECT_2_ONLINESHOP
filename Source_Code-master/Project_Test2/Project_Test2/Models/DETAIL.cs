using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Test2.Models
{
    public class DETAIL
    {
        [Key]
        [Required]
        public int MADT { get; set; }

        [Required]
        public int MAHD { get; set; }
        [Required]
        public int SOLUONG { get; set; }
        [Required]
        public string MASP { get; set; }
        [Required]
        public string TENSP { get; set; }
        [Required]
        public string MALO { get; set; }
        [Required]
        public int? GIANHAP { get; set; }
        [Required]
        public int? GIABAN { get; set; }
        [Required]
        public int? TIEN { get; set; }
        [Required]
        public DateTime NGAYBAN { get; set; }
    }
}
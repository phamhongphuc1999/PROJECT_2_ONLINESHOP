using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Test2.Models
{
    public class KHACHHANG
    {
        [Key]
        [Required]

        public int MAKH { get; set; }
        [Required]
        public string TENKH { get; set; }

        public string DIACHI { get; set; }
        [Required]
        public string SODT { get; set; }
        public string GHICHU { get; set; }
        public virtual ICollection<HOADON> HOADONS { get; set; }

    }
}
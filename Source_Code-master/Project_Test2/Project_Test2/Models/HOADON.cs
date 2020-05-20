using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Project_Test2.Models
{
    public class HOADON
    {
        [Key]
        [Required]
        public int MAHD { get; set; }
        [Required]
        public int MANV { get; set; }
        [Required]
        public int MAKH { get; set; }

        [Required]
        public DateTime NGAYBAN { get; set; }
     
        public virtual KHACHHANG KHACHHANG { get; set; }
        public virtual NV NV { get; set; }
        public virtual ICollection<DETAIL> DETAILs { get; set; }

    }
}
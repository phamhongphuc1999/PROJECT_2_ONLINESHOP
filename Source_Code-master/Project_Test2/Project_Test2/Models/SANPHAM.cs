using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Project_Test2.Models
{
    public class SANPHAM
    {
        [Key, Column(Order = 1)]
        [Required]
        public string MASP { get; set; }
        [Required]
        public string TENSP { get; set; }
        [Key, Column(Order = 2)]
        [Required]
        public string MALO { get; set; }
        [Required]
        public int GIANHAP { get; set; }
        [Required]
        public int LOINHUAN { get; set; }
        [Required]
        public int BAOHANH { get; set; }
        [Required]
        public int SL { get; set; }
        public int Sale { get; set; }
        public virtual ICollection<DETAIL> DETAILS { get; set; }
    }
}
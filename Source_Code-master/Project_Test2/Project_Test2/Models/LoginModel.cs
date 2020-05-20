using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Project_Test2.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage="Mời nhập username")]
        
        public string UserName { get; set; }
        [Required(ErrorMessage = "Mời nhập password")]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
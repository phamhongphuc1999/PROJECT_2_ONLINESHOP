using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Test2.Common
{
    [Serializable]
    public class UserLogin
    { 
        public int UserID { get; set; }
        public string UserName { get; set; }

        public string Name { get; set; }

        public string TypeNV { get; set; }
    }
}
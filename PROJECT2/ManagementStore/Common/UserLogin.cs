﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManagementStore.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { get; set; }
        public string Username { get; set; }

        public string Name { get; set; }

        public string TypeEmployee { get; set; }
    }
}
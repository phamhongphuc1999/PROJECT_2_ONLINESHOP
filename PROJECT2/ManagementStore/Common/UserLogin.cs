using System;

namespace ManagementStore.Common
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string Image { get; set; }

        public string Name { get; set; }

        public string TypeEmployee { get; set; }
    }
}
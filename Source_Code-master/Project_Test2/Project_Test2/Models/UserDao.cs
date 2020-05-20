using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Test2.Models
{
    public class UserDao
    {
        Project_Test2Context db = null;
        public UserDao()
        {
            db = new Project_Test2Context();
        }
        public long Insert(NV entity)
        {
            db.NVs.Add(entity);
            db.SaveChanges();
            return entity.MANV;
        }   
        public NV GetByID(string username)
        {
            return db.NVs.SingleOrDefault(x => x.USERNAME == username);
        }
        public bool Login(string userName, string password)
        {
            var result = db.NVs.Count(x => x.USERNAME == userName && x.PASSWORD == password);
            if (result > 0)
            {
                return true;
            }
            else return false;
        }
    }
}
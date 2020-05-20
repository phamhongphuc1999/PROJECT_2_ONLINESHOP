using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MODELS.EF;

namespace MODELS.Dao
{
    public class BaseDao
    {
        protected DatabaseOnlineShop db = null;

        public BaseDao()
        {
            db = new DatabaseOnlineShop();
        }

        public DatabaseOnlineShop DB
        {
            get { return db; }
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}

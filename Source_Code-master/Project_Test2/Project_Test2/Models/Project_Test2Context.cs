using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project_Test2.Models
{
    public class Project_Test2Context : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Project_Test2Context() : base("name=Project_Test2Context")
        {
        }

        public System.Data.Entity.DbSet<Project_Test2.Models.KHACHHANG> KHACHHANGs { get; set; }
        public System.Data.Entity.DbSet<Project_Test2.Models.DETAIL> DETAILs { get; set; }
        public System.Data.Entity.DbSet<Project_Test2.Models.HOADON> HOADONs { get; set; }
        public System.Data.Entity.DbSet<Project_Test2.Models.NV> NVs { get; set; }

        public System.Data.Entity.DbSet<Project_Test2.Models.SANPHAM> SANPHAMs { get; set; }
    }
}

namespace Project_Test2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DETAILs",
                c => new
                    {
                        MADT = c.Int(nullable: false, identity: true),
                        MAHD = c.Int(nullable: false),
                        SOLUONG = c.Int(nullable: false),
                        MASP = c.String(nullable: false, maxLength: 128),
                        TENSP = c.String(nullable: false),
                        MALO = c.String(nullable: false, maxLength: 128),
                        GIANHAP = c.Int(nullable: false),
                        GIABAN = c.Int(nullable: false),
                        TIEN = c.Int(nullable: false),
                        NGAYBAN = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MADT)
                .ForeignKey("dbo.HOADONs", t => t.MAHD, cascadeDelete: true)
                .ForeignKey("dbo.SANPHAMs", t => new { t.MASP, t.MALO }, cascadeDelete: true)
                .Index(t => t.MAHD)
                .Index(t => new { t.MASP, t.MALO });
            
            CreateTable(
                "dbo.HOADONs",
                c => new
                    {
                        MAHD = c.Int(nullable: false, identity: true),
                        MANV = c.Int(nullable: false),
                        MAKH = c.Int(nullable: false),
                        NGAYBAN = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.MAHD)
                .ForeignKey("dbo.KHACHHANGs", t => t.MAKH, cascadeDelete: true)
                .ForeignKey("dbo.NVs", t => t.MANV, cascadeDelete: true)
                .Index(t => t.MANV)
                .Index(t => t.MAKH);
            
            CreateTable(
                "dbo.KHACHHANGs",
                c => new
                    {
                        MAKH = c.Int(nullable: false, identity: true),
                        TENKH = c.String(nullable: false),
                        DIACHI = c.String(),
                        SODT = c.String(nullable: false),
                        GHICHU = c.String(),
                    })
                .PrimaryKey(t => t.MAKH);
            
            CreateTable(
                "dbo.NVs",
                c => new
                    {
                        MANV = c.Int(nullable: false, identity: true),
                        HOTEN = c.String(nullable: false),
                        GIOITINH = c.String(),
                        SDT = c.String(nullable: false),
                        NGAYSINH = c.DateTime(nullable: false),
                        DIACHI = c.String(),
                        USERNAME = c.String(nullable: false),
                        PASSWORD = c.String(nullable: false),
                        TYPENV = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.MANV);
            
            CreateTable(
                "dbo.SANPHAMs",
                c => new
                    {
                        MASP = c.String(nullable: false, maxLength: 128),
                        MALO = c.String(nullable: false, maxLength: 128),
                        TENSP = c.String(nullable: false),
                        GIANHAP = c.Int(nullable: false),
                        LOINHUAN = c.Int(nullable: false),
                        BAOHANH = c.Int(nullable: false),
                        SL = c.Int(nullable: false),
                        Sale = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.MASP, t.MALO });
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.DETAILs", new[] { "MASP", "MALO" }, "dbo.SANPHAMs");
            DropForeignKey("dbo.HOADONs", "MANV", "dbo.NVs");
            DropForeignKey("dbo.HOADONs", "MAKH", "dbo.KHACHHANGs");
            DropForeignKey("dbo.DETAILs", "MAHD", "dbo.HOADONs");
            DropIndex("dbo.HOADONs", new[] { "MAKH" });
            DropIndex("dbo.HOADONs", new[] { "MANV" });
            DropIndex("dbo.DETAILs", new[] { "MASP", "MALO" });
            DropIndex("dbo.DETAILs", new[] { "MAHD" });
            DropTable("dbo.SANPHAMs");
            DropTable("dbo.NVs");
            DropTable("dbo.KHACHHANGs");
            DropTable("dbo.HOADONs");
            DropTable("dbo.DETAILs");
        }
    }
}

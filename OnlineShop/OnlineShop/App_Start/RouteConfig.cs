﻿using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            #region Employee
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "Employee_Details",
                url: "nhan-vien/thong-tin-ca-nhan",
                defaults: new { controller = "Employee", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Employee_Index",
                url: "nhan-vien/danh-sach",
                defaults: new { controller = "Employee", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Employee_Edit",
                url: "nhan-vien/chinh-sua/{Id}",
                defaults: new { controller = "Employee", action = "Edit", id = UrlParameter.Optional }
            );
            #endregion

            #region Customer
            routes.MapRoute(
                name: "Customer_Index",
                url: "khach-hang/danh-sach",
                defaults: new { controller = "Customer", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Customer_Create",
                url: "khach-hang/them-khach-hang",
                defaults: new { controller = "Customer", action = "Create", id = UrlParameter.Optional }
            );
            #endregion

            #region Product
            routes.MapRoute(
                name: "Product_Index",
                url: "san-pham/danh-sach",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Product_Create",
                url: "san-pham/them-san-pham",
                defaults: new { controller = "Product", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Product_Edit",
                url: "san-pham/chinh-sua/{Id}-{IdPackage}",
                defaults: new { controller = "Product", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Product_DElete",
                url: "san-pham/xoa/{Id}-{IdPackage}",
                defaults: new { controller = "Product", action = "Delete", id = UrlParameter.Optional }
            );
            #endregion

            #region Invoice
            routes.MapRoute(
                name: "Invoice_Index",
                url: "hoa-don/danh-sach",
                defaults: new { controller = "Invoice", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Invoice_Create",
                url: "hoa-don/tao-moi-hoa-don",
                defaults: new { controller = "Invoice", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Invoice_Add",
                url: "hoa-don/them-moi-hoa-don",
                defaults: new { controller = "Invoice", action = "Add", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Invoice_Edit",
                url: "hoa-don/chinh-sua/{id}",
                defaults: new { controller = "Invoice", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Invoice_Delete",
                url: "hoa-don/xoa/{id}",
                defaults: new { controller = "Invoice", action = "Delete", id = UrlParameter.Optional }
            );
            #endregion

            #region Detail
            routes.MapRoute(
                name: "Detail_Index",
                url: "chi-tiet/danh-sach/{id}",
                defaults: new { controller = "Detail", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Detail_Search",
                url: "chi-tiet/thong-ke",
                defaults: new { controller = "Detail", action = "Search", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Detail_SearchItem",
                url: "chi-tiet/thong-ke/san-pham",
                defaults: new { controller = "Detail", action = "SearchItem", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Detail_CREATEADD",
                url: "chi-tiet/tao-moi",
                defaults: new { controller = "Detail", action = "CREATEADD", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Detail_IndexADD/{ID}/{IdInvoice}-{flag}",
                url: "chi-tiet/tao-moi-hoa-don",
                defaults: new { controller = "Detail", action = "IndexADD", id = UrlParameter.Optional }
            );
            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

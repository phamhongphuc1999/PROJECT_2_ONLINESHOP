using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace OnlineShop
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
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
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

using System.Web.Mvc;
using System.Web.Routing;

namespace ManagementStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region Employee
            routes.MapRoute(
                name: "Employee_Details",
                url: "nhan-vien/thong-tin-ca-nhan/{id}",
                defaults: new { controller = "Employee", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Employee_Index",
                url: "nhan-vien/danh-sach-nhan-vien",
                defaults: new { controller = "Employee", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Employee_Edit",
                url: "nhan-vien/chinh-sua/{Id}",
                defaults: new { controller = "Employee", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Employee_Delete",
                url: "nhan-vien/xoa-nhan-vien/{Id}",
                defaults: new { controller = "Employee", action = "Delete", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Employee_Create",
                url: "nhan-vien/them-nhan-vien",
                defaults: new { controller = "Employee", action = "Create", id = UrlParameter.Optional }
            );
            #endregion

            #region Customer
            routes.MapRoute(
                name: "Customer_Index",
                url: "khach-hang/danh-sach-khach-hang",
                defaults: new { controller = "Customer", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Customer_Create",
                url: "khach-hang/them-khach-hang",
                defaults: new { controller = "Customer", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Customer_Edit",
                url: "khach-hang/chinh-sua/{id}",
                defaults: new { controller = "Customer", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Customer_Delete",
                url: "khach-hang/xoa-khach-hang/{id}",
                defaults: new { controller = "Customer", action = "Delete", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Customer_Detail",
                url: "khach-hang/chi-tiet/{id}",
                defaults: new { controller = "Customer", action = "Details", id = UrlParameter.Optional }
            );
            #endregion

            #region Product
            routes.MapRoute(
                name: "Product_Index",
                url: "san-pham/danh-sach-san-pham",
                defaults: new { controller = "Product", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Product_Detail",
                url: "san-pham/chi-tiet-san-pham/{Id}",
                defaults: new { controller = "Product", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Product_Create",
                url: "san-pham/them-san-pham",
                defaults: new { controller = "Product", action = "Create", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Product_Edit",
                url: "san-pham/chinh-sua/{Id}",
                defaults: new { controller = "Product", action = "Edit", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Product_Delete",
                url: "san-pham/xoa/{Id}",
                defaults: new { controller = "Product", action = "Delete", id = UrlParameter.Optional }
            );
            #endregion

            #region Invoice
            routes.MapRoute(
                name: "Invoice_Index",
                url: "hoa-don/danh-sach-hoa-don",
                defaults: new { controller = "Invoice", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Invoice_Detail",
                url: "hoa-don/chi-tiet-hoa-don/{id}",
                defaults: new { controller = "Invoice", action = "Details", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Invoice_Edit",
                url: "hoa-don/chinh-sua-hoa-don/{id}",
                defaults: new { controller = "Invoice", action = "Edit", id = UrlParameter.Optional }
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
                name: "Invoice_Delete",
                url: "hoa-don/xoa/{id}",
                defaults: new { controller = "Invoice", action = "Delete", id = UrlParameter.Optional }
            );
            #endregion

            routes.MapRoute(
                name: "Calendar_Index",
                url: "lich/",
                defaults: new { controller = "Calendar", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}

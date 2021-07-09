using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Fashion
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            //nhúng capcha vào web
            routes.IgnoreRoute("{*botdetect}",
            new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            routes.MapRoute(
                   name: "Danhmuc Sanpham",
                   url: "san-pham/{metatitle}-{dmId}",
                   defaults: new { controller = "SanPham", action = "Danhmuc", id = UrlParameter.Optional },
                   namespaces: new[] { "Fashion.Controllers" }
           );
            routes.MapRoute(
                  name: "Sanpham Detail",
                  url: "chi-tiet/{metatitle}-{spid}",
                  defaults: new { controller = "SanPham", action = "Detail", id = UrlParameter.Optional },
                  namespaces: new[] { "Fashion.Controllers" }
          );
            routes.MapRoute(
                 name: "Tags",
                 url: "tag/{tagId}",
                 defaults: new { controller = "Content", action = "Tag", id = UrlParameter.Optional },
                 namespaces: new[] { "Fashion.Controllers" }
         );
            routes.MapRoute(
                 name: "Content Detail",
                 url: "tin-tuc/{metatitle}-{id}",
                 defaults: new { controller = "Content", action = "Detail", id = UrlParameter.Optional },
                 namespaces: new[] { "Fashion.Controllers" }
         );
            routes.MapRoute(
                 name: "Gioi Thieu",
                 url: "gioi-thieu",
                 defaults: new { controller = "GioiThieu", action = "Index", id = UrlParameter.Optional },
                 namespaces: new[] { "Fashion.Controllers" }
         );
            routes.MapRoute(
                  name: "Lien He",
                  url: "lien-he",
                  defaults: new { controller = "Lienhe", action = "Index", id = UrlParameter.Optional },
                  namespaces: new[] { "Fashions.Controllers" }
      );

            routes.MapRoute(
                name: "News",
                url: "tin-tuc",
                defaults: new { controller = "Content", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
       );
            routes.MapRoute(
              name: "Gio Hang",
              url: "gio-hang",
              defaults: new { controller = "Giohang", action = "Index", id = UrlParameter.Optional },
              namespaces: new[] { "Fashion.Controllers" }
          );
            routes.MapRoute(
               name: "Login",
               url: "dang-nhap",
               defaults: new { controller = "User", action = "DangNhap", id = UrlParameter.Optional },
               namespaces: new[] { "Fashion.Controllers" }
       );
            routes.MapRoute(
                name: "Search",
                url: "tim-kiem",
                defaults: new { controller = "Product", action = "Search", id = UrlParameter.Optional },
                namespaces: new[] { "Fashion.Controllers" }
        );
            routes.MapRoute(
                name: "DangKy",
                url: "dang-ky",
                defaults: new { controller = "User", action = "DangKy", id = UrlParameter.Optional },
                namespaces: new[] { "Fashion.Controllers" }
        );
            routes.MapRoute(
                name: "Thanhtoan",
                url: "thanh-toan",
                defaults: new { controller = "Giohang", action = "Thanhtoan", id = UrlParameter.Optional },
                namespaces: new[] { "Fashion.Controllers" }
        );
            routes.MapRoute(
                name: "Them Gio Hang",
                url: "them-gio-hang",
                defaults: new { controller = "Giohang", action = "ThemItem", id = UrlParameter.Optional },
                namespaces: new[] { "Fashion.Controllers" }
           );
            routes.MapRoute(
                name: "HoanthanhThanhtoan",
                url: "thanh-cong",
                defaults: new { controller = "Giohang", action = "Thanhcong", id = UrlParameter.Optional },
                namespaces: new[] { "Fashion.Controllers" }
        );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "Fashion.Controllers" }
            );
        }
    }
}

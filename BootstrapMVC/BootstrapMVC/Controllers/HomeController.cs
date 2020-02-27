using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Default()
        {
            var list = GetMenus();
            Menu firstView = list.Find(f => f.Id == 4);
            Menu menuFrist = list.Find(f => f.Id == firstView.MenuId);
            ViewData["letTitle"] = menuFrist.Title;


            ViewData["menus"] = "";
            var listMenus = list.FindAll(f => f.MenuId == 0).ToList();

            string strMe = "<li class=\"menu\"> <a href = \"#menu{0}\"  data-toggle=\"collapse\"   aria-expanded=\"{1}\" class=\"dropdown-toggle\"><div class=\"\"><svg xmlns = \"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"feather feather-cpu\"><rect x = \"4\" y=\"4\" width=\"16\" height=\"16\" rx=\"2\" ry=\"2\"></rect><rect x = \"9\" y=\"9\" width=\"6\" height=\"6\"></rect><line x1 = \"9\" y1=\"1\" x2=\"9\" y2=\"4\"></line><line x1 = \"15\" y1=\"1\" x2=\"15\" y2=\"4\"></line><line x1 = \"9\" y1=\"20\" x2=\"9\" y2=\"23\"></line><line x1 = \"15\" y1=\"20\" x2=\"15\" y2=\"23\"></line><line x1 = \"20\" y1=\"9\" x2=\"23\" y2=\"9\"></line><line x1 = \"20\" y1=\"14\" x2=\"23\" y2=\"14\"></line><line x1 = \"1\" y1=\"9\" x2=\"4\" y2=\"9\"></line><line x1 = \"1\" y1=\"14\" x2=\"4\" y2=\"14\"></line></svg><span>{2}</span></div><div><svg xmlns = \"http://www.w3.org/2000/svg\" width=\"24\" height=\"24\" viewBox=\"0 0 24 24\" fill=\"none\" stroke=\"currentColor\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" class=\"feather feather-chevron-right\"><polyline points = \"9 18 15 12 9 6\"></polyline></svg></div></a>{3}</li>";
            string strMen= "<ul class=\"collapse submenu list-unstyled {0}\" id=\"menu{1}\" data-parent=\"#accordionExample\">{2}</ul>";
            string strMenu = "<li {0}><a class=\"menu_a\" href=\"javascript:;\" name=\"{1}\" menu=\"{2}\" title=\"{3}\"'> {3} </a ></li>";
            listMenus.ForEach(x =>
            {
                var listMe = list.FindAll(f => f.MenuId == x.Id).OrderBy(o=>o.MenuOrderBy).ToList();
                bool isShow = listMe.Any(a => a.Id == firstView.Id);
                string strMenus = "";
                string strMens = "";
                listMe.ForEach(item =>
                {
                    strMenus += string.Format(strMenu, item.Id== firstView.Id ? "class=\"active\"" : "", item.URL,x.Title, item.Title);
                });
                strMens += string.Format(strMen, isShow ? "show" : "",x.Id, strMenus);
                ViewData["menus"] += string.Format(strMe, x.Id, isShow ? "true" : "", x.Title, strMens);
            });

            return View(firstView);
        }

        public ActionResult FristView()
        {
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public List<Menu> GetMenus()
        {
            List<Menu> list = new List<Menu>();
            list.Add(new Menu() { Id = 1, URL = "", Title = "我是菜单一", MenuId = 0, MenuOrderBy = 1 });
            list.Add(new Menu() { Id = 2, URL = "", Title = "我是菜单二", MenuId = 0, MenuOrderBy = 2 });
            list.Add(new Menu() { Id = 3, URL = "", Title = "我是菜单三", MenuId = 0, MenuOrderBy = 3 });

            list.Add(new Menu() { Id = 4, URL = "/Home/FristView", Title = "我是首页标题", MenuId = 1, MenuOrderBy = 1 });
            list.Add(new Menu() { Id = 5, URL = "/Home/FristView", Title = "我也是首页标题", MenuId = 1, MenuOrderBy = 1 });
            list.Add(new Menu() { Id = 6, URL = "/Home/FristView", Title = "我也也是首页标题", MenuId = 1, MenuOrderBy = 2 });
            list.Add(new Menu() { Id = 7, URL = "/Home/FristView", Title = "我也也也是首页标题", MenuId = 1, MenuOrderBy = 3 });


            list.Add(new Menu() { Id = 8, URL = "/Home/Contact", Title = "我是Contact1", MenuId = 2, MenuOrderBy = 1 });
            list.Add(new Menu() { Id = 9, URL = "/Home/Contact", Title = "我是Contact2", MenuId = 2, MenuOrderBy = 2 });


            list.Add(new Menu() { Id = 10, URL = "/Home/About", Title = "我是关于", MenuId = 3, MenuOrderBy = 1 });

            return list;
        }

        #region Model
        public class Menu
        {
            public int Id { get; set; }
            public string URL { get; set; }
            public string Title { get; set; }
            public int MenuId { get; set; }
            public int MenuOrderBy { get; set; }

        }
        #endregion
    }
}
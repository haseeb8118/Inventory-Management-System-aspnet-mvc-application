using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using InventoryManagementSystem.Models;

namespace InventoryManagementSystem.Controllers
{
    public class AuthController : Controller
    {
        // GET: Auth
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(user u)
        {
            inventoryDBEntities2 obj = new inventoryDBEntities2();
            var data = obj.st_getLoginDetails(u.u_username, u.u_password);
            foreach (var item in data)
            {
                if(item.Username == u.u_username && item.Password == u.u_password)
                {
                    Session["name"] = u.u_username;
                    return RedirectToAction("Main");
                }
                else
                {

                }
            }
            return View();
        }

        public ActionResult Main()
        {
            if(Session["name"] == null)
            {
                return RedirectToAction("Index", "Auth");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            Session.Remove("name");
            return View("Index");
        }
    }
}
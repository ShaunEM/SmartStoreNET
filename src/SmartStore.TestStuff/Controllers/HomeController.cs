using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartStore.TestStuff.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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

        public ActionResult MySQLTest()
        {

            string connstr = ConfigurationManager.ConnectionStrings["MySQLConn"].ConnectionString;
            using (var conn = new MySqlConnection(connstr))
            {
                var rows = conn.Query<dynamic>("show tables", new { }).ToList();
                foreach(var row in rows)
                {
                    ViewBag.Message += row.Tables_in_mysqlsmartstore.ToString();
                }
            }


            return View("About");
        }
    }
}
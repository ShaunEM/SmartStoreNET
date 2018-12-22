using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartStore.Web.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            ViewBag.Message = "This is a test page";
            return View();
        }









        public ActionResult MySQLTest()
        {
            string connstr = ConfigurationManager.ConnectionStrings["mysqlserver"]?.ConnectionString ?? "";
            using (var conn = new MySqlConnection(connstr))
            {
                var rows = conn.Query<dynamic>("show tables", new { }).ToList();
                foreach (var row in rows)
                {
                    ViewBag.Message += row.Tables_in_mysqlsmartstore.ToString();
                }
            }
            return View("Index");
        }


    }
}
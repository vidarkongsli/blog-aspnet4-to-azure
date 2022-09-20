using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web.Mvc;

namespace Kongsli.LegacyNetFramework.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            var settings = ConfigurationManager.AppSettings.AllKeys.ToDictionary(key => key, key => ConfigurationManager.AppSettings[key]);

            var connectionStrings = new Dictionary<string, string>();
            for (var i = 0; i < ConfigurationManager.ConnectionStrings.Count; i++)
            {
                var connectionString = ConfigurationManager.ConnectionStrings[i];
                connectionStrings.Add(connectionString.Name, connectionString.ConnectionString);
            }

            return View(new HomeModel(settings, connectionStrings));
        }
    }

    public class HomeModel
    {
        public HomeModel(IDictionary<string, string> appSettings, IDictionary<string, string> connectionStrings)
        {
            AppSettings = appSettings;
            ConnectionStrings = connectionStrings;
        }

        public IDictionary<string, string> AppSettings { get; }
        public IDictionary<string, string> ConnectionStrings { get; }
    }
}

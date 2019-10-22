using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MCashDemo.Web.Models;
using Microsoft.Extensions.Options;
using MCash.Business.Domain;
using MCash.Business.Service;

namespace MCashDemo.Web.Controllers
{
    public class HomeController : Controller
    {
        IOptions<ConnectionStrings> _connectionString;
        UserProfile _userProfile;
        public HomeController(IOptions<ConnectionStrings> connectionString, IOptions<UserProfile> userProfile)
        {
            _connectionString = connectionString;
            _userProfile = userProfile.Value;
        }
        public IActionResult Index()
        {
            var transactionService = new TransactionService();
            var data = transactionService.GetAll(_connectionString.Value.MCashDemoConnectionString);
            ViewBag.UserProfile = _userProfile;
            ViewBag.Title = _userProfile.WebSiteName;
            return View(data);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

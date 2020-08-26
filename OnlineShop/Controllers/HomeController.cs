using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace OnlineShop.UI.Controllers
{
    public class HomeController : Controller
    {
#pragma warning disable CS0618 // Type or member is obsolete
        public HomeController(IHostingEnvironment hostingEnvironment)
#pragma warning restore CS0618 // Type or member is obsolete
        {
            HostingEnvironment = hostingEnvironment;
        }

#pragma warning disable CS0618 // Type or member is obsolete
        public IHostingEnvironment HostingEnvironment { get; }
#pragma warning restore CS0618 // Type or member is obsolete

        public IActionResult Index()
        {
            return Json(HostingEnvironment.WebRootPath);
        }
    }
}

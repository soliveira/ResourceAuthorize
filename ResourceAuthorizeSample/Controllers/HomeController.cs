using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ResourceAuthorizeSample.Controllers
{
    using ResourceAuthorizeSample.Authorization;

    using Thinktecture.IdentityModel.Mvc;

    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [ResourceAuthorize(AppResources.BankAccountActions.Read, AppResources.BankAccount)]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [ResourceAuthorize(AppResources.BankAccountActions.Transfer, AppResources.BankAccount)]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
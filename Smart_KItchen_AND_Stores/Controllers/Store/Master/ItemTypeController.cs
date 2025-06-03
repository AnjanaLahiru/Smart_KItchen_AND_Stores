using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Smart_KItchen_AND_Stores.Controllers.Store.Master
{
    public class ItemTypeController : Controller
    {
        // GET: ItemType
        public ActionResult ItemType()
        {
            string currentUser = User.Identity.Name;
            ViewBag.CurrentUser = currentUser;
            ViewBag.UserDisplayName = GetUserDisplayName(currentUser);
            return View();
        }

        private string GetUserDisplayName(string username)
        {
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                return "E0003(IT - Kitchen Stores)";
            }
            return $"{username}(Kitchen Stores)";
        }
    }
}
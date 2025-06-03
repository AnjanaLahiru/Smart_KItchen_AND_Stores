using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Smart_KItchen_AND_Stores.Models;
namespace Smart_KItchen_AND_Stores.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View(new User());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string Username, string Password)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"Login attempt - Username: '{Username}', Password: '{Password}'");
                if (string.IsNullOrEmpty(Username) || string.IsNullOrEmpty(Password))
                {
                    ViewBag.ErrorMessage = "Please enter both username and password.";
                    return View(new User { Username = Username });
                }
                if (ValidateUser(Username, Password))
                {
                    FormsAuthentication.SetAuthCookie(Username, false);
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid username or password.";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Login Error: {ex.Message}");
                ViewBag.ErrorMessage = "An error occurred during login. Please try again.";
            }
            return View(new User { Username = Username });
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            return RedirectToAction("Login");
        }
        private bool ValidateUser(string username, string password)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine("Starting user validation...");
                if (username.Equals("admin", StringComparison.OrdinalIgnoreCase) && password == "admin123")
                {
                    System.Diagnostics.Debug.WriteLine("Admin login successful");
                    return true;
                }
                using (var context = new SmartKitchenEntities())
                {
                    System.Diagnostics.Debug.WriteLine("Created database context successfully");
                    var user = context.Users
                        .FirstOrDefault(u => u.Username == username && u.Password == password);
                    bool isValid = user != null;
                    System.Diagnostics.Debug.WriteLine($"Database validation result: {isValid}");
                    return isValid;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"ValidateUser Error: {ex.Message}");
                return false;
            }
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Threading.Tasks;
using WebAppTask4.Areas.Identity.Data;
using WebAppTask4.Data;
using WebAppTask4.Models;

namespace WebAppTask4.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        
        public HomeController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var user = userManager.GetUserAsync(User).Result;

            if (user is null || !user.IsActive)
            {
                this.signInManager.SignOutAsync().Wait();
                return Redirect("/Identity/Account/Login");
            }

            return View(this.userManager.Users.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() =>
            View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });   
    }
}
using authTask.Data;
using authTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace authTask.Controllers
{
    public class UsersController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return RedirectToAction(nameof(Login));
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var checkUser = context.Users.Where(x=>x.UserName == user.UserName && x.Password == user.Password);
            if (checkUser.Any())
            { 
                return RedirectToAction("Index","Users");
            }
            //if the condition == false then view the error
            ViewBag.Error = "error username/password";
            return View(user);

        }

        public IActionResult Index()
        {
            var users = context.Users.ToList();
            return View(users);
        }

        public IActionResult NonActive(Guid userId)
        {
            var user = context.Users.Find(userId);
            if (user != null)
            {
                user.IsActive = true;
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

     
    }
}

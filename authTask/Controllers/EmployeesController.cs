using authTask.Data;
using authTask.Models;
using Microsoft.AspNetCore.Mvc;

namespace authTask.Controllers
{
    public class EmployeesController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            var emolyees = context.Employees.ToList();
            return View(emolyees);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            context.Employees.Add(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var emp = context.Employees.Find(id);
            return View(emp);
        }

        public IActionResult Update(Employee emp)
        {
            var employee = context.Employees.Find(emp.Id);
            employee.Name = emp.Name;
            employee.Email = emp.Email;
            employee.Password = emp.Password;
            context.SaveChanges();
            return RedirectToAction("Index");

        }

        public IActionResult Delete(int id) 
        {
            var emp = context.Employees.Find(id);
            context.Employees.Remove(emp);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            DanishContext db = new DanishContext();
            ViewBag.danish = "danish";
            return View(db.Students.ToList());
        }

        [HttpGet]
        public IActionResult addstudentform()
        {
            return View();
        }

        [HttpPost]
        public IActionResult addstudentform(Student temp)
        {
            DanishContext db = new DanishContext();
            if (ModelState.IsValid)
            {
                db.Students.Add(temp);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            ViewBag.danish = "danish";
            return View("Index", db.Students.ToList());

        }

        [HttpPost]
        public IActionResult editstudent(Student s)
        {

            DanishContext db = new DanishContext();


            Student? obj = db.Students.Find(s.Id);

            obj.Name = s.Name;
            obj.Age = s.Age;
            obj.Password = s.Password;
            obj.Phone = s.Phone;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult editstudentform(int id)
        {
            DanishContext db = new DanishContext();
            Student mystudent = db.Students.Where(st => st.Id == id).First();

            return View(mystudent);
        }

        public IActionResult deletestudent(int id)
        {

            DanishContext db = new DanishContext();
            Student mystudent = db.Students.Where(st => st.Id == id).First();
            db.Students.Remove(mystudent);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}

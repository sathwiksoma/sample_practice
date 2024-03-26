using Consuming_API_in_MVC_demo.Models;
using Consuming_API_in_MVC_demo.Services;
using Microsoft.AspNetCore.Mvc;

namespace Consuming_API_in_MVC_demo.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentService _service;
        public StudentsController(IStudentService service)
        {
            _service = service;
        }
        // GET: StudentsController
        public async Task<IActionResult> Index()
        {
            List<Student> students = await _service.AllStudents();
            return View(students);
        }

        // GET: StudentsController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            Student student = await _service.GetStudent(id);
            return View(student);
        }

        // GET: StudentsController/Create
        public async Task<ActionResult> Create(Student student)
        {

            return View();
        }

        // POST: StudentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(IFormCollection collection, Student student)
        {
            try
            {
                Student student1 = await _service.AddNewStudent(student);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: StudentsController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            Student student = await _service.GetStudent(id);
            return View(student);
            //return View();
        }

        // POST: StudentsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, IFormCollection collection, Student student)
        {
            try
            {
                Student stu = await _service.UpdateStudent(student);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentsController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            Student student = await _service.GetStudent(id);
            return View(student);
        }

        // POST: StudentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                string response = await _service.DeleteStudent(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

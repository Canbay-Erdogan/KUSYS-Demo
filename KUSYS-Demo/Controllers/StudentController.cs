using KusysDemo.Business.FValidator;
using KusysDemo.DAL;
using KusysDemo.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace KUSYS_Demo.Controllers
{
    public class StudentController : Controller
    {
        private KusysContext _context;

        public StudentController(KusysContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var Students = _context.Students.ToListAsync();
            return View(await Students);
        }

        public async Task<IActionResult> GetById(Guid id)
        {
            if (id == null)
            {
                return Json(new { failed = true, message = "Aranan kriterlerde kayıt bulunamadı" });
            }

            var student = await _context.Students.Include(s => s.Courses)
                .FirstOrDefaultAsync(m => m.StudentId == id);
            if (student == null)
            {
                return Json(new { failed = true, message = "Öğrenci bulunamadı" });
            }
            return View(student);
        }

        public async Task<IActionResult> Create(Student student)
        {
            StudentValidator studentValidator = new StudentValidator();
            bool valide = studentValidator.Validate(student).IsValid;
            if (valide)
            {
                student.StudentId = new Guid();
                _context.Students.Add(student);
                _context.SaveChanges();
                return Json(student);
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            if (id != null)
            {
                Student student = _context.Students.Find(id);
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            if (id != null)
            {
                Student student = _context.Students.Find(id);
                return View(student);
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            if (student != null)
            {
                var findStudent = _context.Students.Find(student.StudentId);
                findStudent.FirstName=student.FirstName;
                findStudent.LastName=student.LastName;
                findStudent.BirthDate=student.BirthDate;
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}

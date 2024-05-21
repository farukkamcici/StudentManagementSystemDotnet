using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagementSystem.Data;
using StudentManagementSystem.Models;

namespace StudentManagementSystem.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext _context;
        public StudentController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var students = _context.Students.Include(s => s.Class).ToList();
            return View(students);
        }

        public IActionResult Create()
        {
            ViewBag.Classes = _context.Classes.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Create(StudentDto studentDto)
        {
            if (ModelState.IsValid)
            { 
                var checkStudent = _context.Students.Find(studentDto.Id);

                if (checkStudent == null)
                {
                    Student student = new Student()
                    {
                        Name = studentDto.Name,
                        Id = studentDto.Id,
                        ClassId = studentDto.ClassId
                    };

                    _context.Students.Add(student);
                    _context.SaveChanges();

                    return RedirectToAction("Index");
                }
                else
                {
                    ViewData["IdExists"] = "This ID already exists!";
                }
            }

            ViewBag.Classes = _context.Classes.ToList();
            return View(studentDto);
        }

        public IActionResult Edit(int id)
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return RedirectToAction("Index", "Student");
            }

            var studentDto = new StudentDto()
            {
                Name = student.Name,
                Id = student.Id,
                ClassId = student.ClassId
            };

            ViewBag.Classes = _context.Classes.ToList();
            return View(studentDto);
        }

        [HttpPost]
        public IActionResult Edit(int id, StudentDto studentDto) 
        {
            var student = _context.Students.Find(id);

            if (student == null)
            {
                return RedirectToAction("Index", "Student");
            }

            if(!ModelState.IsValid)
            {
                return View(studentDto);
            }

            student.Name = studentDto.Name;
            student.ClassId = studentDto.ClassId;

            _context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

        public IActionResult Delete(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
            {
                return RedirectToAction("Index", "Student");
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return RedirectToAction("Index", "Student");
        }

    }
}

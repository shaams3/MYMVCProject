using Microsoft.AspNetCore.Mvc;
using MyMvcProject.Interfaces;
using MyMvcProject.Models;

namespace MyMvcProject.Controllers;

public class StudentController : Controller
{
    private readonly IStudentService _studentService;

    public StudentController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    // 1) List all students
    public IActionResult Index()
    {
        var students = _studentService.GetAll();
        return View(students);
    }

    // 2) Show details for a single student
    public IActionResult Details(int id)
    {
        var student = _studentService.GetById(id);
        if (student is null)
        {
            return NotFound();
        }

        return View(student);
    }

    // 3) Create new student (GET + POST)
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Student());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Student student)
    {
        if (!ModelState.IsValid)
        {
            return View(student);
        }

        _studentService.Add(student);
        return RedirectToAction(nameof(Index));
    }
}

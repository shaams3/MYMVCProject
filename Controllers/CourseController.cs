using Microsoft.AspNetCore.Mvc;
using MyMvcProject.Interfaces;
using MyMvcProject.Models;

namespace MyMvcProject.Controllers;

public class CourseController : Controller
{
    private readonly ICourseService _courseService;

    public CourseController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    // 1) List all courses
    public IActionResult Index()
    {
        var courses = _courseService.GetAll();
        return View(courses);
    }

    // 2) Show details for a single course
    public IActionResult Details(int id)
    {
        var course = _courseService.GetById(id);
        if (course is null)
        {
            return NotFound();
        }

        return View(course);
    }

    // 3) Create new course (GET + POST)
    [HttpGet]
    public IActionResult Create()
    {
        return View(new Course());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Course course)
    {
        if (!ModelState.IsValid)
        {
            return View(course);
        }

        _courseService.Add(course);
        return RedirectToAction(nameof(Index));
    }
}

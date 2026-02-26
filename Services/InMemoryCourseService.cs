using MyMvcProject.Interfaces;
using MyMvcProject.Models;

namespace MyMvcProject.Services;

public class InMemoryCourseService : ICourseService
{
    private readonly List<Course> _courses = new()
    {
        new Course { Id = 1, Title = "Math 101", Credits = 3 },
        new Course { Id = 2, Title = "Programming Basics", Credits = 4 }
    };

    public IEnumerable<Course> GetAll() => _courses;

    public Course? GetById(int id) => _courses.FirstOrDefault(c => c.Id == id);

    public void Add(Course course)
    {
        course.Id = _courses.Count == 0 ? 1 : _courses.Max(c => c.Id) + 1;
        _courses.Add(course);
    }
}

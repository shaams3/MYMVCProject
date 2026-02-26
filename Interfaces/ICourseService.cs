using MyMvcProject.Models;

namespace MyMvcProject.Interfaces;

public interface ICourseService
{
    IEnumerable<Course> GetAll();
    Course? GetById(int id);
    void Add(Course course);
}

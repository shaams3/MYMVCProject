using MyMvcProject.Interfaces;
using MyMvcProject.Models;

namespace MyMvcProject.Services;

public class InMemoryStudentService : IStudentService
{
    private readonly List<Student> _students = new()
    {
        new Student { Id = 1, Name = "Alice", Age = 20 },
        new Student { Id = 2, Name = "Bob", Age = 22 }
    };

    public IEnumerable<Student> GetAll() => _students;

    public Student? GetById(int id) => _students.FirstOrDefault(s => s.Id == id);

    public void Add(Student student)
    {
        student.Id = _students.Count == 0 ? 1 : _students.Max(s => s.Id) + 1;
        _students.Add(student);
    }
}

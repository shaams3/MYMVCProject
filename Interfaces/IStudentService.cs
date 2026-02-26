using MyMvcProject.Models;

namespace MyMvcProject.Interfaces;

public interface IStudentService
{
    IEnumerable<Student> GetAll();
    Student? GetById(int id);
    void Add(Student student);
}

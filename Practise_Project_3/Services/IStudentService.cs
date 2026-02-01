using Practise_Project_3.Models;

namespace Practise_Project_3.Services
{
    public interface IStudentService
    {
        List<Student> GetAllStudents();
        Student? GetStudentById(int id);
        Student AddStudent(Student student);
        bool UpdateStudent(int id, Student student);
        bool DeleteStudent(int id);
    }
}

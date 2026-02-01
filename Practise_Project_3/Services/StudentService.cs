using Practise_Project_3.Models;

namespace Practise_Project_3.Services
{
    public class StudentService : IStudentService
    {
        private static List<Student> students = new List<Student> {

            new Student
            {
                Id = 1,
                Name = "Tapan",
                Email ="tapan.ray@gmail.com",
                IsPresent = true,
            },
             new Student
            {
                Id = 2,
                Name = "Sakshi",
                Email ="sakshi.ray@gmail.com",
                IsPresent = false,
            },
        };

        public List<Student> GetAllStudents()
        {
            return students;
        }

        public Student GetStudentById(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            return student;
        }

        public Student AddStudent(Student student)
        {
            student.Id = students.Max(x => x.Id) + 1;
            students.Add(student);
            return student;
        }

        public bool UpdateStudent(int id, Student student)
        {
            var stud = GetStudentById(id);
            if (stud is null)
                return false;
            stud.Name = student.Name;
            stud.Email = student.Email;
            stud.IsPresent = student.IsPresent;

            return true;
        }

        public bool DeleteStudent(int id)
        {
            var stud = GetStudentById(id);
            if(stud is null)
                return false;
            students.Remove(stud);
            return true;
        }

       
    }
}

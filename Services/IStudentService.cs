using Consuming_API_in_MVC_demo.Models;

namespace Consuming_API_in_MVC_demo.Services
{
    public interface IStudentService
    {
        public Task<List<Student>> AllStudents();
        public Task<Student> GetStudent(int id);
        public Task<Student> AddNewStudent(Student student);
        public Task<Student> UpdateStudent(Student student);
        public Task<string> DeleteStudent(int id);
    }
}

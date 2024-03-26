using Consuming_API_in_MVC_demo.Models;
using Newtonsoft.Json;
using System.Text;

namespace Consuming_API_in_MVC_demo.Services
{
    public class StudentService : IStudentService
    {
        public Student ADdNewStudent(Student student)
        {
            throw new NotImplementedException();
        }

        public async Task<Student> AddNewStudent(Student student)
        {
            Student receivedStudent = new Student();
            using (var httpClient = new HttpClient())
            {
                //StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                //var content = JsonConvert.SerializeObject(student);
                //var buffer = System.Text.Encoding.UTF8.GetBytes(content);
                //var byteContent = new ByteArrayContent(buffer);
                using (var response = await httpClient.PostAsJsonAsync("https://localhost:7075/api/Students", student))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    receivedStudent = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return receivedStudent;
        }

        public async Task<List<Student>> AllStudents()
        {
            List<Student> Studentlist = new List<Student>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7075/api/Students"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Studentlist = JsonConvert.DeserializeObject<List<Student>>(apiResponse);
                }
            }
            return Studentlist;
        }


        public async Task<string> DeleteStudent(int id)
        {
            string responseResult = null;
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7075/api/Students"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    responseResult = apiResponse;
                }
            }
            return responseResult;
        }

        public async Task<Student> GetStudent(int id)
        {
            Student student = new Student();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:7075/api/Students/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return student;
        }

        public async Task<Student> UpdateStudent(Student student)
        {
            Student student1 = new Student();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(student), Encoding.UTF8, "application/json");
                using (var response = await httpClient.
                    PutAsync("https://localhost:7075/api/Students", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    student1 = JsonConvert.DeserializeObject<Student>(apiResponse);
                }
            }
            return student;
        }
    }
}

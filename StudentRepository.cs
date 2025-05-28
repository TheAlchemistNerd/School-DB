
using System.Text.Json;


namespace StudentRepository
{
    public class StudentRepository
    {
        private readonly string filePath;

        public StudentRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public void Save(Student student)
        {
            List<Student> students = GetAllStudents();
            students.Add(student);
            SaveStudents(students);
        }

        public List<Student> GetAllStudents()
        {
            if (!File.Exists(filePath))
                return new List<Student>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
        }

        public void SaveStudents(List<Student> students)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(students, options);
            File.WriteAllText(filePath, json);
        }

    }
}
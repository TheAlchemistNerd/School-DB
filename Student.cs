using System.Text.Json.Serialization;

namespace StudentRepository
{
    public class Student
    {
        [JsonPropertyName("Id")]
        public int Id { get; set; }

        [JsonPropertyName("Name")]
        public string Name { get; set; }

        [JsonPropertyName("Age")]
        public int Age { get; set; }

        // Parametrized constructor
        public Student (int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public Student()
        {

        }
    }
}
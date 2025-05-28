namespace StudentRepository
{
    class Program
    {
        static void Main(String[] args)
        {
            // Define file path
            string filePath = "students.json";


            //Create repository
            // StudentRepository repository = new StudentRepository(filePath);
            // Create a generic JSON file repository for Student
            IRepository<Student> repository = new JsonFileRepository<Student>(filePath);

            // Create and save multiple students
            List<Student> newStudents = new List<Student>
        {
            new Student(1,"Alice", 21),
            new Student(2,"Bob", 22),
            new Student(3,"Charlie", 20),
            new Student(4,"Diana", 23),
            new Student(5,"Ethan", 24),
        };

            foreach (var student in newStudents)
            {
                repository.Save(student);
                Console.WriteLine($"Student {student.Name} saved.");
            }

            // Read and display all students
            List<Student> students = repository.GetAll();
            Console.WriteLine("\nAll Students:");
            foreach (var s in students)
            {
                Console.WriteLine($"ID: {s.Id}, Name: {s.Name}, Age: {s.Age}");
            }
            
            Console.ReadKey();
        }
    }
}
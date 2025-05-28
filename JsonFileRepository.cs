
using System.Text.Json;

namespace StudentRepository
{
    public class JsonFileRepository <T>: IRepository<T>
    {
        private readonly string filePath;

        public JsonFileRepository(string filePath)
        {
            this.filePath = filePath;
        }

        public void Save(T entity)
        {
            List<T> entities = GetAll();
            entities.Add(entity);
            SaveAll(entities);
        }

        public List<T> GetAll()
        {
            if (!File.Exists(filePath))
                return new List<T>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json) ?? new List<T>();
        }

        public void SaveAll(List<T> entities)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(entities, options);
            File.WriteAllText(filePath, json);
        }

    }
}
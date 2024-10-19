using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UpliftLink.Models;

namespace UpliftLink.Services
{
    public class JsonService
    {
        private readonly string _filePath;

        public JsonService(string filePath)
        {
            _filePath = filePath;
        }

        public async Task SaveToJsonFileAsync(List<User> users)
        {
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<List<User>> LoadFromJsonFileAsync()
        {
            if (!File.Exists(_filePath))
                return new List<User>();

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
    }
}

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

        /// <summary>
        /// Initializes a new instance of the <see cref="JsonService"/> class.
        /// </summary>
        /// <param name="filePath">The file path where the JSON data will be stored.</param>
        public JsonService(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Saves a list of users to a JSON file asynchronously.
        /// </summary>
        /// <param name="users">The list of users to save.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task SaveUsersToJsonFileAsync(List<User> users)
        {
            var json = JsonConvert.SerializeObject(users, Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task SaveUserPreferencesAsync(UserPreferences userPreferences)
        {
            var json = JsonConvert.SerializeObject(userPreferences, Formatting.Indented);
            await File.WriteAllTextAsync(_filePath, json);
        }

        /// <summary>
        /// Loads a list of users from a JSON file asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the list of users.</returns>
        public async Task<List<User>> LoadFromJsonFileAsync()
        {
            if (!File.Exists(_filePath))
                return new List<User>();

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }

        public async Task<UserPreferences> LoadUserPreferencesAsync()
        {
            if (!File.Exists(_filePath))
                return new UserPreferences();

            var json = await File.ReadAllTextAsync(_filePath);

            return JsonConvert.DeserializeObject<UserPreferences>(json);

        }
    }
}

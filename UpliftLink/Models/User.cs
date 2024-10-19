using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using UpliftLink.Models;

namespace UpliftLink.Services
{
    /// <summary>
    /// Service for managing user preferences.
    /// </summary>
    public class UserPreferenceService
    {
        private readonly string _filePath;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserPreferenceService"/> class.
        /// </summary>
        /// <param name="filePath">The file path where the user preferences will be stored.</param>
        public UserPreferenceService(string filePath)
        {
            _filePath = filePath;
        }

        /// <summary>
        /// Saves user preferences to a JSON file asynchronously.
        /// </summary>
        /// <param name="preferences">The user preferences to save.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task SavePreferencesAsync(UserPreferences preferences)
        {
            var json = JsonSerializer.Serialize(preferences, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }

        /// <summary>
        /// Loads user preferences from a JSON file asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the user preferences.</returns>
        public async Task<UserPreferences> LoadPreferencesAsync()
        {
            if (!File.Exists(_filePath))
                return new UserPreferences();

            var json = await File.ReadAllTextAsync(_filePath);
            return JsonSerializer.Deserialize<UserPreferences>(json);
        }
    }
}

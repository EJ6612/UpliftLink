using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using UpliftLink.UserPref;

namespace UpliftLink.Services
{
    /// <summary>
    /// Service for managing user preferences.
    /// </summary>
    public class UserPreferencesService
    {
        private readonly string _filePath;
        private UserPreferences _userPreferences;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserPreferencesService"/> class.
        /// </summary>
        public UserPreferencesService()
        {
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "user_settings.json");
            _userPreferences = new UserPreferences();
        }

        /// <summary>
        /// Saves user preferences to a JSON file asynchronously.
        /// </summary>
        /// <param name="preferences">The user preferences to save.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task SavePreferencesAsync(UserPreferences preferences)
        {
            _userPreferences = preferences;
            var json = JsonSerializer.Serialize(_userPreferences, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }

        /// <summary>
        /// Loads user preferences from a JSON file asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains the user preferences.</returns>
        public async Task<UserPreferences> LoadPreferencesAsync()
        {
            if (File.Exists(_filePath))
            {
                var json = await File.ReadAllTextAsync(_filePath);
                _userPreferences = JsonSerializer.Deserialize<UserPreferences>(json);

            }
            return _userPreferences;
        }

        /// <summary>
        /// Applies the user preferences, such as enabling or disabling Bluetooth connectivity.
        /// </summary>
        public void ApplyPreferences()
        {
            if (_userPreferences.IsVisible)
            {
                // Enable Bluetooth connectivity
                EnableBluetooth();
            }
            else
            {
                // Disable Bluetooth connectivity
                DisableBluetooth();
            }
        }

        /// <summary>
        /// Enables Bluetooth connectivity.
        /// </summary>
        private void EnableBluetooth()
        {
            // Implement Bluetooth enabling logic here
        }

        /// <summary>
        /// Disables Bluetooth connectivity.
        /// </summary>
        private void DisableBluetooth()
        {
            // Implement Bluetooth disabling logic here
        }
    }
}

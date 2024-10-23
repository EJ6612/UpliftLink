using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using UpliftLink.Models;

namespace UpliftLink.Services
{
    /// <summary>
    /// Service for managing user preferences.
    /// </summary>
    public class UserPreferencesService
    {
        private readonly string _filePath;
        private UserPreferences _userPreferences;
        private readonly ProximityService _proximityService;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserPreferencesService"/> class.
        /// </summary>
        public UserPreferencesService()
        {
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "user_preferences.json");
            _userPreferences = new UserPreferences();
            _proximityService = new ProximityService();
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

                // TODO error check
                _userPreferences = JsonSerializer.Deserialize<UserPreferences>(json);
            }

            // TODO error check
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
            _proximityService.StartProximityDetection();
        }

        /// <summary>
        /// Disables Bluetooth connectivity.
        /// </summary>
        private void DisableBluetooth()
        {
            _proximityService.StopProximityDetection();
        }
    }
}
    /// <summary>
    /// Service for managing proximity detection of nearby devices.
    /// </summary>
    
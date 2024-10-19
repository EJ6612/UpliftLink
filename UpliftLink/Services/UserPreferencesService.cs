using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using UpliftLink.UserPref;

namespace UpliftLink.Services
{
    public class UserPreferencesService
    {
        private readonly string _filePath;
        private UserPreferences _userPreferences;

        public UserPreferencesService()
        {
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "userpreferences.json");
            _userPreferences = new UserPreferences();
        }

        public async Task SavePreferencesAsync(UserPreferences preferences)
        {
            _userPreferences = preferences;
            var json = JsonSerializer.Serialize(_userPreferences, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_filePath, json);
        }

        public async Task<UserPreferences> LoadPreferencesAsync()
        {
            if (File.Exists(_filePath))
            {
                var json = await File.ReadAllTextAsync(_filePath);
                _userPreferences = JsonSerializer.Deserialize<UserPreferences>(json);
            }
            return _userPreferences;
        }

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

        private void EnableBluetooth()
        {
            // Implement Bluetooth enabling logic here
        }

        private void DisableBluetooth()
        {
            // Implement Bluetooth disabling logic here
        }
    }
}

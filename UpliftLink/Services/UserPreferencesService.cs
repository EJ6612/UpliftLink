using System.Threading.Tasks;
using UpliftLink.UserPref;

namespace UpliftLink.Services
{
    public class UserPreferencesService
    {
        private readonly UserPreferences _userPreferences;
        // WORK WITH JSON TO STORE IF isVisible and PersonalizedMessages are there.
        public UserPreferencesService()
        {
            _userPreferences = new UserPreferences();
        }

        public async Task SavePreferencesAsync(UserPreferences preferences)
        {
            _userPreferences.IsVisible = preferences.IsVisible;
            _userPreferences.PersonalizedMessages = preferences.PersonalizedMessages;
            await Task.Run(() => _userPreferences.SavePreferences());
        }

        public async Task<UserPreferences> LoadPreferencesAsync()
        {
            await Task.Run(() => _userPreferences.LoadPreferences());
            return _userPreferences;
        }
    }
}

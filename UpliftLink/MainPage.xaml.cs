using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using UpliftLink.Pages;
using UpliftLink.Services;

namespace UpliftLink
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            CheckUserExistenceAsync();
        }

        private async Task CheckUserExistenceAsync()
        {
            var userPreferences = await App.UserPreferencesService.LoadPreferencesAsync();

            // Check if user exists based on a specific preference, e.g., PersonalizedMessages
            if (userPreferences.PersonalizedMessages == null || userPreferences.PersonalizedMessages.Count == 0)
            {
                // User does not exist, navigate to CreateUserNamePage
                var newUserPage = new CreateUserNamePage();
                Application.Current.MainPage = new NavigationPage(newUserPage);
            }
            else
            {
                // User exists, proceed with the main page logic
                // You can add additional logic here if needed
            }
        }
    }
}

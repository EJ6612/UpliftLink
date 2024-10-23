using Microsoft.Maui.Controls;
using System.Threading.Tasks;
using UpliftLink.Pages;
using UpliftLink.Services;

namespace UpliftLink
{
    public partial class MainPage : ContentPage
    {
        private readonly JsonService _jsonService;
        public MainPage()
        {
            InitializeComponent();
            _jsonService = new JsonService("user_preferences.json");

            CheckUserExistenceAsync();
        }


        private async Task CheckUserExistenceAsync()
        {
            var userPreferences = await _jsonService.LoadUserPreferencesAsync();

            if (string.IsNullOrEmpty(userPreferences.UserName))
            {
                // User does not exist, navigate to CreateUserNamePage
                var newUserPage = new CreateUserNamePage();
                Application.Current.MainPage = new NavigationPage(newUserPage);
            }

            else
            {
                // User exists, navigate to ReturnedUserUI
                var returningUserPage = new ReturnedUserUI();
                Application.Current.MainPage = new NavigationPage(returningUserPage);
            }
        }
    }
}
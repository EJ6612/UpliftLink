using System.IO;
using UpliftLink.Services;

namespace UpliftLink
{
    public partial class App : Application
    {
        public static string UserPreferencesFilePath { get; private set; }

        public App()
        {
            InitializeComponent();

            // Define the path for the user preferences JSON file
            UserPreferencesFilePath = Path.Combine(FileSystem.AppDataDirectory, "user_preferences.json");

            MainPage = new AppShell();
        }
    }
}

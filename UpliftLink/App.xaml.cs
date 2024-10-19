using UpliftLink.Services;

namespace UpliftLink
{
    public partial class App : Application
    {
        public static UserPreferencesService UserPreferencesService { get; private set; }

        public App()
        {
            InitializeComponent();

            UserPreferencesService = new UserPreferencesService();

            MainPage = new AppShell();
        }
    }
}

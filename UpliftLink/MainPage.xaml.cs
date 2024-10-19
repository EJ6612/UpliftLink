using AuthenticationServices;
using Microsoft.Maui.Controls;
using UpliftLink.Pages;

namespace UpliftLink
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();

            // Write code to deterimine if user already exists
            
            // if...
            var NewUserPage = new CreateUserNamePage();
            Application.Current.MainPage = new NavigationPage(NewUserPage);

            // else...
            
        }

        
    }

}

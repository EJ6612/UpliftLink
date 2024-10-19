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

            //Navigation.PushAsync(new CreateUserNamePage());
            //Navigation.PopToRootAsync();

            var NewUserPage = new CreateUserNamePage();
            Application.Current.MainPage = new NavigationPage(NewUserPage);

            
        }

        
    }

}

namespace UpliftLink.Pages;

public partial class UserSettingsPage : ContentPage
{
	public UserSettingsPage()
	{
		InitializeComponent();
	}

    private async void IncomingPreferenceButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new SelectIncomingMessagesPage());
    }

    private async void OutgoingEditButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new CreateOutgoingMessagesPage());
    }
}
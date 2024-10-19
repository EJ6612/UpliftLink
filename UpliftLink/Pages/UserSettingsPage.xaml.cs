namespace UpliftLink.Pages;

public partial class UserSettingsPage : ContentPage
{
	public UserSettingsPage()
	{
		InitializeComponent();
	}

	/// <summary>
	/// Open the Incoming Preference Page
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private async void IncomingPreferenceButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new SelectIncomingMessagesPage());
    }

	/// <summary>
	/// Open the Outgoing Messages Page
	/// </summary>
	/// <param name="sender"></param>
	/// <param name="e"></param>
    private async void OutgoingEditButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new CreateOutgoingMessagesPage());
    }
}
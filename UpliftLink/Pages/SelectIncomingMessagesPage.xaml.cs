namespace UpliftLink.Pages;

public partial class SelectIncomingMessagesPage : ContentPage
{

	private string userPreference = "";
	public SelectIncomingMessagesPage()
	{
		InitializeComponent();

		// Code here to set the picker (from JSON, or set to pick-me-up if new user)
	}

    private void IncomingMessagesPreference_SelectedIndexChanged(object sender, EventArgs e)
    {
		// Take choice from picker and save it to string
		var picker = (Picker)sender;
		userPreference = (string)picker.SelectedItem;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new MainPage());
    }
}
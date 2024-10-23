using Microsoft.VisualBasic;

namespace UpliftLink.Pages;

public partial class SelectIncomingMessagesPage : ContentPage
{
	private string userPreference = "";

	public SelectIncomingMessagesPage()
	{
		InitializeComponent();

		IncomingMessagesPreference.SelectedIndex = 0;

		// TODO set the picker (from JSON, or set to pick-me-up if new user)
	}

    private void IncomingMessagesPreference_SelectedIndexChanged(object sender, EventArgs e)
    {
		// Take choice from picker and save it to string
		var picker = (Picker)sender;
		userPreference = (string)picker.SelectedItem;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
		// Once user saves choice, proceed to the next page

		// TODO logic for new or returning user
		// TODO save changes to JSON

		await Navigation.PushAsync(new MainPage());
    }
}
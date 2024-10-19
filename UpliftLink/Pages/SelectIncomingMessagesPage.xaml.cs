namespace UpliftLink.Pages;

public partial class SelectIncomingMessagesPage : ContentPage
{

	private string userPreference = "";
	public SelectIncomingMessagesPage()
	{
		InitializeComponent();
	}

    private void IncomingMessagesPreference_SelectedIndexChanged(object sender, EventArgs e)
    {
		var picker = (Picker)sender;
		userPreference = (string)picker.SelectedItem;
    }

    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new IncomingMessagesPage());
    }
}
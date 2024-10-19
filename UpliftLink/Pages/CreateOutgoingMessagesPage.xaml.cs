namespace UpliftLink.Pages;

public partial class CreateOutgoingMessagesPage : ContentPage
{
	public CreateOutgoingMessagesPage()
	{
		InitializeComponent();
		SaveButton.IsEnabled = AreAllEditorsFilled();

		// Code here: Check JSON, fill if not new user.
	}

	/// <summary>
	/// Check if all the editors have content.
	/// </summary>
	/// <returns></returns>
	private bool AreAllEditorsFilled()
	{
		return !string.IsNullOrWhiteSpace(UpliftingMessageInput.Text) &&
				!string.IsNullOrWhiteSpace(HumorousMessageInput.Text) &&
				!string.IsNullOrWhiteSpace(ServiceIdeaMessageInput.Text) &&
				!string.IsNullOrWhiteSpace(QuoteMessageInput.Text);
	}

    private void Input_TextChanged(object sender, TextChangedEventArgs e)
    {
		SaveButton.IsEnabled = AreAllEditorsFilled();
    }


    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
		string pickMeUpMessage = 	UpliftingMessageInput.Text;
		string humorousMessage = 	HumorousMessageInput.Text;
		string serviceIdeaMessage = ServiceIdeaMessageInput.Text;
		string quoteMessage = 		QuoteMessageInput.Text;

		// Save strings to JSON

		await Navigation.PushAsync(new SelectIncomingMessagesPage());
    }

}
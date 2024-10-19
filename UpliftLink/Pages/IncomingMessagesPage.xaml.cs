namespace UpliftLink.Pages;

public partial class IncomingMessagesPage : ContentPage
{
	public IncomingMessagesPage()
	{
		InitializeComponent();

		// foreach message in messages, maximum 20
		CreateChatBubble("All the single ladies! All the single ladies! ", "Beyonce-With-A-Knife-3000");
		CreateChatBubble("Are we out of the woods yet are we out of the woods yet are we out of the woods are we in the clear yet are we in the clear yet are in in the clear yet in the clear yet good", "Obsessive-Catlady-1989");
	}

	/// <summary>
	/// Create a chat bubble for incoming message.
	/// </summary>
	/// <param name="message">Message content</param>
	/// <param name="senderName">Sender name</param>
	private void CreateChatBubble(string message, string senderName)
	{
		// Message bubble
		var messageLabel = new Label 
		{
			Text = message,
			TextColor = Colors.White,
			FontSize = 16, 
			HorizontalOptions = LayoutOptions.Start,
			VerticalOptions = LayoutOptions.Center

		};

		var chatBubble = new Frame 
		{
			Content = messageLabel,
			Padding = new Thickness(15),
			CornerRadius = 15,
			HasShadow = true,
			BorderColor = Colors.Transparent,
			BackgroundColor = Color.FromArgb("#1EBE46"),
			HorizontalOptions = LayoutOptions.Start,
			Margin = new Thickness(1, 1),
			WidthRequest = 250

		};

		// Sender name
		var messageSenderName = new Label
		{
			Text = senderName,
			FontSize = 14,
			HorizontalOptions = LayoutOptions.Start
		};

		var chatObject = new VerticalStackLayout
		{
			Padding = new Thickness(0, 5, 0, 5),
			Spacing = 5,
		};

		chatObject.Children.Add(messageSenderName);
		chatObject.Children.Add(chatBubble);

		StackLayout.Children.Add(chatObject);
	}

	
}
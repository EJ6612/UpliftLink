namespace UpliftLink.Pages;

public partial class IncomingMessagesPage : ContentPage
{
	public IncomingMessagesPage()
	{
		InitializeComponent();

		// foreach message in messages, maximum 20
		CreateChatBubble("Wave to 5 people today.", "Bouncing-Fish-4957");
		CreateChatBubble("Call a friend you haven't spoken to in a while.", "Jazzy-Crayon-5184");
		CreateChatBubble("Call a friend you haven't spoken to in a while.", "Jazzy-Crayon-5184");
		CreateChatBubble("Call a friend you haven't spoken to in a while.", "Jazzy-Crayon-5184");
		CreateChatBubble("Call a friend you haven't spoken to in a while.", "Jazzy-Crayon-5184");
		CreateChatBubble("Call a friend you haven't spoken to in a while.", "Jazzy-Crayon-5184");

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
			Margin = new Thickness(1, 1, 5, 1)
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
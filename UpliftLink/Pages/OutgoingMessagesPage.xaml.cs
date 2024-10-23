namespace UpliftLink.Pages;

public partial class OutgoingMessagesPage : ContentPage
{
	public OutgoingMessagesPage()
	{
		InitializeComponent();

		// TODO load message stats in from JSON

		// ! Remove manual messages after TODO is completed
		CreateChatBubble("You've got this!", "Lift-me-up", 8);
		CreateChatBubble("Love one another -Jesus Christ", "Quote", 5);
		CreateChatBubble("Instead of Abinadi, what if Abinasurvived.", "Humor", 11);
		CreateChatBubble("Give someone an orange, if they're not allergic.", "Service Idea", 2);
		// ! ----------------------------------------------
	}

	/// <summary>
	/// Create a chat bubble for outgoing message.
	/// </summary>
	/// <param name="message">The message the user set for the category.</param>
	/// <param name="category">The message category.</param>
	/// <param name="count">Count of how many times category sent out.</param>
	private void CreateChatBubble(string message, string category, int count)
	{
		// Message bubble
		var messageLabel = new Label 
		{
			Text = message,
			TextColor = Colors.Black,
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
			BackgroundColor = Color.FromArgb("#FF92ECA9"),
			HorizontalOptions = LayoutOptions.End,
			Margin = new Thickness(5, 1, 1, 1)
		};

		// Sender name above bubble
		var messageSenderName = new Label
		{
			Text = $"{count} {category} messages shared.",
			FontSize = 14,
			HorizontalOptions = LayoutOptions.End
		};

		var chatObject = new VerticalStackLayout
		{
			Padding = new Thickness(0, 5, 0, 20),
			Spacing = 5,
		};

		chatObject.Children.Add(messageSenderName);
		chatObject.Children.Add(chatBubble);

		StackLayout.Children.Add(chatObject);
	}
}
namespace UpliftLink.Pages;

public partial class OutgoingMessagesPage : ContentPage
{
	public OutgoingMessagesPage()
	{
		InitializeComponent();
		CreateChatBubble("OOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOOO AAAAAAAAAAAAAAAAAAAAAAAA", "Lift-me-up", 4);
		CreateChatBubble("hehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehehe", "Quote", 2);
		CreateChatBubble("oh yeah oh yeah i like that ooooohhhhhh my gooooooosh GOLLY GEE GOVNAR", "Service Idea", 249);
	}

	private void CreateChatBubble(string message, string category, int count)
	{
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
			BackgroundColor = Colors.SkyBlue,
			HorizontalOptions = LayoutOptions.End,
			Margin = new Thickness(1, 1),
			WidthRequest = 250

		};

		var messageSenderName = new Label
		{
			Text = $"{category}s sent: {count}",
			FontSize = 14,
			HorizontalOptions = LayoutOptions.End
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
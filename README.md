# Inspiration
StreetPass from the Nintendo 3DS Family. Devices would pass by each other and exchange fun (and safe) information preset by the user.

# What it does
When two devices with Uplift Link are within range of one another, they send each other a message prewritten to one of four prompts. The user has set one of four categories of message they want (Lift-me-up, Humor, Quote, Service Idea). They will then receive that category of message. The app will hold onto messages for 24 hours.

Usernames are randomly generated.

# How we built it
We built the app using .NET MAUI (C# XAML). We chose this because C# was the one app-based language we mutually understand well.

# Challenges we ran into
The IDE on MacOS was difficult to set up, git + GPG keys broke on a Windows laptop, and .NET MAUI at times feels underbaked. We could go on about the pains of the tools.

Coding challenges included figuring out the hurdle of modern Bluetooth limitations, server considerations, proximity services, and saving to JSON files (that's what defeated us at hour 23).

# Accomplishments that we're proud of
When the JSON issues are removed, the UI is 95% complete. Messages are set up to load. Bluetooth discoverability is ready to go. App icon looks cool. Setup is straightforward. We're also proud of our planning process: Structure Chart, UMLs, UI drawn out on whiteboard, to-do lists with boxes checked off, and we were able to cover each other's weaknesses.

As it turns out, it works on iOS (but not Android). We're proud of that.

# What we learned
Jarom: I do not have much experience with C#. My class went over get, set for the first time last week. I learned much about the conventions of C#, compared to python. I designed a streamlined to-do list to manage our work and learned about structure diagrams, as well as class diagrams. Elijah: UX design in an IDE and framework without a live view; strengthening of git knowledge; better collaboration skills; better troubleshooting methods; increased experience with C# and XAML.

# What's next for Uplift Link
Figure out JSON file saving woes, and real world testing. We need sleep.

Built With
.net
c#
maui
visual-studio-2022
visual-studio-code
xaml
xcode

Try it out

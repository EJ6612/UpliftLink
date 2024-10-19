using System.Collections.Generic;

namespace UpliftLink.Models
{
    public class UserPreferences
    {
        public bool IsVisible { get; set; }
        public string UserName { get; set; }
        public string PreferredIncoming { get; set; }
        public OutgoingMessages OutgoingMessages { get; set; }
        public int BluetoothToggle { get; set; }
    }

    public class OutgoingMessages
    {
        public string LiftMeUp { get; set; }
        public string Humor { get; set; }
        public string Quote { get; set; }
        public string Service { get; set; }
    }
}

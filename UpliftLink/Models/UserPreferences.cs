using System.Collections.Generic;

namespace UpliftLink.Models
{
    public class UserPreferences
    {
        public bool IsVisible { get; set; }
        public List<string> PersonalizedMessages { get; set; }

        public UserPreferences()
        {
            PersonalizedMessages = new List<string>();
        }
    }
}

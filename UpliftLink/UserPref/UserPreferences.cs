using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpliftLink.UserPref
{
    public class UserPreferences
    {
        public bool IsVisible { get; set; }
        public List<string> PersonalizedMessages { get; set; }

        public UserPreferences()
        {
            PersonalizedMessages = new List<string>();
        }

        public void SavePreferences()
        {
            // Logic to save preferences (e.g., to local storage)
        }

        public void LoadPreferences()
        {
            // Logic to load preferences (e.g., from local storage)
        }
    }
}
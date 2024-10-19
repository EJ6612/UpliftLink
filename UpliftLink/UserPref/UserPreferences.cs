using System;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.Maui.Essentials;

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
            try
            {
                // Save IsVisible
                Preferences.Set("IsVisible", IsVisible);

                // Serialize and save PersonalizedMessages
                string messagesJson = JsonSerializer.Serialize(PersonalizedMessages);
                Preferences.Set("PersonalizedMessages", messagesJson);
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine($"Error saving preferences: {ex.Message}");
            }
        }

        public void LoadPreferences()
        {
            try
            {
                // Load IsVisible
                IsVisible = Preferences.Get("IsVisible", false);

                // Load and deserialize PersonalizedMessages
                string messagesJson = Preferences.Get("PersonalizedMessages", string.Empty);
                if (!string.IsNullOrEmpty(messagesJson))
                {
                    PersonalizedMessages = JsonSerializer.Deserialize<List<string>>(messagesJson);
                }
            }
            catch (Exception ex)
            {
                // Handle or log the exception as needed
                Console.WriteLine($"Error loading preferences: {ex.Message}");
            }
        }
    }
}

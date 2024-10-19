using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UpliftLink.UserPref;

namespace UpliftLink.Services
{
    public class MessageService
    {
        private List<string> personalizedMessages;
        private UserPreferences userPreferences;

        public MessageService(UserPreferences preferences)
        {
            userPreferences = preferences;
            personalizedMessages = preferences.PersonalizedMessages;
        }

        public async Task SendMessageAsync(string message)
        {
            try
            {
                // Logic to send the message to nearby devices
                await Task.Run(() => Console.WriteLine($"Sending message: {message}"));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
        }

        public void AddPersonalizedMessage(string message)
        {
            personalizedMessages.Add(message);
            userPreferences.PersonalizedMessages = personalizedMessages;
            userPreferences.SavePreferences();
        }

        public List<string> GetPersonalizedMessages()
        {
            return personalizedMessages;
        }
    }
}

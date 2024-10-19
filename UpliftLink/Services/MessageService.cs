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

        public MessageService(UserPreferences preferences)
        {
            personalizedMessages = preferences.PersonalizedMessages;
        }

        public void SendMessage(string message)
        {
            // Logic to send the message to nearby devices
        }

        public void AddPersonalizedMessage(string message)
        {
            personalizedMessages.Add(message);
            // Optionally save to UserPreferences
        }

        public List<string> GetPersonalizedMessages()
        {
            return personalizedMessages;
        }
    }
}
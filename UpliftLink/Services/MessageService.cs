using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using UpliftLink.Models;

namespace UpliftLink.Services
{
    public class MessageService
    {
        private readonly string _filePath;
        private List<IncomingMessage> _incomingMessages;
        private OutgoingMessageCount _outgoingMessageCount;
        private UserPreferences _userPreferences;

        /// <summary>
        /// Initializes a new instance of the <see cref="MessageService"/> class.
        /// </summary>
        /// <param name="preferences">User preferences.</param>
        public MessageService(UserPreferences preferences)
        {
            _userPreferences = preferences;
            _filePath = Path.Combine(FileSystem.AppDataDirectory, "messages.json");
            _incomingMessages = new List<IncomingMessage>();
            _outgoingMessageCount = new OutgoingMessageCount();
        }

        /// <summary>
        /// Adds a new incoming message and saves it to the JSON file.
        /// </summary>
        /// <param name="senderUserName">The username of the sender.</param>
        /// <param name="content">The content of the message.</param>
        /// <param name="sender">The sender of the message.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task AddIncomingMessageAsync(string senderUserName, string content, string sender)
        {
            var incomingMessage = new IncomingMessage(content, sender, DateTime.UtcNow, senderUserName);
            _incomingMessages.Add(incomingMessage);
            await SaveMessagesAsync();
        }

        /// <summary>
        /// Increments the count of outgoing messages for a given category and saves it to the JSON file.
        /// </summary>
        /// <param name="category">The category of the message.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task IncrementOutgoingMessageCountAsync(string category)
        {
            if (_outgoingMessageCount.CategoryCounts.ContainsKey(category))
            {
                _outgoingMessageCount.CategoryCounts[category]++;
            }

            else
            {
                _outgoingMessageCount.CategoryCounts[category] = 1;
            }

            await SaveMessagesAsync();
        }

        /// <summary>
        /// Cleans up messages older than 24 hours and saves the updated list to the JSON file.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CleanUpOldMessagesAsync()
        {
            var cutoffTime = DateTime.UtcNow.AddHours(-24);

            _incomingMessages = _incomingMessages.Where(m => m.Timestamp >= cutoffTime).ToList();

            await SaveMessagesAsync();
        }

        /// <summary>
        /// Saves the list of incoming messages and outgoing message count to the JSON file.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task SaveMessagesAsync()
        {
            var messages = new
            {
                incomingMessages = _incomingMessages,
                outgoingMessages = _outgoingMessageCount
            };

            var json = JsonSerializer.Serialize(messages, new JsonSerializerOptions { WriteIndented = true });

            await File.WriteAllTextAsync(_filePath, json);
        }

        /// <summary>
        /// Loads incoming and outgoing messages from the JSON file.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task LoadMessagesAsync()
        {
            if (File.Exists(_filePath))
            {
                var json = await File.ReadAllTextAsync(_filePath);
                var messages = JsonSerializer.Deserialize<Messages>(json);

                // TODO error check
                _incomingMessages = messages.IncomingMessages;
                _outgoingMessageCount = messages.OutgoingMessages;
            }
        }

        /// <summary>
        /// Gets the list of incoming messages.
        /// </summary>
        /// <returns>The list of incoming messages.</returns>
        public List<IncomingMessage> GetIncomingMessages()
        {
            return _incomingMessages;
        }

        /// <summary>
        /// Gets the outgoing message count.
        /// </summary>
        /// <returns>The outgoing message count.</returns>
        public OutgoingMessageCount GetOutgoingMessageCount()
        {
            return _outgoingMessageCount;
        }
    }

    /// <summary>
    /// Represents the combined structure of incoming and outgoing messages.
    /// </summary>
    public class Messages
    {
        // TODO? declare as nullable?
        public List<IncomingMessage> IncomingMessages { get; set; }
        public OutgoingMessageCount OutgoingMessages { get; set; }
    }
}

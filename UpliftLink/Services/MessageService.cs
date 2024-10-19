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
        private readonly string _incomingFilePath;
        private readonly string _outgoingFilePath;
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
            _incomingFilePath = Path.Combine(FileSystem.AppDataDirectory, "incomingMessages.json");
            _outgoingFilePath = Path.Combine(FileSystem.AppDataDirectory, "outgoingMessageCount.json");
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
            await SaveIncomingMessagesAsync();
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
            await SaveOutgoingMessageCountAsync();
        }

        /// <summary>
        /// Cleans up messages older than 24 hours and saves the updated list to the JSON file.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CleanUpOldMessagesAsync()
        {
            var cutoffTime = DateTime.UtcNow.AddHours(-24);
            _incomingMessages = _incomingMessages.Where(m => m.Timestamp >= cutoffTime).ToList();
            await SaveIncomingMessagesAsync();
        }

        /// <summary>
        /// Saves the list of incoming messages to the JSON file.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task SaveIncomingMessagesAsync()
        {
            var json = JsonSerializer.Serialize(_incomingMessages, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_incomingFilePath, json);
        }

        /// <summary>
        /// Saves the outgoing message count to the JSON file.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        private async Task SaveOutgoingMessageCountAsync()
        {
            var json = JsonSerializer.Serialize(_outgoingMessageCount, new JsonSerializerOptions { WriteIndented = true });
            await File.WriteAllTextAsync(_outgoingFilePath, json);
        }

        /// <summary>
        /// Loads incoming and outgoing messages from their respective JSON files.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task LoadMessagesAsync()
        {
            if (File.Exists(_incomingFilePath))
            {
                var json = await File.ReadAllTextAsync(_incomingFilePath);
                _incomingMessages = JsonSerializer.Deserialize<List<IncomingMessage>>(json);
            }

            if (File.Exists(_outgoingFilePath))
            {
                var json = await File.ReadAllTextAsync(_outgoingFilePath);
                _outgoingMessageCount = JsonSerializer.Deserialize<OutgoingMessageCount>(json);
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
}

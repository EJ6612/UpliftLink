using System;
using System.Collections.Generic;

namespace UpliftLink.Models
{
    /// <summary>
    /// Represents a generic message.
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Gets or sets the content of the message.
        /// </summary>
        public string Content { get; set; }

        /// <summary>
        /// Gets or sets the sender of the message.
        /// </summary>
        public string Sender { get; set; }

        /// <summary>
        /// Gets or sets the timestamp of when the message was sent.
        /// </summary>
        public DateTime Timestamp { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Message"/> class.
        /// </summary>
        /// <param name="content">The content of the message.</param>
        /// <param name="sender">The sender of the message.</param>
        /// <param name="timestamp">The timestamp of when the message was sent.</param>
        public Message(string content, string sender, DateTime timestamp)
        {
            Content = content;
            Sender = sender;
            Timestamp = timestamp;
        }
    }

    /// <summary>
    /// Represents an incoming message with additional sender username information.
    /// </summary>
    public class IncomingMessage : Message
    {
        /// <summary>
        /// Gets or sets the username of the sender.
        /// </summary>
        public string SenderUserName { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="IncomingMessage"/> class.
        /// </summary>
        /// <param name="content">The content of the message.</param>
        /// <param name="sender">The sender of the message.</param>
        /// <param name="timestamp">The timestamp of when the message was sent.</param>
        /// <param name="senderUserName">The username of the sender.</param>
        public IncomingMessage(string content, string sender, DateTime timestamp, string senderUserName)
            : base(content, sender, timestamp)
        {
            SenderUserName = senderUserName;
        }
    }

    /// <summary>
    /// Represents the count of outgoing messages categorized by type.
    /// </summary>
    public class OutgoingMessageCount
    {
        /// <summary>
        /// Gets or sets the dictionary that holds the count of outgoing messages for each category.
        /// </summary>
        public Dictionary<string, int> CategoryCounts { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="OutgoingMessageCount"/> class.
        /// </summary>
        public OutgoingMessageCount()
        {
            CategoryCounts = new Dictionary<string, int>();
        }
    }
}

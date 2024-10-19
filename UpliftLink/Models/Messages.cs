using System;
using System.Collections.Generic;

namespace UpliftLink.Models
{
    public class Message
    {
        public string Content { get; set; }
        public string Sender { get; set; }
        public DateTime Timestamp { get; set; }

        public Message(string content, string sender, DateTime timestamp)
        {
            Content = content;
            Sender = sender;
            Timestamp = timestamp;
        }
    }

    public class IncomingMessage : Message
    {
        public string SenderUserName { get; set; }

        public IncomingMessage(string content, string sender, DateTime timestamp, string senderUserName)
            : base(content, sender, timestamp)
        {
            SenderUserName = senderUserName;
        }
    }

    public class OutgoingMessageCount
    {
        public Dictionary<string, int> CategoryCounts { get; set; }

        public OutgoingMessageCount()
        {
            CategoryCounts = new Dictionary<string, int>();
        }
    }
}

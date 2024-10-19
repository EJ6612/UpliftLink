using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
}

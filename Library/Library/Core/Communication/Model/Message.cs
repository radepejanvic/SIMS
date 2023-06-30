using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library.Serializer;

namespace Library.Model
{
    public class Message : ISerializable
    {
        public int Id { get; set; }
        public string SenderUsername { get; set; }
        public string RecipientUsername { get; set; }
        public string MessageText { get; set; }
        public DateTime Time { get; set ; }
        public Message() { }

        public Message(string senderUsername, string recipientUsername, string messageText, DateTime time)
        {
            SenderUsername = senderUsername;
            RecipientUsername = recipientUsername;
            MessageText = messageText;
            Time = time;
        }
    }
}

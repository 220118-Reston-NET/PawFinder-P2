using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace PawFinderModel
{
    public class Message
    {
        [Key]
        public int messageID { get; set; }
        public int SenderID { get; set; }
        public User Sender{ get; set; }
        public int ReceiverID { get; set; }
        public User Receiver{ get; set; }
        public string messageText { get; set; }
        public DateTime messageTimeStamp { get; set; }

        public Message()
        {
            SenderID = 0;
            ReceiverID = 0;
            messageTimeStamp = new DateTime();

        }
    }
}
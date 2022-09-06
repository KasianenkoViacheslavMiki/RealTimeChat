using System;
using System.Collections.Generic;

namespace Reenbit.TestTask.RealTimeChat.Models
{
    public partial class Room
    {
        public Room()
        {
            Messages = new HashSet<Message>();
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string? RoomName { get; set; }
        public bool? TypeRoom { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}

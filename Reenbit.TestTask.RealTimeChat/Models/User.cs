using System;
using System.Collections.Generic;

namespace Reenbit.TestTask.RealTimeChat.Models
{
    public partial class User
    {
        public User()
        {
            Messages = new HashSet<Message>();
            Participants = new HashSet<Participant>();
        }

        public int Id { get; set; }
        public string? UserName { get; set; }
        public string? UserPassword { get; set; }

        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}

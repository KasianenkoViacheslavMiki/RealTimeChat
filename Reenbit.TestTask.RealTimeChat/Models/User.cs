using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Reenbit.TestTask.RealTimeChat.Models
{
    public partial class User : IdentityUser
    {
        public User()
        {
            Messages = new HashSet<Message>();
            Participants = new HashSet<Participant>();
        }


        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<Participant> Participants { get; set; }
    }
}

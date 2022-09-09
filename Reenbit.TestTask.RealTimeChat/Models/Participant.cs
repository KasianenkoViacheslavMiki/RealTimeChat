using System;
using System.Collections.Generic;

namespace Reenbit.TestTask.RealTimeChat.Models
{
    public partial class Participant
    {
        public int Id { get; set; }
        public string? UserId { get; set; }
        public int? RoomId { get; set; }

        public virtual Room? Room { get; set; }
        public virtual User? User { get; set; }
    }
}
